using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagment.Core
{
    public interface ILog
    {
        Task<bool> Write(string message);
    }
}
