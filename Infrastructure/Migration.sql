CREATE TABLE Cars (
                      CarId INT PRIMARY KEY,
                      Model VARCHAR(100),
                      Manufacturer VARCHAR(100),
                      Year INT,
                      PricePerDay DECIMAL(10, 2)
);

CREATE TABLE Customers (
                           CustomerId INT PRIMARY KEY,
                           FullName VARCHAR(150),
                           Phone VARCHAR(20),
                           Email VARCHAR(150)
);

CREATE TABLE Rentals (
                         RentalId INT PRIMARY KEY,
                         CarId INT,
                         CustomerId INT,
                         StartDate DATE,
                         EndDate DATE,
                         TotalCost DECIMAL(10, 2),
                         FOREIGN KEY (CarId) REFERENCES Cars(CarId),
                         FOREIGN KEY (CustomerId) REFERENCES Customers(CustomerId)
);

CREATE TABLE Locations (
                           LocationId INT PRIMARY KEY,
                           City VARCHAR(100),
                           Address VARCHAR(200)
);

CREATE TABLE CarLocations (
                              CarId INT,
                              LocationId INT,
                              PRIMARY KEY (CarId, LocationId),
                              FOREIGN KEY (CarId) REFERENCES Cars(CarId),
                              FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
);



INSERT INTO Cars (CarId, Model, Manufacturer, Year, PricePerDay)
VALUES (1, 'Camry', 'Toyota', 2020, 50.00),
       (2, 'Accord', 'Honda', 2021, 55.00),
       (3, 'Model S', 'Tesla', 2022, 100.00),
       (4, 'Civic', 'Honda', 2020, 45.00),
       (5, 'Corolla', 'Toyota', 2019, 40.00);

INSERT INTO Customers (CustomerId, FullName, Phone, Email)
VALUES (1, 'John Doe', '123-456-7890', 'johndoe@example.com'),
       (2, 'Jane Smith', '234-567-8901', 'janesmith@example.com'),
       (3, 'Emily Davis', '345-678-9012', 'emilydavis@example.com');

INSERT INTO Locations (LocationId, City, Address)
VALUES (1, 'New York', '123 5th Ave'),
       (2, 'Los Angeles', '456 Sunset Blvd'),
       (3, 'Chicago', '789 Wacker Dr');

INSERT INTO CarLocations (CarId, LocationId)
VALUES (1, 1),
       (2, 1),
       (3, 2),
       (4, 3),
       (5, 3);

INSERT INTO Rentals (RentalId, CarId, CustomerId, StartDate, EndDate, TotalCost)
VALUES (1, 1, 1, '2024-12-01', '2024-12-07', 350.00),
       (2, 3, 2, '2024-12-05', '2024-12-10', 500.00),
       (3, 4, 3, '2024-12-02', '2024-12-06', 180.00);

