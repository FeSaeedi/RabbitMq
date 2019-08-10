using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagment.Core
{
    public class LogConsole : ILog
    {
        public Task<bool> Write(string message)
        {
            Debug.WriteLine(message);
            return Task.FromResult(true);
        }
    }
}
