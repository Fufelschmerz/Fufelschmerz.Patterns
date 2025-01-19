namespace Fufelschmerz.Patterns.Iterator.Interfaces.Interfaces;

/// <summary>
/// Агрегат
/// </summary>
public interface IIntegerAggregate
{
    /// <summary>
    /// Метод получения итератора
    /// </summary>
    /// <returns></returns>
    IIntegerEnumerator GetEnumerator();
}