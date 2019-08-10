using BusManagment.Core.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelManagment.Service
{
    public interface IConsumerService
    {
        void Add(string exchange, string qeueuName, string address, int typeId);
        List<CounsumerModel> GetAllConsumerDB();
        void RegisterChannel(string exchange, string qeueuName, string address, int typeId);
    }
}
