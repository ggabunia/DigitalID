using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using DigitalID.DataAccess;
using DigitalID.Models;

namespace DigitalID
{
    public partial class _Default : Page
    {
        //ბაზასთან კავშირის ობიექტი
        private UnitOfWork unitOfWork;

        protected void Page_Load(object sender, EventArgs e)
        {
            unitOfWork = new UnitOfWork();
            if (!IsPostBack)
            {
                BindDropdowns();
            }
        }

        //dropdown control-ების შევსება ბაზიდან
        private void BindDropdowns()
        {

            birthPlaceInput.DataSource = unitOfWork.BirthplaceRepository.Get();
            birthPlaceInput.DataBind();
            birthPlaceInput.Items.Insert(0, new ListItem("დაბადების ადგილი", ""));
        }

        //მეთოდი რომლითაც ხდება გრიდის შევსება. ამავე მეთოდში არის იმპლემენტირებლი ფილტრაცია/ძებნა.
        public IEnumerable<IdCard> GetCards([Control("nameInput")] String name, [Control("pnInput")] String personalNr,
            [Control("birthPlaceInput")] int? birthPlaceID, [Control("bDateFromInput")] DateTime? birthDateFrom,
            [Control("bDateToInput")] DateTime? birthDateTo, [Control("validDateFromInput")] DateTime? validDateFrom,
            [Control("validDateToInput")] DateTime? validDateTo)
        {
            var cards = unitOfWork.IdCardRepository.Get();
            if (!String.IsNullOrWhiteSpace(name))
            {
                cards = cards.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            }
            if (!String.IsNullOrEmpty(personalNr))
            {
                cards = cards.Where(c => c.PersonalNr.Contains(personalNr));
            }
            if (birthPlaceID.HasValue)
            {
                cards = cards.Where(c => c.BirthPlaceID == birthPlaceID.Value);
            }
            if (birthDateFrom.HasValue)
            {
                cards = cards.Where(c => c.BirthDate >= birthDateFrom.Value);
            }
            if (birthDateTo.HasValue)
            {
                cards = cards.Where(c => c.BirthDate <= birthDateTo.Value);
            }
            if (validDateFrom.HasValue)
            {
                cards = cards.Where(c => c.ValidityDate >= validDateFrom.Value);
            }
            if (validDateTo.HasValue)
            {
                cards = cards.Where(c => c.ValidityDate <= validDateTo.Value);
            }
            return cards;
        }


        //მეთოდი, რომელიც გამოიძახება ძებნის ღილაკზე დაჭერისას
        public void FilterData(object sender, EventArgs e)
        {
            collapseField.Value = "show";
            cartGrid.DataBind();
        }

        //რეკურსიული მეთოდი ძებნის ველების გასაწმენდად
        private void ClearInputs(ControlCollection controls)
        {
            collapseField.Value = string.Empty;
            foreach (Control ctrl in controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = string.Empty;
                ClearInputs(ctrl.Controls);
            }
        }


        //მეთოდი, რომლითაც ხდება ძებნის გასუფთავება
        public void ClearSearch(object sender, EventArgs e)
        {
            ClearInputs(Page.Controls);
            BindDropdowns();

            cartGrid.DataBind();
        }

        //პირადობის ბარათის წაშლის მეთოდი - დავალებაში არ იყო მოთხოვნა, როგორ უნდა გამეკეთებინა, და უბრალოდ წაშლაა.
        public void DeleteCard(int id)
        {

            var card = unitOfWork.IdCardRepository.GetByID(id);
            if (card != null)
            {
                unitOfWork.IdCardRepository.Delete(card);
                unitOfWork.Save();
            }           
        }

  
    }
}