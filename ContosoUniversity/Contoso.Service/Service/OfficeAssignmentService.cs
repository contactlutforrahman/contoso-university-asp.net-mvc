using Contoso.Core.Domain;
using Contoso.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public class OfficeAssignmentService : IOfficeAssignmentService
    {
        private readonly IRepository<OfficeAssignment> _officeAssignmentRepository;
        public OfficeAssignmentService(IRepository<OfficeAssignment> officeAssignmentRepository)
        {
            this._officeAssignmentRepository = officeAssignmentRepository;
        }
        public void DeleteOfficeAssignment(int? id)
        {
            var officeAssignment = _officeAssignmentRepository.GetById(id);
            _officeAssignmentRepository.Delete(officeAssignment);
        }

        public IList<OfficeAssignment> GetAllOfficeAssignments()
        {
            var query = from o in _officeAssignmentRepository.Table select o;
            var officeAssignments = query.ToList();
            return officeAssignments;
        }

        public OfficeAssignment GetOfficeAssignmentById(int? id)
        {
            return _officeAssignmentRepository.GetById(id);
        }

        public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
        {
            _officeAssignmentRepository.Insert(officeAssignment);
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            _officeAssignmentRepository.Update(officeAssignment);
        }
    }
}
