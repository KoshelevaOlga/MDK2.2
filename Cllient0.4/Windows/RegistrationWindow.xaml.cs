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
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.Context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Title";
            CmbGender.SelectedIndex = 0;
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLName.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFName.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbPhone.Text))
            {
                MessageBox.Show("Поле Телефон не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(PbPassword.Password))
            {
                MessageBox.Show("Поле Пароль не заполнено");
                return;
            }

            // добавление 
            DB.Client addClient = new DB.Client();
            addClient.Password = PbPassword.Password;
            addClient.Phone = TbPhone.Text;
            addClient.FirstName = TbFName.Text;
            addClient.LastName = TbLName.Text;
            if (TbPatronumic.Text != string.Empty)
            {
                addClient.Patronumic = TbPatronumic.Text;
            }
            addClient.GenderId = (CmbGender.SelectedItem as DB.Gender).ID;

            ClassHelper.EF.Context.Client.Add(addClient);

            // сохранение
            ClassHelper.EF.Context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен");
        }
        private void BtnAuth_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AuthWindow AuthWindow = new AuthWindow();
            AuthWindow.Show();
            this.Close();
        }
    }
}
