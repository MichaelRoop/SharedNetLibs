﻿using LanguageFactory.Net.data;
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
            this.AddMsg(MsgCode.commands, "명령");
            this.AddMsg(MsgCode.response, "응답");
            this.AddMsg(MsgCode.select, "선택");
            this.AddMsg(MsgCode.Search, "검색");
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
            this.AddMsg(MsgCode.Network, "네트워크");
            this.AddMsg(MsgCode.Socket, "소켓");
            this.AddMsg(MsgCode.Credentials, "자격 증명");
            this.AddMsg(MsgCode.About, "정보");
            this.AddMsg(MsgCode.Icons, "아이콘");
            this.AddMsg(MsgCode.Author, "만든 이");
            this.AddMsg(MsgCode.Services, "서비스");
            this.AddMsg(MsgCode.Properties, "속성");
            this.AddMsg(MsgCode.Delete, "삭제");
            this.AddMsg(MsgCode.UserManual, "사용자 매뉴얼");
            this.AddMsg(MsgCode.Vendor, "공급업체");
            this.AddMsg(MsgCode.Product, "제품");
            this.AddMsg(MsgCode.Enabled, "사용");
            this.AddMsg(MsgCode.Default, "기본값");
            this.AddMsg(MsgCode.BaudRate, "전송 속도");
            this.AddMsg(MsgCode.DataBits, "데이터 비트");
            this.AddMsg(MsgCode.StopBits, "정지 비트");
            this.AddMsg(MsgCode.Parity, "패리티");
            this.AddMsg(MsgCode.FlowControl, "흐름 제어");
            this.AddMsg(MsgCode.Read, "읽기");
            this.AddMsg(MsgCode.Write, "쓰기");
            this.AddMsg(MsgCode.Timeout, "시간 제한");
            this.AddMsg(MsgCode.Log, "로그");
            this.AddMsg(MsgCode.None, "없음");
            this.AddMsg(MsgCode.NotFound, "찾을 수 없음");
            this.AddMsg(MsgCode.NotConnected, "연결 안 됨");
            this.AddMsg(MsgCode.ConnectionFailure, "연결 실패");
            this.AddMsg(MsgCode.ReadFailure, "읽기 실패입니다");
            this.AddMsg(MsgCode.WriteFailue, "쓰기 오류입니다");
            this.AddMsg(MsgCode.UnknownError, "알 수 없는 오류");
            this.AddMsg(MsgCode.UnhandledError, "처리되지 않은 오류");
            this.AddMsg(MsgCode.Support, "지원");
            this.AddMsg(MsgCode.Edit, "편집");
            this.AddMsg(MsgCode.Create, "만들기");
            this.AddMsg(MsgCode.NothingSelected, "선택하지 않음");
            this.AddMsg(MsgCode.DeleteFailure, "삭제 실패");
            this.AddMsg(MsgCode.Ethernet, "이더넷");
            this.AddMsg(MsgCode.EmptyParameter, "빈 매개 변수를 추가할 수 없습니다");
            this.AddMsg(MsgCode.AbandonChanges, "변경 내용 취소?");
            this.AddMsg(MsgCode.Warning, "경고");
            this.AddMsg(MsgCode.Run, "실행");
            this.AddMsg(MsgCode.InsufficienPermissions, "권한이 충분하지 않습니다");
            this.AddMsg(MsgCode.CodeSamples, "코드 샘플");
            this.AddMsg(MsgCode.AuthenticationType, "인증 유형");
            this.AddMsg(MsgCode.EncryptionType, "암호화 종류");
            this.AddMsg(MsgCode.SignalStrength, "신호 강도");
            this.AddMsg(MsgCode.UpTime, "작동 시간");
            this.AddMsg(MsgCode.MacAddress, "MAC 주소");
            this.AddMsg(MsgCode.Kind, "종류");
            this.AddMsg(MsgCode.BeaconInterval, "오류 신호 간격");
            this.AddMsg(MsgCode.AccessStatus, "액세스 상태");
            this.AddMsg(MsgCode.AddressType, "주소 유형");
            this.AddMsg(MsgCode.Paired, "페어링됨");
            this.AddMsg(MsgCode.Connected, "연결됨");
            this.AddMsg(MsgCode.ProtectionLevel, "보호 수준");
            this.AddMsg(MsgCode.SecureConnection, "보안 연결");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "허용함");
            this.AddMsg(MsgCode.Address, "주소");
            this.AddMsg(MsgCode.DeviceClass, "장치 클래스");
            this.AddMsg(MsgCode.ServiceClass, "서비스 클래스");
            this.AddMsg(MsgCode.LastSeen, "마지막 표시한 시간");
            this.AddMsg(MsgCode.LastUsed, "마지막 사용 날짜");
            this.AddMsg(MsgCode.Authenticated, "인증됨");
            this.AddMsg(MsgCode.RemoteHost, "원격 호스트");
            this.AddMsg(MsgCode.RemoteService, "원격 서비스");
            this.AddMsg(MsgCode.Clear, "지우기");
            this.AddMsg(MsgCode.ResetAll, "모두 재설정");
            this.AddMsg(MsgCode.Disconnected, "연결이 끊김");
            this.AddMsg(MsgCode.Characteristic, "특징");
            this.AddMsg(MsgCode.Descriptor, "설명자");
            this.AddMsg(MsgCode.Min, "최소");
            this.AddMsg(MsgCode.Max, "최대");
            this.AddMsg(MsgCode.ReadOnly, "읽기 전용");
            this.AddMsg(MsgCode.InvalidInput, "입력이 잘못되었습니다");
            this.AddMsg(MsgCode.ParseFailed, "구문 분석 실패");
            this.AddMsg(MsgCode.OutOfRange, "범위를 벗어남");
            this.AddMsg(MsgCode.email, "자 메일");
            this.AddMsg(MsgCode.CrashReport, "버그 보고서");
            this.AddMsg(MsgCode.DataType, "데이터 형식");
            this.AddMsg(MsgCode.Service, "서비스");
            this.AddMsg(MsgCode.Notifications, "알림");
            this.AddMsg(MsgCode.Disabled, "사용 안함");
            this.AddMsg(MsgCode.Description, "설명");
            this.AddMsg(MsgCode.Unit, "단위");
            this.AddMsg(MsgCode.Exponent, "지수");
            this.AddMsg(MsgCode.True, "참");
            this.AddMsg(MsgCode.False, "거짓");
            this.AddMsg(MsgCode.Even, "짝수");
            this.AddMsg(MsgCode.Odd, "홀수");
            this.AddMsg(MsgCode.Mark, "표시 패리티");
            this.AddMsg(MsgCode.Space, "공백 패리티");
            this.AddMsg(MsgCode.Preview, "미리 보기");
            this.AddMsg(MsgCode.Configuration, "구성");
            this.AddMsg(MsgCode.Configurations, "구성");
            this.AddMsg(MsgCode.Inputs, "입력");
            this.AddMsg(MsgCode.Outputs, "출력");
            this.AddMsg(MsgCode.Digital, "디지털");
            this.AddMsg(MsgCode.Analog, "아날로그");
            this.AddMsg(MsgCode.Step, "걸음");
            this.AddMsg(MsgCode.Row, "행");
            this.AddMsg(MsgCode.Column, "열");

        }

    }
}
