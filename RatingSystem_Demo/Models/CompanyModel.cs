using System.ComponentModel.DataAnnotations;

namespace RatingSystem_Demo.Models
{
    public class CompanyModel
    {
        public Guid f_uid { get; set; }

        [Display(Name ="ID")]
        public int f_iid { get; set; }

        [Display(Name = "Company Name")]
        public string f_company_name { get; set; }

        [Display(Name = "Location")]
        public string f_company_location { get; set; }

        [Display(Name = "Country")]
        public string f_country { get; set; }

        [Display(Name = "Glassdoor Rating")]
        public float f_glassdoor_rating { get; set; }
    }
}
