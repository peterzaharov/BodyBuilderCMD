using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BodyBuilder.BL.Model
{
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public string GenderName { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public Gender() { }
        
        /// <summary>
        /// Конструктор пола.
        /// </summary>
        /// <param name="genderName">Пол пользователя.</param>
        public Gender(string genderName)
        {
            if (string.IsNullOrWhiteSpace(genderName))
                throw new ArgumentNullException("Пол пользователя не может быть пустым!", nameof(genderName));

            GenderName = genderName;
        }
        public override string ToString()
        {
            return GenderName;
        }
    }
}
