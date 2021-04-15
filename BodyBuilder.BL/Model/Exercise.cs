using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Model
{
    [Serializable]

    /// <summary>
    /// Упражнение.
    /// </summary>
    public class Exercise
    {
        public int Id { get; set; }

        #region "Свойства упражнения."
        /// <summary>
        /// Начало выполнения упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Окончание выполнения упражнения
        /// </summary>
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }

        /// <summary>
        /// Активность.
        /// </summary>
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }

        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion
        public Exercise() { }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
