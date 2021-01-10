﻿using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.vi {
    public class Vietnamese : SupportedLanguage {

        public Vietnamese() : base() {
            this.SetLanguage(LangCode.Vietnamese, "Tiếng Việt Nam");

            // Common messages
            this.AddMsg(MsgCode.save, "Lưu");
            this.AddMsg(MsgCode.login, "Đăng nhập");
            this.AddMsg(MsgCode.logoff, "Đăng xuất");
            this.AddMsg(MsgCode.copy, "Sao");
            this.AddMsg(MsgCode.no, "Không");
            this.AddMsg(MsgCode.yes, "Có");
            this.AddMsg(MsgCode.New, "Mới");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Thoát");
            this.AddMsg(MsgCode.start, "Bắt đầu");
            this.AddMsg(MsgCode.stop, "Dừng lại");
            this.AddMsg(MsgCode.language, "Ngôn ngữ");
            this.AddMsg(MsgCode.send, "Gửi");
            this.AddMsg(MsgCode.command, "Lệnh");
            this.AddMsg(MsgCode.commands, "Lệnh");
            this.AddMsg(MsgCode.response, "Phản hồi");
            this.AddMsg(MsgCode.select, "Chọn");
            this.AddMsg(MsgCode.Search, "Tìm kiếm");
            this.AddMsg(MsgCode.connect, "Kết nối");
            this.AddMsg(MsgCode.cancel, "Hủy bỏ");
            this.AddMsg(MsgCode.info, "Thông tin");
            this.AddMsg(MsgCode.Settings, "Cài đặt");
            this.AddMsg(MsgCode.Terminators, "Terminators");
            this.AddMsg(MsgCode.Name, "Tên");
            this.AddMsg(MsgCode.Error, "Lỗi");
            this.AddMsg(MsgCode.CannotDeleteLast, "Không thể xóa mục cuối cùng");
            this.AddMsg(MsgCode.EmptyName, "Tên không thể rỗng");
            this.AddMsg(MsgCode.LoadFailed, "Không tải được");
            this.AddMsg(MsgCode.SaveFailed, "Không lưu được");
            this.AddMsg(MsgCode.EnterName, "Nhập tên");
            this.AddMsg(MsgCode.Continue, "Tiếp tục?");
            this.AddMsg(MsgCode.Configure, "Cấu hình");
            this.AddMsg(MsgCode.NoServices, "Không có Dịch vụ");
            this.AddMsg(MsgCode.PairBluetooth, "Ghép nối qua Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Nhập mã PIN");
            this.AddMsg(MsgCode.PairedDevices, "Thiết bị được ghép nối");
            this.AddMsg(MsgCode.Pair, "Ghép đôi");
            this.AddMsg(MsgCode.Unpair, "Bỏ ghép nối");
            this.AddMsg(MsgCode.Disconnect, "Ngắt kết nối");
            this.AddMsg(MsgCode.Password, "Mật khẩu");
            this.AddMsg(MsgCode.HostName, "Tên máy chủ");
            this.AddMsg(MsgCode.NetworkService, "Dịch vụ Mạng");
            this.AddMsg(MsgCode.Port, "Cổng");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Mã Bảo mật Mạng");
            this.AddMsg(MsgCode.Network, "Mạng");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Chứng danh");
            this.AddMsg(MsgCode.About, "Giới thiệu");
            this.AddMsg(MsgCode.Icons, "Biểu tượng");
            this.AddMsg(MsgCode.Author, "Tác giả");
            this.AddMsg(MsgCode.Services, "Dịch vụ");
            this.AddMsg(MsgCode.Properties, "Thuộc tính");
            this.AddMsg(MsgCode.Delete, "Xóa");
            this.AddMsg(MsgCode.UserManual, "Hướng dẫn sử dụng");
            this.AddMsg(MsgCode.Vendor, "Nhà cung cấp");
            this.AddMsg(MsgCode.Product, "Sản phẩm");
            this.AddMsg(MsgCode.Enabled, "Đã kích hoạt");
            this.AddMsg(MsgCode.Default, "Mặc định");
            this.AddMsg(MsgCode.BaudRate, "Tốc độ baud");
            this.AddMsg(MsgCode.DataBits, "Bit dữ liệu");
            this.AddMsg(MsgCode.StopBits, "Stop Bits");
            this.AddMsg(MsgCode.Parity, "Tính chẵn lẻ");
            this.AddMsg(MsgCode.FlowControl, "Flow Control");
            this.AddMsg(MsgCode.Read, "Đã đọc");
            this.AddMsg(MsgCode.Write, "Ghi");
            this.AddMsg(MsgCode.Timeout, "Hết giờ");
            this.AddMsg(MsgCode.Log, "Nhật ký");
            this.AddMsg(MsgCode.None, "Không co");
            this.AddMsg(MsgCode.NotFound, "Không tìm thấy");
            this.AddMsg(MsgCode.NotConnected, "Chưa kết nối");
            this.AddMsg(MsgCode.ConnectionFailure, "Lỗi Kết nối");
            this.AddMsg(MsgCode.ReadFailure, "Không đọc được");
            this.AddMsg(MsgCode.WriteFailue, "Không ghi được");
            this.AddMsg(MsgCode.UnknownError, "Lỗi không biết");
            this.AddMsg(MsgCode.UnhandledError, "Lỗi Chưa được xử lý");
            this.AddMsg(MsgCode.Support, "Hỗ trợ");
            this.AddMsg(MsgCode.Edit, "Chỉnh sửa");
            this.AddMsg(MsgCode.Create, "Tạo");
            this.AddMsg(MsgCode.NothingSelected, "Chưa chọn nội dung nào");
            this.AddMsg(MsgCode.DeleteFailure, "Không xóa được");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Không thể thêm tham số trống");
            this.AddMsg(MsgCode.AbandonChanges, "Bỏ thay đổi?");
            this.AddMsg(MsgCode.Warning, "CẢNH BÁO");
            this.AddMsg(MsgCode.Run, "Chạy");
            this.AddMsg(MsgCode.InsufficienPermissions, "Không Đủ Quyền");
            this.AddMsg(MsgCode.CodeSamples, "Mẫu mã số");
            this.AddMsg(MsgCode.AuthenticationType, "Loại Xác thực");
            this.AddMsg(MsgCode.EncryptionType, "Loại mật mã hóa");
            this.AddMsg(MsgCode.SignalStrength, "Cường độ tín hiệu");
            this.AddMsg(MsgCode.UpTime, "Thời gian Làm việc");
            this.AddMsg(MsgCode.MacAddress, "Địa chỉ MAC");
            this.AddMsg(MsgCode.Kind, "Loại");
            this.AddMsg(MsgCode.BeaconInterval, "Thời khoảng (beacon)");
            this.AddMsg(MsgCode.AccessStatus, "Trạng thái");
            this.AddMsg(MsgCode.AddressType, "Loại Địa chỉ");
            this.AddMsg(MsgCode.Paired, "Đã ghép nối");
            this.AddMsg(MsgCode.Connected, "Đã kết nối");
            this.AddMsg(MsgCode.ProtectionLevel, "Cấp độ bảo vệ");
            this.AddMsg(MsgCode.SecureConnection, "Kết nối an toàn");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Đã cho phép");
            this.AddMsg(MsgCode.Address, "Địa chỉ");
            this.AddMsg(MsgCode.DeviceClass, "Device Class");
            this.AddMsg(MsgCode.ServiceClass, "Lớp dịch vụ");
            this.AddMsg(MsgCode.LastSeen, "Last Seen");
            this.AddMsg(MsgCode.LastUsed, "Last Used");
            this.AddMsg(MsgCode.Authenticated, "Đã xác thực");
            this.AddMsg(MsgCode.RemoteHost, "Máy chủ Từ xa");
            this.AddMsg(MsgCode.RemoteService, "Dịch vụ từ xa");
            this.AddMsg(MsgCode.Clear, "Xóa");
            this.AddMsg(MsgCode.ResetAll, "Đặt lại Tất cả");


            //this.AddMsg(MsgCode., "");
        }



    }
}