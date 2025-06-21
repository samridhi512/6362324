using System;
using System.Collections.Generic;

public static class SearchFunctions
{
    // Linear Search by Product Name
    public static Product LinearSearch(Product[] products, string name)
    {
        foreach (Product p in products)
        {
            if (p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase))
                return p;
        }
        return null;
    }

    // Binary Search by Product ID
    public static Product BinarySearch(Product[] products, int productId)
    {
        int low = 0;
        int high = products.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            if (products[mid].ProductId == productId)
                return products[mid];
            else if (products[mid].ProductId < productId)
                low = mid + 1;
            else
                high = mid - 1;
        }
        return null;
    }
}
