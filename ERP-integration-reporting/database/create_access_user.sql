CREATE LOGIN erp_report_user WITH PASSWORD = 'StrongPass123!';
CREATE USER erp_report_user FOR LOGIN erp_report_user;
GRANT EXECUTE ON SCHEMA::erp_reports TO erp_report_user;
