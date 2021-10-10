using GreenRiverMedia_ComparisonApp.Models;
using GreenRiverMedia_ComparisonApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenRiverMedia_ComparisonApp.Services
{
    public class ItemService : ItemRepository
    {
        List<Item> items;

        public ItemService()
        {
            items = new List<Item> { new Item { Id=1, Name = "Item1", Score = 0 },
                                     new Item { Id=2, Name = "Item2", Score = 0 },
                                     new Item { Id=3, Name = "Item3", Score = 0 },
                                     new Item { Id=3, Name = "Item4", Score = 0 },
                                     new Item { Id=3, Name = "Item5", Score = 0 },
                                     new Item { Id=3, Name = "Item6", Score = 0 }
};
        }

        public bool checkValueOfCounter(int counter, ItemViewModel newModel, IEnumerable<Tuple<Item, Item>> pairs)
        {
            if (counter != pairs.Count() - 1 && newModel.counter != pairs.Count() - 1)
            {
                return true;

            } else 
            {
                return false;
            }
        }

        public void checkValues(int valueOfFirst, int valueOfSecond, int positionOfFirst, int positionOfSecond)
        {
         
                if (valueOfFirst > valueOfSecond)
                {
                    var model = getSingleItem(positionOfFirst);
                    model.Score += 1;
                }
                else
                {
                    var model = getSingleItem(positionOfSecond);
                    model.Score += 1;
                }
        
        }

        public IEnumerable<Item> getAllItems()
        {
            return items.OrderByDescending(i => i.Score);
        }

        public IEnumerable<Tuple<Item, Item>> getPairsOfTuples(List<Item> items)
        {
            return from i in Enumerable.Range(0, items.Count() - 1)
                        from j in Enumerable.Range(i + 1, items.Count() - i - 1)
                        select Tuple.Create(items[i], items[j]);
        }

        public Item getSingleItem(int id)
        {
            return items.FirstOrDefault(i => i.Id == id);
        }

        public int increasingCounter(int counter, ItemViewModel item)
        {
            return item.counter = counter + 1;
        }

        public Tuple<Item, Item> returningNewItems(IEnumerable<Tuple<Item, Item>> pairs, int counter, ItemViewModel newModel )
        {
            var item1 = pairs.ElementAt(counter).Item1;
            var item2 = pairs.ElementAt(counter).Item2;

            newModel.pairsOfItems = Tuple.Create(item1, item2);
            return newModel.pairsOfItems;
        }
    }
}