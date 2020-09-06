using ScenarioCloud.MobileDevExam.Business.Security;
using ScenarioCloud.MobileDevExam.Data;
using ScenarioCloud.MobileDevExam.WebApp.Models.Security;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ScenarioCloud.MobileDevExam.WebApp.Services.Security
{
  public class UserService : DataService<User>, IUserService
  {
    public UserService(IScenarioDbContext dbContext) : base(dbContext)
    { }

    private const int tokenExpirationInHours = 2;

    public UserAuthenticationInfo Authenticate(ICredential credential)
    {
      var user = Get(u => u.Username.Equals(credential.Username) &&
                          u.Password.Equals(credential.Password)).FirstOrDefault();

      if (user != null)
      {
        var token = $"{Guid.NewGuid()}-{Guid.NewGuid()}-{Guid.NewGuid()}";
        var newToken = DbContext.UserTokens.Add(new UserToken()
        {
          UserId = user.Id,
          Token = token,
          DateIssued = DateTime.UtcNow,
          ExpiryDate = DateTime.UtcNow.AddHours(tokenExpirationInHours)
        });
        DbContext.SaveChanges();
        
        return new UserAuthenticationInfo()
        {
          AccountHolder = user.AccountHolder,
          Token = newToken.Token,
          DateIssued = newToken.DateIssued,
          ExpiryDate = newToken.ExpiryDate
        };
      }

      throw new Exception("Invalid credentials.");
    }

    public async Task<UserAuthenticationInfo> AuthenticateAsync(ICredential credential)
    {
      var user = (await GetAsync(u => u.Username.Equals(credential.Username) &&
                                      u.Password.Equals(credential.Password))).FirstOrDefault();

      if (user != null)
      {
        var token = $"{Guid.NewGuid()}-{Guid.NewGuid()}-{Guid.NewGuid()}";
        var newToken = DbContext.UserTokens.Add(new UserToken()
        {
          UserId = user.Id,
          Token = token,
          DateIssued = DateTime.UtcNow,
          ExpiryDate = DateTime.UtcNow.AddHours(tokenExpirationInHours)
        });
        await DbContext.SaveChangesAsync();

        return new UserAuthenticationInfo()
        {
          AccountHolder = user.AccountHolder,
          Token = newToken.Token,
          DateIssued = newToken.DateIssued,
          ExpiryDate = newToken.ExpiryDate
        };
      }

      throw new Exception("Invalid credentials.");
    }

    public bool Authenticate(string token)
    {
      if (string.IsNullOrWhiteSpace(token))
        return false;

      return DbContext.UserTokens.Any(ut => ut.Token.Equals(token) &&
                                            ut.ExpiryDate > DateTime.UtcNow);
    }

    public async Task<bool> AuthenticateAsync(string token)
    {
      if (string.IsNullOrWhiteSpace(token))
        return false;

      return await DbContext.UserTokens.AnyAsync(ut => ut.Token.Equals(token) &&
                                                       ut.ExpiryDate < DateTime.UtcNow);
    }
  }
}