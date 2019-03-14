using System.Windows;
using GroceryList.Views;
using MahApps.Metro.Controls;

namespace GroceryList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        GroceryListView _groceryListView = new GroceryListView();
        RecipeView _recipeView = new RecipeView();
        IngredientsView _ingredientsView = new IngredientsView();

        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = _groceryListView;
        }

        private void GroceryListButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = _groceryListView;
        }

        private void RecipesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = _recipeView;
        }

        private void IngredientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = _ingredientsView;
        }
    }
}
