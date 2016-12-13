using Contoso.Core;
using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// Get a Course by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns> Course </returns>
        Course GetCourseById(int? id);

        /// <summary>
        /// Inserts a Course
        /// </summary>
        /// <param name="Course">Course</param>
        void InsertCourse(Course course);

        /// <summary>
        /// Updates the Course
        /// </summary>
        /// <param name="Course">Course</param>
        void UpdateCourse(Course course);

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns> All Courses </returns>
        IList<Course> GetAllCourses();

        /// <summary>
        /// Get all Courses with Departments
        /// </summary>
        /// <returns> Courses with Departments </returns>
        IList<Course> GetAllCoursesWithDepartments();

        /// <summary>
        /// Deletes the Course
        /// </summary>
        /// <param name="id"></param>
        void DeleteCourse(int? id);
    }
}
