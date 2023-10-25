using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ActionAir.Contracts;

namespace ActionAir.Models;

public class FieldViewDescriptor : IFieldViewDescriptor
{
    [SetsRequiredMembers]
    public FieldViewDescriptor(Type classType, string fieldName) : this(fieldName)
    {
        var customAttributes = classType
            ?.GetProperty(fieldName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance)
            ?.GetCustomAttributes();

        Initialize(customAttributes);
    }

    [SetsRequiredMembers]
    public FieldViewDescriptor(IEnumerable<Attribute>? customAttributes, string fieldName) : this(fieldName)
    {
        Initialize(customAttributes);
    }

    [SetsRequiredMembers]
    protected FieldViewDescriptor(string fieldName)
    {
        Property = fieldName;
        Title = fieldName.CreateLabelFromPropertyName();
    }

    private void Initialize(IEnumerable<Attribute>? customAttributes)
    {
        if (customAttributes == null)
        {
            return;
        }

        foreach (var customAttribute in customAttributes)
        {
            ProcessAttribute(customAttribute);
        }
    }

    private void ProcessAttribute(Attribute? attribute)
    {
        if (attribute == null)
        {
            return;
        }

        switch (attribute)
        {
            case DisplayAttribute displayAttribute:
                Title = displayAttribute.Name ?? Title;
                AutoGenerateField = displayAttribute.GetAutoGenerateField() ?? AutoGenerateField;
                Filterable = displayAttribute.GetAutoGenerateFilter() ?? Filterable;
                Order = displayAttribute.GetOrder();
                break;

            case DisplayFormatAttribute displayFormatAttribute:
                FormatString = displayFormatAttribute.DataFormatString ?? string.Empty;
                break;
        }
    }

    public required string Property { get; set; }

    private string? title;
    public string Title
    {
        get => title ?? Property;
        set => title = value;
    }

    public bool AutoGenerateField { get; set; } = true;

    public bool Filterable { get; set; } = true;

    private string? formatString;
    public string FormatString
    {
        get => formatString ?? string.Empty;
        set => formatString = value;
    }

    public int? Order { get; set; }
}
