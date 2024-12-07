INSERT INTO equipe (nome) VALUES 
('Gen.G'),
('Bilibili Gaming'),
('Hanwha Life Esports'),
('Top Esports'),
('G2 Esports'),
('T1'),
('Dplus Kia'),
('Beijing JDG Intel Esports'),
('kt Rolster'),
('Suzhou LNG Ninebot Esports');
SELECT * FROM equipe;

-- Gen.G
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Kim Ki-in', 'Challenger', 'Top', 1),
('Kim Geon-bu', 'Challenger', 'Jungle', 1),
('Jeong Ji-hoon', 'Challenger', 'Mid', 1),
('Park Jae-hyuk', 'Challenger', 'ADC', 1),
('Joo Min-kyu', 'Challenger', 'Support', 1);

-- Bilibili Gaming
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Chen Zebin', 'Challenger', 'Top', 2),
('Peng Lixun', 'Challenger', 'Jungle', 2),
('Zhuo Ding', 'Challenger', 'Mid', 2),
('Zhao Jiahao', 'Challenger', 'ADC', 2),
('Luo Wenjun', 'Challenger', 'Support', 2);


-- Hanwha Life Esports
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Choi Woo-je', 'Challenger', 'Top', 3),
('Han Wang-ho', 'Challenger', 'Jungle', 3),
('Kim Geon-woo', 'Challenger', 'Mid', 3),
('Park Do-hyeon', 'Challenger', 'ADC', 3),
('Yoo Hwan-joong', 'Challenger', 'Support', 3);

-- Top Esports
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Bai Jiahao', 'Challenger', 'Top', 4),
('Gao Tianliang', 'Challenger', 'Jungle', 4),
('Su Hanwei', 'Challenger', 'Mid', 4),
('Yu Wenbo', 'Challenger', 'ADC', 4),
('Tian Ye', 'Challenger', 'Support', 4);

-- G2 Esports
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Sergen Çelik', 'Challenger', 'Top', 5),
('Rudy Semaan', 'Challenger', 'Jungle', 5),
('Rasmus Winther', 'Challenger', 'Mid', 5),
('Steven Liv', 'Challenger', 'ADC', 5),
('Labros Papoutsakis', 'Challenger', 'Support', 5);


-- T1
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Choi Hyeon-joon', 'Challenger', 'Top', 6),
('Moon Hyeon-jun', 'Challenger', 'Jungle', 6),
('Lee Sang-hyeok', 'Challenger', 'Mid', 6),
('Lee Min-hyeong', 'Challenger', 'ADC', 6),
('Ryu Min-seok', 'Challenger', 'Support', 6);

-- Dplus KIA
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Jeon Si-woo', 'Challenger', 'Top', 7),
('Choi Yong-hyeok', 'Challenger', 'Jungle', 7),
('Heo Su', 'Challenger', 'Mid', 7),
('Kim Ha-ram', 'Challenger', 'ADC', 7),
('Cho Geon-hee', 'Challenger', 'Support', 7);


-- Beijing JDG Intel Esports
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Hu Jiale', 'Challenger', 'Top', 8),
('Seo Jin-hyeok', 'Challenger', 'Jungle', 8),
('Zeng Qi', 'Challenger', 'Mid', 8),
('Park Jae-hyuk', 'Challenger', 'ADC', 8),
('Lou Yunfeng', 'Challenger', 'Support', 8);

-- KT Rolster
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Kim Gi-in', 'Challenger', 'Top', 9),
('Mun U-chan', 'Challenger', 'Jungle', 9),
('Gwak Bo-seong', 'Challenger', 'Mid', 9),
('Kim Ha-ram', 'Challenger', 'ADC', 9),
('Son Si-woo', 'Challenger', 'Support', 9);
-- Suzhou LNG Ninebot Esports
INSERT INTO usuario (nome, ranque, posicao, idEquipe) VALUES 
('Hu Zhiwei', 'Challenger', 'Top', 10),
('Wei Lian', 'Challenger', 'Jungle', 10),
('Lee Ye-chan', 'Challenger', 'Mid', 10),
('Chen Wei', 'Challenger', 'ADC', 10),
('Luo Siyuan', 'Challenger', 'Support', 10);


INSERT INTO campeonato (ano, idEquipeVencedora) VALUES
(2020, 1), -- Gen.G venceu
(2021, 6), -- T1 venceu
(2022, 2), -- Bilibili Gaming venceu
(2023, 8), -- Beijing JDG Intel Esports venceu
(2024, 5); -- G2 Esports venceu


-- Quartas de final
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('2-1', '2020-11-01', '18:00:00', 'Quartas de Final', 1, 2, 1), -- Gen.G vs Bilibili Gaming
('3-0', '2020-11-02', '19:00:00', 'Quartas de Final', 3, 4, 1), -- Hanwha Life Esports vs Top Esports
('2-3', '2020-11-03', '20:00:00', 'Quartas de Final', 5, 6, 1), -- G2 Esports vs T1
('1-2', '2020-11-04', '21:00:00', 'Quartas de Final', 7, 8, 1); -- Dplus Kia vs Beijing JDG Intel Esports

-- Semifinais
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-2', '2020-11-07', '18:00:00', 'Semifinal', 1, 3, 1), -- Gen.G vs Hanwha Life Esports
('0-3', '2020-11-08', '19:00:00', 'Semifinal', 6, 8, 1); -- T1 vs Beijing JDG Intel Esports

-- Final
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-1', '2020-11-14', '20:00:00', 'Final', 1, 8, 1); -- Gen.G vs Beijing JDG Intel Esports

INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-1', '2021-11-01', '18:00:00', 'Quartas de Final', 1, 2, 2), -- Gen.G vs Bilibili Gaming
('2-3', '2021-11-02', '19:00:00', 'Quartas de Final', 3, 4, 2), -- Hanwha Life Esports vs Top Esports
('3-0', '2021-11-03', '20:00:00', 'Quartas de Final', 5, 6, 2), -- G2 Esports vs T1
('1-2', '2021-11-04', '21:00:00', 'Quartas de Final', 7, 8, 2); -- Dplus Kia vs Beijing JDG Intel Esports
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-2', '2021-11-07', '18:00:00', 'Semifinal', 1, 4, 2), -- Gen.G vs Top Esports
('2-3', '2021-11-08', '19:00:00', 'Semifinal', 6, 8, 2); -- T1 vs Beijing JDG Intel Esports
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-1', '2021-11-14', '20:00:00', 'Final', 4, 6, 2); -- Top Esports vs T1

-- Quartas de Final para 2022
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('2-0', '2022-11-01', '18:00:00', 'Quartas de Final', 2, 3, 3), -- Bilibili Gaming vs Hanwha Life Esports
('3-1', '2022-11-02', '19:00:00', 'Quartas de Final', 4, 5, 3), -- Top Esports vs G2 Esports
('1-3', '2022-11-03', '20:00:00', 'Quartas de Final', 6, 7, 3), -- T1 vs Dplus Kia
('2-3', '2022-11-04', '21:00:00', 'Quartas de Final', 8, 9, 3); -- Beijing JDG Intel Esports vs kt Rolster

-- Semifinais para 2022
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-1', '2022-11-07', '18:00:00', 'Semifinal', 2, 4, 3), -- Bilibili Gaming vs Top Esports
('3-2', '2022-11-08', '19:00:00', 'Semifinal', 7, 8, 3); -- Dplus Kia vs Beijing JDG Intel Esports

-- Final para 2022
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-0', '2022-11-14', '20:00:00', 'Final', 2, 7, 3); -- Bilibili Gaming vs Dplus Kia

-- Quartas de final para 2023
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('2-0', '2023-11-01', '18:00:00', 'Quartas de Final', 1, 5, 3), -- Gen.G vs G2 Esports
('3-2', '2023-11-02', '19:00:00', 'Quartas de Final', 2, 6, 3), -- Bilibili Gaming vs T1
('1-3', '2023-11-03', '20:00:00', 'Quartas de Final', 3, 7, 3), -- Hanwha Life Esports vs Dplus Kia
('2-3', '2023-11-04', '21:00:00', 'Quartas de Final', 4, 8, 3); -- Top Esports vs Beijing JDG Intel Esports

-- Semifinais para 2023
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('1-3', '2023-11-07', '18:00:00', 'Semifinal', 1, 2, 3), -- Gen.G vs Bilibili Gaming
('0-3', '2023-11-08', '19:00:00', 'Semifinal', 7, 8, 3); -- Dplus Kia vs Beijing JDG Intel Esports

-- Final para 2023
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('2-3', '2023-11-14', '20:00:00', 'Final', 2, 8, 3); -- Bilibili Gaming vs Beijing JDG Intel Esports
-- Quartas de final para 2024
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('2-1', '2024-11-01', '18:00:00', 'Quartas de Final', 1, 2, 5), -- Gen.G vs Bilibili Gaming
('1-3', '2024-11-02', '19:00:00', 'Quartas de Final', 3, 5, 5), -- Hanwha Life Esports vs G2 Esports
('3-2', '2024-11-03', '20:00:00', 'Quartas de Final', 6, 7, 5), -- T1 vs Dplus Kia
('0-3', '2024-11-04', '21:00:00', 'Quartas de Final', 8, 10, 5); -- Beijing JDG Intel Esports vs LNG Ninebot Esports

-- Semifinais para 2024
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-0', '2024-11-07', '18:00:00', 'Semifinal', 1, 5, 5), -- Gen.G vs G2 Esports
('2-3', '2024-11-08', '19:00:00', 'Semifinal', 6, 10, 5); -- T1 vs LNG Ninebot Esports

-- Final para 2024
INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato) VALUES
('3-1', '2024-11-14', '20:00:00', 'Final', 5, 10, 5); -- G2 Esports vs LNG Ninebot Esports


-- Jogadores da equipe Gen.G (idEquipe = 1)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(1, 1, 5, 3, 8, 101, 'Azir', 'Mage'), -- Jogador 1 de Gen.G
(2, 1, 2, 4, 12, 67, 'Vayne', 'Marksman'), -- Jogador 2 de Gen.G
(3, 1, 8, 2, 6, 266, 'Aatrox', 'Fighter'), -- Jogador 3 de Gen.G
(4, 1, 1, 5, 15, 412, 'Thresh', 'Support'), -- Jogador 4 de Gen.G
(5, 1, 3, 3, 10, 76, 'Nidalee', 'Assassin'); -- Jogador 5 de Gen.G

-- Jogadores da equipe Bilibili Gaming (idEquipe = 2)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(6, 1, 4, 6, 5, 39, 'Irelia', 'Fighter'), -- Jogador 1 de Bilibili Gaming
(7, 1, 2, 7, 9, 18, 'Tristana', 'Marksman'), -- Jogador 2 de Bilibili Gaming
(8, 1, 6, 4, 3, 157, 'Yasuo', 'Fighter'), -- Jogador 3 de Bilibili Gaming
(9, 1, 0, 8, 12, 350, 'Yuumi', 'Support'), -- Jogador 4 de Bilibili Gaming
(10, 1, 5, 5, 7, 64, 'Gragas', 'Mage'); -- Jogador 5 de Bilibili Gaming


-- Jogadores da equipe Hanwha Life Esports (idEquipe = 3)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(11, 2, 7, 1, 10, 55, 'Kassadin', 'Mage'), -- Jogador 1 de Hanwha Life Esports
(12, 2, 5, 2, 8, 523, 'Aphelios', 'Marksman'), -- Jogador 2 de Hanwha Life Esports
(13, 2, 4, 0, 12, 120, 'Hecarim', 'Fighter'), -- Jogador 3 de Hanwha Life Esports
(14, 2, 0, 1, 20, 350, 'Yuumi', 'Support'), -- Jogador 4 de Hanwha Life Esports
(15, 2, 6, 3, 5, 10, 'Kayle', 'Fighter'); -- Jogador 5 de Hanwha Life Esports

-- Jogadores da equipe Top Esports (idEquipe = 4)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(16, 2, 2, 5, 3, 777, 'Yone', 'Fighter'), -- Jogador 1 de Top Esports
(17, 2, 0, 6, 2, 18, 'Tristana', 'Marksman'), -- Jogador 2 de Top Esports
(18, 2, 1, 7, 1, 80, 'Pantheon', 'Support'), -- Jogador 3 de Top Esports
(19, 2, 0, 8, 4, 432, 'Amumu', 'Tank'), -- Jogador 4 de Top Esports
(20, 2, 3, 6, 6, 30, 'Ryze', 'Mage'); -- Jogador 5 de Top Esports

-- Jogadores da equipe G2 Esports (idEquipe = 5)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(21, 3, 6, 4, 9, 164, 'Camille', 'Fighter'), -- Jogador 1 de G2 Esports
(22, 3, 4, 6, 10, 203, 'Kindred', 'Marksman'), -- Jogador 2 de G2 Esports
(23, 3, 3, 7, 12, 105, 'Twisted Fate', 'Mage'), -- Jogador 3 de G2 Esports
(24, 3, 1, 9, 20, 111, 'Nautilus', 'Tank'), -- Jogador 4 de G2 Esports
(25, 3, 7, 3, 5, 145, 'Kai\'Sa', 'Marksman'); -- Jogador 5 de G2 Esports

-- Jogadores da equipe T1 (idEquipe = 6)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(26, 3, 8, 2, 6, 24, 'Jax', 'Fighter'), -- Jogador 1 de T1
(27, 3, 5, 4, 8, 141, 'Kayn', 'Fighter'), -- Jogador 2 de T1
(28, 3, 7, 3, 7, 134, 'Orianna', 'Mage'), -- Jogador 3 de T1
(29, 3, 0, 5, 21, 497, 'Rakan', 'Support'), -- Jogador 4 de T1
(30, 3, 6, 2, 12, 119, 'Draven', 'Marksman'); -- Jogador 5 de T1

-- Jogadores da equipe Dplus Kia (idEquipe = 7)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(31, 4, 4, 5, 6, 86, 'Garen', 'Tank'), -- Jogador 1 de Dplus Kia
(32, 4, 2, 6, 8, 56, 'Nocturne', 'Assassin'), -- Jogador 2 de Dplus Kia
(33, 4, 3, 3, 12, 45, 'Veigar', 'Mage'), -- Jogador 3 de Dplus Kia
(34, 4, 1, 7, 15, 32, 'Alistar', 'Support'), -- Jogador 4 de Dplus Kia
(35, 4, 5, 4, 7, 81, 'Ezreal', 'Marksman'); -- Jogador 5 de Dplus Kia

-- Jogadores da equipe Beijing JDG Intel Esports (idEquipe = 8)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(36, 4, 6, 3, 8, 75, 'Renekton', 'Fighter'), -- Jogador 1 de Beijing JDG Intel Esports
(37, 4, 5, 2, 9, 28, 'Shyvana', 'Fighter'), -- Jogador 2 de Beijing JDG Intel Esports
(38, 4, 8, 1, 7, 157, 'Yasuo', 'Fighter'), -- Jogador 3 de Beijing JDG Intel Esports
(39, 4, 0, 4, 20, 117, 'Janna', 'Support'), -- Jogador 4 de Beijing JDG Intel Esports
(40, 4, 7, 2, 12, 222, 'Jinx', 'Marksman'); -- Jogador 5 de Beijing JDG Intel Esports

-- Jogadores da equipe Gen.G (idEquipe = 1)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(1, 5, 9, 4, 12, 164, 'Camille', 'Fighter'), -- Jogador 1 de Gen.G
(2, 5, 6, 5, 10, 203, 'Kindred', 'Marksman'), -- Jogador 2 de Gen.G
(3, 5, 7, 3, 11, 238, 'Zed', 'Assassin'), -- Jogador 3 de Gen.G
(4, 5, 0, 7, 20, 117, 'Janna', 'Support'), -- Jogador 4 de Gen.G
(5, 5, 10, 2, 9, 51, 'Kayle', 'Fighter'); -- Jogador 5 de Gen.G

-- Jogadores da equipe Hanwha Life Esports (idEquipe = 3)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(11, 5, 8, 6, 8, 41, 'Twisted Fate', 'Mage'), -- Jogador 1 de Hanwha Life Esports
(12, 5, 7, 4, 6, 81, 'Ezreal', 'Marksman'), -- Jogador 2 de Hanwha Life Esports
(13, 5, 5, 6, 10, 120, 'Hecarim', 'Fighter'), -- Jogador 3 de Hanwha Life Esports
(14, 5, 1, 9, 16, 267, 'Nami', 'Support'), -- Jogador 4 de Hanwha Life Esports
(15, 5, 6, 3, 12, 84, 'Annie', 'Mage'); -- Jogador 5 de Hanwha Life Esports



-- Jogadores da equipe T1 (idEquipe = 6)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(26, 6, 2, 8, 4, 266, 'Aatrox', 'Fighter'), -- Jogador 1 de T1
(27, 6, 1, 7, 5, 203, 'Kindred', 'Marksman'), -- Jogador 2 de T1
(28, 6, 3, 6, 8, 84, 'Annie', 'Mage'), -- Jogador 3 de T1
(29, 6, 0, 9, 12, 497, 'Rakan', 'Support'), -- Jogador 4 de T1
(30, 6, 4, 5, 7, 145, 'Kai\'Sa', 'Marksman'); -- Jogador 5 de T1

-- Jogadores da equipe Beijing JDG Intel Esports (idEquipe = 8)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(36, 6, 10, 1, 6, 75, 'Renekton', 'Fighter'), -- Jogador 1 de Beijing JDG Intel Esports
(37, 6, 7, 2, 9, 35, 'Sejuani', 'Tank'), -- Jogador 2 de Beijing JDG Intel Esports
(38, 6, 8, 3, 5, 157, 'Yasuo', 'Fighter'), -- Jogador 3 de Beijing JDG Intel Esports
(39, 6, 1, 4, 20, 40, 'Soraka', 'Support'), -- Jogador 4 de Beijing JDG Intel Esports
(40, 6, 9, 2, 12, 222, 'Jinx', 'Marksman'); -- Jogador 5 de Beijing JDG Intel Esports

-- Jogadores da equipe Gen.G (idEquipe = 1)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(1, 7, 10, 3, 8, 164, 'Camille', 'Fighter'), -- Jogador 1 de Gen.G
(2, 7, 7, 5, 12, 121, 'Zoe', 'Mage'), -- Jogador 2 de Gen.G
(3, 7, 8, 4, 9, 131, 'Ryze', 'Mage'), -- Jogador 3 de Gen.G
(4, 7, 2, 6, 15, 412, 'Thresh', 'Support'), -- Jogador 4 de Gen.G
(5, 7, 11, 2, 10, 145, 'Kai\'Sa', 'Marksman'); -- Jogador 5 de Gen.G

-- Jogadores da equipe Beijing JDG Intel Esports (idEquipe = 8)
INSERT INTO partidaUsuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao) VALUES
(36, 7, 6, 4, 7, 75, 'Renekton', 'Fighter'), -- Jogador 1 de Beijing JDG Intel Esports
(37, 7, 4, 6, 8, 28, 'Shyvana', 'Fighter'), -- Jogador 2 de Beijing JDG Intel Esports
(38, 7, 7, 3, 6, 157, 'Yasuo', 'Fighter'), -- Jogador 3 de Beijing JDG Intel Esports
(39, 7, 0, 7, 18, 40, 'Soraka', 'Support'), -- Jogador 4 de Beijing JDG Intel Esports
(40, 7, 9, 4, 10, 222, 'Jinx', 'Marksman'); -- Jogador 5 de Beijing JDG Intel Esports

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Infinity Edge', 0, 0, 0, 0, 0, 0, 70, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Immortal Shieldbow', 0, 0, 0, 0, 0, 0, 50, 0.20, 250, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Galeforce', 0, 0, 0, 0, 0, 0, 55, 0.20, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Kraken Slayer', 0, 0, 0, 0, 0, 0, 65, 0.25, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Prowler''s Claw', 0, 0, 0, 0, 0, 0, 60, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Eclipse', 0, 0, 0, 0, 0, 0, 55, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Axiom Arc', 0, 0, 0, 0, 0, 0, 55, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Duskblade of Draktharr', 0, 0, 0, 0, 0, 0, 60, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Black Cleaver', 0, 0, 0, 300, 0, 0, 50, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Death''s Dance', 0, 0, 0, 0, 0, 0, 55, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Bloodthirster', 0, 0, 0, 0, 0, 0, 55, 0.0, 0, 25);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Blade of the Ruined King', 0, 0, 0, 0, 0, 0, 40, 0.25, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Ravenous Hydra', 0, 0, 0, 0, 0, 0, 65, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Titanic Hydra', 0, 0, 0, 500, 0, 0, 30, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Guinsoo''s Rageblade', 30, 0, 0, 0, 0, 0, 30, 0.25, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Mortal Reminder', 0, 0, 0, 0, 0, 0, 25, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Wit''s End', 0, 0, 0, 0, 0, 40, 0, 0.40, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Stormrazor', 0, 0, 0, 0, 0, 0, 40, 0.15, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Rapid Firecannon', 0, 0, 0, 0, 0, 0, 0, 0.30, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Phantom Dancer', 0, 0, 0, 0, 0, 0, 0, 0.30, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Luden''s Tempest', 80, 6, 0, 0, 0, 0, 0, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Liandry''s Anguish', 80, 6, 0, 0, 0, 0, 0, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Rabadon''s Deathcap', 120, 0, 0, 0, 0, 0, 0, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Zhonya''s Hourglass', 65, 0, 0, 0, 45, 0, 0, 0.0, 0, 0);

-- Jogadores da partida 1 (idPartidaUsuario de 1 a 10)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) 
VALUES
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),
(2,7),(2,8),(2,9),(2,10),(2,11),(2,12),
(3,13),(3,14),(3,15),(3,16),(3,17),(3,18),
(4,19),(4,20),(4,21),(4,22),(4,23),(4,24),
(5,1),(5,2),(5,3),(5,4),(5,5),(5,6),
(6,7),(6,8),(6,9),(6,10),(6,11),(6,12),
(7,13),(7,14),(7,15),(7,16),(7,17),(7,18),
(8,19),(8,20),(8,21),(8,22),(8,23),(8,24),
(9,1),(9,2),(9,3),(9,4),(9,5),(9,6),
(10,7),(10,8),(10,9),(10,10),(10,11),(10,12);


-- Jogadores da partida 2 (idPartidaUsuario de 11 a 20)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) 
VALUES
(11,13),(11,14),(11,15),(11,16),(11,17),(11,18),
(12,19),(12,20),(12,21),(12,22),(12,23),(12,24),
(13,1),(13,2),(13,3),(13,4),(13,5),(13,6),
(14,7),(14,8),(14,9),(14,10),(14,11),(14,12),
(15,13),(15,14),(15,15),(15,16),(15,17),(15,18),
(16,19),(16,20),(16,21),(16,22),(16,23),(16,24),
(17,1),(17,2),(17,3),(17,4),(17,5),(17,6),
(18,7),(18,8),(18,9),(18,10),(18,11),(18,12),
(19,13),(19,14),(19,15),(19,16),(19,17),(19,18),
(20,19),(20,20),(20,21),(20,22),(20,23),(20,24);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(21,7),(21,8),(21,9),(21,10),(21,11),(21,12),
(22,13),(22,14),(22,15),(22,16),(22,17),(22,18),
(23,19),(23,20),(23,21),(23,22),(23,23),(23,24),
(24,1),(24,2),(24,3),(24,4),(24,5),(24,6),
(25,7),(25,8),(25,9),(25,10),(25,11),(25,12);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(26,13),(26,14),(26,15),(26,16),(26,17),(26,18),
(27,19),(27,20),(27,21),(27,22),(27,23),(27,24),
(28,1),(28,2),(28,3),(28,4),(28,5),(28,6),
(29,7),(29,8),(29,9),(29,10),(29,11),(29,12),
(30,13),(30,14),(30,15),(30,16),(30,17),(30,18);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(31,19),(31,20),(31,21),(31,22),(31,23),(31,24),
(32,1),(32,2),(32,3),(32,4),(32,5),(32,6),
(33,7),(33,8),(33,9),(33,10),(33,11),(33,12),
(34,13),(34,14),(34,15),(34,16),(34,17),(34,18),
(35,19),(35,20),(35,21),(35,22),(35,23),(35,24);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(36,1),(36,2),(36,3),(36,4),(36,5),(36,6),
(37,7),(37,8),(37,9),(37,10),(37,11),(37,12),
(38,13),(38,14),(38,15),(38,16),(38,17),(38,18),
(39,19),(39,20),(39,21),(39,22),(39,23),(39,24),
(40,1),(40,2),(40,3),(40,4),(40,5),(40,6);
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(41,7),(41,8),(41,9),(41,10),(41,11),(41,12),
(42,13),(42,14),(42,15),(42,16),(42,17),(42,18),
(43,19),(43,20),(43,21),(43,22),(43,23),(43,24),
(44,1),(44,2),(44,3),(44,4),(44,5),(44,6),
(45,7),(45,8),(45,9),(45,10),(45,11),(45,12),
(46,13),(46,14),(46,15),(46,16),(46,17),(46,18),
(47,19),(47,20),(47,21),(47,22),(47,23),(47,24),
(48,1),(48,2),(48,3),(48,4),(48,5),(48,6),
(49,7),(49,8),(49,9),(49,10),(49,11),(49,12),
(50,13),(50,14),(50,15),(50,16),(50,17),(50,18);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(51,19),(51,20),(51,21),(51,22),(51,23),(51,24),
(52,1),(52,2),(52,3),(52,4),(52,5),(52,6),
(53,7),(53,8),(53,9),(53,10),(53,11),(53,12),
(54,13),(54,14),(54,15),(54,16),(54,17),(54,18),
(55,19),(55,20),(55,21),(55,22),(55,23),(55,24),
(56,1),(56,2),(56,3),(56,4),(56,5),(56,6),
(57,7),(57,8),(57,9),(57,10),(57,11),(57,12),
(58,13),(58,14),(58,15),(58,16),(58,17),(58,18),
(59,19),(59,20),(59,21),(59,22),(59,23),(59,24),
(60,1),(60,2),(60,3),(60,4),(60,5),(60,6);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(61,1),(61,2),(61,3),(61,4),(61,5),(61,6),
(62,7),(62,8),(62,9),(62,10),(62,11),(62,12),
(63,13),(63,14),(63,15),(63,16),(63,17),(63,18),
(64,19),(64,20),(64,21),(64,22),(64,23),(64,24),
(65,1),(65,2),(65,3),(65,4),(65,5),(65,6);

INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(66,7),(66,8),(66,9),(66,10),(66,11),(66,12),
(67,13),(67,14),(67,15),(67,16),(67,17),(67,18),
(68,19),(68,20),(68,21),(68,22),(68,23),(68,24),
(69,1),(69,2),(69,3),(69,4),(69,5),(69,6),
(70,7),(70,8),(70,9),(70,10),(70,11),(70,12);



UPDATE partida SET duracao = '00:30:12' WHERE idPartida = 1;
UPDATE partida SET duracao = '00:32:45' WHERE idPartida = 2;
UPDATE partida SET duracao = '00:35:08' WHERE idPartida = 3;
UPDATE partida SET duracao = '00:37:21' WHERE idPartida = 4;
UPDATE partida SET duracao = '00:40:05' WHERE idPartida = 5;
UPDATE partida SET duracao = '00:42:13' WHERE idPartida = 6;
UPDATE partida SET duracao = '00:44:59' WHERE idPartida = 7;
UPDATE partida SET duracao = '00:46:35' WHERE idPartida = 8;
UPDATE partida SET duracao = '00:50:12' WHERE idPartida = 9;
UPDATE partida SET duracao = '00:52:18' WHERE idPartida = 10;
UPDATE partida SET duracao = '00:54:09' WHERE idPartida = 11;
UPDATE partida SET duracao = '00:31:45' WHERE idPartida = 12;
UPDATE partida SET duracao = '00:33:20' WHERE idPartida = 13;
UPDATE partida SET duracao = '00:36:41' WHERE idPartida = 14;
UPDATE partida SET duracao = '00:38:05' WHERE idPartida = 15;
UPDATE partida SET duracao = '00:41:30' WHERE idPartida = 16;
UPDATE partida SET duracao = '00:43:22' WHERE idPartida = 17;
UPDATE partida SET duracao = '00:45:44' WHERE idPartida = 18;
UPDATE partida SET duracao = '00:47:15' WHERE idPartida = 19;
UPDATE partida SET duracao = '00:49:50' WHERE idPartida = 20;
UPDATE partida SET duracao = '00:51:11' WHERE idPartida = 21;
UPDATE partida SET duracao = '00:53:00' WHERE idPartida = 22;
UPDATE partida SET duracao = '00:55:35' WHERE idPartida = 23;
UPDATE partida SET duracao = '00:34:12' WHERE idPartida = 24;
UPDATE partida SET duracao = '00:36:40' WHERE idPartida = 25;
UPDATE partida SET duracao = '00:39:18' WHERE idPartida = 26;
UPDATE partida SET duracao = '00:42:00' WHERE idPartida = 27;
UPDATE partida SET duracao = '00:44:30' WHERE idPartida = 28;
UPDATE partida SET duracao = '00:46:55' WHERE idPartida = 29;
UPDATE partida SET duracao = '00:50:25' WHERE idPartida = 30;
UPDATE partida SET duracao = '00:52:40' WHERE idPartida = 31;
UPDATE partida SET duracao = '00:54:15' WHERE idPartida = 32;
UPDATE partida SET duracao = '00:30:35' WHERE idPartida = 33;
UPDATE partida SET duracao = '00:33:25' WHERE idPartida = 34;
UPDATE partida SET duracao = '00:40:55' WHERE idPartida = 35;


UPDATE partidaUsuario SET ouroAdquirido = 8792 WHERE idPartidaUsuario = 1;
UPDATE partidaUsuario SET ouroAdquirido = 9392 WHERE idPartidaUsuario = 2;
UPDATE partidaUsuario SET ouroAdquirido = 9361 WHERE idPartidaUsuario = 3;
UPDATE partidaUsuario SET ouroAdquirido = 12190 WHERE idPartidaUsuario = 4;
UPDATE partidaUsuario SET ouroAdquirido = 8744 WHERE idPartidaUsuario = 5;
UPDATE partidaUsuario SET ouroAdquirido = 8963 WHERE idPartidaUsuario = 6;
UPDATE partidaUsuario SET ouroAdquirido = 9993 WHERE idPartidaUsuario = 7;
UPDATE partidaUsuario SET ouroAdquirido = 11850 WHERE idPartidaUsuario = 8;
UPDATE partidaUsuario SET ouroAdquirido = 10884 WHERE idPartidaUsuario = 9;
UPDATE partidaUsuario SET ouroAdquirido = 9511 WHERE idPartidaUsuario = 10;
UPDATE partidaUsuario SET ouroAdquirido = 12808 WHERE idPartidaUsuario = 11;
UPDATE partidaUsuario SET ouroAdquirido = 8733 WHERE idPartidaUsuario = 12;
UPDATE partidaUsuario SET ouroAdquirido = 12053 WHERE idPartidaUsuario = 13;
UPDATE partidaUsuario SET ouroAdquirido = 11224 WHERE idPartidaUsuario = 14;
UPDATE partidaUsuario SET ouroAdquirido = 11223 WHERE idPartidaUsuario = 15;
UPDATE partidaUsuario SET ouroAdquirido = 10707 WHERE idPartidaUsuario = 16;
UPDATE partidaUsuario SET ouroAdquirido = 12035 WHERE idPartidaUsuario = 17;
UPDATE partidaUsuario SET ouroAdquirido = 8089 WHERE idPartidaUsuario = 18;
UPDATE partidaUsuario SET ouroAdquirido = 11331 WHERE idPartidaUsuario = 19;
UPDATE partidaUsuario SET ouroAdquirido = 8238 WHERE idPartidaUsuario = 20;
UPDATE partidaUsuario SET ouroAdquirido = 8582 WHERE idPartidaUsuario = 21;
UPDATE partidaUsuario SET ouroAdquirido = 9724 WHERE idPartidaUsuario = 22;
UPDATE partidaUsuario SET ouroAdquirido = 8970 WHERE idPartidaUsuario = 23;
UPDATE partidaUsuario SET ouroAdquirido = 8968 WHERE idPartidaUsuario = 24;
UPDATE partidaUsuario SET ouroAdquirido = 10426 WHERE idPartidaUsuario = 25;
UPDATE partidaUsuario SET ouroAdquirido = 12201 WHERE idPartidaUsuario = 26;
UPDATE partidaUsuario SET ouroAdquirido = 12430 WHERE idPartidaUsuario = 27;
UPDATE partidaUsuario SET ouroAdquirido = 9198 WHERE idPartidaUsuario = 28;
UPDATE partidaUsuario SET ouroAdquirido = 10344 WHERE idPartidaUsuario = 29;
UPDATE partidaUsuario SET ouroAdquirido = 11968 WHERE idPartidaUsuario = 30;
UPDATE partidaUsuario SET ouroAdquirido = 8033 WHERE idPartidaUsuario = 31;
UPDATE partidaUsuario SET ouroAdquirido = 11828 WHERE idPartidaUsuario = 32;
UPDATE partidaUsuario SET ouroAdquirido = 8230 WHERE idPartidaUsuario = 33;
UPDATE partidaUsuario SET ouroAdquirido = 11675 WHERE idPartidaUsuario = 34;
UPDATE partidaUsuario SET ouroAdquirido = 9359 WHERE idPartidaUsuario = 35;
UPDATE partidaUsuario SET ouroAdquirido = 10530 WHERE idPartidaUsuario = 36;
UPDATE partidaUsuario SET ouroAdquirido = 12224 WHERE idPartidaUsuario = 37;
UPDATE partidaUsuario SET ouroAdquirido = 12620 WHERE idPartidaUsuario = 38;
UPDATE partidaUsuario SET ouroAdquirido = 8211 WHERE idPartidaUsuario = 39;
UPDATE partidaUsuario SET ouroAdquirido = 9503 WHERE idPartidaUsuario = 40;
UPDATE partidaUsuario SET ouroAdquirido = 10847 WHERE idPartidaUsuario = 41;
UPDATE partidaUsuario SET ouroAdquirido = 11027 WHERE idPartidaUsuario = 42;
UPDATE partidaUsuario SET ouroAdquirido = 9180 WHERE idPartidaUsuario = 43;
UPDATE partidaUsuario SET ouroAdquirido = 10061 WHERE idPartidaUsuario = 44;
UPDATE partidaUsuario SET ouroAdquirido = 8271 WHERE idPartidaUsuario = 45;
UPDATE partidaUsuario SET ouroAdquirido = 9502 WHERE idPartidaUsuario = 46;
UPDATE partidaUsuario SET ouroAdquirido = 11414 WHERE idPartidaUsuario = 47;
UPDATE partidaUsuario SET ouroAdquirido = 10442 WHERE idPartidaUsuario = 48;
UPDATE partidaUsuario SET ouroAdquirido = 12154 WHERE idPartidaUsuario = 49;
UPDATE partidaUsuario SET ouroAdquirido = 11390 WHERE idPartidaUsuario = 50;
UPDATE partidaUsuario SET ouroAdquirido = 10835 WHERE idPartidaUsuario = 51;
UPDATE partidaUsuario SET ouroAdquirido = 11305 WHERE idPartidaUsuario = 52;
UPDATE partidaUsuario SET ouroAdquirido = 12217 WHERE idPartidaUsuario = 53;
UPDATE partidaUsuario SET ouroAdquirido = 11043 WHERE idPartidaUsuario = 54;
UPDATE partidaUsuario SET ouroAdquirido = 9156 WHERE idPartidaUsuario = 55;
UPDATE partidaUsuario SET ouroAdquirido = 12955 WHERE idPartidaUsuario = 56;
UPDATE partidaUsuario SET ouroAdquirido = 12971 WHERE idPartidaUsuario = 57;
UPDATE partidaUsuario SET ouroAdquirido = 10866 WHERE idPartidaUsuario = 58;
UPDATE partidaUsuario SET ouroAdquirido = 8097 WHERE idPartidaUsuario = 59;
UPDATE partidaUsuario SET ouroAdquirido = 11492 WHERE idPartidaUsuario = 60;
UPDATE partidaUsuario SET ouroAdquirido = 11330 WHERE idPartidaUsuario = 61;
UPDATE partidaUsuario SET ouroAdquirido = 10568 WHERE idPartidaUsuario = 62;
UPDATE partidaUsuario SET ouroAdquirido = 8751 WHERE idPartidaUsuario = 63;
UPDATE partidaUsuario SET ouroAdquirido = 12364 WHERE idPartidaUsuario = 64;
UPDATE partidaUsuario SET ouroAdquirido = 10429 WHERE idPartidaUsuario = 65;
UPDATE partidaUsuario SET ouroAdquirido = 8465 WHERE idPartidaUsuario = 66;
UPDATE partidaUsuario SET ouroAdquirido = 10654 WHERE idPartidaUsuario = 67;
UPDATE partidaUsuario SET ouroAdquirido = 12757 WHERE idPartidaUsuario = 68;
UPDATE partidaUsuario SET ouroAdquirido = 10162 WHERE idPartidaUsuario = 69;
UPDATE partidaUsuario SET ouroAdquirido = 12209 WHERE idPartidaUsuario = 70;
