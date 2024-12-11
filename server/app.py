from flask import Flask, jsonify
from flask_mysqldb import MySQL
from datetime import timedelta
from datetime import date


app = Flask(__name__)

# Configurações do Banco de Dados
app.config['MYSQL_HOST'] = 'localhost'
app.config['MYSQL_USER'] = 'root'
app.config['MYSQL_PASSWORD'] = 'darthvader66'  # Substituir por variável de ambiente para maior segurança
app.config['MYSQL_DB'] = 'lol'
app.config['MYSQL_CURSORCLASS'] = 'DictCursor'

mysql = MySQL(app)

@app.route('/')
def index():
    return "Servidor Flask está ativo! Use /api/partidas para listar as partidas do banco de dados 'lol'."

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
            
            partidas.append(row)

        return jsonify(partidas), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500

@app.route('/api/jogadores', methods=['GET'])
def GetJogadores():
    try:
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

if __name__ == '__main__':
    app.run(debug=True)
