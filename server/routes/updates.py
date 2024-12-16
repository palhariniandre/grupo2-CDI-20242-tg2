from flask import jsonify, request
from app import app, mysql
from datetime import timedelta
from datetime import date

@app.route('/api/equipe/<int:idEquipe>', methods=['PUT'])
def updateEquipe(idEquipe):
    try:
        # Obter os dados do JSON enviados na requisição
        data = request.get_json()
        novo_nome = data.get('nome')

        if not novo_nome:
            return jsonify({"error": "O campo 'nome' é obrigatório"}), 400

        # Abrir cursor para executar a query
        cur = mysql.connection.cursor()

        # Query para atualizar o nome da equipe
        query = """
        UPDATE equipe
        SET nome = %s
        WHERE idEquipe = %s;
        """
        cur.execute(query, (novo_nome, idEquipe))
        mysql.connection.commit()

        # Verificar se alguma linha foi alterada
        if cur.rowcount == 0:
            return jsonify({"error": "Equipe não encontrada ou sem alterações"}), 404

        return jsonify({"message": "Equipe atualizada com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


from flask import jsonify, request
from app import app, mysql

@app.route('/api/usuarios/<int:idUsuario>', methods=['PUT'])
def updateUsuario(idUsuario):
    try:
        # Obter os dados do JSON enviados na requisição
        data = request.get_json()
        novo_nome = data.get('nome')
        novo_ranque = data.get('ranque')
        nova_posicao = data.get('posicao')

        if not (novo_nome or novo_ranque or nova_posicao):
            return jsonify({"error": "É necessário fornecer pelo menos um campo para atualizar (nome, ranque, posição)."}), 400

        # Construir a query dinamicamente com base nos campos enviados
        campos = []
        valores = []
        if novo_nome:
            campos.append("nome = %s")
            valores.append(novo_nome)
        if novo_ranque:
            campos.append("ranque = %s")
            valores.append(novo_ranque)
        if nova_posicao:
            campos.append("posicao = %s")
            valores.append(nova_posicao)

        valores.append(idUsuario)  # Adicionar o ID ao final para o WHERE

        query = f"""
        UPDATE usuario
        SET {', '.join(campos)}
        WHERE idUsuario = %s;
        """
        
        # Executar a query
        cur = mysql.connection.cursor()
        cur.execute(query, valores)
        mysql.connection.commit()

        # Verificar se alguma linha foi alterada
        if cur.rowcount == 0:
            return jsonify({"error": "Usuário não encontrado ou sem alterações"}), 404

        return jsonify({"message": "Usuário atualizado com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500

@app.route('/api/partidausuario/<int:idPartidaUsuario>', methods=['PUT'])
def updatePartidaUsuario(idPartidaUsuario):
    try:
        # Obter os dados do JSON enviados na requisição
        data = request.get_json()
        kills = data.get('kills')
        deaths = data.get('deaths')
        assists = data.get('assists')
        ouroAdquirido = data.get('ouroAdquirido')
        farm = data.get('FARM')

        # Verificação: Pelo menos um campo deve ser enviado
        if not (kills or deaths or assists or ouroAdquirido or farm):
            return jsonify({"error": "Pelo menos um campo deve ser fornecido para atualização"}), 400

        # Construir query dinâmica com os campos fornecidos
        campos = []
        valores = []

        if kills is not None:
            campos.append("kills = %s")
            valores.append(kills)
        if deaths is not None:
            campos.append("deaths = %s")
            valores.append(deaths)
        if assists is not None:
            campos.append("assists = %s")
            valores.append(assists)
        if ouroAdquirido is not None:
            campos.append("ouroAdquirido = %s")
            valores.append(ouroAdquirido)
        if farm is not None:
            campos.append("FARM = %s")
            valores.append(farm)

        valores.append(idPartidaUsuario)  # ID é sempre o último parâmetro

        # Montar query SQL dinâmica
        query = f"""
        UPDATE partidausuario
        SET {', '.join(campos)}
        WHERE idPartidaUsuario = %s;
        """

        # Executar a query
        cur = mysql.connection.cursor()
        cur.execute(query, valores)
        mysql.connection.commit()

        # Verificar se alguma linha foi alterada
        if cur.rowcount == 0:
            return jsonify({"error": "Partida do usuário não encontrada ou sem alterações"}), 404

        return jsonify({"message": "Dados da partida do usuário atualizados com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/api/itenspatusuario/<int:idPartidaUsuario>', methods=['PUT'])
def updateItensPatUsuario(idPartidaUsuario):
    try:
        # Verificar se o idPartidaUsuario existe
        cur = mysql.connection.cursor()
        query_check_partida = "SELECT 1 FROM partidaUsuario WHERE idPartidaUsuario = %s;"
        cur.execute(query_check_partida, (idPartidaUsuario,))
        if not cur.fetchone():
            return jsonify({"error": f"O idPartidaUsuario {idPartidaUsuario} não existe"}), 404

        # Obter os dados enviados na requisição
        data = request.get_json()
        novos_itens = data.get('itens')  # Espera uma lista com 6 IDs de itens

        if not novos_itens or len(novos_itens) != 6:
            return jsonify({"error": "Exatamente 6 itens devem ser fornecidos"}), 400

        # Apagar os 6 itens antigos
        query_delete_itens = """
        DELETE FROM itensPatUsuario
        WHERE idPartidaUsuario = %s;
        """
        cur.execute(query_delete_itens, (idPartidaUsuario,))
        mysql.connection.commit()

        # Inserir os novos itens
        query_insert_itens = """
        INSERT INTO itensPatUsuario (idPartidaUsuario, idItem)
        VALUES (%s, %s);
        """
        for idItem in novos_itens:
            cur.execute(query_insert_itens, (idPartidaUsuario, idItem))
        mysql.connection.commit()

        # Verificar se os itens foram inseridos
        if cur.rowcount == 0:
            return jsonify({"error": "Nenhum item foi inserido. Verifique os dados enviados"}), 500

        return jsonify({"message": "Itens do usuário na partida atualizados com sucesso!"}), 200
    except Exception as e:
        # Log detalhado do erro
        print(f"Erro ao atualizar itens para idPartidaUsuario {idPartidaUsuario}: {str(e)}")
        return jsonify({"error": str(e)}), 500


@app.route('/api/item/<int:idItem>', methods=['PUT'])
def updateItens(idItem):
    try:
        # Obter os dados do JSON enviados na requisição
        data = request.get_json()
        novo_nome = data.get('nome')
        novo_AP = data.get('AP')
        if not (novo_nome or novo_preco or nova_descricao):
            return jsonify({"error": "É necessário fornecer pelo menos um campo para atualizar (nome, preço, descrição)."}), 400

        # Construir a query dinamicamente com base nos campos enviados
        campos = []
        valores = []
        if novo_nome:
            campos.append("nome = %s")
            valores.append(novo_nome)
        if novo_preco:
            campos.append("preco = %s")
            valores.append(novo_preco)
        if nova_descricao:
            campos.append("descricao = %s")
            valores.append(nova_descricao)

        valores.append(idItem)  # Adicionar o ID ao final para o WHERE

        query = f"""
        UPDATE item
        SET {', '.join(campos)}
        WHERE idItem = %s;
        """
        
        # Executar a query
        cur = mysql.connection.cursor()
        cur.execute(query, valores)
        mysql.connection.commit()

        # Verificar se alguma linha foi alterada
        if cur.rowcount == 0:
            return jsonify({"error": "Item não encontrado ou sem alterações"}), 404

        return jsonify({"message": "Item atualizado com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
    
@app.route('/api/itens/<int:idItem>', methods=['PUT'])
def updateItem(idItem):
    try:
        # Obter os dados do JSON enviados na requisição
        data = request.get_json()
        nome = data.get('nome')
        AP = data.get('AP')
        penetMagica = data.get('penetMagica')
        regMana = data.get('regMana')
        vida = data.get('vida')
        armadura = data.get('armadura')
        resistMagica = data.get('resistMagica')
        danAtaque = data.get('danAtaque')
        velocAtaque = data.get('velocAtaque')
        escudoConcedido = data.get('escudoConcedido')
        curaConcedida = data.get('curaConcedida')

        # Validação: Pelo menos um campo deve ser fornecido para atualização
        if not any([nome, AP, penetMagica, regMana, vida, armadura, resistMagica, danAtaque, velocAtaque, escudoConcedido, curaConcedida]):
            return jsonify({"error": "Pelo menos um campo deve ser fornecido para atualização"}), 400

        # Construir query dinâmica com os campos fornecidos
        campos = []
        valores = []

        if nome is not None:
            campos.append("nome = %s")
            valores.append(nome)
        if AP is not None:
            campos.append("AP = %s")
            valores.append(AP)
        if penetMagica is not None:
            campos.append("penetMagica = %s")
            valores.append(penetMagica)
        if regMana is not None:
            campos.append("regMana = %s")
            valores.append(regMana)
        if vida is not None:
            campos.append("vida = %s")
            valores.append(vida)
        if armadura is not None:
            campos.append("armadura = %s")
            valores.append(armadura)
        if resistMagica is not None:
            campos.append("resistMagica = %s")
            valores.append(resistMagica)
        if danAtaque is not None:
            campos.append("danAtaque = %s")
            valores.append(danAtaque)
        if velocAtaque is not None:
            campos.append("velocAtaque = %s")
            valores.append(velocAtaque)
        if escudoConcedido is not None:
            campos.append("escudoConcedido = %s")
            valores.append(escudoConcedido)
        if curaConcedida is not None:
            campos.append("curaConcedida = %s")
            valores.append(curaConcedida)

        # Adicionar o idItem ao final da lista de valores
        valores.append(idItem)

        # Construir e executar a query SQL dinâmica
        query = f"""
        UPDATE itens
        SET {', '.join(campos)}
        WHERE idItem = %s;
        """
        cur = mysql.connection.cursor()
        cur.execute(query, valores)
        mysql.connection.commit()

        # Verificar se alguma linha foi afetada
        if cur.rowcount == 0:
            return jsonify({"error": "Item não encontrado ou sem alterações"}), 404

        return jsonify({"message": "Item atualizado com sucesso!"}), 200
    except Exception as e:
        return jsonify({"error": str(e)}), 500
