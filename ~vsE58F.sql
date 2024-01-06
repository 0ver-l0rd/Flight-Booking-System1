SELECT USER_NAME(2);


CREATE TABLE Accounts (
    ID INT IDENTITY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Username VARCHAR(50),
    Password VARCHAR(50),
    PRIMARY KEY(ID)
)

CREATE TABLE Flights (
    ID INT IDENTITY,
    DepartureCity VARCHAR(50),
    ArrivalCity VARCHAR(50),
    DepartureTime DATETIME,
    Price DECIMAL(10, 2),
    SeatingCapacity INT,
    PRIMARY KEY(ID)
)

CREATE TABLE Reservations (
    ID INT IDENTITY,
    Account_ID INT,
    Flight_ID INT,
    SeatNumber INT,
    PRIMARY KEY(ID),
    FOREIGN KEY(Account_ID) REFERENCES Accounts(ID),
    FOREIGN KEY(Flight_ID) REFERENCES Flights(ID)
)

-- Insert dummy data into Accounts
INSERT INTO Accounts (FirstName, LastName, Username, Password)
VALUES 
('John1', 'Doe1', 'john1doe', 'password123'),
('Jane2', 'Doe2', 'jane2doe', 'password123'),
('John3', 'Doe3', 'john3doe', 'password123'),
('Jane4', 'Doe4', 'jane4doe', 'password123'),
('John5', 'Doe5', 'john5doe', 'password123'),
('Jane6', 'Doe6', 'jane6doe', 'password123'),
('John7', 'Doe7', 'john7doe', 'password123'),
('Jane8', 'Doe8', 'jane8doe', 'password123'),
('John9', 'Doe9', 'john9doe', 'password123'),
('Jane10', 'Doe10', 'jane10doe', 'password123'),
('John11', 'Doe11', 'john11doe', 'password123'),
('Jane12', 'Doe12', 'jane12doe', 'password123'),
('John13', 'Doe13', 'john13doe', 'password123'),
('Jane14', 'Doe14', 'jane14doe', 'password123'),
('John15', 'Doe15', 'john15doe', 'password123'),
('Jane16', 'Doe16', 'jane16doe', 'password123'),
('John17', 'Doe17', 'john17doe', 'password123'),
('Jane18', 'Doe18', 'jane18doe', 'password123'),
('John19', 'Doe19', 'john19doe', 'password123'),
('Jane20', 'Doe20', 'jane20doe', 'password123'),
('John21', 'Doe21', 'john21doe', 'password123'),
('Jane22', 'Doe22', 'jane22doe', 'password123'),
('John23', 'Doe23', 'john23doe', 'password123'),
('Jane24', 'Doe24', 'jane24doe', 'password123'),
('John25', 'Doe25', 'john25doe', 'password123'),
('Jane26', 'Doe26', 'jane26doe', 'password123'),
('John27', 'Doe27', 'john27doe', 'password123'),
('Jane28', 'Doe28', 'jane28doe', 'password123'),
('John29', 'Doe29', 'john29doe', 'password123'),
('Jane30', 'Doe30', 'jane30doe', 'password123')
-- Insert dummy data into Flights
INSERT INTO Flights (DepartureCity, ArrivalCity, DepartureTime, Price, SeatingCapacity)
VALUES 
('New York', 'London', '2023-12-31 23:59:59', 500.00, 200),
('London', 'Paris', '2024-01-01 23:59:59', 510.00, 200),
('Paris', 'Berlin', '2024-01-02 23:59:59', 520.00, 200),
('Berlin', 'Rome', '2024-01-03 23:59:59', 530.00, 200),
('Rome', 'Madrid', '2024-01-04 23:59:59', 540.00, 200),
('Madrid', 'Lisbon', '2024-01-05 23:59:59', 550.00, 200),
('Lisbon', 'Dublin', '2024-01-06 23:59:59', 560.00, 200),
('Dublin', 'Edinburgh', '2024-01-07 23:59:59', 570.00, 200),
('Edinburgh', 'Oslo', '2024-01-08 23:59:59', 500.00, 200),
('Oslo', 'Helsinki', '2024-01-09 23:59:59', 500.00, 200),
('Edinburgh', 'Oslo', '2024-01-08 23:59:59', 580.00, 200),
('Oslo', 'Helsinki', '2024-01-09 23:59:59', 590.00, 200),
('Helsinki', 'Copenhagen', '2024-01-10 23:59:59', 600.00, 200),
('Copenhagen', 'Amsterdam', '2024-01-11 23:59:59', 610.00, 200),
('Amsterdam', 'Brussels', '2024-01-12 23:59:59', 620.00, 200),
('Brussels', 'Vienna', '2024-01-13 23:59:59', 630.00, 200),
('Vienna', 'Budapest', '2024-01-14 23:59:59', 640.00, 200),
('Budapest', 'Prague', '2024-01-15 23:59:59', 650.00, 200),
('Prague', 'Warsaw', '2024-01-16 23:59:59', 660.00, 200),
('Warsaw', 'Athens', '2024-01-17 23:59:59', 670.00, 200),
('Athens', 'Istanbul', '2024-01-18 23:59:59', 680.00, 200),
('Helsinki', 'Copenhagen', '2024-01-10 23:59:59', 500.00, 200),
('Copenhagen', 'Amsterdam', '2024-01-11 23:59:59', 500.00, 200),
('Amsterdam', 'Brussels', '2024-01-12 23:59:59', 500.00, 200),
('Brussels', 'Vienna', '2024-01-13 23:59:59', 500.00, 200),
('Vienna', 'Budapest', '2024-01-14 23:59:59', 500.00, 200),
('Budapest', 'Prague', '2024-01-15 23:59:59', 500.00, 200),
('Prague', 'Warsaw', '2024-01-16 23:59:59', 500.00, 200),
('Warsaw', 'Athens', '2024-01-17 23:59:59', 500.00, 200),
('Istanbul', 'Moscow', '2024-01-19 23:59:59', 690.00, 200)
-- Insert dummy data into Reservations
INSERT INTO Reservations (Account_ID, Flight_ID, SeatNumber)
VALUES 
(1, 1, 1),
(2, 2, 2),
(3, 3, 3),
(4, 4, 4),
(5, 5, 5),
(6, 6, 6),
(7, 7, 7),
(8, 8, 8),
(9, 9, 9),
(10, 10, 10),
(11, 11, 11),
(12, 12, 12),
(13, 13, 13),
(14, 14, 14),
(15, 15, 15),
(16, 16, 16),
(17, 17, 17),
(18, 18, 18),
(19, 19, 19),
(20, 20, 20),
(21, 21, 21),
(22, 22, 22),
(23, 23, 23),
(24, 24, 24),
(25, 25, 25),
(26, 26, 26),
(27, 27, 27),
(28, 28, 28),
(29, 29, 29),
(30, 30, 30)