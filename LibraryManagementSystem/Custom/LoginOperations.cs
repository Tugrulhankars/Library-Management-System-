using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManagementSystem.Custom
{
    public static class LoginOperations
    {
        public static Admins loggedAdmin = null;
        public static Users loggedUser = null;
        public static DateTime dtloggedTime;
        

        public static void loginTry(MainWindow main)
        {
            using (LMSContext context = new LMSContext())
            {
                var ipTestResult = context.LoginTries.Where(tr => tr.TriedIp == GlobalMethods.returnUserIp() & tr.DateOfTry.AddMinutes(15) > DateTimeHelper.ServerTime).Count();
                if (ipTestResult>5)
                {
                    MessageBox.Show(Messages.loginIpResult);
                    return;
                }
                var adminEmail = context.Admins.FirstOrDefault(tr => tr.Email == main.txtLoginEmail.Text);
                var userEmail = context.Users.FirstOrDefault(tr => tr.UserEmail == main.txtLoginEmail.Text);
                if (userEmail!=null && userEmail.UserPassword==GlobalMethods.returnUserPassword(main.passwordBoxLogin.Password.ToString(),userEmail.SaltOfPw))
                {
                    

                    loggedUser = userEmail;
                    dtloggedTime = DateTimeHelper.ServerTime;
                    main.lblMyAccountUserFN.Content = loggedUser.FirstName;
                    main.lblMyAccountUserLN.Content = loggedUser.LastName;
                    main.lblMyAccountUserEmail.Content = loggedUser.UserEmail;
                    main.lblMyAccountUserRD.Content = loggedUser.RegisterDate;
                    
                    int label = (int)loggedUser.UserTypeId;

                    if (label == 1)
                    {
                        main.lblMyAccountRank.Content = "Teacher";
                        main.lblHomePage.Content = loggedUser.FirstName + " " + loggedUser.LastName + "/"+main.lblMyAccountRank.Content;
                    }
                    else if (label == 2)
                    {
                        main.lblMyAccountRank.Content = "Student";
                        main.lblHomePage.Content = loggedUser.FirstName + " " + loggedUser.LastName + "/" + main.lblMyAccountRank.Content;
                    }                   
                    main.tabControl.SelectedIndex = 3;
                    MessageBox.Show(Messages.loginSuccess);

                }
                
                else if (adminEmail!=null && adminEmail.Password==GlobalMethods.returnUserPassword(main.passwordBoxLogin.Password.ToString(),adminEmail.SaltOfPw))
                {
                    loggedAdmin = adminEmail;
                    main.lblAdminName.Content = adminEmail.FirstName +""+ adminEmail.LastName;
                    main.tabControl.SelectedIndex = 6;
                    MessageBox.Show(Messages.loginSuccess);
                }

                else
                {
                    increaseLoginTry();
                    MessageBox.Show(Messages.loginUserEmail);
                    return;
                }

                main.txtLoginEmail.Text = "";
                main.passwordBoxLogin.Password = "";

            }
        }


        private static void increaseLoginTry()
        {
            using (LMSContext context = new LMSContext())
            {
                LoginTries tries = new LoginTries();
                tries.TriedIp = GlobalMethods.returnUserIp();
                tries.DateOfTry=DateTimeHelper.ServerTime;
                context.LoginTries.Add(tries);
                context.SaveChanges();

            }
        }

        public static void userLogout()
        {
            loggedUser = null;
            MessageBox.Show(Messages.successLogout);
            GlobalMethods.main.tabControl.SelectedIndex = 1;

        }

        public static void adminLogout()
        {
            loggedAdmin = null;
            MessageBox.Show(Messages.successLogout);
            GlobalMethods.main.tabControl.SelectedIndex = 1;
        }

        
    }
}
