
var ht = new HashTable<string>(10);

ht.Put(244, "BigB");
ht.Put(248, "SomeB");
ht.Put(344, "MomB");
ht.Put(384, "SmallB");
ht.Put(380, "TinyB");

ht.Remove(344);

ht.Print();

public class Entry<T> {
    public int Key { get; set; }
    public T Value { get; set; }
    public Entry<T> Next { get; set; }
}

public class HashTable<T>
{
    private int size;
    private Entry<T>[] table;

    public HashTable(int size)
    {
        this.size = size;
        table = new Entry<T>[size];
    }

    public bool Put(int key, T value)
    {
        var hash = GetHash(key);

        for (var entry = table[hash]; entry != null; entry = entry.Next)
        {
            if (entry.Key == key)
            {
                entry.Value = value;
                return false;
            }
        }

        var newEntry = new Entry<T>()
        {
            Key = key,
            Value = value,
            Next = table[hash]
        };

        table[hash] = newEntry;

        return true;
    }

    public void Remove(int key)
    {
        var hash = GetHash(key);
        var back = this.table[hash];

        for (var current = back; current != null; current = current.Next)
        {
            if (current.Key == key)
            {
                if (current == back)
                {
                    this.table[hash] = current.Next;
                }
                else
                {
                    back.Next = current.Next;
                }
                current.Next = null;
                return;
            }
            back = current;
        }
    }

    public T Get(int key)
    {
        var index = GetHash(key);
        for (var curr = this.table[index]; curr != null; curr = curr.Next)
        {
            if (curr.Key == key)
            {
                return curr.Value;
            }
        }
        return default(T);
    }
    public void Print() {
        Console.WriteLine();
        for(var i = 0; i < size; i++) {
            var entry = table[i];
            Console.Write($"{i}: ");
            while(entry != null) {
                Console.Write($"[{entry.Key}: {entry.Value}]  ");
                entry = entry.Next;
            }
            Console.WriteLine();
        }
    }

    private int GetHash(int key) {
        return key % size;
    }
}
