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
    public partial class TestAdd : System.Web.UI.Page
    {
        //ბაზასთან კავშირის ობიექტი
        private UnitOfWork unitOfWork;

        //ველი რომელიც გამოიყენება რედაქტირების შემთხვევაში
        private int? cardId; 
        
        protected void Page_Load(object sender, EventArgs e)
        {
            unitOfWork = new UnitOfWork();

            //თუკი ამ id-ით ბარათი მოიძებნა, ე.ი. რედაქტირების გვერდია.
            var idStr = Request.QueryString["id"];  
           
            if (!String.IsNullOrWhiteSpace(idStr))
            {
                int currentID = 0;
                try
                {
                    currentID = Convert.ToInt32(idStr);
                }
                catch (Exception)
                {

                }
                var card = unitOfWork.IdCardRepository.GetByID(currentID);
                if (card == null)
                {
                    errorDiv.Text = "<h3 class='alert alert-danger'>ასეთი ბარათი არ არსებობს. შეგიძლიათ დაამატოთ ქვემოთ მოცემული ფორმით</h3>";
                    errorDiv.Visible = true;
                }
                else
                {
                    cardId = Convert.ToInt32(idStr);
                }

            }
            if (!IsPostBack)
            {
                BindDropdowns();
                if (cardId.HasValue)
                {
                    BindModel(cardId.Value);
                }
            }
        }
        //რედაქტირების შემთხვევაში არსებული მონაცემების ჩაწერა
        private void BindModel(int id) 
        {           
            var card = unitOfWork.IdCardRepository.GetByID(id);
            fNameInput.Text = card.FirstName;
            lNameInput.Text = card.LastName;
            pnInput.Text = card.PersonalNr;
            cardNrInput.Text = card.CardNr;
            bDateInput.Text = card.BirthDate.ToString("yyyy-MM-dd");
            validDateInput.Text = card.ValidityDate.ToString("yyyy-MM-dd");
            issueDateInput.Text = card.IssueDate.ToString("yyyy-MM-dd");
            genderInput.SelectedValue = card.GenderID.ToString();
            issuerInput.Text = card.Issuer;
            nationalityInput.SelectedValue = card.NationalityID.ToString();
            birthPlaceInput.SelectedValue = card.BirthPlaceID.ToString();
        }

        //dropdown control-ების შევსება ბაზიდან
        private void BindDropdowns()
        {
            
            nationalityInput.DataSource = unitOfWork.NationalityRepository.Get();
            nationalityInput.DataBind();

            genderInput.DataSource = unitOfWork.GenderRepository.Get();
            genderInput.DataBind();

            birthPlaceInput.DataSource = unitOfWork.BirthplaceRepository.Get();
            birthPlaceInput.DataBind();
        }

        //შევსებული ველების ვალიდაციის და მოდელის ობიექტის შექმნის მეთოდი
        private IdCard CreateModel(string fName, string lName, string personalNr, string cardNr, string issuer, string nationalityIDStr,
            string genderIDStr, string birthPlaceIDStr, string birthDateStr, string issueDateStr, string validityDateStr)
        {
            
            string errors = "";
            int? genderId = null;
            int? birthPlaceId = null;
            int? nationalityId = null;
            DateTime? birthDate = null;
            DateTime? issueDate = null;
            DateTime? validityDate = null;
            if (String.IsNullOrWhiteSpace(fName))
            {
                errors += "<li>სახელის ველი სავალდებულოა</li>";
            }
            else
            {
                fName = fName.Trim();
            }
            if (String.IsNullOrWhiteSpace(lName))
            {
                errors += "<li>გვარის ველი სავალდებულოა</li>";
            }
            else
            {
                lName = lName.Trim();
            }
            if (String.IsNullOrWhiteSpace(nationalityIDStr))
            {
                errors += "<li>მოქალაქეობის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    nationalityId = Convert.ToInt32(nationalityIDStr);
                }
                catch (Exception)
                {
                    errors += "<li>მოქალაქეობა არასწორ ფორმატშია</li>";
                }
            }
            if (String.IsNullOrWhiteSpace(genderIDStr))
            {
                errors += "<li>სქესის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    genderId = Convert.ToInt32(genderIDStr);
                }
                catch (Exception)
                {
                    errors += "<li>სქესი არასწორ ფორმატშია</li>";
                }
            }
            if (String.IsNullOrWhiteSpace(personalNr))
            {
                errors += "<li>პირადი ნომრის ველი სავალდებულოა</li>";
            }
            else
            {
                personalNr = personalNr.Trim();
                if (unitOfWork.IdCardRepository.Get(filter: c => c.PersonalNr == personalNr && c.ID != cardId).Any())
                {
                    errors += "<li>ამ პირადი ნომრით პირადობა უკვე არსებობს</li>";
                }
            }
            if (String.IsNullOrWhiteSpace(birthDateStr))
            {
                errors += "<li>დაბადების თარიღის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    birthDate = DateTime.Parse(birthDateStr);
                }
                catch (Exception)
                {
                    errors += "<li>დაბადების თარიღი არასწორ ფორმატშია</li>";
                }

            }
            if (String.IsNullOrWhiteSpace(issueDateStr))
            {
                errors += "<li>გაცემის თარიღის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    issueDate = DateTime.Parse(issueDateStr);
                }
                catch (Exception)
                {
                    errors += "<li>გაცემის თარიღი არასწორ ფორმატშია</li>";
                }

            }
            if (String.IsNullOrWhiteSpace(validityDateStr))
            {
                errors += "<li>მოქმედების ვადის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    validityDate = DateTime.Parse(validityDateStr);
                }
                catch (Exception)
                {
                    errors += "<li>მოქმედების ვადა არასწორ ფორმატშია</li>";
                }

            }
            if (String.IsNullOrWhiteSpace(birthPlaceIDStr))
            {
                errors += "<li>დაბადების ადგილის ველი სავალდებულოა</li>";
            }
            else
            {
                try
                {
                    birthPlaceId = Convert.ToInt32(birthPlaceIDStr);
                }
                catch (Exception)
                {
                    errors += "<li>დაბადების ადგილი არასწორ ფორმატშია</li>";
                }
            }
            if (String.IsNullOrWhiteSpace(cardNr))
            {
                errors += "<li>ბარათის ნომრის ველი სავალდებულოა</li>";
            }
            else
            {
                cardNr = cardNr.Trim();
            }
            if (String.IsNullOrWhiteSpace(issuer))
            {
                errors += "<li>გამცემი ორგანოს ველი სავალდებულოა</li>";
            }
            else
            {
                issuer = issuer.Trim();
            }
            if (birthDate.HasValue && birthDate.Value > DateTime.Now)
            {
                errors += "<li>დაბადების თარიღი ვერ იქნება მომავალში</li>";
            }
            if (issueDate.HasValue && issueDate.Value > DateTime.Now)
            {
                errors += "<li>გაცემის თარიღი ვერ იქნება მომავალში</li>";
            }
            if (birthDate.HasValue && issueDate.HasValue && birthDate > issueDate)
            {
                errors += "<li>დაბადების თარიღი ვერ იქნება გაცემის თარიღზე გვიან</li>";
            }

            if (errors != "")
            {
                errors = String.Format("<div class='alert alert-danger'><ul>{0}</ul></div>", errors);
                errorDiv.Text = errors;
                errorDiv.Visible = true;
                return null;

            }
            return new IdCard()
            {
                FirstName = fName,
                LastName = lName,
                BirthDate = birthDate.Value,
                BirthPlaceID = birthPlaceId.Value,
                CardNr = cardNr,
                GenderID = genderId.Value,
                IssueDate = issueDate.Value,
                Issuer = issuer,
                NationalityID = nationalityId.Value,
                PersonalNr = personalNr,
                ValidityDate = validityDate.Value
            };
        }
        //მეთოდი რომელიც ამატებს ახალ ობიექტს ან არედაქტირებს ძველს
        public void AddOrUpdate(object sender, EventArgs e)
        {
                    errorDiv.Visible = false;
            errorDiv.Text = "";

            var fName = fNameInput.Text;
            var lName = lNameInput.Text;
            var nationalityID = nationalityInput.SelectedValue;
            var genderID = genderInput.SelectedValue;
            var pN = pnInput.Text;
            var bDate = bDateInput.Text;
            var issuDate = issueDateInput.Text;
            var validityDate = validDateInput.Text;
            var birthPlaceID = birthPlaceInput.SelectedValue;
            var cardNr = cardNrInput.Text;
            var issuer = issuerInput.Text;

            IdCard newCard = CreateModel(fName, lName, pN, cardNr, issuer, nationalityID, genderID, birthPlaceID, bDate, issuDate, validityDate);
            if (newCard != null)
            {
                if (cardId.HasValue)
                {
                    var oldCard = unitOfWork.IdCardRepository.GetByID(cardId.Value);

                    oldCard.FirstName = newCard.FirstName;
                    oldCard.LastName = newCard.LastName;
                    oldCard.IssueDate = newCard.IssueDate;
                    oldCard.Issuer = newCard.Issuer;
                    oldCard.NationalityID = newCard.NationalityID;
                    oldCard.PersonalNr = newCard.PersonalNr;
                    oldCard.ValidityDate = newCard.ValidityDate;
                    oldCard.BirthDate = newCard.BirthDate;
                    oldCard.GenderID = newCard.GenderID;
                    oldCard.BirthPlaceID = newCard.BirthPlaceID;
                    oldCard.CardNr = newCard.CardNr;

                    unitOfWork.IdCardRepository.Update(oldCard);
                }
                else
                {
                    unitOfWork.IdCardRepository.Insert(newCard);
                }
                unitOfWork.Save();
                Response.Redirect("/");
            }

        }

    }
}