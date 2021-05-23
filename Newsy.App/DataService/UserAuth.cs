using System;
using System.Collections.Immutable;
using Newsy.Model;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Newsy.App.DataService
{
    public class UserAuth
    {
        readonly HttpClient client = new HttpClient();
        static readonly Uri uri = new Uri("http://localhost:60048/api/Users");

        public async Task<bool> RegisterUser(User user)
        {

            string jsonUserAdd = JsonConvert.SerializeObject(user);

            string jsonUsers = await client.GetStringAsync(uri);

            var pastUsers = JsonConvert.DeserializeObject<User[]>(jsonUsers);

            foreach (var u in pastUsers)
            {
                if (u.Email == user.Email)
                {
                    System.Diagnostics.Debug.WriteLine("User Exsist");
                    return false;
                }
            }
            HttpResponseMessage result = await client.PostAsync(uri, new StringContent(jsonUserAdd, Encoding.UTF8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                   
                    jsonUserAdd = await result.Content.ReadAsStringAsync();
                    var userAdded = JsonConvert.DeserializeObject<User>(jsonUserAdd);
                    await client.DeleteAsync($"http://localhost:60048/api/Users/{userAdded.Id + 1}");
                    return true;
                }
                else
                {
                return false;

                }


        }

        public async Task<User> LoginAuth(User user)
        {

        }
    }
}
