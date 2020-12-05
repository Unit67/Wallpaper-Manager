using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Wallpaper_Manager
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        WallpaperManager wallpaperManager = new WallpaperManager();

        private void MenuItem_Set_Wallpaper(object sender, RoutedEventArgs e)
        {
            wallpaperManager.Set_Wallpaper();
        }

        private void MenuItem_Anm_Wallpaper(object sender, RoutedEventArgs e)
        {
            wallpaperManager.Set_Anm_Wallpaper();
        }

        private void MenuItem_Close(object sender, RoutedEventArgs e)
        {
            DialogResult result;
            result = (DialogResult)System.Windows.MessageBox.Show("The Application will be closed","App close", MessageBoxButton.YesNo);
            if(result == DialogResult.Yes)
                System.Windows.Application.Current.Shutdown();
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            if(MainWindow!=null)
                MainWindow.Close();
            
        }
    }
}
