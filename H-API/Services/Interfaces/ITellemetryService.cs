using HARMONIA.Domain.DTOs.Telemetria;

namespace H_API.Services.Interfaces
{
    public interface ITellemetryService
    {
        public string InsertHumedalData(TellemetryPost dto);
    }
}
