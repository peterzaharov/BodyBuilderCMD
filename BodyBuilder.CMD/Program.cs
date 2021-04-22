using BodyBuilder.BL.Controller;
using BodyBuilder.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace BodyBuilder.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-ru");
            ResourceManager resourceManager = new ResourceManager("BodyBuilder.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Greeting", culture));

            Console.Write(resourceManager.GetString("EnterUserName", culture));
            string name = Console.ReadLine();

            UserController userController = new UserController(name);
            MealController eatingController = new MealController(userController.CurrentUser);
            ExerciseController exercisesController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterUserGender", culture));
                string gender = Console.ReadLine();
                DateTime dateOfBirth = ParseDateTime("дата рождения");
                double weight = ParseDouble("вес");
                double height = ParseDouble("рост");

                userController.SetNewUserData(dateOfBirth, gender, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            while (true)
            {
                Console.WriteLine("Что Вы хотите сделать?");
                Console.WriteLine("E - ввести прием пищи.");
                Console.WriteLine("A - внести упражнение.");
                Console.WriteLine("Q - выход.");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Meal.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exercise = EnterExercise();
                        exercisesController.Add(exercise.Activity, exercise.Begin, exercise.End);
                        foreach (var item in exercisesController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражения: ");
            string exercise = Console.ReadLine();
            double energy = ParseDouble("расход энергии в минуту");

            DateTime begin = ParseDateTime("начало упражения");
            DateTime end = ParseDateTime("окончание упражения");

            Activity activity = new Activity(exercise, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите имя продукта: ");
            string food = Console.ReadLine();

            double calories = ParseDouble("калорийность");
            double proteins = ParseDouble("белки");
            double fats = ParseDouble("жиры");
            double carbohydrates = ParseDouble("углеводы");

            double weight = ParseDouble("вес порции");

            Food product = new Food(food, proteins, fats, carbohydrates, calories);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime dateOfBirth;
            while (true)
            {
                Console.Write($"Введите {value} (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}");
                }
            }

            return dateOfBirth;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат поля {name}");
                }
            }
        }
    }
}
