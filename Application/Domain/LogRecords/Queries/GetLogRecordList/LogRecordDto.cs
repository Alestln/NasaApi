namespace Application.Domain.LogRecords.Queries.GetLogRecordList;

public class LogRecordDto
{
    public string Ip { get; set; }

    public DateTime Date { get; set; }

    public string Method { get; set; }

    public string Path { get; set; }

    public string Protocol { get; set; }

    public int StatusCode { get; set; }

    public int Size { get; set; }

    public string CountryCode { get; set; }
}