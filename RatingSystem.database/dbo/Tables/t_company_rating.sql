CREATE TABLE [dbo].[t_company_rating] (
    [f_uid]              UNIQUEIDENTIFIER NOT NULL,
    [f_iid]              INT              IDENTITY (1, 1) NOT NULL,
    [f_company_name]     NVARCHAR (100)   NULL,
    [f_company_location] NVARCHAR (100)   NULL,
    [f_country]          NVARCHAR (100)   NULL,
    [f_glassdoor_rating] FLOAT (53)       NULL,
    CONSTRAINT [PK_t_company_rating] PRIMARY KEY CLUSTERED ([f_uid] ASC)
);

