using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testService.Models
{
    public class Course
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string URL { get; set; } = "sd";

        public string Title { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; } = 15;

        public string Discription { get; set; }
    }
    
    public static class Courseware
    {
        private static List<Course> _course = new List<Course>()
        {
            //new Course()
            //{
            //    Title = "Course 1",
            //    Price = 10.0
            //},
            //new Course()
            //{
            //    Title = "Course 2",
            //    Price = 20.0
            //}
        };

        static Courseware()
        {
            var faker = new Faker<Course>();
            faker.RuleFor(_ => _.URL, f => f.Internet.Url());
            faker.RuleFor(_ => _.Title, f => f.Random.String());
            faker.RuleFor(_ => _.Price, f => f.Random.Double());
            faker.RuleFor(_ => _.Discount, f => f.Random.Int());
            faker.RuleFor(_ => _.Discription, f => f.Random.String());
            _course = faker.Generate(10);
        }

        public static IEnumerable<Course> GetAll()
        {
            return _course.AsReadOnly();
        }

        public static Course GetById(string id)
        {
            return _course.SingleOrDefault(b => b.Id.Equals(id,
                StringComparison.OrdinalIgnoreCase));
        }

        public static Course Add(Course course)
        {
            course.Id = Guid.NewGuid().ToString();
            _course.Add(course);    // id записи вы формируем на стороне сервера, а не на стороне клиента
            return course;
        }

    }
}