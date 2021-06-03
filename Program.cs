using System;

namespace ConsoleApp1
{
    public class Student
    {
        // 1. Поля класса - объявленные как protected - видимы в производных классах,
        // и невидимы из экземпляра класса
        protected string name; // Фамилия и имя студента
        protected int course; // Курс обучения
        protected string gradeBook; // Номер зачетной книги

        // 2. Конструктор класса с 3 параметрами
        public Student(string Name, int course, string gradeBook)
        {
            this.Name = Name;
            this.course = course;
            this.gradeBook = gradeBook;
        }

        // 3. Свойства доступа к полям класса
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Course
        {
            get { return course; }
            set { course = value; }
        }

        public string GradeBook
        {
            get { return gradeBook; }
            set { gradeBook = value; }
        }

        // 4. Метод Print() - вывести значения полей на экран
        public void Print()
        {
            Console.WriteLine("The values of fields are:");
            Console.WriteLine($"Name = {name}");
            Console.WriteLine($"Course = {course}");
            Console.WriteLine($"GradeBook = {gradeBook}");
        }
    }

    // Класс Aspirant - наследует возможности класса Student
    public class Aspirant : Student
    {
        // 1. Внутреннее поле класса
        protected string topic; // Тема кандидатской диссертации

        // 2. Конструктор класса Aspirant - с помощью ключевого слова base обращается
        // к конструктору базового класса Student
        public Aspirant(string name, int course, string gradeBook, string topic) :
            base(name, course, gradeBook)
        {
            // Можно изменять protected-члены базового класса
            base.name = name; // доступ к полю name класса Student с помощью base
            this.course = course; // доступ к полю course класса Student с помощью this
            this.gradeBook = gradeBook;

            this.topic = topic; // инициализация внутреннего поля класса Aspirant
        }

        // 3. Свойство для доступа к полю topic
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }

        // 4. Метод Print() - печать полей класса Aspirant
        // Имя данного метода перекрывает имя метода Student.Print(),
        // поэтому перед именем метода указывается new
        public new void Print() // new - переопределение метода базового класса
        {
            base.Print(); // вызвать метод Print() базового класса
            Console.WriteLine($"Topic = {topic}");
        }
    }

    // Класс Зав. Кафедры
    public class ZavKafedry : Aspirant
    {
        protected string kafedra;

        public ZavKafedry(string name, int course, string gradeBook, string topic, string Kafedra) :
            base(name, course, gradeBook, topic)
        {
            // Можно изменять protected-члены базового класса
            base.name = name; // доступ к полю name класса Aspirant с помощью base
            this.course = course; // доступ к полю course класса Aspirant с помощью this
            this.gradeBook = gradeBook;
            this.topic = topic; // доступ к полю topic класса Aspirant с помощью base
            this.Kafedra = Kafedra; // инициализация внутреннего поля класса ZavKafedry
        }

        // 3. Свойство для доступа к полю Kafedra
        public string Kafedra
        {
            get { return kafedra; }
            set { kafedra = value; }
        }

        public new void Print() // new - переопределение метода базового класса
        {
            base.Print(); // вызвать метод Print() базового класса
            Console.WriteLine($"Kafedra = {Kafedra}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация работы с классами Student и Aspirant

            // 1. Объявить экземпляр класса Student
            Student st1 = new Student("Ivanov I.I.", 2, "0519");

            // 2. Вывести поля класса Student
            Console.WriteLine("The instance of st1:");
            st1.Print();

            // 3. Объявить экземпляр класса Aspirant
            // При объявлении используется свойство get экземпляра st1
            Aspirant asp1 = new Aspirant(st1.Name, st1.Course, st1.GradeBook, "Hello world!");

            // 4. Вызвать метод Print() экземпляра asp1
            Console.WriteLine("---------------------");
            Console.WriteLine("The instance of asp1:");
            asp1.Print();

            // 5. Объявить экземпляр класса Aspirant
            // При объявлении используется свойство get экземпляра st1
            ZavKafedry kaf1 = new ZavKafedry(asp1.Name, 4, asp1.GradeBook, asp1.Topic, "Programming");

            // 6. Вызвать метод Print() экземпляра kaf1
            Console.WriteLine("---------------------");
            Console.WriteLine("The instance of kaf1:");
            kaf1.Print();
        }
    }
}
