namespace Common.Constants;

public enum EventType : short
{
    AdminCreated = 1,
    AdminUpdated = 2,
    AdminLocked = 3,
    AdminUnlocked = 4,
    AdminDeleted = 5,
    AdminPasswordReset = 6,
    AdminPasswordChanged = 7,


    CategoryCreated = 1001,
    CategoryUpdated = 1002,
    CategoryLocked = 1003,
    CategoryUnlocked = 1004,
    CategoryDeleted = 1005,
    CategoryIconUpdated =1006,

    DepartmentCreated = 2001,
    DepartmentRenewed = 2002,
    DepartmentLocked = 2003,
    DepartmentUnlocked = 2004,
    DepartmentDeleted = 2005,
    DepartmentFileUpdated = 2006,
    DepartmentRequested = 2007,
    DepartmentApproved = 2008,
    DepartmentRejected = 2009,


    LicenseCreated = 3001,
   LicenseUpdated = 3002,
   LicenseLocked = 3003,
   LicenseUnlocked = 3004,
   LicenseDeleted = 3005,
   LicenseFileUpdated = 3006,
   LicenseRequested = 3007,
   LicenseApproved = 3008,
    LicenseRejected = 3009,

    ProductCreated = 4001,
    ProductUpdated = 4002,
    ProductLocked = 4003,
    ProductUnlocked = 4004,
    ProductDeleted = 4005,
    ProductFileUpdated = 4006,

    UserCreated = 5001,
    UserUpdated = 5002,
    UserLocked = 5003,
    UserUnlocked = 5004,
    UserDeleted = 5005,
}