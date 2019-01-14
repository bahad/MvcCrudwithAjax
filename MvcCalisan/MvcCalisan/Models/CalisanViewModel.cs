using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcCalisan.Models
{
    public class CalisanViewModel
    {
        public int calisanID { get; set; }
        [Required(ErrorMessage = "Enter Name")]
        public string calisanIsim { get; set; }
        [Required(ErrorMessage = "Enter Adres")]
        public string calisanAdres { get; set; }
        public Nullable<int> calisanYas { get; set; }
        public Nullable<decimal> calisanMaas { get; set; }
        public string calisanTelefon { get; set; }
        public string calisanEmail { get; set; }
        [Required(ErrorMessage = "Enter DepartmanID")]
        public int departmanID { get; set; }
        [Required(ErrorMessage = "Enter PozisyonId")]
        public int pozisyonID { get; set; }
        [Required(ErrorMessage = "Enter Kod")]
        public string calisanKod { get; set; }
        public Nullable<int> calisanYetkiID { get; set; }
        public string DepartmentName { get; set; }
        public string PozisyonName { get; set; }
    }
}