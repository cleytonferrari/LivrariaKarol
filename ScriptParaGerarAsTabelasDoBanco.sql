/* 
crie um banco de dados no SQL Server chamado: KarolBanco
Uma vez criado o banco, crie as seguintes tabelas:
*/

CREATE TABLE Autor(
	AutorId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome  varchar(75) NULL,
	Email varchar(75) NULL,
	Biografia varchar(500) NULL
);

CREATE TABLE Livro(
	LivroId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome varchar(100) NULL,
	DataDaPublicacao date NULL,
	Prefacio varchar(50) NULL,
	AutorId int NULL,
	Editora varchar(50) NULL
);