using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP3
{
    public class ClassComponentsInfo
    {
        public string Name { get; }
        public ObservableCollection<string> Components { get; set; }
        public ClassComponentsInfo(string name)
        {
            Name = name;
            Components = new ObservableCollection<string>();
        }
    }
}
