using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Model
{
    [Serializable]

    /// <summary>
    /// Активность
    /// </summary>
    public class Activity
    {
        public int Id { get; set; }

        #region "Свойства активности"
        /// <summary>
        /// Наименование активности.
        /// </summary>
        public string ActivityName { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        /// <summary>
        /// Сжигание калорий за минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        #endregion
        public Activity() { }

        /// <summary>
        /// Конструктор активности.
        /// </summary>
        /// <param name="activityName">Наименование активности</param>
        /// <param name="caloriesPerMinute">Количетсво сожженных калорий за минуту</param>
        public Activity(string activityName, double caloriesPerMinute)
        {
            #region "Проверка входных данных"
            if (string.IsNullOrWhiteSpace(activityName))
                throw new ArgumentNullException("Наименование активности не может быть пустыми!", nameof(activityName));
            if (caloriesPerMinute < 0)
                throw new ArgumentException("Количество сожженных калорий не может быть равно нулю!", nameof(caloriesPerMinute));
            #endregion

            ActivityName = activityName;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return ActivityName;
        }
    }
}
