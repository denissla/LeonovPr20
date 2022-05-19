﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LeonovPr20
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Random rnd = new Random();
            int value = rnd.Next(1, 10);
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://reqres.in/api/users/{value}");
                response.EnsureSuccessStatusCode();
                var answer = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(answer);
                var str = o.SelectToken(@"$.data");
                GetUser answer_user = JsonConvert.DeserializeObject<GetUser>(str.ToString());
                Label1.Text = "ID: " + answer_user.ID + "\r\n" + "Email: " + answer_user.Email + "\r\n" + "Имя: " + answer_user.First_Name + "\r\n" + "Фамилия: " + answer_user.Last_Name + "\r\n" + "Аватар: " + answer_user.Avatar;
            }

            catch
            { }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PutRequestPage());
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new PostUserPage());
        }
    }
}
