
namespace PhoneBookWebAPI.Model
{
    public class ContactDataAccessLayer : IContact

    {
        private readonly ContactDBContext dbCtx;
        public ContactDataAccessLayer(ContactDBContext dbCtx)
        {
            this.dbCtx = dbCtx;
        }
        public void Add(Contact contact)
        {
            //throw new NotImplementedException();
            try
            {
                dbCtx.contact.Add(contact);
                dbCtx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            try
            {
                var record = dbCtx.contact.Find(id);
                if (record != null)
                {
                    dbCtx.contact.Remove(record);
                    dbCtx.SaveChanges();
                }
                else
                {
                    throw new Exception("record no found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Contact Get(int id)
        {
            //throw new NotImplementedException();
            try
            {
                var record = dbCtx.contact.Find(id);
                if (record != null)
                {
                    return record;
                }
                else
                {
                    throw new Exception("record not found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Contact> GetAll()
        {
            //throw new NotImplementedException();
            try
            {
                return dbCtx.contact.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Contact contact)
        {
            //throw new NotImplementedException();
            try
            {
                var record = dbCtx.contact.Find(contact.Id);
                if (record != null)
                {
                    record.FirstName = contact.FirstName;
                    record.LastName = contact.LastName;
                    record.DateofBirth = contact.DateofBirth;
                    record.Email = contact.Email;
                    record.Phone = contact.Phone;
                    record.City = contact.City;
                    record.state = contact.state;
                    record.country = contact.country;
                    dbCtx.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
