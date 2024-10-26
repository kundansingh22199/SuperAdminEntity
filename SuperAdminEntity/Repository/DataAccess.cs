using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SuperAdminEntity.EF;
using SuperAdminEntity.Models;
using System.Data;

namespace SuperAdminEntity.Repository
{
    public class DataAccess
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IConfiguration _configuration;

        // Inject ApplicationDbContext and IConfiguration
        public DataAccess(ApplicationDbContext applicationDbContext, IConfiguration configuration)
        {
            _applicationDbContext = applicationDbContext;
            _configuration = configuration;
        }

        public async Task<string> GetConnectionAsync(string domain)
        {
            if (string.IsNullOrEmpty(domain))
            {
                return _configuration.GetConnectionString("SqlCon");
            }
            using (var connection = new SqlConnection(_configuration.GetConnectionString("SqlCon")))
            {
                await connection.OpenAsync();

                using (var cmd = new SqlCommand("SP_GetConnection", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@domain", domain);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader["Connection"]?.ToString(); 
                        }
                    }
                }
            }

            return string.Empty;
        }

        public async Task<bool> SignInAsync(ControlMst obj)
        {
            var regNoParam = new SqlParameter("@username", obj.username);
            var passwordParam = new SqlParameter("@Password", obj.password);
            var result = await _applicationDbContext.ControlMsts
                .FromSqlRaw("EXEC Proc_Login @username, @Password", regNoParam, passwordParam)
                .ToListAsync();

            return result.Any();
        }
        public async Task<string> ChangeAdminPassword(ModChangePass obj)
        {
            string msg = "";
            var connectionString = await GetConnectionAsync(obj.Domain);
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new ApplicationDbContext(optionsBuilder.Options))
            {
                try
                {
                    var result = await context.Set<ChangePasswordResult>()
                        .FromSqlRaw("EXEC SP_UpdateAdminPassword @oldpassword = {0}, @newpassword = {1}, @confpassword = {2}",
                            obj.OldPassword, obj.NewPassword, obj.ConfPassword)
                        .ToListAsync();

                    if (result.Any())
                    {
                        msg = result.First().Message;
                    }
                }
                catch (Exception ex)
                {
                    msg = "An error occurred while updating the password";
                }
            }

            return msg;
        }
        public async Task<List<Tbl_DomainMaster>> GetDomain()
        {
            var result = new List<Tbl_DomainMaster>();

            try
            {
                result = await _applicationDbContext.Tbl_DomainMaster
                    .FromSqlRaw("EXEC SP_GetPackage @Action = {0}", "domain")
                    .ToListAsync();
                result.ForEach(domain =>
                {
                    domain.Connection = domain.Connection;
                });
            }
            catch (Exception ex)
            {
            }

            return result;
        }
        public async Task<bool> AddDomain(Tbl_DomainMaster obj)
        {
            var encryptedConnection = obj.Connection.Trim();

            var parameters = new[]
            {
                new SqlParameter("@Domain", obj.Domain.Trim()),
                new SqlParameter("@Connection", encryptedConnection)
            };
            try
            {
                var result = await _applicationDbContext.Database
                    .ExecuteSqlRawAsync("EXEC SP_AddDomain @Domain, @Connection", parameters);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
