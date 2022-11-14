using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP3
{
    public class NamespaceInfo
    {
        public string Name { get; }
        public ObservableCollection<ClassInfo> ClassList { get; set; }
        public NamespaceInfo(string name)
        {
            Name = name;
            ClassList = new ObservableCollection<ClassInfo>();
        }
    }
}
