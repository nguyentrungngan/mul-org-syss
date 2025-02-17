# Backend - Hướng Dẫn Cài Đặt & Triển Khai

## 1. Mục Đích
Backend cung cấp API xử lý dữ liệu cho hệ thống, bao gồm các chức năng như đăng nhập, phê duyệt dữ liệu hình ảnh, và cung cấp API RESTful cho frontend.

## 2. Chức Năng Chính
- Xử lý đăng nhập, xác thực người dùng (Login API).
- Quản lý dữ liệu hình ảnh (Display Store, Display Upload, Display Approval APIs).
- Đồng bộ hóa nhật ký (Sync Logs API).
- Cung cấp API RESTful cho frontend (React, Vue, v.v.).

## 3. Hướng Dẫn Cài Đặt
### Bước 1: Tạo & Kích Hoạt Môi Trường Ảo
#### Trên Windows (CMD/Git Bash)

Download and Install Python: https://www.python.org/downloads/ then

```sh
python -m venv venv
venv\Scripts\activate
```

### Bước 2: Cài Đặt Các Gói Cần Thiết
```sh
pip install -r requirements.txt
```

### Bước 3: Cấu Hình Biến Môi Trường
Tạo file `int.env` và thiết lập các giá trị cần thiết:
```
DATABASE_URL=mysql+pymysql://user:password@localhost/your_database
SECRET_KEY=mysecretkey
HOST=127.0.0.1
PORT=8000
```

### Bước 4: Chạy Server Backend
```sh
uvicorn main:app --host 0.0.0.0 --port 8000 --reload
```

### Bước 5: Kiểm Tra API
Mở trình duyệt và truy cập:
- **Docs API**: [http://127.0.0.1:8000/docs](http://127.0.0.1:8000/docs)
- **Redoc API**: [http://127.0.0.1:8000/redoc](http://127.0.0.1:8000/redoc)

### Bước 6: Tắt Môi Trường Ảo (Nếu Cần)
```sh
deactivate
```

