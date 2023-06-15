using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VisioForge.MediaFramework.Helpers;

namespace LibraryManagementSystem.Custom
{
    public class AdminOperations
    {


        // ENG: shows user confirmations in admin panel
        // TUR: kullanıcı onaylarını gösterir admin panelinde       
        public static void confirmListUser()
        {
            using (LMSContext context = new LMSContext())
            {

                var query = from a in context.Users
                            join b in context.UserTypes on a.UserTypeId equals b.UserTypeId
                            join c in context.Ranks on a.RankId equals c.RankId
                            where a.UserTypeId==2 && a.RankId==1
                            select new
                            {
                                UserEmail=a.UserEmail,
                                UserId = a.UserId,
                                UserTypeId = b.UserTypeId,
                                UserTypeName=b.UserTypeName,
                                RankId = c.RankId,
                                RankName=c.RankName,

                            };

                GlobalMethods.main.gridUserConfirm.ItemsSource = query.ToList();

            }
        }


        // ENG: Setting Book limits
        public static void bookLimits()
        {

            using (LMSContext context = new LMSContext())
            {
                BookLimits limits = new BookLimits();

                string limit = GlobalMethods.main.txtSettingBL.Text;
                int newLimit = int.Parse(limit);
                limits.BookLimit = newLimit;
                context.BookLimits.Update(limits);
                context.SaveChanges();


            }


        }

        // ENG: Approves and changes teacher's rank in admin panel
        // TUR: Admin panelinde öğretmenin rütbesini onaylar ve değiştirir
        public static void confirmUser()
        {
            using (LMSContext context = new LMSContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserTypeId == 2 && u.RankId == 1);
                if (user != null)
                {

                    user.UserTypeId = 1;
                    context.SaveChanges();
                }
            }
        }

        // ENG: Lists the books users want to return    
        // TUR: kullanıcıların iade etmek istediği kitapları listeler
        public static void returnConfirmBook()
        {
            using (LMSContext context = new LMSContext())
            {

                var query = from a in context.Returns
                            join b in context.Books on a.BookId equals b.BookId
                            join c in context.Users on a.UserId equals c.UserId
                            join d in context.Categories on b.CategoryId equals d.CategoryId
                            select new
                            {

                                ReturnId = a.ReturnId,
                                BookId=b.BookId,
                                BookName = b.BookName,
                                UserFirstName = c.FirstName,
                                UserLastName = c.LastName,
                                CategoryName = d.CategoryName,
                                StockAmount=b.StockAmount,
                                AcquisitionDate = a.AcquisitionDate,
                                ReturnDate = a.ReturnDate,
                                Deadline = a.Deadline,


                            };

                GlobalMethods.main.gridUserConfirm.ItemsSource = query.ToList();


            }

        }


        // ENG: admin approves the returned book
        // TUR:admin iade edilen kitabı onaylar
        public static void returnDeleteBook()
        {
            using (LMSContext context = new LMSContext())
            {
                Records records = new Records();
                Returns returns = new Returns();
                var returnId = GlobalMethods.main.gridUserConfirm;

                if (returnId.SelectedItem != null)
                {
                    var selectedRow = returnId.ItemContainerGenerator.ContainerFromItem(returnId.SelectedItem) as DataGridRow;
                    if (selectedRow != null)
                    {
                        var dataItem = selectedRow.Item;
                        var firstColumnProperty = dataItem.GetType().GetProperty("ReturnId");
                        var stockAmountProperty = dataItem.GetType().GetProperty("StockAmount");
                        var bookIdProperty = dataItem.GetType().GetProperty("BookId");
                        int stockAmount = (int)stockAmountProperty.GetValue(dataItem);
                        int bookId = (int)bookIdProperty.GetValue(dataItem);

                        records.RecordId = (int)firstColumnProperty.GetValue(dataItem, null);
                        returns.ReturnId = (int)firstColumnProperty.GetValue(dataItem, null);
                        context.Returns.Remove(returns);
                        context.Records.Remove(records);

                        stockAmount++;

                        var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                        if (book != null)
                        {
                            book.StockAmount = stockAmount;
                        }
                        selectedRow.IsEnabled = false;
                    }
                }
                context.SaveChanges();
            }
        }

        // ENG: admin adds books to the system, the number of books increases
       // TUR: admin sisteme kitap ekler kitap sayısı artar
        public static void addBook()
        {

            using (LMSContext context = new LMSContext())
            {

                Books books = new Books();

                //Check Stock Amount
                var nameBook = GlobalMethods.main.txtAdmBookName.Text;
                var bookName = context.Books.FirstOrDefault(tr => tr.BookName == nameBook);
                if (bookName != null)
                {


                    bookName.StockAmount++;
                    context.SaveChanges();
                }

                //new book stockAmount
                string stockAmount = GlobalMethods.main.txtAdmStockAmount.Text;
                int stock = int.Parse(stockAmount);
                books.StockAmount = stock;





                //new category save
                var categoryName = GlobalMethods.main.txtAdmCategoryName.Text;
                var existingCategory = context.Categories.FirstOrDefault(c => c.CategoryName == categoryName);
                if (existingCategory != null)
                {
                    books.CategoryId = existingCategory.CategoryId;

                }

                // author name save
                var firstName = GlobalMethods.main.txtAdmAuthorFN.Text;
                var lastName = GlobalMethods.main.txtAdmAuthorLN.Text;
                var existingAuthor = context.Authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
                if (existingAuthor != null)
                {
                    books.AuthorId = existingAuthor.AuthorId;
                }
                else if (existingAuthor == null)
                {
                    Authors authors = new Authors();
                    authors.FirstName = GlobalMethods.main.txtAdmAuthorFN.Text;
                    authors.LastName = GlobalMethods.main.txtAdmAuthorLN.Text;

                    books.Author = authors;
                }


                // Take Number of page
                string numberOfPage = GlobalMethods.main.txtAdmNumberOfPage.Text;
                int numberOfP = int.Parse(numberOfPage);
                books.NumberOfPage = numberOfP;
                books.BookName = nameBook;



                // Take production year and convert type date
                string productionyear = GlobalMethods.main.txtAdmProductionYear.Text;
                DateTime date;
                if (DateTime.TryParse(productionyear, out date))
                {
                    books.ProductionYear = date;
                }

                context.Books.Add(books);
                context.SaveChanges();



            }

        }
        //admin kayıtlı kullanıcıları listeler
        public static void listUserAdmin()
        {

            using (LMSContext context = new LMSContext())
            {

                var query = from b in context.Users
                            join a in context.UserTypes on b.UserTypeId equals a.UserTypeId
                            select new
                            {
                                UserEmail = b.UserEmail,
                                FirstName = b.FirstName,
                                LastName = b.LastName,
                                UserTypeName = a.UserTypeName,


                            };

                // ENG: If the index of the selected item is greater than 0 in the ComboBox, it returns the data related to the selected item
                // TUR: ComboBox'da seçilen öğenin imdex'i 0'dan büyükse seçilen öğe ile ilgili verileri getirir
                if (GlobalMethods.main.cmbAdminEmailType.SelectedIndex > 0)
                {
                    var selectedUserType = GlobalMethods.main.cmbAdminEmailType.SelectedItem as UserTypes;
                    if (selectedUserType != null)
                    {
                        var query2 = query.Where(book => book.UserTypeName == selectedUserType.UserTypeName);
                        GlobalMethods.main.gridAdminUser.ItemsSource = query2.ToList();
                    }
                }

                if (GlobalMethods.main.cmbAdminEmailType.SelectedIndex == 0)
                {
                    GlobalMethods.main.gridAdminUser.ItemsSource = query.ToList();
                }
            }

        }

        // ENG: Shows records of books purchased by users
        // TUR: kullanıcıların aldığı kitapların kayıtlarını gösterir
        public static void listBookRecord()
        {
            using (LMSContext context = new LMSContext())
            {
                var query = from a in context.Records
                            join b in context.Users on a.UserId equals b.UserId
                            join c in context.Books on a.BookId equals c.BookId
                            join d in context.UserTypes on b.UserTypeId equals d.UserTypeId
                            select new
                            {
                                UserEmail = b.UserEmail,
                                UserTypeName = d.UserTypeName,
                                BookName = c.BookName,
                                AcquisitionDate = a.AcquisitionDate,
                                ReturnDate = a.ReturnDate,
                                Deadline = a.Deadline > DateTimeHelper.ServerTime ? (a.Deadline - DateTimeHelper.ServerTime).ToString() : "0"



                            };

                // ENG: If the index of the selected item is greater than 0 in the ComboBox, it returns the data related to the selected item
                // TUR: ComboBox'da seçilen öğenin imdex'i 0'dan büyükse seçilen öğe ile ilgili verileri getirir
                if (GlobalMethods.main.cmbAdminEmailType.SelectedIndex > 0)
                {
                    var selectedUserType = GlobalMethods.main.cmbAdminEmailType.SelectedItem as UserTypes;
                    if (selectedUserType != null)
                    {
                        var query2 = query.Where(book => book.UserTypeName == selectedUserType.UserTypeName);
                        GlobalMethods.main.gridAdminUser.ItemsSource = query2.ToList();
                    }
                }

                if (GlobalMethods.main.cmbAdminEmailType.SelectedIndex == 0)
                {
                    GlobalMethods.main.gridAdminUser.ItemsSource = query.ToList();
                }

            }
        }


        // ENG: Adding a new admin to the system
        // TUR: sisteme yeni admin ekleme
        public static void addAdmin()
        {
            using (LMSContext context = new LMSContext())
            {
                Admins admin = new Admins();
                admin.FirstName = GlobalMethods.main.txtAdminFirstName.Text;
                admin.LastName = GlobalMethods.main.txtAdminLastName.Text;
                var adminEmail = context.Admins.FirstOrDefault(b => b.Email == GlobalMethods.main.txtAdminEmail.Text.ToString());
                if (adminEmail != null)
                {
                    MessageBox.Show(Messages.existMail);
                    return;
                }
                admin.Email = GlobalMethods.main.txtAdminEmail.Text;
                if (GlobalMethods.main.txtAdminPassword.Password != GlobalMethods.main.txtAdminVerifyPassword.Password)
                {
                    MessageBox.Show(Messages.registerPassword);
                    return;
                }
                if (GlobalMethods.main.txtAdminPassword.Password.Length<8)
                {
                    MessageBox.Show(Messages.passwordCharacters);
                    return;
                }
                Guid guid = Guid.NewGuid();
                admin.SaltOfPw = guid.ToString();
                admin.Password = GlobalMethods.returnUserPassword(GlobalMethods.main.txtAdminPassword.Password.ToString(), admin.SaltOfPw);
                admin.RegisterDate = DateTimeHelper.ServerTime;
                context.Admins.Add(admin);
                context.SaveChanges();

            }
        }

        // ENG: sorting registered admins
        // TUR: kayıtlı adminleri sıralama
        public static void adminList()
        {
            using (LMSContext context = new LMSContext())
            {

                var query = from a in context.Admins
                            select new
                            {
                                AdminId = a.AdminId,
                                AdminNameFirstName = a.FirstName,
                                AdminNameLastName = a.LastName,
                                AdminEmail = a.Email,
                                AdminRegisterDate = a.RegisterDate,
                            };

                GlobalMethods.main.gridAdminList.ItemsSource = query.ToList();

            }
        }

        // ENG: deletes a registered admin
        // TUR: kayıtlı bir admini siler
        public static void adminDelete()
        {
            using (LMSContext context = new LMSContext())
            {
                Admins admins = new Admins();

                var adminId = GlobalMethods.main.gridAdminList;

                if (adminId.SelectedItem != null)
                {
                    var selectedRow = adminId.ItemContainerGenerator.ContainerFromItem(adminId.SelectedItem) as DataGridRow;
                    if (selectedRow != null)
                    {
                        var dataItem = selectedRow.Item;
                        var firstColumnProperty = dataItem.GetType().GetProperty("AdminId");
                        //var firstCellValue = firstColumnProperty.GetValue(dataItem, null);
                        admins.AdminId = (int)firstColumnProperty.GetValue(dataItem, null);
                        context.Admins.Remove(admins);

                    }
                }
                context.SaveChanges();
            }
        }



        // ENG: Lists the books in the library in the admin panel
        // TUR: Admin panelinde kütüphanedeki kitapları listeler
        public static void adminListLibraryBook()
        {
            using (LMSContext context = new LMSContext())
            {
                var query = from b in context.Books
                            join a in context.Authors on b.AuthorId equals a.AuthorId
                            join c in context.Categories on b.CategoryId equals c.CategoryId

                            select new
                            {
                                BookId = b.BookId,
                                BookName = b.BookName,
                                AuthorFirstName = a.FirstName,
                                AuthorLastName = a.LastName,
                                CategoryName = c.CategoryName,
                                NumberOfPage = b.NumberOfPage,
                                StockAmount = b.StockAmount,


                            };


                GlobalMethods.main.gridAdminLibrary.ItemsSource = query.ToList();
                GlobalMethods.main.gridAdminLibrary.Items.Refresh();
            }

        }

        // ENG: Keeps the return period of the book purchased for students
        // TUR: Öğrenciler için alınan kitabın iade süresini tutar
        public static void adminBookDeadline()
        {

            using (LMSContext context = new LMSContext())
            {
                Dates dates = new Dates();

                string deadline = GlobalMethods.main.txtAdminDeadLine.Text;
                int deadline2=int.Parse(deadline);
                dates.BookDeadline=deadline2;
                context.Dates.Update(dates);
                context.SaveChanges();

               

            }

        }

        // ENG: Shows expired books in admin panel
        // TUR: İade süresi geçmiş kitapları admin panelinde gösterir
        public static void pastDelivery()
        {
            using (LMSContext context = new LMSContext())
            {
                var query = from a in context.Records
                            join b in context.Users on a.UserId equals b.UserId
                            join c in context.Books on a.BookId equals c.BookId
                            join d in context.UserTypes on b.UserTypeId equals d.UserTypeId
                            where a.Deadline<=DateTimeHelper.ServerTime
                            select new
                            {
                                UserEmail = b.UserEmail,
                                UserTypeName = d.UserTypeName,
                                BookName = c.BookName,
                                AcquisitionDate = a.AcquisitionDate,
                                ReturnDate = a.ReturnDate,
                                Deadline = a.Deadline > DateTimeHelper.ServerTime ? (a.Deadline - DateTimeHelper.ServerTime).ToString() : "0"



                            };
                GlobalMethods.main.gridAdminUser.ItemsSource = query.ToList();

            }

        }
    }
}
