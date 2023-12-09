using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Laba3
{
    struct Student
    {
        public string surName;
        public string firstName;
        public string patronymic;
        public char sex;
        public string dateOfBirth;
        public char mathematicsMark;
        public char physicsMark;
        public char informaticsMark;
        public int scholarship;

        public Student(string lineWithAllData)
        {
            string[] value = Convert.ToString(lineWithAllData).Trim().Split();
            surName = value[0];
            firstName = value[1];
            patronymic = value[2];
            sex = Convert.ToChar(value[3]);
            dateOfBirth = value[4];
            mathematicsMark = Convert.ToChar(value[5]);
            physicsMark = Convert.ToChar(value[6]);
            informaticsMark = Convert.ToChar(value[7]);
            scholarship = Convert.ToInt32(value[8]);
        }
    }
}
