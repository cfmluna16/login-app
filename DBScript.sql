use LoginApp;

create table Users
(
	UserId int identity(1,1) primary key,
	UserName varchar(255) not null,
	UserPassword varchar(255) not null,
	CreatedDate datetime null
)

create index _userName_idx on Users(UserName);

create procedure pr_create_user
	@userName varchar(255),
	@userPassword varchar(255)
as
	insert into Users values (@userName, @userPassword, GetDate());

create procedure pr_get_user_byusername
	@userName varchar(255)
as
	select * from Users where UserName = @userName;
