
CREATE TABLE alert_logs (
    id SERIAL PRIMARY KEY,
    rule_name VARCHAR(255) NOT NULL,
    source VARCHAR(50) NOT NULL, -- plc, mes, manual
    value FLOAT NOT NULL,
    threshold FLOAT NOT NULL,
    status VARCHAR(50) NOT NULL, -- triggered, normal
    timestamp TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);


SELECT tag_name, value, timestamp
FROM plc_data
WHERE timestamp >= NOW() - INTERVAL '1 hour';


SELECT parameter_name, value, timestamp
FROM mes_data
WHERE timestamp >= NOW() - INTERVAL '1 hour';


SELECT field_name, value, timestamp
FROM manual_data
WHERE timestamp >= NOW() - INTERVAL '1 hour';


SELECT p.tag_name, p.value, r.threshold, 
    CASE WHEN p.value > r.threshold THEN 'triggered' ELSE 'normal' END AS status
FROM plc_data p
JOIN rule_settings r ON p.tag_name = r.rule_name
WHERE p.timestamp >= NOW() - INTERVAL '1 hour';


INSERT INTO alert_logs (rule_name, source, value, threshold, status)
VALUES ('temperature_threshold', 'plc', 105, 100, 'triggered');


SELECT * FROM alert_logs ORDER BY timestamp DESC LIMIT 10;
