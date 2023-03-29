using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp3
{
    class Program
    {
        static private List<Student> readStudentsCSV()
        {
            List<Student> students = new List<Student>();
            string first_line;

            using (var reader = new StreamReader("C:/Users/Saymed Dustga/Desktop/Notas.csv"))
            {
                first_line = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] students_data = line.Split(',');
                    Student new_student = new Student(students_data[0], students_data[1], int.Parse(students_data[2]), students_data[3], int.Parse(students_data[4]), int.Parse(students_data[5]));
                    students.Add(new_student);
                }
            }
            return students;
        }
        static private void addStudentCSV(List<Student> students, Student new_student)
        {
            string first_line = "Nombres ,Apellidos,Edad,Email,Nota 1,Nota 2";
            using (StreamWriter sw = new StreamWriter("C:/Users/Saymed Dustga/Desktop/Notas.csv"))
            {
                sw.WriteLine(first_line);
                foreach (Student student in students)
                {
                    List<int> notas = student.getNotas();
                    sw.WriteLine($"{student.getName()},{student.getLastName()},{student.getAge()},{student.getEmail()},{notas[0]},{notas[1]}");
                }
                List<int> notas_new_student = new_student.getNotas();
                sw.WriteLine($"{ new_student.getName()},{ new_student.getLastName()},{ new_student.getAge()},{ new_student.getEmail()},{ notas_new_student[0]},{ notas_new_student[1]}");
            }
        }
        static private void removeLastStudentCSV(List<Student> students)
        {
            string first_line = "Nombres ,Apellidos,Edad,Email,Nota 1,Nota 2";
            using (StreamWriter sw = new StreamWriter("C:/Users/Saymed Dustga/Desktop/Notas.csv"))
            {
                sw.WriteLine(first_line);
                for(int i =0; i < students.Count-1; i++)
                {
                    List<int> notas = students[i].getNotas();
                    sw.WriteLine($"{students[i].getName()},{students[i].getLastName()},{students[i].getAge()},{students[i].getEmail()},{notas[0]},{notas[1]}");
                }
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = readStudentsCSV();
            foreach (Student student in students)
            {
                List<int> notas = student.getNotas();
                Console.WriteLine($"{student.getName()},{student.getLastName()},{student.getAge()},{student.getEmail()},{notas[0]},{notas[1]}");
            }
            Random random = new Random();
            Student new_student = new Student("Gerardo","Rosetti",22, "gerardorosetti@gmail.com", random.Next(1, 21), random.Next(1, 21));
            addStudentCSV(students,new_student);
            students = readStudentsCSV();
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (Student student in students)
            {
                List<int> notas = student.getNotas();
                Console.WriteLine($"{student.getName()},{student.getLastName()},{student.getAge()},{student.getEmail()},{notas[0]},{notas[1]}");
            }
            removeLastStudentCSV(students);
            Console.ReadLine();
        }
    }
}
