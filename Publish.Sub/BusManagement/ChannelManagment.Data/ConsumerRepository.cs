using BusManagment.Core.Consumer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelManagment.Data
{
    public class ConsumerRepository : IConsumerRepository
    {
        public void Add(string exchange, string qeueuName, string address, int typeId)
        {
            //throw new NotImplementedException();
        }

        public List<CounsumerModel> GetAll()
        {
            List<CounsumerModel> models = new List<CounsumerModel>();
            models.Add(new CounsumerModel());
            models.Add(new CounsumerModel());
            models.Add(new CounsumerModel());
            return models;
        }
    }
}
