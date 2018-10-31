using System;

public class Class1
{
    string ReadFile(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        try
        {
            string text = reader.ReadToEnd();
        } catch (Exception e)
        {
            Console.WriteLine("Read file exception thrown");
        }
        finally {
            if (reader != null)
            {
                reader.Close();
            }
        }

        return text;
    }

    // dayOfWeek = Day of the Week (Monday, Tuesday, etc)
    // hours = # of Hours for the gig
    // minutes = # of Minutes for the gig
    // miles = # of Miles to the gig
    double CalculateBill(string dayOfWeek, int hours, int minutes, int miles)
    {
        double price = 0;
        double firstPrice = 0;
        if (dayOfWeek = "Monday")
        {

        }
        else if ((dayOfWeek = "Tuesday" || (dayOfWeek = "Wedesday") || (dayOfWeek = "Thursday") || (dayOfWeek = "Sunday")))
        {
            
            if (hours = 2)
            {
                price = 200.00;
            }
            else if (hours > 2)
            {
                if (minutes >= 45)
                {
                    firstPrice = 200;
                    price = firstPrice + 75;
                }
            }
            else if (miles > 30)
            {
                double m = 0;
                double milage = 0;
                firstPrice = 200;
                m = miles - 30;
                milage = m * .50;
                price = firstPrice + milage;
            }
        }
        else if ((dayOfWeek = "Friday" || (dayOfWeek = "Saturday")))
        {
            double adder = 0;
            adder = 200 * 0.15;

            if (hours = 2)
            {
                price = 200.00 + adder;
            }
            else if (hours > 2)
            {
                if (minutes >= 45)
                {
                    firstPrice = 200;
                    price = firstPrice + 75;
                }
            }
            else if (miles > 30)
            {
                double m = 0;
                double milage = 0;
                m = miles - 30;
                milage = m * .50;
                firstPrice = 200 + milage;
                price = firstPrice + adder;
            }
        }
        return price;
    }
    int index = 0;
    int[,] itemData = new int[index, 3];
    string EvaluateGrocerySpending(int[,]itemData)
    {
        double totalCost = 0;
        int product_code = 0;
        IDictionary<int, int> dictItem = new Dictionary<index, totalCost>();       
        double price = 0;
        int quantity_purchased = 0;
        double cost = 0;
        int finalProductCode = 0;
        string itemName = "";

        for (int i = 1; i < itemData.GetLength(0); i++)
        {
            for (int k = 0; k < itemData.GetLength(1); k++)
            {   
                product_code = itemData[i, 0];
                price = itemData[i, 1];
                quantity_purchased = itemData[i, 2];
                totalCost = price * quantity_purchased;
                dictItem.add(product_code, totalCost); 
                
            }
        }

        var keyOfMaxValue = dictItem.Aggregate((a, b) => a.Value > b.Value ? a : b).Key;
        finalProducCode = int.Parse(keyOfMaxValue);
        itemName = GetItemName(finalProductCode);
        return itemName;
    }
}
