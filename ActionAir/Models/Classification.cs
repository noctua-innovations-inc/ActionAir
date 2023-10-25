using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ActionAir.Models;

public class Classification
{
    [Display(AutoGenerateField = false)]
    public required string Division { get; set; }

    [Display(AutoGenerateField = false)]
    public required string CompetitorId { get; set; }

    [Display(Name = "Competitor")]
    [JsonPropertyName("CompNm")]
    public required string CompetitorName { get; set; }

    public required string Region { get; set; }

    [Display(AutoGenerateFilter = false)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public double WorldGrade { get; set; }

    [Display(Name = "World Class")]
    public required string WorldClassification { get; set; }

    [Display(AutoGenerateFilter = false)]
    [DisplayFormat(DataFormatString = "{0:N2}")]
    public double RegionGrade { get; set; }

    [Display(Name = "Regional Class")]
    public required string RegionClassification { get; set; }
}
