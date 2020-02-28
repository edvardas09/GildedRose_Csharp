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
                if(Items[i].Name == "Aged Brie")
                    AgedBrie(Items[i]);
                else if (Items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                    BackStagePasses(Items[i]);
                else if (Items[i].Name == "Sulfuras, Hand of Ragnaros")
                    LegendaryItem(Items[i]);
                else if (Items[i].Name == "Conjured Mana Cake")
                    Conjured(Items[i]);
                else
                    StandardItem(Items[i]);
            }
        }

        public void AgedBrie(Item item)
        {
            item.SellIn--;
            if (item.Quality < 50) item.Quality++;

            if(item.SellIn < 0 && item.Quality < 50) item.Quality++;
        }

        public void BackStagePasses(Item item)
        {
            item.SellIn--;

            if (item.Quality < 50) item.Quality++;

            if (item.SellIn < 10)
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 5)
            {
                if (item.Quality < 50) item.Quality++;
            }
            if (item.SellIn < 0)
            {
                item.Quality = 0;
            }
        }

        public void Conjured(Item item)
        {
            item.SellIn--;

            if (item.SellIn >= 0)
                item.Quality -= 2;

        }

        public void LegendaryItem(Item item)
        {
            item.SellIn = item.SellIn;
            item.Quality = item.Quality;
        }

        public void StandardItem(Item item)
        {
            item.SellIn--;
            if (item.Quality > 0) item.Quality--;
            if (item.SellIn < 0)
            {
                if (item.Quality > 0) item.Quality--;
            }
        }
    }
}