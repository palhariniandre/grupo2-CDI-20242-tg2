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

@app.route('/api/partidausuario', methods=['POST'])
def insertPartidaUsuario():
    try:
        # Obter os dados do corpo da solicitação
        data = request.get_json()

        # Validar os campos necessários
        required_fields = ['idUsuario', 'idPartida', 'kills', 'deaths', 'assists', 'idCampeao', 'nomeCampeao', 'classeCampeao', 'ouroAdquirido', 'FARM']
        for field in required_fields:
            if field not in data:
                return jsonify({"error": f"Campo '{field}' é obrigatório."}), 400

        # Extrair os dados
        idUsuario = data['idUsuario']
        idPartida = data['idPartida']
        kills = data['kills']
        deaths = data['deaths']
        assists = data['assists']
        idCampeao = data['idCampeao']
        nomeCampeao = data['nomeCampeao']
        classeCampeao = data['classeCampeao']
        ouroAdquirido = data['ouroAdquirido']
        FARM = data['FARM']

        # Inserir os dados na tabela partidausuario
        cur = mysql.connection.cursor()
        insert_query = """
        INSERT INTO partidausuario (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao, ouroAdquirido, FARM)
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        cur.execute(insert_query, (idUsuario, idPartida, kills, deaths, assists, idCampeao, nomeCampeao, classeCampeao, ouroAdquirido, FARM))

        # Commit para salvar as alterações
        mysql.connection.commit()

        # Retornar sucesso com o ID gerado
        new_id = cur.lastrowid
        return jsonify({"message": "Registro de partidausuario adicionado com sucesso!", "idPartidaUsuario": new_id}), 201

    except Exception as e:
        # Rollback para desfazer alterações em caso de erro
        mysql.connection.rollback()
        return jsonify({"error": str(e)}), 500

    finally:
        cur.close()  # Garantir que o cursor seja fechado

@app.route('/api/itenspartidausuario', methods=['POST'])
def insertItensPartidaUsuario():
    try:
        # Obter os dados do corpo da solicitação
        data = request.get_json()

        # Validar os campos necessários
        required_fields = ['idPartidaUsuario', 'itens']
        if any(field not in data for field in required_fields):
            return jsonify({"error": f"Os campos '{', '.join(required_fields)}' são obrigatórios."}), 400

        # Extrair os dados
        idPartidaUsuario = data['idPartidaUsuario']
        itens = data['itens']  # Esperado como uma lista de IDs de itens

        # Validar o número de itens (máximo 6)
        if not isinstance(itens, list) or len(itens) > 6:
            return jsonify({"error": "É necessário fornecer uma lista de no máximo 6 itens."}), 400

        # Abrir cursor para operações no banco
        cur = mysql.connection.cursor()

        # Inserir cada item na tabela itenspatusuario
        insert_query = """
        INSERT INTO itenspatusuario (idPartidaUsuario, idItem)
        VALUES (%s, %s);
        """
        for idItem in itens:
            cur.execute(insert_query, (idPartidaUsuario, idItem))

        # Confirmar as alterações no banco de dados
        mysql.connection.commit()

        # Retornar sucesso
        return jsonify({"message": "Itens vinculados ao partidausuario com sucesso!"}), 201

    except Exception as e:
        # Rollback para desfazer alterações em caso de erro
        mysql.connection.rollback()
        return jsonify({"error": str(e)}), 500

    finally:
        cur.close()  # Garantir que o cursor seja fechado
