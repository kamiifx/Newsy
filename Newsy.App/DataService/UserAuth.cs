using System;
using System.Collections.Immutable;
using System.ComponentModel;
using Newsy.Model;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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

        public string ErrorMsg = "";


        public async Task<bool> RegisterUser(User user)
        {
            if (user.Password.Length < 6)
            {
                ErrorMsg = "Password to Short!";
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
                        ErrorMsg = "User Already Exsist";
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
            catch (Exception e)
            {
                ErrorMsg = e.Message;
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
                    return true;
                }
            }
            return false;
        }
    }
}
