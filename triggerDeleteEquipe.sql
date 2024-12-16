DELIMITER $$

CREATE TRIGGER after_equipe_delete
AFTER DELETE ON equipe
FOR EACH ROW
BEGIN
    -- Excluir jogadores vinculados à equipe excluída
    DELETE FROM usuario
    WHERE idEquipe = OLD.idEquipe;

    -- Excluir partidas onde a equipe excluída estava envolvida
    DELETE FROM partida
    WHERE idEquipeVermelha = OLD.idEquipe OR idEquipeAzul = OLD.idEquipe;
END$$

DELIMITER ;
