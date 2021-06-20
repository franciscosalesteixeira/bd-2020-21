CREATE SCHEMA GymCompany;
GO

CREATE TABLE GymCompany.Ginasio (
	NIF			INT				NOT NULL,
	Telefone	INT				NOT NULL,
	Morada		VARCHAR(50)		NOT NULL,	
	Gestor		VARCHAR(30)		NOT NULL,
	PRIMARY KEY (NIF),
	UNIQUE (Telefone)
);

CREATE TABLE GymCompany.Pessoa (
	Numero_CC	INT				NOT NULL,
	Nome		VARCHAR(30)		NOT NULL,
	Telefone	INT,	
	Morada		VARCHAR(50),
	Email		VARCHAR(30),
	PRIMARY KEY (Numero_CC),
	UNIQUE (Nome, Telefone, Email)
);

CREATE TABLE GymCompany.Funcionario (
	Numero_CC				INT				NOT NULL,
	Numero_Funcionario		INT				NOT NULL,
	Funcao					VARCHAR(10)		NOT NULL,	
	Salario					DECIMAL(10,2)	NOT NULL	CHECK(Salario > 740),
	PRIMARY KEY (Numero_CC),
	UNIQUE (Numero_Funcionario)
);

CREATE TABLE GymCompany.Cliente (
	Numero_CC			INT				NOT NULL,
	Numero_Cliente		INT				NOT NULL,
	Tipo_Subscricao		VARCHAR(10)		NOT NULL,
	PRIMARY KEY (Numero_CC),
	UNIQUE (Numero_Cliente)
);

CREATE TABLE GymCompany.Tem_Funcionarios (
	NIF						INT		NOT NULL,
	Numero_Funcionario		INT		NOT NULL,
	PRIMARY KEY (NIF, Numero_Funcionario)
);

CREATE TABLE GymCompany.Tem_Clientes (
	NIF					INT		NOT NULL,
	Numero_Cliente		INT		NOT NULL,
	PRIMARY KEY (NIF, Numero_Cliente)
);

CREATE TABLE GymCompany.Equipamento (
	Designacao			VARCHAR(30)		NOT NULL,
	Tipo_Equipamento	VARCHAR(30),
	Quantidade			INT,
	PRIMARY KEY (Designacao)
);

CREATE TABLE GymCompany.Produto (
	Codigo		VARCHAR(15)		NOT NULL,
	Nome		VARCHAR(30)		NOT NULL,
	Preco		DECIMAL(4,2)	NOT NULL,
	Stock		INT,
	PRIMARY KEY (Codigo),
	UNIQUE (Nome)
);

CREATE TABLE GymCompany.Possui (
	NIF				INT				NOT NULL,
	Designacao		VARCHAR(30)		NOT NULL,
	PRIMARY KEY (NIF, Designacao)
);

CREATE TABLE GymCompany.Oferece (
	NIF				INT				NOT NULL,
	Designacao		VARCHAR(30)		NOT NULL,
	PRIMARY KEY (NIF, Designacao)
);

CREATE TABLE GymCompany.Vende (
	NIF			INT				NOT NULL,
	Codigo		VARCHAR(15)		NOT NULL,
	PRIMARY KEY (NIF, Codigo)
);

CREATE TABLE GymCompany.Professor (
	Numero_Funcionario		INT		NOT NULL,
	PRIMARY KEY (Numero_Funcionario)
);

CREATE TABLE GymCompany.Aluno (
	Numero_Cliente		INT		NOT NULL,
	PRIMARY KEY (Numero_Cliente)
);

CREATE TABLE GymCompany.Aula (
	Designacao		VARCHAR(30)		NOT NULL,
	Tipo_Aula		VARCHAR(30),
	Hora			TIME			NOT NULL,
	Dias_Semana		VARCHAR(7)		NOT NULL,
	Nr_Max_Alunos	INT				NOT NULL,
	PRIMARY KEY (Designacao)
);

CREATE TABLE GymCompany.AulaInstancia (
	FK_Aula			VARCHAR(30)		NOT NULL,
	FK_Professor	INT				NOT NULL,
	Codigo			VARCHAR(30)		NOT NULL,
	PRIMARY KEY(FK_Aula, FK_Professor),
	UNIQUE (Codigo)
);

CREATE TABLE GymCompany.Frequentou (
	Numero_Aluno	INT				NOT NULL,
	Codigo_Aula		VARCHAR(30)		NOT NULL,
	PRIMARY KEY(Numero_Aluno, Codigo_Aula)
)

CREATE TABLE GymCompany.Inscrito (
	Numero_Aluno		INT				NOT NULL,
	Designacao_Aula		VARCHAR(30)		NOT NULL,
	PRIMARY KEY(Numero_Aluno, Designacao_Aula)
);

CREATE TABLE GymCompany.Leciona (
	Numero_Professor	INT				NOT NULL,
	Designacao_Aula		VARCHAR(30)		NOT NULL,
	PRIMARY KEY(Numero_Professor, Designacao_Aula)
);

CREATE TABLE GymCompany.Login (
	Username		VARCHAR(30)		NOT NULL,
	Pass			VARCHAR(30)		NOT NULL,
	PRIMARY KEY (Username)
);

ALTER TABLE GymCompany.Funcionario
	ADD FOREIGN KEY (Numero_CC) REFERENCES GymCompany.Pessoa(Numero_CC);

ALTER TABLE GymCompany.Cliente
	ADD FOREIGN KEY (Numero_CC) REFERENCES GymCompany.Pessoa(Numero_CC);

ALTER TABLE GymCompany.Tem_Funcionarios
	ADD FOREIGN KEY (Numero_Funcionario) REFERENCES GymCompany.Funcionario(Numero_Funcionario);

ALTER TABLE GymCompany.Tem_Funcionarios
	ADD FOREIGN KEY (NIF) REFERENCES GymCompany.Ginasio(NIF);

ALTER TABLE GymCompany.Tem_Clientes
	ADD FOREIGN KEY (NIF) REFERENCES GymCompany.Ginasio(NIF);

ALTER TABLE GymCompany.Tem_Clientes
	ADD FOREIGN KEY (Numero_Cliente) REFERENCES GymCompany.Cliente(Numero_Cliente);

ALTER TABLE GymCompany.Possui
	ADD FOREIGN KEY (NIF) REFERENCES GymCompany.Ginasio(NIF);

ALTER TABLE GymCompany.Possui
	ADD FOREIGN KEY (Designacao) REFERENCES GymCompany.Equipamento(Designacao);

ALTER TABLE GymCompany.Oferece
	ADD FOREIGN KEY (NIF) REFERENCES GymCompany.Ginasio(NIF);

ALTER TABLE GymCompany.Oferece
	ADD FOREIGN KEY (Designacao) REFERENCES GymCompany.Aula(Designacao);

ALTER TABLE GymCompany.Vende
	ADD FOREIGN KEY (NIF) REFERENCES GymCompany.Ginasio(NIF);

ALTER TABLE GymCompany.Vende
	ADD FOREIGN KEY (Codigo) REFERENCES GymCompany.Produto(Codigo);

ALTER TABLE GymCompany.Professor
	ADD FOREIGN KEY (Numero_Funcionario) REFERENCES GymCompany.Funcionario(Numero_Funcionario);

ALTER TABLE GymCompany.Aluno
	ADD FOREIGN KEY (Numero_Cliente) REFERENCES GymCompany.Cliente(Numero_Cliente);

ALTER TABLE GymCompany.AulaInstancia
	ADD FOREIGN KEY (FK_Aula) REFERENCES GymCompany.Aula(Designacao);

ALTER TABLE GymCompany.AulaInstancia
	ADD FOREIGN KEY (FK_Professor) REFERENCES GymCompany.Professor(Numero_funcionario);

ALTER TABLE GymCompany.Frequentou
	ADD FOREIGN KEY (Numero_Aluno) REFERENCES GymCompany.Aluno(Numero_Cliente);

ALTER TABLE GymCompany.Frequentou
	ADD FOREIGN KEY (Codigo_Aula) REFERENCES GymCompany.AulaInstancia(Codigo);

ALTER TABLE GymCompany.Inscrito
	ADD FOREIGN KEY (Numero_Aluno) REFERENCES GymCompany.Aluno(Numero_Cliente);

ALTER TABLE GymCompany.Inscrito
	ADD FOREIGN KEY (Designacao_Aula) REFERENCES GymCompany.Aula(Designacao);

ALTER TABLE GymCompany.Leciona
	ADD FOREIGN KEY (Numero_Professor) REFERENCES GymCompany.Professor(Numero_Funcionario);

ALTER TABLE GymCompany.Leciona
	ADD FOREIGN KEY (Designacao_Aula) REFERENCES GymCompany.Aula(Designacao);