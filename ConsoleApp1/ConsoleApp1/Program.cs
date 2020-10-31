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

	    public StreamWriter AllocateStreamWriter() 
        {
            FileStream fs = File.Create("everwhat.txt");
            return new StreamWriter(fs);
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
