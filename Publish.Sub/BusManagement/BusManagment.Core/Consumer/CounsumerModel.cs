namespace BusManagment.Core.Consumer
{
    public class CounsumerModel
    {
        //private string address;
        //private int protocolType;

        //public CounsumerModel(string address, int protocolType)
        //{
        //    this.address = address;
        //    this.protocolType = protocolType;
        //}
        public string Exchange { get; set; }
        public string QeueuName { get; set; }
        public string Address { get; set; }
        public int TypeId { get; set; }
    }
}