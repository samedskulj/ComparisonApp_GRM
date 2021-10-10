using GreenRiverMedia_ComparisonApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenRiverMedia_ComparisonApp.Repository
{
    public interface ItemRepository
    {
        IEnumerable<Item> getAllItems();
        Item getSingleItem(int id);

        IEnumerable<Tuple<Item, Item>> getPairsOfTuples(List<Item> items);

        void checkValues( int valueOfFirst, int valueOfSecond, int positionOfFirst, int positionOfSecond);

        int increasingCounter(int counter, ItemViewModel item);

        bool checkValueOfCounter(int counter, ItemViewModel newModel, IEnumerable<Tuple<Item, Item>> pairs);

        Tuple<Item, Item> returningNewItems(IEnumerable<Tuple<Item, Item>> pairs, int counter, ItemViewModel newModel);

    }
}
