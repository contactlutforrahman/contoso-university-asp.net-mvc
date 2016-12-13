using Contoso.Core;
using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Get a Department by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Department GetDepartmentById(int? id);

        /// <summary>
        /// Inserts a Department
        /// </summary>
        /// <param name="Department">Department</param>
        void InsertDepartment(Department Department);

        /// <summary>
        /// Updates the Department
        /// </summary>
        /// <param name="Department">Department</param>
        void UpdateDepartment(Department Department);

        IList<Department> GetAllDepartments();

        /// <summary>
        /// Deletes the Department
        /// </summary>
        /// <param name="id"></param>
        void DeleteDepartment(int? id);
    }
}
