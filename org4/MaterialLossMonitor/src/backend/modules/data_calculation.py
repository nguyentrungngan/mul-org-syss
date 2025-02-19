def calculate_material_loss(mes_material, ftp_material, plc_material):
    A = ((mes_material + ftp_material) / 2) - plc_material
    B = (mes_material + ftp_material) / 2
    material_loss = (A / B) * 100
    return material_loss
