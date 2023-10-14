using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var grand_father = new AdultFamilyMember() {Mother = null, Name = "Bob", Sex = Gender.Male};
            var father = new AdultFamilyMember() {Father = grand_father, Name = "Папа", Sex = Gender.Female};
            var mother = new FamilyMember() {Mother = null, Father = null, Name = "Мама", Sex = Gender.Male};
            var son = new FamilyMember() { Mother = mother, Father = father, Name = "Сын", Sex = Gender.Female};
            var son1 = new FamilyMember() { Mother = mother, Father = father, Name = "Сын2", Sex = Gender.Female};
            var son2 = new FamilyMember() { Mother = mother, Father = father, Name = "Сын3", Sex = Gender.Female};
            var son3 = new FamilyMember() { Mother = mother, Father = father, Name = "Сын4", Sex = Gender.Female};

            grand_father.Family = new FamilyMember[] { father };

            father.Family = new FamilyMember[] { mother, son, son1, son2, son3 };

            grand_father.Print(2);

            Console.ReadKey();
        }
    }
}
