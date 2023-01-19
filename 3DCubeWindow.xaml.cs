using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GrafikaZadanie3
{
    /// <summary>
    /// Logika interakcji dla klasy _3DCubeWindow.xaml
    /// </summary>
    public partial class _3DCubeWindow : Window
    {
        public _3DCubeWindow()
        {
            InitializeComponent();
            Bitmap bitmap1 = new Bitmap(2, 2);
            Bitmap bitmap2 = new Bitmap(2, 2);
            Bitmap bitmap3 = new Bitmap(2, 2);
            Bitmap bitmap4 = new Bitmap(2, 2);
            Bitmap bitmap5 = new Bitmap(2, 2);
            Bitmap bitmap6 = new Bitmap(2, 2);
            bitmap1.SetPixel(0, 0, System.Drawing.Color.White);
            bitmap1.SetPixel(0, 1, System.Drawing.Color.Yellow);
            bitmap1.SetPixel(1, 0, System.Drawing.Color.Magenta);
            bitmap1.SetPixel(1, 1, System.Drawing.Color.Red);
            bitmap2.SetPixel(0, 0, System.Drawing.Color.Green);
            bitmap2.SetPixel(0, 1, System.Drawing.Color.Yellow);
            bitmap2.SetPixel(1, 0, System.Drawing.Color.Cyan);
            bitmap2.SetPixel(1, 1, System.Drawing.Color.White);
            bitmap3.SetPixel(0, 0, System.Drawing.Color.White);
            bitmap3.SetPixel(0, 1, System.Drawing.Color.Magenta);
            bitmap3.SetPixel(1, 0, System.Drawing.Color.Cyan);
            bitmap3.SetPixel(1, 1, System.Drawing.Color.Blue);
            bitmap4.SetPixel(0, 0, System.Drawing.Color.Blue);
            bitmap4.SetPixel(0, 1, System.Drawing.Color.Magenta);
            bitmap4.SetPixel(1, 0, System.Drawing.Color.Black);
            bitmap4.SetPixel(1, 1, System.Drawing.Color.Red);
            bitmap5.SetPixel(0, 0, System.Drawing.Color.Cyan);
            bitmap5.SetPixel(0, 1, System.Drawing.Color.Blue);
            bitmap5.SetPixel(1, 0, System.Drawing.Color.Green);
            bitmap5.SetPixel(1, 1, System.Drawing.Color.Black);
            bitmap6.SetPixel(0, 0, System.Drawing.Color.Yellow);
            bitmap6.SetPixel(0, 1, System.Drawing.Color.Red);
            bitmap6.SetPixel(1, 0, System.Drawing.Color.Green);
            bitmap6.SetPixel(1, 1, System.Drawing.Color.Black);
            bitmapImage1.ImageSource = Convert(bitmap1);
            bitmapImage2.ImageSource = Convert(bitmap2);
            bitmapImage3.ImageSource = Convert(bitmap3);
            bitmapImage4.ImageSource = Convert(bitmap4);
            bitmapImage5.ImageSource = Convert(bitmap5);
            bitmapImage6.ImageSource = Convert(bitmap6);
        }

        public BitmapImage Convert(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            src.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }
    }
}
