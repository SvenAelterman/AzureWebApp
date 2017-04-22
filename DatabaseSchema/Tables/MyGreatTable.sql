CREATE TABLE [dbo].[MyGreatTable]
(
	[MyGreatTableId] INT NOT NULL IDENTITY(1,1),
	[GreatField] VARCHAR(25) NOT NULL,

	CONSTRAINT [PK_MyGreatTable] PRIMARY KEY (MyGreatTableId)
)
