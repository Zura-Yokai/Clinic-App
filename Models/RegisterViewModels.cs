using System;
using System.ComponentModel.DataAnnotations;


// DO NOT MAPPED in DbContext!!!
public class RegisterViewModels
{
	[Required]
	public string userName { get; set; }
	[Required]
	public string password { get; set; }
	public string role { get; set; }
	
	// Add you Registration fields here... then in AccountController.. public IHttpActionResult RegisterUser(RegisterViewModel newUser)
	public string lastName { get; set; }
	public string firstName { get; set; }
	public string email { get; set; }
	public DateTime? birthDate { get; set; }
	public string gender { get; set; }
	public string phone { get; set; }
	public string address { get; set; }
	public string specialization { get; set; }

	//
		
}