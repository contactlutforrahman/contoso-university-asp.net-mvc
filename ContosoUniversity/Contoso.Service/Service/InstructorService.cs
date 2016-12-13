using System.Collections.Generic;
using System.Linq;
using Contoso.Core.Domain;
using Contoso.Data.Repository;

namespace Contoso.Service.Service
{
    public class InstructorService : IInstructorService
    {
        private readonly IRepository<Instructor> _instructorRepository;
        private readonly IRepository<OfficeAssignment> _officeAssesmentRepository;

        public InstructorService(IRepository<Instructor> instructorRepository, IRepository<OfficeAssignment> officeAssesmentRepository)
        {
            this._instructorRepository = instructorRepository;
            this._officeAssesmentRepository = officeAssesmentRepository;
        }

        public Instructor GetInstructorById(int? id)
        {
            return _instructorRepository.GetById(id);
        }

        public void InsertInstructor(Instructor instructor)
        {
            _instructorRepository.Insert(instructor);
        }

        public IList<Instructor> GetAllInstructors()
        {
            var query = from i in _instructorRepository.Table select i;
            var instructors = query.ToList();
            return instructors;
        }

        public IList<Instructor> GetInstructorsWithOfficeAssignment()
        {
            var query = from i in _instructorRepository.Table
                        join o in _officeAssesmentRepository.Table
                        on i.Id equals o.InstructorId
                        select i;
            var instructors = query.ToList();
            return instructors;
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _instructorRepository.Update(instructor);
        }

        public void DeleteInstructor(int? id)
        {
            var instructor = _instructorRepository.GetById(id);
            _instructorRepository.Delete(instructor);
        }
    }
}
