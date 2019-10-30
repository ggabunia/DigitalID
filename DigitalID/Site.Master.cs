using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigitalID.DataAccess;
using DigitalID.Models;


namespace DigitalID
{
    public partial class SiteMaster : MasterPage
    {
        private UnitOfWork unitOfWork;
        protected void Page_Load(object sender, EventArgs e)
        {
            unitOfWork = new UnitOfWork();
        }
        public IEnumerable<Nationality> GetNationalities()
        {
            var _db = new DigitalID.DataAccess.DigitalIdDbContext();
            IEnumerable<Nationality> query = unitOfWork.NationalityRepository.Get();
            return query;
        }

   
    }
}