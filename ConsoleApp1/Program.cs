// ============================================================
//  Topics: Introduction, Loops/Arrays/Methods,
//          Strings/Collections,
//          Queue/Stack/Dictionary/HashSet/Files
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class CSharpReference
{
    // ============================================================
    // PROGRAM STARTS HERE
    // ============================================================
    static void Main(string[] args)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("   C# REFERENCE PROJECT");
        Console.WriteLine("====================================\n");

        // Each topic is called in its own method
        Demo1_Introduction();
        Demo2_LoopsArraysMethods();
        Demo3_StringsCollections();
        Demo4_QueueStackDictHashSetFiles();

        Console.WriteLine("\n✅ Program finished!");
    }


    // ============================================================
    // TOPIC #1 — INTRODUCTION TO C#
    // ============================================================
    static void Demo1_Introduction()
    {
        Console.WriteLine("\n--- TOPIC #1: INTRODUCTION ---");

        // --- Data types (value types) ---
        int wholeNumber = 42;
        double decimal1 = 3.14;
        bool flag = true;
        char letter = 'A';
        float smallFloat = 1.5f;
        long bigNumber = 9_000_000_000L; // _ improves readability

        // --- Reference types ---
        string text = "Hello C#";   // can be null or a string
        object obj = wholeNumber;  // can hold any type

        // --- var — type is inferred automatically (but still static!) ---
        var autoInt = 100;    // compiler knows: int
        var autoString = "Hi";  // compiler knows: string

        // --- const and readonly ---
        const double PI = 3.14159;  // never changes, known at compile time
        // readonly can only be assigned in the declaration or constructor (class level)

        Console.WriteLine($"int={wholeNumber}, double={decimal1}, bool={flag}, char={letter}");
        Console.WriteLine($"var autoInt={autoInt}, var autoString={autoString}, PI={PI}");

        // --- Implicit conversion — safe widening ---
        int x = 10;
        double widened = x;   // int → double, no data loss
        Console.WriteLine($"Implicit: int {x} → double {widened}");

        // --- Explicit conversion (cast) — may lose data ---
        double precise = 9.99;
        int truncated = (int)precise;  // decimal part is cut off!
        Console.WriteLine($"Explicit: double {precise} → int {truncated}");

        // --- Arithmetic operators ---
        int a = 10, b = 3;
        Console.WriteLine($"10+3={a + b}, 10-3={a - b}, 10*3={a * b}, 10/3={a / b}, 10%3={a % b}");
        // ⚠ int/int = int: 10/3 = 3, NOT 3.33!

        // --- Comparison and logical operators ---
        Console.WriteLine($"10>3: {a > b}, 10==3: {a == b}, true&&false: {true && false}, !true: {!true}");

        // --- Conditions: if / else if / else ---
        int temp = 20;
        if (temp > 30)
            Console.WriteLine("Hot");
        else if (temp > 15)
            Console.WriteLine($"Nice ({temp}°C)");  // this one prints
        else
            Console.WriteLine("Cold");

        // --- Ternary operator (short if/else) ---
        string result = (temp > 0) ? "Positive" : "Negative";
        Console.WriteLine($"Ternary: {result}");

        // --- Switch statement ---
        int day = 3;
        switch (day)
        {
            case 1: Console.WriteLine("Monday"); break;
            case 2: Console.WriteLine("Tuesday"); break;
            case 3: Console.WriteLine("Wednesday"); break;  // this one
            default: Console.WriteLine("Other day"); break;
        }
    }


    // ============================================================
    // TOPIC #2 — LOOPS, ARRAYS, METHODS
    // ============================================================
    static void Demo2_LoopsArraysMethods()
    {
        Console.WriteLine("\n--- TOPIC #2: LOOPS, ARRAYS, METHODS ---");

        // ---- LOOPS ----

        // for — when we know the number of iterations
        Console.Write("for: ");
        for (int i = 0; i < 5; i++)
            Console.Write(i + " ");   // 0 1 2 3 4
        Console.WriteLine();

        // while — runs while the condition is true
        Console.Write("while: ");
        int n = 0;
        while (n < 5)
        {
            Console.Write(n + " ");
            n++;
        }
        Console.WriteLine();

        // do-while — runs AT LEAST ONCE (condition checked after body)
        Console.Write("do-while: ");
        int m = 0;
        do
        {
            Console.Write(m + " ");
            m++;
        } while (m < 5);
        Console.WriteLine();

        // foreach — iterates over a collection
        int[] arrayElems = { 10, 20, 30, 40 };
        Console.Write("foreach: ");
        foreach (int el in arrayElems)
            Console.Write(el + " ");
        Console.WriteLine();

        // break — exits the loop immediately
        Console.Write("break at 3: ");
        for (int i = 0; i < 10; i++)
        {
            if (i == 3) break;
            Console.Write(i + " ");  // 0 1 2
        }
        Console.WriteLine();

        // continue — skips the current iteration
        Console.Write("continue (even only): ");
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 != 0) continue;  // odd numbers are skipped
            Console.Write(i + " ");    // 0 2 4
        }
        Console.WriteLine();

        // ---- ARRAYS ----

        // Simple array — fixed size
        int[] empty = new int[5];           // all 0 by default
        int[] initialized = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"Array length: {initialized.Length}");
        Console.WriteLine($"Element [2]: {initialized[2]}");  // 3

        // Iterating with index
        Console.Write("Array: ");
        for (int i = 0; i < initialized.Length; i++)
            Console.Write(initialized[i] + " ");
        Console.WriteLine();

        // 2D array
        int[,] matrix = new int[2, 3];
        matrix[0, 0] = 1; matrix[0, 1] = 2; matrix[0, 2] = 3;
        matrix[1, 0] = 4; matrix[1, 1] = 5; matrix[1, 2] = 6;

        Console.WriteLine("Matrix:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }

        // ---- METHOD CALLS ----

        // Simple method
        int sum = Add(5, 3);
        Console.WriteLine($"Add(5,3) = {sum}");

        // Default parameter
        Greet();          // uses default "Guest"
        Greet("Alice");   // uses "Alice"

        // ref — modifies the original variable (must be initialized first)
        int refNum = 10;
        MultiplyBy2(ref refNum);
        Console.WriteLine($"ref after MultiplyBy2: {refNum}");  // 20

        // out — method assigns the value (no need to initialize before)
        GetData(out int outResult);
        Console.WriteLine($"out GetData: {outResult}");         // 99

        // params — accepts a variable number of arguments
        Console.WriteLine($"params Sum(1,2,3,4): {SumParams(1, 2, 3, 4)}");

        // Overloading — same name, different parameters
        Console.WriteLine($"Overload int: {Calculate(5, 3)}");
        Console.WriteLine($"Overload double: {Calculate(5.5, 3.3)}");

        // Recursion — factorial
        Console.WriteLine($"Factorial(5) = {Factorial(5)}");  // 120
    }

    // --- Method definitions (used by Demo2) ---

    // Returns the sum of two numbers
    static int Add(int a, int b)
    {
        return a + b;
    }

    // Default parameter: if not provided, uses "Guest"
    static void Greet(string name = "Guest")
    {
        Console.WriteLine($"Hello, {name}!");
    }

    // ref — variable is passed by reference, original is modified
    static void MultiplyBy2(ref int number)
    {
        number *= 2;
    }

    // out — method MUST assign a value before returning
    static void GetData(out int result)
    {
        result = 99;  // mandatory assignment
    }

    // params — allows passing any number of arguments
    static int SumParams(params int[] numbers)
    {
        int total = 0;
        foreach (int num in numbers)
            total += num;
        return total;
    }

    // Overloading — int version
    static int Calculate(int a, int b) => a + b;

    // Overloading — double version (same name, different type)
    static double Calculate(double a, double b) => a + b;

    // Recursion — calls itself; base case: n <= 1 stops the recursion
    static long Factorial(int n)
    {
        if (n <= 1) return 1;         // BASE CASE — stops recursion
        return n * Factorial(n - 1);  // recursive call
    }


    // ============================================================
    // TOPIC #3 — STRINGS AND COLLECTIONS (List)
    // ============================================================
    static void Demo3_StringsCollections()
    {
        Console.WriteLine("\n--- TOPIC #3: STRINGS AND COLLECTIONS ---");

        // ---- STRING METHODS ----

        string s = "  Hello, World!  ";

        Console.WriteLine($"Original:       [{s}]");
        Console.WriteLine($"Trim():         [{s.Trim()}]");           // removes leading/trailing spaces
        Console.WriteLine($"ToUpper():      [{s.Trim().ToUpper()}]");
        Console.WriteLine($"ToLower():      [{s.Trim().ToLower()}]");
        Console.WriteLine($"Length:         {s.Length}");
        Console.WriteLine($"Contains('Hello'): {s.Contains("Hello")}");       // true
        Console.WriteLine($"StartsWith('  H'): {s.StartsWith("  H")}");       // true
        Console.WriteLine($"IndexOf('World'):   {s.IndexOf("World")}");        // position

        string replaced = s.Trim().Replace("Hello", "Hi");
        Console.WriteLine($"Replace:        [{replaced}]");

        // Substring — extract a portion of the string
        string sub = s.Trim().Substring(0, 5);  // start at 0, length 5
        Console.WriteLine($"Substring(0,5): [{sub}]");  // "Hello"

        // Split — divide into an array
        string csv = "Alice,Bob,Carol";
        string[] names = csv.Split(',');
        Console.Write("Split: ");
        foreach (string name in names)
            Console.Write($"[{name}] ");
        Console.WriteLine();

        // IsNullOrEmpty / IsNullOrWhiteSpace — null-safety checks
        string? maybeNull = null;
        Console.WriteLine($"IsNullOrEmpty(null):     {string.IsNullOrEmpty(maybeNull)}");   // true
        Console.WriteLine($"IsNullOrWhiteSpace(' '): {string.IsNullOrWhiteSpace("  ")}");   // true

        // String interpolation and formatting
        string firstName = "Maria";
        int age = 25;
        Console.WriteLine($"Interpolation: Hello, {firstName}! You are {age} years old.");
        Console.WriteLine(string.Format("Format: Hello, {0}! You are {1} years old.", firstName, age));

        // ⚠ String is IMMUTABLE — every operation creates a NEW object
        string orig = "abc";
        string upper = orig.ToUpper();  // orig is still "abc"
        Console.WriteLine($"Immutable: orig={orig}, upper={upper}");

        // StringBuilder — efficient for many concatenation operations in a loop
        Console.Write("StringBuilder: ");
        var sb = new StringBuilder();
        for (int i = 1; i <= 5; i++)
        {
            sb.Append(i);
            if (i < 5) sb.Append("-");
        }
        Console.WriteLine(sb.ToString());  // "1-2-3-4-5"

        // ---- LIST<T> ----
        Console.WriteLine("\n-- List<T> --");

        var list = new List<string>();
        list.Add("Apple");
        list.Add("Banana");
        list.Add("Lemon");
        Console.WriteLine($"Count after Add: {list.Count}");

        // Access by index
        Console.WriteLine($"list[1] = {list[1]}");  // "Banana"

        // Contains
        Console.WriteLine($"Contains('Apple'): {list.Contains("Apple")}");

        // Remove
        list.Remove("Banana");
        Console.WriteLine($"Count after Remove: {list.Count}");

        // Sort
        list.Add("Avocado");
        list.Sort();
        Console.Write("After Sort: ");
        foreach (string item in list)
            Console.Write(item + " ");
        Console.WriteLine();

        // ⚠ Always check Count > 0 before accessing by index
        if (list.Count > 0)
            Console.WriteLine($"First element: {list[0]}");
    }


    // ============================================================
    // TOPIC #4 — QUEUE, STACK, DICTIONARY, HASHSET, FILES
    // ============================================================
    static void Demo4_QueueStackDictHashSetFiles()
    {
        Console.WriteLine("\n--- TOPIC #4: QUEUE, STACK, DICTIONARY, HASHSET, FILES ---");

        DemoQueue();
        DemoStack();
        DemoDictionary();
        DemoHashSet();
        DemoFiles();
    }

    // ---- QUEUE<T> — FIFO (First In, First Out) ----
    // Analogy: checkout line — first person in is first person out
    static void DemoQueue()
    {
        Console.WriteLine("\n-- Queue (FIFO) --");

        var queue = new Queue<string>();

        // Enqueue — adds to the BACK
        queue.Enqueue("First");
        queue.Enqueue("Second");
        queue.Enqueue("Third");
        Console.WriteLine($"Count: {queue.Count}");

        // Peek — looks at the FRONT without removing
        if (queue.Count > 0)
            Console.WriteLine($"Peek (no remove): {queue.Peek()}");  // "First"

        // Dequeue — removes from the FRONT
        if (queue.Count > 0)
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");  // "First"

        // TryDequeue — safe removal (no exception thrown if empty)
        if (queue.TryDequeue(out string? removed))
            Console.WriteLine($"TryDequeue: {removed}");  // "Second"

        // ⚠ Calling Dequeue() on an empty queue throws InvalidOperationException!
        Console.WriteLine($"Remaining in queue: {queue.Count}");

        // Iteration
        Console.Write("Queue contents: ");
        foreach (string el in queue)
            Console.Write(el + " ");
        Console.WriteLine();
    }

    // ---- STACK<T> — LIFO (Last In, First Out) ----
    // Analogy: stack of plates — last placed is first taken
    static void DemoStack()
    {
        Console.WriteLine("\n-- Stack (LIFO) --");

        var stack = new Stack<int>();

        // Push — adds to the TOP
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Count: {stack.Count}");

        // Peek — looks at the TOP without removing
        if (stack.Count > 0)
            Console.WriteLine($"Peek (no remove): {stack.Peek()}");  // 30

        // Pop — removes from the TOP
        if (stack.Count > 0)
            Console.WriteLine($"Pop: {stack.Pop()}");  // 30

        // TryPop — safe removal
        if (stack.TryPop(out int poppedVal))
            Console.WriteLine($"TryPop: {poppedVal}");  // 20

        // ⚠ Calling Pop() on an empty stack throws InvalidOperationException!
        Console.WriteLine($"Remaining in stack: {stack.Count}");

        // Contains
        Console.WriteLine($"Contains(10): {stack.Contains(10)}");

        // Iteration
        Console.Write("Stack contents: ");
        foreach (int el in stack)
            Console.Write(el + " ");
        Console.WriteLine();
    }

    // ---- DICTIONARY<TKey, TValue> — key-value pairs ----
    // Keys are UNIQUE, lookup is fast (O(1))
    static void DemoDictionary()
    {
        Console.WriteLine("\n-- Dictionary<K,V> --");

        var dict = new Dictionary<string, int>();

        // Add — throws exception if key already exists
        dict.Add("Alice", 25);
        dict.Add("Bob", 30);
        dict["Carol"] = 22;    // also works; updates if key exists

        Console.WriteLine($"Count: {dict.Count}");

        // Access by key
        Console.WriteLine($"dict['Alice'] = {dict["Alice"]}");

        // ContainsKey — checks if a key exists
        Console.WriteLine($"ContainsKey('Bob'):  {dict.ContainsKey("Bob")}");
        Console.WriteLine($"ContainsValue(30):   {dict.ContainsValue(30)}");

        // ⚠ Safe access with TryGetValue — avoids KeyNotFoundException
        if (dict.TryGetValue("Alice", out int aliceAge))
            Console.WriteLine($"TryGetValue Alice: {aliceAge}");
        else
            Console.WriteLine("Alice not found");

        // Iterating over all pairs
        Console.WriteLine("All entries:");
        foreach (KeyValuePair<string, int> pair in dict)
            Console.WriteLine($"  {pair.Key} → {pair.Value}");

        // Keys only / Values only
        Console.Write("Keys: ");
        foreach (string key in dict.Keys)
            Console.Write(key + " ");
        Console.WriteLine();

        // Remove — removes by key
        dict.Remove("Bob");
        Console.WriteLine($"After Remove: {dict.Count}");
    }

    // ---- HASHSET<T> — unique set (no duplicates) ----
    static void DemoHashSet()
    {
        Console.WriteLine("\n-- HashSet<T> --");

        var set = new HashSet<int>();

        // Add — if already present, nothing happens (no exception)
        set.Add(1);
        set.Add(2);
        set.Add(3);
        set.Add(3);  // duplicate — silently ignored
        Console.WriteLine($"Count (with duplicate 3): {set.Count}");  // 3, not 4!

        // Contains
        Console.WriteLine($"Contains(2): {set.Contains(2)}");

        // Remove
        set.Remove(1);
        Console.WriteLine($"After Remove(1): {set.Count}");

        // Set operations
        var set2 = new HashSet<int> { 3, 4, 5 };

        var union = new HashSet<int>(set);
        union.UnionWith(set2);          // {2, 3, 4, 5} — all elements
        Console.Write("UnionWith: ");
        foreach (int el in union) Console.Write(el + " ");
        Console.WriteLine();

        var intersect = new HashSet<int>(set);
        intersect.IntersectWith(set2);  // elements in both sets
        Console.Write("IntersectWith: ");
        foreach (int el in intersect) Console.Write(el + " ");  // {3}
        Console.WriteLine();

        var except = new HashSet<int>(set);
        except.ExceptWith(set2);        // set minus set2 elements
        Console.Write("ExceptWith: ");
        foreach (int el in except) Console.Write(el + " ");  // {2}
        Console.WriteLine();
    }

    // ---- FILE OPERATIONS ----
    static void DemoFiles()
    {
        Console.WriteLine("\n-- Files --");

        string path = "test.txt";

        // ---- Writing ----

        // WriteAllText — overwrites or creates the file
        File.WriteAllText(path, "First line\n");
        Console.WriteLine("WriteAllText: written.");

        // AppendAllText — adds to existing content
        File.AppendAllText(path, "Second line\n");
        File.AppendAllText(path, "Third line\n");
        Console.WriteLine("AppendAllText: appended.");

        // AppendAllLines — writes an array of lines
        string[] lines = { "Fourth", "Fifth" };
        File.AppendAllLines(path, lines);
        Console.WriteLine("AppendAllLines: lines appended.");

        // ---- Reading ----

        // Always check if the file exists BEFORE reading
        if (!File.Exists(path))
        {
            Console.WriteLine("File not found!");
            return;
        }

        // ReadAllText — entire content as one string
        string allText = File.ReadAllText(path);
        Console.WriteLine($"\nReadAllText:\n{allText}");

        // ReadAllLines — array of lines
        string[] readLines = File.ReadAllLines(path);
        Console.WriteLine($"ReadAllLines — line count: {readLines.Length}");

        // ---- StreamWriter / StreamReader (for large files) ----

        string streamPath = "stream_test.txt";

        // StreamWriter — writing via stream
        // 'using' guarantees the file is closed even if an error occurs
        using (StreamWriter writer = new StreamWriter(streamPath))
        {
            writer.WriteLine("StreamWriter line 1");
            writer.WriteLine("StreamWriter line 2");
        }  // automatically calls Close() + Dispose() here
        Console.WriteLine("StreamWriter: written.");

        // StreamReader — reading line by line
        if (File.Exists(streamPath))
        {
            using (StreamReader reader = new StreamReader(streamPath))
            {
                Console.WriteLine("StreamReader output:");
                string? line = reader.ReadLine();  // returns null at end of file
                while (line != null)
                {
                    Console.WriteLine($"  → {line}");
                    line = reader.ReadLine();
                }
            }  // file is automatically closed here
        }

        // ---- Cleanup — delete test files ----
        if (File.Exists(path)) File.Delete(path);
        if (File.Exists(streamPath)) File.Delete(streamPath);
        Console.WriteLine("Test files deleted.");
    }
}

// ============================================================
// QUICK SUMMARY — KEY THINGS TO REMEMBER
// ============================================================
//
//  #1 INTRODUCTION
//     • value type (stack): int, double, bool, char
//     • reference type (heap): string, object, arrays, classes
//     • var — inferred type (still static), const — compile-time constant
//     • int/int = int (10/3 = 3!), use double if you need decimals
//
//  #2 LOOPS / ARRAYS / METHODS
//     • do-while — runs at least once, condition checked AFTER body
//     • break — exit loop, continue — skip current iteration
//     • array: fixed size, use .Length
//     • ref — variable MUST be initialized before passing
//     • out — no init needed, but method MUST assign a value
//     • overloading — same name, different parameter types/count
//
//  #3 STRINGS / COLLECTIONS
//     • string is IMMUTABLE — every operation creates a new object
//     • StringBuilder — use when doing many concatenations in a loop
//     • List<T> — dynamic size, Add/Remove/Sort/Contains/.Count
//     • ALWAYS check Count > 0 before accessing by index
//
//  #4 QUEUE / STACK / DICTIONARY / HASHSET / FILES
//     • Queue  — FIFO: Enqueue (back) → Dequeue (front)
//     • Stack  — LIFO: Push (top)     → Pop (top)
//     • Dictionary — unique keys; use TryGetValue for safe access
//     • HashSet — unique values only; UnionWith / IntersectWith / ExceptWith
//     • File.WriteAllText — overwrites; AppendAllText — adds to file
//     • using (StreamWriter/Reader) — guarantees the file is closed
//     • ALWAYS check File.Exists() before reading
// ============================================================
