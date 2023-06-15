using LibraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace LibraryManagementSystem.Custom
{
    public static class RegisterOperations
    {
        public static void completeRegister(MainWindow main)
        {
            using (LMSContext context = new LMSContext())
            {
                Users users = new Users();
                users.FirstName = main.txtFirstName.Text;
                users.LastName = main.txtLastName.Text;
                users.UserEmail = main.txtEmail.Text;
                if (main.txtRegisterPw.Password.Length<8 && main.txtRegisterVerifyPw.Password.Length<8)
                {
                    MessageBox.Show(Messages.passwordCharacters);
                    return;
                }
                if (main.txtRegisterPw.ToString()!=main.txtRegisterVerifyPw.ToString())
                {
                    MessageBox.Show(Messages.registerPassword);
                    return;
                }
                Guid guid = Guid.NewGuid();
                users.SaltOfPw = guid.ToString();
                users.UserPassword = GlobalMethods.returnUserPassword(main.txtRegisterPw.Password.ToString(),users.SaltOfPw);
                users.UserEmail = main.txtEmail.Text;
                if (main.cmbRank.SelectedIndex<1)
                {
                    MessageBox.Show(Messages.registerComboBox);
                    return;
                }
                users.RankId = (main.cmbRank.SelectedItem as UserTypes).UserTypeId;
                users.UserTypeId = (main.cmbRank.SelectedItem as UserTypes).UserTypeId;
                if (users.UserTypeId==1)
                {
                    users.UserTypeId = 2;
                }
                users.RegisterIp = GlobalMethods.returnUserIp();
                users.RegisterDate= DateTime.Now;

                try
                {
                    context.Users.Add(users);
                    context.SaveChanges();
                }
                catch (Exception E)
                {

                    MessageBox.Show(Messages.registerFail + E.Message.ToString()+"\n\n" + E?.InnerException?.Message);
                    return;
                }
                MessageBox.Show(Messages.registerSuccess);
                main.tabControl.SelectedIndex = 1;
               
            }


        }
        

    }
}
