using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
	/// <summary>
	/// Description of AppointmentController.
	/// </summary>
	public class AppointmentController : ApiController
	{
		SDWebApiDbContext _db = new SDWebApiDbContext();
		
		[HttpGet]
		public IHttpActionResult GetAll(){
			var appointment = _db.Appointments.ToList();
			
			foreach (var ap in appointment) 
			{
				ap.patient = _db.Patients.Where(x=>x.userId == ap.patientUserId).FirstOrDefault() ?? new Patient();
				ap.doctor = _db.Doctors.Where(x=>x.userId == ap.doctorUserId).FirstOrDefault() ?? new Doctor();
				ap.doctorAvailableTimes = _db.DocAvailTimes.Find(ap.doctorAvailbleTimeId) ?? new DoctorAvailableTimes();
			}
			return Ok(appointment);
		}
		
		[HttpGet]
		[Route("api/appointment/bydoctoruserid/{id}")]
		public IHttpActionResult GetAllByDoctorUserId(int id, string bystatus = ""){
			var appointment = _db.Appointments.Where(x=>x.doctorUserId == id).ToList();
			
			if(!string.IsNullOrEmpty(bystatus))
			{
				appointment = appointment.Where(x=>x.status == bystatus).ToList();
			}				
			
			foreach (var ap in appointment) 
			{
				ap.patient = _db.Patients.Where(x=>x.userId == ap.patientUserId).FirstOrDefault() ?? new Patient();
				ap.doctor = _db.Doctors.Where(x=>x.userId == ap.doctorUserId).FirstOrDefault() ?? new Doctor();
				ap.doctorAvailableTimes = _db.DocAvailTimes.Find(ap.doctorAvailbleTimeId) ?? new DoctorAvailableTimes();
			}
			
			return Ok(appointment);
		}			
		
		[HttpGet]
		[Route("api/appointment/bypatientuserid/{id}")]
		public IHttpActionResult GetAllByPatientUserId(int id){
			var appointment = _db.Appointments.Where(x=>x.patientUserId == id).ToList();
			
			foreach (var ap in appointment) 
			{
				ap.patient = _db.Patients.Where(x=>x.userId == ap.patientUserId).FirstOrDefault() ?? new Patient();
				ap.doctor = _db.Doctors.Where(x=>x.userId == ap.doctorUserId).FirstOrDefault() ?? new Doctor();
				ap.doctorAvailableTimes = _db.DocAvailTimes.Find(ap.doctorAvailbleTimeId) ?? new DoctorAvailableTimes();
			}
			return Ok(appointment);
		}

		
		
		[HttpGet]
		[Route("api/appointment/{id}")]
		public IHttpActionResult getIdAppointment(int id){
			var appId = _db.Appointments.Find(id);
			if(appId != null)
				return Ok(appId);
			else
				return BadRequest("Appointment not Found ");	
		}
		
		[HttpPost]
		public IHttpActionResult CreateAppointment(Appointment ap){
			_db.Appointments.Add(ap);
			_db.SaveChanges();
			return Ok("Success");
		}
		
		[HttpPut]
		public IHttpActionResult UpdateAppointment(Appointment updatedAppointment){
			var ap = _db.Appointments.Find(updatedAppointment.id);
			if(ap != null)
			{
				ap.doctorAvailbleTimeId = updatedAppointment.doctorAvailbleTimeId;
				ap.reason = updatedAppointment.reason;
				ap.status = updatedAppointment.status;				
				_db.Entry(ap).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
				return Ok("Success");
			}
			else 
				return BadRequest("Unsuccessfull");
		}		
		
		[HttpPut]
		[Route("api/appointment/setstatus/{appointmentId}/{status}")]
		public IHttpActionResult SetAppointmentStatus(int appointmentId, string status){
			var ap = _db.Appointments.Find(appointmentId);
			if(ap != null)
			{
				ap.status = status;				
				_db.Entry(ap).State = System.Data.Entity.EntityState.Modified;
				_db.SaveChanges();
				return Ok("Success");
			}
			else 
				return BadRequest("Unsuccessfull");
		}
		
		[HttpDelete]
		public IHttpActionResult DeleteAppointment(int Id){
			var ap = _db.Appointments.Find(Id);
			if(ap != null)
			{
				_db.Appointments.Remove(ap);
				_db.SaveChanges();
				return Ok("Delete Successfully");
			}
			else
				return BadRequest("Delete Unsuccessfully");
		}
	}
}