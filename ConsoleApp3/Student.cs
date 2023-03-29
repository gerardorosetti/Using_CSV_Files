using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Student
    {
        private string _name;
        private string _last_name;
        private int _age;
        private string _email;
        private List<int> _notas;
        public Student(string name, string last_name, int age, string email, int nota1, int nota2)
        {
            _name = name;
            _last_name = last_name;
            _age = age;
            _email = email;
            _notas = new List<int>();
            _notas.Add(nota1);
            _notas.Add(nota2);
        }
        public Student(string name, string last_name, int age, string email)
        {
            _name = name;
            _last_name = last_name;
            _age = age;
            _email = email;
            _notas = new List<int>();
        }
        public void addNota(int nota)
        {
            _notas.Add(nota);
        }

        public string getName()
        {
            return _name;
        }
        public string getLastName()
        {
            return _last_name;
        }
        public int getAge()
        {
            return _age;
        }
        public string getEmail()
        {
            return _email;
        }
        public List<int> getNotas()
        {
            return _notas;
        }
    }
}
