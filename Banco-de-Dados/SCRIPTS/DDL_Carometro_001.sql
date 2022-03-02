CREATE DATABASE DM_CAROMETRO;
GO


USE DM_CAROMETRO;
GO


CREATE TABLE escola(
idEscola INT PRIMARY KEY IDENTITY(1,1),
nomeEscola VARCHAR(30) NOT NULL,
endereco VARCHAR(150) NOT NULL UNIQUE,
numero INT NOT NULL UNIQUE
);
GO


CREATE TABLE turma(
idTurma INT PRIMARY KEY IDENTITY(1,1),
letraTurma VARCHAR(1) NOT NULL
);
GO


CREATE TABLE grauEscolar(
idGrau INT PRIMARY KEY IDENTITY(1,1),
nomeGrau VARCHAR(30) NOT NULL
);
GO


CREATE TABLE serie(
idSerie INT PRIMARY KEY IDENTITY(1,1),
idGrau INT FOREIGN KEY REFERENCES grauEscolar(idGrau),
numeroSerie VARCHAR(10) NOT NULL
);
GO



CREATE TABLE professor(
idProfessor INT PRIMARY KEY IDENTITY(1,1),
idEscola INT FOREIGN KEY REFERENCES escola(idEscola),
nomeProfessor VARCHAR(30),
email VARCHAR(200) UNIQUE NOT NULL,
senha VARCHAR(20) NOT NULL
);
GO


CREATE TABLE aluno(
idAluno INT PRIMARY KEY IDENTITY(1,1),
idEscola INT FOREIGN KEY REFERENCES escola(idEscola),
idSerie INT FOREIGN KEY REFERENCES serie(idSerie),
idTurma INT FOREIGN KEY REFERENCES turma(idTurma),
idFace VARCHAR(50) UNIQUE NOT NULL,
nomeAluno VARCHAR(30) NOT NULL,
cpf VARCHAR(11) NOT NULL UNIQUE,
rm VARCHAR(4) NOT NULL,
dataNascimento DATETIME NOT NULL,
foto VARCHAR(300) NOT NULL
);

