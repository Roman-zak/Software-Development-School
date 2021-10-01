using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Product firstproduct = new Product("Apple", 20.5, 2);
           
        Buy firstbuy = new Buy(firstproduct, 5);
            //  firstbuy.Calculate();

            Check firstcheck = new Check();


            Console.WriteLine(firstcheck.printCheck(firstproduct));

            Console.WriteLine( firstcheck.printCheck(firstbuy));
            Storage load = new Storage(10);
            Console.WriteLine("input\n");
            load.InputProduct();
            Meat steak = new Meat(Meat.Quality.FirstQuality, Meat.Kind.Porck, "Steak", 1.1, 2.2);
            load.AddProduct(steak);
            Product prod = new Product( "prod", 1.5, 2.5);
            load.AddProduct("Cucumber", 1.5, 2.5);
            Console.WriteLine(load.PrintFullList());
            Console.WriteLine("Meat:\n");
            Console.WriteLine(load.PrintMeat());
            Console.ReadKey();
        }
    }

    class Product
    {
        protected string naming;
        public string Naming
        {
            get
            {
                return naming;
            }
            set
            {
                naming = value;
            }
        }
        protected double price;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        protected double weight;
        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
            }
        }
        public Product()
        {
            naming = "";
            price = 0;
            weight = 0;
        }
         public Product(string naming, double price, double weight)
        {
            this.naming = naming;
            this.price = price;
            this.weight = weight;
        }
        public virtual void ChangePrice(int perc, bool sign)
        {
            if(sign)
                this.price += this.price * perc / 100.0;
            else
                this.price -= this.price * perc / 100.0;
        }
    }
    class Buy
    {
        protected internal Product product;
        public int amount;
        public double sumPrice;
        public double sumWeight;
        //public double fullweight;
        public Buy(Product product, int amount)
        {
            this.product = product;
            this.amount = amount;
            sumPrice = this.product.Price * amount;
            sumWeight = this.product.Weight * amount;
        }
    }
    sealed class Check
    {
        public string printCheck(Product product)
        {
            return  ("Product : " + product.Naming + "\nPrice : " + product.Price + "\nWeight : " + product.Weight + "\n\n");
        }
        public string printCheck(Buy purchase)
        {
            return ("Product : " + purchase.product.Naming + "\nSum : " + purchase.sumPrice + "\nSum weight : " + purchase.sumWeight + '\n');
        }
    }

    class Meat : Product
    {
        public enum Quality { UltimateQuality, FirstQuality, SecondQuality };
        Quality quality;
        public enum Kind { Mutton, Veal, Porck, Chicken };
        Kind kind;
        public override void ChangePrice(int perc, bool sign)
        {
            if (sign)
            {
                this.price += this.price * perc/100.0;

            }
            else
            {
                this.price -= this.price * perc / 100.0;
            }
            switch (quality)
            {
                    case Quality.UltimateQuality:
                        this.price += this.price * 0.3;
                        break;
                    case Quality.FirstQuality:
                        this.price += this.price * 0.15;
                        break;
            }
        }
        public Meat(Quality quality, Kind kind, string naming, double price, double weight)
            : base(naming, price, weight)
        {
            this.quality = quality;
            this.kind = kind;
        }

    }
    class Diry_products : Product
    {
        private int dueDate;
        public int DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public Diry_products(int dueDate, string naming, double price, double weight)
            : base(naming, price, weight)
        {
            this.dueDate = dueDate;
        }

        public override void ChangePrice(int perc, bool sign)
        {
            if (sign)
            {
                this.price += this.price * perc / 100.0;
                
            }
            else
            {
                this.price -= this.price * perc / 100.0;               
            }
            if(dueDate<14)
            {
                this.price -= this.price * 0.3;
            }
        }

    }

    class Storage
    {
        public Product[] products = new Product[10];
        public int maxSize;
        public int size;
        //int currentIndx;

        public Storage()
        {
            size = 0;
            maxSize = 1;
            products = new Product[maxSize];
        }
        public Storage(int size)
        {
            this.size = 0;
            maxSize = size;
            for(int i=0; i<size; i++)
            {
                products[i] = new Product();
            }
            
        }
        public Product this[int index]
        {
            get
            {
                return products[index];
            }
            set
            {
                products[index] = value;
            }
        }

        public void InputProduct()
        {
            products[size].Naming = Console.ReadLine();
            products[size].Price = double.Parse(Console.ReadLine());
            products[size].Weight = double.Parse(Console.ReadLine());
            size++;
        }
        public void AddProduct(string naming, double price, double weight)
        {
            products[size].Naming = naming;
            products[size].Price = price;
            products[size].Weight = weight;
            size++;
        }
        public void AddProduct(object obj)
        {
            products[size]=obj as Product;
            size++;
        }

        public string PrintFullList()
        {
            string print = " ";
            for (int i = 0; i < size; i++)
            {
                print += products[i].Naming + ' ' + products[i].Price.ToString() + ' ' + products[i].Weight.ToString() + '\n';
            }
            return print;
        }

        public void ChangePrice(int perc, bool sign)
        {
            for (int i = 0; i < size; i++)
            {
                if (sign)
                {
                    products[i].Price += products[i].Price * perc / 100.0;

                }
                else
                {
                    products[i].Price -= products[i].Price * perc / 100.0;
                }
            }

        }

        public string PrintMeat()
        {
            string strMeat="";
            for(int i=0; i<size; i++)
            {
                if(products[i] is Meat)
                {
                    strMeat += products[i].Naming + ' ' + products[i].Price.ToString() + ' ' + products[i].Weight.ToString() + '\n';
                }
            }
            return strMeat;
        }

       // public string 
    }
}
/*
Утворити клас Storage, полем якого визначити масив продуктів.
Для цього класу описати наступні методи:
наповнення інформацією даних у режимі діалогу з користувачем,
наповнення інформацією даних шляхом ініціалізації,
друку повної інформації про всі товари,
метод знаходження всіх м’ясних продуктів.
Метод зміни ціни для всіх товарів на заданий відсоток.
Створити індексатор для повного доступу за номером до масиву товарів.

Для класу Check наслідування. Продемонструвати результат на пробному похідному класі.

*/