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

-- Itens Míticos (Mythic Items)
INSERT INTO itens (nome, AP, penetMagica, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Eclipse', 0, 0, 150, 0, 0, 55, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Força do Vendaval', 0, 0, 0, 0, 0, 60, 0.2, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Coração de Aço (Heartsteel)', 0, 0, 800, 40, 0, 0, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Angústia de Liandry (Liandry’s Anguish)', 80, 10, 0, 0, 0, 0, 0.0, 0, 0);

INSERT INTO itens (nome, AP, penetMagica, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida)
VALUES ('Virtude Radiante (Radiant Virtue)', 0, 0, 400, 30, 30, 0, 0.0, 0, 0);


-- Dano Físico e Crítico
INSERT INTO itens (nome, AP, danAtaque, vida)
VALUES ('Gume do Infinito (Infinity Edge)', 0, 70, 0);

INSERT INTO itens (nome, AP, danAtaque)
VALUES ('A Coletora (The Collector)', 0, 55);

INSERT INTO itens (nome, AP, danAtaque, curaConcedida)
VALUES ('Sedenta por Sangue (Bloodthirster)', 0, 55, 80);

INSERT INTO itens (nome, AP, danAtaque, velocAtaque)
VALUES ('Gume do Vento (Stormrazor)', 0, 40, 0.15);

INSERT INTO itens (nome, AP, danAtaque, vida)
VALUES ('Lança de Shojin (Spear of Shojin)', 0, 65, 250);


-- Poder de Habilidade (AP)
INSERT INTO itens (nome, AP, armadura)
VALUES ('Ampulheta de Zhonya (Zhonya’s Hourglass)', 65, 45);

INSERT INTO itens (nome, AP, penetMagica)
VALUES ('Cajado do Vazio (Void Staff)', 70, 40);

INSERT INTO itens (nome, AP)
VALUES ('Capuz da Morte de Rabadon (Rabadon’s Deathcap)', 120);

INSERT INTO itens (nome, AP, penetMagica)
VALUES ('Morellonomicon', 80, 15);

INSERT INTO itens (nome, AP, vida)
VALUES ('Abraço Demoníaco (Demonic Embrace)', 60, 300);


-- Itens de Tanque e Resistências
INSERT INTO itens (nome, vida)
VALUES ('Armadura de Warmog (Warmog’s Armor)', 800);

INSERT INTO itens (nome, vida, armadura)
VALUES ('Presságio de Randuin (Randuin’s Omen)', 400, 60);

INSERT INTO itens (nome, vida, resistMagica)
VALUES ('Força da Natureza (Force of Nature)', 350, 70);

INSERT INTO itens (nome, vida, armadura)
VALUES ('Armadura de Espinhos (Thornmail)', 250, 60);

INSERT INTO itens (nome, vida, resistMagica, curaConcedida)
VALUES ('Semblante Espiritual (Spirit Visage)', 450, 40, 20);


-- Itens de Suporte e Utilidade
INSERT INTO itens (nome, escudoConcedido)
VALUES ('Medalhão dos Solari de Ferro (Locket of the Iron Solari)', 200);

INSERT INTO itens (nome, curaConcedida)
VALUES ('Redenção (Redemption)', 100);

INSERT INTO itens (nome, AP, penetMagica)
VALUES ('Putrificador Quimtec (Chemtech Putrifier)', 40, 10);

INSERT INTO itens (nome, vida, armadura)
VALUES ('Juramento do Cavaleiro (Knight’s Vow)', 250, 20);

INSERT INTO itens (nome, AP, velocAtaque)
VALUES ('Turíbulo Ardente (Ardent Censer)', 60, 0.1);


-- Itens de Velocidade de Ataque, On-Hit e ADC
INSERT INTO itens (nome, velocAtaque)
VALUES ('Furacão de Runaan (Runaan’s Hurricane)', 0.45);

INSERT INTO itens (nome, danAtaque, velocAtaque)
VALUES ('Espada do Rei Destruído (Blade of the Ruined King)', 40, 0.25);

INSERT INTO itens (nome, danAtaque, velocAtaque)
VALUES ('Lâmina da Fúria de Guinsoo (Guinsoo’s Rageblade)', 30, 0.25);

INSERT INTO itens (nome, velocAtaque)
VALUES ('Dançarina Fantasma (Phantom Dancer)', 0.45);

INSERT INTO itens (nome, velocAtaque)
VALUES ('Canhão Fumegante (Rapid Firecannon)', 0.35);


-- Itens de Início e Consumíveis
INSERT INTO itens (nome, danAtaque, vida)
VALUES ('Lâmina de Doran (Doran’s Blade)', 8, 80);

INSERT INTO itens (nome, AP, regMana, vida)
VALUES ('Anel de Doran (Doran’s Ring)', 15, 5, 70);

INSERT INTO itens (nome, vida)
VALUES ('Escudo de Doran (Doran’s Shield)', 80);

INSERT INTO itens (nome, curaConcedida)
VALUES ('Poção de Vida (Health Potion)', 150);

INSERT INTO itens (nome, curaConcedida, AP)
VALUES ('Poção Corrupta (Corrupting Potion)', 125, 10);


-- Itens de Jungler (Itens de Caçador)
INSERT INTO itens (nome, vida)
VALUES ('Lâmina do Rastreador (Tracker’s Knife)', 150);

INSERT INTO itens (nome, danAtaque)
VALUES ('Sabre do Escaramuçador (Skirmisher’s Sabre)', 20);

INSERT INTO itens (nome, vida)
VALUES ('Lâmina do Perseguidor (Stalker’s Blade)', 100);

INSERT INTO itens (nome, danAtaque)
VALUES ('Machete do Caçador (Hunter’s Machete)', 10);

INSERT INTO itens (nome, regMana)
VALUES ('Talismã do Caçador (Hunter’s Talisman)', 5);


-- Jogadores da partida 1 (idPartidaUsuario de 1 a 10)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(1,1),(1,2),(1,3),(1,4),(1,5),(1,6),
(2,1),(2,2),(2,3),(2,4),(2,5),(2,6),
(3,1),(3,2),(3,3),(3,4),(3,5),(3,6),
(4,1),(4,2),(4,3),(4,4),(4,5),(4,6),
(5,1),(5,2),(5,3),(5,4),(5,5),(5,6),
(6,1),(6,2),(6,3),(6,4),(6,5),(6,6),
(7,1),(7,2),(7,3),(7,4),(7,5),(7,6),
(8,1),(8,2),(8,3),(8,4),(8,5),(8,6),
(9,1),(9,2),(9,3),(9,4),(9,5),(9,6),
(10,1),(10,2),(10,3),(10,4),(10,5),(10,6);

-- Jogadores da partida 2 (idPartidaUsuario de 11 a 20)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(11,1),(11,2),(11,3),(11,4),(11,5),(11,6),
(12,1),(12,2),(12,3),(12,4),(12,5),(12,6),
(13,1),(13,2),(13,3),(13,4),(13,5),(13,6),
(14,1),(14,2),(14,3),(14,4),(14,5),(14,6),
(15,1),(15,2),(15,3),(15,4),(15,5),(15,6),
(16,1),(16,2),(16,3),(16,4),(16,5),(16,6),
(17,1),(17,2),(17,3),(17,4),(17,5),(17,6),
(18,1),(18,2),(18,3),(18,4),(18,5),(18,6),
(19,1),(19,2),(19,3),(19,4),(19,5),(19,6),
(20,1),(20,2),(20,3),(20,4),(20,5),(20,6);


INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(21,1),(21,2),(21,3),(21,4),(21,5),(21,6),
(22,1),(22,2),(22,3),(22,4),(22,5),(22,6),
(23,1),(23,2),(23,3),(23,4),(23,5),(23,6),
(24,1),(24,2),(24,3),(24,4),(24,5),(24,6),
(25,1),(25,2),(25,3),(25,4),(25,5),(25,6);
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(26,1),(26,2),(26,3),(26,4),(26,5),(26,6),
(27,1),(27,2),(27,3),(27,4),(27,5),(27,6),
(28,1),(28,2),(28,3),(28,4),(28,5),(28,6),
(29,1),(29,2),(29,3),(29,4),(29,5),(29,6),
(30,1),(30,2),(30,3),(30,4),(30,5),(30,6);
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(31,1),(31,2),(31,3),(31,4),(31,5),(31,6),
(32,1),(32,2),(32,3),(32,4),(32,5),(32,6),
(33,1),(33,2),(33,3),(33,4),(33,5),(33,6),
(34,1),(34,2),(34,3),(34,4),(34,5),(34,6),
(35,1),(35,2),(35,3),(35,4),(35,5),(35,6);
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(36,1),(36,2),(36,3),(36,4),(36,5),(36,6),
(37,1),(37,2),(37,3),(37,4),(37,5),(37,6),
(38,1),(38,2),(38,3),(38,4),(38,5),(38,6),
(39,1),(39,2),(39,3),(39,4),(39,5),(39,6),
(40,1),(40,2),(40,3),(40,4),(40,5),(40,6);
-- Jogadores da partida 5 (Gen.G e Hanwha Life Esports)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(41,1),(41,2),(41,3),(41,4),(41,5),(41,6),
(42,1),(42,2),(42,3),(42,4),(42,5),(42,6),
(43,1),(43,2),(43,3),(43,4),(43,5),(43,6),
(44,1),(44,2),(44,3),(44,4),(44,5),(44,6),
(45,1),(45,2),(45,3),(45,4),(45,5),(45,6),
(46,1),(46,2),(46,3),(46,4),(46,5),(46,6),
(47,1),(47,2),(47,3),(47,4),(47,5),(47,6),
(48,1),(48,2),(48,3),(48,4),(48,5),(48,6),
(49,1),(49,2),(49,3),(49,4),(49,5),(49,6),
(50,1),(50,2),(50,3),(50,4),(50,5),(50,6);
-- Jogadores da partida 6 (T1 e Beijing JDG Intel Esports)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(51,1),(51,2),(51,3),(51,4),(51,5),(51,6),
(52,1),(52,2),(52,3),(52,4),(52,5),(52,6),
(53,1),(53,2),(53,3),(53,4),(53,5),(53,6),
(54,1),(54,2),(54,3),(54,4),(54,5),(54,6),
(55,1),(55,2),(55,3),(55,4),(55,5),(55,6),
(56,1),(56,2),(56,3),(56,4),(56,5),(56,6),
(57,1),(57,2),(57,3),(57,4),(57,5),(57,6),
(58,1),(58,2),(58,3),(58,4),(58,5),(58,6),
(59,1),(59,2),(59,3),(59,4),(59,5),(59,6),
(60,1),(60,2),(60,3),(60,4),(60,5),(60,6);
-- Jogadores da Gen.G (idPartida=7, idPartidaUsuario=61 a 65)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(61,1),(61,2),(61,3),(61,4),(61,5),(61,6),
(62,1),(62,2),(62,3),(62,4),(62,5),(62,6),
(63,1),(63,2),(63,3),(63,4),(63,5),(63,6),
(64,1),(64,2),(64,3),(64,4),(64,5),(64,6),
(65,1),(65,2),(65,3),(65,4),(65,5),(65,6);

-- Jogadores da Beijing JDG Intel Esports (idPartida=7, idPartidaUsuario=66 a 70)
INSERT INTO itensPatUsuario (idPartidaUsuario, idItem) VALUES
(66,1),(66,2),(66,3),(66,4),(66,5),(66,6),
(67,1),(67,2),(67,3),(67,4),(67,5),(67,6),
(68,1),(68,2),(68,3),(68,4),(68,5),(68,6),
(69,1),(69,2),(69,3),(69,4),(69,5),(69,6),
(70,1),(70,2),(70,3),(70,4),(70,5),(70,6);
