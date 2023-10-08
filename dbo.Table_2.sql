CREATE TABLE Accommodations (
    AccommodationId INT PRIMARY KEY,
    ClientId INT NOT NULL,
    RoomId INT NOT NULL,
    CheckInDate DATETIME NOT NULL,
    CheckOutDate DATETIME,
    Comment TEXT,
    FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
    FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
);