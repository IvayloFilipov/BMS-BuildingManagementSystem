namespace BuildingManagementSystem.Common
{
    public static class GlobalConstants
    {
        // Common constants
        public const string SystemName = "Building Management System";
        public const string ShortSystemName = "BMS";

        // Building email - added by me. Should create one. This below is myne.
        public const string SystemEmail = "ivaylo_filipov@abv.bg";

        // Roles constants
        public const string AdministratorRoleName = "Admin";
        public const string UserRoleName = "User";
        public const string ControllerRoleName = "Controller";
        public const string TenantRoleName = "Tenant";
        public const string GuestRoleName = "Guest";

        // Input models constraints
        // Folder - Building Data
        // Entity Address
        public const int DistrictMaxLength = 50;
        public const int StreetMaxLength = 100;
        public const int StreetNumberMaxLength = 5;
        public const int BlockNumberMaxLength = 5;
        public const int EntranceNumberMaxLength = 5;
        public const int FloorNumberMaxLength = 2;
        public const int ApprtmentNumberMaxLength = 3;
        public const int ZipCodeNumberMaxLength = 4;

        // Entity City
        public const int CityNameMaxLength = 80;

        // Entity Company Owner
        public const int CompanyNameMaxLength = 100;
        public const int UICMaxLength = 20;
        public const int CompanyOwnerFirstNameMaxLength = 50;
        public const int CompanyOwnerLastNameMaxLength = 50;
        public const int CompanyEmailMaxLength = 80;
        public const int CompanyPhoneMaxLength = 20;

        // Entity Owner
        public const int OwnerFirstNameMaxLength = 50;
        public const int OwnerMiddleNameMaxLength = 50;
        public const int OwnerLastNameMaxLength = 50;
        public const int OwnerEmailMaxLength = 80;
        public const int OwnerPhoneMaxLength = 20;

        // Entity Property type
        public const int PropertyTypeMaxLength = 50;
        public const string ShopPropertyType = "Магазин";
        public const string AppartmentPropertyType = "Апартамент";
        public const string StudioPropertyType = "Студио";
        public const string GaragePropertyType = "Гараж";

        // Entity Tenant
        public const int TenantFirstNameMaxLength = 50;
        public const int TenantMiddleNameMaxLength = 50;
        public const int TenantLastNameMaxLength = 50;
        public const int TenantEmailMaxLength = 80;
        public const int TenantPhoneMaxLength = 20;

        // Folder - Building Expenses
        // Entity Expense type
        public const int ExpenseTypeMaxLength = 50;
        public const string ElectriciyElevatorExpenseType = "Ел. енергия - асансьор";
        public const string StairsElectriciyStairsExpenseType = "Ел. енергия - общи части";
        public const string MaintenanceElevatorFeeExpenseType = "Такса - асансьор";
        public const string ManagementFeeExpenseType = "Такса управление";
        public const string CleaningFeeExpenseType = "Такса почистване";
        public const string BankFeeExpenseType = "Такса банк. сметка";
        public const string OthersExpenseType = "Други";

        // Entity Transaction
        public const int TransactionDescriptionMaxLength = 250;

        // Folder - Building Funds
        // Entity Account
        public const int AccountTypeMaxLength = 20;
        public const int AccountDescriptionMaxLength = 250;
        public const string CashAccounType = "Каса";
        public const string UbbBankAccountType = "Банкова сметка - ОББ";

        // Folder - Building Incomes
        // Entity Payment
        public const int PaymentPeriodMaxLength = 250;
        public const string CashPaymentType = "В брой";
        public const string BankPaymentType = "Банков превод";

        // Enatity Payment type
        public const int PaymentTypeMaxLength = 20;

        // Folder - Common
        // Entity Contact form
        public const int FullNameMaxLength = 100;
        public const int ContactEmailMaxLength = 80;
        public const int ContactPhoneMaxLength = 20;
        public const int ContactTitleMaxLength = 200;
        public const int ContactContentMaxLength = 15000;

        // Entity File
        public const int URLMaxLength = 1000;
        public const int FileDescriptionMaxLength = 250;
        public const int FileExtensionMaxLength = 10;

        // Folder - Debts
        // Entity Fee
        public const int FeeTypeMaxLength = 100;
        public const int FeeDescriptionMaxLength = 250;
        public const int ReducedMonthlyFeeAmount = 10;
        public const int RegularMonthlyAmount = 20;
        public const int IncreasedMonthlyAmount = 80;
        public const string ReducedMonthlyFee = "Намалена такса";
        public const string RegularMonthlyFee = "Нормална такса";
        public const string IncreasedMonthlyFee = "Увеличена такса";

        // Entity Property debt
        public const int PropertyDebtDescriptionMaxLength = 250;

        // Entity Property status
        public const int PropertyStatusMaxLength = 50;
        public const string OccupiedPropertyStatus = "Обитаем";
        public const string UnoccupiedPropertyStatus = "Необитаем";
        public const string TemporariliFreePropertyStatus = "Временно необитаем";
        public const string CommertialPropertyStatus = "С търговска дейност";

        // Register Error messages
        public const string FirstNameErrorMessage = "Полето '{0}' трябва да съдържа само букви и да има минимум {2} и максимум {1} символа.";
        public const string LasttNameErrorMessage = "Полето '{0}' трябва да съдържа само букви и да има минимум {2} и максимум {1} символа.";
        public const string EmailErrorMessage = "В полето '{0}' е въведен невалиден е-мейл адрес.";
        public const string PhoneNumberErrorMessage = "В полето '{0}' е въведен невалиден телефонен номер. Модела за въвеждане на коректен телефонен номер е '+359ххххххххх'. Празни пространства не са разрешени.";
        public const string PasswordErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.";
        public const string ConfirmPasswordErrorMessage = "Въведените данни в полето 'Парола' и 'Повторете паролата' не съвпадат.";

        // Register Building book Error messages
        public const string CompanyNameErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.";
        public const string CityNameErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.";
        public const string DistrictNameErrorMessage = "Полето '{0}' трябва да съдържа минимум {2} и максимум {1} символа.";
        public const string ZipCodeErrorMessage = "Полето '{0}' трябва да съдържа точно {2} цифри.";
    }
}
