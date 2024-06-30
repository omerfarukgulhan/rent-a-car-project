using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserAdded = "User added";
        public static string UserFetched = "User fetched";
        public static string UserClaimsFetched = "User claims fetched";
        public static string TokenCreated = "Token created";
        public static string UserAlreadyExists = "User already exists";
        public static string UserNotFound = "User not found";
        public static string Registered = "Registered";
        public static string WrongPassword = "Wrong password";
        public static string LoginSuccessful = "Login successful";
        public static string AuthorizationDenied = "You do not have authorization for this action";

        public static string ColorsFetched = "Colors fetched";
        public static string ColorFetched = "Color fetched";
        public static string ColorAdded = "Color added";
        public static string ColorDeleted = "Color deleted";
        public static string ColorUpdated = "Color updated";
        public static string ColorNotFound = "Color not found";

        public static string BrandsFetched = "Brands fetched";
        public static string BrandFetched = "Brand fetched";
        public static string BrandAdded = "Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        public static string BrandNotFound = "Brand not found";
    }
}
