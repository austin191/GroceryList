using GroceryList.Enums;
using GroceryList.ViewModels.Base;

namespace GroceryList.Models
{
    public class RecipeIngredientModel : ViewModel
    {
        private Ingredient _ingredient;
        private double _quantity;
        private QuantityTypes _quantityType;

        public Ingredient Ingredient
        {
            get { return _ingredient; }
            set { SetField(ref _ingredient, value); }
        }

        public double Quantity
        {
            get { return _quantity; }
            set { SetField(ref _quantity, value); }
        }

        public QuantityTypes QuantityType
        {
            get { return _quantityType; }
            set { SetField(ref _quantityType, value); }
        }
    }
}
