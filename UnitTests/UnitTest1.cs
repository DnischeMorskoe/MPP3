using MPP3;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private const string DLLpath = @"D:\Учеба\3_курс\СПП\MPP3\ClassLibrary\bin\Debug\ClassLibrary.dll";

        [TestMethod]
        public void TestMethod1()
        {
            AssemblyData UnitTest1= MPP3.LoadAssembly.GetAssemblyInfo(DLLpath);

            Assert.AreEqual(UnitTest1.NamespaceList.Count, 1);
            Assert.AreEqual(UnitTest1.NamespaceList[0].Name, "ClassLibrary");
            Assert.AreEqual(UnitTest1.NamespaceList[0].ClassList.Count, 2);
            Assert.AreEqual(UnitTest1.NamespaceList[0].ClassList[1].ComponentsList.Count, 3);
        }
    }
}