using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerson.BusinessFacade;

namespace Powerson.Web
{
    public partial class ValidateCode : PageBase
    {
        //验证码长度
        private int codeLen = 4;
        //图片清晰度
        private int fineness = 85;
        //图片高度
        private int imgHeight = 24;
        //图片宽度
        private int imgWidth = 50;
        //字体家族名称
        private string fontFamily = "Times New Roman";
        //字体大小
        private int fontSize = 14;
        //绘制起始坐标X
        private int posX = 0;
        //绘制起始坐标 Y
        private int posY = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string validateCode = CreateValidateCode();
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
            DisturbBitmap(bitmap);//图像背景
            DrawValidateCode(bitmap, validateCode);
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);

        }
        ///生成验证码
        ///
        private string CreateValidateCode()
        {
            string validateCode = "";
            Random random = new Random();//随机对象
            for (int i = 0; i < codeLen; i++)
            {
                //int n=random.Next(26);
                //validateCode+=(char)(n+65);

                int n = random.Next(10);//数字
                validateCode += n.ToString();
            }
            this.valCode = validateCode;
            return validateCode;
        }

        //图像背景
        private void DisturbBitmap(Bitmap bitmap)
        {
            Random random = new Random();
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    if (random.Next(90) <= this.fineness)
                        bitmap.SetPixel(i, j, Color.White);
                }
            }
        }

        //绘制验证码图像,bitmap图版,validateCode验证值
        private void DrawValidateCode(Bitmap bitmap, string validateCode)
        {
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new Font(fontFamily, fontSize, FontStyle.Bold);//设置绘制字体
            g.DrawString(validateCode, font, Brushes.Black, posX, posY);//绘制验证码图像
        }

    }
}
