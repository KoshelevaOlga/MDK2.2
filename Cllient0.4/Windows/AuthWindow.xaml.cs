﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cllient0._4.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnReg_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = ClassHelper.EF.Context.Client.ToList().
            Where(i => i.Phone == TbPhone.Text && i.Password == PbPassword.Password).
            FirstOrDefault();
            if (userAuth != null)
            {
                // переход на окно список услуг
                ServiceWindow serviceWindow = new ServiceWindow();
                serviceWindow.Show();
                this.Close();
            }
            else
            {
                // если пользователь не найден
                MessageBox.Show("Пользователя не существует", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
