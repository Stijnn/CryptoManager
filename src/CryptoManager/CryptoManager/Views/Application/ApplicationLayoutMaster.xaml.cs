using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CryptoManager.Views.Application
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationLayoutMaster : ContentPage
    {
        public ListView ListView;

        public ApplicationLayoutMaster()
        {
            InitializeComponent();

            BindingContext = new ApplicationLayoutMasterViewModel();
            ListView = MenuItemsListView;
        }

        class ApplicationLayoutMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<ApplicationLayoutMenuItem> MenuItems { get; set; }
            
            public ApplicationLayoutMasterViewModel()
            {
                MenuItems = new ObservableCollection<ApplicationLayoutMenuItem>(new[]
                {
                    new ApplicationLayoutMenuItem(typeof(Favorites.FavoriteView)) { Id = 0, Title = "Favorites" },
                    new ApplicationLayoutMenuItem(typeof(Search.SearchView)) { Id = 1, Title = "Search" },
                    new ApplicationLayoutMenuItem(typeof(Coins.CoinsView)) { Id = 2, Title = "Coins" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}