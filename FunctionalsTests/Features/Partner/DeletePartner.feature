#language: pt

Funcionalidade: DELETE partner
    Cenário: Deletar um parceiro
	Dado que eu queira deletar um parceiro
	Quando eu chamar o endpoint de deleção de parceiro com o email "TESTEDELETE@GMAIL.COM"
	Então eu devo receber o status "OK" com a mensagem "Parceiro deletado com sucesso"

	@regressivo
    Cenário: Deletar um parceiro passando um email invalido
	Dado que eu queira deletar um parceiro  
	Quando eu chamar o endpoint de deleção de parceiro com o email "TESTEDELETEGMAIL.COM"
	Então eu devo receber o status "BadRequest" com a mensagem "O email infomado deve ser valido"

	@regressivo
    Cenário: Deletar um parceiro inexistente
	Dado que eu queira deletar um parceiro 
	Quando eu chamar o endpoint de deleção de parceiro com o email "TESTEDELETEINEXISTENTE@GMAIL.COM"
	Então eu devo receber o status "OK" com a mensagem "Parceiro deletado com sucesso"