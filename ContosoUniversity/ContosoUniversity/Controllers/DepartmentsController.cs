using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contoso.Core;
using Contoso.Data;
using Contoso.Service;
using Contoso.Service.Service;
using Contoso.Core.Domain;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;

        public DepartmentsController(IDepartmentService departmentService, IInstructorService instructorService)
        {
            this._departmentService = departmentService;
            this._instructorService = instructorService;
        }

        // GET: Departments
        public ActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.InstructorId = new SelectList(_instructorService.GetAllInstructors(), "Id", "LastName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Budget,StartDate,InstructorId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.InsertDepartment(department);
                return RedirectToAction("Index");
            }

            ViewBag.InstructorId = new SelectList(_instructorService.GetAllInstructors(), "Id", "LastName", department.InstructorId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.InstructorId = new SelectList(_instructorService.GetAllInstructors(), "Id", "LastName", department.InstructorId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Budget,StartDate,InstructorId")] Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentService.UpdateDepartment(department);
                return RedirectToAction("Index");
            }
            ViewBag.InstructorId = new SelectList(_instructorService.GetAllInstructors(), "Id", "LastName", department.InstructorId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _departmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
