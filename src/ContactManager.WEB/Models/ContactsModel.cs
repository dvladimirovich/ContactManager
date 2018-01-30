using System.Collections.Generic;

namespace ContactManager.WEB.Models
{
    public class ContactsModel
    {
        public long Total { get; set; }
        public List<PersonTableModel> Items { get; set; }

        public ContactsModel(long total, List<PersonTableModel> items)
        {
            Total = total;
            Items = items;
        }
    }
}
