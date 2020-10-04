using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace logintestapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void LogInBtn_Clicked(object sender, EventArgs e)
        {
            int id = int.Parse(idEntry.Text.Trim());
            PasswordHasher pwordhasher = new PasswordHasher();
            var user = (await App.MobileService.GetTable<Users>().Where(u => u.id==id).ToListAsync()).FirstOrDefault();
            if (user != null)
            {
                if (pwordhasher.Verify(passwordEntry.Text, user.passwordHash))
                {
                    await Navigation.PushAsync(new HomePage());
                }
            }
        }
    }
}
