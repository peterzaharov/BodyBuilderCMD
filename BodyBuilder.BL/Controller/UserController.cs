using BodyBuilder.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BodyBuilder.BL.Controller
{
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Новый пользователь.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Конструктор пользователя.
        /// </summary>
        /// <param name="userName">Имя пользователя.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new ArgumentNullException("Имя пользователя не могут быть пустыми", nameof(userName));

            Users = GetAllUsers();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        /// <param name="dateOfBirth">Дата рождения пользователя.</param>
        /// <param name="usersGender">Пол пользователя.</param>
        /// <param name="weight">Вес пользователя.</param>
        /// <param name="height">Рост пользователя.</param>
        public void SetNewUserData(DateTime dateOfBirth, string usersGender, double weight = 1, double height = 1)
        {
            #region "Проверка входных данных"
            if (dateOfBirth < DateTime.Parse("01.01.1900") || dateOfBirth >= DateTime.Now)
                throw new ArgumentException("Дата рождения введена некорректно!", nameof(dateOfBirth));

            if (usersGender == null)
                throw new ArgumentNullException("Пол пользователя не может быть пустым!", nameof(usersGender));

            if (weight <= 0)
                throw new ArgumentException("Вес пользователя не может быть меньше или равен нулю!", nameof(weight));

            if (height <= 0)
                throw new ArgumentException("Рост пользователя не может быть меньше или равен нулю!", nameof(height));
            #endregion

            CurrentUser.DateOfBirth = dateOfBirth;
            CurrentUser.UsersGender = new Gender(usersGender);
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
        }

        /// <summary>
        /// Загрузить список пользователей
        /// </summary>
        /// <returns>Список пользователей.</returns>
        private List<User> GetAllUsers()
        {
            return Load<User>() ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
