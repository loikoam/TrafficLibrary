using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testService.Data.Models
{
    public class BookDb
    {
        //для модели все данные должны быть public and notReadonly
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public double Price { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }
    }
}
