using Microsoft.AspNetCore.SignalR;

namespace PruebaSignalR.SignalR
{
    public class MiClaseSignalR : Hub
    {

        // Clase que utilizaremos desde el hub
        public EscuchandoCambiosQuery sbAlertas = new EscuchandoCambiosQuery();


        /// <summary>
        /// Enviar un mensaje de respuesta todos los usuarios.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task EnviarMensaje(string user, string message)
        {
            await Clients.All.SendAsync("Respuesta de SignalR: ", user, message);
        }

        /// <summary>
        /// Iniciar escucha de alertas del usuario dado.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public async Task IniciarEscuchaAlertas(int idUsuario)
        {
            // Agregar/Seleccionar cliente a nuestra clase a utilizar
            sbAlertas = EscuchandoCambiosQuery.cliente.GetOrAdd(Context.ConnectionId, sbAlertas);
            sbAlertas.callerContext = Context;
            sbAlertas.hubCallerClients = Clients;

            // Utilizar la clase
            sbAlertas.SetData(
              @"Data Source=DESKTOP-7PMMU6Q;Initial Catalog=AlarmaComunitaria;Integrated Security=true;MultipleActiveResultSets=true;",
              $"SELECT IdAlerta  FROM dbo.Prueba WHERE IdUsuario={idUsuario}",
              "ALERTAS_ESCUCHA");
            sbAlertas.OnMensajeRecibido += new EscuchandoCambiosQuery.MensajeRecibido(sbAlertas_InformacionRecibida);
            sbAlertas.IniciarEscucha();
            await Clients.Caller.SendAsync("Escucha de alertas iniciada");
        }

        /// <summary>
        /// Detener escucha de alertas del usuario dado.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public async Task DetenerEscuchaAlertas(int idUsuario)
        {
            // Seleccionar cliente que va a detener la escucha
            sbAlertas = EscuchandoCambiosQuery.cliente.GetOrAdd(Context.ConnectionId, sbAlertas);

            // Detener la escucha
            sbAlertas.OnMensajeRecibido -= sbAlertas_InformacionRecibida;
            await Clients.Caller.SendAsync("Escucha de alertas detenida");
        }

        /// <summary>
        /// Evento de cambio escuchando alertas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="mensaje"></param>
        private static void sbAlertas_InformacionRecibida(object sender, string mensaje)
        {
            var sb = (EscuchandoCambiosQuery)sender;
            HubCallerContext hcallerContext = sb.callerContext;
            IHubCallerClients<IClientProxy> hubClients = sb.hubCallerClients;
            hubClients.Caller.SendAsync($"El mensaje {mensaje} indica un cambio el " + DateTime.Now.ToString());
        }


    }

}

