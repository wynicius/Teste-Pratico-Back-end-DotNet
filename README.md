# Olá, Seja Muito Bem Vindo(a)! :wave:
### Me chamo Wynicius e este é o Back-end do meu teste prático para a seletiva de estágio da Blue Technology! :smiley:

# Back-end do projeto Agenda Blue

### Este é um projeto de exemplo que implementa uma API RESTful para gerenciar contatos em uma agenda, com um CRUD simples. O projeto foi desenvolvido usando o ASP.NET Core 7.0 e o banco de dados SQL Server.
## [Conheça o Front-end do projeto clicando aqui](https://github.com/wynicius/Teste-Pratico-Front-end-Vuejs)


# Estrutura do projeto

### O projeto está organizado em pastas da seguinte maneira:
- **Controllers**: contém as classes que implementam os controladores da API.
- **DataAccess**: contém as classes que implementam o acesso a dados usando o padrão.
- **Repository** com o Entity Framework Core.
- **Services**: contém as classes que implementam a lógica de negócios da aplicação.
- **DTOs**: contém as classes que definem os objetos de transferência de dados usados pela API.
- **Mappings**: contém as classes que definem os mapeamentos entre os objetos de transferência de dados e as entidades do banco de dados.
- **Migrations**: contém as migrações do banco de dados geradas pelo Entity Framework Core.
- **Models**: contém as classes que definem as entidades do banco de dados.
- **Injeção de Dependência**: contém injeções de dependência que garantem reutilização de códigos e aseparação de responsabilidades entre classes, como exemplo da classe ContatoController, em que são injetados três objetos: IContatoService, ILogger<ContatoService> e IMapper.

## Swagger:

### O projeto usa o Swagger para documentar a API. A documentação da API pode ser acessada em /swagger/index.html.
![Swagger](https://raw.githubusercontent.com/wynicius/pictures/main/Swagger.jpg)

# Tech

- [C#]
- [.Net]
- [Sql Server]

# Clonando o repositório

```sh
# clonar este repositório
$ git clone https://github.com/wynicius/Teste-Pratico-Back-end-DotNet

# Abra o prompt de comando e navegue até a pasta:
$ cd agenda-contatos

# digite esse comando:
$ dotnet build
```

# Rodando a aplicação:

```sh
# Acesse a API em:
$ https://localhost:5298
```

# Testando a API

## Aqui estão as rotas disponíveis na API:

### Autenticação
- POST /api/autenticacao/auth: Autentica o usuário, com identificação no DB e o token.
- GET /api/autenticacao/anonimo: Autentica o usuário anonimo.
- GET /api/autenticacao/autenticado: Verifica se o usuário está autenticado e retorno o seu nome.
- GET /api/autenticacao/usuario: verifica se o usuário é um usuário simples.
- GET /api/autenticacao/administrador: verifica se o usuário é um administrador.

### Usuarios
- GET /api/usuario/listar{email}: lista um usuário pelo Email.
- POST /api/usuario/criarUsuario: cria um novo usuário.
- DELETE /api/usuario/excluir/{id}: exclui um usuário pelo ID.

### Contatos
- GET /api/listartodos: lista todos os contatos.
- GET /api/listar/{id}: lista um contato pelo ID.
- POST /api/criar: cria um novo contato.
- PUT /api/editar: atualiza um contato existente.
- DELETE /api/excluir/{id}: exclui um contato pelo ID.

# [Conheça o Front-end do projeto clicando aqui](https://github.com/wynicius/Teste-Pratico-Front-end-Vuejs)

# Autor:

![Foto Perfil](https://avatars.githubusercontent.com/u/111314452?v=4) [![LinkedIn](https://img.shields.io/badge/LinkedIn-%230077B5.svg?logo=linkedin&logoColor=white)](https://linkedin.com/in/wynicius) 
