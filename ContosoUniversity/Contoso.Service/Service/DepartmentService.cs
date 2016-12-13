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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        
        public Department GetDepartmentById(int? id)
        {
            return _departmentRepository.GetById(id);
        }

        public void InsertDepartment(Department department)
        {
            _departmentRepository.Insert(department);
        }

        public IList<Department> GetAllDepartments()
        {
            var query = from d in _departmentRepository.Table select d;
            var departments = query.ToList();
            return departments;
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(int? id)
        {
            var department = _departmentRepository.GetById(id);
            _departmentRepository.Delete(department);
        }
    }
}