using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Model
{
    [Serializable]

    /// <summary>
    /// Прием пищи.
    /// </summary>
    public class Meal
    {
        public int Id { get; set; }

        #region "Свойства приёма пищи."
        /// <summary>
        /// Момент приёма пищи.
        /// </summary>
        public DateTime MomentOfEating { get; set; }

        /// <summary>
        /// Коллекция еды.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion
        public Meal() { }

        /// <summary>
        /// Конструктор приёма пищи.
        /// </summary>
        /// <param name="user">Имя пользователя</param>
        public Meal(User user)
        {
            User = user ?? throw new ArgumentNullException("Имя пользователя не может быть пустым!", nameof(user));
            MomentOfEating = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавление приема пищи.
        /// </summary>
        /// <param name="food">Наименование употребленной пищи.</param>
        /// <param name="weight">Вес пищи.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.FoodName.Equals(food.FoodName));

            if (product == null)
                Foods.Add(food, weight);
            else
                Foods[product] += weight;
        }
    }
}
