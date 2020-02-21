using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {   
            for (var i = 0; i < Items.Count; i++)
            {
                //check if item name starts with "sulfuras"
                if (!Items[i].Name.StartsWith("Sulfuras")) //if item is not sulfuras, do calculations
                {
                    //if item is not sulfuras, decrease SellIn value
                    Items[i].SellIn -= 1;

                    if (Items[i].SellIn < 0 && Items[i].Quality > -1) //if item's sell by date has passed and quality is above -1
                    {
                        //check if item's name starts with "Aged Brie"
                        if (Items[i].Name == "Aged Brie" && Items[i].Quality < 50)
                        {
                            Items[i].Quality += 2;
                        }

                        //check if item's name starts with "Backstage passes"
                        else if (Items[i].Name.StartsWith("Backstage passes"))
                        {
                            Items[i].Quality = 0;
                        }

                        //check if item's name starts with "Conjured"
                        else if (Items[i].Name.StartsWith("Conjured"))
                        {
                            Items[i].Quality -= 4;
                        }
                        
                        //for remaining items'
                        else if (Items[i].Name != "Aged Brie")
                        {
                            Items[i].Quality -= 2;
                        }
                    }

                    //if item quality between 0 and 50 and sell by date has not passed, change quality
                    else if (Items[i].Quality > -1 && Items[i].Quality < 50)
                    {
                        //check if item's name starts with "Aged Brie"
                        if (Items[i].Name == "Aged Brie")
                        {
                            Items[i].Quality += 1;
                        }

                        //check if item's name starts with "Backstage passes"
                        else if (Items[i].Name.StartsWith("Backstage passes"))
                        {
                            Items[i].Quality += 1; //always add 1 to quality

                            if (Items[i].SellIn < 10)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    if (Items[i].SellIn < 5)
                                    {
                                        Items[i].Quality += 2; //if item's sell by date is less then 5, add 2 more to quality
                                    }
                                    else
                                        Items[i].Quality += 1; //if item's sell by date is less then 10, but more then 5, add 1 more to quality
                                }
                            }

                        }

                        //check if item's name starts with "Conjured"
                        else if (Items[i].Name.StartsWith("Conjured"))
                        {
                            Items[i].Quality -= 2;
                        }

                        //for other items'
                        else
                        {
                            Items[i].Quality -= 1;
                        }
                    }

                    //just in case quality drops below 0
                    if (Items[i].Quality < 0)
                        Items[i].Quality = 0;
                    //just in case quality rises above 50
                    if (Items[i].Quality > 50)
                        Items[i].Quality = 50;
                }            
            }
        }
    }
}