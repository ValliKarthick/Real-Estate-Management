using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Real_Estate_Management.Models
{
    public class HouseInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SearchId { get; set; }

        //[Required (ErrorMessage ="Mandatory")]
        public string BrokerId { get; set; }
        //[Display(Name = "House Type")]
        public string HouseType { get; set; }
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Characters are not allowed.")]
        public string Location { get; set; }
        public double SquareFeet { get; set; }
        public string SaleType { get; set; }
        public string Price { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ContactNumber { get; set; }
    }
}