using SharpDevelopWebApi.Models;
public class Doctor : Person
{
	public int userId { get; set; }
	public string specialization { get; set; }
	public string email { get; set; }

}