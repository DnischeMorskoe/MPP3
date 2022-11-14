using Microsoft.Win32;
using MPP3;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace WPFAssemblyBrowser
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Model model;
        private ICommand openFileCommand;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public ViewModel(Model model)
        {
            this.model = model;
        }
        public string AssemblyFileName
        {
            get => model.AssemblyFileName;
            set
            {
                model.AssemblyFileName = value;
                AssemblyInfo = new ObservableCollection<AssemblyData>
                {
                    MPP3.LoadAssembly.GetAssemblyInfo(model.AssemblyFileName)
                };

                OnPropertyChanged("AssemblyFileName");
            }
        }
        public ObservableCollection<AssemblyData> AssemblyInfo
        {
            get => model.AssemblyInfo;
            set
            {
                model.AssemblyInfo = value;
                OnPropertyChanged("AssemblyInfo");
            }
        }
        
        public ICommand OpenFileCommand
        {
            get
            {
                return openFileCommand ??= new RelayCommand(obj =>
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    if (dialog.ShowDialog() == true)
                    {
                        AssemblyFileName = dialog.FileName;
                    }
                });
            }
            set { }
        }
    }
}
