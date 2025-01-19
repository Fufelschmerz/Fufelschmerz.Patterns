using Fufelschmerz.Patterns.Iterator;

var integerAggregate = new IntegerAggregate(6);
integerAggregate.Add(1);
integerAggregate.Add(2);
integerAggregate.Add(3);
integerAggregate.Add(4);
integerAggregate.Add(5);
integerAggregate.Add(6);

foreach (var item in integerAggregate)
{
    Console.WriteLine(item);
}

Console.ReadKey();