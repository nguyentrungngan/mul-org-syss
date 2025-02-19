from modules.data_calculation import calculate_material_loss

def process_data(plc_data, mes_data, ftp_data):
    material_loss = calculate_material_loss(mes_data, ftp_data, plc_data)
    return material_loss
