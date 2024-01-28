Create Procedure spDeleteCompany
	@f_uid uniqueidentifier
AS  
BEGIN    
DELETE FROM 
    [dbo].[t_company_rating]
WHERE
    [f_uid]=@f_uid
END