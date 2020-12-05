using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Application;

namespace Wallpaper_Manager.Managers
{
    class TrayManager
    {
        private NotifyIcon notifier = new NotifyIcon();     
        public void setup()
        {
            this.notifier.MouseDown += Notifier_MouseDown;
            this.notifier.Icon = Properties.Resources.Icon1;
            this.notifier.Visible = true;
        }
        private void Notifier_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                System.Windows.Controls.ContextMenu menu = (System.Windows.Controls.ContextMenu)Application.Current.FindResource("NotifierContextMenu");
                menu.IsOpen = true;
            }
        }

        private void Menu_Open(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Open");
        }

        private void Menu_Close(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Close");
            System.Windows.Application.Current.Shutdown();
        }
    }
}
