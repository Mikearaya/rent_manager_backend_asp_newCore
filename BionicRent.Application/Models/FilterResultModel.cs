using System.Collections;
using System.Collections.Generic;

namespace BionicRent.Application.Models {
    public class FilterResultModel<T> {
        public IEnumerable<T> Items;
        public int Count;
    }
}