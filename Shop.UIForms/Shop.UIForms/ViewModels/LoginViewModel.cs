namespace Shop.UIForms.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Shop.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        public LoginViewModel()
        {
            this.Email = "yusiel.re@gmail.com";
            this.Password = "123456";
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an email.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an password.",
                    "Accept");
                return;
            }

            if (!this.Email.Equals("yusiel.re@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "User or password wrong.",
                    "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //    "Ok",
            //    "Funck yeahh!!",
            //    "Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());

        }
    }
}
