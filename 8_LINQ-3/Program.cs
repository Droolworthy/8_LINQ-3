using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ3
{
    internal class Program
    {
        static void Main()
        {
            Hospital hospital = new Hospital();

            hospital.Work();
        }
    }

    class Hospital
    {
        private readonly List<Ill> _ills = new List<Ill>();

        public Hospital()
        {
            CreateIlls();
        }

        public void Work()
        {
            bool isWork = true;

            string commandSortPatientsByFullName = "1";
            string commandSortPatientsByAge = "2";
            string commandSortPatientsByDisease = "3";
            string commandExit = "4";

            while (isWork)
            {
                Console.WriteLine("Отсортировать всех больных по ФИО - " + commandSortPatientsByFullName);
                Console.WriteLine("Отсортировать всех больных по возрасту - " + commandSortPatientsByAge);
                Console.WriteLine("Вывести больных с определенным заболеванием - " + commandSortPatientsByDisease);
                Console.WriteLine("Выйти из приложения - " + commandExit);

                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (userInput == commandSortPatientsByFullName)
                {
                    var filteredPatientsByFullName = _ills.OrderBy(patient => patient.FullName);

                    ShowFilteredPatients(filteredPatientsByFullName);

                    DescribeResult("\nДля продолжения нажмите любую клавишу...");
                }
                else if (userInput == commandSortPatientsByAge)
                {
                    var filteredPatientsByAge = _ills.OrderBy(patient => patient.Age);

                    ShowFilteredPatients(filteredPatientsByAge);

                    DescribeResult("\nДля продолжения нажмите любую клавишу...");
                }
                else if (userInput == commandSortPatientsByDisease)
                {
                    Console.Write("Введите заболевание больного - ");
                    userInput = Console.ReadLine();

                    var filteredPatientsByDisease = _ills.Where(patient => patient.Disease.ToLower() == userInput.ToLower());

                    foreach (var patient in filteredPatientsByDisease)
                    {
                        Console.WriteLine($"ФИО - {patient.FullName}, Возраст - {patient.Age}, Заболевание - {patient.Disease}");
                    }

                    DescribeResult("\nДля продолжения нажмите любую клавишу...");
                }
                else if (userInput == commandExit)
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        private void ShowFilteredPatients(IOrderedEnumerable<Ill> filteredPatients)
        {
            foreach (var patient in filteredPatients)
            {
                Console.WriteLine($"ФИО - {patient.FullName}, Возраст - {patient.Age}, Заболевание - {patient.Disease} ");
            }
        }

        private void DescribeResult(string initialDescription)
        {
            Console.WriteLine(initialDescription);
            Console.ReadLine();
            Console.Clear();
        }

        private void CreateIlls()
        {
            _ills.Add(new Ill("Петров Петр Петрович", 18, "Акне"));
            _ills.Add(new Ill("Гусева Екатерина Сергеевна", 20, "Вирусная инфекция"));
            _ills.Add(new Ill("Иванов Иван Иванович", 19, "Акне"));
            _ills.Add(new Ill("Кузнецова Анна Денисовна", 21, "Вирусная инфекция"));
            _ills.Add(new Ill("Целиков Павел Михайлович", 25, "Остеохондроз"));
            _ills.Add(new Ill("Орехов Дмитрий Викторович", 33, "Вирусная инфекция"));
            _ills.Add(new Ill("Королёв Николай Сергеевич", 23, "Бронхит"));
            _ills.Add(new Ill("Малышев Илья Николаевич", 30, "Бронхит"));
            _ills.Add(new Ill("Фролов Дмитрий Алексеевич", 35, "Остеохондроз"));
            _ills.Add(new Ill("Галкин Илья Михайлович", 38, "Остеохондроз"));
        }
    }

    class Ill
    {
        public Ill(string completeName, int year, string illness)
        {
            FullName = completeName;
            Age = year;
            Disease = illness;
        }

        public string FullName { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }
    }
}
