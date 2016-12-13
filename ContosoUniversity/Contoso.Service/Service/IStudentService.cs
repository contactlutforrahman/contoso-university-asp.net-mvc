using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public interface IStudentService
    {
        void InsertStudent(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int? id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
