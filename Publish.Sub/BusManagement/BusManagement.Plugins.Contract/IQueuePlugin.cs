using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagement.Plugins.Contract
{
    public interface IConsumerPlugin
    {
        string QueueName { get; }
        Task<int> Notify(string x);
    }
}
