   M S B A M L   `   `   `  ���� R  NLibraryManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:LibraryManagementSystemLibraryManagementSystem  (    "LibraryManagementSystem.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     7local%clr-namespace:LibraryManagementSystem     -     � Title$  
MainWindow��$	��450��$	��800��.��� .+��� -   $��
tabControl�� �� SelectedIndex$ 1��.@��� -   $��tabRegister��$��Register��$��50,-5,-54,0q�$��1��$y�Hidden=�.��� ����  �� ImageSource$ Icons/1.png�� � ColumnDefinitions �� $	��31* ��� $
��210* ��� $
��156* �.+��� -    ��Name$ txtFirstName��$	��189��$	��Top=�$
��Left=�$��8,52,0,0q�$��31��$��1��
���   �.������ $ Icons/login2.png��.����  J� IsHitTestVisible$ False��$��
First Name��$	��Top=�$
��Left=�$��	10,60,0,0q�
������� J� RenderTransformOrigin$ 0.364,0.381&�$��16��$	��124��$��1������  �� 
TargetType" ��.���  �� Property � y�	 �� Value$	 	Collapsed=�
 �� Triggers
 ��  �� Binding �� *Text+ �� ElementName$ txtFirstName�� �� Value  .a���  � y�$	 Visible=��� -   $ txtLastName��$	��189��$	��Top=�$
��Left=�$��8,88,0,0q�$��31��$��1��
���   �.������ $ Icons/login2.png��.���� -   $ txtEmail��$	��189��$	��Top=�$
��Left=�$��	8,124,0,0q�$��31��$��1��
���   �.������ $ Icons/login2.png��.���� -   $��cmbRank��$
��Left=�$��
15,253,0,0q�$	��Top=�$	��145��$��1��$��22���� -   $��btnRegsiter��$��Sign Up��$
��Left=�$��
15,280,0,0q�$	��Top=�$��57��$��30��$��1��$��14(�
���   �����  �� 
TargetType" ��.R��� #��z��#��z��#��z�� �� CornerRadius$ 5��._��� $��Center=�$��Center=��� $��	Password:��$
��Left=�$��	2,173,0,0q�$	��Top=�$��1��$��26��$��62��G� -	    G�Name$ txtRegisterPw��$
��Left=�$��
64,173,0,0q�$	��Top=�$��87��$��26��$��1��
���   ����� $ Icons/login2.png���� $
��Left=�$��	2,197,0,0q�$	��Top=�$��39��$��70��$��1������  �� TextWrapping$
 Wrap=�$��Verify Password:��$��57��$��40��G� -
   $ txtRegisterVerifyPw��$
��Left=�$��
64,211,0,0q�$	��Top=�$��87��$��25��$��1��$ 0.471,0.643&�
���   ����� $ Icons/login2.png���� $ False��$��	Last Name��$	��Top=�$
��Left=�$��	10,96,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��1������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtLastName��  .a���  � y�$	 Visible=��� $ False��$��Email��$	��Top=�$
��Left=�$��
10,132,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��1������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtEmail��  .a���  � y�$	 Visible=��� -    ��Name$ btnTabRegisterBack��$��Center=�$��0,10,0,0q�$	��Top=�$��42��$��33������ $! Icons/arrow-left-circle.png���� -   $��tabLogin��$��Login��$��-57,-2,46,0q�$��0��$y�Hidden=�.��� ���� $ Icons/lo.png�� �� $��0* ��� $	��87* ��� $
��485* ��� $
��222* �.+��� -   $ txtLoginEmail��$��210,128,0,0q�$��2��$��30��$	��Top=�$
��Left=�$	��190��
���   �.������ $ Icons/Adsız tasarım.png��.���� $ False��$��Email��$	��Top=�$
��Left=�$��225,135,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��2������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtLoginEmail��  .a���  � y�$	 Visible=�G� -   $ passwordBoxLogin��$	��190��$	��Top=�$
��Left=�$��210,160,0,0q�$��30��$��2��
���   ����� $ Icons/Adsız tasarım.png���� -    ��Name$ MyTextBlock��$ False��$��Password��$	��Top=�$
��Left=�$��225,166,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��2������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Password.Length+$ passwordBoxLogin�� 0.a���  � y�$	 Visible=��� -   $��btnLogin��$��Log In��$
��Left=�$��210,220,0,0q�$	��Top=�$��60��$��2��
���   ����� $ Icons/Adsız tasarım.png������ " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� -   $ btnForgetPassword��$��Forgot Your Password?��$
��Left=�$��215,195,0,0q�$	��Top=�$	��190�����	#FFDDDDDD$��2������ " ��.R��� �� $"��https://sifremi-unuttum.com/?�.�I forgot my password�� -   $��btnLoginSignUp��$��Sign Up��$
��Left=�$��340,220,0,0q�$	��Top=�$��60��$��2��
���   ����� $ Icons/Adsız tasarım.png������ " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� $��2��$
��Left=�$��169,130,0,0q�$	��Top=�$ 0.395,0.579&�$��26��$��36������ $ Icons/account.png���� $��2��$
��Left=�$��167,166,0,0q�$	��Top=�$��24��$��38������ $ Icons/lock.png���� $��2��$&�� Welcome To Metropolition Library��$
��Left=�$��
174,23,0,0q�$	��Top=�$��16(�$��Segoe UI Black)��� -   $��tabForgetPassword��$��ForgetPw��$��
14,-5,-9,0q�$��2��$y�Hidden=�.��� ���� $ Icons/3.png�� �� $
��137* ��� $
��657* �.+��� -   $��txtForgetPwEmail��$
��Left=�$��180,130,0,0q� �� TextWrapping$
 Wrap=�$�� ��$	��Top=�$	��134��$��19��$��1���� $ False��$��Email��$	��Top=�$
��Left=�$��190,130,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��1������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtForgetPwEmail��  .a���  � y�$	 Visible=��� -   $��txtForgetPwFN��$
��Left=�$��180,152,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��134��$��19��$��1���� $ False��$��
First name��$	��Top=�$
��Left=�$��190,154,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��1������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtForgetPwFN��  .a���  � y�$	 Visible=��� -   $��txtForgetPwLN��$
��Left=�$��180,176,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��134��$��19��$��1���� $ False��$��	Last name��$	��Top=�$
��Left=�$��190,177,0,0q�
�������$ 0.364,0.381&�$��16��$	��124��$��1������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtForgetPwLN��  .a���  � y�$	 Visible=��� -   $��btnForgetPwCancel��$��Cancel��$
��Left=�$��180,210,0,0q�$	��Top=�$��1��$��45��
���   ����� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� -   $��btnForgetPwContinue��$��Continue��$
��Left=�$��260,210,0,0q�$	��Top=�$��54��$��1��
���   ����� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� -   $��tabHomePage��$��HomePage��$��77,-4,-73,2q�$��4��$y�Hidden=�.���  � RowDefinitions �� $	��89* ��� $
��101* ����� $ Icons/Adsız tasarım.png�� �� $
��287* ��� $
��450* ��� $	��57* �.+��� $
��Left=�$��	25,80,0,0q�$	��Top=�$��43��$��16(�$��38��$ 0.535,0.922&����� $ Icons/menu.png���� -   $ btnHPLibrary��$�� ��$
��Left=�$��
24,123,0,0q�$	��Top=�$��44��$��30��$ 0.5,0.5&����� $ Icons/library.png���� -   $ 
btnMyBooks��$�� ��$
��Left=�$��
24,158,0,0q�$	��Top=�$��44��$��30��$ 1.366,-0.73&�$��2������ $ Icons/book-edit.png���� -   $ btnNotifications��$�� ��$
��Left=�$��	24,16,0,0q�$	��Top=�$��44��$��30��$ 	0.5,0.601&�$��1������ $ Icons/bell.png���� -   $ 	btnLogout��$
��Left=�$��
425,23,0,0q�$	��Top=�$��35��$��1��$��38��$��2������ $ Icons/logout.png���� -   $��lblHomePage��$��isim soyisim/rütbe��$
��Left=�$��
253,23,0,0q�$	��Top=�$	��167��$��33��$��1���� -   $ btnMyAccount��$�� ��$
��Left=�$��	24,51,0,0q�$	��Top=�$��44��$��30��$ 	0.5,0.101&�$��1������ $ Icons/account-box.png��&   System.Windows.Controls.DataGrid  -    $��
gridMyBook��$��159,82,16,82q�$��2��$��2��   Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Return��   CellTemplate �� .R��� -!   $��Return���� -"   $��btnHomePageInfo��$
��Left=�$��24,0,0,0q�$��Center=�$��30��$��44��$��1������ $ Icons/information.png���� $��Library��$
��Left=�$��
68,127,0,0q�$	��Top=�$��Segoe UI Black)��� $��My Books��$
��Left=�$��
68,160,0,0q�$	��Top=�$��24��$��2��$��Segoe UI Black)��� $��Notifacitions��$
��Left=�$��	67,20,0,0q�$��1��$	��Top=�$��Segoe UI Black)��� $��
My Account��$
��Left=�$��	67,55,0,0q�$��1��$	��Top=�$��Segoe UI Black)��� $��About Us��$
��Left=�$��68,0,0,0q�$��Center=�$��Segoe UI Black)�$��1���� -#   $��
tabLibrary��$��Library��$��79,-7,-79,2q�$��5��$y�Hidden=�.��� ���� $ Icons/Adsız tasarım.png��.+�  -$   $��gridLibrary��$��149,77,10,43q��� $��
Book Name:��$
��Left=�$��
168,20,0,0q�$	��Top=��� -%   $��txtLibraryBookName��$
��Left=�$��
247,24,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -&   $��txtLibraryAuthorFN��$
��Left=�$��
417,24,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -'   $��cmbBookCategory��$
��Left=�$��
247,47,0,0q�$	��Top=�$	��120���� -(   $��	cmbSortBy��$
��Left=�$��
554,22,0,0q�$	��Top=�$	��136���� -)   $��btnAddMyLibrary��$
��Left=�$��
10,178,0,0q�$	��Top=�$��40��$��44������ $ Icons/login2.png������ $ Icons/book-plus.png���� -*   $��btnListBooks��$
��Left=�$��
10,126,0,0q�$	��Top=�$��44��$��47������ $ Icons/login2.png������ $ Icons/list-box.png���� -+   $ txtLibraryAuthorLN��$
��Left=�$��
417,51,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $ False��$��Author First Name��$	��Top=�$
��Left=�$��
430,26,0,0q�
�������$ 0.364,0.381&�$��16��$	��124������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtLibraryAuthorFN��  .a���  � y�$	 Visible=��� $ False��$��Author Last Name��$	��Top=�$
��Left=�$��
430,53,0,0q�
�������$ 0.364,0.381&�$��16��$	��124������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtLibraryAuthorLN��  .a���  � y�$	 Visible=��� -,   $ btnLibraryBookSearch��$
��Left=�$��	10,88,0,0q�$	��Top=�$��44��$��33������ $ Icons/login2.png������ $ Icons/book-search.png���� --   $ btnTabLibraryBackHome��$�� ��$
��Left=�$��	10,22,0,0q�$	��Top=�$��44��$��31������ $ Icons/login2.png������ $ Icons/home.png���� -.   $��btnLibraryClear��$
��Left=�$��
707,22,0,0q�$	��Top=�$��40��$��36������ $ Icons/login2.png������ $ Icons/delete-empty.png���� $��Search��$
��Left=�$��	47,95,0,0q�$	��Top=�$��Segoe UI Black)��� $��
List Books��$
��Left=�$��
47,137,0,0q�$	��Top=�$ 0.526,0.579&�$��Segoe UI Black)��� $��Add My Library��$
��Left=�$��
47,185,0,0q�$	��Top=�$��Segoe UI Black)��� $��Clear Filters��$
��Left=�$��
691,51,0,0q�$	��Top=�$��Segoe UI Black)��� -/   $��tabNewPassword��$��NewPw��$��-107,-4,113,2q�$��3��$y�Hidden=�.��� ���� $ Icons/mail.png��.+��� -0   $��txtNewPwCode��$
��Left=�$��327,105,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� -1   $��lblNewPwText��$/��)Enter the Code Sent to Your Email Address��$��Center=�$��0,70,0,0q�$	��Top=�$��26��$	��282���� -2   $��btnNewPwCancel��$��Cancel��$
��Left=�$��327,186,0,0q�$	��Top=�$��22��$��45��
���   ����� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� -3   $��btnNewPwApprove��$��Approve��$
��Left=�$��392,186,0,0q�$	��Top=�
���   ����� " ��.R��� #��z��#��z��#��z��$ 5��$��22��$��55��._��� $��Center=�$��Center=�G� -4   $ txtNewPwPassword��$
��Left=�$��327,127,0,0q�$	��Top=�$	��120��G� -5   $ txtNewPwVerifyPassword��$
��Left=�$��327,150,0,0q�$	��Top=�$	��120���� $��New Password:��$
��Left=�$��238,123,0,0q�$	��Top=��� $��Verify Password:��$
��Left=�$��232,146,0,0q�$	��Top=��� $��Enter Code:��$
��Left=�$��256,101,0,0q�$	��Top=�$ 0.658,0.387&��� -6   $��tabAdmin��$��Admin��$��73,-4,-76,2q�$��7��$y�Hidden=�.��� ���� $ Icons/Adsız tasarım.png��.+�  -7   $��gridAdminLibrary��$��100,73,43,32q��� -8   $��btnAdmListBook��$��
List Books��$
��Left=�$��	10,76,0,0q�$	��Top=�$��85��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -9   $��btnAdmAddBook��$��Book Setting��$
��Left=�$��
10,101,0,0q�$	��Top=�$��85��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -:   $��btnAdmConfirm��$��Confirms��$
��Left=�$��
10,151,0,0q�$	��Top=�$��85��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -;   $ btnAdmAdminSetting��$��Admin Setting��$
��Left=�$��
10,126,0,0q�$	��Top=�$ 0.379,0.503&�$��85��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -<   $��btnAdminLogout��$
��Left=�$��
711,15,0,0q�$	��Top=�$��38��$��40������ $ Icons/logout.png���� -=   $��lblAdminName��$��Label��$
��Left=�$��
647,15,0,0q�$	��Top=��� ->   $ btnAdminSendNotifacition��$��Notifacitions��$
��Left=�$��
10,176,0,0q�$	��Top=�$��85��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -?   $��
tabConfirm��$��Confirms��$��
76,0,-74,0q�$��22��$��Center=�$y�Hidden=�.��� $	��390������ $ Icons/Adsız tasarım.png��.+�  -@   $��gridUserConfirm��$��121,68,87,37q�   $ Confirmations�� �� .R��� -A   $��Approve��$��84��$��25���� -B   $��btnUserConfirmList��$��User Approvals��$
��Left=�$��	10,68,0,0q�$	��Top=�$	��102��
���   ��� -C   $ btnReturnConfirm��$��Return Approvals��$
��Left=�$��	10,93,0,0q�$	��Top=�$	��102��
���   ��� -D   $��btnAdminConfirmsBack��$
��Left=�$��0,10,0,0q�$	��Top=�$��33��$��42������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -E   $��tabAdminAddBook��$��Book Set��$��102,-4,-102,2q�$��9��$y�Hidden=�.��� ���� $ Icons/6.png�� �� �� $��0* �.+��� -F   $��txtAdmBookName��$
��Left=�$��
132,89,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��18���� $��
Book Name:��$
��Left=�$��	37,85,0,0q�$	��Top=�$ 0.395,0.388&�$��75��$��26���� -G   $��txtAdmCategoryName��$
��Left=�$��132,229,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��18���� $��Category Name:��$
��Left=�$��
13,220,0,0q�$	��Top=�$ 0.263,0.196&�$	��102��$��26���� -H   $��txtAdmAuthorFN��$
��Left=�$��132,123,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��18���� $��Author First Name:��$
��Left=�$��	0,118,0,0q�$	��Top=�$��26��$	��110���� -I   $��txtAdmAuthorLN��$
��Left=�$��132,265,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��18��$ 0.333,0.724&��� $��Author Last Name:��$
��Left=�$��	2,260,0,0q�$	��Top=�$��25��$	��110���� -J   $��txtAdmNumberOfPage��$
��Left=�$��132,157,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $��Number Of Page:��$
��Left=�$��
11,153,0,0q�$	��Top=�$	��108���� -K   $��	btnAdmAdd��$��Add Book��$
��Left=�$��144,330,0,0q�$	��Top=�$��96��$��30������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -L   $��txtAdmStockAmount��$
��Left=�$��132,298,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $��Stock Amount:��$
��Left=�$��
23,290,0,0q�$	��Top=�$��92���� -M   $ txtAdmProductionYear��$
��Left=�$��132,191,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120���� $��Production Year:��$
��Left=�$��
15,187,0,0q�$	��Top=�$	��100���� $&�� Adding a new book to the library��$
��Left=�$��	23,36,0,0q�$	��Top=�$	��260��$��16(��� -N   $ txtSettingBL��$
��Left=�$��
384,89,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��22���� $��Book Limits :��$
��Left=�$��
302,87,0,0q�$	��Top=��� -O   $ btnSettingUpdate��$��Update��$
��Left=�$��397,124,0,0q�$	��Top=�$ 0.584,-0.246&�$��80��$��30������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� $��Book Limits Setting��$
��Left=�$��
358,36,0,0q�$	��Top=�$��16(��� -P   $��btnAdminBookSetBack��$
��Left=�$��0,10,0,0q�$	��Top=�$��33��$��42������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -Q   $��txtAdminDeadLine��$
��Left=�$��387,208,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��23���� $��Book Deadline :��$
��Left=�$��290,207,0,0q�$	��Top=��� -R   $��btnAdminDeadLine��$��Update��$
��Left=�$��397,253,0,0q�$	��Top=�$��32��$��80������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -S   $��tabAdminSendEmail��$��SendE��$��108,0,-108,0q�$��20��$	��Top=�$��10��$y�Hidden=�.��� ���� $ Icons/Adsız tasarım.png��.+�  -T   $��gridAdminUser��$��407,61,17,61q��� -U   $ txtAdminSendEmail��$
��Left=�$��
47,161,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��310��$	��108���� $ False��$#��Write the content of the mail��$	��Top=�$
��Left=�$��
57,161,0,0q�
�������$ 0.364,0.381&�$��16��$	��178������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtAdminSendEmail��  .a���  � y�$	 Visible=��� -V   $��btnSendEmail��$
��Send��$
��Left=�$��302,301,0,0q�$	��Top=�$��45��
���   ��� -W   $��btnAdminListUser��$��	List User��$
��Left=�$��684,326,0,0q�$	��Top=��� -X   $ txtAdminSendEmailObj��$
��Left=�$��	47,90,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��310���� $ False��$"��Write the Object of the mail��$	��Top=�$
��Left=�$��	57,92,0,0q�
�������$ 0.364,0.381&�$��16��$	��178������ " ��.���  � y�$	 	Collapsed=�
 ��  �� *Text+$ txtAdminSendEmailObj��  .a���  � y�$	 Visible=��� -Y   $ btnAdminListRecords��$��List Records��$
��Left=�$��612,326,0,0q�$	��Top=��� -Z   $��cmbAdminEmailType��$
��Left=�$��
627,34,0,0q�$	��Top=�$	��150���� -[   $ btnSendEmailBack��$
��Left=�$��0,10,0,0q�$	��Top=�$��33��$��42������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -\   $ btnPastDelivery��$��Past Delivery��$
��Left=�$��536,326,0,0q�$	��Top=��� -]   $��tabMyAccount��$
��MyAc��$��-182,-5,183,3q�$��6��$y�Hidden=�.��� ���� $ Icons/5.png��.+��� -^   $��lblMyAccountFN��$��First Name:��$
��Left=�$��	52,60,0,0q�$	��Top=�$��70���� -_   $��lblMyAccountUserFN��$��label��$
��Left=�$��
154,60,0,0q�$	��Top=�$��64��$ 0.635,0.502&��� $��
Last Name:��$
��Left=�$��
52,104,0,0q�$	��Top=�$��80���� -`   $��lblMyAccountUserLN��$��Label��$
��Left=�$��154,104,0,0q�$	��Top=�$��63���� $��E-mail:��$
��Left=�$��
52,143,0,0q�$	��Top=�$��70���� -a   $��lblMyAccountUserEmail��$��Label��$
��Left=�$��154,143,0,0q�$	��Top=�$	��208���� $��Register Date:��$
��Left=�$��
52,181,0,0q�$	��Top=�$��90���� -b   $��lblMyAccountUserRD��$��Label��$
��Left=�$��154,181,0,0q�$	��Top=��� $��Rank:��$
��Left=�$��
52,220,0,0q�$	��Top=�$��70���� -c   $��lblMyAccountRank��$��Label��$
��Left=�$��154,220,0,0q�$	��Top=��� $��User Informations��$
��Left=�$��	56,16,0,0q�$	��Top=�$��16(��� $��	Password:��$
��Left=�$��
52,260,0,0q�$	��Top=��� $��********��$
��Left=�$��154,260,0,0q�$	��Top=��� $��New Password:��$
��Left=�$��
469,99,0,0q�$	��Top=�$ 0.132,0.387&�$��93���� $��Verify New Password:��$
��Left=�$��469,143,0,0q�$	��Top=�G� -d   $ txtMANPassword��$
��Left=�$��597,103,0,0q�$	��Top=�$	��120��G� -e   $ txtMAVNPassword��$
��Left=�$��597,147,0,0q�$	��Top=�$	��120���� -f   $ btnMAChangePw��$��Change Password��$
��Left=�$��608,192,0,0q�$	��Top=����� " ��.R��� #��z��#��z��#��z��$ 5��$��99��._��� $��Center=�$��Center=��� -g   $ btnDeleteAccount��$
��Left=�$��
732,23,0,0q�$	��Top=�$��38��$��40������ $ Icons/account-off.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -h   $��btnMyAccountBack��$
��Left=�$��0,10,0,0q�$	��Top=�$ 0.379,0.253&�$��42��$��33������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -i   $��tabAdminAddAndList��$��	Admin Set��$��0,-5,-108,3q�$��Right=�$��71��$��11��$y�Hidden=�.��� ���� $ Icons/Adsız tasarım.png��.+��� $��First Name:��$
��Left=�$��	42,62,0,0q�$	��Top=��� -j   $ txtAdminFirstName��$
��Left=�$��
117,66,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��22��$ 0.542,0.047&��� $��
Last Name:��$
��Left=�$��
43,104,0,0q�$	��Top=��� -k   $ txtAdminLastName��$
��Left=�$��117,108,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��22���� $��Email:��$
��Left=�$��
71,150,0,0q�$	��Top=��� -l   $ txtAdminEmail��$
��Left=�$��117,152,0,0q�$
 Wrap=�$�� ��$	��Top=�$	��120��$��22���� $��	Password:��$
��Left=�$��
49,191,0,0q�$	��Top=��� -m   $ btnAddAdmin��$��	Add Admin��$
��Left=�$��144,274,0,0q�$	��Top=�$��24��$��66��
���   ����� " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� $��Add a new Admin��$
��Left=�$��
101,26,0,0q�$	��Top=�$��16(�  -n     Name$ gridAdminList��$��287,59,10,68q�G� -o   $ txtAdminPassword��$
��Left=�$��117,195,0,0q�$	��Top=�$	��120��$��22���� $��Verify Password:��$
��Left=�$��
17,232,0,0q�$	��Top=�G� -p   $ txtAdminVerifyPassword��$
��Left=�$��117,236,0,0q�$	��Top=�$	��120��$��22���� -q   $ btnAdminSettingList��$��List Admins��$
��Left=�$��
287,32,0,0q�$	��Top=�$��22��
���   ����� " ��.R��� #��z��#��z��#��z��$ 5��._��� $��Center=�$��Center=��� -r   $ btnAdminSettingDelete��$��Delete Admin��$
��Left=�$��
357,32,0,0q�$	��Top=�$��77��$��22������ " ��.R��� #��z��
���   �#��z��$ 5��._��� $��Center=�$��Center=��� -s   $ btnAdminSetBack��$
��Left=�$��0,10,0,0q�$	��Top=�$��33��$��42������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=��� -t   $��tabInfo��$��Information��$��-33,-4,29,2q�$y�Hidden=�.��� ���� $ Icons/login2.png��.+��� -u   $��lblInfo��$
��Left=�$��Center=�$	��360��$	��710��$��67,0,0,0q��� -v   $
��Left=�$��0,10,0,0q�$	��Top=�$ 0.505,0.503&�$��33��$��42������ $! Icons/arrow-left-circle.png������ " ��.R��� #��z��#��z��#��z��$ 7��._��� $��Center=�$��Center=�