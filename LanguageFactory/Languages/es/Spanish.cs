using LanguageFactory.data;
using LanguageFactory.Messaging;

namespace LanguageFactory.Languages.es {
    class Spanish : SupportedLanguage {
        public Spanish() : base() {

            this.SetLanguage(LangCode.Spanish, "Español");

            // Common messages
            this.AddMsg(MsgCode.save, "Guardar");
            this.AddMsg(MsgCode.login, "Iniciar sesión");
            this.AddMsg(MsgCode.logoff, "Cerrar sesión");
            this.AddMsg(MsgCode.copy, "Copiar");
            this.AddMsg(MsgCode.no, "No");
            this.AddMsg(MsgCode.yes, "Si");
            this.AddMsg(MsgCode.New, "Nuevo");
            this.AddMsg(MsgCode.Ok, "Aceptar");
            this.AddMsg(MsgCode.exit, "Salir");
            this.AddMsg(MsgCode.start, "Iniciar");
            this.AddMsg(MsgCode.stop, "Detener");
            this.AddMsg(MsgCode.language, "Idiomas");
            this.AddMsg(MsgCode.send, "Enviar");
            this.AddMsg(MsgCode.command, "Comando");
            this.AddMsg(MsgCode.response, "Respuesta");
            this.AddMsg(MsgCode.select, "Seleccionar");
            this.AddMsg(MsgCode.discover, "Descubrir");
            this.AddMsg(MsgCode.connect, "Conectar");
            this.AddMsg(MsgCode.cancel, "Cancelar");
            this.AddMsg(MsgCode.info, "Información");


            //this.AddMsg(MsgCode., "");
        }

    }
}
