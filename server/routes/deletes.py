from flask import jsonify
from app import app, mysql
from datetime import timedelta
from datetime import date

@app.route('/api/equipe/<int:idEquipe>', methods=['DELETE'])
def deleteEquipe(idEquipe):
    try:
        cur = mysql.connection.cursor()
        
        # Excluir registros de itenspatusuario vinculados
        delete_itens_partida = """
        DELETE FROM itenspatusuario
        WHERE idPartidaUsuario IN (
            SELECT idPartidaUsuario
            FROM partidausuario
            WHERE idPartida IN (
                SELECT idPartida
                FROM partida
                WHERE idEquipeAzul = %s OR idEquipeVermelha = %s
            )
        );
        """
        cur.execute(delete_itens_partida, (idEquipe, idEquipe))
        
        # Excluir registros de partidausuario
        delete_partida_usuario = """
        DELETE FROM partidausuario
        WHERE idPartida IN (
            SELECT idPartida
            FROM partida
            WHERE idEquipeAzul = %s OR idEquipeVermelha = %s
        );
        """
        cur.execute(delete_partida_usuario, (idEquipe, idEquipe))
        
        # Excluir registros de partidas
        delete_partidas = """
        DELETE FROM partida
        WHERE idEquipeAzul = %s OR idEquipeVermelha = %s;
        """
        cur.execute(delete_partidas, (idEquipe, idEquipe))
        
        # Excluir registros de usuários vinculados à equipe
        delete_usuarios = """
        DELETE FROM usuario
        WHERE idEquipe = %s;
        """
        cur.execute(delete_usuarios, (idEquipe,))
        
        # Excluir a equipe
        delete_equipe = """
        DELETE FROM equipe
        WHERE idEquipe = %s;
        """
        cur.execute(delete_equipe, (idEquipe,))
        
        # Commit para salvar as alterações no banco de dados
        mysql.connection.commit()
        
        return jsonify({"message": f"Equipe com ID {idEquipe} deletada com sucesso!"}), 200
    
    except Exception as e:
        # Rollback para desfazer alterações em caso de erro
        mysql.connection.rollback()
        return jsonify({"error": str(e)}), 500
    
    finally:
        cur.close()  # Garantir que o cursor seja fechado

@app.route('/api/partida/<int:idPartida>', methods=['DELETE'])
def deletePartida(idPartida):
    try:
        cur = mysql.connection.cursor()
        
        # Excluir registros de itenspatusuario
        delete_itens_partida = """
        DELETE FROM itenspatusuario
        WHERE idPartidaUsuario IN (
            SELECT idPartidaUsuario
            FROM partidausuario
            WHERE idPartida = %s
        );
        """
        cur.execute(delete_itens_partida, (idPartida,))
        
        # Excluir registros de partidausuario
        delete_partida_usuario = """
        DELETE FROM partidausuario
        WHERE idPartida = %s;
        """
        cur.execute(delete_partida_usuario, (idPartida,))

        # Excluir a partida
        delete_partida = """
        DELETE FROM partida
        WHERE idPartida = %s;
        """
        cur.execute(delete_partida, (idPartida,))

        # Commit para salvar as alterações no banco de dados
        mysql.connection.commit()
        
        return jsonify({"message": f"Partida com ID {idPartida} deletada com sucesso!"}), 200

    except Exception as e:
        # Rollback para desfazer alterações em caso de erro
        mysql.connection.rollback()
        return jsonify({"error": str(e)}), 500
    
    finally:
        cur.close()  # Garantir que o cursor seja fechado
@app.route('/api/usuario/<int:idUsuario>', methods=['DELETE'])
def deleteUsuario(idUsuario):
        try:
            cur = mysql.connection.cursor()
            
            # Excluir registros de itenspatusuario
            delete_itens_partida = """
            DELETE FROM itenspatusuario
            WHERE idPartidaUsuario IN (
                SELECT idPartidaUsuario
                FROM partidausuario
                WHERE idUsuario = %s
            );
            """
            cur.execute(delete_itens_partida, (idUsuario,))
            
            # Excluir registros de partidausuario
            delete_partida_usuario = """
            DELETE FROM partidausuario
            WHERE idUsuario = %s;
            """
            cur.execute(delete_partida_usuario, (idUsuario,))
            
            # Excluir o usuário
            delete_usuario = """
            DELETE FROM usuario
            WHERE idUsuario = %s;
            """
            cur.execute(delete_usuario, (idUsuario,))
            
            # Commit para salvar as alterações no banco de dados
            mysql.connection.commit()
            
            return jsonify({"message": f"Usuário com ID {idUsuario} deletado com sucesso!"}), 200
        except Exception as e:
        # Rollback para desfazer alterações em caso de erro
            mysql.connection.rollback()
            return jsonify({"error": str(e)}), 500
    
        finally:
            cur.close()  # Garantir que o cursor seja fechado
            
@app.route('/api/partidausuario/<int:idPartidaUsuario>', methods=['DELETE'])
def deletePartidaUsuario(idPartidaUsuario):
    try:
        cur = mysql.connection.cursor()

        # Excluir registros relacionados na tabela itenspatusuario
        delete_itens_query = """
        DELETE FROM itenspatusuario
        WHERE idPartidaUsuario = %s;
        """
        cur.execute(delete_itens_query, (idPartidaUsuario,))

        # Excluir registro da tabela partidausuario
        delete_partida_usuario_query = """
        DELETE FROM partidausuario
        WHERE idPartidaUsuario = %s;
        """
        cur.execute(delete_partida_usuario_query, (idPartidaUsuario,))

        # Commit para salvar as alterações
        mysql.connection.commit()

        return jsonify({"message": f"Registro de partidausuario com ID {idPartidaUsuario} deletado com sucesso!"}), 200

    except Exception as e:
        # Rollback para desfazer alterações em caso de erro
        mysql.connection.rollback()
        return jsonify({"error": str(e)}), 500

    finally:
        cur.close()  # Garantir que o cursor seja fechado
