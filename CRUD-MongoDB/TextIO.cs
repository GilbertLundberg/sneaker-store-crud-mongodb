using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MongoDB
{
    internal class TextIO : IStringIO
    {
        public void Clear()
        {
            System.Console.Clear();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public string GetString()
        {
            return Console.ReadLine(); 
        }

        public void PrintString(string output)
        {
            Console.WriteLine(output);
        }
    }
}
