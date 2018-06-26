using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Profile.Models.Database
{
    public enum Rank
    {
        Tiny = 1,
        Small,
        Middle,
        Large,
        Hudge,
        Impossible
    }

    [Bind(Exclude = "CreationDate")]
    public class Group
    {
        public int GroupId { get; set; }
        [Required(ErrorMessage = "Please, enter name. " )]
        [MaxLength(20, ErrorMessage = "Name not must be longer 20 characters. ")]
        public string Name { get; set; }
        [Display(Name = "Count members")]
        [Required(ErrorMessage = "Please, enter count of group members. ")]
        public int CountMembers { get; set; }
        public Rank Rank { get; set; }
        [Display(Name = "Creation date")]
        public string CreationDate { get; set; }
        [Required(ErrorMessage = "Please, set karma.")]
        public int Karma { get; set; }
        public string ImageFileSystemPath { get; set; } 
        public string ImageProgectLinkPath { get; set; }
    } // end "Group" class

} // end namespace