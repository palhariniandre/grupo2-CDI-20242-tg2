CREATE OR REPLACE VIEW vw_partida AS
SELECT 
    u.idUsuario,
    u.idEquipe,
    u.nome,
    up.idPartida,
    up.kills,
    up.deaths,
    up.assists,
    up.idCampeao,
    up.nomeCampeao,
    up.classeCampeao,
    up.ouroAdquirido,
    up.farm,
    -- Itens dos jogadores
    MAX(CASE WHEN ipu.rank = 1 THEN i.idItem END) AS item1id,
    MAX(CASE WHEN ipu.rank = 1 THEN i.nome END) AS item1nome,
    MAX(CASE WHEN ipu.rank = 2 THEN i.idItem END) AS item2id,
    MAX(CASE WHEN ipu.rank = 2 THEN i.nome END) AS item2nome,
    MAX(CASE WHEN ipu.rank = 3 THEN i.idItem END) AS item3id,
    MAX(CASE WHEN ipu.rank = 3 THEN i.nome END) AS item3nome,
    MAX(CASE WHEN ipu.rank = 4 THEN i.idItem END) AS item4id,
    MAX(CASE WHEN ipu.rank = 4 THEN i.nome END) AS item4nome,
    MAX(CASE WHEN ipu.rank = 5 THEN i.idItem END) AS item5id,
    MAX(CASE WHEN ipu.rank = 5 THEN i.nome END) AS item5nome,
    MAX(CASE WHEN ipu.rank = 6 THEN i.idItem END) AS item6id,
    MAX(CASE WHEN ipu.rank = 6 THEN i.nome END) AS item6nome
FROM 
    usuario u
JOIN 
    partidausuario up ON u.idUsuario = up.idUsuario
LEFT JOIN (
    SELECT 
        ipu.idPartidaUsuario, 
        ipu.idItem, 
        ROW_NUMBER() OVER (PARTITION BY ipu.idPartidaUsuario ORDER BY ipu.idItem) AS rank
    FROM 
        itensPatUsuario ipu
) ipu ON ipu.idPartidaUsuario = up.idPartidaUsuario
LEFT JOIN 
    itens i ON ipu.idItem = i.idItem
GROUP BY 
    u.idUsuario, u.idEquipe, u.nome, up.idPartida, up.kills, up.deaths, up.assists,
    up.idCampeao, up.nomeCampeao, up.classeCampeao, up.ouroAdquirido, up.farm;

   