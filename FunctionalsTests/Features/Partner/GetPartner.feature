#language: pt

Funcionalidade: GET partner
    Cenário: resgatar um parceiro
	Dado que eu queira resgatar um parceiro
	Quando eu chamar o endpoint de get de parceiro com o email "TESTEGET@GMAIL.COM"
	Então eu devo receber o status "OK" e o conteudo da mensagem contendo "TESTEGET@GMAIL.COM"

	@regressivo
    Cenário: resgatar um parceiro passando email invalido
	Dado que eu queira deletar um parceiro
	Quando eu chamar o endpoint de get de parceiro com o email "TESTEGETGMAIL.COM"
	Então eu devo receber o status "BadRequest" e o conteudo da mensagem contendo "O Email infomado deve ser valido"

	@regressivo
    Cenário: resgatar um parceiro inexistente
	Dado que eu queira deletar um parceiro
	Quando eu chamar o endpoint de get de parceiro com o email "TESTEGETINEXISTENTE@GMAIL.COM"
	Então eu devo receber o status "NoContent" e o conteudo da mensagem contendo ""