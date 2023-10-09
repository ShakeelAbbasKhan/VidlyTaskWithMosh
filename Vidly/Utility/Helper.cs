using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vidly.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Guest = "Guest";
        public static List<SelectListItem> GetRolesForDropDown()
        {
            
             return new List<SelectListItem>
             {
                 new SelectListItem {Value=Helper.Admin,Text = Helper.Admin},
                 new SelectListItem {Value=Helper.Guest,Text = Helper.Guest}
             };
        }
    }
}
