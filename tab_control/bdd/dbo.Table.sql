CREATE TABLE Demande
(
	[id] INT NOT NULL PRIMARY KEY, 
    [id_parents] INT NOT NULL, 
    [id_babysitter] NCHAR(10) NOT NULL, 
    [vu] NCHAR(10) NULL, 
    [accept] NCHAR(10) NULL
)
