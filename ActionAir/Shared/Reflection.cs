using ActionAir.Contracts;
using ActionAir.Models;
using System.Reflection;

namespace ActionAir.Shared;

public class Reflection : IReflection
{
    public IList<IFieldViewDescriptor> GetFieldViewDescriptors(Type classType)
    {
        // Returning an IList<> interface, because...
        // Good polymorphic practice: Accept as generic as possible, return as specific as possible.
        // IEnumerable is the choice for deferred execution, but there is nothing to defer here.
        var result = new List<IFieldViewDescriptor>();

        var order = 0;

        // Fetch all of the public class properties
        var properties = classType?.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        if (properties == null)
        {
            return result;
        }

        // Create a Field View Descriptor for each property, unless it is invalid or unwanted.
        foreach (var property in properties)
        {
            var descriptor = GetFieldViewDescriptor(property);
            if (!(descriptor?.AutoGenerateField ?? false))
            {
                continue;
            }

            // Default the display order to natural order
            descriptor.Order ??= order++;
            result.Add(descriptor);
        }

        // Return the Field View Descriptors in proper display order sequence.
        if (order > 0 && order != result.Count)
        {
            return result
                .OrderBy(x => x.Order)
                .ToList();
        }
        return result;
    }

    public IFieldViewDescriptor? GetFieldViewDescriptor(PropertyInfo propertyInfo)
    {
        if (propertyInfo == null)
        {
            return null;
        }
        return new FieldViewDescriptor(propertyInfo.GetCustomAttributes(), propertyInfo.Name);
    }
}
