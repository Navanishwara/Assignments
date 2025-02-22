using System.Data;
using System.Security.Principal;
using AccountLibrary;
using AccountLibrary;

namespace AccountClient
{
    internal class Program
    {
        static void Main(string[] args)
        {



            int choice;
            do
            {
                Console.WriteLine("-------Customer Details------");
                Console.WriteLine("1.Add Custoomer");
                Console.WriteLine("2.Get Customer By ID");
                Console.WriteLine("3.Update Customer");
                Console.WriteLine("-------Account Details------");
                Console.WriteLine("4. Add Account");
                Console.WriteLine("5.Get Account by id");
                Console.WriteLine("6.Uddate Account");
                Console.WriteLine("----Transactions---");
                Console.WriteLine("7. Deposit");
                Console.WriteLine("8. withdraw");
                Console.WriteLine("9. Transfer Funds");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter choice");
                choice = int.Parse(Console.ReadLine());
                CusomerDAO dal = null;
                AccountDAO acl = null;
                switch (choice)
                {
                    case 1:
                        
                        try
                        {
                            var cu = new Customers();
                            Console.WriteLine("Enter the customer Id");
                            cu.CustomerId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Customer  Name");
                            cu.Name = Console.ReadLine();
                            Console.WriteLine("Enter the MobileNumber");
                            cu.Mobile = Console.ReadLine();
                            Console.WriteLine("Enter the Email Id");
                            cu.Email = Console.ReadLine();

                           
                            dal = new CusomerDAO();
                            dal.AddCustomer(cu);
                            
                            Console.WriteLine("Customer records inserted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter the Customer   Id");
                            int id = int.Parse(Console.ReadLine());
                           
                            dal = new CusomerDAO();
                            Customers c1 = dal.GetCustomerById(id);
                            Console.WriteLine($"Customer datails are\nName:{c1.Name}\tMobile{c1.Mobile}\tEmail Id{c1.Email}");
                            
                        }
                        catch (Exception ex)
                        {
                            throw new CustomerNotFoundException("customer id not found");
                            
                        }
                        break;
                    case 3:
                        try
                        {
                            
                            var cm = new Customers();
                            Console.WriteLine("Enter the customer Id");
                            cm.CustomerId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Customer  Name");
                            cm.Name = Console.ReadLine();
                            Console.WriteLine("Enter the MobileNumber");
                            cm.Mobile = Console.ReadLine();
                            Console.WriteLine("Enter the Email Id");
                            cm.Email = Console.ReadLine();

                           
                            dal = new CusomerDAO();
                            dal.UpdateCustomer(cm);
                           
                            Console.WriteLine("Record updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 4:
                        try
                        {
                            var Au = new Account();
                            Console.WriteLine("Enter the Account Id");
                            Au.AccountId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the  AccountNumber");
                            Au.AccountNumber = int.Parse( Console.ReadLine());
                            Console.WriteLine("Enter the Account balance");
                            Au.Balance = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Account Type");
                            Au.AccountType = Console.ReadLine();

                            acl = new AccountDAO();
                            acl.AddAccount(Au);

                            Console.WriteLine("Account records inserted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;


                    case 5:
                        try
                        {
                            Console.WriteLine("Enter the Account  Id");
                            int id = int.Parse(Console.ReadLine());
                             acl = new AccountDAO();
                            Account a1 = acl.GetAccountById(id);
                            Console.WriteLine($"Account  datails are\nAccountID:{a1.AccountId}\tAccountNumber{a1.AccountNumber}\tBalance: {a1.Balance}\t Account Type:{a1.AccountType}");

                        }
                        catch (Exception ex)
                        {
                           
                            throw new AccountNotFoundException("Account id not found");

                        }
                        break;
                    case 6:
                        try
                        {
                            var Au = new Account();
                            Console.WriteLine("Enter the Account Id");
                            Au.AccountId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the  AccountNumber");
                            Au.AccountNumber = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Account balance");
                            Au.Balance = decimal.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Account Type");
                            Au.AccountType = Console.ReadLine();

                            
                            acl = new AccountDAO();
                            acl.UpdateAccount(Au);

                            Console.WriteLine("Account Deatils Updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 7:
                        try
                        {
                            
                            Console.WriteLine("Enter the Account Id");
                           int id= int.Parse(Console.ReadLine());
                            
                            Console.WriteLine("Enter the Account balance");
                            decimal Balance = decimal.Parse(Console.ReadLine());
                            TransactionManager t = new TransactionManager();

                            t.Deposit(Balance,id);

                           

                            Console.WriteLine("Account Deatils Updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 8:
                        try
                        {

                            Console.WriteLine("Enter the Account Id");
                            int id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the Account balance");
                            decimal Balance = decimal.Parse(Console.ReadLine());
                            TransactionManager t = new TransactionManager();

                            t.Withdraw(Balance, id);



                            Console.WriteLine("Account Deatils Updated");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 9:
                        try
                        {

                            Console.WriteLine("Enter the Account Id1");
                            int id1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the Account Id2");
                            int id2 = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Account to transfer");
                            decimal amount = decimal.Parse(Console.ReadLine());
                            TransactionManager t = new TransactionManager();

                            t.TransferFunds(id1, id2,amount);
                            Console.WriteLine("Transfer successfull");


                           
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;

                }
            } while (choice != 0);
         

        }
    }
}
