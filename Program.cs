using System;
using System.Linq;
using LinqPractices.DbOperations;

namespace LinqPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            //Find()
            Console.WriteLine("***** Find ******");
            var student = _context.Students.Where(student=>student.Id ==1).FirstOrDefault();
            student = _context.Students.Find(1);
            System.Console.WriteLine(student.Name);

            //FirstOrDefault()
            System.Console.WriteLine();
            Console.WriteLine("***** FirstOrDefault ******");
            student = _context.Students.Where(student=>student.Surname =="Arda").FirstOrDefault();
            System.Console.WriteLine(student.Name);

            student = _context.Students.FirstOrDefault(x=>x.Surname=="Arda");
            System.Console.WriteLine(student.Name);

            //SingleOrDefault()
            System.Console.WriteLine();
            Console.WriteLine("***** SingleOrDefault ******");
            student = _context.Students.SingleOrDefault(s => s.Name == "Deniz");
            System.Console.WriteLine(student.Surname);

            //ToList()
            System.Console.WriteLine();
            Console.WriteLine("***** ToList ******");
            var studentList = _context.Students.Where(x=>x.ClassId ==2).ToList();
            System.Console.WriteLine(studentList.Count);

            //OrderBy()
            System.Console.WriteLine();
            Console.WriteLine("***** OrderBy ******");

            students = _context.Students.OrderBy(x=>x.Id).ToList();
            foreach (var st in students)
            {
                System.Console.WriteLine(st.Id+ " - "+ st.Name);
            }

            //OrderByDescending
            System.Console.WriteLine();
            Console.WriteLine("***** OrderByDescending ******");

            students = _context.Students.OrderByDescending(x=>x.Id).ToList();
            foreach (var st in students)
            {
                System.Console.WriteLine(st.Id+ " - "+ st.Name);
            }

            //Anonymous Object Result
            System.Console.WriteLine();
            Console.WriteLine("***** Anonymous Object Result ******");

            var anonymousObject = _context.Students
                                .Where(x=>x.ClassId==2)
                                .Select(x=> new {
                                    Id = x.Id,
                                    FullName = x.Name + " " + x.Surname
                                });

        foreach (var item in anonymousObject)
        {
            System.Console.WriteLine(item.Id + " - "+ item.FullName);
        }
        }
    }
}
