CREATE TABLE Rooms (
    RoomId INT PRIMARY KEY,
    Capacity INT NOT NULL,
    Comfort VARCHAR(20) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);