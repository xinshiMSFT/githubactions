namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] arg)
        {
            var returnNull = ReturnNull();
            _ = returnNull.Value;
        }

        private static NullObj ReturnNull()
        {            
            return null;
        }
    }

    internal class NullObj
    {
        internal string Value { get; set; }
    }
}
