using System.Reflection;

namespace ActionAir.Contracts;

public interface IReflection
{
    public IList<IFieldViewDescriptor> GetFieldViewDescriptors(Type classType);

    public IFieldViewDescriptor? GetFieldViewDescriptor(PropertyInfo propertyInfo);
}