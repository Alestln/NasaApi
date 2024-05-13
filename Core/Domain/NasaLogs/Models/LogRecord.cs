using Core.Common;

namespace Core.Domain.NasaLogs.Models;

public class LogRecord : Entity
{
    public int Id { get; set; }
    
    public string Ip { get; set; }

    public DateTime Date { get; set; }

    public string Method { get; set; }

    public string Path { get; set; }

    public string Protocol { get; set; }

    public int StatusCode { get; set; }

    public int Size { get; set; }

    public string CountryCode { get; set; }
}