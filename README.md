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
    public static void DisplayMenu(InventoryItem item)
    {
        Console.WriteLine("1. Display Item Details");
        Console.WriteLine("2. Update Price");
        Console.WriteLine("3. Sell Item");
        Console.WriteLine("4. Restock Item");
        Console.WriteLine("5. Exit");

        Console.Write("Select an option (1-5): ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                item.PrintDetails();
                break;
            case 2:
                Console.Write("Enter new price: $");
                double newPrice = Convert.ToDouble(Console.ReadLine());
                item.UpdatePrice(newPrice);
                break;
            case 3:
                Console.Write("Enter quantity to sell: ");
                int quantitySold = Convert.ToInt32(Console.ReadLine());
                item.SellItem(quantitySold);
                break;
            case 4:
                Console.Write("Enter quantity to restock: ");
                int additionalQuantity = Convert.ToInt32(Console.ReadLine());
                item.RestockItem(additionalQuantity);
                break;
            case 5:
                Console.WriteLine("Exiting the program.");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option. Please select 1-5.");
                break;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 10);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 15);

        while (true)
        {
            Console.WriteLine("Select an item (1 or 2): ");
            int selectedItem = Convert.ToInt32(Console.ReadLine());

            // Display the menu for the selected item
            if (selectedItem == 1)
            {
                InventoryItem.DisplayMenu(item1);
            }
            else if (selectedItem == 2)
            {
                InventoryItem.DisplayMenu(item2);
            }
            else
            {
                Console.WriteLine("Invalid item selection. Please select 1 or 2.");
            }
        }
    }
}
