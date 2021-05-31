using System;
using System.Diagnostics;
using Account.Domain.Enums;

namespace Account.Application.Models.DTOs.Account
{
    public class UserDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string NationalCode { get; set; }
        public string ImageName { get; set; }
        public Guid ActivationToken { get; set; }
        public string Password { get; set; }
        public string ActivationCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastSendCodeDate { get; set; }
        public DateTime CreationDate { get; set; }
        public Gender Gender { get; set; }

        //public string GetGender
        //{
        //    get
        //    {
        //        return Gender switch
        //        {
        //            Gender.Female => "خانم",
        //            Gender.Male => "آقا",
        //            Gender.None => "نامشخص",
        //            _ => "نامشخص"
        //        };
        //    }
        //}
        public string FullName => Name + Family;
    }
}