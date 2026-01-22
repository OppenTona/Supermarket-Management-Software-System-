# Supermarket Management Software System

A comprehensive Windows Forms application developed in C# for managing supermarket operations with full CRUD (Create, Read, Update, Delete) functionality.

## 👥 Team members

- Team Leader: Nguyễn Thị Thanh Vân (ThanhVan2024)
- Member: Nguyễn Thế Toàn (OppenTona)
- Member: Lưu Hiểu Khánh (HieuKhanh04)
- Member: Lê Hà Phương (LeHaPhuong2004)

## 🌟 Features

### Core Functionality
- **Employee Management** (Quản lý Nhân viên): Complete employee information management including personal details, positions, and salary tracking
- **Product Category Management** (Quản lý Loại sản phẩm): Organize products into categories with detailed descriptions
- **Product Management** (Quản lý Sản phẩm): Full product lifecycle management including inventory tracking, pricing, and supplier information
- **Inventory Management**: 
  - **Stock In** (Nhập kho): Record incoming inventory with supplier details
  - **Stock Out** (Xuất kho): Track outgoing products and stock levels
- **User Account Management** (Quản lý Tài khoản): Role-based access control with admin and user permissions
- **Statistics & Reports** (Thống kê): Generate comprehensive reports and analytics
- **Secure Login System** (Đăng nhập): Authentication with role-based authorization

### Security Features
- Role-based access control (Admin/User)
- Secure login authentication
- Different permission levels for different user types

## 🏗️ System Architecture

### Database Structure
The system uses SQL Server with the following main tables:
- **LoaiSP**: Product categories
- **NhanVien**: Employee information
- **SanPham**: Product details and inventory
- **NhapKho**: Stock intake records
- **XuatKho**: Stock outflow records
- **QuanLyTK**: User account management

### Technology Stack
- **Frontend**: Windows Forms (.NET Framework)
- **Backend**: C#
- **Database**: SQL Server
- **IDE**: Visual Studio

## 🚀 Getting Started

### Prerequisites
- Visual Studio 2019 or later
- .NET Framework 4.7.2 or later
- SQL Server (LocalDB or full version)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/OppenTona/Supermarket-Management-Software-System-.git
   cd Supermarket-Management-Software-System-
   ```

2. **Database Setup**
   - Open SQL Server Management Studio
   - Execute the SQL script located at `demo/SQLQLKhoHang.sql` to create the database and tables
   - Update the connection string in the application if needed

3. **Build and Run**
   - Open `demo/demo.sln` in Visual Studio
   - Build the solution (Ctrl+Shift+B)
   - Run the application (F5)

### Default Login
The application includes a login system. Please refer to your database setup for initial login credentials.

## 📋 Usage

### For Administrators
- Full access to all modules
- Employee management capabilities
- User account creation and management
- Complete system statistics and reports

### For Regular Users
- Limited access based on role permissions
- Product and inventory management
- Basic reporting features
- Stock in/out operations

## 🗂️ Project Structure

```
demo/
├── demo/                          # Main application folder
│   ├── Form1.cs                   # Main application form
│   ├── form_Dangnhap.cs          # Login form
│   ├── fm_NhanVien.cs            # Employee management
│   ├── fm_LoaiSP.cs              # Product category management
│   ├── fm_SanPham.cs             # Product management
│   ├── fm_NhapKho.cs             # Stock intake management
│   ├── fm_XuatKho.cs             # Stock outflow management
│   ├── fm_TaiKhoan.cs            # Account management
│   ├── fm_ThongKe.cs             # Statistics and reports
│   └── ...
├── SQLQLKhoHang.sql              # Database creation script
└── demo.sln                      # Visual Studio solution file
```

## 🔧 Configuration

### Database Connection
Update the connection string in your forms to match your SQL Server configuration:
```csharp
String str = "Server=localhost;Database=QLKhoHang;Trusted_Connection=true";
```

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is developed for educational purposes. Please check with the repository owner for specific licensing terms.

## 🐛 Bug Reports & Feature Requests

Please use the [Issues](https://github.com/OppenTona/Supermarket-Management-Software-System-/issues) section to report bugs or request new features.

## 📞 Support

For support and questions, please create an issue in the repository or contact the development team.

---

**Note**: This is a Vietnamese-developed application with forms and interfaces in Vietnamese language. The database structure and business logic are designed specifically for supermarket/warehouse management operations.
