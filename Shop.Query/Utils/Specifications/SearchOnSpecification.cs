using System;
using System.Linq.Expressions;
using Common.Core.Enums;
using Common.Domain;

namespace Shop.Query.Utils.Specifications
{
    public class SearchOnSpecification<T,TKey> : BaseSpecification<T> where T : BaseEntity<TKey>
    {
        public SearchOnSpecification(SearchOn searchOn)
        {
            switch (searchOn)
            {
                case SearchOn.Active:
                    Criteria = i => i.IsDelete == false;
                    break;
                case SearchOn.Deleted:
                    Criteria = i => i.IsDelete;
                    break;
                case SearchOn.All:
                    Criteria = i => i.Id != null;
                    break;
            }

        }
    }
}