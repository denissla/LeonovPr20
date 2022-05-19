using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LeonovPr20
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PutRequestPage : ContentPage
    {
        public PutRequestPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var user = new PutUser();
            user.Name = "Leonov Denis";
            user.Job = "Student_KGPK";
            string json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            HttpClient client = new HttpClient();
            Random random = new Random();
            int value = random.Next(1, 10);
            try
            {
                HttpResponseMessage response = await client.PutAsync($"https://reqres.in/api/users/{value}", content);
                response.EnsureSuccessStatusCode();
                var answer = await response.Content.ReadAsStringAsync();
                PutUser answer_user = JsonConvert.DeserializeObject<PutUser>(answer);
                Label1.Text = "Имя: " + user.Name + "\r\n" + "Работа: " + user.Job + "\r\n" + "Время обновления: " + Convert.ToString(answer_user.UpdateAt);

            }
            catch
            {

            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PostUserPage());
        }
    }
}