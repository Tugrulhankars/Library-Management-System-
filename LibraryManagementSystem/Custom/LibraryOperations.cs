using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Media3D;
using VisioForge.Libs.Accord.Math;
using VisioForge.Libs.MediaFoundation.OPM;
using VisioForge.MediaFramework.FFMPEGEXE;
using static LibraryManagementSystem.Custom.AppInit;

namespace LibraryManagementSystem.Custom
{
   public static class LibraryOperations
    {
       public static MainWindow main;

        // ENG: Allows viewing of books in the library section
        // TUR: kütüphane kısmında kitapların görüntülenmesini sağlar
        public static void bookJoin()
        {
            using (LMSContext context = new LMSContext())
            {
                var query = from b in context.Books
                            join a in context.Authors on b.AuthorId equals a.AuthorId
                            join c in context.Categories on b.CategoryId equals c.CategoryId

                            select new
                            {
                               BookId=b.BookId,
                                BookName = b.BookName,
                                AuthorFirstName = a.FirstName,
                                AuthorLastName = a.LastName,    
                                CategoryName = c.CategoryName,
                                NumberOfPage=b.NumberOfPage,
                                StockAmount=b.StockAmount,
                                                            

                            };
                
                GlobalMethods.main.gridLibrary.ItemsSource = query.ToList();
                GlobalMethods.main.gridLibrary.Items.Refresh();
            }

        }

        // ENG: Allows the user of the system to receive the book of her/his choice.
        // TUR: Sistemi kullanan kişinin seçtiği kitabı almasını sağlar
        public static void addMyLibrary()
        {
          
            using (LMSContext context  =new LMSContext())
            {
                Records records = new Records();
               

                var limit = context.BookLimits.FirstOrDefault();

                var result = context.Records.Where(tr => tr.UserId == LoginOperations.loggedUser.UserId).Count();
                if (result>=limit.BookLimit && LoginOperations.loggedUser.UserTypeId==2)
                {
                    MessageBox.Show(Messages.myLibraryBook);
                    GlobalMethods.main.gridLibrary.IsEnabled=false;
                    return;
                }

                var deadline = context.Dates.FirstOrDefault();
                
                records.UserId=LoginOperations.loggedUser.UserId;
                records.AcquisitionDate = DateTimeHelper.ServerTime;
                records.Deadline = DateTimeHelper.ServerTime.AddMinutes(deadline.BookDeadline);
                var id = GlobalMethods.main.gridLibrary;


                if (id.SelectedItem != null)
                {
                    var selectedRow = id.ItemContainerGenerator.ContainerFromItem(id.SelectedItem) as DataGridRow;

                    if (selectedRow != null)
                    {
                        var dataItem = selectedRow.Item;
                        var bookIdProperty = dataItem.GetType().GetProperty("BookId");
                        var stockAmountProperty = dataItem.GetType().GetProperty("StockAmount");

                        int bookId = (int)bookIdProperty.GetValue(dataItem);
                        int stockAmount = (int)stockAmountProperty.GetValue(dataItem);
                        

                        records.BookId = bookId;
                       
                        context.Records.Add(records);
                        if (stockAmount > 0)
                        {
                            stockAmount--; 
                            
                            
                            var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                            if (book != null)
                            {
                                book.StockAmount = stockAmount;
                               
                            }
                        }

                    }
                }
              
                context.SaveChanges();
                
            }





        }

        public static void clearFilter()
        {

            GlobalMethods.main.txtLibraryBookName.Text = "";
            GlobalMethods.main.txtLibraryAuthorFN.Text = "";
            GlobalMethods.main.txtLibraryAuthorLN.Text = "";
            GlobalMethods.main.cmbBookCategory.SelectedIndex = 0;
            GlobalMethods.main.cmbSortBy.SelectedIndex = 0;

        }



    }
}
