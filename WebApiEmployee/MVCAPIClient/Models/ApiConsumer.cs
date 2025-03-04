using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using NuGet.Protocol.Plugins;

namespace MVCAPIClient.Models
{
    public class ApiConsumer
    {
        static string baseUrl = "http://localhost:5290/api/Employee/";
        string token = null;
        public static List<Employee> GetEmps( string token)

        {
            //var login = new LoginModel
            //{
            //    userName = "admin",
            //    password = "admin123"
            //};

            //read the token from session to access secured API
           // GetToken(login);
            if (token != null)
            {
                var lstEmps = new List<Employee>();
                //call the API GETAll
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
                    http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = http.GetStringAsync("GetAllEmps");//if u give above full path keep it as empty "";
                    response.Wait();
                    if (response.IsCompletedSuccessfully)
                    {
                        var data = response.Result;
                        lstEmps = JsonSerializer.Deserialize<List<Employee>>(data);
                    }
                    else
                    {
                        throw new Exception(response.Exception.Message);
                    }

                }
                return lstEmps;
            }
            else
            {
                throw new Exception("Invalid");
            }
        }

        public static string AddEmp(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.PostAsJsonAsync<Employee>("AddEmp", emp);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var responseRead = response.Content.ReadAsStringAsync();
                        responseRead.Wait();
                        var msg = responseRead.Result;
                        return msg;
                    }
                    else
                    {
                        return " could not insert record";
                    }
                }
                else
                {
                    return "Request failed";
                }
            }
        }
        public static Employee GetEmpId(int id)
        {
            var emp = new Employee();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.GetStringAsync($"GetEmpById/{id}");
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    emp = JsonSerializer.Deserialize<Employee>(response);
                    return emp;
                }
                else
                {
                    throw new Exception(task.Exception.Message);
                }
            }
        }
        public static bool Update(Employee emp)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.PutAsJsonAsync<Employee>($"UpdateEmp/{emp.empid}", emp);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }


        }
        public static bool Delete(int id)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var task = http.DeleteAsync($"DeleteByID/{id}");
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }
        public  static string GetToken(LoginModel login)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri("http://localhost:5290/api/Account/Login");
                var task = http.PostAsJsonAsync<LoginModel>("", login);
                task.Wait();
                if (task.IsCompletedSuccessfully)
                {
                    var response = task.Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var token = response.Content.ReadAsStringAsync().Result;
                        return token;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
               

            }
        }
    }
}
