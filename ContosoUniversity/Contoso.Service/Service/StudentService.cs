using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Core.Domain;
using Contoso.Data.Repository;

namespace Contoso.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public void DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            var query = from s in _studentRepository.Table select s;
            var students = query.ToList();
            return students;
        }

        public Student GetStudentById(int? id)
        {
            throw new NotImplementedException();
        }

        public void InsertStudent(Student student)
        {
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
