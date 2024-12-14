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
    up.farm
FROM 
    usuario u
JOIN 
    partidausuario up ON u.idUsuario = up.idUsuario;;