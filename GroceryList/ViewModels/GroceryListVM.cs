using GroceryList.Data;
using GroceryList.ViewModels.Base;

namespace GroceryList.ViewModels
{
    public class GroceryListVM : ViewModel
    {
        GroceryListRepo _groceryListRepo;
        public GroceryListVM(GroceryListRepo groceryListRepo)
        {
            _groceryListRepo = groceryListRepo;
        }
    }
}
