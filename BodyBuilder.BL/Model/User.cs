using System;
using System.Collections.Generic;

namespace BodyBuilder.BL.Model
{
    [Serializable]

    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        #region "Свойства пользователя"
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата рождения пользователя.
        /// </summary>
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public int? GenderId { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public virtual Gender UsersGender { get; set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }
        
        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
        public int Age { get { return DateTime.Now.Year - DateOfBirth.Year; } }
        #endregion
        public User() { }

        /// <summary>
        /// Конструктор пользователя.
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="dateOfBirth">Дата рождения.</param>
        /// <param name="usersGender">Пол.</param>
        /// <param name="weight">Вес.</param>
        /// <param name="height">Рост.</param>
        public User(string name, DateTime dateOfBirth, Gender usersGender, double weight, double height)
        {
            #region "Проверка входных данных"
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пользователя не могут быть пустыми", nameof(name));

            if (dateOfBirth < DateTime.Parse("01.01.1900") || dateOfBirth >= DateTime.Now)
                throw new ArgumentException("Дата рождения введена некорректно!", nameof(dateOfBirth));

            if (usersGender == null)
                throw new ArgumentNullException("Пол пользователя не может быть пустым!", nameof(usersGender));

            if (weight <= 0)
                throw new ArgumentException("Вес пользователя не может быть меньше или равен нулю!", nameof(weight));

            if (height <= 0)
                throw new ArgumentException("Рост пользователя не может быть меньше или равен нулю!", nameof(height));
            #endregion

            Name = name;
            DateOfBirth = dateOfBirth;
            UsersGender = usersGender;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя пользователя не могут быть пустыми", nameof(name));
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
