namespace NdflVerification.ReportsContext.Utils
{
    /// <summary>
    /// Спецификация
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ISpecification<in TEntity>
    {
        /// <summary>
        /// Проверка удовлетворения условию
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsSpecificatiedBy(TEntity entity);
    }
}