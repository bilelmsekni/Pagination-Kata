using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;

namespace PaginationLogic
{
    public class PaginationLogic
    {
        ItemDao _itemDao;

        public PaginationLogic()
        {
            _itemDao = new ItemDao();
        }

        public PaginationResults Paginate(int ps, int rp)
        {
            var elements = _itemDao.GetItems(FilterCriteria.GetFilters());
            int firstPage;
            int lastpage;
            int previousPage;
            int nextPage;

            if (elements != null && elements.Count > 0)
            {
                firstPage = 1;
            }
            else
            {
                firstPage = 0;
            }

            if (elements != null && elements.Count > 0 && ps > 0)
            {
                var total = elements.Count + ps;

                lastpage = total - 1 / ps;
            }
            else
            {
                lastpage = 0;
            }

            if (elements != null)
            {
                if (rp > 1 && elements.Count > 0)
                {
                    previousPage = rp - 1;
                }
                else
                {
                    previousPage = -1;
                }
            }
            else
            {
                previousPage = 0;
            }

            if (elements != null)
            {
                if (rp * ps <= elements.Count - 1)
                {
                    nextPage = rp + 1;
                }
                else
                {
                    nextPage = -1;
                }
            }
            else
            {
                nextPage = 0;
            }

            var results = new PaginationResults();
            results.FirstPage = firstPage;
            results.LastPage = lastpage;
            results.PreviousPage = previousPage;
            results.NextPage = nextPage;

            return results;
        }
    }

    public class FilterCriteria
    {
        public static Filter GetFilters()
        {
            return new Filter
            {
                Availibility = true,
                RequiredQuality = ItemQuality.High
            };
        }
    }

    public class Filter
    {
        public string Name { get; set; }
        public ItemQuality RequiredQuality { get; set; }
        public bool Availibility { get; set; }
    }

    public class PaginationResults
    {
        public int FirstPage { get; set; }
        public int LastPage { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        //public IEnumerable<Item> PageItems { get; set; }
    }

    public class ItemDao
    {
        public IList<Item> GetItems(Filter filter)
        {
            var quantity = new Random().Next(1, 50);
            var itemId = 1;
            var itemRules = new Faker<Item>()
                .RuleFor(a => a.ItemId, f => itemId++)
                .RuleFor(a => a.ItemName, f => f.Commerce.Product())
                .RuleFor(a => a.Available, f => f.PickRandom<bool>())
                .RuleFor(a => a.ItemQuality, f => f.PickRandom<ItemQuality>());
            return itemRules.Generate(quantity).ToList();
        }
    }

    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public ItemQuality ItemQuality { get; set; }
        public bool Available { get; set; }
    }

    public enum ItemQuality
    {
        Basic,
        Medium,
        High
    }
}
