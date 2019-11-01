using ClassifiedsAzureSaturday.Models;
using ClassifiedsAzureSaturday.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClassifiedsAzureSaturday.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListingsPage : ContentPage
    {
        List<ClassifiedItem> Listings { get; set; }
        WeatherService weatherService;
        public ListingsPage()
        {
            InitializeComponent();
            Listings = new List<ClassifiedItem>()
            {
                new ClassifiedItem{ Id=new Guid().ToString(), ItemName= "Item 1", ItemDescription= "This is Item 1", TypeOfItem= "Electronics", Price= "100", ImageURL= "https://images-na.ssl-images-amazon.com/images/I/31tmp7757XL.jpg", ContactNo= "+97123456", Distance= 5,LocationName="Deira"},
                new ClassifiedItem{ Id=new Guid().ToString(), ItemName= "Item 2", ItemDescription= "This is Item 2", TypeOfItem= "Apparel", Price= "50", ImageURL= "https://images-na.ssl-images-amazon.com/images/I/314dBKQw2qL._AC_SY400_.jpg", ContactNo= "+97123457", Distance= 10,LocationName="Jebel Ali"},
                new ClassifiedItem{ Id=new Guid().ToString(), ItemName= "Item 3", ItemDescription= "This is Item 3", TypeOfItem= "Footwear", Price= "200", ImageURL= "https://ae01.alicdn.com/kf/HTB1DkSrXF67gK0jSZPfq6yhhFXaK/Nike-Air-Max-Plus-Original-Men-s-Running-Shoes-Outdoor-Breathable-Comfort-Sneakers-Designer-Shockproof-Jogging.jpg_q50.jpg", ContactNo= "+97123458", Distance= 15,LocationName="Bur Dubai"},
                new ClassifiedItem{ Id=new Guid().ToString(), ItemName= "Item 4", ItemDescription= "This is Item 4", TypeOfItem= "Furniture", Price= "500", ImageURL= "https://ii1.pepperfry.com/media/catalog/product/d/o/494x544/doloris-stylish-tufted-chair-in-beige-colour-by-dreamzz-furniture-doloris-stylish-tufted-chair-in-be-0ahswj.jpg", ContactNo= "+97123459", Distance= 65,LocationName="Dubai Silicon Oasis"},
                new ClassifiedItem{ Id=new Guid().ToString(), ItemName= "Item 5", ItemDescription= "This is Item 5", TypeOfItem= "Electronics", Price= "800", ImageURL= "https://images-eu.ssl-images-amazon.com/images/G/39/electronics/store/6column/1122839_CE_Store_Mobiles_PC_Nav_Computers_Accessories_Laptops_440x440.jpg", ContactNo= "+97123450", Distance= 95,LocationName="Al Awir"},
            };
            ListingsListView.ItemsSource = Listings;

            var weatherList=weatherService.GetWeatherForecasts().Result;
            WeatherForecastListView.ItemsSource = weatherList;
        }

        async private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ClassifiedItem;
            await Navigation.PushAsync(new ListingDetailPage(item));

        }


    }
}