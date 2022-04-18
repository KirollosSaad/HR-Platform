using HR.Platform.Domain.Entities.Interfaces;

using Microsoft.EntityFrameworkCore.Metadata;

using System.Linq.Expressions;
using System.Reflection;

namespace HR.Platform.Infrastructure.Persistence.Extensions
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);

            var filter = methodToCall.Invoke(null, new object[] { });

            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.FindProperty(nameof(IAuditableEntity.DeletedAt)));
        }

        private static LambdaExpression GetSoftDeleteFilter<TEntity>() where TEntity : class, IAuditableEntity
        {
            Expression<Func<TEntity, bool>> filter = x => !x.DeletedAt.HasValue;
            return filter;
        }
    }
}
