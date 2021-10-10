using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GreenRiverMedia_ComparisonApp.Models
{
    
    public class ItemViewModel
    {
        //Fluent Validation nisam iskoristio jer smatram da je testni projekat msm da nije potreban
        public Tuple<Item, Item> pairsOfItems { get; set; }
        public int counter { get; set; }
        [Required(ErrorMessage = "Please enter first item value.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input must only contain numbers")]  //regex expression za iskljucivo brojeve
        public int valueOfFirst { get; set; }
        [Required(ErrorMessage = "Please enter second item value.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Input must only contain numbers")]
        public int valueOfSecond { get; set; }
    }
}