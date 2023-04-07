using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        public int intField;
        private readonly object __lockObj = new object();

        static void Main(string[] args)
        {
            var returnNull = ReturnNull();
            _ = returnNull.Value;
        }

        private static NullObj ReturnNull()
        {            
            return null;
        }

        public void ResourceLeakExample()
        {
            StreamReader reader = new StreamReader("");
        }
        
        public void ResourceLeakExample2()
        {
            StreamReader reader = new StreamReader("");
        }

        public void WriteToField(int input)
        {
            lock (__lockObj)
            {
                intField = input;
            }
        }

        public int ReadFromField()
        {
            return intField;
        }
    }

    internal class NullObj
    {
        internal string Value { get; set; }
    }
}
