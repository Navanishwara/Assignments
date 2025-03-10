
namespace PhoneBookApi.Models
{
    public class ContactDataAccess : IContactDataAccess
    {
        private readonly ContactDbContext _context; 
        public ContactDataAccess(ContactDbContext context)
        {
            _context = context;
        }
        public void AddContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteContact(int id)
        {
            try
            {
                var record =_context.Contacts.Find(id);
                if (record != null)
                {
                    _context.Contacts.Remove(record);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Record not found,could not delete");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact GetContactById(int id)
        {
            try
            {
                var record=_context.Contacts.Find(id);
                if(record != null)
                {
                    return record;
                }
                else
                {
                    throw new Exception("Record not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contact> GetContacts()
        {
            try
            {
                return _context.Contacts.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                var record = _context.Contacts.Find(contact.id);
                if(record != null)
                {
                    record.firstname = contact.firstname;
                    record.lastname = contact.lastname;
                    record.gender = contact.gender;
                    record.dob = contact.dob;
                    record.phone = contact.phone;
                    record.email = contact.email;
                    record.city = contact.city;
                    record.state = contact.state;
                    record.country = contact.country;
                    record.picture  = contact.picture;

                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
