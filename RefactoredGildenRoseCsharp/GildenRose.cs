using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactoredGildenRoseCsharp
{
    public class GildenRose
    {
        #region Fields

        //As variable Items is a private field (By default if a class member isn't specified with public access modifier it is private), 
        //will be is more clear this class member to specify with  access modifier key private and
        // its name according to private fields naming convention change to _items, but as according to requirements
        //it isn't allowable to change this property (more exactly field) I left as it was.
        IList<Item> Items;

        #endregion Fields


        #region Constructors
        public GildenRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        #endregion Constructors


        #region Methods

        //The requirements allow to do this method static, but as in the Program class this method will be used in for loop 
        //it is more efficient to create an instance of GildenRose class and access this method through instance, 
        //not by the class name directly.This is the reason why it is left without the static keyword.
        //The same reason is why static  isn't used for field IList<Item> Items and additionally, 
        //if Items be marked as static a static constructor that initializes this field when the class is loaded must be provided.
        public void UpdateQuality()
        {
            for (var i = 0; i < this.Items.Count; i++)
            {
                Item thisItem = this.Items[i];//The methods below will be able as input use only one object not an object collection
                //Used this.Items instead Items, that be more clear that it is the field of the current this class instance
                switch (thisItem.Name)
                {
                    case "+5 Dexterity Vest":
                    case "Elixir of the Mongoose":
                    //!!!!!!!!!Below case must be separated from this group as it has other qualities rules, but initially for testing purpose it leaved here
                    //case "Conjured Mana Cake":
                        ItemPropertiesChangeMethods.StandardChange(thisItem);
                        break;
                    case "Aged Brie":
                        ItemPropertiesChangeMethods.AgedBrieChange(thisItem);
                        break;
                    case "Sulfuras, Hand of Ragnaros":
                        //Do nothing - "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
                        //"Sulfuras", being a legendary item, never has to be sold or decreases in Quality
                        break;
                    case "Backstage passes to a TAFKAL80ETC concert":
                        ItemPropertiesChangeMethods.BackstagePasses(thisItem);
                        break;
                    case "Conjured Mana Cake":
                        ItemPropertiesChangeMethods.ConjuredChange(thisItem);
                        break;
                    default:
                        #region Message to user about good for that isn't implemented quality update method
                        Console.WriteLine("Error No xxx:");
                        Console.WriteLine("In the goods list is item - " + thisItem.Name);
                        Console.WriteLine("for that in the program isn't implemented");
                        Console.WriteLine("quality update method.");
                        Console.WriteLine("The program will end now.");
                        Console.WriteLine("Remove this good from the list and restart the program or");
                        Console.WriteLine("Inform about it your programmer.");
                        Console.WriteLine();
                        #endregion
                        break;
                }
                this.Items[i] = thisItem;//assign item with updated properties back to the collection element.
            }
        }

        

        #endregion Methods

    }
}
