
-- Sample query to retrieve the latest data for each PLC
SELECT plc_id, parameter_name, value, unit, timestamp
FROM plc_data
WHERE timestamp = (SELECT MAX(timestamp) FROM plc_data AS sub WHERE sub.plc_id = plc_data.plc_id);

-- Sample query to retrieve historical data for a specific PLC
SELECT * FROM plc_data 
WHERE plc_id = @plc_id 
AND timestamp BETWEEN @start_time AND @end_time
ORDER BY timestamp ASC;
