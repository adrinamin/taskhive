CREATE LOGIN dev_user WITH PASSWORD = '$(Password)';
GO

CREATE DATABASE TaskHive;
GO

USE TaskHive;
GO

CREATE USER taskhive_dev_user FOR LOGIN dev_user;
GO

ALTER ROLE db_owner ADD MEMBER taskhive_dev_user;
GO
