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
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Department> _departmentRepository;
        
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="courseRepository">Course Repository</param>
        public CourseService(IRepository<Course> courseRepository, IRepository<Department> departmentRepository)
        {
            this._courseRepository = courseRepository;
            this._departmentRepository = departmentRepository;
        }

        public Course GetCourseById(int? id)
        {
            return _courseRepository.GetById(id);
        }

        public void InsertCourse(Course course)
        {
            if (course == null)
                throw new ArgumentNullException("course");

            _courseRepository.Insert(course);
        }

        public IList<Course> GetAllCourses()
        {

            var query = from c in _courseRepository.Table
                        select c;

            var courses = query.ToList();
            return courses;
        }

        public IList<Course> GetAllCoursesWithDepartments()
        {
            var query = from c in _courseRepository.Table
                        join d in _departmentRepository.Table
                        on c.DepartmentId equals d.Id
                        select c;
            var courses = query.ToList();
            return courses;
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void DeleteCourse(int? id)
        {
            var course = _courseRepository.GetById(id);
            _courseRepository.Delete(course);
        }
    }
}