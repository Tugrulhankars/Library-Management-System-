using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static LibraryManagementSystem.Custom.AppInit;

namespace LibraryManagementSystem.Custom
{
    public static class SearchOperations
    {
       
        public static void searchBook(MainWindow main)
        {
            using (LMSContext _context = new LMSContext())
            {
                string srSearch = "";
                if (main.txtLibraryBookName.Text.Length>0)
                {
                    srSearch = main.txtLibraryBookName.Text;
                    
                }
                string authorSearchFN = "";
                if (main.txtLibraryAuthorFN.Text.Length>0)
                {
                    authorSearchFN= main.txtLibraryAuthorFN.Text;
                }                
                string authorSearchLN = "";
                if (main.txtLibraryAuthorLN.Text.Length>0)
                {
                    authorSearchLN= main.txtLibraryAuthorLN.Text;
                }



                var query = from book in _context.Books
                            join author in _context.Authors on book.AuthorId equals author.AuthorId
                            join category in _context.Categories on book.CategoryId equals category.CategoryId
                            where book.BookName.Contains(srSearch) &&
                                  author.FirstName.Contains(authorSearchFN) &&
                                  author.LastName.Contains(authorSearchLN)                        
                            select new
                            {
                                BookId=book.BookId,
                                BookName = book.BookName,
                                AuthorFirstName = author.FirstName,
                                AuthorLastName = author.LastName,
                                CategoryName = category.CategoryName,
                                StockAmount = book.StockAmount,
                                NumberOfPage = book.NumberOfPage,
                            };
                var selectedCategory = (Categories)GlobalMethods.main.cmbBookCategory.SelectedItem;
                if (GlobalMethods.main.cmbBookCategory.SelectedIndex>0)
                {                   
                    query = query.Where(book => book.CategoryName == selectedCategory.CategoryName);

                   
                }
                if (GlobalMethods.main.cmbSortBy.SelectedIndex == 1)
                {
                    query = query.Where(book => book.StockAmount == 0);
                }
                else if (GlobalMethods.main.cmbSortBy.SelectedIndex == 2)
                {
                    query = query.OrderBy(book => book.StockAmount);
                }
                else if (GlobalMethods.main.cmbSortBy.SelectedIndex == 3)
                {
                    query = query.OrderByDescending(book => book.StockAmount);
                }
                else if (GlobalMethods.main.cmbSortBy.SelectedIndex == 4)
                {
                    query = query.OrderBy(book => book.NumberOfPage);
                }
                else if (GlobalMethods.main.cmbSortBy.SelectedIndex == 5)
                {
                    query = query.OrderByDescending(book => book.NumberOfPage);
                }


                GlobalMethods.main.gridLibrary.ItemsSource = query.ToList();
            }
            

        }


        
        

    }
}
