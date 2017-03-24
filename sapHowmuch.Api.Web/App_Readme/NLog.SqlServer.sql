CREATE TABLE [dbo].[Logs](  
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [EventDateTime] [datetime] NOT NULL,
    [EventLevel] [nvarchar](100) NOT NULL,
    [UserName] [nvarchar](100) NOT NULL,
    [MachineName] [nvarchar](100) NOT NULL,
    [EventMessage] [nvarchar](max) NOT NULL,
    [ErrorSource] [nvarchar](100) NULL,
    [ErrorClass] [nvarchar](500) NULL,
    [ErrorMethod] [nvarchar](max) NULL,
    [ErrorMessage] [nvarchar](max) NULL,
    [InnerErrorMessage] [nvarchar](max) NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )
)
