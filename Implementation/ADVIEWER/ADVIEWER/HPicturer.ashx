<%@ WebHandler Language="VB" Class="HPicturer" %>

Imports System
Imports System.Web
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text

Public Class HPicturer : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
    
        
        Dim Response As HttpResponse = context.Response
        Dim Request As HttpRequest = context.Request

        
        Dim imgHeight, imgWidth As Integer
        Dim maxwidth As String = Request.QueryString("w")
        Dim maxheight As String = Request.QueryString("h")
        Dim AllowThumb As Boolean
        If Request.QueryString("thumb") Is Nothing Or Request.QueryString("thumb") = "" Then
            AllowThumb = True
        Else
            AllowThumb = Convert.ToBoolean(Request.QueryString("thumb"))
        End If
       
        
     
        
        'Get information about the image
        Dim imageUrl As String = Request.QueryString("path") '+ "/" + Path.GetFileName(Request.QueryString("img"))
        Dim fullSizeImg As System.Drawing.Image
        Try
            fullSizeImg = System.Drawing.Image.FromFile(context.Server.MapPath(imageUrl))
        Catch
            fullSizeImg = System.Drawing.Image.FromFile(context.Server.MapPath("~/styles/images/nopic11.jpg"))

        End Try
        
        
        

        imgHeight = fullSizeImg.Height
        imgWidth = fullSizeImg.Width
        If AllowThumb = True Then
            If imgWidth > maxwidth Or imgHeight > maxheight Then
                'Determine what dimension is off by more
                Dim deltaWidth As Integer = imgWidth - maxwidth
                Dim deltaHeight As Integer = imgHeight - maxheight
                Dim scaleFactor As Double

                If deltaHeight > deltaWidth Then
                    'Scale by the height
                    scaleFactor = maxheight / imgHeight
                Else
                    'Scale by the Width
                    scaleFactor = maxwidth / imgWidth
                End If

              
                
                    imgWidth *= scaleFactor
                    imgHeight *= scaleFactor
                End If
        
   
                Dim bmPhoto As New Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb)
  
                bmPhoto.SetResolution(72, 72)

                Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
       
                grPhoto.SmoothingMode = SmoothingMode.HighQuality
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality
                grPhoto.DrawImage(fullSizeImg, New Rectangle(0, 0, imgWidth, imgHeight), 0, 0, fullSizeImg.Width, fullSizeImg.Height, GraphicsUnit.Pixel)

                Dim mm As New MemoryStream()
                bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg)
                Response.ContentType = "image/jpeg"
                Response.Cache.SetCacheability(HttpCacheability.Public)
                Response.BufferOutput = False
                Response.OutputStream.Write(mm.GetBuffer(), 0, mm.GetBuffer().Length)
            Else
            
    
                Dim bmPhoto As New Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb)
  
                bmPhoto.SetResolution(72, 72)

                Dim grPhoto As Graphics = Graphics.FromImage(bmPhoto)
       
                grPhoto.SmoothingMode = SmoothingMode.HighQuality
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic
                grPhoto.PixelOffsetMode = PixelOffsetMode.HighQuality
                grPhoto.DrawImage(fullSizeImg, New Rectangle(0, 0, imgWidth, imgHeight), 0, 0, fullSizeImg.Width, fullSizeImg.Height, GraphicsUnit.Pixel)

                Dim mm As New MemoryStream()
                bmPhoto.Save(mm, System.Drawing.Imaging.ImageFormat.Jpeg)
                Response.ContentType = "image/jpeg"
                Response.Cache.SetCacheability(HttpCacheability.Public)
                Response.BufferOutput = False
                Response.OutputStream.Write(mm.GetBuffer(), 0, mm.GetBuffer().Length)
            End If
                
        
    End Sub
    Function ThumbnailCallback() As Boolean
        Return False

    End Function
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class