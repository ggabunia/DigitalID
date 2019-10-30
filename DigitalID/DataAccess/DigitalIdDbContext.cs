using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DigitalID.Models;


namespace DigitalID.DataAccess
{

    //ბაზასთან კავშირის კლასი.
    public class DigitalIdDbContext : DbContext
    {
        public DigitalIdDbContext() : base("DigitalID")
        {
           
        }
        public DbSet<IdCard> IdCards { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<BirthPlace> BirthPlaces { get; set; }
    }
}