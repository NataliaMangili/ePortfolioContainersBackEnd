namespace ePortfolio.Domain.ValueObjects;

public class ContactVO
{
    public string Email { get; }
    public string PhoneNumber { get; }

    public ContactVO(string email, string phoneNumber, string address)
    {
        if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            throw new ArgumentException("Invalid email address.");

        if (string.IsNullOrEmpty(phoneNumber) || !IsValidPhoneNumber(phoneNumber))
            throw new ArgumentException("Invalid phone number.");

        Email = email;
        PhoneNumber = phoneNumber;
    }

    private bool IsValidEmail(string email) =>
        //TODO Ajustar regras
        email.Contains("@") && email.Contains(".");

    private bool IsValidPhoneNumber(string phoneNumber) => 
        phoneNumber.Length >= 7 && long.TryParse(phoneNumber, out _);

    public override int GetHashCode() => HashCode.Combine(Email, PhoneNumber);

    public override string ToString() => $"Email: {Email} - Phone: {PhoneNumber}";

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (ContactVO)obj;
        return Email == other.Email && PhoneNumber == other.PhoneNumber;
    }

}
