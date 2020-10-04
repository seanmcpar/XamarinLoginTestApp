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
            if (idEntry.Text != null || passwordEntry.Text != null)
            {
                if (int.TryParse(idEntry.Text.Trim(), out int id))
                {
                    PasswordHasher pwordhasher = new PasswordHasher();
                    var user = (await App.MobileService.GetTable<Users>().Where(u => u.id == id).ToListAsync()).FirstOrDefault();
                    if (user != null)
                    {
                        if (pwordhasher.Verify(passwordEntry.Text.Trim(), user.passwordHash))
                        {
                            await Navigation.PushAsync(new HomePage());
                        }
                        else
                        {
                            await DisplayAlert("Access Denied", "Incorrect Log In Details.", "Ok");
                            passwordEntry.Text = "";
                        }
                    }
                    else
                    {
                        await DisplayAlert("Access Denied", "Incorrect Log In Details.", "Ok");
                        passwordEntry.Text = "";
                    }
                }
                else
                {
                    await DisplayAlert("Access Denied", "Incorrect Log In Details.", "Ok");
                    passwordEntry.Text = "";
                }

            }
            else
            {
                await DisplayAlert("Access Denied", "Please enter valid log in credentials.", "Ok");
            }
        }
    }
}
