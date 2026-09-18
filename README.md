# Coffee Shop POS Management System

## Giới thiệu

Coffee Shop POS Management System là đồ án cá nhân được xây dựng nhằm mô phỏng hệ thống quản lý và bán hàng tại cửa hàng cà phê.

Hệ thống được phát triển dựa trên quy trình nghiệp vụ thực tế, hỗ trợ các hoạt động từ gọi món, thanh toán, quản lý hóa đơn đến quản lý kho, nhập xuất hàng và theo dõi hoạt động kinh doanh thông qua báo cáo và Dashboard.

## Công nghệ sử dụng

- C#
- Windows Forms (WinForms)
- SQL Server
- Entity Framework Core
- LINQ
- Git / GitHub
- Visual Studio

## Kiến trúc hệ thống

Ứng dụng được xây dựng theo mô hình 3 lớp:

- **GUI (Graphical User Interface):** Xử lý giao diện và tương tác với người dùng.
- **BUS (Business Logic Layer):** Xử lý các quy tắc và nghiệp vụ của hệ thống.
- **DAL (Data Access Layer):** Truy xuất và thao tác dữ liệu.
- **MODEL:** Định nghĩa các entity và mô hình dữ liệu.

Cơ sở dữ liệu được xây dựng theo hướng Code First bằng Entity Framework Core và lưu trữ trên SQL Server.

## Chức năng chính

Hệ thống bao gồm các nhóm chức năng:

- Đăng nhập và phân quyền Manager/Cashier.
- Quản lý bàn.
- Gọi món và quản lý order.
- Quản lý menu và danh mục món.
- Quản lý topping.
- Quản lý khách hàng.
- Quản lý nhà cung cấp.
- Quản lý nguyên vật liệu và tồn kho.
- Quản lý công thức món.
- Quản lý phiếu nhập.
- Quản lý phiếu xuất.
- Quản lý hóa đơn.
- Thanh toán bằng nhiều phương thức.
- Quản lý chương trình khuyến mãi.
- Báo cáo doanh thu.
- Dashboard theo dõi hoạt động cửa hàng.
- Đổi mật khẩu và phân quyền người dùng.

## Cơ sở dữ liệu

Hệ thống sử dụng SQL Server để quản lý dữ liệu.

Một số nhóm dữ liệu chính gồm:

- Nhân viên
- Bàn
- Danh mục
- Món
- Topping
- Khách hàng
- Hóa đơn và chi tiết hóa đơn
- Khuyến mãi
- Nguyên vật liệu
- Công thức
- Nhà cung cấp
- Phiếu nhập
- Phiếu xuất
- Phương thức thanh toán

Các quan hệ và ràng buộc dữ liệu được cấu hình bằng Entity Framework Core Fluent API.

## Một số nghiệp vụ nổi bật

### Gọi món và thanh toán

Hỗ trợ gọi món tại bàn hoặc mang về, lựa chọn món/topping, khách hàng thành viên, khuyến mãi và nhiều phương thức thanh toán.

### Quản lý kho

Theo dõi tồn kho nguyên vật liệu và topping. Số lượng tồn được cập nhật dựa trên hoạt động nhập, xuất và bán hàng.

### Công thức món

Quản lý định lượng nguyên vật liệu cho từng món và hỗ trợ quy đổi đơn vị khi xử lý tồn kho.

### Báo cáo doanh thu

Truy vấn và tổng hợp dữ liệu hóa đơn đã thanh toán để phục vụ thống kê doanh thu và các chỉ tiêu kinh doanh theo khoảng thời gian.

### Dashboard

Tổng hợp các thông tin quan trọng của cửa hàng trên một màn hình nhằm hỗ trợ theo dõi nhanh tình trạng kinh doanh và tồn kho.

## Tài khoản Demo

Hệ thống có các tài khoản mẫu phục vụ mục đích chạy thử:

| Tài khoản | Mật khẩu | Vai trò |
|---|---|---|
| Manager | 123456 | Manager |
| Cash1 | 123456 | Cashier |
| Cash2 | 123456 | Cashier |

> Các tài khoản và mật khẩu trên chỉ là dữ liệu mẫu phục vụ mục đích học tập và demo.

## Mục đích dự án

Dự án được thực hiện nhằm vận dụng các kiến thức về:

- Phân tích nghiệp vụ.
- Phân tích và thiết kế hệ thống thông tin.
- Thiết kế cơ sở dữ liệu quan hệ.
- SQL và xử lý dữ liệu.
- Lập trình hướng đối tượng.
- Kiến trúc phần mềm nhiều lớp.
- Xây dựng ứng dụng desktop.
- Tổng hợp và trực quan hóa dữ liệu thông qua báo cáo và Dashboard.

## Tác giả

**Nguyễn Ngọc Quý**

Sinh viên ngành Hệ thống thông tin quản lý.
