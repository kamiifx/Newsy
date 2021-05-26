using System;
using System.Collections.Immutable;
using System.ComponentModel;
using Newsy.Model;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Identity.Client;
using Newsy.App.Views;
using Newtonsoft.Json;

namespace Newsy.App.DataService
{
    public class UserAuth : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        

        readonly HttpClient client = new HttpClient();
        static readonly Uri uri = new Uri("http://localhost:60048/api/Users");

        public User LoggedUser;
        public string EmailUser = "";

        public async Task<bool> RegisterUser(User user)
        {
            if (user.Password.Length < 6)
            {
                System.Diagnostics.Debug.WriteLine("Password To Short");
                return false;
            }
            try
            {
                string jsonUserAdd = JsonConvert.SerializeObject(user);

                string jsonUsers = await client.GetStringAsync(uri);

                var pastUsers = JsonConvert.DeserializeObject<User[]>(jsonUsers);

                foreach (var u in pastUsers)
                {
                    if (u.Email == user.Email)
                    {
                        System.Diagnostics.Debug.WriteLine("User Already Exsist");
                        return false;
                    }
                }
                HttpResponseMessage result = await client.PostAsync(uri, new StringContent(jsonUserAdd, Encoding.UTF8, "application/json"));
                if (result.IsSuccessStatusCode)
                {
                    jsonUserAdd = await result.Content.ReadAsStringAsync();
                    var userAdded = JsonConvert.DeserializeObject<User>(jsonUserAdd);
                    await client.DeleteAsync($"http://localhost:60048/api/Users/{userAdded.Id + 1}"); //Weird Issue Fix, bugs with http.
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<bool> LoginAuth(string email , string password)
        {

            string jsonUsers = await client.GetStringAsync(uri);

            var pastUsers = JsonConvert.DeserializeObject<User[]>(jsonUsers);

            foreach (var u in pastUsers)
            {
                if (u.Email == email && u.Password == password)
                {
                    System.Diagnostics.Debug.WriteLine($"{u.Id} : {u.Email} : {u.Password}");
                    LoggedUser = u;
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> OutlookLogin()
        {
            string[] scopes = new string[]
            {
                "https://graph.microsoft.com/user.read"
            };
            string clientId = "e87b2067-612c-48b3-8664-e469a7ae594c"; //Mutlitentant Personal and Orginizational.
            string redirectUri = "https://login.microsoftonline.com/common/oauth2/nativeclient";


            var authApp = PublicClientApplicationBuilder.Create(clientId)
                .WithRedirectUri(redirectUri)
                .Build();
            var result = await authApp.AcquireTokenInteractive(scopes)
                .ExecuteAsync();
            System.Diagnostics.Debug.WriteLine("result: " + result.Account);

            string email = result.Account.Username.ToString();
            string password = result.TenantId.ToString();

            string jsonUsers = await client.GetStringAsync(uri);
            var pastUsers = JsonConvert.DeserializeObject<User[]>(jsonUsers);

            foreach (var u in pastUsers)
            {
                if (u.Email == email)
                {
                    System.Diagnostics.Debug.WriteLine($"HERE! {u.Id} : {u.Email} : {u.Password}");
                    EmailUser = u.Email.ToString();
                    LoggedUser = u;
                    return true;
                }
            }

            User outlookUser = new User()
            {
                Email = result.Account.Username,
                Password = result.TenantId
            };

            string jsonUserAdd = JsonConvert.SerializeObject(outlookUser);
            HttpResponseMessage resultOutlook = await client.PostAsync(uri, new StringContent(jsonUserAdd, Encoding.UTF8, "application/json"));

            if (resultOutlook.IsSuccessStatusCode)
            {
                jsonUserAdd = await resultOutlook.Content.ReadAsStringAsync();
                var userAdded = JsonConvert.DeserializeObject<User>(jsonUserAdd);
                await client.DeleteAsync($"http://localhost:60048/api/Users/{userAdded.Id + 1}");
                LoggedUser = outlookUser;
                return true;
            }

            return false;
        }
    }
}
