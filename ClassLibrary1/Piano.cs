using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace лаба10
{
    public class Piano: MusicalInstrument , IInit
    {
        
        Random rnd = new Random();
        static string[] KeyboardLayouts = { "октавная", "шкальная", "дигитальная" };
        protected int NumberOfKeys1;
        public int NumberOfKeys
        {
            get => NumberOfKeys1;
            set
            {
                // if (value < 0)
                // {
                //     Console.WriteLine("Error!");
                //     NumberOfKeys = 0;
                // }
                // else NumberOfKeys = value;
            }
        }

        protected string KeyboardLayout1;
        public string KeyboardLayout
        {
            get => KeyboardLayout1;
            set
            {
                //if (HasCharacters)
                //{
                //    Console.WriteLine("Error!");
                //    name = "";
                //}
                //else KeyboardLayout1 = value;
            }
        }
        public Piano() : base()
        {
            NumberOfKeys = 0;
            KeyboardLayout = string.Empty;
        }

        public Piano(int keys, string name, string layout, int num) : base(name, num)
        {
            NumberOfKeys1 = keys;
            KeyboardLayout1 = layout;
        }

        public override void Show()
        {
            Console.WriteLine($"Id: {num} Фортепиано. Название: {Name}, количество клавиш: {NumberOfKeys}, раскладка: {KeyboardLayout}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Piano p)
                return this.NumberOfKeys == p.NumberOfKeys
                    && this.KeyboardLayout == p.KeyboardLayout
                    && this.Name == p.Name;
            return false;
        }

        public override string ToString()
        {
            return base.ToString() + $"Id: {num} Фортепиано. Количество клавищ: {NumberOfKeys}, раскладка: {KeyboardLayout}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите тип расскладки");
            KeyboardLayout1 = Console.ReadLine();
            Console.WriteLine("Введите количество клавиш");
            NumberOfKeys1 = Functions.Input();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            KeyboardLayout1 = KeyboardLayouts[rnd.Next(KeyboardLayouts.Length)];
            NumberOfKeys1 = rnd.Next(1,89);
        }
        public new object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
        
    }
}

