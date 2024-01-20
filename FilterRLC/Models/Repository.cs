using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace FilterRLC.Models
{
    public static class Repository
    {
        private static List<FilterParams> filters = new List<FilterParams>();
        public static IEnumerable<FilterParams> Filters => filters;
    public static void AddFilter(FilterParams filter)
        {
            filters.Add(filter);
        }
        public static void ReplaceFilter(FilterParams filter, int id)
        {
            if (filter != null)
            {
                filters[id] = filter;
            }
        }

        public static void RemoveFilter(FilterParams filter, int id)
        {
            filters.RemoveAt(id);
        }
    }
}