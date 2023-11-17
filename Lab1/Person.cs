namespace Lab1
{
    /// <summary>
    /// Класс Человек
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name;

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age;

        /// <summary>
        /// Пол человека
        /// </summary>
        public Gender Gender;

        /// <summary>
        /// Конструктор класса Человек
        /// </summary>
        /// <param name="lastname">фамилия</param>
        /// <param name="name">имя</param>
        /// <param name="age">возраст</param>
        /// <param name="gender">пол</param>
        public Person(string lastname, string name, int age, Gender gender)
        {
            LastName = lastname;
            Name = name;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Вывод данных о человеке
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"{LastName} {Name}, возраст: {Age}, пол: {Gender}");
        }
    }
}
