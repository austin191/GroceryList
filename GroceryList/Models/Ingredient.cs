using GroceryList.Enums;
using GroceryList.ViewModels.Base;

namespace GroceryList.Models
{
    public class Ingredient : ViewModel
    {
        private string _name;
        private IngredientTypes _type;

        public IngredientTypes Type
        {
            get { return _type; }
            set { SetField(ref _type, value); }
        }
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }
    }
}
