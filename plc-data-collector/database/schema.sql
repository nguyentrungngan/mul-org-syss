-- Create a table to store PLC data for viewing
CREATE TABLE plc_data (
    id INT IDENTITY(1,1) PRIMARY KEY,
    plc_id INT NOT NULL,
    timestamp DATETIME DEFAULT GETDATE(),
    parameter_name NVARCHAR(100),
    value FLOAT,
    unit NVARCHAR(20)
);
