using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing.Imaging;

namespace Wallpaper_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        Style style;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Set_Wallpaper(object sender, RoutedEventArgs e)
        {
            var status = OpenFileDialog.ShowDialog();
            if (status.Equals(true))
            {
                try
                {
                    Set(OpenFileDialog.FileName, style);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }
        
        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched,
            Fit,
            Fill
        }


        public static void Set(string imgPath, Style style)
        {
            var img = System.Drawing.Image.FromFile(System.IO.Path.GetFullPath(imgPath));
            string tempPath = imgPath; //System.IO.Path.Combine(System.IO.Path.GetTempPath(), "wallpaper.bmp");
            img.Save("C:/Test.jpg", ImageFormat.Jpeg);

            var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            switch (style)
            {
                case Style.Tiled:
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                    break;
                case Style.Centered:
                    key.SetValue(@"WallpaperStyle", 1.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Stretched:
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case Style.Fit:
                    key.SetValue(@"WallpaperStyle", "6");
                    key.SetValue(@"TileWallpaper", "0");
                    break;
                case Style.Fill:
                    key.SetValue(@"WallpaperStyle", "10");
                    key.SetValue(@"TileWallpaper", "0");
                    break;

            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imgPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        #region ComboBox
        private void ComboBoxItem_Selected_Tiled(object sender, RoutedEventArgs e)
        {
            style = Style.Tiled;
        }

        private void ComboBoxItem_Selected_Centered(object sender, RoutedEventArgs e)
        {
            style = Style.Centered;
        }

        private void ComboBoxItem_Selected_Stretched(object sender, RoutedEventArgs e)
        {
            style = Style.Stretched;
        }

        private void ComboBoxItem_Selected_Fit(object sender, RoutedEventArgs e)
        {
            style = Style.Fit;
        }

        private void ComboBoxItem_Selected_Fill(object sender, RoutedEventArgs e)
        {
            style = Style.Fill;
        }
        #endregion
    }
}
