namespace PhoneBookApi.Models
{
    public interface IContactDataAccess
    {
        public List<Contact> GetContacts();
        public Contact GetContactById(int id);
        public  void AddContact(Contact contact);
        public void UpdateContact(Contact contact);
        public void DeleteContact(int id);
    }
}
