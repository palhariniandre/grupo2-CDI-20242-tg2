from flask import jsonify, request
from app import app, mysql
from datetime import timedelta
from datetime import date

# Post para jogadores
@app.route('/api/jogadores', methods=['POST'])
def postJogador():
    try:
        data = request.get_json()

        nome = data['nome']
        ranque = data['ranque']
        posicao = data['posicao']
        idEquipe = data['idEquipe'] 

        cur = mysql.connection.cursor()
        query = """
        INSERT INTO usuario (nome, ranque, posicao, idEquipe)
        VALUES (%s, %s, %s, %s);
        """
        cur.execute(query, (nome, ranque, posicao, idEquipe))
        mysql.connection.commit()

        return jsonify({"message": "Jogador criado com sucesso!"}), 201
    except Exception as e:
        return jsonify({"error": str(e)}), 400

# Post para partidas
@app.route('/api/equipe', methods=['POST'])
def insertEquipe():
    try:
        data = request.get_json()

        nome = data.get('nome')

        if not nome:
            return jsonify({"error": "O campo 'nome' é obrigatório"}), 400

        cur = mysql.connection.cursor()
        query = """
        INSERT INTO equipe (nome)
        VALUES (%s);
        """
        cur.execute(query, (nome,))
        mysql.connection.commit()

        return jsonify({"message": "Equipe inserida com sucesso!"}), 201
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    
@app.route('/api/partida', methods=['POST'])
def insertPartida():
    try:
        # Obter os dados do corpo da solicitação
        data = request.get_json()

        # Validar os dados necessários
        required_fields = ['placar', 'data', 'hora', 'etapa', 'idEquipeAzul', 'idEquipeVermelha', 'idCampeonato', 'duracao']
        for field in required_fields:
            if field not in data:
                return jsonify({"error": f"Campo '{field}' é obrigatório."}), 400

        # Extrair os dados
        placar = data['placar']
        data_partida = data['data']
        hora = data['hora']
        etapa = data['etapa']
        idEquipeAzul = data['idEquipeAzul']
        idEquipeVermelha = data['idEquipeVermelha']
        idCampeonato = data['idCampeonato']
        duracao = data['duracao']

        # Inserir a partida no banco de dados
        cur = mysql.connection.cursor()
        insert_query = """
        INSERT INTO partida (placar, data, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato, duracao)
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.execute(insert_query, (placar, data_partida, hora, etapa, idEquipeAzul, idEquipeVermelha, idCampeonato, duracao))

        # Commit para salvar as alterações
        mysql.connection.commit()

        # Retornar sucesso com o ID da nova partida
        new_id = cur.lastrowid
        return jsonify({"message": "Partida adicionada com sucesso!", "idPartida": new_id}), 201

    except Exception as e:
        mysql.connection.rollback()  # Reverter alterações em caso de erro
        return jsonify({"error": str(e)}), 500

    finally:
        cur.close()  # Garantir que o cursor seja fechado
