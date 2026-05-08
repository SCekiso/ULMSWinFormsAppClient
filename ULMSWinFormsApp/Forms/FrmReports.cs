using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmReports : Form
    {
        public FrmReports()
        {
            InitializeComponent();
        }
        //corrected code: Added validation to ensure that a report type is selected and that the Student ID is provided and numeric before generating the report.
        //Also removed unnecessary delay to improve performance.
        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Validate report selection
            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            // Validate Student ID
            if (string.IsNullOrWhiteSpace(txtReportStudentId.Text))
            {
                MessageBox.Show("Please enter a Student ID.");
                return;
            }

            // Student ID must be numeric
            if (!int.TryParse(txtReportStudentId.Text, out _))
            {
                MessageBox.Show("Student ID must contain numbers only.");
                return;
            }

            string reportType = cmbReportType.Text;
            string studentId = txtReportStudentId.Text;

            // Removed unnecessary delay to improve performance
            // Thread.Sleep(4000);

            StringBuilder report = new StringBuilder();

            report.AppendLine("===== ULMS REPORT =====");
            report.AppendLine("Report Type: " + reportType);
            report.AppendLine("Student ID Filter: " + studentId);
            report.AppendLine("Generated On: " + DateTime.Now);
            report.AppendLine();

            // Student Summary Report
            if (reportType == "Student Summary Report")
            {
                report.AppendLine("Student ID: " + SharedData.StudentId);
                report.AppendLine("Student Name: " + SharedData.StudentName);
                report.AppendLine("Course: " + SharedData.CourseName);
                report.AppendLine("Semester: " + SharedData.Semester);
                report.AppendLine("Status: Active");
            }

            // Marks Report
            else if (reportType == "Marks Report")
            {
                int sub1 = 78;
                int sub2 = 65;
                int sub3 = 80;

                double average = (sub1 + sub2 + sub3) / 3.0;

                report.AppendLine("Subject 1: " + sub1);
                report.AppendLine("Subject 2: " + sub2);
                report.AppendLine("Subject 3: " + sub3);
                report.AppendLine("Average: " + average);
            }

            // Enrollment Report
            else if (reportType == "Enrollment Report")
            {
                report.AppendLine("Student ID: " + SharedData.StudentId);
                report.AppendLine("Student Name: " + SharedData.StudentName);
                report.AppendLine("Course: " + SharedData.CourseName);
                report.AppendLine("Semester: " + SharedData.Semester);
            }

            txtReportOutput.Text = report.ToString();
        }

        private void btnClearReport_Click(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = -1;
            txtReportStudentId.Clear();
            txtReportOutput.Clear();
            txtReportStudentId.Focus();
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
