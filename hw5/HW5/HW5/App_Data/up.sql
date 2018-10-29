CREATE TABLE [dbo].[Requests]
(
	[ID]			INT IDENTITY (1,1)	NOT NULL,
	[FirstName]		NVARCHAR(20)		NOT NULL,
	[LastName]		NVARCHAR(20)		NOT NULL,
	[PhoneNumber]	NVARCHAR(12)		NOT NULL,
	[ApartmentName]	NVARCHAR(30)		NOT NULL,
	[UnitNumber]	INT					NOT NULL,
	[Explanation]	NVARCHAR(60)		NOT NULL,
	[Permission]	BIT					NOT NULL,
	CONSTRAINT [PK_dbo.Requests] PRIMARY KEY CLUSTERED ([ID] ASC)
);

INSERT INTO [dbo].[Requests] (FirstName, LastName, PhoneNumber, ApartmentName, UnitNumber, Explanation, Permission) VALUES
	('Xueying', 'Zhang', '450-123-1122', 'Powell', 11, 'Important', 0),
	('Zhuo', 'Liu', '120-899-4882', 'LA', 5, 'Important', 0),
	('Chunguang', 'Lyu', '852-478-1234', 'Oregon', 10, ' Broken', 1),
	('Jing', 'Li', '777-888-9999', 'Bejing', 1, 'Bulb', 1),
	('Zha', 'Na', '447-567-3321', 'Shanghai', 8, 'Does not work', 0)
GO
