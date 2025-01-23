namespace Mission3;

public class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
        
    }

    public void UpdateQuantity(int quantity)
    {
        if (Quantity < 0)
        {
            // add an error handling here
            throw new ArgumentException("Quantity cannot be negative");
        }

        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Category: {Category}, Quantity: {Quantity}, ExpirationDate: {ExpirationDate.ToShortDateString()}";
    }
}
