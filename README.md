# APLICAÇÂO

Essa eh uma aplicacao back end utilizando .net6 e SQLServer, onde eh criado e salvo no DB objetos do tipo Usuario que possuem:
- Nome: nome do ususario eh um campo required;
- Cpf: Cpf do usuario eh um campo rquired, que eh unico por usuario, nao possibilitando crariar outro usuario com mesmo cpf (deve ser escrito no formato xxx.xxx.xxx-xx);
- Telefone: telefone do ususario eh um campo required;
- Email: email do ususario eh um campo required;
- Ativo: checagem pra identificar se eh um usuario ativo, pois podemos receber (GET) apenas usuarios ativos na rota ".../User/ativos";
- DataDeCriacao: data da criacao do usuario no formato dd/mm/yyyy criada automaticamente
- Id: campo key de identificacao

## FUNÇÕES

AdicionarUser: Checa se o cpf ja existe no DB, caso ja exista da um BadRequest, caso nao exista da um POST na rota ".../User";
GetUsers: retorna todos usuarios do DB;
GetById: retorna usario filtrado pelo id Unico;
UpdateUser: modifica usuario filtrado pelo ID, caso retorne algum user do ID pela rota "User/{id}", caso nao retorne nada retorna um BadRequest;
DeletUser: deleta usuario filtrado pelo ID, caso retorne algum user do ID pela rota "User/{id}", caso nao retorne nada retorna um BadRequest;
GetAtivo: retorna todos usuarios do DB com o tag ativo como true na rota ".../User/ativos";
