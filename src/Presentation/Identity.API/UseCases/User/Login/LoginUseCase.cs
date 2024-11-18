using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Identity.API.Domain.User;
using Identity.API.UseCases.Auth.Login;
using Microsoft.IdentityModel.Tokens;

namespace Identity.API.UseCases.User.Login;

public class LoginUseCase(IUsersRepository<Domain.User.User> auth,IConfiguration conf)
{
    private readonly IUsersRepository<Domain.User.User> _auth = auth;
    private readonly IConfiguration _conf = conf;
    
    public  async Task<LoginOut> Login( LoginIn request)
    {
        try
        {
            bool isValid = await _auth.IsUserPasswordValid(request.Username, request.Password);

            if (!isValid)
            {
                throw new ArgumentException("User password is invalid!");
            }

            var result = new LoginOut()
            {
                Token = GenerateToken(),
            };
            return await Task.FromResult(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private string GenerateToken()
    { 
        var jwtConfiguration = _conf.GetSection("JwtConfiguration");
        
        var issuer = jwtConfiguration.GetSection("Issuer").Value ?? string.Empty; 
        var audience = jwtConfiguration.GetSection("Audience").Value ?? string.Empty;
        
        DateTime expires = DateTime.Now.AddMinutes(
            int.Parse(
                jwtConfiguration.GetSection("ExpirationTimeInMinutes").Value ?? string.Empty
            )
        );
        
        var securityKey = 
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    jwtConfiguration.GetSection("SecurityKey").Value ?? string.Empty
                )
            );
        
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: expires,
            signingCredentials: credentials
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}