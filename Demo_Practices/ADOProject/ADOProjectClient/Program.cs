using ADOLib;
namespace ADOProjectClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {

                Console.WriteLine("1.Add employee");
                Console.WriteLine("2.Delete employee");
                Console.WriteLine("3.Update employee");
                Console.WriteLine("4.Display employee");
                Console.WriteLine("5.Find Employee by id");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter choice");
                choice = int.Parse(Console.ReadLine());
                AdoDisconnected dal = null;
                //AdoConnected dal = null;
                switch (choice)
                {
                    case 1:
                        //Add employee
                        try
                        {
                            var em = new Employee();
                            Console.WriteLine("Enter the code");
                            em.Ecode = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the Name");
                            em.Name = Console.ReadLine();
                            Console.WriteLine("Enter the salary");
                            em.salary = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the depid");
                            em.Deptid = int.Parse(Console.ReadLine());

                            //insert using dal\
                            //dal = new AdoConnected();
                            dal = new AdoDisconnected();
                            dal.AddEmployee(em);
                            Console.WriteLine("record inserted");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine("Enter the Emp Code to employee to delete");
                            int ecode = int.Parse(Console.ReadLine());
                            //dal = new AdoConnected();
                            dal = new AdoDisconnected();
                            dal.DeleteEmployee(ecode);
                            Console.WriteLine("deleted successfully");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                 case 3:
                        var emp = new Employee();
                        //update employee
                        Console.WriteLine("Enter the employee code to update");
                        int ecod = int.Parse(Console.ReadLine());
                        //dal = new AdoConnected();
                        dal = new AdoDisconnected();
                        dal.UpdateEmployee(emp);
                        Console.WriteLine("Updated successfully");
                        break;
                    
                    case 4:
                        //display employee
                        //dal = new AdoConnected();
                        dal = new AdoDisconnected();
                        var lstEmps = dal.GetAllEmployees();
                        if(lstEmps.Count == 0)
                        {
                            Console.WriteLine("No records available");
                        }else
                        {
                            foreach(var e in lstEmps)
                            {
                                Console.WriteLine($"{e.Ecode}\t{e.Name}\t{e.salary}\t{e.Deptid}");
                            }                        
                        }
                        break;
                    case 5:
                        //get employee name by id;
                        try
                        {
                            //Employee emp1 = new Employee();
                            Console.WriteLine("Enter the employee  empid");
                            int id = int.Parse(Console.ReadLine());
                            //dal = new AdoConnected();
                            dal = new AdoDisconnected();
                           Employee e1 =  dal.GetEmployee(id);
                            Console.WriteLine("The name of Employee is "+e1.Name);
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
            } while(choice != 0);    
        }
    }
}
