using LanguageFactory.Net.data;
using LanguageFactory.Net.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LanguageFactory.Net.Languages.pt {
    public class Portuguese : SupportedLanguage {

        public Portuguese() : base() {
            this.SetLanguage(LangCode.Portuguese, "Português");

            // Common messages
            this.AddMsg(MsgCode.save, "Guardar");
            this.AddMsg(MsgCode.login, "Iniciar sessão");
            this.AddMsg(MsgCode.logoff, "Terminar sessão");
            this.AddMsg(MsgCode.copy, "Copiar");
            this.AddMsg(MsgCode.no, "No");
            this.AddMsg(MsgCode.yes, "Sim");
            this.AddMsg(MsgCode.New, "Novo");
            this.AddMsg(MsgCode.Ok, "OK");
            this.AddMsg(MsgCode.exit, "Sair");
            this.AddMsg(MsgCode.start, "Iniciar");
            this.AddMsg(MsgCode.stop, "Parar");
            this.AddMsg(MsgCode.language, "Idiomas");
            this.AddMsg(MsgCode.send, "Enviar");
            this.AddMsg(MsgCode.command, "Comando");
            this.AddMsg(MsgCode.commands, "Comandos");
            this.AddMsg(MsgCode.response, "Resposta");
            this.AddMsg(MsgCode.select, "Seleccionar");
            this.AddMsg(MsgCode.Search, "Pesquisar");
            this.AddMsg(MsgCode.connect, "Ligar");
            this.AddMsg(MsgCode.cancel, "Cancelar");
            this.AddMsg(MsgCode.info, "Informações");
            this.AddMsg(MsgCode.Settings, "Definições");
            this.AddMsg(MsgCode.Terminators, "Terminadores");
            this.AddMsg(MsgCode.Name, "Nome");
            this.AddMsg(MsgCode.Error, "Erro");
            this.AddMsg(MsgCode.CannotDeleteLast, "Não é possível eliminar a última entrada");
            this.AddMsg(MsgCode.EmptyName, "O nome não pode estar vazio");
            this.AddMsg(MsgCode.LoadFailed, "Falha ao garregar");
            this.AddMsg(MsgCode.SaveFailed, "Falha ao guardar");
            this.AddMsg(MsgCode.EnterName, "Introduzir nome");
            this.AddMsg(MsgCode.Continue, "Continuar?");
            this.AddMsg(MsgCode.Configure, "Configurar");
            this.AddMsg(MsgCode.NoServices, "Não foram detectados serviços");
            this.AddMsg(MsgCode.PairBluetooth, "Emparelhar Bluetooth");
            this.AddMsg(MsgCode.EnterPin, "Introduzir o PIN");
            this.AddMsg(MsgCode.PairedDevices, "Dispositivos emparelhados");
            this.AddMsg(MsgCode.Pair, "Emparelhar");
            this.AddMsg(MsgCode.Unpair, "Desemparelhar ");
            this.AddMsg(MsgCode.Disconnect, "Desligar");
            this.AddMsg(MsgCode.Password, "Palavra-passe");
            this.AddMsg(MsgCode.HostName, "Nome de anfitrião");
            this.AddMsg(MsgCode.NetworkService, "Serviço de rede");
            this.AddMsg(MsgCode.Port, "Porta");
            this.AddMsg(MsgCode.NetworkSecurityKey, "Chave de segurança de rede");
            this.AddMsg(MsgCode.Network, "Rede");
            this.AddMsg(MsgCode.Socket, "Socket");
            this.AddMsg(MsgCode.Credentials, "Credenciais");
            this.AddMsg(MsgCode.About, "Acerca de");
            this.AddMsg(MsgCode.Icons, "Ícones");
            this.AddMsg(MsgCode.Author, "Autor");
            this.AddMsg(MsgCode.Services, "Serviços");
            this.AddMsg(MsgCode.Properties, "Propriedades");
            this.AddMsg(MsgCode.Delete, "Eliminar");
            this.AddMsg(MsgCode.UserManual, "Manual de utilizador");
            this.AddMsg(MsgCode.Vendor, "Fornecedor");
            this.AddMsg(MsgCode.Product, "Produto");
            this.AddMsg(MsgCode.Enabled, "Ativado");
            this.AddMsg(MsgCode.Default, "Predefinido");
            this.AddMsg(MsgCode.BaudRate, "Veloc. Transmissão");
            this.AddMsg(MsgCode.DataBits, "Bits de dados");
            this.AddMsg(MsgCode.StopBits, "Bits de paragem");
            this.AddMsg(MsgCode.Parity, "Paridade");
            this.AddMsg(MsgCode.FlowControl, "Controlo de Fluxo");
            this.AddMsg(MsgCode.Read, "Leitura");
            this.AddMsg(MsgCode.Write, "Escrita");
            this.AddMsg(MsgCode.Timeout, "Tempo limite esgotado");
            this.AddMsg(MsgCode.Log, "Registar");
            this.AddMsg(MsgCode.None, "Nenhum");
            this.AddMsg(MsgCode.NotFound, "Não Encontrado");
            this.AddMsg(MsgCode.NotConnected, "Não ligada");
            this.AddMsg(MsgCode.ConnectionFailure, "Falha da ligação");
            this.AddMsg(MsgCode.ReadFailure, "Falha de leitura");
            this.AddMsg(MsgCode.WriteFailue, "Falha de escrita");
            this.AddMsg(MsgCode.UnknownError, "Erro desconhecido");
            this.AddMsg(MsgCode.UnhandledError, "Erro Não Processado");
            this.AddMsg(MsgCode.Support, "Suporte");
            this.AddMsg(MsgCode.Edit, "Editar");
            this.AddMsg(MsgCode.Create, "Criar");
            this.AddMsg(MsgCode.NothingSelected, "Nada Selecionado");
            this.AddMsg(MsgCode.DeleteFailure, "Falha na eliminação");
            this.AddMsg(MsgCode.Ethernet, "Ethernet");
            this.AddMsg(MsgCode.EmptyParameter, "Não é possível adicionar um parâmetro vazio");
            this.AddMsg(MsgCode.AbandonChanges, "Abandone os dados não guardados?");
            this.AddMsg(MsgCode.Warning, "Aviso");
            this.AddMsg(MsgCode.Run, "Executar");
            this.AddMsg(MsgCode.InsufficienPermissions, "Permissões Insuficientes");
            this.AddMsg(MsgCode.CodeSamples, "Exemplos de Código");
            this.AddMsg(MsgCode.AuthenticationType, "Tipo de autenticação");
            this.AddMsg(MsgCode.EncryptionType, "Tipo de encriptação");
            this.AddMsg(MsgCode.SignalStrength, "Força do sinal");
            this.AddMsg(MsgCode.UpTime, "Tempo ativo");
            this.AddMsg(MsgCode.MacAddress, "Endereço MAC");
            this.AddMsg(MsgCode.Kind, "Tipo");
            this.AddMsg(MsgCode.BeaconInterval, "Intervalo de Beacons");
            this.AddMsg(MsgCode.AccessStatus, "Estado de Acesso");
            this.AddMsg(MsgCode.AddressType, "Tipo de endereço");
            this.AddMsg(MsgCode.Paired, "Emparelhado");
            this.AddMsg(MsgCode.Connected, "Ligado");
            this.AddMsg(MsgCode.ProtectionLevel, "Protection Level");
            this.AddMsg(MsgCode.SecureConnection, "Ligação Segura");
            this.AddMsg(MsgCode.Id, "ID");
            this.AddMsg(MsgCode.Allowed, "Permitido");
            this.AddMsg(MsgCode.Address, "Endereço");
            this.AddMsg(MsgCode.DeviceClass, "Classe do dispositivo");
            this.AddMsg(MsgCode.ServiceClass, "Classe de Serviço");
            this.AddMsg(MsgCode.LastSeen, "Última Visualização");
            this.AddMsg(MsgCode.LastUsed, "Última utilização");
            this.AddMsg(MsgCode.Authenticated, "Autenticado");
            this.AddMsg(MsgCode.RemoteHost, "Anfitrião remoto");
            this.AddMsg(MsgCode.RemoteService, "Serviço Remoto");
            this.AddMsg(MsgCode.Clear, "Limpar");

            //this.AddMsg(MsgCode., "");
        }


    }
}
