using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using MPP3;

namespace WPFAssemblyBrowser
{
    public class Model  : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string assemblyFileName;
        private ObservableCollection<AssemblyData> assemblyInfo;
        public string AssemblyFileName
        {
            get => assemblyFileName;
            set
            {
                assemblyFileName = value;
                OnPropertyChanged("AssemblyFileName");
            }
        }

        public ObservableCollection<AssemblyData> AssemblyInfo
        {
            get => assemblyInfo;
            set
            {
                assemblyInfo = value;
                OnPropertyChanged("AssemblyInfo");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
