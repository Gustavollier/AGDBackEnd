#language: pt

Funcionalidade: POST complaint
  Cenário: Criar uma nova denuncia
    Dado que eu queira criar uma nova denuncia
    Quando eu chamar o endpoint de criação de denuncia passando a category "0", description "Criacao de denuncia para testar o fluxo" e parceiro com email "" e nome "" 
    Então eu devo receber o status "OK" e a mensagem de retorno "Denuncia criada com sucesso"

  Cenário: Criar uma nova denuncia com um parceiro informado
    Dado que eu queira criar uma nova denuncia
    Quando eu chamar o endpoint de criação de denuncia passando a category "0", description "Criacao de denuncia para testar o fluxo" e parceiro com email "exemplo@gmail.com" e nome "Teste" 
    Então eu devo receber o status "OK" e a mensagem de retorno "Denuncia criada com sucesso"

        @regressivo
 Cenário: Criar uma nova denuncia informando um parceiro com email invalido
    Dado que eu queira criar uma nova denuncia
    Quando eu chamar o endpoint de criação de denuncia passando a category "0", description "Criacao de denuncia para testar o fluxo" e parceiro com email "CRIACAODENUNCIAgmail.com" e nome "Teste" 
    Então eu devo receber o status "BadRequest" e a mensagem de retorno "Email invalido"

        @regressivo
 Cenário: Criar uma nova denuncia informando com um parceiro inexistente
    Dado que eu queira criar uma nova denuncia
    Quando eu chamar o endpoint de criação de denuncia passando a category "0", description "Criacao de denuncia para testar o fluxo" e parceiro com email "CRIACAODENUNCIA@gmail.com" e nome "Teste" 
    Então eu devo receber o status "BadRequest" e a mensagem de retorno "Parceiro inválido para esta denúncia"
