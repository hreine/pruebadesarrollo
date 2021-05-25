namespace Shop.UIForms.ViewModels
{

    using Shop.Common.Models;
    using Shop.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel :BaseViewModel
    {

        /// <summary>
        /// Lista de productos
        /// </summary>
        private ObservableCollection<Product> products;


        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }
        

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {

            var url = Application.Current.Resources["UrlAPI"].ToString();

            var response = await this.apiService.GetListAsync<Product>(
                url,
                "/shop/api",
                "/Products",
                "bearer",
                MainViewModel.GetInstance().Token.AccessToken);


            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            var myproducts = (List<Product>)response.Result;
            this.Products = new ObservableCollection<Product>(myproducts);
            this.IsRefreshing = false;
        }
    }
}
