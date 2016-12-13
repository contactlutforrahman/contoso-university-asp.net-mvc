using Contoso.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Service.Service
{
    public interface IOfficeAssignmentService
    {
        /// <summary>
        /// Get a OfficeAssignment by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        OfficeAssignment GetOfficeAssignmentById(int? id);

        /// <summary>
        /// Inserts a OfficeAssignment
        /// </summary>
        /// <param name="OfficeAssignment">OfficeAssignment</param>
        void InsertOfficeAssignment(OfficeAssignment officeAssignment);

        /// <summary>
        /// Updates the OfficeAssignment
        /// </summary>
        /// <param name="OfficeAssignment">OfficeAssignment</param>
        void UpdateOfficeAssignment(OfficeAssignment officeAssignment);

        /// <summary>
        /// Get All OfficeAssignments
        /// </summary>
        IList<OfficeAssignment> GetAllOfficeAssignments();


        /// <summary>
        /// Deletes the OfficeAssignment
        /// </summary>
        /// <param name="id"></param>
        void DeleteOfficeAssignment(int? id);
    }
}
