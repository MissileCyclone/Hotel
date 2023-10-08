CREATE TABLE Clients (
    ClientId INT PRIMARY KEY,
    LastName VARCHAR(50) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    MiddleName VARCHAR(50),
    PassportData VARCHAR(50) NOT NULL,
    Comment TEXT
);