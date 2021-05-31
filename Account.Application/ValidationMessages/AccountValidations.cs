namespace Account.Application.ValidationMessages
{
    public static class AccountValidations
    {
        #region Password
        public const string CurrentPasswordInValid = "کلمه عبور فعلی نامعتبر است";
        public const string PasswordNotCompareRePassword = "کلمه های عبور یکسان نیستند";
        public const string PasswordMinLength = "کلمه عبور باید بیشتر از 6 کاراکتر باشد";
        public const string PasswordMaxLength = "کلمه عبور باید کمتر از 50 کاراکتر باشد";


        #endregion

        public const string EmailExist = "ایمیل وارد شده تکراری است";
        public const string Required = "وارد کردن این فیلد اجباری است";
        public const string UserNotFound = "کاربری با مشخصات وارد شده یافت نشد";
        public const string NotFound = "اطلاعات درخواستی یافت نشد";
        public const string MaxLength = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است";
        public const string MinLength = "تعداد کاراکتر های وارد شده کمتر از حد مجاز است";
        public const string InvalidPhoneNumber = "شماره تلفن نامعتبر است";
        public const string InvalidNationalCode = " کدملی نامعتبر است";
        

    }
}