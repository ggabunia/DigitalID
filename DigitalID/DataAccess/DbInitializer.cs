using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DigitalID.Models;

namespace DigitalID.DataAccess
{
    //კლასი, რომლითაც ხდება თავდაპირველი მნიშვნელობების ინიციალიზაცია, თუკი მოდელი შეიცვალა.
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DigitalIdDbContext>
    {
        protected override void Seed(DigitalIdDbContext context)
        {
            GetBirthPlaces().ForEach(c => context.BirthPlaces.Add(c));
            GetGenders().ForEach(p => context.Genders.Add(p));
            GetNationalities().ForEach(p => context.Nationalities.Add(p));
            context.SaveChanges();
            foreach(var item in GetCards())
            {
                var rand = new Random();
                var nationalities = context.Nationalities.ToList();
                var birthPlaces = context.BirthPlaces.ToList();
                item.BirthPlaceID = birthPlaces[rand.Next(birthPlaces.Count)].ID;
                item.NationalityID = nationalities[rand.Next(nationalities.Count)].ID;
                context.IdCards.Add(item);
            }
        }
        private static List<Gender> GetGenders()
        {
            return new List<Gender>()
            {
                new Gender() { ID=1, GenderName="მამრობითი" },
                new Gender(){ID=2, GenderName="მდედრობითი"}
            };
        }
        private static List<BirthPlace> GetBirthPlaces()
        {
            return new List<BirthPlace>()
            {
                new BirthPlace(){PlaceName="თბილისი"},
                new BirthPlace(){PlaceName="ბათუმი"},
                new BirthPlace(){PlaceName="ქუთაისი"},
                new BirthPlace(){PlaceName="ზუგდიდი"},
                new BirthPlace(){PlaceName="თელავი"},
                new BirthPlace(){PlaceName="სხვა"}
            };
        }
        private static List<Nationality> GetNationalities()
        {
            return new List<Nationality>()
            {
                new Nationality(){NationalityName="საქართველო"},
                new Nationality(){NationalityName="სომხეთი"},
                new Nationality(){NationalityName="აზერბაიჯანი"},
                new Nationality(){NationalityName="თურქეთი"},
                new Nationality(){NationalityName="რუსეთი"},
                new Nationality(){NationalityName="ამერიკა"},
                new Nationality(){NationalityName="გერმანია"},
                new Nationality(){NationalityName="სხვა"}
            };
        }

        private static List<IdCard> GetCards()
        {
            return new List<IdCard>()
            {
                new IdCard()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    BirthDate = new DateTime(1980,3,12),
                    CardNr = "XX123",
                    GenderID = 1,
                    IssueDate = new DateTime(2016,1,21),
                    Issuer = "ACME",
                    PersonalNr = "12345678910",
                    ValidityDate = new DateTime(2026,1,21)
                },
                 new IdCard()
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    BirthDate = new DateTime(1986,11,3),
                    CardNr = "XX124",
                    GenderID = 2,
                    IssueDate = new DateTime(2018,10,7),
                    Issuer = "ACME",
                    PersonalNr = "12345678911",
                    ValidityDate = new DateTime(2028,10,7)
                },
                  new IdCard()
                {
                    FirstName = "Erika",
                    LastName = "Mustermann",
                    BirthDate = new DateTime(1993,4,1),
                    CardNr = "XX125",
                    GenderID = 2,
                    IssueDate = new DateTime(2012,9,6),
                    Issuer = "ACME",
                    PersonalNr = "99999999999",
                    ValidityDate = new DateTime(2022,9,6)
                },
                   new IdCard()
                {
                    FirstName = "Titius",
                    LastName = "Seius",
                    BirthDate = new DateTime(1971,3,12),
                    CardNr = "XX126",
                    GenderID = 1,
                    IssueDate = new DateTime(2016,1,21),
                    Issuer = "ACME",
                    PersonalNr = "33333355555",
                    ValidityDate = new DateTime(2026,1,21)
                },

            };
        }
    }
}