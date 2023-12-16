# Projeto MovieRentalCompany - Locadora
Esse repósitorio contém o codigo-fonte do projeto Movie Rental Company que é um sistema de locadora básica, com objetivo de salvar os dados dos clientes e alocar filmes.

## Tech

- ![Entity Framework Core](https://img.shields.io/badge/-EF%20Core-512BD4?style=flat-square&logo=efCore&logoColor=white) - ORM
- ![.NET 6](https://img.shields.io/badge/-dotnet-512BD4?style=flat-square&logo=dotnet&logoColor=white) 
- ![SQL Serve](https://img.shields.io/badge/-SQL%20Server-CC2927?style=flat-square&logo=microsoft-sql-server&logoColor=white)


## Entidades do Projeto
- Customer(Cliente)
- Movie(Filme)
- MovieRental(Locacao)

#### Customer
Dados do cliente.
| Name | Type |
| ------ | ------ |
| Id | int |
| Name | string |
| LastName | string |
| Email | string |
| IsActive | bool |

#### Movie
Dados do filme.
| Name | Type |
| ------ | ------ |
| Id | int |
| Name | string |
| Category | string |
| IsActive | bool |
| IsDeleted | DateTime? |

#### MovieRental
Dados do registro da alocação.
| Name | Type |
| ------ | ------ |
| Id | int |
| Id_Customer | int |
| Id_Movie | int |
| Creater | DateTime |
| Devolution | DateTime? |
| PrevisionDevolution | DateTime |
| Canceled | DateTime? |


## Features

- Cadastrar novos clientes e filmes
- ALocar, remover ou adicionar filmes

## Regras das funcionalidades
- Não permitir a duplicidade de clientes
- Apenas Exclusão logicas para casos de remoção de filme



### Começando..
Aplique as migrations no banco com ajuda do nosso amigo Entity Framework Core, digite o comando:
```sh
update-database
```
### Arquitetura do Projeto

O projeto é organizado em quatro camadas principais: Company, Domain, Infrastructure e Services.

| Camada | Objetivo |
| ------ | ------ |
| Company | Esta camada é responsável por receber as requisições e abriga os controllers. Aqui, as interações com o mundo externo são tratadas, recebendo e respondendo a solicitações. |
| Domain | A camada Domain engloba entidades, DTOs (Data Transfer Objects), interfaces e modelos de mensagens. Aqui, definimos as estruturas de dados essenciais para o domínio da aplicação, garantindo uma representação consistente e clara dos conceitos. |
| Infrstrucutre | A camada Infrastructure gerencia o acesso aos dados, hospedando o repositório responsável pela comunicação com o banco de dados. Ela concentra-se na implementação de detalhes de infraestrutura, isolando as preocupações relacionadas ao armazenamento de dados.|
| Services | A camada Services assume a responsabilidade de executar as funcionalidades da lógica de negócios. Antes de efetuar qualquer alteração no banco de dados, as operações e regras de negócio são implementadas nesta camada para garantir consistência e integridade. Essa estrutura proporciona uma separação clara de responsabilidades, facilitando a manutenção e evolução do sistema. Cada camada desempenha um papel específico, contribuindo para a coesão e a modularidade do projeto. |


### Entendendo o codigo

## Controllers
Com o intuito de centralizar métodos comuns, como  consulta por ID, que são compartilhados por vários controllers na camada Company, foi introduzido um Controller Genérico. Essa abordagem simplifica a implementação nos controllers específicos, promovendo a consistência e facilitando a manutenção.

Essa estrutura de controle genérico oferece uma maneira eficiente de lidar com operações comuns entre diferentes entidades, garantindo a coesão e a reutilização de código em toda a aplicação.

Segue um exemplo no qual foi usado no projeto:

```
public class CustomerController : VideoRentalStoreGenericController<Customer, IServices<Movie>>{
    private readonly IServices<Customer> _services;
        public CustomerController(IServices<Customer> services) : base(services) 
        {
            _services = services;
        }   
}
```