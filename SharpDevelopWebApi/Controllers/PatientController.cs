using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of PatientController.
	/// </summary>
	public class PatientController : ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
		public IHttpActionResult GetAll(){
			var p = _db.Patients.ToList();
			if(p != null)
				return Ok(p);
			else
				return BadRequest("Patients Not Found");		
		}
		
		[HttpGet]
		[Route("api/patient/{id}")]
		public IHttpActionResult getIDpatient(int id) {
			var pat = _db.Patients.Find(id);
			if(pat != null)
				return Ok(pat);
			else
				return BadRequest("Patient Not Found");
		}
		
		[HttpGet]
		[Route("api/patient/byuserid/{id}")]
		public IHttpActionResult getPatientByUserId(int id) {
			var pat = _db.Patients.Where(x=>x.userId == id).FirstOrDefault();
			if(pat != null)
				return Ok(pat);
			else
				return BadRequest("Patient Not Found");
		}		
		
		[HttpPost]
		public IHttpActionResult PatientRegister(Patient p){
			_db.Patients.Add(p);
			_db.SaveChanges();
			return Ok(p);
		}
			
		[HttpPut]
		public IHttpActionResult UpdatePatient(Patient p){
			var patient = _db.Patients.Find(p.id);
			if(patient != null)
			{
				patient.lastName = p.lastName;
				patient.firstName = p.firstName;
				patient.address = p.address;
				patient.phone = p.phone;
				_db.Entry(patient).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
				return Ok("Patient Successfully");
			}
			else
				return BadRequest("Patient not Found");
		}
		
		[HttpDelete]
		[Route("api/patients/{id}")]
		public IHttpActionResult DeleteDoctor(int id){
			var d = _db.Patients.Find(id);
			if(d != null)
			{
				_db.Patients.Remove(d);
				_db.SaveChanges();
				return Ok("Delete Successfully");
			}
			else
				return BadRequest("Delete Unsuccessfully");
			       
		}
	}
}