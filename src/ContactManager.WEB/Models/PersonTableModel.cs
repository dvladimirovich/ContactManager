namespace ContactManager.WEB.Models
{
    public class PersonTableModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Birth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int AddressId { get; set; }
    }
}
