using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP3
{
    public class AssemblyInfo
    {
        public string Name { get; }
        public ObservableCollection<NamespaceInfo> NamespaceList { get; set; }
        public AssemblyInfo(string name)
        {
            Name = name;
            NamespaceList = new ObservableCollection<NamespaceInfo>();
        }
    }
}
