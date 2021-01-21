/*
 * Created by SharpDevelop.
 * User: HMW LENDING
 * Date: 29/09/2019
 * Time: 5:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of DoctorAvailableTimes.
	/// </summary>
	public class DoctorAvailableTimes
	{
		public int id { get; set; }
		
		public int doctorUserId { get; set; }
		[NotMapped]
		public Doctor doctor {get; set;}
		
		public DateTime? date { get; set; }
		public DateTime? startTime { get; set; }
		public DateTime? endTime { get; set; }
	}
}
