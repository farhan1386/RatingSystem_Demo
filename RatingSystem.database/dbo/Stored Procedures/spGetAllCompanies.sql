create procedure spGetAllCompanies
AS  
BEGIN    
    SELECT TOP (1000) [f_uid]
      ,[f_iid]
      ,[f_company_name]
      ,[f_company_location]
      ,[f_country]
      ,[f_glassdoor_rating]
  FROM 
      [Sample-DB].[dbo].[t_company_rating]
END