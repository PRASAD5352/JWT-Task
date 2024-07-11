using MontCrest_Task_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MontCrest_Task_API.Controllers
{
    [Authorize]
    public class StudentController : ApiController
    {
        MontCrestEntities db;
        public StudentController()
        {
            db = new MontCrestEntities();
        }
        [HttpGet]
        [Route("api/students")]
        public List<StudentRegistration> GetAll()
        {
            return db.StudentRegistrations.ToList();
        }
        [HttpGet]
        [Route("api/student/{id}")]
        public StudentRegistration Get(int id)
        {
            return db.StudentRegistrations.Find(id);
        }
        [HttpPost]
        [Route("api/student")]
        public string AddStudent(StudentRegistration s)
        {
            db.StudentRegistrations.Add(s);
            db.SaveChanges();
            return "Student Added Successfully";
        }
        [HttpPut]
        [Route("api/student")]
        public string UpdateStudent(StudentRegistration s)
        {
            db.Entry<StudentRegistration>(s).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "Student Updated Successfully";
        }
        [HttpDelete]
        [Route("api/student/{id}")]
        public string DeleteStudent(int id)
        {
            StudentRegistration s=db.StudentRegistrations.Find(id);
            db.StudentRegistrations.Remove(s);
            db.SaveChanges();
            return "Student Deleted Successfully";
        }
    }
}
