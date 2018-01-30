using System.Collections.Generic;

namespace ContactManager.WEB.Models
{
    public class LocationsModel
    {
        public long Total { get; set; }
        public List<AddressTableModel> Items { get; set; }

        public LocationsModel(long total, List<AddressTableModel> items)
        {
            Total = total;
            Items = items;
        }
    }
}
