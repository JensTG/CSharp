using System.Security.Cryptography;

namespace FirstClassAndMethod {
    public class Person {
        protected string _name;
        protected int _age;

        public Person(string name) {
            _name = name;
        }
        public void SetAge(int age) {
            _age = age;
        }
        public string Greet() {
            if(_age > 0) return "Hello! My name is " + _name + ". And I am " + _age.ToString() + " years old."; 
            return "Hello! My name is " + _name;
        }
        public override string ToString() {
            return _name + _age.ToString();
        }

        ~Person() {
            _name = String.Empty;
        }
    }

    public class Student : Person {
        public Student(string name) : base(name) {
            _name = name;
        }
        public void Studying() {
            Console.WriteLine("Im studying!");
        }
    }
}