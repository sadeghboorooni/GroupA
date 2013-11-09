using System.Web;

namespace jQueryUploadTest {
	public class Thumbnail : IHttpHandler {

		public void ProcessRequest (HttpContext context) {
			context.Response.ContentType = "image/jpg";
            string s = context.Request["f"];
			context.Response.WriteFile(context.Server.MapPath("~/member/advsimages/main/"+context.Request["id"]+"/"+s));
		}

		public bool IsReusable { get { return false; } }
	}
}
