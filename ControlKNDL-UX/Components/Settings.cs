using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace ControlKNDL_UX.Components 
{
    public class Settings : INotifyPropertyChanged
    {
        bool _settingsChanged = false;
        public bool SettingsChanged { get { return _settingsChanged; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }

            this._settingsChanged = true;
        }

        public string getKindleGenVersion()
        {
            return Properties.Settings.Default.KindleGenVersion;
        }

        public void setKindleGenVersion(string kindleGenVersion)
        {
            if (Properties.Settings.Default.KindleGenVersion != kindleGenVersion)
            {
                Properties.Settings.Default.KindleGenVersion = kindleGenVersion;
                Properties.Settings.Default.Save();
                OnPropertyChanged("KindleGenVersion");
            }
        }
    }
}
