DROP PROCEDURE wartAdd
GO

CREATE PROCEDURE [dbo].[wartAdd]
	@Liczba int,
	@Wiadomosc NVARCHAR (60),
	@Czas DATETIME2 (7),
	@Id int OUTPUT
AS
	INSERT into Wartosc (Liczba, Wiadomosc, Czas) VALUES (@Liczba, @Wiadomosc, @Czas)
	SET @Id = @@IDENTITY