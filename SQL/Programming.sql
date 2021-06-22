--Trigger para a criação de um novo ginasio em que o gestor tem de existir.
GO
CREATE TRIGGER AddGym ON GymCompany.Ginasio
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @gestor as VARCHAR(30);
	SELECT @gestor=Gestor FROM inserted;

	IF NOT EXISTS (SELECT Numero_CC FROM GymCompany.Pessoa WHERE Numero_CC=@gestor)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The manager %s is not present in the database as a person', 14, 1, @gestor);
	END
	IF NOT EXISTS (SELECT Numero_CC FROM GymCompany.Funcionario WHERE Numero_CC=@gestor)
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


--Trigger para a criação de uma instancia de aula: Aula e professor tem de existir.
GO
CREATE TRIGGER CreateCourse ON GymCompany.AulaInstancia
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @aula as VARCHAR(30);
	DECLARE @professor as INT;
	SELECT @aula=FK_Aula FROM inserted;
	SELECT @professor=FK_Professor FROM inserted;

	IF NOT EXISTS (SELECT Designacao FROM GymCompany.Aula WHERE Designacao=@aula)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The course %s is not present in the database', 14, 1, @aula);
	END
	IF NOT EXISTS (SELECT Numero_Funcionario FROM GymCompany.Professor WHERE Numero_Funcionario=@professor)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The teacher %s is not present in the database', 14, 1, @professor);
	END
END
GO


--Trigger para a criação de um Cliente: pessoa com este CC tem de existir.
GO
CREATE TRIGGER CreateClient ON GymCompany.Cliente
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @cc as INT;
	SELECT @cc=Numero_CC FROM inserted;

	IF NOT EXISTS (SELECT Numero_CC FROM GymCompany.Pessoa WHERE Numero_CC=@cc)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The person with cc %s is not in the database', 14, 1, @cc);
	END
END
GO


--Trigger para a Frequentou: Aluno tem de estar inscrito nesta Aula
GO
CREATE TRIGGER NewFrequentou ON GymCompany.Frequentou
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @aluno as INT;
	DECLARE @aula as VARCHAR(30);
	SELECT @aluno=Numero_Aluno FROM inserted;
	SELECT @aula=Codigo_Aula FROM inserted;

	IF NOT EXISTS (SELECT * FROM (GymCompany.AulaInstancia JOIN GymCompany.Inscrito
					ON FK_Aula=Designacao_Aula) WHERE Codigo=@aula AND Numero_Aluno=@aluno)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The client %s is not subscribed to this course', 14, 1, @aluno);
	END
END
GO


--Trigger para a criar novo funcionario: Pessoa tem de existir.
GO
CREATE TRIGGER CreateEmployee ON GymCompany.Funcionario
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @cc as INT;
	SELECT @cc=Numero_CC FROM inserted;

	IF NOT EXISTS (SELECT Numero_CC FROM GymCompany.Pessoa WHERE Numero_CC=@cc)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The person with cc %s is not in the database', 14, 1, @cc);
	END
END
GO


--Store Procedure para a criar novo inscrito
GO
CREATE PROC GymCompany.NewSub @num INT, @aula VARCHAR(30) 
AS
BEGIN
	IF NOT EXISTS (SELECT Numero_Cliente FROM GymCompany.Cliente WHERE Numero_Cliente=@num)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The client %s is not present in the database', 14, 1, @num);
	END
	ELSE IF NOT EXISTS (SELECT Designacao FROM GymCompany.Aula WHERE Designacao=@aula)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The course %s is not present in the database', 14, 1, @aula);
	END
	ELSE 
		INSERT INTO GymCompany.Aluno VALUES (@num);
		INSERT INTO GymCompany.Inscrito VALUES (@num, @aula);
END
GO


--Store procedure para colocar professor a lecionar uma aula
GO
CREATE PROC GymCompany.NewProf @numProf INT, @aula VARCHAR(30) 
AS
BEGIN
	IF NOT EXISTS (SELECT Numero_Funcionario FROM GymCompany.Funcionario WHERE Numero_Funcionario=@numProf)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The employee %s is not present in the database', 14, 1, @numProf);
	END
	ELSE IF NOT EXISTS (SELECT * FROM GymCompany.Funcionario WHERE Funcao='Personal Trainer' and Numero_Funcionario=@numProf)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The employee %s is not present in the database as a Personal Trainer to be able to teach this course', 14, 1, @numProf);
	END
	ELSE IF NOT EXISTS (SELECT Designacao FROM GymCompany.Aula WHERE Designacao=@aula)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The course %s is not present in the database', 14, 1, @aula);
	END
	ELSE 
		INSERT INTO GymCompany.Professor VALUES (@numProf);
		INSERT INTO GymCompany.Leciona VALUES (@numProf, @aula);
END
GO


--Trigger para Oferece: Ginasio e aula tem de existir
GO
CREATE TRIGGER NewOferece ON GymCompany.Oferece
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @nif as INT;
	DECLARE @aula as VARCHAR(30);
	SELECT @nif=NIF FROM inserted;
	SELECT @aula=Designacao FROM inserted;

	IF NOT EXISTS (SELECT NIF FROM GymCompany.Ginasio WHERE NIF=@nif)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The gym %s is not in the database', 14, 1, @nif);
	END
	IF NOT EXISTS (SELECT Designacao FROM GymCompany.Aula WHERE Designacao=@aula)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The course %s is not in the database', 14, 1, @aula);
	END
END
GO


--Trigger para Possui: Ginasio e equipamento tem de existir
GO
CREATE TRIGGER NewPossui ON GymCompany.Possui
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @nif as INT;
	DECLARE @equip as VARCHAR(30);
	SELECT @nif=NIF FROM inserted;
	SELECT @equip=Designacao FROM inserted;

	IF NOT EXISTS (SELECT NIF FROM GymCompany.Ginasio WHERE NIF=@nif)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The gym %s is not in the database', 14, 1, @nif);
	END
	IF NOT EXISTS (SELECT Designacao FROM GymCompany.Equipamento WHERE Designacao=@equip)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The equipment %s is not in the database', 14, 1, @equip);
	END
END
GO


--Trigger para criar Professor: funcionario tem de existir
GO
CREATE TRIGGER CreateProfessor ON GymCompany.Professor
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @num as INT;
	SELECT @num=Numero_Funcionario FROM inserted;

	IF NOT EXISTS (SELECT Numero_Funcionario FROM GymCompany.Funconario WHERE Numero_Funcionario=@num)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The employee %s is not in the database', 14, 1, @num);
	END
END
GO


--Trigger para Tem_Clientes: Ginasio e cliente tem de existir
GO
CREATE TRIGGER New_Tem_Clientes ON GymCompany.Tem_Clientes
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @nif as INT;
	DECLARE @num as INT;
	SELECT @nif=NIF FROM inserted;
	SELECT @num=Numero_Cliente FROM inserted;

	IF NOT EXISTS (SELECT NIF FROM GymCompany.Ginasio WHERE NIF=@nif)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The gym %s is not in the database', 14, 1, @nif);
	END
	IF NOT EXISTS (SELECT Numero_Cliente FROM GymCompany.Cliente WHERE Numero_Cliente=@num)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The client %s is not in the database', 14, 1, @num);
	END
END
GO


--Trigger para Tem_Funcionarios: Ginasio e funcionario tem de existir
GO
CREATE TRIGGER New_Tem_Funcionarios ON GymCompany.Tem_Funcionarios
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @nif as INT;
	DECLARE @num as INT;
	SELECT @nif=NIF FROM inserted;
	SELECT @num=Numero_Funcionario FROM inserted;

	IF NOT EXISTS (SELECT NIF FROM GymCompany.Ginasio WHERE NIF=@nif)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The gym %s is not in the database', 14, 1, @nif);
	END
	IF NOT EXISTS (SELECT Numero_Funcionario FROM GymCompany.Funcionario WHERE Numero_Funcionario=@num)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The employee %s is not in the database', 14, 1, @num);
	END
END
GO


--Trigger para Vende: Ginasio e produto tem de existir
GO
CREATE TRIGGER New_Vende ON GymCompany.Vende
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @nif as INT;
	DECLARE @codigo as VARCHAR(15);
	SELECT @nif=NIF FROM inserted;
	SELECT @codigo=Codigo FROM inserted;

	IF NOT EXISTS (SELECT NIF FROM GymCompany.Ginasio WHERE NIF=@nif)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The gym %s is not in the database', 14, 1, @nif);
	END
	IF NOT EXISTS (SELECT Codigo FROM GymCompany.Produto WHERE Codigo=@codigo)
	BEGIN
		ROLLBACK TRAN;
		RAISERROR ('The product %s is not in the database', 14, 1, @codigo);
	END
END
GO


--Store Procedure para remover cliente: tem de eliminar este cliente da tabela Tem_Clientes
--e se for aluno remover da tabela Inscrito e Aluno
GO
CREATE PROC GymCompany.RemoveClient @num INT
AS
BEGIN
	IF EXISTS (SELECT Numero_Cliente FROM GymCompany.Aluno WHERE Numero_Cliente=@num) --verificar se é aluno
	BEGIN
		DELETE FROM GymCompany.Inscrito
		WHERE Numero_Aluno = @num;

		DELETE FROM GymCompany.Aluno
		WHERE Numero_Cliente = @num;
	END

	DELETE FROM GymCompany.Tem_Clientes
	WHERE Numero_Cliente = @num;

	DELETE FROM GymCompany.Cliente
	WHERE Numero_Cliente = @num;
END
GO


--Store Procedure para remover funcionario: tem de eliminar este funcionario da tabela Tem_Funcionarios
--e se for professor remover da tabela Leciona e Professor
GO
CREATE PROC GymCompany.RemoveEmployee @num INT
AS
BEGIN
	IF EXISTS (SELECT Numero_Funcionario FROM GymCompany.Professor WHERE Numero_Funcionario=@num) --verificar se é professor
	BEGIN
		DELETE FROM GymCompany.Leciona
		WHERE Numero_Professor = @num;

		DELETE FROM GymCompany.Professor
		WHERE Numero_Funcionario = @num;
	END

	DELETE FROM GymCompany.Tem_Funcionarios
	WHERE Numero_Funcionario = @num;

	DELETE FROM GymCompany.Funcionario
	WHERE Numero_Funcionario = @num;
END
GO


--Store Procedure para remover pessoa: tem de verificar se é funcionario ou cliente.
--Se for funcionario chama o RemoveEmployee
--Se for cliente chama o RemoveClient
--Por fim eliminar a Pessoa
GO
CREATE PROC GymCompany.RemovePerson @cc INT
AS
BEGIN
	DECLARE @num AS INT;

	IF EXISTS (SELECT Numero_Cliente FROM GymCompany.Cliente WHERE Numero_CC=@cc) --verificar se é cliente
	BEGIN
		SELECT @num=Numero_Cliente FROM GymCompany.Cliente WHERE Numero_CC=@cc
		
		EXEC GymCompany.RemoveClient @num;
	END

	IF EXISTS (SELECT Numero_Funcionario FROM GymCompany.Funcionario WHERE Numero_CC=@cc) --verificar se é funcionario
	BEGIN
		SELECT @num=Numero_Funcionario FROM GymCompany.Funcionario WHERE Numero_CC=@cc
		
		EXEC GymCompany.RemoveEmployee @num;
	END

	DELETE FROM GymCompany.Pessoa
	WHERE Numero_CC = @cc;
END
GO


--Store Procedure para remover produto: tem de eliminar este produto da tabelas:
--Vende e Produto
GO
CREATE PROC GymCompany.RemoveProduct @cod INT
AS
BEGIN
	DELETE FROM GymCompany.Vende
	WHERE Codigo=@cod

	DELETE FROM GymCompany.Produto
	WHERE Codigo=@cod
END
GO


--Store Procedure para remover equipamento: tem de eliminar este equipamento das tabelas:
--Possui e Equipamento
GO
CREATE PROC GymCompany.RemoveEquipment @desig INT
AS
BEGIN
	DELETE FROM GymCompany.Possui
	WHERE Designacao=@desig

	DELETE FROM GymCompany.Equipamento
	WHERE Designacao=@desig
END
GO


--Store Procedure para remover aula: tem de eliminar esta aula da tabelas: 
--Oferece, Inscrito, Leciona e Aula
GO
CREATE PROC GymCompany.RemoveCourse @desig INT
AS
BEGIN
	DELETE FROM GymCompany.Oferece
	WHERE Designacao=@desig

	DELETE FROM GymCompany.Inscrito
	WHERE Designacao_Aula=@desig

	DELETE FROM GymCompany.Leciona
	WHERE Designacao_Aula=@desig

	DELETE FROM GymCompany.Aula
	WHERE Designacao=@desig
END
GO