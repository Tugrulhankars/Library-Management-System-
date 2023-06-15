using Gst;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using VisioForge.MediaFramework.Helpers;
using Task = System.Threading.Tasks.Task;

namespace LibraryManagementSystem.Custom
{
    public static class VerifyEmail
    {


        //E-posta adresi ve SMTP bilgilerini tanımalarız
        public static string emailAdmin = Messages.adminEmail;
        public static string password =Messages.adminMailPw;
        public static string smtpServer =Messages.adminSmtpServer;
        public static int smtpPort = 587;

        //Kullanıcının E-posta adresi
        public static string userEmailAddress;
        public static string userName;

        //E-posta Gövdesi Oluşturulur
        public static string subject;
        public static string body;


        public static int randomCode;
        public static string mail2;
        public static string title;
        public static string content;

        //Email that sends a security code to the user
        public static async void emailNew(MainWindow main,Dispatcher dispatcher)
        {
           
            using (LMSContext context = new LMSContext())
            {
                var verifyUser = context.Users.FirstOrDefault(tr => tr.UserEmail == main.txtForgetPwEmail.Text.ToString());
                dispatcher.Invoke(() =>
                {
                    Users users = new Users();

                   
                    if (verifyUser == null)
                    {
                        MessageBox.Show(Messages.loginUserEmail);
                        return;
                    }
                    Random random = new Random();
                    randomCode = random.Next(100, 9999999);
                    


                    userEmailAddress = main.txtForgetPwEmail.Text.ToString();                                    
                    mail2 = main.txtForgetPwEmail.Text.ToString();
                    MessageBox.Show(Messages.sendEmailUser);
                    main.tabControl.SelectedIndex = 5;

                });
                await Task.Run(() =>
                {

                    subject = Messages.passwordResetSubject;
                    body = $"Hello, \n\nSecurity Code:{randomCode}\n\nTo change your password, you must use the security code we sent.";
                    MailMessage message = new MailMessage(emailAdmin, userEmailAddress, subject, body);

                    if (verifyUser.UserEmail == mail2)
                    {
                        SmtpClient client = new SmtpClient(smtpServer, smtpPort);
                        client.Credentials = new NetworkCredential(emailAdmin, password);
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                    
                });


            }
        }
        
        //Forget Password and new password
        public static  void newPassword()
        {

            using (LMSContext context = new LMSContext())
            {

                string code = GlobalMethods.main.txtNewPwCode.Text;
                int code2 = int.Parse(code);

                if (randomCode != code2)
                {
                    MessageBox.Show(Messages.invalidCode);
                    return;
                }
                else
                {
                    var user = context.Users.FirstOrDefault(tr => tr.UserEmail == GlobalMethods.main.txtForgetPwEmail.Text.ToString());
                    Guid guid = Guid.NewGuid();
                    user.SaltOfPw = guid.ToString();
                    user.UserPassword = GlobalMethods.returnUserPassword(GlobalMethods.main.txtNewPwPassword.Password.ToString(), user.SaltOfPw);
                    context.Users.Update(user);
                    context.SaveChanges();
                    MessageBox.Show(Messages.passwordResetSuscess);
                    GlobalMethods.main.tabControl.SelectedIndex = 3;
                }
                

            }
        }


        //Delete user account mail message
        public static async void deleteAccountMail(Dispatcher dispatcher)
        {
            dispatcher.Invoke(() =>
            {
                userEmailAddress = LoginOperations.loggedUser.UserEmail;
                userName = LoginOperations.loggedUser.FirstName+ " " + LoginOperations.loggedUser.LastName;
            });
            await Task.Run(() =>
            {


                string subject = Messages.deleteObject;
                string body = $"Hello, \n\n{userName} \n\nWe learned that you have left the Metropolitan Library and it saddens us that we hope you will join us again.\nBest regards,\n Metropolition Library team";
                MailMessage mail = new MailMessage(emailAdmin, userEmailAddress, subject, body);

                SmtpClient client = new SmtpClient(smtpServer, smtpPort);
                client.Credentials = new NetworkCredential(emailAdmin, password);
                client.EnableSsl = true;
                client.Send(mail);
            });


        }


        //Notifications that the admin sends to the user
        public static async void adminNotifacition(Dispatcher dispatcher)
        {

            dispatcher.Invoke(() =>
            {    
                
                
                var email = GlobalMethods.main.gridAdminUser;
                if (email.SelectedItem != null)
                {
                    var selectedRow = email.ItemContainerGenerator.ContainerFromItem(email.SelectedItem) as DataGridRow;
                    if (selectedRow != null)
                    {
                        var dataItem = selectedRow.Item;
                        var firstColumnProperty = dataItem.GetType().GetProperty("UserEmail");
                        userEmailAddress = (string)firstColumnProperty.GetValue(dataItem, null);
                        title = GlobalMethods.main.txtAdminSendEmailObj.Text;
                        content = GlobalMethods.main.txtAdminSendEmail.Text;
                        MessageBox.Show(Messages.sendEmail);
                    }
                }

               
            });


            await Task.Run(() =>
            {
                try
                {
                    string subject = title;
                    string body = content;
                    MailMessage mail = new MailMessage(emailAdmin, userEmailAddress, subject, body);

                    SmtpClient client = new SmtpClient(smtpServer, smtpPort);
                    client.Credentials = new NetworkCredential(emailAdmin, password);
                    client.EnableSsl = true;
                    client.Send(mail);
                }
                catch (Exception E)
                {

                    MessageBox.Show(Messages.sendEmail);
                    return;
                }

               
            });


        }


        //welcome mail
        public static async void SendEmailInBackground(Dispatcher dispatcher)
        {
            dispatcher.Invoke(() =>
            {
                userEmailAddress = GlobalMethods.main.txtEmail.Text;
                userName = GlobalMethods.main.txtFirstName.Text + " " + GlobalMethods.main.txtLastName.Text;
            });
            await Task.Run(() =>
            {
                
                
                string subject = Messages.welcomeObject;
                string body = $"Hello, \n\n{userName} \n\nWelcome to our family\n\n Are you ready to travel the different worlds between the pages of the book? ";
                MailMessage mail = new MailMessage(emailAdmin, userEmailAddress, subject, body);

                SmtpClient client = new SmtpClient(smtpServer, smtpPort);
                client.Credentials = new NetworkCredential(emailAdmin, password);
                client.EnableSsl = true;
                client.Send(mail);
            });

           
        }

       

    }

}

