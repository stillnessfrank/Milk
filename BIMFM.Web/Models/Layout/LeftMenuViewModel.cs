using Abp.Application.Navigation;

namespace BIMFM.Web.Models.Layout
{
    public class LeftMenuViewModel
    {
        public UserMenu MainMenu { get; set; }

        public string ActiveMenuItemUrl{ get; set; }
        public string ActiveMenuItemController { get; set; }
        //public string ActiveMenuItemAction { get; set; }
    }
}