using GroceryList.Data;
using GroceryList.ViewModels.Base;

namespace GroceryList.ViewModels
{
    public class RecipeVM : ViewModel
    {
        private GroceryListRepo _groceryListRepo;
        public RecipeVM(GroceryListRepo groceryListRepo)
        {
            _groceryListRepo = groceryListRepo;
        }
    }
}
