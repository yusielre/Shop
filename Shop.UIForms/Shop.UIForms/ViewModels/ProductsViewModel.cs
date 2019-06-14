namespace Shop.UIForms.ViewModels
{
    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }


        public ProductsViewModel()
        {
            
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            ServicePointManager.ServerCertificateValidationCallback =
            delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            var response = await this.apiService.GetListAsync<Product>(
                "https://192.168.1.4",
                "/api",
                "/Products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                response.Message,
                "Accept");
                return;
            }

            var myProducts = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(myProducts);
        }
    }
}
