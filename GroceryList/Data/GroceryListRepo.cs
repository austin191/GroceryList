using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GroceryList.Enums;

namespace GroceryList.Data
{
    public class GroceryListRepo
    {
        private string ingredientsFile = Directory.GetCurrentDirectory() + @"\ingredients.csv";
        private string recipiesFile = Directory.GetCurrentDirectory() + @"\recipies.csv";

        public GroceryListRepo()
        {
            if (!File.Exists(ingredientsFile)) File.Create(ingredientsFile).Close();
            if (!File.Exists(recipiesFile)) File.Create(recipiesFile).Close();
        }

        //ingredients
        public List<Ingredient> GetIngredientsList()
        {
            var listOfIngredients = new List<Ingredient>();
            using (StreamReader reader = new StreamReader(ingredientsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var name = line.Split(',')[0];
                    bool success = Enum.TryParse(line.Split(',')[1], out IngredientTypes type);
                    if (!success) type = IngredientTypes.Measured;

                    listOfIngredients.Add(new Ingredient() {
                        Name = name,
                        Type = type
                    });
                }
            }
            return listOfIngredients;
        }

        public Ingredient GetIngredient(string name)
        {
            using (StreamReader reader = new StreamReader(ingredientsFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (name == line.Split(',')[0])
                    {
                        if (Enum.TryParse(line.Split(',')[1], out IngredientTypes type))
                        {
                            return new Ingredient()
                            {
                                Name = line.Split(',')[0],
                                Type = type
                            };
                        }
                    }
                }
            }
            return new Ingredient();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            using (StreamWriter writer = new StreamWriter(ingredientsFile, append: true))
            {
                writer.WriteLine($"{ingredient.Name},{ingredient.Type.ToString()}");
            }
        }

        public void DeleteIngredient(string name)
        {
            var currentIngredients = GetIngredientsList();
            if (File.Exists(ingredientsFile))
            {
                File.Delete(ingredientsFile);
                File.Create(ingredientsFile).Close();
            }

            foreach (var ing in currentIngredients)
            {
                if (ing.Name != name)
                    AddIngredient(ing);
            }

            DeleteIngredientFromRecipe(name);
        }

        //recipies
        //csv format: name, ingredient, quantity, quantityType
        public List<Recipe> GetRecipesList()
        {
            var recipeList = new List<Recipe>();
            Dictionary<string, List<RecipeIngredientModel>> recipeEntryDictionary = new Dictionary<string, List<RecipeIngredientModel>>();

            using (StreamReader reader = new StreamReader(recipiesFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var name = line.Split(',')[0];
                    if (!recipeEntryDictionary.ContainsKey(name))
                    {
                        recipeEntryDictionary.Add(name, new List<RecipeIngredientModel>());
                    }
                    var ingredient = GetIngredient( line.Split(',')[1] );
                    var quantity = Convert.ToDouble( line.Split(',')[2] );
                    if (Enum.TryParse(line.Split(',')[3], out QuantityTypes quantityType)) {
                        recipeEntryDictionary[name].Add(new RecipeIngredientModel
                        {
                            Ingredient = ingredient,
                            Quantity = quantity,
                            QuantityType = quantityType
                        });
                    }
                }
            }

            foreach (var recipeEntry in recipeEntryDictionary)
            {
                var recipe = new Recipe() { Name = recipeEntry.Key };
                foreach (var rim in recipeEntry.Value)
                {
                    recipe.Ingredients.Add(new RecipeIngredientModel()
                    {
                        Ingredient = rim.Ingredient,
                        Quantity = rim.Quantity,
                        QuantityType = rim.QuantityType
                    });
                }
                recipeList.Add(recipe);
            }

            return recipeList;
        }

        public Recipe GetRecipe(string name)
        {
            var recipe = new Recipe(){ Name = name };

            using (StreamReader reader = new StreamReader(recipiesFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Split(',')[0] == name)
                    {
                        var ingredient = GetIngredient(line.Split(',')[1]);
                        var quantity = Convert.ToDouble(line.Split(',')[2]);
                        if (Enum.TryParse(line.Split(',')[3], out QuantityTypes quantityType))
                        {
                            recipe.Ingredients.Add(new RecipeIngredientModel
                            {
                                Ingredient = ingredient,
                                Quantity = quantity,
                                QuantityType = quantityType
                            });
                        }
                    }                    
                }
            }        

            return recipe;
        }

        public void AddRecipe(Recipe recipe)
        {
            using (StreamWriter writer = new StreamWriter(recipiesFile, append: true))
            {
                foreach (var rim in recipe.Ingredients)
                {
                    writer.WriteLine($"{recipe.Name},{rim.Ingredient.Name},{rim.Quantity},{rim.QuantityType.ToString()}");
                }
            }
        }

        public void DeleteRecipe(string name)
        {
            var currentRecipies = GetRecipesList();
            if (File.Exists(recipiesFile))
            {
                File.Delete(recipiesFile);
                File.Create(recipiesFile).Close();
            }

            foreach (var rec in currentRecipies)
            {
                if (rec.Name != name)
                    AddRecipe(rec);
            }            
        }

        public void DeleteIngredientFromRecipe(string name)
        {
            var currentRecipies = GetRecipesList();
            if (File.Exists(recipiesFile))
            {
                File.Delete(recipiesFile);
                File.Create(recipiesFile).Close();
            }

            using (StreamWriter writer = new StreamWriter(recipiesFile, append: true))
            {
                foreach (var recipe in currentRecipies)
                {
                    foreach (var rim in recipe.Ingredients)
                    {
                        if(rim.Ingredient.Name != name)
                            writer.WriteLine($"{recipe.Name},{rim.Ingredient.Name},{rim.Quantity},{rim.QuantityType.ToString()}");
                    }
                }
            }
        }
    }
}
