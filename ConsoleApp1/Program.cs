// ============================================================
//  C# ATSISKAITYMO PAVYZDINIS PROJEKTAS
//  Temos: Įvadas, Ciklai/Masyvai/Metodai,
//         Tekstinės eilutės/Collections,
//         Queue/Stack/Dictionary/HashSet/Failai
// ============================================================

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    // ============================================================
    // PROGRAMA PRASIDEDA ČIA
    // ============================================================
    static void Main(string[] args)
    {
        Console.WriteLine("====================================");
        Console.WriteLine("   C# ATSISKAITYMO PAVYZDYS");
        Console.WriteLine("====================================\n");

        // Kiekviena tema iškviečiama atskirame metode
        Demo1_Ivadas();
        Demo2_CiklaiMasyvaiMetodai();
        Demo3_StringCollections();
        Demo4_QueueStackDictHashSetFailai();

        Console.WriteLine("\n✅ Programa baigė darbą!");
    }


    // ============================================================
    // TEMA #1 — ĮVADAS Į C#
    // ============================================================
    static void Demo1_Ivadas()
    {
        Console.WriteLine("\n--- TEMA #1: ĮVADAS ---");

        // --- Duomenų tipai (value types) ---
        int sveikas = 42;
        double slankus = 3.14;
        bool loginė = true;
        char simbolis = 'A';
        float mazasSlank = 1.5f;
        long didelisSk = 9_000_000_000L; // _ padeda skaitomumui

        // --- Reference type ---
        string tekstas = "Labas C#";   // null arba eilutė
        object obj = sveikas;      // bet koks tipas

        // --- var — tipas nustatomas automatiškai (bet yra statinis!) ---
        var auto = 100;           // kompiliatorius žino: int
        var autoTekstas = "Hi";   // kompiliatorius žino: string

        // --- const ir readonly ---
        const double PI = 3.14159;  // niekada nesikeičia, žinoma kompiliacijos metu
        // readonly galima priskirti tik deklaracijoje arba konstruktoriuje (klasės lygmenyje)

        Console.WriteLine($"int={sveikas}, double={slankus}, bool={loginė}, char={simbolis}");
        Console.WriteLine($"var auto={auto}, var autoTekstas={autoTekstas}, PI={PI}");

        // --- Implicit (automatinė) konversija — saugus platinimas ---
        int x = 10;
        double platinimas = x;   // int → double, nėra duomenų praradimo
        Console.WriteLine($"Implicit: int {x} → double {platinimas}");

        // --- Explicit (priverstinė) konversija — gali prarasti duomenis ---
        double tikslus = 9.99;
        int apkarpytas = (int)tikslus;  // dešimtainė dalis pametama!
        Console.WriteLine($"Explicit: double {tikslus} → int {apkarpytas}");

        // --- Aritmetiniai operatoriai ---
        int a = 10, b = 3;
        Console.WriteLine($"10+3={a + b}, 10-3={a - b}, 10*3={a * b}, 10/3={a / b}, 10%3={a % b}");
        // ⚠ int/int = int: 10/3 = 3, ne 3.33!

        // --- Lyginimo ir loginiai operatoriai ---
        Console.WriteLine($"10>3: {a > b}, 10==3: {a == b}, true&&false: {true && false}, !true: {!true}");

        // --- Sąlyga: if / else if / else ---
        int temp = 20;
        if (temp > 30)
            Console.WriteLine("Karšta");
        else if (temp > 15)
            Console.WriteLine($"Malonu ({temp}°C)");  // šis bus išspausdintas
        else
            Console.WriteLine("Šalta");

        // --- Ternary operatorius (trumpa if/else) ---
        string rezultatas = (temp > 0) ? "Teigiama" : "Neigiama";
        Console.WriteLine($"Ternary: {rezultatas}");

        // --- Switch sakinys ---
        int diena = 3;
        switch (diena)
        {
            case 1: Console.WriteLine("Pirmadienis"); break;
            case 2: Console.WriteLine("Antradienis"); break;
            case 3: Console.WriteLine("Trečiadienis"); break;  // šis
            default: Console.WriteLine("Kita diena"); break;
        }
    }


    // ============================================================
    // TEMA #2 — CIKLAI, MASYVAI, METODAI
    // ============================================================
    static void Demo2_CiklaiMasyvaiMetodai()
    {
        Console.WriteLine("\n--- TEMA #2: CIKLAI, MASYVAI, METODAI ---");

        // ---- CIKLAI ----

        // for — kai žinome iteracijų skaičių
        Console.Write("for: ");
        for (int i = 0; i < 5; i++)
            Console.Write(i + " ");   // 0 1 2 3 4
        Console.WriteLine();

        // while — kol sąlyga teisinga
        Console.Write("while: ");
        int n = 0;
        while (n < 5)
        {
            Console.Write(n + " ");
            n++;
        }
        Console.WriteLine();

        // do-while — vykdomas BENT VIENĄ KARTĄ (sąlyga tikrinama po)
        Console.Write("do-while: ");
        int m = 0;
        do
        {
            Console.Write(m + " ");
            m++;
        } while (m < 5);
        Console.WriteLine();

        // foreach — iteravimas per kolekciją
        int[] masyvElem = { 10, 20, 30, 40 };
        Console.Write("foreach: ");
        foreach (int el in masyvElem)
            Console.Write(el + " ");
        Console.WriteLine();

        // break — nutraukia ciklą
        Console.Write("break ties 3: ");
        for (int i = 0; i < 10; i++)
        {
            if (i == 3) break;
            Console.Write(i + " ");  // 0 1 2
        }
        Console.WriteLine();

        // continue — praleidžia šią iteraciją
        Console.Write("continue lyginiai: ");
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 != 0) continue;  // nelyginiai praleisti
            Console.Write(i + " ");    // 0 2 4
        }
        Console.WriteLine();

        // ---- MASYVAI ----

        // Paprastas masyvas — fiksuotas dydis
        int[] skaičiai = new int[5];          // visi 0 pagal nutylėjimą
        int[] inicializuotas = { 1, 2, 3, 4, 5 };

        Console.WriteLine($"Masyvo ilgis: {inicializuotas.Length}");
        Console.WriteLine($"Elementas [2]: {inicializuotas[2]}");  // 3

        // Iteravimas per masyvą su indeksu
        Console.Write("Masyvas: ");
        for (int i = 0; i < inicializuotas.Length; i++)
            Console.Write(inicializuotas[i] + " ");
        Console.WriteLine();

        // Dvimatis masyvas
        int[,] matrica = new int[2, 3];
        matrica[0, 0] = 1; matrica[0, 1] = 2; matrica[0, 2] = 3;
        matrica[1, 0] = 4; matrica[1, 1] = 5; matrica[1, 2] = 6;

        Console.WriteLine("Matrica:");
        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 3; j++)
                Console.Write(matrica[i, j] + "\t");
            Console.WriteLine();
        }

        // ---- METODŲ KVIETIMAI ----

        // Paprastas metodas
        int suma = Sudeti(5, 3);
        Console.WriteLine($"Sudeti(5,3) = {suma}");

        // Default parametras
        Sveikinti();           // naudoja numatytąjį "Svečias"
        Sveikinti("Jonas");    // naudoja "Jonas"

        // ref — keičia originalų kintamąjį (turi būti inicializuotas)
        int refSk = 10;
        PadaugintIš2(ref refSk);
        Console.WriteLine($"ref po PadaugintIš2: {refSk}");  // 20

        // out — metodas priskiria reikšmę (nereikia inicializuoti)
        GautiDuomenis(out int outRez);
        Console.WriteLine($"out GautiDuomenis: {outRez}");   // 99

        // params — kintamas kiekis argumentų
        Console.WriteLine($"params Suma(1,2,3,4): {SumaParams(1, 2, 3, 4)}");

        // Overloading — tas pats pavadinimas, skirtingi parametrai
        Console.WriteLine($"Overload int: {Skaiciuoti(5, 3)}");
        Console.WriteLine($"Overload double: {Skaiciuoti(5.5, 3.3)}");

        // Rekursija — faktorialas
        Console.WriteLine($"Faktorialas(5) = {Faktorialas(5)}");  // 120
    }

    // --- Metodų apibrėžimai (naudojami Demo2) ---

    // Grąžina dviejų skaičių sumą
    static int Sudeti(int a, int b)
    {
        return a + b;
    }

    // Default parametras: jei nenurodytas — naudojamas "Svečias"
    static void Sveikinti(string vardas = "Svečias")
    {
        Console.WriteLine($"Sveiki, {vardas}!");
    }

    // ref — kintamasis perduodamas kaip nuoroda, keičiamas originale
    static void PadaugintIš2(ref int skaičius)
    {
        skaičius *= 2;
    }

    // out — metodas PRIVALO priskirti reikšmę
    static void GautiDuomenis(out int rezultatas)
    {
        rezultatas = 99;  // privaloma priskirti
    }

    // params — leidžia perduoti bet kiek argumentų
    static int SumaParams(params int[] skaičiai)
    {
        int suma = 0;
        foreach (int s in skaičiai)
            suma += s;
        return suma;
    }

    // Overloading — int versija
    static int Skaiciuoti(int a, int b) => a + b;

    // Overloading — double versija (tas pats pavadinimas, kitas tipas)
    static double Skaiciuoti(double a, double b) => a + b;

    // Rekursija — kviečia pats save, bazinis atvejis: n <= 1
    static long Faktorialas(int n)
    {
        if (n <= 1) return 1;        // BAZINIS ATVEJIS — sustabdo rekursiją
        return n * Faktorialas(n - 1); // rekursinis kvietimas
    }


    // ============================================================
    // TEMA #3 — TEKSTINĖS EILUTĖS IR COLLECTIONS (List)
    // ============================================================
    static void Demo3_StringCollections()
    {
        Console.WriteLine("\n--- TEMA #3: TEKSTINĖS EILUTĖS IR COLLECTIONS ---");

        // ---- STRING METODAI ----

        string s = "  Labas, Pasauli!  ";

        Console.WriteLine($"Originalas:    [{s}]");
        Console.WriteLine($"Trim():        [{s.Trim()}]");          // pašalina kraštų tarpus
        Console.WriteLine($"ToUpper():     [{s.Trim().ToUpper()}]");
        Console.WriteLine($"ToLower():     [{s.Trim().ToLower()}]");
        Console.WriteLine($"Length:        {s.Length}");
        Console.WriteLine($"Contains('Labas'): {s.Contains("Labas")}");    // true
        Console.WriteLine($"StartsWith('  L'): {s.StartsWith("  L")}");    // true
        Console.WriteLine($"IndexOf('Pasauli'): {s.IndexOf("Pasauli")}");  // pozicija

        string pakeistas = s.Trim().Replace("Labas", "Sveikas");
        Console.WriteLine($"Replace:       [{pakeistas}]");

        // Substring — iškirpti dalį
        string sub = s.Trim().Substring(0, 5);  // nuo 0, ilgis 5
        Console.WriteLine($"Substring(0,5): [{sub}]");  // "Labas"

        // Split — dalinti į masyvą
        string csv = "Jonas,Petras,Ona";
        string[] vardai = csv.Split(',');
        Console.Write("Split: ");
        foreach (string v in vardai)
            Console.Write($"[{v}] ");
        Console.WriteLine();

        // IsNullOrEmpty / IsNullOrWhiteSpace — null tikrinimas
        string? galNullStr = null;
        Console.WriteLine($"IsNullOrEmpty(null): {string.IsNullOrEmpty(galNullStr)}");      // true
        Console.WriteLine($"IsNullOrWhiteSpace(' '): {string.IsNullOrWhiteSpace("  ")}");   // true

        // String interpoliation ir formatavimas
        string vardas = "Marija";
        int amžius = 25;
        Console.WriteLine($"Interpoliation: Sveika, {vardas}! Tau {amžius} metai.");
        Console.WriteLine(string.Format("Format: Sveika, {0}! Tau {1} metai.", vardas, amžius));

        // ⚠ String yra IMMUTABLE — kiekviena operacija sukuria NAUJĄ objektą
        string orig = "abc";
        string nauja = orig.ToUpper();  // orig lieka "abc"
        Console.WriteLine($"Immutable: orig={orig}, nauja={nauja}");

        // StringBuilder — efektyviam jungimui cikle
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

        var sarasas = new List<string>();
        sarasas.Add("Obuolys");
        sarasas.Add("Bananas");
        sarasas.Add("Citrina");
        Console.WriteLine($"Count po Add: {sarasas.Count}");

        // Prieiga per indeksą
        Console.WriteLine($"sarasas[1] = {sarasas[1]}");  // "Bananas"

        // Contains
        Console.WriteLine($"Contains('Obuolys'): {sarasas.Contains("Obuolys")}");

        // Remove
        sarasas.Remove("Bananas");
        Console.WriteLine($"Count po Remove: {sarasas.Count}");

        // Sort
        sarasas.Add("Avokadas");
        sarasas.Sort();
        Console.Write("Po Sort: ");
        foreach (string v2 in sarasas)
            Console.Write(v2 + " ");
        Console.WriteLine();

        // ⚠ Svarbu tikrinti prieš prieigą
        if (sarasas.Count > 0)
            Console.WriteLine($"Pirmas elementas: {sarasas[0]}");
    }


    // ============================================================
    // TEMA #4 — QUEUE, STACK, DICTIONARY, HASHSET, FAILAI
    // ============================================================
    static void Demo4_QueueStackDictHashSetFailai()
    {
        Console.WriteLine("\n--- TEMA #4: QUEUE, STACK, DICTIONARY, HASHSET, FAILAI ---");

        DemoQueue();
        DemoStack();
        DemoDictionary();
        DemoHashSet();
        DemoFailai();
    }

    // ---- QUEUE<T> — FIFO (First In, First Out) ----
    // Analogija: eilė prie kasos — pirmas atėjęs, pirmas aptarnaujamas
    static void DemoQueue()
    {
        Console.WriteLine("\n-- Queue (FIFO) --");

        var eilė = new Queue<string>();

        // Enqueue — deda į GALĄ
        eilė.Enqueue("Pirmas");
        eilė.Enqueue("Antras");
        eilė.Enqueue("Trečias");
        Console.WriteLine($"Count: {eilė.Count}");

        // Peek — žiūri į PRIEKĮ, bet neišima
        if (eilė.Count > 0)
            Console.WriteLine($"Peek (neiširia): {eilė.Peek()}");  // "Pirmas"

        // Dequeue — išima iš PRIEKIO
        if (eilė.Count > 0)
            Console.WriteLine($"Dequeue: {eilė.Dequeue()}");  // "Pirmas"

        // TryDequeue — saugus išėmimas (nemetamas exception)
        if (eilė.TryDequeue(out string? išimtas))
            Console.WriteLine($"TryDequeue: {išimtas}");  // "Antras"

        // ⚠ Jei eilė tuščia ir bandome Dequeue() — InvalidOperationException!
        Console.WriteLine($"Liko eilėje: {eilė.Count}");

        // Iteravimas
        Console.Write("Queue turinys: ");
        foreach (string el in eilė)
            Console.Write(el + " ");
        Console.WriteLine();
    }

    // ---- STACK<T> — LIFO (Last In, First Out) ----
    // Analogija: knygų krūva — paskutinė padėta, pirmoji paimama
    static void DemoStack()
    {
        Console.WriteLine("\n-- Stack (LIFO) --");

        var krūva = new Stack<int>();

        // Push — deda ant VIRŠAUS
        krūva.Push(10);
        krūva.Push(20);
        krūva.Push(30);
        Console.WriteLine($"Count: {krūva.Count}");

        // Peek — žiūri į VIRŠŲ, bet neišima
        if (krūva.Count > 0)
            Console.WriteLine($"Peek (neiširia): {krūva.Peek()}");  // 30

        // Pop — išima nuo VIRŠAUS
        if (krūva.Count > 0)
            Console.WriteLine($"Pop: {krūva.Pop()}");  // 30

        // TryPop — saugus išėmimas
        if (krūva.TryPop(out int išimtasInt))
            Console.WriteLine($"TryPop: {išimtasInt}");  // 20

        // ⚠ Jei krūva tuščia ir bandome Pop() — InvalidOperationException!
        Console.WriteLine($"Liko krūvoje: {krūva.Count}");

        // Contains
        Console.WriteLine($"Contains(10): {krūva.Contains(10)}");

        // Iteravimas
        Console.Write("Stack turinys: ");
        foreach (int el in krūva)
            Console.Write(el + " ");
        Console.WriteLine();
    }

    // ---- DICTIONARY<TKey, TValue> — raktų-reikšmių poros ----
    // Raktai UNIKALŪS, paieška greita (O(1))
    static void DemoDictionary()
    {
        Console.WriteLine("\n-- Dictionary<K,V> --");

        var žodynas = new Dictionary<string, int>();

        // Add — prideda (klaida jei raktas jau yra)
        žodynas.Add("Jonas", 25);
        žodynas.Add("Petras", 30);
        žodynas["Ona"] = 22;    // taip pat veikia; jei yra — atnaujina

        Console.WriteLine($"Count: {žodynas.Count}");

        // Prieiga per raktą
        Console.WriteLine($"žodynas['Jonas'] = {žodynas["Jonas"]}");

        // ContainsKey — tikrina ar raktas egzistuoja
        Console.WriteLine($"ContainsKey('Petras'): {žodynas.ContainsKey("Petras")}");
        Console.WriteLine($"ContainsValue(30): {žodynas.ContainsValue(30)}");

        // ⚠ Saugus gavimas su TryGetValue — vengia KeyNotFoundException
        if (žodynas.TryGetValue("Jonas", out int jonoAmžius))
            Console.WriteLine($"TryGetValue Jonas: {jonoAmžius}");
        else
            Console.WriteLine("Jonas nerastas");

        // Iteravimas per visas poras
        Console.WriteLine("Visi įrašai:");
        foreach (KeyValuePair<string, int> pora in žodynas)
            Console.WriteLine($"  {pora.Key} → {pora.Value}");

        // Tik raktai / tik reikšmės
        Console.Write("Raktai: ");
        foreach (string r in žodynas.Keys)
            Console.Write(r + " ");
        Console.WriteLine();

        // Remove — pašalina pagal raktą
        žodynas.Remove("Petras");
        Console.WriteLine($"Po Remove: {žodynas.Count}");
    }

    // ---- HASHSET<T> — unikali aibė (be pasikartojančių) ----
    static void DemoHashSet()
    {
        Console.WriteLine("\n-- HashSet<T> --");

        var aibė = new HashSet<int>();

        // Add — jei jau yra, nieko nevyksta (nemetama klaida)
        aibė.Add(1);
        aibė.Add(2);
        aibė.Add(3);
        aibė.Add(3);  // dublikatas — ignoruojamas
        Console.WriteLine($"Count (su dublikatu 3): {aibė.Count}");  // 3, ne 4!

        // Contains
        Console.WriteLine($"Contains(2): {aibė.Contains(2)}");

        // Remove
        aibė.Remove(1);
        Console.WriteLine($"Po Remove(1): {aibė.Count}");

        // Aibių operacijos
        var aibė2 = new HashSet<int> { 3, 4, 5 };

        var sąjunga = new HashSet<int>(aibė);
        sąjunga.UnionWith(aibė2);          // {2, 3, 4, 5} — visi elementai
        Console.Write("UnionWith: ");
        foreach (int el in sąjunga) Console.Write(el + " ");
        Console.WriteLine();

        var sankirta = new HashSet<int>(aibė);
        sankirta.IntersectWith(aibė2);     // bendri elementai
        Console.Write("IntersectWith: ");
        foreach (int el in sankirta) Console.Write(el + " ");  // {3}
        Console.WriteLine();

        var skirtumas = new HashSet<int>(aibė);
        skirtumas.ExceptWith(aibė2);       // aibė be aibė2 elementų
        Console.Write("ExceptWith: ");
        foreach (int el in skirtumas) Console.Write(el + " "); // {2}
        Console.WriteLine();
    }

    // ---- FAILŲ OPERACIJOS ----
    static void DemoFailai()
    {
        Console.WriteLine("\n-- Failai --");

        string kelias = "testas.txt";

        // ---- Rašymas ----

        // WriteAllText — perrašo arba sukuria failą
        File.WriteAllText(kelias, "Pirma eilutė\n");
        Console.WriteLine("WriteAllText: parašyta.");

        // AppendAllText — prideda prie esamo turinio
        File.AppendAllText(kelias, "Antra eilutė\n");
        File.AppendAllText(kelias, "Trečia eilutė\n");
        Console.WriteLine("AppendAllText: pridėta.");

        // WriteAllLines — rašo eilučių masyvą
        string[] eilutės = { "Ketvirta", "Penkta" };
        File.AppendAllLines(kelias, eilutės);
        Console.WriteLine("AppendAllLines: pridėtos eilutės.");

        // ---- Skaitymas ----

        // Tikrinti ar failas egzistuoja PRIEŠ skaitant
        if (!File.Exists(kelias))
        {
            Console.WriteLine("Failas nerastas!");
            return;
        }

        // ReadAllText — visas tekstas kaip viena eilutė
        string visas = File.ReadAllText(kelias);
        Console.WriteLine($"\nReadAllText:\n{visas}");

        // ReadAllLines — masyvas eilučių
        string[] skaitytosEilutės = File.ReadAllLines(kelias);
        Console.WriteLine($"ReadAllLines — eilučių skaičius: {skaitytosEilutės.Length}");

        // ---- StreamWriter / StreamReader (dideliems failams) ----

        string stream_kelias = "stream_testas.txt";

        // StreamWriter — rašymas per srautą
        // 'using' garantuoja, kad failas bus uždarytas (net jei įvyksta klaida)
        using (StreamWriter rašytojas = new StreamWriter(stream_kelias))
        {
            rašytojas.WriteLine("StreamWriter 1 eilutė");
            rašytojas.WriteLine("StreamWriter 2 eilutė");
        }  // čia automatiškai Close() + Dispose()
        Console.WriteLine("StreamWriter: parašyta.");

        // StreamReader — skaitymas eilutė po eilutės
        if (File.Exists(stream_kelias))
        {
            using (StreamReader skaitojas = new StreamReader(stream_kelias))
            {
                Console.WriteLine("StreamReader skaitymas:");
                string? eilutė = skaitojas.ReadLine();  // null jei EOF
                while (eilutė != null)
                {
                    Console.WriteLine($"  → {eilutė}");
                    eilutė = skaitojas.ReadLine();
                }
            }  // čia automatiškai uždaro failą
        }

        // ---- Valymas — ištriname test failus ----
        if (File.Exists(kelias)) File.Delete(kelias);
        if (File.Exists(stream_kelias)) File.Delete(stream_kelias);
        Console.WriteLine("Testų failai ištrinti.");
    }
}

// ============================================================
// GREITA SANTRAUKA — KĄ ATSIMINTI
// ============================================================
//
//  #1 ĮVADAS
//     • value type (stack): int, double, bool, char
//     • reference type (heap): string, object, masyvai, klasės
//     • var — automatinis tipas (statinis), const — kompiliacijos laiku
//     • int/int = int (10/3 = 3!), naudok double jei reikia tikslaus
//
//  #2 CIKLAI / MASYVAI / METODAI
//     • do-while — bent 1 kartą, nes sąlyga PO vykdymo
//     • break — išeiti iš ciklo, continue — praleisti iteraciją
//     • masyvas: fiksuotas dydis, .Length
//     • ref — kintamasis TURI būti inicializuotas prieš perduodant
//     • out — NEREIKIA inicializuoti, bet metodas PRIVALO priskirti
//     • overloading — tas pats pavadinimas, skirtingi parametrai
//
//  #3 STRING / COLLECTIONS
//     • string yra IMMUTABLE — kiekviena operacija = naujas objektas
//     • StringBuilder — naudok kai daug jungimo operacijų cikle
//     • List<T> — dinaminis dydis, Add/Remove/Sort/Contains/.Count
//     • VISADA tikrink Count > 0 prieš prieigą per indeksą
//
//  #4 QUEUE / STACK / DICTIONARY / HASHSET / FAILAI
//     • Queue  — FIFO: Enqueue (galą) → Dequeue (priekį)
//     • Stack  — LIFO: Push (viršų)  → Pop (viršų)
//     • Dictionary — unikalūs raktai; naudok TryGetValue saugiam gavimui
//     • HashSet — unikalios reikšmės; UnionWith / IntersectWith / ExceptWith
//     • File.WriteAllText — perrašo; AppendAllText — prideda
//     • using (StreamWriter/Reader) — garantuoja failo uždarymą
//     • VISADA tikrink File.Exists() prieš skaitant
// ============================================================
