Create Procedure spGetCompanyById
@f_uid uniqueidentifier
AS  
BEGIN    
    SELECT [f_uid]
      ,[f_iid]
      ,[f_company_name]
      ,[f_company_location]
      ,[f_country]
      ,[f_glassdoor_rating]
  FROM 
      [Sample-DB].[dbo].[t_company_rating]
  WHERE 
	 [t_company_rating].[f_uid]=@f_uid
END