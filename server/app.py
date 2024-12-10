from flask import Flask, jsonify
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

@app.route('/api/partidas', methods=['GET'])
def get_partidas():
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



if __name__ == '__main__':
    app.run(debug=True)
