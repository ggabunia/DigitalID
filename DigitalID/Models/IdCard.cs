using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalID.Models
{
    public class IdCard
    {
        [ScaffoldColumn(false)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage = "სახელის ველი სავალდებულოა")]
        [Display(Name = "სახელი")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "გვარის ველი სავალდებულოა")]
        [Display(Name = "გვარი")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "მოქალაქეობის ველი სავალდებულოა")]
        [Display(Name = "მოქალაქეობა")]
        public int NationalityID { get; set; }
        public virtual Nationality Nationality { get; set; }
        [Required(ErrorMessage = "სქესის ველი სავალდებულოა")]
        [Display(Name = "სქესი")]
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }
        [Required(ErrorMessage = "პირადი ნომრის ველი სავალდებულოა")]
        [Display(Name = "პირადი ნომერი")]
        public string PersonalNr { get; set; }
        [Required(ErrorMessage = "დაბადების თარიღის ველი სავალდებულოა")]
        [Display(Name = "დაბადების თარიღი")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "გაცემის თარიღის ველი სავალდებულოა")]
        [Display(Name = "გაცემის თარიღი")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; }
        [Required(ErrorMessage = "მოქმედების ვადის ველი სავალდებულოა")]
        [Display(Name = "მოქმედების ვადა")]
        [DataType(DataType.Date)]
        public DateTime ValidityDate { get; set; }
        [Required(ErrorMessage = "დაბადების ადგილის ველი სავალდებულოა")]
        [Display(Name = "დაბადების ადგილი")]
        public int BirthPlaceID { get; set; }
        public virtual BirthPlace BirthPlace { get; set; }
        [Required(ErrorMessage = "ბარათის ნომრის ველი სავალდებულოა")]
        [Display(Name = "ბარათის ნომერი")]
        public string CardNr { get; set; }
        [Required(ErrorMessage = "გამცემი ორგანოს ველი სავალდებულოა")]
        [Display(Name = "გამცემი ორგანო")]
        public string Issuer { get; set; }
    }
}