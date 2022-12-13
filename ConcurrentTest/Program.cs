using System.Collections.Concurrent;


ConcurrentDictionary<Coordinate,string> cDictionary = new();
string[] letters = { "A", "B", "C" };
int[] numbers = { 1, 2};

int rowIndex = 0;


//foreach (var letter in letters)
Parallel.ForEach(letters, letter =>
{
    int colIndex = 0;
    //foreach (var number in numbers)
    Parallel.ForEach(numbers, number =>
    {
        
     
      cDictionary.TryAdd(new Coordinate(rowIndex, colIndex), letter + number.ToString());
      
        
        Interlocked.Increment(ref colIndex);
        //colIndex++;
    }
    );
    Interlocked.Increment(ref rowIndex);
    //rowIndex++;
}
);

int count = 0;
foreach(KeyValuePair<Coordinate, string> kvp in cDictionary)
{
    Console.WriteLine(kvp.Key + " ---> " + kvp.Value);
    count++;
}

Console.WriteLine(count);

struct Coordinate
{

    public int x;
    public int y;

    public override string? ToString()
    {
        return "\nX: " + x.ToString() + "\nY: " + y.ToString();
    }

    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}

