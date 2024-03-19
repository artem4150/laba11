﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace лаба10
{
    public class ElectricGuitar : Guitar , IInit
    {
        Random rnd = new Random();

        protected string PowerSupply1;
        
        public string PowerSupply
        {
            get => PowerSupply1;
            set
            {
                if (HasCharacters)
                {
                    Console.WriteLine("Error!");
                    name = "";
                }
                else PowerSupply1 = value;
            }
        }

        static string[] PowerSupplys = { "батарейки", "аккумуляторы", "фиксированный источник питания", "USB" };
        public ElectricGuitar() : base()
        {
            PowerSupply = string.Empty;
        }
        public ElectricGuitar(string power, string name, int NumberOfStrings, int num) : base(NumberOfStrings, name, num)
        {
            PowerSupply1 = power;
        }
        public override void Show()
        {
            Console.WriteLine($"Id: {num} Электрогитара. Название: {Name}, источник питания: {PowerSupply}");
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is ElectricGuitar e)
                return this.PowerSupply == e.PowerSupply
                    && this.Name == e.Name;
            return false;
        }

        public override string ToString()
        {
            return base.ToString()+ $"Id: {num} Электрогитара.Источник питания: { PowerSupply}";
        }

        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите тип источника питания");
            PowerSupply = Console.ReadLine();
        }
        public override void RandomInit()
        {
            base.RandomInit();
            PowerSupply1 = PowerSupplys[rnd.Next(PowerSupplys.Length)];
        }
        public int CompareTo(object obj)
        {
            if (obj is Guitar otherGuitar)
            {
                return NumberOfStrings.CompareTo(otherGuitar.NumberOfStrings);
            }

            throw new ArgumentException("Невозможно сравнить объекты");
        }
        public new object ShallowCopy()
        {
            return this.MemberwiseClone();
        }
    }
}
