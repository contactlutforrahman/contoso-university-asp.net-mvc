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
    public class InstructorsController : Controller
    {
        private readonly IInstructorService _instructorService;
        private readonly IOfficeAssignmentService _officeAssignmentService;

        public InstructorsController(IInstructorService instructorService, IOfficeAssignmentService officeAssignmentService)
        {
            this._instructorService = instructorService;
            this._officeAssignmentService = officeAssignmentService;
        }

        // GET: Instructors
        public ActionResult Index()
        {
            var instructors = _instructorService.GetInstructorsWithOfficeAssignment();
            return View(instructors.ToList());
        }

        // GET: Instructors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetInstructorById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(_officeAssignmentService.GetAllOfficeAssignments(), "InstructorId", "Location");
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstMidName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorService.InsertInstructor(instructor);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(_officeAssignmentService.GetAllOfficeAssignments(), "InstructorId", "Location", instructor.Id);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetInstructorById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(_officeAssignmentService.GetAllOfficeAssignments(), "InstructorId", "Location", instructor.Id);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstMidName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorService.InsertInstructor(instructor);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(_officeAssignmentService.GetAllOfficeAssignments(), "InstructorId", "Location", instructor.Id);
            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = _instructorService.GetInstructorById(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _instructorService.DeleteInstructor(id);
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
