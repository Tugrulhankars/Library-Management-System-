using GLib;
using LibraryManagementSystem.Custom;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VisioForge.Libs.TagLib.WavPack;
using File = System.IO.File;
using Notification = GLib.Notification;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow main;
        public bool isClick;

        public MainWindow()
        {


            InitializeComponent();
            main = this;
            GlobalMethods.main = this;
            AppInit.initApp(this);
         

        }
        private void btnRegsiter_Click(object sender, RoutedEventArgs e)
        {
            VerifyEmail.SendEmailInBackground(Dispatcher);
            RegisterOperations.completeRegister(this);


        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginOperations.loginTry(this);

        }


        private void passwordBoxLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (passwordBoxLogin.Password.Length >= 0)
            {
                MyTextBlock.Visibility = Visibility.Collapsed;
            }
            if (passwordBoxLogin.Password.Length == 0)
            {
                MyTextBlock.Visibility = Visibility.Visible;
            }
        }


        //**********************************************************************
        private void btnListBooks_Click(object sender, RoutedEventArgs e)
        {
            LibraryOperations.bookJoin();
        }



        private void btnForgetPwContinue_Click(object sender, RoutedEventArgs e)
        {

            VerifyEmail.emailNew(this, Dispatcher);
        }



        private void btnMyBooks_Click(object sender, RoutedEventArgs e)
        {
            HomePageOperations.myBook();
        }


        private void btnGrid(object sender, RoutedEventArgs e)
        {

            HomePageOperations.deleteMyBook();

            DataGridRow row = (DataGridRow)gridMyBook.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);

        }

        private void btnUserConfirmList_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.confirmListUser();
            isClick = false;
        }

        private void btnAdmAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.addBook();
        }




        private void btnRankConfirmations(object sender, RoutedEventArgs e)
        {

           

            if (isClick == true)
            {
                AdminOperations.returnDeleteBook();
            }
            else if (isClick == false)
            {

                AdminOperations.confirmUser();

            }
            DataGridRow row = (DataGridRow)gridUserConfirm.ItemContainerGenerator.ContainerFromItem(((Button)sender).DataContext);
            // Seçilen satır üzerinde işlemler yapabilirs
        }
        private void btnReturnConfirm_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.returnConfirmBook();
            isClick = true;
        }

        /************************************************************/
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AdminOperations.bookLimits();
        }

        private void btnLibraryBookSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchOperations.searchBook(this);

        }

        private void btnAdminListUser_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.listUserAdmin();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            VerifyEmail.adminNotifacition(Dispatcher);
        }

       
       

        private void btnNewPwApprove_Click(object sender, RoutedEventArgs e)
        {
            VerifyEmail.newPassword();
        }

        private void btnNotifications_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Messages.userNotifacition);
        }

        private void btnMAChangePw_Click(object sender, RoutedEventArgs e)
        {
            HomePageOperations.myAccount();
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {          
            HomePageOperations.deleteAccount(Dispatcher);
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.addAdmin();
        }

        private void btnAdminSettingList_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.adminList();
        }


        private void btnAdminSettingDelete_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.adminDelete();
        }


        private void btnAdminLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginOperations.adminLogout();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginOperations.userLogout();
        }

        private void btnAddMyLibrary_Click(object sender, RoutedEventArgs e)
        {
            LibraryOperations.addMyLibrary();
        }


        private void btnAdminListRecords_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.listBookRecord();
        }

        private void btnAdmListBook_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.adminListLibraryBook();
        }

        private void btnLibraryClear_Click(object sender, RoutedEventArgs e)
        {
            LibraryOperations.clearFilter();
            LibraryOperations.bookJoin();
        }
        private void btnPastDelivery_Click(object sender, RoutedEventArgs e)
        {
            AdminOperations.pastDelivery();
        }

        //TabControl.SelectedIndex
        private void btnMyAccountBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnAdminConfirmsBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }

        private void btnAdminBookSetBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }

        private void btnAdminSendNotifacition_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 9;
        }

        private void btnAdminSetBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }

        private void btnSendEmailBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 6;
        }


        private void btnForgetPassword_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;
        }

        private void btnAdmAdminSetting_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 11;
        }

        private void btnAdmAddBook_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 8;
        }

        private void btnAdmConfirm_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 7;
        }

        private void btnTabRegisterBack_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void btnTabLibraryBackHome_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnMyAccount_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 10;
        }

        private void btnLoginSignUp_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }



        private void btnNewPwCancel_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 2;

        }

        private void btnHPLibrary_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void btnHomePageInfo_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 12;
            main.lblInfo.Content = File.ReadAllText("C:\\Users\\karsl\\OneDrive\\Masaüstü\\C#\\LMS\\info.txt");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

       private void Main_Window(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (tabLogin.IsSelected)
                {
                    LoginOperations.loginTry(this);
                }
                if (tabRegister.IsSelected)
                {
                    RegisterOperations.completeRegister(this);
                }
                if (tabForgetPassword.IsSelected)
                {
                    VerifyEmail.emailNew(this, Dispatcher);
                }
                if (tabNewPassword.IsSelected)
                {
                    VerifyEmail.newPassword();
                }
                if (tabLibrary.IsSelected)
                {
                    SearchOperations.searchBook(this);
                }
                if (tabMyAccount.IsSelected)
                {
                    HomePageOperations.myAccount();
                }
                if (tabAdminAddBook.IsSelected)
                {
                    AdminOperations.addBook();
                }
                if (tabAdminSendEmail.IsSelected)
                {
                    VerifyEmail.adminNotifacition(Dispatcher);
                }
                if (tabAdminAddAndList.IsSelected)
                {
                    AdminOperations.addAdmin();

                }
               
            }
        }

        
    }
}

