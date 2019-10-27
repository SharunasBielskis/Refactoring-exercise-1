using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredGildenRoseCsharp
{
    static class ItemPropertiesChangeMethods
    {
        //static class because not worthy to create separate instance
        
        public static void StandardChange(Item thisItem)
        {
            thisItem.SellIn-- ;
            // The Quality of an item is never negative
            if (thisItem.Quality > 0)
            {
                thisItem.Quality--;
                // Once the sell by date has passed, Quality degrades twice as fast
                if (thisItem.SellIn < 0 && thisItem.Quality > 0)
                {
                    thisItem.Quality--;
                } 
            }
            
        }
        public static void AgedBrieChange(Item thisItem)
        {
            thisItem.SellIn--;
            //"Aged Brie" actually increases in Quality the older it gets
            //The Quality of an item is never more than 50
            if (thisItem.Quality < 50)
            {
                thisItem.Quality++;
                if (thisItem.SellIn < 0 && thisItem.Quality < 50)
                {
                    thisItem.Quality++;
                } 
            }
            
        }
        public static void BackstagePasses(Item thisItem)
        {
            thisItem.SellIn--;
            // "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
            // Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
            //Quality drops to 0 after the concert
            if (thisItem.SellIn < 0)
            {
                thisItem.Quality = 0;
            }
            else
            {
                if (thisItem.Quality < 50)
                {
                    thisItem.Quality++;
                    if (thisItem.SellIn < 11 && thisItem.Quality < 50)
                    {
                        thisItem.Quality ++;
                    }
                    if (thisItem.SellIn < 6 && thisItem.Quality < 50)
                    {
                        thisItem.Quality++;
                    }
                }
            }
        }
        public static void ConjuredChange(Item thisItem)
        {
            //"Conjured" items degrade in Quality twice as fast as normal items
            thisItem.SellIn--;
            // The Quality of an item is never negative
            if (thisItem.Quality > 0)
            {
                thisItem.Quality--;
                if (thisItem.Quality > 0)
                {
                    thisItem.Quality--;
                }
                // Once the sell by date has passed, Quality degrades twice as fast
                if (thisItem.SellIn < 0 && thisItem.Quality > 0)
                {
                    thisItem.Quality--;
                    if (thisItem.Quality > 0)
                    {
                        thisItem.Quality--;
                    }
                }
            }

        }
    }
}
