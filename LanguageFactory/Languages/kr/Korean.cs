using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.kr {
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
            this.AddMsg(MsgCode.Error, "오류");
            this.AddMsg(MsgCode.CannotDeleteLast, "삭제할 수 없습니다");
            this.AddMsg(MsgCode.EmptyName, "이름은 비워 둘 수 없습니다");
            this.AddMsg(MsgCode.LoadFailed, "로드하지 못함");
            this.AddMsg(MsgCode.SaveFailed, "저장하지 못했습니다.");
            this.AddMsg(MsgCode.EnterName, "이름 입력");
            this.AddMsg(MsgCode.Continue, "계속?");
            this.AddMsg(MsgCode.Configure, "구성");
            this.AddMsg(MsgCode.NoServices, "서비스를 찾을 수 없습니다");
            this.AddMsg(MsgCode.PairBluetooth, "Bluetooth 연결");
            this.AddMsg(MsgCode.EnterPin, "PIN 입력");
            this.AddMsg(MsgCode.PairedDevices, "연결된 디바이스");
            this.AddMsg(MsgCode.Pair, "연결하다");
            this.AddMsg(MsgCode.Unpair, "언페어링");
            this.AddMsg(MsgCode.Disconnect, "연결 끊기");
            this.AddMsg(MsgCode.Password, "암호");
            this.AddMsg(MsgCode.HostName, "호스트 이름");
            this.AddMsg(MsgCode.NetworkService, "네트워크 서비스");
            this.AddMsg(MsgCode.Port, "포트");
            this.AddMsg(MsgCode.NetworkSecurityKey, "네트워크 보안 키");


            //this.AddMsg(MsgCode., "");
        }

    }
}
