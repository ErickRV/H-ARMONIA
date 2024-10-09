using H_API.Services.Interfaces;
using HARMONIA.Core.Interfaces;
using HARMONIA.Domain.DTOs.Telemetria;
using HARMONIA.Domain.Entidades;
using HARMONIA.Domain.Enums;

namespace H_API.Services.Services
{
    public class TellemetryService : ITellemetryService
    {
        private readonly IDbService dbService;

        public TellemetryService(IDbService dbService)
        {
            this.dbService = dbService;
        }

        public string InsertHumedalData(TellemetryPost dto)
        {
            HumedalData humedalData = new HumedalData(dto);
            return dbService.InsertDocument(DataBaseContainers.Telemetria, humedalData).Id;
        }
    }
}
