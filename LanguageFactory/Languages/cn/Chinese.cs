using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.cn {
    class Chinese : SupportedLanguage {
        public Chinese() : base() {
            this.SetLanguage(LangCode.Chinese, "汉语");

            // Common messages
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
            //this.AddMsg(MsgCode., "");
        }

    }
}
