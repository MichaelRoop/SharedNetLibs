using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;

namespace LanguageFactory.Net.Languages.es {
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
            this.AddMsg(MsgCode.Settings, "Configuración");
            this.AddMsg(MsgCode.Terminators, "Terminadores");
            this.AddMsg(MsgCode.Name, "Nombre");
            this.AddMsg(MsgCode.Error, "Error");
            this.AddMsg(MsgCode.CannotDeleteLast, "No se puede eliminar la última entrada");
            this.AddMsg(MsgCode.EmptyName, "El nombre no puede estar en blanco");
            this.AddMsg(MsgCode.LoadFailed, "No se pueden cargar");
            this.AddMsg(MsgCode.SaveFailed, "Error al guardar");
            this.AddMsg(MsgCode.EnterName, "Escribir nombre");
            this.AddMsg(MsgCode.Continue, "¿Continuar?");
            this.AddMsg(MsgCode.Configure, "Configurar");
            this.AddMsg(MsgCode.NoServices, "Ningún servicio encontrado");
            this.AddMsg(MsgCode.PairBluetooth, "Emparejar Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Escribir PIN");
            this.AddMsg(MsgCode.PairedDevices, "Dispositivos emparejados");
            this.AddMsg(MsgCode.Pair, "Emparejar");
            this.AddMsg(MsgCode.Unpair, "Desemparejar");
            this.AddMsg(MsgCode.Disconnect, "Desconectar");
            this.AddMsg(MsgCode.Password, "Contraseña");
            this.AddMsg(MsgCode.HostName, "Nombre de host");
            this.AddMsg(MsgCode.NetworkService, "Servicio de red");
            this.AddMsg(MsgCode.Port, "Puerto");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Clave de seguridad de red");
            this.AddMsg(MsgCode.Network, "Red");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Credenciales");
            this.AddMsg(MsgCode.About, "Acerca de");
            this.AddMsg(MsgCode.Icons, "Iconos");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Servicios");
            this.AddMsg(MsgCode.Properties, "Propiedades");
            this.AddMsg(MsgCode.Delete, "Eliminar");
            this.AddMsg(MsgCode.UserManual, "Manual del usuario");
            this.AddMsg(MsgCode.Vendor, "Proveedor");
            this.AddMsg(MsgCode.Product, "Producto");
            this.AddMsg(MsgCode.Enabled, "Habilitado");
            this.AddMsg(MsgCode.Default, "Predeterminados");
            this.AddMsg(MsgCode.BaudRate, "Velocidad en baudios");
            this.AddMsg(MsgCode.DataBits, "Bits de datos");
            this.AddMsg(MsgCode.StopBits, "Bits de parada");
            this.AddMsg(MsgCode.Parity, "Paridad");
            this.AddMsg(MsgCode.FlowControl, "Control de flujo");
            this.AddMsg(MsgCode.Read, "Leer");
            this.AddMsg(MsgCode.Write, "Escritura");
            this.AddMsg(MsgCode.Timeout, "Tiempo de expiración");
            this.AddMsg(MsgCode.Log, "Registro");
            this.AddMsg(MsgCode.None, "Ninguna");
            this.AddMsg(MsgCode.NotFound, "No Encontrado");
            this.AddMsg(MsgCode.NotConnected, "No Conectado");
            this.AddMsg(MsgCode.ConnectionFailure, "Error De conexión");
            this.AddMsg(MsgCode.ReadFailure, "Error de Lectura");
            this.AddMsg(MsgCode.WriteFailue, "Error de Escritura");
            this.AddMsg(MsgCode.UnknownError, "Error Desconocido");
            this.AddMsg(MsgCode.UnhandledError, "Error no Controlado");
            this.AddMsg(MsgCode.Support, "Soporte");
            this.AddMsg(MsgCode.Edit, "Editar");
            this.AddMsg(MsgCode.Create, "Crear");
            this.AddMsg(MsgCode.NothingSelected, "No se seleccionó nada");
            this.AddMsg(MsgCode.DeleteFailure, "Error de eliminación");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");

            //this.AddMsg(MsgCode., "");
        }

    }
}
