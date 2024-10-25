using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UsersCourse
    {
        public int IdUser { get; set; }
        public User User { get; set; }  // Связь с таблицей пользователей

        public int IdCourse { get; set; }
        public Course Course { get; set; }  // Связь с таблицей курсов
    }
}
