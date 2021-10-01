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


            firstcheck.printCheck(firstproduct);

            firstcheck.printCheck(firstbuy);

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
        private double price;
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

        private double weight;
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
        public Product(string naming, double price, double weight )
        {
            this.naming = naming;
            this.price = price;
            this.weight = weight;
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
    class Check
    {
        public void printCheck(Product product)
        {
            Console.Write("Product : " + product.Naming + "\nPrice : " + product.Price + "\nWeight : " + product.Weight + "\n\n");
        }
        public void printCheck(Buy purchase)
        {
            Console.Write("Product : " + purchase.product.Naming + "\nSum : " + purchase.sumPrice + "\nSum weight : " + purchase.sumWeight + '\n');

        }
    }
}
