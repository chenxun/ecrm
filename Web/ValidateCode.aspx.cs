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
        //��֤�볤��
        private int codeLen = 4;
        //ͼƬ������
        private int fineness = 85;
        //ͼƬ�߶�
        private int imgHeight = 24;
        //ͼƬ���
        private int imgWidth = 50;
        //�����������
        private string fontFamily = "Times New Roman";
        //�����С
        private int fontSize = 14;
        //������ʼ����X
        private int posX = 0;
        //������ʼ���� Y
        private int posY = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string validateCode = CreateValidateCode();
            Bitmap bitmap = new Bitmap(imgWidth, imgHeight);
            DisturbBitmap(bitmap);//ͼ�񱳾�
            DrawValidateCode(bitmap, validateCode);
            bitmap.Save(Response.OutputStream, ImageFormat.Gif);

        }
        ///������֤��
        ///
        private string CreateValidateCode()
        {
            string validateCode = "";
            Random random = new Random();//�������
            for (int i = 0; i < codeLen; i++)
            {
                //int n=random.Next(26);
                //validateCode+=(char)(n+65);

                int n = random.Next(10);//����
                validateCode += n.ToString();
            }
            this.valCode = validateCode;
            return validateCode;
        }

        //ͼ�񱳾�
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

        //������֤��ͼ��,bitmapͼ��,validateCode��ֵ֤
        private void DrawValidateCode(Bitmap bitmap, string validateCode)
        {
            Graphics g = Graphics.FromImage(bitmap);
            Font font = new Font(fontFamily, fontSize, FontStyle.Bold);//���û�������
            g.DrawString(validateCode, font, Brushes.Black, posX, posY);//������֤��ͼ��
        }

    }
}
