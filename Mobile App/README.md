# **Writing your mobile app**

 

Let’s write a mobile app which displays some classifieds and show you the listing detail with contact number. To keep the document clean, we have the code snippets in a separate file “Azure Saturday Mobile App Code Snippets” which you will have to use 

1.    Open Visual Studio and Create a New Project

![image-20191101171757240](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\1)

2.    Select Mobile App(Xamarin.Forms) template from the list

![image-20191101171850144](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\2.jpg)

3.    Give a Name to your project and select a location to save the project and Click on Create

4.    Select “Blank” template. Choose the platforms you would like to develop your app for. Click OK

![image-20191101171944779](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\3.jpg)

5.    The generated solution contains 3 projects

	a.    .NET Standard or the Shared Code

	b.    Xamarin.Android

	c.    Xamarin.iOS

![](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\4.jpg)

6.    We will be working only on the shared code which will be compiled into native code at the time of compilation. The folder structure will be as follows:

	a.    Views: Contains all the UI files where you will design the UI with XAML. Every .xaml file has a code behind file with an extension .xaml.cs which defines the functionality.

	b.    Models: Provides the business entities and logic

	c.    Services: Provides classes that interact with external libraries.

7.    Right click on the ClassifiedsApp shared code project -> Add -> New Folder and name the folder as Models

8.    Repeat the steps for creating 2 more folders and call them Views and Services.

9.    Let’s add our classifieds item model. Right click on Models folder -> Add -> Class

 ![img](file:///C:/Users/ahmad/AppData/Local/Temp/msohtmlclip1/01/clip_image008.png)

![image-20191101172018239](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\5.jpg)

10.  Give the name as “ClassifiedItem” and click Add

 ![img](file:///C:/Users/ahmad/AppData/Local/Temp/msohtmlclip1/01/clip_image010.jpg)

![image-20191101172041413](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\6.jpg)

11.  Add the new fields

```C#
	public class ClassifiedItem
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Price { get; set; }
        public string ContactNo { get; set; }
        public string ImageURL { get; set; }
        public int Distance { get; set; }
        public string TypeOfItem { get; set; }
        public string LocationName { get; set; }
    }
```



12.  Now lets add some pages. Right click on the Views Folder -> Add -> New Item

![image-20191101172157072](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\7.jpg)

13.  Select Content Page from Xamarin.Forms Category, Name the page “ListingsPage.xaml” and Click Add

![image-20191101172220592](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\8.jpg)

14.  Repeat the process to add another page called “ListingDetailPage.xaml”

15.  Lets start putting some listings. Open the ListingsPage and replace the Label with the following ListVIew:

 ```XAML
 <ListView x:Name="ListingsListView"/>
 ```

16.  Press F7 or Open the code-behind for the ListingsPage and add the following code:

```c#
List<ClassifiedItem> Listings { get; set; }
	public ListingDetailPage()
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
}
```
17. Now try running the app. It should show you the Class name instead of the Listing Item Name because by default the ToString method of the listview works on the class name.

18. To fix this issue, go back to your ClassifiedItem Model Class and add the following code:

```C#
public override string ToString()
{
	 return ItemName;
}
```


19. Let’s add an awesome nuget package for handling images. Go to Tools -> NuGet Package Manager -> Manage Nuget Packages for solution…

![image-20191101172243284](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\9.jpg)

20. Click on Browse and search for “ffimageloading”. Install the nuget package in all the projects.

![image-20191101172303055](E:\Meetups\Full Solution - Azure Saturday\create-your-own-mobileapp\Mobile App\img\10.jpg)

21. Paste the following code in the ListingPage.xaml file under xmlns:

 ```XAML
 xmlns:forms="clr-namespace:FFImageLoading.Forms;assembly=FFImageLoading.Forms"
 ```

22. Let’s modify the way our data looks by defining a data template. Open ListingsPage.xaml and replace the ListView with the following code:

```XAML
 <ListView x:Name="ListingsListView"  ItemSelected="OnItemSelected" HasUnevenRows="True">
        <ListView.ItemTemplate>
          <DataTemplate>
            <ViewCell>
              <Grid Padding="10">
                <Grid.RowDefinitions> 
                  <RowDefinition Height="Auto" />
                  <RowDefinition Height="*" />
                </Grid.RowDefinitions>
                 <Grid.ColumnDefinitions>
                  <ColumnDefinition Width="Auto" />
                  <ColumnDefinition Width="*" />
                  <ColumnDefinition Width="Auto"/>
                </Grid.ColumnDefinitions>
                <forms:CachedImage Grid.RowSpan="2"
              Source="{Binding ImageURL}"
              Aspect="AspectFill"
              HeightRequest="60"
              WidthRequest="60" />
                <Label Grid.Column="1"
              Text="{Binding ItemName}"
              FontAttributes="Bold" />
                <Label Grid.Row="1"
              Grid.Column="2"
              Text="{Binding LocationName}"
              VerticalOptions="End" />
              </Grid>
            </ViewCell>
          </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
```
23. Open the ListingPage code-behind file and paste the following code under the constructor. This enables the behavior of navigation to the ListingDetailPage when an item is tapped:

```C#
async private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
{      
      var item = e.SelectedItem as ClassifiedItem;
      await Navigation.PushAsync(new ListingDetailPage(item));
}
```

24. To enable the navigation to the details page we need to make the ListingPage into a navigation page. Open App.xaml.cs and change the MainPage assignment to the following:

```C#
 MainPage = new NavigationPage(new ListingsPage());
```

25. Run the app and you should be able to navigate to a page with just a label saying “Welcome to Xamarin.Forms”. And you can click the arrow on the top bar to go back to your ListingPage.


26. “Welcome to Xamarin.Forms" doesn’t really tell much about the listing so let’s change that. Paste the following code replacing the existing StackLayout. The following code is just a couple of labels in a StackLayout which will display the Listing Information:

```XAML
 <StackLayout Spacing="20" Padding="15">
        <Label Text="Item Name:" FontSize="Medium" />
        <Label x:Name="ItemNameTb" FontSize="Small"/>
        <Label Text="Description:" FontSize="Medium" />
        <Label x:Name="DescriptionTb" FontSize="Small"/>
        <Label Text="Price:" FontSize="Medium" />
        <Label x:Name="PriceTb" FontSize="Small"/>
        <Label Text="Location:" FontSize="Medium" />
        <Label x:Name="LocationTb" FontSize="Small"/>
    </StackLayout>
```

27. In ListingDetailPage Code-behind file, replace the constructor with the following code:

 ```C#
public ListingDetailPage(ClassifiedItem item)
{
	  InitializeComponent(); 
      ItemNameTb.Text = item.ItemName;
      DescriptionTb.Text = item.ItemDescription;
      PriceTb.Text = item.Price;
      LocationTb.Text = item.LocationName;
} 
 ```

28. Run the app 

29. Congratulations, you just made a classifieds app which navigates to a detail page!

30. Continue your journey of Mobile app development with Xamarin and you shall definitely be an amazing developer. Here are a few resources to give you a head start:

	a. Microsoft Learn Portal
        https://docs.microsoft.com/en-us/learn/browse/?products=xamarin	
	b. Official DotNet Portal
        https://dotnet.microsoft.com/learn/xamarin
	c. Xamarin Official Docs
	    https://docs.microsoft.com/en-us/xamarin/