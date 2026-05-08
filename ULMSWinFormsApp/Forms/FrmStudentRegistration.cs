using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmStudentRegistration : Form
    {
        public FrmStudentRegistration()
        {
            InitializeComponent();
        }

        //This is the corrected code :
        private void btnSaveStudent_Click(object sender, EventArgs e)
        {
            // Validate empty fields
            if (string.IsNullOrWhiteSpace(txtStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAge.Text) ||
                cmbProgramme.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            // Validate Student ID (numbers only)
            if (!int.TryParse(txtStudentId.Text, out int studentIdNumber))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }

            //the new code to validate age input (numbers only and within the range of 18-30)
            if (!int.TryParse(txtAge.Text, out int age) || age < 18 || age > 30)
            {
                MessageBox.Show("Please enter a valid age from (18-30).");
                return;
            }

            //the new code is to validate email format (basic check for "@" and ".")
            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            //the new code to create a student object and display the details in the output textbox
            Student student = new Student
            {
                StudentId = txtStudentId.Text,
                FullName = txtFullName.Text,
                Email = txtEmail.Text,
                Age = age,
                Programme = cmbProgramme.Text
            };

            //added code to save student data to shared data for use in other forms
            SharedData.StudentId = student.StudentId;
            SharedData.StudentName = student.FullName;

            txtStudentOutput.Text =
                "Student saved successfully!" + Environment.NewLine +
                "Student ID: " + student.StudentId + Environment.NewLine +
                "Full Name: " + student.FullName + Environment.NewLine +
                "Email: " + student.Email + Environment.NewLine +
                "Age: " + student.Age + Environment.NewLine +
                "Programme: " + student.Programme;
        }


        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtAge.Clear();
            cmbProgramme.SelectedIndex = -1;
            txtStudentOutput.Clear();
            txtStudentId.Focus();
        }

        //Add Back button to return to dashboard
        private void btnBackToDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
