using GroceryList.Data;
using GroceryList.Enums;
using GroceryList.Models;
using GroceryList.ViewModels.Base;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GroceryList.ViewModels
{
    public class IngredientsVM : ViewModel
    {
        private readonly GroceryListRepo _groceryListRepo;
        private ObservableCollection<Ingredient> _ingredients;
        private Ingredient _selectedIngredient;
        private string _newIngredientText;
        private bool _isNewMeasured;
        private bool _isNewSingular = true;

        public IngredientsVM(GroceryListRepo groceryListRepo)
        {
            _groceryListRepo = groceryListRepo;
            Refresh();
        }

        public void Refresh()
        {
            Ingredients = new ObservableCollection<Ingredient>( _groceryListRepo.GetIngredientsList() );
        }
        private void Remove()
        {
            if (SelectedIngredient != null)
            {
                _groceryListRepo.DeleteIngredient(SelectedIngredient.Name);
                Refresh();
            }
        }
        private void Add()
        {
            if (!string.IsNullOrEmpty(NewIngredientText))
            {
                IngredientTypes ingredientType = IsNewSingular ? IngredientTypes.Singular : IngredientTypes.Measured;
                _groceryListRepo.AddIngredient(new Ingredient()
                {
                    Name = NewIngredientText,
                    Type = ingredientType
                });
            }
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get { return _ingredients; }
            set { SetField(ref _ingredients, value); }
        }

        public Ingredient SelectedIngredient
        {
            get { return _selectedIngredient; }
            set { SetField(ref _selectedIngredient, value); }
        }

        public string NewIngredientText
        {
            get { return _newIngredientText; }
            set { SetField(ref _newIngredientText, value); }
        }

        public bool IsNewSingular
        {
            get { return _isNewSingular; }
            set { SetField(ref _isNewSingular, value); }
        }

        public bool IsNewMeasured
        {
            get { return _isNewMeasured; }
            set { SetField(ref _isNewMeasured, value); }
        }

        public ICommand RemoveCommand => new DelegateCommand(Remove);
        public ICommand AddCommand => new DelegateCommand(Add);

    }
}
