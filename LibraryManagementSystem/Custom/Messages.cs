using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Custom
{
    public static class Messages
    {
        //Admin Email informations 
        public static string adminEmail = "215060018@toros.edu.tr";
        public static string adminMailPw = "h2002T2000.";
        public static string adminSmtpServer = "smtp.gmail.com";


        //RegisterOperations Messages
        public static string registerPassword = "Error! Entered passwords are not matching. Please re-type your password!";
        public static string registerComboBox = "Error! Please select your user rank / role first!";
        public static string registerFail = "An error has occured while registering. Error is: \n";
        public static string registerSuccess = "User has been succcesfully registered";
        public static string passwordCharacters = "Password cannot be shorter than 8 characters";


        //AppInit Messages
        public static string userTypeName = "Please Pick User Type";
        public static string displayMemberPath = "UserTypeName";
        public static string bookCategoryName = "Category";
        public static string categoryDisplayMP = "CategoryName";

        //LoginOperations Messages
        public static string loginIpResult = "Error! You have so many times tried to login withing 15 minutes. Try again later!";
        public static string loginUserEmail = "Error! No such user is found!";
        public static string loginUserPassword = "Error! The entered password is incorrect";
        public static string loginSuccess = "You have successfully logged-in";

        //Notifacition
        public static string userNotifacition = "Check your e-mail address for notifications";

        //Log out
        public static string successLogout = "Logging out of the system";

        //kullanıcıya şifre gönderir
        public static string passwordResetSubject = "Password Reset";

        //kullanıcıya rasgele kod gönderir
        public static string invalidCode = "Invalid code please enter a valid code";

        //Delete Account Mail Object
        public static string deleteObject = "Delete Account";

        //Admin send Email
        public static string sendEmail = "Please select the user you want to send mail";

        //Welcome mail object
        public static string welcomeObject = "Welcome";

        //Book Limits
        public static string myLibraryBook = "Your library can have a maximum of 5 books. If you want to buy another book, you must return the book first";

        //User Password Reset
        public static string passwordResetSuscess = "Your password has been successfully changed";

        //Add Admin
        public static string existMail = "The registered user with the entered e-mail address already exists";

        //My account delete
        public static string accountDelete = "Your account will be permanently deleted Are you sure you want to do this ?";

        //send Email
        public static string sendEmailUser =  "A security code has been sent to the your e-mail address";


    }

}


       

    
