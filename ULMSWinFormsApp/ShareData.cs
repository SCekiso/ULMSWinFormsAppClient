using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULMSWinFormsApp
{
    //added a new class to share data between forms without using a database or file storage, which is not recommended for production but serves the purpose for this testing scenario.
    public static class SharedData
    {
        // Static properties to hold shared data across forms
        public static string StudentId { get; set; }
        public static string StudentName { get; set; }
         public static string CourseName { get; set; }
        public static string Semester { get; set; }
    }
}
