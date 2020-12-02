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
using static Wallpaper_Manager.Enums.Enums;
using MahApps.Metro.Controls;

namespace Wallpaper_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        OpenFileDialog OpenFileDialog = new OpenFileDialog();
        Enums.Enums.Style style;
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
                    WallpaperManager.Set(OpenFileDialog.FileName, style);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }
        private void Set_Anm_Wallpaper(object sender, RoutedEventArgs e)
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
                    string[] files =Directory.GetFiles(folderPath);

                    WallpaperManager.SetAnm(files, style);

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        #region ComboBox
        private void ComboBoxItem_Selected_Tiled(object sender, RoutedEventArgs e)
        {
            style = Enums.Enums.Style.Tiled;
        }

        private void ComboBoxItem_Selected_Centered(object sender, RoutedEventArgs e)
        {
            style = Enums.Enums.Style.Centered;
        }

        private void ComboBoxItem_Selected_Stretched(object sender, RoutedEventArgs e)
        {
            style = Enums.Enums.Style.Stretched;
        }

        private void ComboBoxItem_Selected_Fit(object sender, RoutedEventArgs e)
        {
            style = Enums.Enums.Style.Fit;
        }

        private void ComboBoxItem_Selected_Fill(object sender, RoutedEventArgs e)
        {
            style = Enums.Enums.Style.Fill;
        }
        #endregion
    }
}
