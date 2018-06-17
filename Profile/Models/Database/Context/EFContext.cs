using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Profile.Models.Database.Context
{
    public class EFContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }
    } // end class
} // end namespace