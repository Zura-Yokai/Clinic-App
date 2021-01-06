/*
 * Created by SharpDevelop.
 * User: HMW LENDING
 * Date: 29/09/2019
 * Time: 5:31 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Appointment.
	/// </summary>
	public class Appointment
	{
		public int id { get; set; }
		
		public int patientUserId { get; set; }
		[NotMapped]
		public Patient patient { get; set; } 	
		
		public int doctorUserId { get; set; }
		[NotMapped]
		public Doctor doctor { get; set; }
		
		public int doctorAvailbleTimeId { get; set; }
		[NotMapped]
		public DoctorAvailableTimes doctorAvailableTimes { get; set; }
		
		public string reason { get; set; }
		public string status { get; set; }
	}
}
