from flask import jsonify
from app import app, mysql
from datetime import timedelta
from datetime import date

@app.route('/api/equipe/<int:idEquipe>/delete', methods=['DELETE'])
def deleteEquipe(idEquipe):
    try:
        cur = mysql.connection.cursor()
        
        # Excluir jogadores vinculados
        query_delete_usuarios = "DELETE FROM usuario WHERE idEquipe = %s;"
        cur.execute(query_delete_usuarios, (idEquipe,))
        
        # Excluir partidas vinculadas
        query_delete_partidas = """
        DELETE FROM partida
        WHERE idEquipeVermelha = %s OR idEquipeAzul = %s;
        """
        cur.execute(query_delete_partidas, (idEquipe, idEquipe))
        
        # Excluir a equipe
        query_delete_equipe = "DELETE FROM equipe WHERE idEquipe = %s;"
        cur.execute(query_delete_equipe, (idEquipe,))
        
        mysql.connection.commit()
        
        return jsonify({"message": "Equipe deletada com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
