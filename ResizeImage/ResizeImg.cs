using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ResizeImg
{
    public static Image Resize(Image imgToResize, int h, int w)
    {
        Size size = new Size(w, h);
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;

        float WHrate = ((float)imgToResize.Width / (float)imgToResize.Height); //Yüklenen fotonunun boyutlarının (genişliğin yüksekliğe) oranı...

        float newHeight = 0;
        float newWidth = 0;

        if (h != 0)
        {
            newHeight = h;
            newWidth = h * (int)WHrate;
        }
        else if(w != 0)
        {
            newHeight = (float)w / (float)WHrate;
            newWidth = w;
        }        

        Bitmap b = new Bitmap((int)newWidth, (int)newHeight);
        Graphics g = Graphics.FromImage((Image)b);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        g.DrawImage(imgToResize, 0, 0, newWidth, newHeight);
        g.Dispose();
        return (Image)b;
    }
}