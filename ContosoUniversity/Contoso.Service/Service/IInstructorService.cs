using Contoso.Core;
using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public interface IInstructorService
    {
        /// <summary>
        /// Get a Instructor by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Instructor GetInstructorById(int? id);

        /// <summary>
        /// Inserts a Instructor
        /// </summary>
        /// <param name="Instructor">Instructor</param>
        void InsertInstructor(Instructor Instructor);

        /// <summary>
        /// Updates the Instructor
        /// </summary>
        /// <param name="Instructor">Instructor</param>
        void UpdateInstructor(Instructor Instructor);

        /// <summary>
        /// Get All Instructors
        /// </summary>
        IList<Instructor> GetAllInstructors();
        /// <summary>
        /// Get All Instructors
        /// </summary>
        IList<Instructor> GetInstructorsWithOfficeAssignment();

        /// <summary>
        /// Deletes the Instructor
        /// </summary>
        /// <param name="id"></param>
        void DeleteInstructor(int? id);
    }
}
