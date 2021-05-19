using System;
using Newsy.Model;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.App.DataService
{
    public class UserAuth
    {
        private static HttpClient http = new HttpClient();
        static readonly Uri uri = new Uri("http://localhost:5000/api/Users");

        public async Task<bool> RegisterUser(string email, string password)
        {
            User newuser = new User()
            {
                Email = email,
                Password = password
            };

            var response = await http.PostAsJsonAsync(uri, newuser);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
    }
}
