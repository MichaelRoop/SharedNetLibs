using LanguageFactory.data;
using LanguageFactory.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Languages.cn {
    class Chinese : SupportedLanguage {
        public Chinese() : base() {
            this.SetLanguage(LangCode.Chinese, "汉语");

            // Common messages
            this.AddMsg(MsgCode.exit, "退出");
            this.AddMsg(MsgCode.start, "开始");
            this.AddMsg(MsgCode.stop, "停止");
            this.AddMsg(MsgCode.language, "语言");
            //this.AddMsg(MsgCode., "");
        }

    }
}
