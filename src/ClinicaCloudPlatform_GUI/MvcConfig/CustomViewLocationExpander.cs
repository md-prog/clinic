using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System;
namespace MvcConfig
{
    public class CustomViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            viewLocations = viewLocations.Select(f => f.Replace("/Views/", "/MvcViews/"));

            return viewLocations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }
    }
}