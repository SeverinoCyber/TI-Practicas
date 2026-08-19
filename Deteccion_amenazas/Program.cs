using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

public class EventoSeguridad
{
    public string IpOrigen { get; private set; }
    public string Timestamp { get; private set; }
    [Range(1,5)]
    public int NivelSeveridad { get; private set; }

    public EventoSeguridad(string ipOrigen, string timestamp, int nivelSeveridad)
    {
        IpOrigen = ipOrigen;
        Timestamp = timestamp;
        NivelSeveridad = nivelSeveridad; 
    }
    public virtual int AnalizarRiesgos()
    {
       return NivelSeveridad * 10;
    }
    
    public string ObtenerDetalles()
    {
        return $"Ip de la amenaza: {IpOrigen} | Fecha y Hora: {Timestamp} | Nivel de Severidad: {NivelSeveridad}";
    }
}

public class IntentosLogin : EventoSeguridad
{
    public int IntentosFallidos { get; private set;} 
    public string UsuarioObjetivo { get; private set; }

    public IntentosLogin(string ip_origen, string timestamp, int nivel_severidad, int intentosFallidos, string usuarioObjetivo)
        : base(ip_origen, timestamp, nivel_severidad)
    {
        IntentosFallidos = intentosFallidos;
        UsuarioObjetivo = usuarioObjetivo;
    }

    public override int AnalizarRiesgos()
    {
        int riesgoBase = base.AnalizarRiesgos();

        if (IntentosFallidos > 5)
        {
            return riesgoBase * 2; 
        }

        return riesgoBase;
    }
}

public class TraficoRed : EventoSeguridad
{
    public int PuertoDestino{ get; private set; }
    public int BytesTransferidos{ get; private set; }
    public TraficoRed(string ipOrigen, string timestamp, int nivelSeveridad, int puertoDestino, int bytesTransferidos)
        : base(ipOrigen, timestamp, nivelSeveridad)
    {
        PuertoDestino = puertoDestino;
        BytesTransferidos = bytesTransferidos;
    }

    public override int AnalizarRiesgos()
    {
        int riesgoBase = base.AnalizarRiesgos();
        
        if(PuertoDestino != 80 && PuertoDestino != 443 && BytesTransferidos > 1000000)
        {
            return riesgoBase + 50;
        }

        return riesgoBase;
    }
}

public class SIEMManager
{
   public List<EventoSeguridad> ListaEventos { get; private set; } = new List<EventoSeguridad>();
   public int UmbralAlerta { get; private set; }

   public SIEMManager(int umbralAlerta)
    {
        UmbralAlerta = umbralAlerta;
    }

   public void RegistrarEvento(EventoSeguridad evento)
    {
        if (evento != null)
        {
            ListaEventos.Add(evento); 
            Console.WriteLine("Evento recibido!");
        }
    }

    public void GenerarReporte()
    {
        Console.WriteLine("=== REPORTE DE AMENAZAS SIEM ===");

        foreach (EventoSeguridad evento in ListaEventos)
        {
            int puntajeRiesgo = evento.AnalizarRiesgos();

            if(puntajeRiesgo >= UmbralAlerta)
            {
                Console.WriteLine("\n[¡ALERTA CRÍTICA!]");
                Console.WriteLine(evento.ObtenerDetalles());
                Console.WriteLine($"Puntaje de Riesgo Calculado: {puntajeRiesgo} (Supera el umbral de {UmbralAlerta})");
            }
        }
    }

}

namespace MiAplicacion
{
    class Program
    {
        static void Main(string[] args)
        {
            SIEMManager siem = new SIEMManager(50);
            EventoSeguridad evento1 = new IntentosLogin("192.168.1.10",  "2026-08-18 10:00", 2, 2,"admin");
            EventoSeguridad evento2 = new IntentosLogin("45.33.22.11",  "2026-08-18 10:05", 4, 8,"root");
            EventoSeguridad evento3 = new TraficoRed("10.0.0.5",  "2026-08-18 10:10", 1, 443, 5000);
            EventoSeguridad evento4 = new TraficoRed("192.168.1.50",  "2026-08-18 10:15", 3, 8080, 5000000);

            siem.RegistrarEvento(evento1);
            siem.RegistrarEvento(evento2);
            siem.RegistrarEvento(evento3);
            siem.RegistrarEvento(evento4);

            siem.GenerarReporte();

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
            
        }
    }
}