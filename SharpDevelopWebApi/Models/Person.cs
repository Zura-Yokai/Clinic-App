/*
 * Created by SharpDevelop.
 * User: Gabs
 * Date: 31/07/2019
 * Time: 3:06 pm
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace SharpDevelopWebApi.Models
{
	/// <summary>
	/// Description of Person.
	/// </summary>
	public class Person
	{
		
		public int id { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public DateTime? birthDate { get; set; }
		public string gender { get; set; }
		public string address { get; set; }
		public string phone { get; set; }
	}
}
