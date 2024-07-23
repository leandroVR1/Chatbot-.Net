-- Active: 1721753556983@@bb7vuyvmgp1ucuetd4f2-mysql.services.clever-cloud.com@3306@bb7vuyvmgp1ucuetd4f2
CREATE TABLE IncomingMessages (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    WaId VARCHAR(255) NOT NULL,
    Message TEXT NOT NULL,
    Timestamp DATETIME NOT NULL
);
