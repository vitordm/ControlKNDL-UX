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
using System.Windows.Shapes;

namespace ControlKNDL_UX.Views
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        Components.Settings SettingsComponent { get; set; }

        public Settings(ref Components.Settings setting)
        {
            InitializeComponent();

            if (setting != null)
                SettingsComponent = setting;
            else 
                SettingsComponent = new Components.Settings();
            loadSettings();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            SettingsComponent.setKindleGenVersion(textBox.Text);
            loadSettings();
        }

        private void loadSettings()
        {
            textBox.Text = SettingsComponent.getKindleGenVersion();

        }
        
    }
}
