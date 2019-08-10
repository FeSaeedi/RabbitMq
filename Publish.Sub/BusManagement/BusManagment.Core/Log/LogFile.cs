using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagment.Core
{
    public class LogFile : ILog
    {
        public async Task<bool> Write(string message)
        {
            Debug.WriteLine("Recive Step2");
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\Fereshteh\source\repos\BusManagement\fredle2.txt", true))
            {

                await file.WriteLineAsync(message);

            }

            return true;
        }
        public async Task<bool> Write2(string message)
        {
            // StreamWriter streamWriter = new StreamWriter(@"C:\Users\Fereshteh\source\repos\BusManagement\fredle.txt", false);// (@"C:\Users\Fereshteh\source\repos\BusManagement\test.txt");
            Debug.WriteLine("Recive Step2");
            //streamWriter.Write(message);
            using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(@"C:\Users\Fereshteh\source\repos\BusManagement\fredle2.txt"))
            {

                await file.WriteLineAsync("zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz vvvvvvvvvvvvvvvvvv ddddddddddddddddddd");

            }

            return true;
        }
    }
}
