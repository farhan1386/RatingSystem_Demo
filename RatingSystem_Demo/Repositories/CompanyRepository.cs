using Dapper;
using Microsoft.Data.SqlClient;
using RatingSystem_Demo.Models;

namespace RatingSystem_Demo.Repositories
{
    public class CompanyRepository : ICompany
    {
        private readonly IConfiguration _configuration;
        private readonly SqlConnection _connection;
        public CompanyRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IEnumerable<CompanyModel>> Get()
        {
            var sql = $@"
                        SELECT [f_uid]
                              ,[f_iid]
                              ,[f_company_name]
                              ,[f_company_location]
                              ,[f_country]
                              ,[f_glassdoor_rating]
                          FROM 
                               [Sample-DB].[dbo].[t_company_rating]
                               ORDER BY f_iid ASC";

            return await _connection.QueryAsync<CompanyModel>(sql);
        }
        public async Task<CompanyModel> Find(Guid uid)
        {
            var sql = $@"
                        SELECT [f_uid]
                              ,[f_iid]
                              ,[f_company_name]
                              ,[f_company_location]
                              ,[f_country]
                              ,[f_glassdoor_rating]
                          FROM [Sample-DB].[dbo].[t_company_rating]
                          WHERE
                               [f_uid]=@uid";

            return await _connection.QueryFirstOrDefaultAsync<CompanyModel>(sql, new { uid });
        }
        public async Task<CompanyModel> Add(CompanyModel model)
        {
            model.f_uid = Guid.NewGuid();

            var sql = $@"
                     INSERT INTO [dbo].[t_company_rating]
                           ([f_uid]
                           ,[f_company_name]
                           ,[f_company_location]
                           ,[f_country]
                           ,[f_glassdoor_rating])
                     VALUES
                           (@f_uid,
                            @f_company_name,
                            @f_company_location,
                            @f_country, 
                            @f_glassdoor_rating)";

            await _connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<CompanyModel> Update(CompanyModel model)
        {
            var sql = $@"UPDATE [dbo].[t_company_rating]
                        SET  
                            [f_company_name] = @f_company_name, 
                            [f_company_location] = @f_company_location,
                            [f_country] = @f_country,
                            [f_glassdoor_rating] = @f_glassdoor_rating 
                         WHERE 
		                    f_uid=@f_uid";

            await _connection.ExecuteAsync(sql, model);
            return model;
        }
        public async Task<CompanyModel> Remove(CompanyModel model)
        {
            var sql = $@"
                        DELETE FROM 
                            [dbo].[t_company_rating]
                        WHERE
                            [f_uid]=@f_uid";

            await _connection.ExecuteAsync(sql, model);
            return model;
        }
    }
}
