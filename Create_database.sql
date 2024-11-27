-- Tabela de Equipes
CREATE TABLE equipe (
    idEquipe INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL
);

-- Tabela de Campeonato
CREATE TABLE campeonato (
    idCampeonato INT PRIMARY KEY AUTO_INCREMENT,
    ano INT NOT NULL,
    idEquipeVencedora INT,
    FOREIGN KEY (idEquipeVencedora) REFERENCES equipe(idEquipe)
);

-- Tabela de Partida
CREATE TABLE partida (
    idPartida INT PRIMARY KEY AUTO_INCREMENT,
    placar VARCHAR(50) NOT NULL,
    data DATE NOT NULL,
    hora TIME NOT NULL,
    etapa VARCHAR(50) NOT NULL,
    idEquipeAzul INT NOT NULL,
    idEquipeVermelha INT NOT NULL,
    idCampeonato INT NOT NULL,
    FOREIGN KEY (idEquipeAzul) REFERENCES equipe(idEquipe),
    FOREIGN KEY (idEquipeVermelha) REFERENCES equipe(idEquipe),
    FOREIGN KEY (idCampeonato) REFERENCES campeonato(idCampeonato)
);

-- Tabela de Usuários
CREATE TABLE usuario (
    idUsuario INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    ranque VARCHAR(50) NOT NULL,
    posicao VARCHAR(50) NOT NULL,
    idEquipe INT NOT NULL,
    FOREIGN KEY (idEquipe) REFERENCES equipe(idEquipe)
);

-- Tabela de PartidaUsuario
CREATE TABLE partidaUsuario (
    idPartidaUsuario INT PRIMARY KEY AUTO_INCREMENT,
    idUsuario INT NOT NULL,
    idPartida INT NOT NULL,
    kills INT DEFAULT 0,
    deaths INT DEFAULT 0,
    assists INT DEFAULT 0,
    idCampeao INT NOT NULL,
    nomeCampeao VARCHAR(255) NOT NULL,
    classeCampeao VARCHAR(255) NOT NULL,
    FOREIGN KEY (idUsuario) REFERENCES usuario(idUsuario),
    FOREIGN KEY (idPartida) REFERENCES partida(idPartida)
);

-- Tabela de Itens
CREATE TABLE itens (
    idItem INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    AP INT DEFAULT 0,
    penetMagica INT DEFAULT 0,
    regMana INT DEFAULT 0,
    vida INT DEFAULT 0,
    armadura INT DEFAULT 0,
    resistMagica INT DEFAULT 0,
    danAtaque INT DEFAULT 0,
    velocAtaque FLOAT DEFAULT 0.0,
    escudoConcedido INT DEFAULT 0,
    curaConcedida INT DEFAULT 0
);

-- Tabela de ItensPatUsuario
CREATE TABLE itensPatUsuario (
    idPartidaUsuario INT NOT NULL,
    idItem INT NOT NULL,
    PRIMARY KEY (idPartidaUsuario, idItem),
    FOREIGN KEY (idPartidaUsuario) REFERENCES partidaUsuario(idPartidaUsuario),
    FOREIGN KEY (idItem) REFERENCES itens(idItem)
);
