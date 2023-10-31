namespace AnimeList.Web.UI.Services
{
    public class MenuItemModel
    {
        public string Name { get; set; } = string.Empty;
        public string Href { get; set; } = string.Empty;
        public string IconClass { get; set; } = string.Empty; 
        public static List<MenuItemModel> Intialise()
        {
            var menuItem = new List<MenuItemModel>
            {
                new MenuItemModel { Name = "About", Href = "/About" },
            };

            return menuItem;
        }
    }
}
