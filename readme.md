## Description  

**Credit API** is simple dotnet core application.
  
## Cloning  

```bash
$ git clone https://github.com/SemihY/dotnetcore-boilerplate.git
``` 

## Installing

- [ ] First 

```bash  
$ docker-compose up -d
```

- [ ] Second

You should connect db and create tables.

```sql

Use master

create table Credits
(
	Id bigint identity
		constraint Credits_pk
			primary key nonclustered,
	IdentificationNumber bigint not null,
	Name nvarchar(50) not null,
	Surname nvarchar(50)  not null,
	Salary bigint not null,
	TelephoneNumber nvarchar(50)  not null,
	CreditLimit bigint not null
)

```  

## Running

# Swagger

$ localhost:8000



