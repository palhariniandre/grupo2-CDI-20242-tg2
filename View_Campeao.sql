CREATE OR REPLACE VIEW vw_campeoes AS
SELECT 
    pu.idCampeao,
    pu.nomeCampeao,
    pu.classeCampeao,
    COUNT(DISTINCT pu.idPartidaUsuario) AS vezesSelecionado,
FROM partidaUsuario pu
GROUP BY pu.idCampeao, pu.nomeCampeao, pu.classeCampeao;

