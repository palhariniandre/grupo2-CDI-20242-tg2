from flask import Flask
from flask_mysqldb import MySQL
from config.db_config import Config
from datetime import timedelta
from datetime import date

app = Flask(__name__)

app.config.from_object(Config)

mysql = MySQL(app)

# Rotas
@app.route('/')
def index():
    return "Servidor Flask está ativo!"


# Certifique-se de que apenas um arquivo registra cada rota
from routes.selects import *
from routes.inserts import *
from routes.deletes import *



if __name__ == '__main__':
    app.run(debug=True)
