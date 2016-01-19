using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using ControlKNDL_UX.Components;

namespace ControlKNDL_UX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Settings _settingComponent;
        Settings SettingsComponent
        {
            get
            {
                return _settingComponent;
            }
            set
            {
                _settingComponent = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            SettingsComponent = new Settings();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (SettingsComponent.SettingsChanged)
                Properties.Settings.Default.Save();
        }

        private void btSearchFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opDlg = new OpenFileDialog();
            opDlg.DefaultExt = ".epub";
            opDlg.Filter = "Epub Files (*.epub)|*.epub|All Files (*.*)|*.*";

            Nullable<bool> result = opDlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = opDlg.FileName;
                tbFileToConvert.Text = filename;
            }

        }

        private void btConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                KndlGConverter kndlG = new KndlGConverter();
                kndlG.ConvertFile(tbFileToConvert.Text);

                tbOutput.Text = kndlG.Log;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }


        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new Views.Settings(ref _settingComponent).ShowDialog();
        }
    }
}
