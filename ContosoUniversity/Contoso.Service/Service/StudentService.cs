using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contoso.Core;
using Contoso.Data;
using Contoso.Data.Repository;
using Contoso.Core.Domain;

namespace Contoso.Service.Service
{
    public class StudentService : IStudentService
    {

        private readonly IRepository<Student> _studentRepository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="studentRepository">Student Repository</param>
        public StudentService(IRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public Student GetStudentById(int? id)
        {
            return _studentRepository.GetById(id);
        }

        public void InsertStudent(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("student");
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void DeleteStudent(int? id)
        {
            var student = _studentRepository.GetById(id);
            _studentRepository.Delete(student);
        }

        public IList<Student> GetAllStudents()
        {
            var query = from c in _studentRepository.Table
                        select c;

            var students = query.ToList();
            return students;
        }
    }
}