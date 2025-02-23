/*
Helper scripts for finding user and login information in SQL Server.
*/

SELECT
    name AS login_name,
    type_desc AS login_type,
    CASE WHEN is_disabled = 1 THEN 'Disabled' ELSE 'Enabled' END AS status
FROM sys.server_principals
WHERE type NOT IN ('G', 'R')
-- Exclude groups and roles
ORDER BY name;

SELECT name, type_desc, authentication_type_desc
FROM sys.database_principals
WHERE type NOT IN ('A', 'G', 'R', 'X')
    AND sid IS NOT NULL
    AND name != 'guest';
