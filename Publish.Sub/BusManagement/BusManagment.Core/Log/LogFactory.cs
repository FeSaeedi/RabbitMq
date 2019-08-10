using ChannelManagment.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusManagment.Core
{
    public class LogFactory
    {
        public static ILog GetLog(int typeId)
        {
            switch (typeId)
            {
                case (int)ProtocolTypeEnum.Http:
                    return new LogFile();

                case (int)ProtocolTypeEnum.Tcp:
                    return new LogConsole();
                default:
                    return null;
                    break;
            }
        }
    }
}
