Create Procedure spAddCompany
	@f_uid uniqueidentifier,
	@f_company_name nvarchar(100),
	@f_company_location nvarchar(100),
	@f_country nvarchar(100),
	@f_glassdoor_rating float
AS  
BEGIN    
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
       @f_glassdoor_rating)
END