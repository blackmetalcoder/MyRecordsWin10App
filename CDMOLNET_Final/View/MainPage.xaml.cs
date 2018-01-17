using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CDMOLNET_Final.ServiceCD;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CDMOLNET_Final.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            //Konto
            Object valueKonto = localSettings.Values["Konto"];
            if (valueKonto == null)
            {
                // No data
            }
            else
            {
                txtUser.Text = valueKonto.ToString();
            }
            //Password
            Object valuePwd = localSettings.Values["Password"];
            if (valuePwd == null)
            {
                // No data
            }
            else
            {
                txtPassword.Password = valuePwd.ToString();
            }
            //User
            Object valueUser = localSettings.Values["User"];
            if (valueUser == null)
            {
                // No data
            }
            else
            {
                txtInfo.Text = valueUser.ToString() + " är inloggad";
            }
        }

        private async void btnLoogain_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            ServiceCD.CDServiceSoapClient klient = new CDServiceSoapClient();
            var svar = await klient.loggaInAsync(txtUser.Text, txtPassword.Password);
            string s = svar.Body.loggaInResult;
            string[] anv = s.Split(';');
            localSettings.Values["Konto"] = txtUser.Text;
            localSettings.Values["Password"] = txtPassword.Password;
            localSettings.Values["User"] = anv[0];
            localSettings.Values["id"] = anv[1];
        }
    }
}
