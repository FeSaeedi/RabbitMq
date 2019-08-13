using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelManagment.Core
{
    public interface IChannel
    {
        void RegisterConsumer(string exchange, string queueName, string address, int protocolType);
        void RemoveSubscriber(string queueName, string address);
        void RegisterConsumer( string queueName, Func<string, Task<int>> notifyFunc);
    }
}
