using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MongoDB
{
    internal interface IStringIO
    {
        public string GetString();

        public void PrintString(string input);

        public void Clear();

        public void Exit();
    }
}
