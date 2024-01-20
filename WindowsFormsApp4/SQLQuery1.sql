select * from Flights;

--ALTER TABLE Flights
--ADD FlightTime TIME;

ALTER TABLE Flights  -- Replace "Flights" with your actual table name
ADD class varchar(20);

UPDATE Flights
SET class = DATEADD(HOUR, (RAND() * 5) + 1, DepartureTime);

ALTER TABLE Flights DROP COLUMN class;

select * from Flights