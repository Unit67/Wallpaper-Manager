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
using System.Windows.Forms;

namespace Wallpaper_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        Managers.TrayManager trayManager = new Managers.TrayManager();
        Microsoft.Win32.OpenFileDialog OpenFileDialog = new Microsoft.Win32.OpenFileDialog();
        WallpaperManager wallpaperManager = new WallpaperManager();
        Enums.Enums.Style style;
        public MainWindow()
        {
            trayManager.setup();    
            InitializeComponent();
        }
        private void Set_Wallpaper(object sender, RoutedEventArgs e)
        {
            wallpaperManager.Set_Wallpaper();
        }
        private void Set_Anm_Wallpaper(object sender, RoutedEventArgs e)
        {
            wallpaperManager.Set_Anm_Wallpaper();
        }

        #region ComboBox
        private void ComboBoxItem_Selected_Tiled(object sender, RoutedEventArgs e)
        {
            wallpaperManager.style = Enums.Enums.Style.Tiled;
        }

        private void ComboBoxItem_Selected_Centered(object sender, RoutedEventArgs e)
        {
            wallpaperManager.style = Enums.Enums.Style.Centered;
        }

        private void ComboBoxItem_Selected_Stretched(object sender, RoutedEventArgs e)
        {
            wallpaperManager.style = Enums.Enums.Style.Stretched;
        }

        private void ComboBoxItem_Selected_Fit(object sender, RoutedEventArgs e)
        {
            wallpaperManager.style = Enums.Enums.Style.Fit;
        }

        private void ComboBoxItem_Selected_Fill(object sender, RoutedEventArgs e)
        {
            wallpaperManager.style = Enums.Enums.Style.Fill;
        }
        #endregion
    }
}
