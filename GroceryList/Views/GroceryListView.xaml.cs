using GroceryList.ViewModels;
using System.Windows.Controls;

namespace GroceryList.Views
{
    /// <summary>
    /// Interaction logic for GroceryListView.xaml
    /// </summary>
    public partial class GroceryListView : UserControl
    {
        public GroceryListView(GroceryListVM viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
