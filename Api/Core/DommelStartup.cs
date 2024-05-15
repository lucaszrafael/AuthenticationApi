using Dommel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Api.Core
{
    public static class DommelStartup
    {
        public static void AddDommelCustomizado(this IServiceCollection services) => DommelMapper.SetTableNameResolver(new TabelaResolver());

        public class TabelaResolver : ITableNameResolver
        {
            public string ResolveTableName(Type type)
            {
                TypeInfo typeInfo = type.GetTypeInfo();
                TableAttribute tableAttr = typeInfo.GetCustomAttribute<TableAttribute>();
                if (tableAttr != null)
                {
                    return tableAttr.Name;
                }
                return $"{type.Name}";
            }
        }
    }
}