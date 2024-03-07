using System;

public class InventoryItem
{

    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }


    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {

        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }




    public void UpdatePrice(double newPrice)
    {

        Price = newPrice;
    }


    public void RestockItem(int additionalQuantity)
    {

        QuantityInStock += additionalQuantity;
    }


    public void SellItem(int quantitySold)
    {

        QuantityInStock = Math.Max(0, QuantityInStock - quantitySold);
    }


    public bool IsInStock()
    {

        return QuantityInStock > 0;
    }


    public void PrintDetails()
    {

        Console.WriteLine($"Item Name: {ItemName}");
        Console.WriteLine($"Item ID: {ItemId}");
        Console.WriteLine($"Price: ${Price:F2}");
        Console.WriteLine($"Quantity in Stock: {QuantityInStock}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {

        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);





        Console.WriteLine("Initial Item Details:");
        item1.PrintDetails();
        item2.PrintDetails();


        item1.SellItem(3);
        item2.SellItem(5);
        Console.WriteLine("After Selling Items:");
        item1.PrintDetails();
        item2.PrintDetails();


        item1.RestockItem(5);
        Console.WriteLine("After Restocking Item 1:");
        item1.PrintDetails();


        Console.WriteLine($"Item 1 is{(item1.IsInStock() ? "" : " not")} in stock.");
        Console.WriteLine($"Item 2 is{(item2.IsInStock() ? "" : " not")} in stock.");
    }
}
