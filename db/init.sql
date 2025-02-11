IF NOT EXISTS (SELECT 1
FROM sys.server_principals
WHERE name = 'dev_user')
BEGIN
    CREATE LOGIN dev_user WITH PASSWORD = '$(Password)';
END;
GO

IF NOT EXISTS (SELECT 1
FROM sys.databases
WHERE name = 'TaskHive')
BEGIN
    CREATE DATABASE TaskHive;
END;
GO

USE TaskHive;
GO

IF NOT EXISTS (SELECT 1
FROM sys.database_principals
WHERE name = 'taskhive_dev_user')
BEGIN
    CREATE USER taskhive_dev_user FOR LOGIN dev_user;
END;
GO

ALTER ROLE db_owner ADD MEMBER taskhive_dev_user;
GO
