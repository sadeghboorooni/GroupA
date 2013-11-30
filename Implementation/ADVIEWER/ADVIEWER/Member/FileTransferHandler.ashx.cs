using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace ADVIEWER.BAL {
	public class FileTransferHandler : IHttpHandler {
		private readonly JavaScriptSerializer js = new JavaScriptSerializer();

        private string mode;
        private string id;
		public string StorageRoot {
            get 
            {
                string username = Membership.GetUser().UserName.ToLower();

                
                {
                    string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/member/advsimages/main/" + id + "/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    return folderPath;
                }
                //else
                //{
                //    string folderPath = System.Web.HttpContext.Current.Server.MapPath("~/member/advsimages/main/" + id + "/");
                    
                //    return folderPath;
                //}
                
            }
		}
		public bool IsReusable { get { return false; } }

		public void ProcessRequest (HttpContext context) {
            mode = context.Request["mode"];
            id = context.Request["id"];
			context.Response.AddHeader("Pragma", "no-cache");
			context.Response.AddHeader("Cache-Control", "private, no-cache");

			HandleMethod(context);
		}

		// Handle request based on method
		private void HandleMethod (HttpContext context) {
			switch (context.Request.HttpMethod) {
				case "HEAD":
				case "GET":
					if (GivenFilename(context)) DeliverFile(context);
					else ListCurrentFiles(context);
					break;

				case "POST":
				case "PUT":
					UploadFile(context);
					break;

				case "DELETE":
					DeleteFile(context);
					break;

				case "OPTIONS":
					ReturnOptions(context);
					break;

				default:
					context.Response.ClearHeaders();
					context.Response.StatusCode = 405;
					break;
			}
		}

		private static void ReturnOptions(HttpContext context) {
			context.Response.AddHeader("Allow", "DELETE,GET,HEAD,POST,PUT,OPTIONS");
			context.Response.StatusCode = 200;
		}

		// Delete file from the server
		private void DeleteFile (HttpContext context) {
            mode = context.Request["mode"];
            id = context.Request["id"];
			var filePath = StorageRoot + context.Request["f"];
			if (File.Exists(filePath)) {
				File.Delete(filePath);
			}
		}

		// Upload file to the server
		private void UploadFile (HttpContext context) {
			var statuses = new List<FilesStatus>();
			var headers = context.Request.Headers;

			if (string.IsNullOrEmpty(headers["X-File-Name"])) {
				UploadWholeFile(context, statuses);
			} else {
				UploadPartialFile(headers["X-File-Name"], context, statuses);
			}

			WriteJsonIframeSafe(context, statuses);
		}

		// Upload partial file
		private void UploadPartialFile (string fileName, HttpContext context, List<FilesStatus> statuses) {
			if (context.Request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
			var inputStream = context.Request.Files[0].InputStream;
			var fullName = StorageRoot + Path.GetFileName(fileName);

			using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write)) {
				var buffer = new byte[1024];

				var l = inputStream.Read(buffer, 0, 1024);
				while (l > 0) {
					fs.Write(buffer, 0, l);
					l = inputStream.Read(buffer, 0, 1024);
				}
				fs.Flush();
				fs.Close();
			}
			statuses.Add(new FilesStatus(new FileInfo(fullName),mode,id));
		}

		// Upload entire file
		private void UploadWholeFile (HttpContext context, List<FilesStatus> statuses) {
			for (int i = 0; i < context.Request.Files.Count; i++) {
				var file = context.Request.Files[i];
				file.SaveAs(StorageRoot + Path.GetFileName(file.FileName));

				string fullName = Path.GetFileName(file.FileName);
				statuses.Add(new FilesStatus(fullName, file.ContentLength,mode,id));
			}
		}

		private void WriteJsonIframeSafe (HttpContext context, List<FilesStatus> statuses) {
			context.Response.AddHeader("Vary", "Accept");
			try {
				if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
					context.Response.ContentType = "application/json";
				else
					context.Response.ContentType = "text/plain";
			} catch {
				context.Response.ContentType = "text/plain";
			}

			var jsonObj = js.Serialize(statuses.ToArray());
			context.Response.Write(jsonObj);
		}

		private static bool GivenFilename (HttpContext context) {
			return !string.IsNullOrEmpty(context.Request["f"]);
		}

		private void DeliverFile (HttpContext context) {
			var filename = context.Request["f"];
			var filePath = StorageRoot + filename;

			if (File.Exists(filePath)) {
				context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
				context.Response.ContentType = "application/octet-stream";
				context.Response.ClearContent();
				context.Response.WriteFile(filePath);
			} else
				context.Response.StatusCode = 404;
		}

		private void ListCurrentFiles (HttpContext context) {
			var files =
				new DirectoryInfo(StorageRoot)
					.GetFiles("*", SearchOption.TopDirectoryOnly)
					.Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden))
					.Select(f => new FilesStatus(f,mode,id))
					.ToArray();

			string jsonObj = js.Serialize(files);
			context.Response.AddHeader("Content-Disposition", "inline; filename=\"files.json\"");
			context.Response.Write(jsonObj);
			context.Response.ContentType = "application/json";
		}
	}
}