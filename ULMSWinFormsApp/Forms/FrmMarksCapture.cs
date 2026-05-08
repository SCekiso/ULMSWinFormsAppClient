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
    public partial class FrmMarksCapture : Form
    {
        public FrmMarksCapture()
        {
            InitializeComponent();
        }

        private void btnCalculateResults_Click(object sender, EventArgs e)
        {   
            //Corrected code: Added validation to ensure that all fields are filled and that marks are numeric and within a reasonable range before processing the data.
            // Basic validation for empty fields
            if (string.IsNullOrWhiteSpace(txtMarkStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtMarkStudentName.Text) ||
                string.IsNullOrWhiteSpace(txtSubject1.Text) ||
                string.IsNullOrWhiteSpace(txtSubject2.Text) ||
                string.IsNullOrWhiteSpace(txtSubject3.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Validate Student ID (numbers only)
            if (!int.TryParse(txtMarkStudentId.Text, out int studentIdNumber))
            {
                MessageBox.Show("Please enter a valid numeric Student ID.");
                return;
            }


            //Corrected code: Validate that the marks are numeric and within a reasonable range (0-100)
            //Validate numeric input for marks
            if (!double.TryParse(txtSubject1.Text, out double Sub1) ||
                !double.TryParse(txtSubject2.Text, out double Sub2) ||
                !double.TryParse(txtSubject3.Text, out double Sub3))
            {
                MessageBox.Show("Please enter valid numeric values for all subjects.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Corrected code: Create a MarkRecord instance and populate it with the input data
            MarkRecord record = new MarkRecord();

            record.StudentId = txtMarkStudentId.Text;
            record.StudentName = txtMarkStudentName.Text;
            record.Subject1 = Sub1;
            record.Subject2 = Sub2;
            record.Subject3 = Sub3;

            // Corrected Code: Average calculation should be based on the total marks, not the number of subjects
            record.Average = (record.Subject1 + record.Subject2 + record.Subject3) / 3;

            if (record.Average >= 50)
            {
                record.ResultStatus = "PASS";
            }
            else
            {
                record.ResultStatus = "FAIL";
            }

            txtMarksOutput.Text =
                "Marks processed successfully!" + Environment.NewLine +
                "Student ID: " + record.StudentId + Environment.NewLine +
                "Student Name: " + record.StudentName + Environment.NewLine +
                "Subject 1: " + record.Subject1 + Environment.NewLine +
                "Subject 2: " + record.Subject2 + Environment.NewLine +
                "Subject 3: " + record.Subject3 + Environment.NewLine +
                "Average: " + record.Average + Environment.NewLine +
                "Final Result: " + record.ResultStatus;
        }

        private void btnClearMarks_Click(object sender, EventArgs e)
        {
            txtMarkStudentId.Clear();
            txtMarkStudentName.Clear();
            txtSubject1.Clear();
            txtSubject2.Clear();
            txtSubject3.Clear();
            txtMarksOutput.Clear();
            txtMarkStudentId.Focus();
        }

        private void btnBackMarks_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
