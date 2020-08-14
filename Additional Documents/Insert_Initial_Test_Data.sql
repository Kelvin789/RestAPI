BEGIN TRAN

SELECT * 
FROM [UserAPI].[dbo].[Users]

SELECT * 
FROM [UserAPI].[dbo].[Leaderboard]

INSERT INTO [UserAPI].[dbo].[Users]
VALUES 
(1, 'Will', 'Smith', 'willsmith@example.com', 012345678901), 
(2, 'Peter', 'Griffin', null, null), 
(3, 'Brad', 'Pitt', 'bradpitt@example.com', 012345678901),
(4, 'Jennifer', 'Lawrence', null, null),
(5, 'Scarlett', 'Johansson', 'Scarlett@example.com', null),
(6, 'Angelina', 'Jolie', null, 012345678901)

INSERT INTO [UserAPI].[dbo].[Leaderboard]
VALUES 
(1, 101, 3),
(2, 500, 50),
(3, 40, 6),
(4, 60, 10),
(5, 10, 1),
(6, 90, 4)

SELECT * 
FROM [UserAPI].[dbo].[Users]

SELECT * 
FROM [UserAPI].[dbo].[Leaderboard]

COMMIT TRAN