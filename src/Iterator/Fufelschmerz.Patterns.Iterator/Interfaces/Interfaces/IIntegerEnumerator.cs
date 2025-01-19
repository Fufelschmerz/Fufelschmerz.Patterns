namespace Fufelschmerz.Patterns.Iterator.Interfaces.Interfaces;

/// <summary>
/// Итератор
/// </summary>
public interface IIntegerEnumerator
{
    /// <summary>
    /// Текущий элемент
    /// </summary>
    int Current { get; }

    /// <summary>
    /// Переход к следующему элементу
    /// </summary>
    /// <returns>Значение true, если перечислитель был успешно перемещен к следующему элементу; значение false, если перечислитель достиг конца коллекции./returns>
    bool MoveNext();

    /// <summary>
    /// Сбрасывает итератор в начальное состояние
    /// </summary>
    void Reset();
}