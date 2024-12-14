from flask import Flask, jsonify, request
from flask_mysqldb import MySQL
from datetime import timedelta
from datetime import date


app = Flask(__name__)

# Configurações do Banco de Dados
app.config['MYSQL_HOST'] = 'localhost'
app.config['MYSQL_USER'] = 'root'
app.config['MYSQL_PASSWORD'] = '6117747029'  # Substituir por variável de ambiente para maior segurança
app.config['MYSQL_DB'] = 'lol'
app.config['MYSQL_CURSORCLASS'] = 'DictCursor'

mysql = MySQL(app)

@app.route('/')
def index():
    return "Servidor Flask está ativo! Use /api/partidas para listar as partidas do banco de dados 'lol'."
# selects para as tabelas sem where
@app.route('/api/campeonato', methods=['GET'])
def Getcampeonatos():
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            c.idCampeonato, 
            c.ano, 
            c.idEquipeVencedora 
        FROM campeonato c;
        """
        cur.execute(query)
        rows = cur.fetchall()
        
        campeonatos = []
        for row in rows:
            campeonatos.append(row)

        return jsonify(campeonatos), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    




@app.route('/api/partidas', methods=['GET'])
def GetPartidas():
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            p.idPartida, 
            p.data, 
            p.placar, 
            p.duracao,
            p.hora, 
            p.etapa, 
            eq1.nome AS equipeVermelha, 
            eq2.nome AS equipeAzul, 
            c.ano AS AnoCampeonato 
        FROM partida p
        JOIN equipe eq1 ON p.idEquipeVermelha = eq1.idEquipe
        JOIN equipe eq2 ON p.idEquipeAzul = eq2.idEquipe
        JOIN campeonato c ON p.idCampeonato = c.idCampeonato;
        """
        cur.execute(query)
        rows = cur.fetchall()
        
        partidas = []
        for row in rows:
            # Converter 'datetime.date', 'datetime.time' ou 'timedelta' para strings
            if isinstance(row['data'], (date,)):
                row['data'] = str(row['data'])
            if isinstance(row['hora'], (timedelta,)):
                row['hora'] = str(row['hora'])
            if isinstance(row['duracao'], (timedelta,)):
                row['duracao'] = str(row['duracao'])
            
            partidas.append(row)

        return jsonify(partidas), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500

@app.route('/api/jogadores', methods=['GET', 'POST'])
def manageJogadores():
    if (request.method == 'GET'):
    
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            u.idUsuario, 
            u.nome, 
            u.ranque, 
            u.posicao, 
            e.nome AS equipe 
        FROM usuario u
        LEFT JOIN equipe e ON u.idEquipe = e.idEquipe;
        """
        cur.execute(query)
        rows = cur.fetchall()
        
        jogadores = []
        for row in rows:
            jogadores.append(row)

        return jsonify(jogadores), 200
    elif (request.method == 'POST'):
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
            return jsonify({"error": str(e)}), 500

@app.route('/api/equipe', methods=['GET'])
def GetEquipes():
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            e.idEquipe, 
            e.nome 
        FROM equipe e;
        """
        cur.execute(query)
        rows = cur.fetchall()
        
        equipes = []
        for row in rows:
            equipes.append(row)

        return jsonify(equipes), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500

@app.route('/api/item', methods=['GET'])
def GetItens():
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            i.idItem, 
            i.nome, 
            i.AP, 
            i.penetMagica, 
            i.regMana, 
            i.vida, 
            i.armadura, 
            i.resistMagica, 
            i.danAtaque, 
            i.velocAtaque, 
            i.escudoConcedido, 
            i.curaConcedida 
        FROM itens i;
        """
        cur.execute(query)
        rows = cur.fetchall()
        
        itens = []
        for row in rows:
            itens.append(row)

        return jsonify(itens), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    


# selects para as tabelas com where

@app.route('/api/equipes/<int:idEquipe>', methods=['GET'])
def getEquipeById(idEquipe):
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT 
            e.idEquipe, 
            e.nome AS nomeEquipe,
            u.idUsuario,
            u.nome AS nomeUsuario,
            u.ranque,
            u.posicao
        FROM equipe e
        LEFT JOIN usuario u ON e.idEquipe = u.idEquipe
        WHERE e.idEquipe = %s;
        """
        cur.execute(query, (idEquipe,))
        rows = cur.fetchall()

        if not rows:
            return jsonify({"error": "Equipe não encontrada"}), 404

        # Estruturar o resultado
        equipe = {
            "idEquipe": rows[0]['idEquipe'],
            "nomeEquipe": rows[0]['nomeEquipe'],
            "jogadores": []
        }
        for row in rows:
            if row['idUsuario']:
                equipe['jogadores'].append({
                    "idUsuario": row['idUsuario'],
                    "nomeUsuario": row['nomeUsuario'],
                    "ranque": row['ranque'],
                    "posicao": row['posicao']
                })

        return jsonify({"equipe": equipe}), 200
    except Exception as e:
        return jsonify({"status": "error", "message": f"Erro ao buscar equipe: {str(e)}"}), 500

@app.route('/api/partidaId/<int:idPartida>', methods=['GET'])
def GetPartida(idPartida):
    try:
        cur = mysql.connection.cursor()

        # Consulta para buscar os detalhes da partida
        query_partida = """
        SELECT 
            p.idPartida, 
            p.placar, 
            p.duracao, 
            p.hora, 
            p.data, 
            eq1.nome AS equipeVermelha,
            p.idEquipeVermelha, 
            eq2.nome AS equipeAzul,
            p.idEquipeAzul
        FROM partida p
        JOIN equipe eq1 ON p.idEquipeVermelha = eq1.idEquipe
        JOIN equipe eq2 ON p.idEquipeAzul = eq2.idEquipe
        WHERE p.idPartida = %s;
        """
        cur.execute(query_partida, (idPartida,))
        partida = cur.fetchone()

        if not partida:
            return jsonify({"status": "error", "message": "Partida não encontrada"}), 404

        # Converter campos de data/hora para string
        partida["data"] = str(partida["data"]) if partida["data"] else None
        partida["hora"] = str(partida["hora"]) if partida["hora"] else None
        partida["duracao"] = str(partida["duracao"]) if partida["duracao"] else None

        return jsonify({
            "status": "success",
            "partida": partida
        }), 200

    except Exception as e:
        return jsonify({"status": "error", "message": str(e)}), 500

@app.route('/api/vw_partida', methods=['GET'])
def get_view_partida():
    try:
        id_partida = request.args.get('idPartida', type=int)
        id_equipe = request.args.get('idEquipe', type=int)

        query = """
        SELECT 
            idUsuario,
            idEquipe,
            nome,
            idPartida,
            kills,
            deaths,
            assists,
            idCampeao,
            nomeCampeao,
            classeCampeao,
            ouroAdquirido,
            farm,
            item1id,
            item1nome,
            item2id,
            item2nome,
            item3id,
            item3nome,
            item4id,
            item4nome,
            item5id,
            item5nome,
            item6id,
            item6nome

        FROM vw_partida
        WHERE idPartida = %s AND idEquipe = %s;
        """
        cur = mysql.connection.cursor()
        cur.execute(query, (id_partida, id_equipe))
        rows = cur.fetchall()

        return jsonify(rows), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500





if __name__ == '__main__':
    app.run(debug=True)