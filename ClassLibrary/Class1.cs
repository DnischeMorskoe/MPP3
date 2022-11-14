namespace ClassLibrary
{
    public class Class1
    {
        public int field1;
        private int field2;
        public int property1 { get; set; }
        public int property2 { get; private set; }

        // methods
        public string Method1()
        {
            return "OK";
        }

        public int Method2(int x, int y)
        {
            return x + y;
        }

        private void Method3()
        {

        }
    }
}