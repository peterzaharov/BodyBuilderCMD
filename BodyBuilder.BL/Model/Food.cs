using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Model
{
    [Serializable]

    /// <summary>
    /// Еда.
    /// </summary>
    public class Food
    {
        public int Id { get; set; }

        #region "Свойства"
        /// <summary>
        /// Наименование еды.
        /// </summary>
        public string FoodName { get; set; }

        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }

        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории.
        /// </summary>
        public double Calories { get; set; }
        #endregion
        public virtual ICollection<Meal> Meals { get; set; }
        public Food() { }
        public Food(string foodName, double proteins, double fats, double carbohydrates, double calories)
        {
            #region "Проверка входных данных"
            if (string.IsNullOrWhiteSpace(foodName))
                throw new ArgumentNullException("Наименование еды не может быть пустыми", nameof(foodName));

            if (proteins < 0)
                throw new ArgumentException("Отрицательное количество белков в еде невозможно!", nameof(proteins));

            if (fats < 0)
                throw new ArgumentException("Отрицательное количество белков в еде невозможно!", nameof(fats));

            if (carbohydrates < 0)
                throw new ArgumentException("Отрицательное количество углеводов в еде невозможно!", nameof(carbohydrates));

            if (calories < 0)
                throw new ArgumentException("Отрицательное количество калорий в еде невозможно!", nameof(calories));
            #endregion

            FoodName = foodName;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public Food(string foodName) : this(foodName, 0, 0, 0, 0) { }
        public override string ToString()
        {
            return FoodName;
        }
    }
}
