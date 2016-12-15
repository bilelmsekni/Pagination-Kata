import java.util.ArrayList;
import java.util.List;

/**
 * Created by SkiBLE on 15/12/2016.
 */
public class PaginationLogic {

    ItemDao _itemDao;
    public PaginationLogic()
    {
        _itemDao = new ItemDao();
    }

    public PaginationResults Paginate(int ps, int rp)
    {
        List<Item> elements = _itemDao.GetItems(FilterCriteria.GetFilters());
        int firstPage;
        int lastpage;
        int previousPage;
        int nextPage;

        if (elements != null && elements.size() > 0)
        {
            firstPage = 1;
        }
        else
        {
            firstPage = 0;
        }

        if (elements != null && elements.size() > 0 && ps > 0)
        {
            int total = elements.size() + ps;

            lastpage = total - 1 / ps;
        }
        else
        {
            lastpage = 0;
        }

        if (elements != null)
        {
            if (rp > 1 && elements.size() > 0)
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
            if (rp * ps <= elements.size() - 1)
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

        PaginationResults results = new PaginationResults();
        results.FirstPage = firstPage;
        results.LastPage = lastpage;
        results.PreviousPage = previousPage;
        results.NextPage = nextPage;

        return results;
    }
}

class FilterCriteria {

    public static Filter GetFilters()
    {
        Filter filter = new Filter();
        filter.Availibility =true;
        filter.RequiredQuality = ItemQuality.High;
        return new Filter();
    }
}

class Filter {
    public String Name;
    public ItemQuality RequiredQuality;
    public boolean Availibility;
}

class Item
{
    public int ItemId;
    public String ItemName;
    public ItemQuality ItemQuality;
    public boolean Available;
}

enum ItemQuality
{
    Basic,
    Medium,
    High
}

class ItemDao
{
    public List<Item> GetItems(Filter filter)
    {
        return new ArrayList<Item>();
    }
}

class PaginationResults
{
    public int FirstPage;
    public int LastPage;
    public int PreviousPage;
    public int NextPage;
    //public List<Item> PageItems { get; set; }
}