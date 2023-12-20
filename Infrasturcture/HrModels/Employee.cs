using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.HrModels;
 
   public class   Employee
    {
         
        public int EmpId { get; set; }
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string LastName { get; set; }
        public string FullNameEn { get; set; }
        public short Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public string BirthPlace { get; set; }
        public int BirthCityId { get; set; }
        public int NationalityId { get; set; }
        public string NationalNo { get; set; }
        public string PassportNo { get; set; }
        public string PassportIssuingPlace { get; set; }
        public DateTime? PassportIssuingDate { get; set; }
        public DateTime? PassportExpirationDate { get; set; }
        public string IdcardNo { get; set; }
        public string IdcardIssuingPlace { get; set; }
        public DateTime? IdcardIssuingDate { get; set; }
        public short SocialStateId { get; set; }
        public short? ReligionId { get; set; }
        public short? BloodTypeId { get; set; }
        public short Status { get; set; }
     
    }
 
 