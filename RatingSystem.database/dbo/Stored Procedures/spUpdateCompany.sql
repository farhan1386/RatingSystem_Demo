Create Procedure spUpdateCompany
	@f_uid uniqueidentifier,
	@f_company_name nvarchar(100),
	@f_company_location nvarchar(100),
	@f_country nvarchar(100),
	@f_glassdoor_rating float
AS  
BEGIN    
    UPDATE [dbo].[t_company_rating]
    SET  
        [f_company_name] = @f_company_name, 
        [f_company_location] = @f_company_location,
        [f_country] = @f_country,
        [f_glassdoor_rating] = @f_glassdoor_rating 
        WHERE 
		f_uid=@f_uid
END