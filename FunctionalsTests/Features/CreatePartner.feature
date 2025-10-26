#language: pt

Funcionalidade: POST partner
  Cenário: Criar um novo parceiro
    Dado que eu queira adicionar um novo parceiro
    Quando eu chamar o endpoint de criação de parceiro passando o email "TESTE@GMAIL.COM" e o usuario "TESTE"
    Então eu devo receber o status "OK" e a mensagem "Parceiro inserido com sucesso"
    
    @regressivo
  Cenário: Criar um parceiro com email já existente
    Dado que eu queira adicionar um novo parceiro
    Quando eu chamar o endpoint de criação de parceiro passando o email "TESTE@GMAIL.COM" e o usuario "TESTE"
    Então eu devo receber o status "BadRequest" e a mensagem "Já existe um parceiro com o email informado"