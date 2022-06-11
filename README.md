# Projeto MovieRentalCompany - Locadora
Esse repósitorio contém o codigo-fonte do projeto Movie Rental Company que é um sistema de locadora básica, com objetivo de salvar os dados dos clientes, locar filme e fazer locação do filme desejado.


### Começando..
Aplique as migrations no banco, com ajuda do nosso amigo Entity Framework Core, digite o comando:
```sh
update-database .
```

### Entidades
- Customer(Cliente)
- Movie(Filme)
- MovieRental(Locacao)

##### Customer
Dados do cliente.
| Name | Type |
| ------ | ------ |
| Id | int |
| Name | string |
| LastName | string |
| Email | string |
| IsActive | bool |

##### Movie
Dados do filme.
| Name | Type |
| ------ | ------ |
| Id | int |
| Name | string |
| Category | string |
| IsActive | bool |
| IsDeleted | DateTime? |

##### MovieRental
Dados do registro da locação.
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

- Cadastrar novos clientes
- Cadastrar novos filmes
- Locar filmes
- Não permitir que duplicidade de clientes
- Não permitir a exclusão física dos registros
- Notificar atraso durante a devolução do filme.


## Tech

MovieRentalCompany usa como tecnologia:
- [Entity Framework Core] - ORM
- [.NET 6] 
- [SQL LOCAL]

