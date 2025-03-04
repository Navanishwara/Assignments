using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TicketBookingWEBAPI.Model;

namespace MVCTicketBooking.Models
{
    public class APIConsumer
    {
        static string baseUrl = "http://localhost:5110/api/Ticket/";
        public static List<TicketBooking> GetBookings()

        {
           
                var lstBook = new List<TicketBooking>();
                //call the API GETAll
                using (var http = new HttpClient())
                {
                    http.BaseAddress = new Uri(baseUrl);
     
                    var response = http.GetStringAsync("GetSeatingSections");//if u give above full path keep it as empty "";
                    response.Wait();
                    if (response.IsCompletedSuccessfully)
                    {
                        var data = response.Result;
                        lstBook = JsonSerializer.Deserialize<List<TicketBooking>>(data);
                    }
                    else
                    {
                        throw new Exception(response.Exception.Message);
                    }

                }
                return lstBook;
            }
        public static bool BookTicket(string seatingType, int ticketCount)
        {
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(baseUrl);
                var response = http.PostAsJsonAsync<TicketBooking>($"bookTicket?seatingType={seatingType}&ticketCount={ticketCount}", null);
                response.Wait();
                if (response.IsCompletedSuccessfully)
                {
                    var data =response.Result;

                    if (data.IsSuccessStatusCode)
                    {
                        var responseRead = data.Content.ReadAsStringAsync();
                        responseRead.Wait();
                        var msg = responseRead.Result;
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

    }
}
