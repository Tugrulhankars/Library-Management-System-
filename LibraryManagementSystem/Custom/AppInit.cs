using GLib;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace LibraryManagementSystem.Custom
{
    public static class AppInit
    {

        public enum enWhichSorting
        {
            [Description("Sort")]
            Sort,
            [Description("Sort By Stock Amount Zero")]
            SortByStockAmountZero,
            [Description("Sort By Stock Amount Ascending")]
            SortByStockAmountAsc,
            [Description("Sort By Stock Amount Descending")]
            SortByStockAmountDesc,
            [Description("Sort By Number Of Page Ascending")]
            SortByNumberOfPageAsc,
            [Description("Sort By Number Of Page Descending")]
            SortByNumberOfPageDesc
        }

        public class sortingOption
        {
            public enWhichSorting whichSort { get; set; }
            public string description { get; set; }
        }

        private static List<sortingOption> sortingOptionList;
        private static void initSortingOptions()
        {
            sortingOptionList = new List<sortingOption>();
            foreach (enWhichSorting sort in Enum.GetValues(typeof(enWhichSorting)))
            {
                sortingOptionList.Add(new sortingOption { whichSort = sort, description = StringValueOfEnum(sort) });
            }

        }



        //Lesson Videos
        static string StringValueOfEnum(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }






        public static void initApp(MainWindow main)
        {
            ObservableCollection<UserTypes> userRank = new ObservableCollection<UserTypes>();
            userRank.Add(new UserTypes() { UserTypeId=0, UserTypeName = Messages.userTypeName });
            using (LMSContext context =new LMSContext())
            {
                var userTypes=context.UserTypes;
                foreach (var item in userTypes)
                {
                    userRank.Add(item);
                }

            }
            main.cmbRank.ItemsSource = userRank;
            main.cmbRank.DisplayMemberPath = Messages.displayMemberPath;
            main.cmbRank.SelectedIndex = 0;

            //admin panelindeki student/teacher comboBox
            main.cmbAdminEmailType.ItemsSource = userRank;
            main.cmbAdminEmailType.DisplayMemberPath = Messages.displayMemberPath;
            main.cmbAdminEmailType.SelectedIndex = 0;


            ObservableCollection<Categories> categories = new ObservableCollection<Categories>();
            categories.Add(new Categories() { CategoryId=0,CategoryName=Messages.bookCategoryName });
            using (LMSContext context = new LMSContext())
            {
                var bookCategory = context.Categories;
                foreach (var item in bookCategory)
                {
                    categories.Add(item);
                }
            }

            main.cmbBookCategory.ItemsSource = categories;
            main.cmbBookCategory.DisplayMemberPath = Messages.categoryDisplayMP;
            main.cmbBookCategory.SelectedIndex = 0;

            initSortingOptions();
            main.cmbSortBy.ItemsSource = sortingOptionList;
            main.cmbSortBy.DisplayMemberPath = "description";
            main.cmbSortBy.SelectedIndex = 0;

            
                           
           
        }

       
      



    }
}
