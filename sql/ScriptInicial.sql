create database BdLogStore

use BdLogstore

Create Table Endereco(

    Id						Bigint Identity(1,1),
	Logradouro				Varchar(200),
	Numero					Varchar(20),	
    Complemento				Varchar(50),
    Bairro					Varchar(100),    
    Cidade					Varchar(100),    
	Estado					Varchar(50),
	UsuarioInclusaoId 		Bigint,
	UsuarioAlteracaoId		Bigint,
	DataInclusao			DateTime,
	DataAlteracao           Datetime,
	Deleted                 bit,
	
	Constraint PK_Endereco Primary Key (Id)
)


Create Table Cliente(

	Id						Bigint Identity(1,1),
	Nome					Varchar(200),
	Cpf						Varchar(14),
	Telefone				Varchar(20),
	UsuarioInclusaoId 		Bigint,
	UsuarioAlteracaoId		Bigint,
	DataInclusao			DateTime,
	DataAlteracao           Datetime,
	Deleted                 bit,
	
	Constraint PK_Cliente Primary Key (Id),
	Constraint Fk_Cliente_Endereco Foreign Key (EnderecoId) References Endereco(Id)
)



Go
Create Table Produto(
	Id						Bigint Identity(1,1),
	Descricao               Varchar(200),
	Valor					Decimal(15,8),	
	UsuarioInclusaoId 		Bigint,
	UsuarioAlteracaoId		Bigint,
	DataInclusao			DateTime,
	DataAlteracao           Datetime,
	Deleted                 bit,
	Constraint PK_Produto Primary Key (Id)	
)


--insert into Produto(Descricao,Valor,UsuarioInclusaoId,UsuarioAlteracaoId,DataInclusao,DataAlteracao,Deleted)
--values('3 Queijos',50.00,1,1,GETDATE(),GETDATE(),0)
--     ,('Frango com requeijão',59.99,1,1,GETDATE(),GETDATE(),0)
--	 ,('Mussarela',42.50,1,1,GETDATE(),GETDATE(),0)
--	 ,('Calabresa',42.50,1,1,GETDATE(),GETDATE(),0)
--	 ,('Pepperoni',55.00,1,1,GETDATE(),GETDATE(),0)
--	 ,('Portuguesa',45.00,1,1,GETDATE(),GETDATE(),0)
--	 ,('Veggie',59.99,1,1,GETDATE(),GETDATE(),0)


select * from Produto

Go



Create Table Pedido(

	Id						Bigint Identity(1,1),
	ClienteId               Bigint,
	Valor					Decimal(15,2),	
	UsuarioInclusaoId 		Bigint,
	UsuarioAlteracaoId		Bigint,
	DataInclusao			DateTime,
	DataAlteracao           Datetime,
	Deleted                 bit,

	Constraint PK_Pedido Primary Key (Id),
	Constraint Fk_Pedido_Cliente Foreign Key (ClienteId) References Cliente(Id)
)

GO

Create Table PedidoItem(

	Id						Bigint Identity(1,1),
	ProdutoId				Bigint,
	PedidoId				Bigint,
	MeioaMeio               Bit,
	Produto2Id				Bigint,
	ValorItem               Decimal(15,2),
	UsuarioInclusaoId 		Bigint,
	UsuarioAlteracaoId		Bigint,
	DataInclusao			DateTime,
	DataAlteracao           Datetime,
	Deleted                 bit,

	Constraint PK_Pedido_Item Primary Key (Id),
	Constraint Fk_PedidoItem_Produto Foreign Key (ProdutoId) References Produto(Id) ,
	Constraint Fk_PedidoItem_Pedido Foreign Key (PedidoId) References Pedido(Id) 
)





