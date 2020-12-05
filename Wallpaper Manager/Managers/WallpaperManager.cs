using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Wallpaper_Manager.MainWindow;
using static Wallpaper_Manager.Enums.Enums;
using System.Windows.Forms;
using System.IO;

namespace Wallpaper_Manager
{
    class WallpaperManager
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;
        
        Microsoft.Win32.OpenFileDialog OpenFileDialog = new Microsoft.Win32.OpenFileDialog();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]

        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public Enums.Enums.Style style;

        public void Set_Wallpaper()
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
                    System.Windows.MessageBox.Show(Ex.ToString());
                }
            }
        }

        public void Set_Anm_Wallpaper()
        {
            var status = OpenFileDialog.ShowDialog();
            if (status.Equals(true))
            {
                try
                {
                    OpenFileDialog.ValidateNames = false;
                    OpenFileDialog.CheckFileExists = false;
                    OpenFileDialog.CheckPathExists = true;

                    string folderPath = System.IO.Path.GetDirectoryName(OpenFileDialog.FileName);
                    string[] files = Directory.GetFiles(folderPath);

                    SetAnm(files, style);

                }
                catch (Exception Ex)
                {
                    System.Windows.MessageBox.Show(Ex.ToString());
                }
            }
        }
        public static void Set(string imgPath,  Style style)
        {
            var img = System.Drawing.Image.FromFile(System.IO.Path.GetFullPath(imgPath));
            string tempPath = imgPath;
            img.Save("C:/Test.jpeg", ImageFormat.Jpeg);

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

        public static void SetAnm(string[] imgPath, Enums.Enums.Style style)
        {
            for(int i = 0; i == imgPath.Length; i++)
            {
                var img = System.Drawing.Image.FromFile(System.IO.Path.GetFullPath(imgPath[i]));
                string tempPath = imgPath[i]; //System.IO.Path.Combine(System.IO.Path.GetTempPath(), "wallpaper.bmp");
                img.Save("C:/Test.jpeg", ImageFormat.Jpeg);

                var key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

                switch (style)
                {
                    case Enums.Enums.Style.Tiled:
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

                SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, imgPath[i], SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
            }
        }
    }
}
