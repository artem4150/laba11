using лаба10;
using ClassLibrary1;
using System.Collections.Generic;
using MusicalInstrument = ClassLibrary1.MusicalInstrument;

namespace лаба11
{
    public class ElectricGuitar : MusicalInstrument
    {
        // Другие члены класса

        public MusicalInstrument GetBase()
        {
            return new MusicalInstrument(Name, num.number); // Возвращает объект базового класса
        }
    }
    public class TestCollections
    {
        // Поля коллекций
        private Queue<MusicalInstrument> collection1;
        private List<string> collection2;
        private Dictionary<MusicalInstrument, MusicalInstrument> collection3;
        private Dictionary<string, MusicalInstrument> collection4;

        // Конструктор
        public TestCollections(int count)
        {
            // Создание коллекцийт
            collection1 = new Queue<MusicalInstrument>();
            collection2 = new List<string>();
            collection3 = new Dictionary<MusicalInstrument, MusicalInstrument>();
            collection4 = new Dictionary<string, MusicalInstrument>();

            // Заполнение коллекций
            for (int i = 0; i < count; i++)
            {
                ElectricGuitar guitar = new ElectricGuitar();
                collection1.Enqueue(guitar);
                collection2.Add(guitar.ToString());
                collection3.Add(guitar.GetBase(), guitar);
                collection4.Add(guitar.Name, guitar);
            }
            

        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            Queue<MusicalInstrument> instrumentsQueue = new Queue<MusicalInstrument>();

// Добавляем объекты в коллекцию
            ElectricGuitar guitar1 = new ElectricGuitar("батарейки", "Fender Stratocaster", 6, 1);
            Piano piano1 = new Piano(88, "Yamaha YDP-144", "шкальная", 2);
            Guitar guitar2 = new Guitar(12, "Ibanez RG550", 3);

            instrumentsQueue.Enqueue(guitar1);
            instrumentsQueue.Enqueue(piano1);
            instrumentsQueue.Enqueue(guitar2);
            // Добавление объекта в коллекцию
            ElectricGuitar newGuitar = new ElectricGuitar("USB", "Gibson Les Paul", 6, 4);
            instrumentsQueue.Enqueue(newGuitar);

// Удаление объекта из коллекции
            MusicalInstrument removedInstrument = instrumentsQueue.Dequeue();
// Количество элементов гитар в коллекции
            int guitarCount = instrumentsQueue.Count(item => item.GetType() == typeof(Guitar));
            // Печать всех элементов гитар в коллекции
            foreach (var item in instrumentsQueue.Where(item => item.GetType() == typeof(Guitar)))
            {
                Console.WriteLine(item);
            }
            foreach (var item in instrumentsQueue)
            {
                Console.WriteLine(item);
            }
            Queue<MusicalInstrument> clonedQueue = new Queue<MusicalInstrument>(instrumentsQueue);
            List<MusicalInstrument> sortedList = instrumentsQueue.OrderBy(item => item.Name).ToList();
            string searchName = "Fender Stratocaster";
            MusicalInstrument foundInstrument = instrumentsQueue.FirstOrDefault(item => item.Name == searchName);
            Dictionary<int, MusicalInstrument> instrumentsDictionary = new Dictionary<int, MusicalInstrument>();

// Добавляем объекты в коллекцию
            ElectricGuitar guitar1 = new ElectricGuitar("батарейки", "Fender Stratocaster", 6, 1);
            Piano piano1 = new Piano(88, "Yamaha YDP-144", "шкальная", 2);
            Guitar guitar2 = new Guitar(12, "Ibanez RG550", 3);

            instrumentsDictionary.Add(1, guitar1);
            instrumentsDictionary.Add(2, piano1);
            instrumentsDictionary.Add(3, guitar2);
// Добавление объекта в коллекцию
            ElectricGuitar newGuitar = new ElectricGuitar("USB", "Gibson Les Paul", 4);
            instrumentsDictionary.Add(4, newGuitar);

// Удаление объекта из коллекции
            instrumentsDictionary.Remove(2); // Удаление объекта с ключом 2
// Количество элементов гитар в коллекции
            int guitarCount = instrumentsDictionary.Count(item => item.Value.GetType() == typeof(Guitar));
// Печать всех элементов гитар в коллекции
            foreach (var item in instrumentsDictionary.Values.Where(item => item.GetType() == typeof(Guitar)))
            {
                Console.WriteLine(item);
            }
            foreach (var item in instrumentsDictionary.Values)
            {
                Console.WriteLine(item);
            }
            Dictionary<int, MusicalInstrument> clonedDictionary = new Dictionary<int, MusicalInstrument>(instrumentsDictionary);
            var sortedDictionary = instrumentsDictionary.OrderBy(item => item.Value.Name).ToDictionary(item => item.Key, item => item.Value);
            string searchName = "Fender Stratocaster";
            var foundInstrument = instrumentsDictionary.FirstOrDefault(item => item.Value.Name == searchName).Value;
            TestCollections collections = new TestCollections(1000);
            public static TimeSpan MeasureTime(Action action)
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                action();
                watch.Stop();
                return watch.Elapsed;
            }

            void MeasureSearchTime()
            {
                // Измеряем время поиска для первого, центрального, последнего элементов и элемента, не входящего в коллекцию
                MusicalInstrument first = collection1.Peek();
                MusicalInstrument middle = collection1.ElementAt(collection1.Count / 2);
                MusicalInstrument last = collection1.Last();
                MusicalInstrument notInCollection = new ElectricGuitar();

                var timeFirst = MeasureTime(() => SearchElement(first));
                var timeMiddle = MeasureTime(() => SearchElement(middle));
                var timeLast = MeasureTime(() => SearchElement(last));
                var timeNotInCollection = MeasureTime(() => SearchElement(notInCollection));

                Console.WriteLine("Time to search for first element: " + timeFirst);
                Console.WriteLine("Time to search for middle element: " + timeMiddle);
                Console.WriteLine("Time to search for last element: " + timeLast);
                Console.WriteLine("Time to search for element not in collection: " + timeNotInCollection);
            }

            void SearchElement(MusicalInstrument element)
            {
                bool containsKey = collection3.ContainsKey(element);
                bool containsValue = collection3.ContainsValue(element);
                bool containsString = collection2.Contains(element.ToString());
                bool containsByName = collection4.ContainsKey(element.Name);
            }
            collections.MeasureSearchTime();


        }
    }
}