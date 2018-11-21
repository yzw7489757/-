using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace QGYHelper.Util
{
    /// <summary>
    ///ImageHelper 的摘要说明
    /// </summary>
    public class ImageHelper
    {
        public ImageHelper()
        {}

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="save_path">保存路径</param>
        /// <param name="save_path_thumb">缩略图保存路径</param>
        /// <param name="img_format">图片格式</param>
        /// <param name="file">保存文件夹名</param>
        /// <returns></returns>
        public static bool SaveImg(Bitmap img, ref string save_path,ref string save_path_thumb, string img_format = "jpg", string file = "")
        {
            #region 检查保存路径

            string path = "/uploads/img/";
            if (!string.IsNullOrEmpty(file))
            {
                path = "/uploads/img/" + file + "/";
            }
            string FullPath = HttpContext.Current.Request.MapPath(path);
            if (!System.IO.Directory.Exists(FullPath))
            {
                System.IO.Directory.CreateDirectory(FullPath);
            }

            #endregion

            img_format = img_format.ToLower();
            string FileName = "img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + img_format;
            string FileNameThumb = "img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_thumb." + img_format;
            int default_thumb_size = 280;
            if (img_format != "gif")
            {
                #region 保存图片

                #region 缩略图

                //Image img_thumb = ResizeImage(img, default_thumb_size, default_thumb_size);
                Image.GetThumbnailImageAbort myCallback = null;
                Image img_thumb = img.GetThumbnailImage(default_thumb_size, default_thumb_size, myCallback, IntPtr.Zero);

                #endregion

                switch (img_format)
                {
                    case "png": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Png);
                        img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    case "bmp": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "gif": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    default: img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }

                #endregion
            }
            else//GIF图
            {
                #region 保存图片

                #region 保存原图

                img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Gif);

                #endregion

                #region 保存缩略图

                Gif.GifHelper gh = new Gif.GifHelper();
                gh.Thumbnail(FullPath + FileName, default_thumb_size, FullPath + FileNameThumb);

                #endregion

                #endregion
            }
            save_path = path + FileName;
            save_path_thumb = path + FileNameThumb;

            return true;
        }

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="save_path">保存路径</param>
        /// <param name="save_path_thumb">缩略图保存路径</param>
        /// <param name="img_format">图片格式</param>
        /// <param name="file">保存文件夹名</param>
        /// <returns></returns>
        public static bool SaveImg(Image img, ref string save_path, ref string save_path_thumb,string img_format = ".jpg",string file = "")
        {
            img_format = (img_format.Trim() == "") ? ".jpg" : img_format.Trim();
            #region 检查保存路径

            string path = "/uploads/img/";
            if (!string.IsNullOrEmpty(file))
            {
                path = "/uploads/img/" + file + "/";
            }
            string FullPath = HttpContext.Current.Request.MapPath(path);
            if (!System.IO.Directory.Exists(FullPath))
            {
                System.IO.Directory.CreateDirectory(FullPath);
            }

            #endregion

            img_format = img_format.ToLower();
            string FileName = "img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + img_format;
            string FileNameThumb = "img_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_thumb" + img_format;
            int default_thumb_size = 280;
            if (img_format != ".gif")
            {
                #region 保存图片

                #region 缩略图

                //Image img_thumb = ResizeImage(img, default_thumb_size, default_thumb_size);
                Image.GetThumbnailImageAbort myCallback = null;
                Image img_thumb = img.GetThumbnailImage(default_thumb_size, default_thumb_size, myCallback, IntPtr.Zero);

                #endregion

                if (img_format == ".bmp")
                {
                    Bitmap bmp = new Bitmap(img);
                    bmp.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                    Bitmap bmp_thumb = new Bitmap(img_thumb);
                    bmp_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                else
                {
                    switch (img_format)
                    {
                        case ".png": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Png);
                            img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        case ".bmp": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case ".gif": img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Gif);
                            img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        default: img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            img_thumb.Save(FullPath + FileNameThumb, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                    }
                }

                #endregion
            }
            else//GIF图
            {
                #region 保存图片

                #region 保存原图

                img.Save(FullPath + FileName, System.Drawing.Imaging.ImageFormat.Gif);

                #endregion

                #region 保存缩略图

                Gif.GifHelper gh = new Gif.GifHelper();
                gh.Thumbnail(FullPath + FileName, default_thumb_size, FullPath + FileNameThumb);

                #endregion

                #endregion
            }
            
            save_path = path + FileName;
            save_path_thumb = path + FileNameThumb;

            return true;
        }

        /// <summary>
        /// 将图片数据转换为Base64字符串
        /// </summary>
        /// <param name="img">图片</param>
        /// <param name="base64_code">Base64码</param>
        /// <returns></returns>
        public static bool ToBase64(Image img, ref string base64_code)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();
            binFormatter.Serialize(memStream, img);
            byte[] bytes = memStream.GetBuffer();
            base64_code = Convert.ToBase64String(bytes);
            return true;
        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="base64_code"></param>
        /// <param name="img"></param>
        /// <param name="img_format">图片格式</param>
        /// <returns></returns>
        public static bool ToImage(string base64_code, ref Bitmap img, ref string img_format)
        {
            #region 图片格式

            string mark1 = "data:image/";
            string mark2 = ";base64,";
            int pos1 = base64_code.IndexOf(mark1);
            int pos2 = base64_code.IndexOf(mark2);
            img_format = base64_code.Substring(pos1 + mark1.Length, pos2 - pos1 - mark1.Length);

            #endregion

            base64_code = base64_code.Replace("data:image/" + img_format + ";base64,", "");
            byte[] bytes = Convert.FromBase64String(base64_code);

            MemoryStream ms = new MemoryStream(bytes);
            Bitmap bmp = new Bitmap(ms);
            //img = new Bitmap(1024, 768, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
            //Graphics draw = Graphics.FromImage(img);
            //draw.DrawImage(bmp, 0, 0);

            img = new Bitmap(bmp);

            bmp.Dispose();
            //draw.Dispose();
            ms.Close();

            return true;
        }

        /// <summary>
        /// 将Base64字符串转换为图片
        /// </summary>
        /// <param name="base64_code"></param>
        /// <param name="img"></param>
        /// <param name="img_format">图片格式</param>
        /// <returns></returns>
        public static bool ToImage(string base64_code, ref Image img, ref string img_format)
        {
            #region 图片格式

            string mark1 = "data:image/";
            string mark2 = ";base64,";
            int pos1 = base64_code.IndexOf(mark1);
            int pos2 = base64_code.IndexOf(mark2);
            img_format = base64_code.Substring(pos1 + mark1.Length, pos2 - pos1 - mark1.Length);

            #endregion

            base64_code = base64_code.Replace("data:image/" + img_format + ";base64,", "");
            byte[] bytes = Convert.FromBase64String(base64_code);

            MemoryStream ms = new MemoryStream(bytes);

            if (img_format == "gif")
            {
                img = Image.FromStream(ms);
            }
            else
            {
                Image img2 = Image.FromStream(ms);
                img = new Bitmap(img2.Width, img2.Height);
                Graphics draw = Graphics.FromImage(img);
                draw.DrawImage(img2, 0, 0, img2.Width, img2.Height);
                draw.Dispose();
            }
            ms.Close();

            return true;
        }

        /// <summary>    
        /// 合并图片   
        /// </summary>    
        /// <param name="imgBack">粘贴的源图片</param>    
        /// <param name="destImg">粘贴的目标图片</param>    
        public static Image CombinImage(Image imgBack, Image img)
        {     
            if (img.Height != 65 || img.Width != 65)
            {
                img = ResizeImage(img, 65, 65);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);     

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框    

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);    

            g.DrawImage(img, imgBack.Width / 2 - img.Width / 2, imgBack.Width / 2 - img.Width / 2, img.Width, img.Height);
            GC.Collect();
            return imgBack;
        }

        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <returns>处理以后的图片</returns>    
        public static Image ResizeImage(Image bmp, int newW, int newH)
        {
            try
            {
                Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>    
        /// Resize图片    
        /// </summary>    
        /// <param name="bmp">原始Bitmap</param>    
        /// <param name="newW">新的宽度</param>    
        /// <param name="newH">新的高度</param>    
        /// <returns>处理以后的图片</returns>    
        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量    
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch
            {
                return null;
            }
        }  
    }
}