using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ULMSWinFormsApp.Models;
using ULMSWinFormsApp;

namespace ULMSWinFormsApp.Forms
{
    public partial class FrmCourseEnrollment : Form
    {
        public FrmCourseEnrollment()
        {
            InitializeComponent();
        }
        //Corrected code: Added validation to ensure that all fields are filled, that Student ID is numeric and that Student Name does not contain numbers before processing the enrollment.
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            // Validate empty fields
            if (string.IsNullOrWhiteSpace(txtEnrollStudentId.Text) ||
                string.IsNullOrWhiteSpace(txtEnrollStudentName.Text) ||
                string.IsNullOrWhiteSpace(cmbCourse.Text) ||
                string.IsNullOrWhiteSpace(cmbSemester.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            // Validate Student ID (numbers only)
            if (!int.TryParse(txtEnrollStudentId.Text, out _))
            {
                MessageBox.Show("Student ID must contain numbers only.");
                return;
            }

            // Validate Student Name (no numbers)
            if (txtEnrollStudentName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Student name cannot contain numbers.");
                return;
            }
            // Check for duplicate enrollment (basic check based on displayed output)
            if (txtEnrollmentOutput.Text.Contains(cmbCourse.Text))
            {
                MessageBox.Show("Student is already enrolled in this course.");
                return;
            }
            // Created enrollment object
            Enrollment enrollment = new Enrollment
            {
                StudentId = txtEnrollStudentId.Text,
                StudentName = txtEnrollStudentName.Text,
                CourseName = cmbCourse.Text,
                Semester = cmbSemester.Text
            };

            SharedData.CourseName = enrollment.CourseName;
            SharedData.Semester = enrollment.Semester;
            // Display enrollment details
            txtEnrollmentOutput.Text =
                "Enrollment completed successfully!" + Environment.NewLine +
                "Student ID: " + enrollment.StudentId + Environment.NewLine +
                "Student Name: " + enrollment.StudentName + Environment.NewLine +
                "Course: " + enrollment.CourseName + Environment.NewLine +
                "Semester: " + enrollment.Semester;
        }
        //btnclear
        private void btnClearEnrollment_Click(object sender, EventArgs e)
        {
            txtEnrollStudentId.Clear();
            txtEnrollStudentName.Clear();
            cmbCourse.SelectedIndex = -1;
            cmbSemester.SelectedIndex = -1;
            txtEnrollmentOutput.Clear();
            txtEnrollStudentId.Focus();
        }

        private void btnBackEnrollment_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEnrollStudentId_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
