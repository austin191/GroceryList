using System.Collections.Generic;
using GroceryList.ViewModels.Base;

namespace GroceryList.Models
{
    public class Recipe : ViewModel
    {
        private string _name;
        private List<RecipeIngredientModel> _ingredients;

        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        public List<RecipeIngredientModel> Ingredients
        {
            get { return _ingredients; }
            set { SetField(ref _ingredients, value); }
        }
    }
}
