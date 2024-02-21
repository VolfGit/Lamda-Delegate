//Задание:
//Создайте класс Product с полями Name (строка), Price(двойное число) и Category(строка).

//Создайте список объектов класса Product и добавьте в него несколько элементов.

//Создайте делегат FilterDelegate, который принимает объект типа Product и возвращает
//булево значение.

//Используя лямбда-выражение, создайте экземпляр делегата FilterDelegate, который будет
//фильтровать список объектов Product по какому-либо критерию (например, все продукты с ценой больше 50).

//Выведите на экран отфильтрованный список продуктов.

//Создайте делегат для вычисления общей стоимости продуктов в списке.

//Используя лямбда-выражение, создайте экземпляр делегата для вычисления общей стоимости
//продуктов в списке.

//Выведите на экран общую стоимость продуктов.

//Создайте делегат для преобразования списка продуктов в список их названий.

//Используя лямбда-выражение, создайте экземпляр делегата для преобразования списка
//продуктов в список их названий.

//Выведите на экран список названий продуктов.

using static Program;

class Program
{
    public delegate bool FilterDelegate(Product product);
    public delegate double AverageDelegate(Product product);
    public delegate string OnlyNamelistDeleagte(Product product);
    public static void Main(string[] args)
    {

        Product product = new Product()
        { Name = "Sosiski", Category = "Mjaso", Price = 14 };
        Product product1 = new Product()
        { Name = "Bulka", Category = "Hleb", Price = 11 };
        Product product2 = new Product()
        { Name = "Limonade", Category = "Napitki", Price = 16 };

        List<Product> Products = new List<Product>();

        Products.Add(product);

        Products.Add(product1);
        Products.Add(product2);

        FilterDelegate delegatefilter = p => p.Price < 15;
        List<Product> Sortedlist = new List<Product>();

        foreach (Product prop in Products)
        {
            if (delegatefilter(prop))

            {
                Sortedlist.Add(prop);

                Product.PrintProduct(prop);
            }
        }

        //Func<Product, double> selector = p => p.Price;
        AverageDelegate avgDelegate = (Product p) => p.Price;//не получилось с помощью делегата

        
        double averagePrice = product.CalculateAverage(Products, avgDelegate);
        //double averagePrice = Products.Average(selector);
        Console.WriteLine($"Average price of List: {averagePrice:F2}");

        OnlyNamelistDeleagte onlyname = (Product p) => p.Name;
        List<string> productListNames = new List<string>();
        productListNames = Product.CreateNameList(Products, onlyname);
        foreach(string p  in productListNames)

        { Console.WriteLine(p); }

        //List <String> productListNames = new List<String>();
        //foreach (Product p in Products)
        //{
        //    productListNames.Add(onlyname(p));
        //    Console.WriteLine(p.Name);
        //}    



    }
}



class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }




    public static void PrintProduct(Product prop)
    {
        Console.WriteLine($"{prop.Name} , {prop.Category} , {prop.Price}");
    }


    //public static double CalculateAverage(List<Product> products, AverageDelegate averageDelegate)
    //{
    //    double sum = 0;
    //    foreach (Product product in products)
    //    {
    //        sum += averageDelegate(product);
    //    }
    //    return sum / products.Count;
    //}
    public  double CalculateAverage(List<Product> products, AverageDelegate averageDelegate)
    {
        double sum = 0;
        foreach (Product product in products)
        {
            sum += averageDelegate(product);
        }
        return sum / products.Count;
    }

    public static List<string> CreateNameList(List<Product> products, OnlyNamelistDeleagte onlyNameDelegate)
    {
        List<string> nameList = new List<string>();
        foreach (Product product in products)
        {
            nameList.Add(onlyNameDelegate(product));
        }
        return nameList;
    }
    

}