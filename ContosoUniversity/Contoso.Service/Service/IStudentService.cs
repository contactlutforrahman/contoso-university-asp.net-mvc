using Contoso.Core;
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
        /// <summary>
        /// Get a student by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Student GetStudentById(int? id);

        /// <summary>
        /// Inserts a student
        /// </summary>
        /// <param name="student">Student</param>
        void InsertStudent(Student student);

        /// <summary>
        /// Updates the student
        /// </summary>
        /// <param name="student">Student</param>
        void UpdateStudent(Student student);

        IList<Student> GetAllStudents();

        /// <summary>
        /// Deletes the student
        /// </summary>
        /// <param name="id"></param>
        void DeleteStudent(int? id);
    }
}
