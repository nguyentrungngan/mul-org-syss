#include <iostream>
#include "modbus/modbus.h"  // if Modbus machine
#include "database.h"        // if module to connect SQL Server
#include "SimpleIni.h" // if module to load config.init

void loadConfig(std::string &plc_ip, int &plc_port, std::string &db_host, std::string &db_user, std::string &db_pass, std::string &db_name) {
    CSimpleIniA ini;
    ini.SetUnicode();  
    if (ini.LoadFile("config.ini") < 0) {
        std::cerr << "Error: unable to read file config.ini" << std::endl;
        exit(1);
    }

    plc_ip = ini.GetValue("PLC", "IP", "192.168.1.100");
    plc_port = std::stoi(ini.GetValue("PLC", "PORT", "502"));

    db_host = ini.GetValue("Database", "HOST", "localhost");
    db_user = ini.GetValue("Database", "USERNAME", "sa");
    db_pass = ini.GetValue("Database", "PASSWORD", "yourpassword");
    db_name = ini.GetValue("Database", "DATABASE", "factory_db");
}

int main() {
    std::string plc_ip, db_host, db_user, db_pass, db_name;
    int plc_port;
    
    loadConfig(plc_ip, plc_port, db_host, db_user, db_pass, db_name);
    
    std::cout << "Connecting to PLC at " << plc_ip << ":" << plc_port << "..." << std::endl;

    // connect to PLC
    modbus_t *plc = modbus_new_tcp(plc_ip.c_str(), plc_port);
    if (modbus_connect(plc) == -1) {
        std::cerr << "Error: Unable to connect to PLC." << std::endl;
        return -1;

    // Read data
    uint16_t sensor_data;
    if (modbus_read_registers(plc, 0, 1, &sensor_data) == -1) {
        std::cerr << "Error: Unable to read from PLC." << std::endl;
    } else {
        std::cout << "Sensor value: " << sensor_data << std::endl;
        save_to_database(db_host, db_user, db_pass, db_name, sensor_data);  // Lưu vào SQL Server
    }

    modbus_close(plc);
    modbus_free(plc);
    return 0;
}
