using System.Reflection;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace MPP3
{
    public class LoadAssembly
    {
        public static AssemblyData GetAssemblyInfo(string DLLpath)
        {
            Assembly assembly = Assembly.LoadFrom(DLLpath);
            AssemblyData assemblyInfo = new AssemblyData(assembly.GetName().Name);
            var namespaces = assembly.GetTypes().Select(type => type.Namespace).Distinct().ToList().Where(ns => ns != null).ToList();
            namespaces.ForEach(ns =>
            {
                NamespaceInfo namespaceData = new NamespaceInfo(ns);
                assemblyInfo.NamespaceList.Add(namespaceData);

                var classes = assembly.GetTypes().Where(type => type.IsClass && type.Namespace == ns).ToList();

                classes.ForEach(clas =>
                {
                    ClassInfo classData = new ClassInfo(clas.Name);
                    namespaceData.ClassList.Add(classData);

                    var fields = clas.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).ToList();
                    var properties = clas.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).ToList();
                    var methods = clas.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance)
                        .Where(method => !method.IsDefined(typeof(ExtensionAttribute))).ToList();

                    fields.ForEach(field => classData.ComponentsList.First(m => m.Name == "Fields").Components.Add(field.ToString()));
                    properties.ForEach(prop => classData.ComponentsList.First(m => m.Name == "Properties").Components.Add(prop.ToString()));
                    methods.ForEach(method => classData.ComponentsList.First(m => m.Name == "Methods").Components.Add(method.ToString()));
                });

                classes.ForEach(clas =>
                {
                    clas.GetMethods().Where(m => m.IsDefined(typeof(ExtensionAttribute), false)).ToList()
                         .ForEach(em =>
                         {
                             assemblyInfo.NamespaceList.ToList().ForEach(ns =>
                                 ns.ClassList.First(clas => clas.Name == em.GetParameters()[0].ParameterType.Name)
                                 ?.ComponentsList.First(m => m.Name == "Methods")
                                 .Components.Add("Extension:" + em.ToString()));
                         });
                });
            });

            return assemblyInfo;
        }
    }
}