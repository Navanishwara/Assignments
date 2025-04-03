namespace PhoneBookWebAPI.Model
{
    public interface IContact
    {
       public  void Add(Contact contact);
        public void Delete(int id);
        public void Update(Contact contact);
        public Contact Get(int id);
       public  List<Contact> GetAll();
    }
}
