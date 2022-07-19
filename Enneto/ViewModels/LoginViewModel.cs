using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using Enneto.Models;
using Enneto.Views;

namespace Enneto.ViewModels.Loguin
{
    public class LoginViewModel
    {
        private readonly INavigation navigation;
        private readonly ContentPage page;

        public string Usuario { get; set; }

        public string Password { get; set; }

        public Command LoginCommand { get; }

        public LoginViewModel(INavigation navigation, ContentPage page)
        {
            LoginCommand = new Command(OnLoginClicked);
            this.navigation = navigation;
            this.page = page;
        }

        private async void OnLoginClicked(object obj)
        {
            var login = new Login
            {
                Username = Usuario,
                Password = Password
            };

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
            (message, cert, chain, errors) => { return true; };


            Uri RequestUri = new Uri("https://enneto-auth-api.azurewebsites.net/api/Users");
            var client = new HttpClient(httpClientHandler);

            var json = JsonConvert.SerializeObject(login);

            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync(RequestUri, contentJson);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseUser = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());

                    //Iniciando Sesion
                    //no se trae la clave por fines de Seguridad
                    baseDatos.Perfil.Id = responseUser.User.Id;
                    baseDatos.Perfil.Username = responseUser.User.Username;
                    baseDatos.Perfil.FirstName = responseUser.User.FirstName;
                    baseDatos.Perfil.LastName = responseUser.User.LastName;
                    baseDatos.Perfil.Avatar = responseUser.User.Avatar;

                    baseDatos.EstaAutenticado = responseUser.IsAuthenticated;
                    navigation.InsertPageBefore(new FlyoutPageShop(), page);
                    await navigation.PopAsync().ConfigureAwait(false);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("ENNETO", "Usuario y/o clave incorrectos", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("ENNETO", "No se puede autenticar al usuario", "OK");
            }
        }
    }
}
