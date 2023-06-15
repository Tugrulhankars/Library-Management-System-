using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace LibraryManagementSystem.Custom
{
    public class HomePageOperations
    {


        // ENG: Displays the books the user owns
        // TUR: Kullanıcı sahip olduğu kitapları görüntüler
        public static void myBook()
        {

            using (LMSContext context = new LMSContext())
            {
                

                var query = from a in context.Books
                            join b in context.Records on a.BookId equals b.BookId
                            join c in context.Authors on a.AuthorId equals c.AuthorId
                            join d in context.Categories on a.CategoryId equals d.CategoryId
                            where b.UserId == LoginOperations.loggedUser.UserId
                            select new
                            {
                                RecordId = b.RecordId,
                                BookId=b.BookId,
                                BookName = a.BookName,
                                AuthorFirstName = c.FirstName,
                                AuthorLastName = c.LastName,
                                CategoryName = d.CategoryName,
                                AcquisitionDate = b.AcquisitionDate,
                                ReturnDate = b.ReturnDate,
                                Deadline = b.Deadline
                            };



                GlobalMethods.main.gridMyBook.ItemsSource = query.ToList();
               
            }
        }

        // ENG: User requests for book return
        // TUR: Kullanıcı kitap iadesi için talep gerçekleştirir
        public static void deleteMyBook()
        {
            using (LMSContext context = new LMSContext())
            {
                Returns returns = new Returns();
               

                returns.UserId=LoginOperations.loggedUser.UserId;
                returns.ReturnDate = DateTimeHelper.ServerTime;
                var recordId = GlobalMethods.main.gridMyBook;


                if (recordId.SelectedItem != null)
                {


                    var selectedRow = recordId.ItemContainerGenerator.ContainerFromItem(recordId.SelectedItem) as DataGridRow;
                    if (selectedRow != null)
                    {
                        var dataItem = selectedRow.Item;
                        var firstColumnProperty = dataItem.GetType().GetProperty("RecordId");
                        returns.ReturnId = (int)firstColumnProperty.GetValue(dataItem, null);

                        
                        var secondColumnProperty = dataItem.GetType().GetProperty("BookId");
                        returns.BookId = (int)secondColumnProperty.GetValue(dataItem, null);

                      
                        var third = dataItem.GetType().GetProperty("AcquisitionDate");
                        returns.AcquisitionDate = (DateTime)third.GetValue(dataItem, null);

                       
                        var fourth = dataItem.GetType().GetProperty("Deadline");
                        returns.Deadline = (DateTime)fourth.GetValue(dataItem, null);

                        context.Returns.Add(returns);
                        selectedRow.IsEnabled=false;
                    }                   
                }
                context.SaveChanges();
            }          
        }


        // ENG: Changes the password of the user account
        // TUR: Kullanıcı hesabının şifresini değiştirir
        public static void myAccount()
        {

            using (LMSContext context = new LMSContext())
            {
                var user = LoginOperations.loggedUser;

                if (GlobalMethods.main.txtMANPassword.Password != GlobalMethods.main.txtMAVNPassword.Password)
                {
                    MessageBox.Show(Messages.registerPassword);
                    return;

                }
                Guid guid = Guid.NewGuid();
                user.SaltOfPw = guid.ToString();
                user.UserPassword = GlobalMethods.returnUserPassword(GlobalMethods.main.txtMANPassword.Password.ToString(), user.SaltOfPw);
                context.Users.Update(user);
                context.SaveChanges();

                MessageBox.Show(Messages.passwordResetSuscess);

            }            
        }

        // ENG: Deletes the user account
        // TUR: Kullanıcı hesabını siler
        public static void deleteAccount(Dispatcher dispatcher)
        {
            using (LMSContext context = new LMSContext())
            {
                var user = LoginOperations.loggedUser;              
                MessageBoxResult result = MessageBox.Show(Messages.accountDelete,Messages.deleteObject,MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    VerifyEmail.deleteAccountMail(Dispatcher.CurrentDispatcher);
                    context.Users.Remove(user);
                    context.SaveChanges();
                    GlobalMethods.main.tabControl.SelectedIndex = 1;
                }
                              
            }

        }

       


    }
}
