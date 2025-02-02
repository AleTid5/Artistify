﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity.User;
using Entity;
using Repository;
using System.Net.Mail;
using Common.Rules;

namespace WinApp.Views.Category
{
    public partial class Edit : UserControl
    {
        public event EventHandler GoBack;
        Entity.Category category = new Entity.Category();
        private List<Status> statuses = (new StatusRepository()).FindAll();

        public Edit()
        {
            InitializeComponent();
            this.comboStatus.DataSource = statuses;
            this.comboStatus.DisplayMember = "Name";
            this.comboStatus.ValueMember = "Code";
        }

        public void SetCategory(Entity.Category category)
        {
            this.category = category;
        }

        public void FillForm()
        {
            txtName.Text = this.category.Name;
            txtAge.Text = this.category.BlockedAge.ToString();
            comboStatus.SelectedValue = this.category.Status.Code;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.GoBack != null)
            {
                this.CleanForm();
                this.GoBack(this, EventArgs.Empty);
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                this.category.Name = NativeRules.CheckString(txtName.Text.ToString().Trim(), "Nombre inválido", 1, 25);
                this.category.BlockedAge = Convert.ToInt32(txtAge.Text.ToString().Trim());
                this.category.Status = (new StatusRepository()).FindStatusByCode(comboStatus.SelectedValue.ToString());

                (new CategoryRepository()).EditCategory(category);
                MessageBox.Show("La categoría se ha editado exitosamente!");
                this.btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CleanForm()
        {
            txtName.Text = txtAge.Text = "";
        }
    }
}
