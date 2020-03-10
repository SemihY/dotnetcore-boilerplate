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
go


