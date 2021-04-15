using BodyBuilder.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Controller
{
    public class MealController : ControllerBase
    {
        private readonly User user;
        public List<Food> Foods { get; }
        public Meal Meal { get; }
        public MealController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            Foods = GetAllFoods();
            Meal = GetMeal();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.FoodName == food.FoodName);

            if (product == null)
            {
                Foods.Add(food);
                Meal.Add(food, weight);
                Save();
            }
            else
            {
                Meal.Add(product, weight);
                Save();
            }
        }

        private Meal GetMeal()
        {
            return Load<Meal>().FirstOrDefault() ?? new Meal(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
        private void Save()
        {
            Save(Foods);
            Save(new List<Meal>() { Meal });
        }
    }
}
