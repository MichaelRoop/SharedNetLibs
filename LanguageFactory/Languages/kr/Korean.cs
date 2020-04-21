using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.kr {
    class Korean : SupportedLanguage {
        public Korean() : base() {
            this.SetLanguage(LangCode.Korean, "한국어");

            // Common messages
            this.AddMsg(MsgCode.save, "저장");
            this.AddMsg(MsgCode.login, "로그인");
            this.AddMsg(MsgCode.logoff, "로그오프하다");
            this.AddMsg(MsgCode.copy, "복사하다");
            this.AddMsg(MsgCode.no, "아니");
            this.AddMsg(MsgCode.yes, "예");
            this.AddMsg(MsgCode.New, "신규");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "종료");
            this.AddMsg(MsgCode.start, "시작");
            this.AddMsg(MsgCode.stop, "중지");
            this.AddMsg(MsgCode.language, "언어");
            this.AddMsg(MsgCode.send, "보내다");
            this.AddMsg(MsgCode.command, "명령");
            this.AddMsg(MsgCode.response, "응답");
            this.AddMsg(MsgCode.select, "선택");
            this.AddMsg(MsgCode.discover, "디스커버");
            this.AddMsg(MsgCode.connect, "연결하다");
            this.AddMsg(MsgCode.cancel, "취소");
            this.AddMsg(MsgCode.info, "정보");
            this.AddMsg(MsgCode.Settings, "설정");
            this.AddMsg(MsgCode.Terminators, "종결자");
            this.AddMsg(MsgCode.Name, "이름");


            //this.AddMsg(MsgCode., "");
        }

    }
}
