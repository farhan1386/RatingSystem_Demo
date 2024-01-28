using Dapper;
using Microsoft.Data.SqlClient;
using RatingSystem_Demo.Models;
using System.Data;

namespace RatingSystem_Demo.Repositories
{
    public class CompanyRepositorySP : ICompany
    {
        private readonly IConfiguration _configuration;
        private SqlConnection _connection;
        public CompanyRepositorySP(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
        public async Task<IEnumerable<CompanyModel>> Get()
        {
            return await _connection.QueryAsync<CompanyModel>("spGetAllCompanies",
                commandType:CommandType.StoredProcedure);
        }
        public async Task<CompanyModel> Find(Guid uid)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@f_uid", uid);
            return await _connection.QueryFirstOrDefaultAsync<CompanyModel>("spGetCompanyById", parameters,
                commandType: CommandType.StoredProcedure);
        }
        public async Task<CompanyModel> Add(CompanyModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@f_uid", model.f_uid = Guid.NewGuid());
            parameters.Add("@f_company_name", model.f_company_name);
            parameters.Add("@f_company_location", model.f_company_location);
            parameters.Add("@f_country", model.f_country);
            parameters.Add("@f_glassdoor_rating", model.f_glassdoor_rating);
            await _connection.ExecuteAsync("spAddCompany", parameters, commandType: CommandType.StoredProcedure);
            return model;
        }
        public async Task<CompanyModel> Update(CompanyModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@f_uid", model.f_uid);
            parameters.Add("@f_company_name", model.f_company_name);
            parameters.Add("@f_company_location", model.f_company_location);
            parameters.Add("@f_country", model.f_country);
            parameters.Add("@f_glassdoor_rating", model.f_glassdoor_rating);

            await _connection.ExecuteAsync("spUpdateCompany", parameters, commandType: CommandType.StoredProcedure);
            return model;
        }
        public async Task<CompanyModel> Remove(CompanyModel model)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@f_uid", model.f_uid);
            await _connection.ExecuteAsync("spDeleteCompany", parameters, commandType: CommandType.StoredProcedure);
            return model;
        }
    }
}