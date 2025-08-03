using DeliveryApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliveryApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {

        public Search(string par1, string par2, string par3)
        {
            InitializeComponent();
            BindingContext = new SearchViewModel(par1, par2, par3);
        }
    }
}