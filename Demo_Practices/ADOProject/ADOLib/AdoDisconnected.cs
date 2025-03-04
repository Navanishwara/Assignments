using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace ADOLib
{
    public class AdoDisconnected : IEmployeeDataAccess
    {
    NpgsqlConnection con;
        NpgsqlDataAdapter da;
        DataSet ds;
    public AdoDisconnected()
        {
            con = new NpgsqlConnection();
            con.ConnectionString = "Host=localhost;Database=empdb;Username=postgres;Password=root";
            da = new NpgsqlDataAdapter("select * from employee",con);
            //create and fill the dataset using adapter
            ds = new DataSet();
            da.Fill(ds, "employee");
            //add constraint
            ds.Tables[0].Constraints.Add("pk1", ds.Tables[0].Columns[0],true);

        }

        public void AddEmployee(Employee employee)
        {
            //create a new row in DataSet Table rows collection
            DataRow row = ds.Tables[0].NewRow();
            //specify column values to this new row
            row[0] = employee.Ecode;
            row[1] = employee.Name;
            row[2]= employee.salary;
            row[3] = employee.Deptid;

            //add this new row to the DataSet Table Rows
            ds.Tables[0].Rows.Add(row);
            //using DataAdapter save this insert in database
            NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
            //save changes to database
            da.Update(ds, "employee");
        }

        public void DeleteEmployee(int ecode)
        {
           DataRow row = ds.Tables[0].Rows.Find(ecode);
            if (row != null)
            {
                //delete the row and update
                row.Delete();
                //using DataAdapter save this insert in database
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
                //save the changes to database
                da.Update(ds, "employee");
            }
            else
            {
                throw new Exception("ecode not found");
            }
        }

        public List<Employee> GetAllEmployees()
        {
           List<Employee> lstEmps = new List<Employee>();
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                var empt = new Employee
                {
                    Ecode = (int)row[0],
                    Name = row[1].ToString(),
                    salary = (int)row[2],
                    Deptid = (int)row[3]

                  };
                //add to the collection
                lstEmps.Add(empt);
            }
            return lstEmps;
        }

        public Employee GetEmployee(int id)
        {
            DataRow row = ds.Tables[0].Rows.Find(id);
            if (row == null)
            {
                throw new Exception("ecode does not exist");
            }
            else
            {
                var emps = new Employee
                {
                    Ecode = (int)row[0],
                    Name = row[1].ToString(),
                    salary = (int)row[2],
                    Deptid = (int)row[3]
                };
                return emps;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            DataRow row = ds.Tables[0].Rows.Find(employee.Ecode);
            if (row != null)
            {
                //udate the row columns and update
                row[2] = employee.salary;
                //using DataAdapter save this insert in database
                NpgsqlCommandBuilder builder = new NpgsqlCommandBuilder(da);
                //save changes to database
                da.Update(ds, "employee");


            }
            else
            {
                throw new Exception("ecode not found");
            }
        }

        public void UpdateSalUsingSP(Employee employee)
        {
            DataRow row = ds.Tables[0].Rows.Find(employee.Ecode);
            if (row != null)
            {
                //update the row columns and update
                row[2]= employee.salary;
                //using dataadapter save this insert in database
                NpgsqlCommandBuilder builder= new NpgsqlCommandBuilder(da);
                //save changes to database
                da.Update(ds,"employee");
            }
            else
            {
                throw new Exception("ecode not found");
            }
        }
        public void UpdateSalUsingSP(int ecode, int salary)
        {
            throw new NotImplementedException();
        }
    }
  
}
