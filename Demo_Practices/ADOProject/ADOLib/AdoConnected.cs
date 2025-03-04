
using Npgsql; //for postgreSql
using System.Configuration;
namespace ADOLib
{
    public class AdoConnected : IEmployeeDataAccess
    {
        NpgsqlConnection con;
        public AdoConnected()
        {
            con = new NpgsqlConnection();
            //read the configuration
            string conStr = ConfigurationManager.ConnectionStrings["pgconstr"].ConnectionString;
            con.ConnectionString = "";
        }
        public void AddEmployee(Employee employee)
        {
            //throw new NotImplementedException();
            //command for insert statement
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("insert into employee values(@ec,@en,@sal,@did)", con);
                cmd.CommandType = System.Data.CommandType.Text;
                //specify  the parameter value
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", employee.Ecode);
                cmd.Parameters.AddWithValue("@en", employee.Name);
                cmd.Parameters.AddWithValue("@sal", employee.salary);
                cmd.Parameters.AddWithValue("@did", employee.Deptid);
               
                //open the connection 
                con.Open();
                //execute the command
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
             //close the connection
                    con.Close();
            }
        }

        public void DeleteEmployee(int ecode)
        {
            //throw new NotImplementedException();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("Delete from employee where empid = @ec", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@ec", ecode);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }

        public List<Employee> GetAllEmployees()
        {
            //throw new NotImplementedException();
            var lstEmps = new List<Employee>();
            try
            {
                //configure the command for select all statements
                NpgsqlCommand cmd = new NpgsqlCommand("select * from employee",con);
                cmd.CommandType = System.Data.CommandType.Text;
                //open the connection
                con.Open();
                //execute the command
                NpgsqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    //get the record one by one and add int
                    var emp = new Employee
                    {

                        Ecode = sdr.IsDBNull(0)? 0: sdr.GetInt32(0),
                        Name = sdr.GetString(1),
                        salary = sdr.GetInt32(2),
                        Deptid = sdr.GetInt32(3),

                    };
                    //add 
                    lstEmps.Add(emp);

                }
            }
            catch (Exception ex)
              {
                throw ex;
            }
            finally
            { 
                //close the connection
                con.Close();
            
            }
            //return the result
            return lstEmps; 

        }

        public Employee  GetEmployee(int id)
        {
            Employee emp = new Employee();
            //throw new NotImplementedException();
            try
            {
                
                NpgsqlCommand cmd = new NpgsqlCommand("select * from employee where empid= @ec ", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ec", id);
                con.Open();

                NpgsqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();

                //get the record one by one and add int


               emp.Ecode = sdr.GetInt32(0);
                   emp.Name = sdr.GetString(1);
                emp.salary = sdr.GetInt32(2);
                emp.Deptid = sdr.GetInt32(3);

                    
                

                }catch(Exception ex) { throw ex; }
            finally { con.Close(); }
            return emp;

        }

        public void UpdateEmployee(Employee employee)
        {
            //throw new NotImplementedException();
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand("update employee set salary = salary +2000 where empid = @ec ", con);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@ec",employee.Ecode);
                con.Open();
                var count =cmd.ExecuteNonQuery();
                if (count==0)
                {
                    throw new Exception("ecode does not exits");
                }

            }catch(Exception ex) { throw ex; }
            finally { con.Close(); }
        }

        public void UpdateSalUsingSP(int ecode, int salary)
        {
            //throw new NotImplementedException();
            NpgsqlCommand cmd = new NpgsqlCommand("call_sp_update", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ec", ecode);
            cmd.Parameters.AddWithValue("@sal", salary);
            con.Open();
            cmd.ExecuteNonQuery();
            //use if function  which returns a value;

            con.Close();
        }
    }
}
