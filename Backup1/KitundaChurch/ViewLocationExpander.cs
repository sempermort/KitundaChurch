using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitundaChurch
{
    public class ViewLocationExpander: IViewLocationExpander

    {
        protected static IEnumerable<string> ExtendedLocations = new[]
    {
        "/{0}.cshtml"
    };

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            //nothing here
        }

        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            //extend current view locations
            return viewLocations.Concat(ExtendedLocations);
        }
    }
}
