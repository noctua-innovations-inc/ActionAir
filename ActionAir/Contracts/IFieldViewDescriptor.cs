namespace ActionAir.Contracts;

public interface IFieldViewDescriptor
{
    bool AutoGenerateField { get; set; }
    bool Filterable { get; set; }
    string FormatString { get; set; }
    int? Order { get; set; }
    string Property { get; set; }
    string Title { get; set; }
}