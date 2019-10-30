using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalID.Models;


namespace DigitalID.DataAccess
{
    //Unit Of Work Design Pattern-ის იმპლემენტაცია.
    public class UnitOfWork : IDisposable
    {
        private DigitalIdDbContext context = new DigitalIdDbContext();
        private GenericRepository<Gender> genderRepository;
        private GenericRepository<Nationality> nationalityRepository;
        private GenericRepository<BirthPlace> birthplaceRepository;
        private GenericRepository<IdCard> idCardRepository;

        public GenericRepository<Gender> GenderRepository
        {
            get
            {

                if (this.genderRepository == null)
                {
                    this.genderRepository = new GenericRepository<Gender>(context);
                }
                return genderRepository;
            }
        }

        public GenericRepository<Nationality> NationalityRepository
        {
            get
            {

                if (this.nationalityRepository == null)
                {
                    this.nationalityRepository = new GenericRepository<Nationality>(context);
                }
                return nationalityRepository;
            }
        }

        public GenericRepository<BirthPlace> BirthplaceRepository
        {
            get
            {

                if (this.birthplaceRepository == null)
                {
                    this.birthplaceRepository = new GenericRepository<BirthPlace>(context);
                }
                return birthplaceRepository;
            }
        }

        public GenericRepository<IdCard> IdCardRepository
        {
            get
            {

                if (this.idCardRepository == null)
                {
                    this.idCardRepository = new GenericRepository<IdCard>(context);
                }
                return idCardRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}