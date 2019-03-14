using GroceryList.Data;
using GroceryList.ViewModels.Base;

namespace GroceryList.ViewModels
{
    public class IngredientsVM : ViewModel
    {
        GroceryListRepo _groceryListRepo;
        public IngredientsVM(GroceryListRepo groceryListRepo)
        {
            _groceryListRepo = groceryListRepo;
        }
    }
}
