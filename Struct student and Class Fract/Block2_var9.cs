// Display the names and average scores of students who have "5" in computer science.

using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Laba3
{
    public partial class Block2
    {
        static Student[] ReadData(string fileName)
        {
            int count = System.IO.File.ReadAllLines(fileName).Length;
            Student[] studs = new Student[count];
            StreamReader read = new StreamReader(fileName);
            for (int i = 0; i < studs.Length; i++)
            {
                studs[i] = new Student(read.ReadLine());
            }
            read.Close();
            return studs;
        }

        static void runMenu(Student[] studs)
        {
            for (int i = 0; i < studs.Length; i++)
            {
                if (studs[i].informaticsMark == '-')
                    studs[i].informaticsMark = '2';
                if (studs[i].mathematicsMark == '-')
                    studs[i].mathematicsMark = '2';
                if (studs[i].physicsMark == '-')
                    studs[i].physicsMark = '2';
                int informaticsMark = Convert.ToInt32(new string(studs[i].informaticsMark, 1));
                int mathematicsMark = Convert.ToInt32(new string(studs[i].mathematicsMark, 1));
                int physicsMark = Convert.ToInt32(new string(studs[i].physicsMark, 1));
                if (informaticsMark == 5)
                {
                    double gpa = Convert.ToDouble((informaticsMark + mathematicsMark + physicsMark) / 3);
                    Console.WriteLine($"{studs[i].surName} GPA: {gpa}"); // Grade Point Average
                }
            }
        }
        static public void Main2()
        {
            Student[] studs = ReadData("data.txt");
            runMenu(studs);
        }
    }
}


