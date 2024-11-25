using Identity.API.Domain.Entity;
using Microsoft.AspNetCore.Identity;


namespace Identity.API.Domain.User;

public sealed class User : IdentityUser<Guid>,IIdentityEntity<Guid>
{

    public User()
    {
        
    }

    public User(string Email,DateTime modification, string resume, string caption,string firstName,string lastName, bool active = true)
    {
        Id = Guid.NewGuid();    
        Inclusion = DateTime.Now;
        SetEmail(Email);
        SetUsername(Email);
        SetResume(resume);
        SetCaption(caption);
        SetName(firstName,lastName);
        Active = active;
    }

    
    public DateTime Inclusion { get; }
    
    public DateTime Modification { get; set; }
    public  required string  Resume {get; set;}
    public  required string Caption { get; set; }
    
    public string  FirstName { get; set; }
    
    public string  LastName { get; set; }   
    
    public string FullName => $"{FirstName} {LastName}";
    
    public bool Active { get; set; }

    public void SetEmail(string email)
    {
        ArgumentException.ThrowIfNullOrEmpty(email,"cannot be null or empty.");

        if (!email.Contains("@"))
            throw new ArgumentException("Email must be valid email address.");
        Email = email;  
    }

    public void SetUsername(string emailUserName)
    {
        ArgumentException.ThrowIfNullOrEmpty(emailUserName,"UserName cannot be null or empty.");

        if (!emailUserName.Contains("@"))
            throw new ArgumentException("Username must be valid email address.");
        UserName = emailUserName;  
    }

    public void SetName(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName,"FirstName cannot be null or empty.");
        ArgumentException.ThrowIfNullOrEmpty(lastName,"LastName cannot be null or empty."); 
        
        FirstName = firstName;
        LastName= lastName;
    }
  

    public void SetResume(string resume)
    {
        ArgumentException.ThrowIfNullOrEmpty(resume,"The resume cannot be null or empty.");
        Resume = resume;    
    }

    public void SetCaption(string caption)
    {
        ArgumentException.ThrowIfNullOrEmpty(caption,"Caption cannot be null or empty.");
        Caption = caption;
    }
    public void SetActive()
    {
        Active = true;
    }

    public void SetInactive()
    {
        Active = false;
    }
    
    public void ValidateUserPassword(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password,"password cannot be null or empty.");
        
        if(password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long.");
        
        var specialCaracters = new List<string>(){"@","#",".","'","\""};
        if (!specialCaracters.Contains(password))
            throw new ArgumentException("password must contain special caracters.");
        
        
    }

   
}