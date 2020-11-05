using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.cn {
    class Chinese : SupportedLanguage {
        public Chinese() : base() {
            this.SetLanguage(LangCode.Chinese, "汉语");

            // Common messages
            this.AddMsg(MsgCode.save, "保存");
            this.AddMsg(MsgCode.login, "登录");
            this.AddMsg(MsgCode.logoff, "注销");
            this.AddMsg(MsgCode.copy, "复制");
            this.AddMsg(MsgCode.no, "否");
            this.AddMsg(MsgCode.yes, "是");
            this.AddMsg(MsgCode.New, "新");
            this.AddMsg(MsgCode.Ok, "确认");
            this.AddMsg(MsgCode.exit, "退出");
            this.AddMsg(MsgCode.start, "开始");
            this.AddMsg(MsgCode.stop, "停止");
            this.AddMsg(MsgCode.language, "语言");
            this.AddMsg(MsgCode.send, "发送");
            this.AddMsg(MsgCode.command, "命令");
            this.AddMsg(MsgCode.response, "响应");
            this.AddMsg(MsgCode.select, "选择");
            this.AddMsg(MsgCode.discover, "发现");
            this.AddMsg(MsgCode.connect, "连接");
            this.AddMsg(MsgCode.cancel, "取消");
            this.AddMsg(MsgCode.info, "信息");
            this.AddMsg(MsgCode.Settings, "设置");
            this.AddMsg(MsgCode.Terminators, "终止符");
            this.AddMsg(MsgCode.Name, "名称");
            this.AddMsg(MsgCode.Error, "错误");
            this.AddMsg(MsgCode.CannotDeleteLast, "不能删除最后一个");
            this.AddMsg(MsgCode.EmptyName, "名称不能为空");
            this.AddMsg(MsgCode.LoadFailed, "加载失败");
            this.AddMsg(MsgCode.SaveFailed, "未能保存");
            this.AddMsg(MsgCode.EnterName, "输入名称");
            this.AddMsg(MsgCode.Continue, "繼續?");
            this.AddMsg(MsgCode.Configure, "配置");
            this.AddMsg(MsgCode.NoServices, "未检测到服务");
            this.AddMsg(MsgCode.PairBluetooth, "对蓝牙设备进行配对");
            this.AddMsg(MsgCode.EnterPin, "输入 PIN 码");
            this.AddMsg(MsgCode.PairedDevices, "已配对的设备");
            this.AddMsg(MsgCode.Pair, "配对");
            this.AddMsg(MsgCode.Unpair, "取消配对");
            this.AddMsg(MsgCode.Disconnect, "断开连接");
            this.AddMsg(MsgCode.Password, "密码");
            this.AddMsg(MsgCode.HostName, "主机名");
            this.AddMsg(MsgCode.NetworkService, "网络服务");
            this.AddMsg(MsgCode.Port, "端口");
            this.AddMsg(MsgCode.NetworkSecurityKey, "网络安全密钥");
            this.AddMsg(MsgCode.Network, "网络");
            this.AddMsg(MsgCode.Socket, "套接字");
            this.AddMsg(MsgCode.Credentials, "凭据");
            this.AddMsg(MsgCode.About, "关于");
            this.AddMsg(MsgCode.Icons, "图标");
            this.AddMsg(MsgCode.Author, "作者");
            this.AddMsg(MsgCode.Services, "服务");
            this.AddMsg(MsgCode.Properties, "属性");
            this.AddMsg(MsgCode.Delete, "删除");
            this.AddMsg(MsgCode.UserManual, "用户手册");
            this.AddMsg(MsgCode.Vendor, "供应商");
            this.AddMsg(MsgCode.Product, "产品");
            this.AddMsg(MsgCode.Enabled, "已启用");
            this.AddMsg(MsgCode.Default, "默认");
            this.AddMsg(MsgCode.BaudRate, "波特率");
            this.AddMsg(MsgCode.DataBits, "数据位");
            this.AddMsg(MsgCode.StopBits, "停止位");
            this.AddMsg(MsgCode.Parity, "奇偶校验");
            this.AddMsg(MsgCode.FlowControl, "流控制");
            this.AddMsg(MsgCode.Read, "读取");
            this.AddMsg(MsgCode.Write, "写入");
            this.AddMsg(MsgCode.Timeout, "超时");
            this.AddMsg(MsgCode.Log, "记录");
            this.AddMsg(MsgCode.None, "无");
            this.AddMsg(MsgCode.NotFound, "找不到");
            this.AddMsg(MsgCode.NotConnected, "未连接");
            this.AddMsg(MsgCode.ConnectionFailure, "连接失败");
            this.AddMsg(MsgCode.ReadFailure, "读取失败");
            this.AddMsg(MsgCode.WriteFailue, "的写入故障");
            this.AddMsg(MsgCode.UnknownError, "未知错误");
            this.AddMsg(MsgCode.UnhandledError, "未处理的错误");

            //this.AddMsg(MsgCode., "");

        }

    }
}
