using System.Linq.Expressions;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

namespace Day4_MobileNumberValidationExceptiion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Enter the Mobile Number:");
                long mobile = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter the alternate mobile number:");
                long alternateMobile = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter landline number");
                long landline = long.Parse(Console.ReadLine());
                Console.WriteLine("Enter the email id");
                string email = Console.ReadLine();
                Console.WriteLine("enter the contact address");
                string add = Console.ReadLine();
                ContactDetail contactDetail = new ContactDetail(mobile, alternateMobile, landline, email, add);
                ContactDetailsBO contactDetailsBO = new ContactDetailsBO();
                contactDetailsBO.Validate(contactDetail);


            }
            catch (DuplicateNumberException ex)
            {
                Console.WriteLine(ex.Message);
            }
    catch(Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    }
    public class ContactDetailsBO
    {
        public   void Validate(ContactDetail cd)
        {
            if (cd._mobile == cd._alternateMobile)
            {
                throw new DuplicateNumberException("same mobile number and alternate mobile number");
            }
            else
            {
                Console.WriteLine(cd.ToString());
            }
        }
    }
    public class ContactDetail
    {
        public long _mobile { get; set; }
        public long _alternateMobile { get; set; }
        public long _landLine { get; set; }
        public string _email { get; set; }
        public string _address { get; set; }

       
      public ContactDetail(long mobile, long alternateMobile, long landline, string email, string address)
        {
            _mobile = mobile;
            _alternateMobile = alternateMobile;
            _landLine = landline;
            _email = email;
            _address = address;

        }
        public override string ToString()
        {
            return $"ContactDetails:\n Mobile : {_mobile}\n Alternate Mobile:{_alternateMobile}\n LandLine: {_landLine}\n Email: {_email}\n Address:{_address}";
        }


    }
    class DuplicateNumberException : Exception
    {
        public DuplicateNumberException(string msg) : base(msg)
        {
        }
    }
}
