using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationLayout : MasterDetailPage
    {
        public ApplicationLayout()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ApplicationLayoutMenuItem;
            if (item == null)
                return;

            Page newPage = (Page)Activator.CreateInstance(item.PageType);
            newPage.Title = item.Title;

            Detail = new NavigationPage(newPage);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}