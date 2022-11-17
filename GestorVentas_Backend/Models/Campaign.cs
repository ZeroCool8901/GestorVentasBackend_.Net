using System;
using System.Collections.Generic;

namespace GestorVentas_Backend.Models
{
    public partial class Campaign
    {
        public int IdCampaign { get; set; }
        public string? Campaign1 { get; set; }
        public int? Period { get; set; }
        public decimal? InterestRate { get; set; }
    }
}
