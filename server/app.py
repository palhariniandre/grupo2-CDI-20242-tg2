from flask import Flask, jsonify
from flask_mysqldb import MySQL
from datetime import timedelta

app = Flask(__name__)

# Configurações do Banco de Dados
app.config['MYSQL_HOST'] = 'localhost'
app.config['MYSQL_USER'] = 'root'
app.config['MYSQL_PASSWORD'] = '6117747029'
app.config['MYSQL_DB'] = 'lol'
app.config['MYSQL_CURSORCLASS'] = 'DictCursor'

mysql = MySQL(app)

@app.route('/')
def index():
    return "Servidor Flask com MariaDB para o banco LoL!"

# Endpoint para listar todas as partidas
@app.route('/api/partidas', methods=['GET'])
def get_partidas():
    try:
        cur = mysql.connection.cursor()
        query = """
        SELECT         
            CONCAT(eq1.nome, ' x ', eq2.nome) AS titulo,
            p.idPartida, 
            DATE_FORMAT(p.data, '%d/%m/%Y') AS data,
            TIME_TO_SEC(p.duracao) AS duracao_sec
        FROM 
            partida p
        JOIN 
            equipe eq1 ON p.idEquipeAzul = eq1.idEquipe
        JOIN 
            equipe eq2 ON p.idEquipeVermelha = eq2.idEquipe
        JOIN 
            campeonato c ON p.idCampeonato = c.idCampeonato;
        """
        cur.execute(query)
        rows = cur.fetchall()

        # Converta os dados para JSON-friendly format
        partidas = []
        for row in rows:
            duracao_str = str(timedelta(seconds=row['duracao_sec']))  # Converte segundos para "hh:mm:ss"
            partidas.append({
                "idPartida": row['idPartida'],
                "titulo": row['titulo'],
                "data": row['data'],
                "duracao": duracao_str
            })

        return jsonify(partidas), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


if __name__ == '__main__':
    app.run(debug=True)
