using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itro1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager stmanager = new StudentManager(@"C:\test.csv");
            stmanager.menu();
          
        }

    }
}
