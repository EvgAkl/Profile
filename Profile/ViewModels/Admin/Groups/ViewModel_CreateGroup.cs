using System.Web;
using Profile.Models.Database;
using System.ComponentModel.DataAnnotations;

namespace Profile.ViewModels.Admin.Groups
{
    public class ViewModel_CreateGroup
    {
        public Group group { get; set; }
        [Display(Name = "Choose avatar")]
        public HttpPostedFileBase image { get; set; }
    } // end class
} // end namespace