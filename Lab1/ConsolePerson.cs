namespace Lab1
{
    /// <summary>
    /// Класс вывода.
    /// </summary>
    public static class ConsolePerson
    {
        /// <summary>
        /// Метод вывода списка людей.
        /// </summary>
        /// <param name="listperson">список людей.</param>
        /// <param name="nameList">название списка людей.</param>
        public static void Print(PersonList listperson, string nameList)
        {
            Console.WriteLine(nameList);

            int count = listperson.CountList();

            for (int index = 0; index <= count; index++)
            {
                Person person = listperson.LookForIndexList(index);
                Console.WriteLine(person.GetInfo());
            }

            Console.WriteLine();
        }
    }
}
