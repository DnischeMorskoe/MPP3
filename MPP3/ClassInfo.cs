using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP3
{
    public class ClassInfo
    {
        public string Name { get; }
        public ObservableCollection<ClassComponentsInfo> ComponentsList { get; set; }
        public ClassInfo(string name)
        {
            Name = name;
            ComponentsList = new ObservableCollection<ClassComponentsInfo>
            {
                new ClassComponentsInfo("Fields"), new ClassComponentsInfo("Properties"), new ClassComponentsInfo("Methods")
            };
        }
    }
}
