using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HR.Platform.Infrastructure.Persistence.Converters
{
    public class EnumConverter<T> : ValueConverter<T, string>
    {
        public EnumConverter() : base(x => x.ToString(), v => (T)Enum.Parse(typeof(T), v))
        {
        }
    }
}
