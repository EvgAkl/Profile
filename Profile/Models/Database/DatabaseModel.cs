using System;
using System.Collections.Generic;
using System.Web;

namespace Profile.Models.Database
{
    public enum GroupName
    {
        Racers = 1,
        Bikers,
        Jokers,
        Musicians
    }

    public enum Rank
    {
        Tiny = 1,
        Small,
        Middle,
        Large,
        Hudge,
        Impossible
    }

    public class Group
    {
        public int GroupId { get; set; }
        public GroupName Name { get; set; }
        public int CountMembers { get; set; }
        public Rank Rank { get; set; }
        public DateTime CreationDate { get; set; }
        public int Karma { get; set; }
        public string ImagePath { get; set; } 
    } // end "Group" class

} // end namespace