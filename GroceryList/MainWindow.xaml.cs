using System.Windows;
using GroceryList.Data;
using GroceryList.ViewModels;
using GroceryList.Views;
using MahApps.Metro.Controls;

namespace GroceryList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        GroceryListRepo _groceryListRepo = new GroceryListRepo();
        GroceryListView _groceryListView;
        RecipeView _recipeView;
        IngredientsView _ingredientsView;

        public MainWindow()
        {
            InitializeComponent();
            _groceryListView = new GroceryListView(new GroceryListVM(_groceryListRepo));
            _recipeView = new RecipeView(new RecipeVM(_groceryListRepo));
            _ingredientsView = new IngredientsView(new IngredientsVM(_groceryListRepo));
            MainContent.Content = _groceryListView;
        }

        private void GroceryListButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Transition = TransitionType.RightReplace;
            MainContent.Content = _groceryListView;
        }

        private void RecipesButton_Click(object sender, RoutedEventArgs e)
        {
            if(MainContent.Content.GetType() == typeof(GroceryListView))
                MainContent.Transition = TransitionType.LeftReplace;
            else
                MainContent.Transition = TransitionType.RightReplace;

            MainContent.Content = _recipeView;
        }

        private void IngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Transition = TransitionType.LeftReplace;
            MainContent.Content = _ingredientsView;
        }
    }
}
