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

