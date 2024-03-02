using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Model
{
    internal class University : IFactory
    {
        private List<string> studentNames = new List<string>
        {
            "John Smith", "Emma Johnson", "Christopher Davis", "Sophia Williams",
            "Daniel Brown", "Ava Miller", "Matthew Jones", "Olivia Garcia",
            "William Taylor", "Evelyn Martin", "Andrew Anderson", "Abigail Thomas",
            "Joseph Jackson", "Grace White", "David Harris", "Chloe Martinez",
            "Benjamin Thompson", "Zoe Davis", "Christopher Lee", "Sophia Taylor",
            "James Moore", "Emma Robinson", "Logan Hernandez", "Mia Walker",
            "Ethan Hall", "Aria Martinez", "Michael Davis", "Isabella Lewis",
            "Alexander Wilson", "Amelia Clark", "Ryan Lewis", "Harper Turner",
            "Nathan Hill", "Ella Perez", "Daniel Adams", "Avery Allen",
            "Elijah Carter", "Scarlett Nelson", "Logan Stewart", "Lily Ramirez",
            "Caleb Reed", "Aubrey Cooper", "Jack Bennett", "Grace Rivera",
            "Samuel Young", "Addison Russell", "Nicholas Ward", "Sofia Scott",
            "Jackson Torres", "Victoria Phillips", "Dylan Collins", "Mila Foster",
            "Brandon Powell", "Hannah Bell", "Isaac Price", "Elena Butler",
            "Luke Foster", "Leah Turner", "Henry Henderson", "Aria Reed",
            "Wyatt Murphy", "Madison Martinez", "Gabriel King", "Avery Adams",
            "Owen Carter", "Charlotte Cooper", "Carter Scott", "Elizabeth Hill"
        };

        public IProduct CreateProduct()
        {
            throw new NotImplementedException();
        }

        public IStudent CreateStudent()
        {
            Random rnd = new Random();
            int type = rnd.Next(1, 7);
            int randomIndex = rnd.Next(studentNames.Count);
            string selectedName = studentNames[randomIndex];
            switch (type)
            {
                case 1:
                    return new Mathematician(selectedName);
                case 2:
                    return new Statistician(selectedName);
                case 3:
                    return new ComputerMechanic(selectedName);
                case 4:
                    return new ComputerMathematician(selectedName);
                case 5:
                    return new Educator(selectedName);
                default:
                    return new Student(selectedName); 
            }
        }
    }
}
