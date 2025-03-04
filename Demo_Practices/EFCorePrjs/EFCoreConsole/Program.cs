using BusinessLayerHRMLIB;
using EFCoreDBFirstLIb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCoreConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //configure dependencies injection service for dal and 
            var depServices = new ServiceCollection();
            depServices.AddDbContext<EMPDBContext>(options => {
                options.UseNpgsql("Host=localhost;Database=empdb;Username=postgres;Password=root");
            });
            depServices.AddScoped<IEmployeDataAccess, EmployeeDataAccess>();
           
            //get the DAL instance from service provider
           var provider = depServices.BuildServiceProvider();
            var dal = provider.GetService<IEmployeDataAccess>();

            BusinessLayer bll = new BusinessLayer(dal);
           
            int choice = 0;
            do
            {
                Employee emp = null; 
                displayMenu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        //add employe
                        try
                        {
                            emp = new Employee();
                            Console.WriteLine("Enter empid ");
                            emp.empid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter emp name");
                            emp.name = Console.ReadLine();
                            Console.WriteLine("Enter the salary");
                            emp.salary = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the dpt Id");
                            emp.depid = int.Parse(Console.ReadLine());
                            dal.Add(emp);
                            Console.WriteLine("record added successfully");
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        //delete emp by id]
                        try
                        {
                            Console.WriteLine("Enter empid for delete");
                            int ec = int.Parse(Console.ReadLine());
                            bll.Delete(ec);
                            Console.WriteLine("delete record successfully");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        case 3:
                        try
                        {
                            //update 
                            emp = new Employee();
                            Console.WriteLine("Enter empid ");
                            emp.empid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter emp name");
                            emp.name = Console.ReadLine();
                            Console.WriteLine("Enter the salary");
                            emp.salary = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the dpt Id");
                            emp.depid = int.Parse(Console.ReadLine());
                            bll.UpdateEmployee(emp);
                            Console.WriteLine("Record updated success");
                        }catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        case 4:
                        //display employee
                        try
                        {
                            var lstEmps = bll.GetAllEmps();
                            foreach (var emps in lstEmps)
                            {
                                Console.WriteLine($"{emps.empid}\t{emps.name}\t{emps.salary}\t{emps.depid}");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                        case 5:
                        //find by id 
                        try
                        {
                            Console.WriteLine("Enter the empid");
                            int eid = int.Parse(Console.ReadLine());
                            var re = bll.GetEmployee(eid);
                            Console.WriteLine($"{re.empid}\t{re.name}\t{re.salary}\t{re.depid}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                        case 0:
                        //exit
                        break;
                        default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 0);  


        }

        static void displayMenu()
        {
            Console.WriteLine("1.Add Employee");
            Console.WriteLine("2.Delete Employee by id");
            Console.WriteLine("3.Update Employee");
            Console.WriteLine("4. Display all  Employee");
            Console.WriteLine("5.Find Employee");
            Console.WriteLine("0. Exit");
            Console.WriteLine("Enter the choice");

        }
    }
}
