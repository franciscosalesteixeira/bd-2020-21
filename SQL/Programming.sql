--Trigger para a criação de um novo ginasio em que o gestor tem de existir.
GO
CREATE TRIGGER AddGym ON GymCompany.Ginasio
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @gestor as varchar(30);
	SELECT @gestor=Gestor FROM inserted;

	IF NOT EXISTS (SELECT nome FROM GymCompany.Pessoa WHERE nome=@gestor)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The manager %s is not present in the database as a person', 14, 1, @gestor);
	END
	IF NOT EXISTS (SELECT GymCompany.Pessoa.Numero_CC FROM (GymCompany.Pessoa JOIN GymCompany.Funcionario 
					ON GymCompany.Pessoa.Numero_CC = GymCompany.Funcionario.Numero_CC) WHERE nome=@gestor)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The manager %s is not present in the database as a employee', 14, 1, @gestor);
	END
END
GO


--Store Procedure para remover ginasio: tem de remover todos os funcionários, produtos, 
--equipamentos, clientes e aulas associados a este ginasio.
GO
CREATE PROC GymCompany.RemoveGym @nif INT
AS
BEGIN
	DELETE FROM GymCompany.Oferece
	WHERE NIF = @nif;

	DELETE FROM GymCompany.Possui
	WHERE NIF = @nif;

	DELETE FROM GymCompany.Tem_Clientes
	WHERE NIF = @nif;

	DELETE FROM GymCompany.Tem_Funcionarios
	WHERE NIF = @nif;

	DELETE FROM GymCompany.Vende
	WHERE NIF = @nif;

	DELETE FROM GymCompany.Ginasio
	WHERE NIF = @nif;
END
GO

--tests
SELECT * FROM GymCompany.Ginasio
SELECT * FROM GymCompany.Pessoa WHERE Numero_CC=212314321
SELECT * FROM GymCompany.Funcionario
UPDATE GymCompany.Ginasio SET Gestor='Sérgio Oliveira' WHERE NIF=123
