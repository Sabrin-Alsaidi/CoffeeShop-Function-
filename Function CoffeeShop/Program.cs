using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Function_CoffeeShop;
class Program
{
    static void Main(string[] args)
    {

        int type , size;
        double coffeePrice , total;
        string withSugar, withMilk;
        string[] coffee = { "Americano", "Latte", "Cappuccino" };
        double[] price = { 2.50, 3.00, 3.50 };
        string[] coffeeSize = { "samll", "Medium", "Large" };
        double[] sizePrice = { 1.50, 2.00, 3.50 };
        display_menu(coffee, price);
        place_order(coffeeSize, sizePrice,out type, out size,out withSugar,out withMilk);
        calculate_cost(price, sizePrice,type, size,out total);
        display_order_summary(coffee, coffeeSize, type, size,  withSugar, withMilk,total);
    }

    //display menu
    static void display_menu(string[] coffees, double[]prices)
    {
        
        for (int i = 0; i <coffees.Length ; i++)
        {
            Console.WriteLine($"{i+1}. {coffees[i]} - {prices[i]}");
            
        }
    }

    //place order
    static void place_order(string[] coffeesize, double[] sPrice,out int coffeeType, out int cSize,
        out string Sugar, out String Milk)
    {
        //display size
        Console.WriteLine("Select a coffee (1-3):");
         coffeeType = int.Parse(Console.ReadLine());

        Console.WriteLine("Customizations:");
        for (int i = 0; i < coffeesize.Length; i++)
        {
            Console.WriteLine($"{i+1}.{coffeesize[i]} - {sPrice[i]}");
        }
        do
        {
            Console.WriteLine("Select a size (1-3):");
        } while (!int.TryParse(Console.ReadLine(), out cSize) || cSize > 3);
        //with sugar or not
        Console.WriteLine("Do you want sugar? (yes/no):");
        string sug = Console.ReadLine();
         Sugar = (sug.ToLower() == "yes")? "With sugar " :"without sugar";
        //with milk or not 
        Console.WriteLine("Do you want milk? (yes/no):");
        string m = Console.ReadLine();
        Milk = (m.ToLower() == "yes") ? "With Milk " : "without Milk";
    }

    //calculate cost
    static void calculate_cost(double[] prices, double[] sPrice, int type, int size,out double total)
    {
        double CoffeePrice = prices[type-1];
        double cSizePrics = sPrice[size-1];
        total = CoffeePrice + cSizePrics;
    }

    //display order summary
    static void display_order_summary(string[] coffeetype, string[] CPrice,int type,int size ,
        string Sugar,  string Milk,double Total)
    {
        Console.WriteLine($"your order is :{coffeetype[type - 1]}, size {CPrice[size - 1]}, {Sugar} {Milk}. ");
        Console.WriteLine($"The total price is : {Total}");
        Console.WriteLine("Thank you for ordering!");
    }
}

