using ClassifiedsAzureSaturday.Models;
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
    public partial class ListingDetailPage : ContentPage
    {

        public ListingDetailPage(ClassifiedItem item)
        {
            InitializeComponent();

            ItemNameTb.Text = item.ItemName;
            DescriptionTb.Text = item.ItemDescription;
            PriceTb.Text = item.Price;
            LocationTb.Text = item.LocationName;
        }

    }
}