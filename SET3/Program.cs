using Microsoft.SqlServer.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace SET3
{
    /*
     Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.
    Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1. 
    Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz). 
    Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. 
    Se da un vector cu n elemente, o valoare e si o pozitie din vector k. Se cere sa se insereze valoarea e in vector pe pozitia k. Primul element al vectorului se considera pe pozitia zero. 
    Se da un vector cu n elemente si o pozitie din vector k. Se cere sa se stearga din vector elementul de pe pozitia k. Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga. 
    Reverse. Se da un vector nu n elemente. Se cere sa se inverseze ordinea elementelor din vector. Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.
    Rotire. Se da un vector cu n elemente. Rotiti elementele vectorului cu o pozitie spre stanga. Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc. 
    Rotire k. Se da un vector cu n elemente. Rotiti elementele vectorului cu k pozitii spre stanga. 
    Cautare binara. Se da un vector cu n elemente sortat in ordine crescatoare. Se cere sa se determine pozitia unui element dat k. Daca elementul nu se gaseste in vector rezultatul va fi -1. 
    Se da un numar natural n. Se cere sa se afiseze toate numerele prime mai mici sau egale cu n (ciurul lui Eratostene). 
    Sortare selectie. Implementati algoritmul de sortare <Selection Sort>. 
    Sortare prin insertie. Implementati algoritmul de sortare <Insertion Sort>. 
    Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului). 
    Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector. 
    Se da un vector de n numere naturale. Determinati cel mai mare divizor comun al elementelor vectorului.
    Se da un numar n in baza 10 si un numar b. 1 < b < 17. Sa se converteasca si sa se afiseze numarul n in baza b.   
    Se da un polinom de grad n ai carui coeficienti sunt stocati intr-un vector. Cel mai putin semnificativ coeficient este pe pozitia zero in vector. Se cere valoarea polinomului intr-un punct x. 
    Se da un vector s (vectorul in care se cauta) si un vector p (vectorul care se cauta). Determinati de cate ori apare p in s. De ex. Daca s = [1,2,1,2,1,3,1,2,1] si p = [1,2,1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar). 
    Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2. Determinati numarul de suprapuneri (margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare. Siragurile de margele se pot roti atunci cand le suprapunem. 
    Se dau doi vectori. Se cere sa se determine ordinea lor lexicografica (care ar trebui sa apara primul in dictionar). 
    Se dau doi vectori v1 si v2. Se cere sa determine intersectia, reuniunea, si diferentele v1-v2 si v2 -v1 (implementarea operatiilor cu multimi). Elementele care se repeta vor fi scrise o singura data in rezultat. 
    Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare. 
    Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare (v[i] este 1 daca i face parte din multime si este 0 in caz contrar).
    (Interclasare) Se dau doi vector sortati crescator v1 si v2. Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2. Sunt permise elemente duplicate. 
    Se dau doua numere naturale foarte mari (cifrele unui numar foarte mare sunt stocate intr-un vector - fiecare cifra pe cate o pozitie). Se cere sa se determine suma, diferenta si produsul a doua astfel de numere. 
     Se da un vector si un index in vectorul respectiv. Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat. 
    Quicksort. Sortati un vector folosind metoda QuickSort. 
    MergeSort. Sortati un vector folosind metoda MergeSort.
    Sortare bicriteriala. Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i]. Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima. 
    (Element majoritate). Intr-un vector cu n elemente, un element m este element majoritate daca mai mult de n/2 din valorile vectorului sunt egale cu m (prin urmare, daca un vector are element majoritate acesta este unui singur).  Sa se determine elementul majoritate al unui vector (daca nu exista atunci se va afisa <nu exista>). (incercati sa gasiti o solutie liniara). 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            SET3();
            Console.WriteLine("Aplicatia s-a inchis.");
        }

        private static void SET3()
        {
            Console.WriteLine("SET3 de exercitii in ConsoleApp - Fundamentele programarii 2022 - pali roland\n");
            Console.WriteLine("Apasa orice buton pentru a continua spre meniul de alegere al exercitiilor");
            Console.ReadKey();
            while (true)
            {
                MENU();
                string menubrowser = Console.ReadLine();
                switch (menubrowser.ToLower())
                {
                    case "exit":
                        return;
                    case "1":
                        Start();
                        P1();
                        Finish();
                        break;
                    case "2":
                        Start();
                        P2();
                        Finish();
                        break;
                    case "3":
                        Start();
                        P3();
                        Finish();
                        break;
                    case "4":
                        Start();
                        P4();
                        Finish();
                        break;
                    case "5":
                        Start();
                        P5();
                        Finish();
                        break;
                    case "6":
                        Start();
                        P6();
                        Finish();
                        break;
                    case "7":
                        Start();
                        P7();
                        Finish();
                        break;
                    case "8":
                        Start();
                        P8();
                        Finish();
                        break;
                    case "9":
                        Start();
                        P9();
                        Finish();
                        break;
                    case "10":
                        Start();
                        P10();
                        Finish();
                        break;
                    case "11":
                        Start();
                        P11();
                        Finish();
                        break;
                    case "12":
                        Start();
                        P12();
                        Finish();
                        break;
                    case "13":
                        Start();
                        P13();
                        Finish();
                        break;
                    case "14":
                        Start();
                        P14();
                        Finish();
                        break;
                    case "15":
                        Start();
                        P15();
                        Finish();
                        break;
                    case "16":
                        Start();
                        P16();
                        Finish();
                        break;
                    case "17":
                        Start();
                        P17();
                        Finish();
                        break;
                    case "18":
                        Start();
                        P18();
                        Finish();
                        break;
                    case "19":
                        Start();
                        P19();
                        Finish();
                        break;
                    case "20":
                        Start();
                        P20();
                        Finish();
                        break;
                    case "21":
                        Start();
                        P21();
                        Finish();
                        break;
                    case "22":
                        Start();
                        P22();
                        Finish();
                        break;
                    case "23":
                        Start();
                        P23();
                        Finish();
                        break;
                    case "24":
                        Start();
                        P24();
                        Finish();
                        break;
                    case "25":
                        Start();
                        P25();
                        Finish();
                        break;
                    case "26":
                        Start();
                        P26();
                        Finish();
                        break;
                    case "27":
                        Start();
                        P27();
                        Finish();
                        break;
                    case "28":
                        Start();
                        P28();
                        Finish();
                        break;
                    case "29":
                        Start();
                        P29();
                        Finish();
                        break;
                    case "30":
                        Start();
                        P30();
                        Finish();
                        break;
                    case "31":
                        Start();
                        P31();
                        Finish();
                        break;
                    default:
                        Console.WriteLine("Valoarea introdusa nu apartine criteriului cerut, apasa orice buton pentru a reveni la meniul de selectie!");
                        Console.ReadKey();
                        break;
                }
            }
        }


        private static void MENU()
        {
            Console.Clear();
            Console.WriteLine("SET 3 de exercitii:");
            Console.WriteLine("1. Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.");
            Console.WriteLine("2. Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1. ");
            Console.WriteLine("3. Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz).");
            Console.WriteLine("4. Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. ");
            Console.WriteLine("5. Se da un vector cu n elemente, o valoare e si o pozitie din vector k.Se cere sa se insereze valoarea e in vector pe pozitia k.Primul element al vectorului se considera pe pozitia zero.");
            Console.WriteLine("6. Se da un vector cu n elemente si o pozitie din vector k.Se cere sa se stearga din vector elementul de pe pozitia k.Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga.");
            Console.WriteLine("7. Reverse.Se da un vector nu n elemente.Se cere sa se inverseze ordinea elementelor din vector.Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.");
            Console.WriteLine("8. Rotire.Se da un vector cu n elemente.Rotiti elementele vectorului cu o pozitie spre stanga.Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc.");
            Console.WriteLine("9. Rotire k.Se da un vector cu n elemente.Rotiti elementele vectorului cu k pozitii spre stanga.");
            Console.WriteLine("10. Cautare binara.Se da un vector cu n elemente sortat in ordine crescatoare.Se cere sa se determine pozitia unui element dat k.Daca elementul nu se gaseste in vector rezultatul va fi - 1.");
            Console.WriteLine("11. Se da un numar natural n.Se cere sa se afiseze toate numerele prime mai mici sau egale cu n(ciurul lui Eratostene).");
            Console.WriteLine("12. Sortare selectie.Implementati algoritmul de sortare < Selection Sort >.");
            Console.WriteLine("13. Sortare prin insertie.Implementati algoritmul de sortare < Insertion Sort >.");
            Console.WriteLine("14. Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului).");
            Console.WriteLine("15. Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector.");
            Console.WriteLine("16. Se da un vector de n numere naturale.Determinati cel mai mare divizor comun al elementelor vectorului.");
            Console.WriteLine("17. Se da un numar n in baza 10 si un numar b. 1 < b < 17.Sa se converteasca si sa se afiseze numarul n in baza b.");
            Console.WriteLine("18. Se da un polinom de grad n ai carui coeficienti sunt stocati intr - un vector.Cel mai putin semnificativ coeficient este pe pozitia zero in vector.Se cere valoarea polinomului intr - un punct x.");
            Console.WriteLine("19. Se da un vector s(vectorul in care se cauta) si un vector p(vectorul care se cauta).Determinati de cate ori apare p in s.De ex.Daca s = [1, 2, 1, 2, 1, 3, 1, 2, 1] si p = [1, 2, 1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar).");
            Console.WriteLine("20. Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2.Determinati numarul de suprapuneri(margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare.Siragurile de margele se pot roti atunci cand le suprapunem.");
            Console.WriteLine("21. Se dau doi vectori.Se cere sa se determine ordinea lor lexicografica(care ar trebui sa apara primul in dictionar).");
            Console.WriteLine("22. Se dau doi vectori v1 si v2.Se cere sa determine intersectia, reuniunea, si diferentele v1 - v2 si v2 - v1(implementarea operatiilor cu multimi).Elementele care se repeta vor fi scrise o singura data in rezultat.");
            Console.WriteLine("23. Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare.");
            Console.WriteLine("24. Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare(v[i] este 1 daca i face parte din multime si este 0 in caz contrar).");
            Console.WriteLine("25. (Interclasare) Se dau doi vector sortati crescator v1 si v2.Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2.Sunt permise elemente duplicate.");
            Console.WriteLine("26. Se dau doua numere naturale foarte mari(cifrele unui numar foarte mare sunt stocate intr - un vector - fiecare cifra pe cate o pozitie).Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.");
            Console.WriteLine("27. Se da un vector si un index in vectorul respectiv.Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat.");
            Console.WriteLine("28. Quicksort.Sortati un vector folosind metoda QuickSort.");
            Console.WriteLine("29. MergeSort.Sortati un vector folosind metoda MergeSort.");
            Console.WriteLine("30. Sortare bicriteriala.Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i].Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima.");
            Console.WriteLine("31. (Element majoritate).Intr - un vector cu n elemente, un element m este element majoritate daca mai mult de n / 2 din valorile vectorului sunt egale cu m(prin urmare, daca un vector are element majoritate acesta este unui singur).Sa se determine elementul majoritate al unui vector(daca nu exista atunci se va afisa < nu exista >). (incercati sa gasiti o solutie liniara).");

            Console.Write("Introduceti un numar de la 1 la 32 sau 'exit' pentru a iesi din aplicatie: ");
        }
        private static void Finish()
        {
            Console.WriteLine();
            Console.WriteLine("Pentru a reveni la meniul de selectie apasati orice buton.");
            Console.ReadKey();
        }
        private static void P31()
        {
            Console.WriteLine("31. (Element majoritate).Intr - un vector cu n elemente, un element m este element majoritate daca mai mult de n / 2 din valorile vectorului sunt egale cu m(prin urmare, daca un vector are element majoritate acesta este unui singur).Sa se determine elementul majoritate al unui vector(daca nu exista atunci se va afisa < nu exista >). (incercati sa gasiti o solutie liniara).");
            int[] arr = ArrayInputs();
            List<int> candidatesList = new List<int>();
            int[,] candidates = new int[arr.Length,arr.Length];
            for(int i = 0; i < arr.Length; i++)
            {
                if (candidatesList.Contains(arr[i]))
                candidatesList.Add(arr[i]);
            }
        }
        private static void P30()
        {
            Console.WriteLine("30. Sortare bicriteriala.Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i].Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima.");
            Console.WriteLine("E : ");
            int[] E = ArrayInputs();
            Console.WriteLine("W : ");
            int[] W = ArrayInputs();
            if (E.Length != W.Length)
            {
                Console.WriteLine("Vectori nu au voie sa aiba lungimi diferite");
                return;
            }
            for (int i = 0; i < E.Length; i++)    // insertion sort pe E, si sortare W astfel incat elementele sa isi retina ponderea pe index.
            {
                int j = i;
                while (j > 0 && E[j] < E[j - 1])
                {
                    (E[j], E[j - 1]) = (E[j - 1], E[j]);
                    (W[j], W[j - 1]) = (W[j - 1], W[j]);
                    j--;
                }
            }
            for (int i = 0; i < E.Length; i++)  // insertion sort bazat pe W, in care sortam elementele din E si W dupa ponderea din W ale elementelor egale.
            {
                int j = i;
                while (j > 0 && W[j] > W[j - 1] && E[j] == E[j - 1])
                {
                    (E[j], E[j - 1]) = (E[j - 1], E[j]);
                    (W[j], W[j - 1]) = (W[j - 1], W[j]);
                    j--;
                }
            }
            Console.WriteLine("E sortat cu ponderea elementelor din W: ");
            PrintArray(E);
            PrintArray(W);
        }
        private static void P29()
        {
            Console.WriteLine("29. MergeSort.Sortati un vector folosind metoda MergeSort.");
            int[] arr = ArrayInputs();
            MergeSort(arr);
            PrintArray(arr);
        }
        private static void MergeSort(int[] arr)
        {
            throw new NotImplementedException();
        }

        private static void P28()
        {
            Console.WriteLine("28. Quicksort.Sortati un vector folosind metoda QuickSort.");
            int[] arr = ArrayInputs();
            QuickSort(arr);
            PrintArray(arr);
        }

        private static void QuickSort(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        public static readonly Random rnd = new Random();
        private static void QuickSort(int[] v, int lo , int hi)
        {
            if (lo < hi)
            {
                int index;
                index = rnd.Next(lo, hi + 1);
                (v[lo], v[index]) = (v[index], v[lo]);
                int k = lo;
                for (int i = lo + 1; i <= hi; i++)
                    if (v[i] < v[lo])
                    {
                        k++;
                        (v[k], v[i]) = (v[i], v[k]);
                    }
                (v[lo], v[k]) = (v[k], v[lo]);

                QuickSort(v, lo, k - 1);
                QuickSort(v, k + 1, hi);
            }
        }

        private static void P27()
        {
            Console.WriteLine("27. Se da un vector si un index in vectorul respectiv.Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat.");
            int[] arr = ArrayInputs();
            Console.Write("Dati indexul: ");
            int index = int.Parse(Console.ReadLine());
            if(index >= arr.Length)
            {
                Console.WriteLine("Index introdus gresit.");
                return;
            }
            InsertionSort(arr);
            Console.WriteLine($"{arr[index]} este valoarea care se gaseste pe pozitia {index} dupa sortare.");

        }
        private static void P26()
        {
            Console.WriteLine("26. Se dau doua numere naturale foarte mari(cifrele unui numar foarte mare sunt stocate intr - un vector - fiecare cifra pe cate o pozitie).Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.");
            // folosinduma de bigintegerul meu din NumarMare.cs
            NumarMare V1 = new NumarMare(Console.ReadLine());
            NumarMare V2 = new NumarMare(Console.ReadLine());
            Console.WriteLine("V1 + V2 = ");
            Console.WriteLine(V1 + V2);
            Console.WriteLine("V1 - V2 = ");
            Console.WriteLine(V1 - V2);
            Console.WriteLine("V1 * V2 = ");
            Console.WriteLine(V1 * V2);
        }
        private static void P25()
        {
            Console.WriteLine("25. (Interclasare) Se dau doi vector sortati crescator v1 si v2.Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2.Sunt permise elemente duplicate.");
            int[] arr1 = ArrayInputs();
            InsertionSort(arr1);
            int[] arr2 = ArrayInputs();
            SelectionSort(arr2);
            int[] interclasat = Combine(arr1, arr2);
            PrintArray(interclasat);
        }

        private static int[] Combine(int[] arr1, int[] arr2)
        {
            List<int> ints = new List<int>();
            foreach (int i in arr1) ints.Add(i);
            foreach (int i in arr2) ints.Add(i);
            int[] ToReturn = ints.ToArray();
            InsertionSort(ToReturn); 
            return ToReturn;
        }

        private static void P24()
        {
            Console.WriteLine("v1 : ");
            int[] arr1 = ArrayInputs("VectorBinar");
            Console.WriteLine("v2 : ");
            int[] arr2 = ArrayInputs("VectorBinar");
            Console.WriteLine("v1 U v2 :");
            int[] reunion = ReunionBinar(arr1, arr2);
            PrintArray(reunion);
            Console.WriteLine("v1 ∩ v2 :");
            int[] intersection = IntersectionBinar(arr1, arr2);
            PrintArray(intersection);
            Console.WriteLine(@"v1 \ v2 :");
            int[] difference1 = DifferenceBinar(arr1, arr2);
            PrintArray(difference1);
            Console.WriteLine(@"v2 \ v1 :");
            int[] difference2 = DifferenceBinar(arr2, arr1);
            PrintArray(difference2);
        }
        public static int[] ReunionBinar(int[] arr1, int[] arr2)
        {
            int[] ToReturn = new int[Math.Max(arr1.Length, arr2.Length)];
            for(int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] == 1)
                {
                    ToReturn[i] = 1;
                }
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] == 1)
                {
                    ToReturn[i] = 1;
                }
            }
            return ToReturn;
        }
        public static int[] IntersectionBinar(int[] arr1, int[] arr2)
        {
            int[] ToReturn = new int[Math.Min(arr1.Length, arr2.Length)];
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == 1 && arr2[i] == 1)
                {
                    ToReturn[i] = 1;
                }
            }
            return ToReturn;
        }
        public static int[] DifferenceBinar(int[] arr1, int[] arr2)
        {
            int[] ToReturn = new int[Math.Max(arr1.Length, arr2.Length)];
            for (int i = 0; i < Math.Min(arr1.Length, arr2.Length); i++)
            {
                if (arr1[i] == 1 && arr2[i] == 0)
                {
                    ToReturn[i] = 1;
                }
            }
            if(arr1.Length > arr2.Length)
            {
                int i = arr2.Length;
                while( i < arr1.Length)
                {
                    ToReturn[i] = 1;
                    i++;
                }
            }
            return ToReturn;
        }
        private static void P23()
        {
            P22(); // nu inteleg ce diferenta face daca elementele sunt in ordine crescatoare (?)
        }
        private static void P22()
        {
            Console.WriteLine("22. Se dau doi vectori v1 si v2.Se cere sa determine intersectia, reuniunea, si diferentele v1 - v2 si v2 - v1(implementarea operatiilor cu multimi).Elementele care se repeta vor fi scrise o singura data in rezultat.");
            Console.WriteLine("v1 : ");
            int[] arr1 = ArrayInputs();
            Console.WriteLine("v2 : ");
            int[] arr2 = ArrayInputs();
            Console.WriteLine("v1 U v2 :");
            int[] reunion = Reunion(arr1, arr2);
            PrintArray(reunion);
            Console.WriteLine("v1 ∩ v2 :");
            int[] intersection = Intersection(arr1, arr2);       
            PrintArray(intersection);
            Console.WriteLine(@"v1 \ v2 :");
            int[] difference1 = Difference(arr1, arr2);
            PrintArray(difference1);
            Console.WriteLine(@"v2 \ v1 :");
            int[] difference2 = Difference(arr2, arr1);
            PrintArray(difference2);

        }

        private static int[] Difference(int[] arr1, int[] arr2)
        {
            SortedSet<int> ints = new SortedSet<int>();
            foreach(int i in arr1) ints.Add(i);
            foreach (int i in arr2) ints.Remove(i);
            return ints.ToArray();
        }

        private static int[] Intersection(int[] arr1, int[] arr2)
        {
            SortedSet<int> ints = new SortedSet<int>();
            for(int i = 0; i < arr1.Length; i++)
            {
                for(int j = 0; j < arr2.Length; j++)
                {
                    if (arr1[i] == arr2[j])
                    {
                        ints.Add(arr1[i]);
                    }
                }
            }
            return ints.ToArray();
        }

        private static int[] Reunion(int[] arr1, int[] arr2)
        {
            SortedSet<int> ints= new SortedSet<int>();
            foreach(int i in arr1) ints.Add(i);
            foreach(int i in arr2) ints.Add(i);
            return ints.ToArray();
        }

        private static void P21()
        {
            Console.WriteLine("21. Se dau doi vectori.Se cere sa se determine ordinea lor lexicografica(care ar trebui sa apara primul in dictionar).");
            Console.WriteLine("v1: ");
            int[] arr1 = ArrayInputs();
            Console.WriteLine("v2: ");
            int[] arr2 = ArrayInputs();
            for(int i = 0; i < Math.Min(arr1.Length,arr2.Length); i++)
            {
                if (arr1[i] > arr2[i])
                {
                    Console.WriteLine("v1 > v2");
                    return;
                }
                if (arr1[i] < arr2[i])
                {
                    Console.WriteLine("v1 < v2");
                    return;
                }
            }
            if(arr1.Length > arr2.Length) // [1 , 2 , 3] > [ 1 , 2 ](?) habar nu am cum functioneaza ordinea lexicografica.
            {
                Console.WriteLine("v1 > v2");
                return;
            }
            if (arr1.Length < arr2.Length)
            {
                Console.WriteLine("v1 < v2");
                return;
            }
            Console.WriteLine("v1 = v2");
        }
        private static void P20()
        {
            // habar nu am ce inseamna rotirea in cazul sireagurilor pentru cerinta, nici nu stiu ce caut concret
            Console.WriteLine("20. Se dau doua siraguri de margele formate din margele albe si negre, notate s1, respectiv s2.Determinati numarul de suprapuneri(margea cu margea) a unui sirag peste celalalt astfel incat margelele suprapuse au aceeasi culoare.Siragurile de margele se pot roti atunci cand le suprapunem.");
            Console.WriteLine("Sireag 1: ");
            int[] arr1 = ArrayInputs("Binary");
            Console.WriteLine("Sireag 2: ");
            int[] arr2 = ArrayInputs("Binary");
            int sum = 0;
            if(arr1.Length > arr2.Length)
            {
                for(int i = 0; i < arr2.Length; i++)
                {
                    Rotate(arr2, 1);
                    for(int j = 0; j < arr1.Length; j++)
                    {
                        sum += IntSearch(arr1, arr2, j);
                    }                   
                }
            }
            else
            {
                for (int i = 0; i < arr1.Length; i++)
                {
                    Rotate(arr1, 1);
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        sum += IntSearch(arr2, arr1, j);
                    }
                }
            }
            Console.WriteLine($"{sum} suprapuneri posibile");
        }
        private static void P19()
        {
            Console.WriteLine("19. Se da un vector s(vectorul in care se cauta) si un vector p(vectorul care se cauta).Determinati de cate ori apare p in s.De ex.Daca s = [1, 2, 1, 2, 1, 3, 1, 2, 1] si p = [1, 2, 1] atunci p apare in s de 3 ori. (Problema este dificila doar daca o rezolvati cu un algoritm liniar).");
            int[] s = ArrayInputs();
            int[] p = ArrayInputs();
            int sum = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == p[0])
                {
                    sum += IntSearch(s, p, i);
                }
            }
            Console.WriteLine($"Vectorul a fost gasit de {sum} ori.");
        }
        private static int IntSearch(int[] s, int[] p, int index)
        {
            int i = index;
            int count = 0;
            if (i + p.Length > s.Length)
            {
                return 0;
            }
            while (count < p.Length)
            {              
                if (s[i] == p[count])
                {
                    i++;
                    count++;
                    continue;
                }
                else return 0;
            }
            return 1;
        }
        private static void P18()
        {
            Console.WriteLine("18. Se da un polinom de grad n ai carui coeficienti sunt stocati intr - un vector.Cel mai putin semnificativ coeficient este pe pozitia zero in vector.Se cere valoarea polinomului intr - un punct x.");
            Console.Write("Dati gradul polinomului: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Dati coeficientii polinomului in ordine: ");
            int[] poly = new int[n + 1];
            for(int i = 0; i <= n; i++)
            {
                Console.Write($"C{i}: ");
                poly[i] = int.Parse(Console.ReadLine());    
            }
            Console.Write("Dati valoarea 'x': ");
            int x = int.Parse(Console.ReadLine());
            int polysum = 0;
            for(int i = 0; i < poly.Length; i++)
            {
                polysum += poly[i] * (int)Math.Pow(x, i);
            }
            Console.WriteLine($"Suma polinomului dat in punctu {x} este: {polysum}");
        }
        private static void P17()
        {
            Console.WriteLine("17. Se da un numar n in baza 10 si un numar b. 1 < b < 17.Sa se converteasca si sa se afiseze numarul n in baza b.");
            Console.Write("Dati numarul de convertit: ");
            string n = Console.ReadLine();
            int f = int.Parse(n);
            Console.WriteLine("Dati baza dorita: ");
            int b = int.Parse(Console.ReadLine());
            StringBuilder str = new StringBuilder();
            do
            {
                if(f % b < 10)
                {
                    str.Insert(0, f % b);
                }
                else
                {
                    int r = f % b;
                    switch (r)
                    {
                        case 10:
                            str.Insert(0, 'a');
                            break;
                        case 11:
                            str.Insert(0, 'b');
                            break;
                        case 12:
                            str.Insert(0, 'c');
                            break;
                        case 13:
                            str.Insert(0, 'd');
                            break;
                        case 14:
                            str.Insert(0, 'e');
                            break;
                        case 15:
                            str.Insert(0, 'f');
                            break;
                    }
                }
                f /= b;
            } while (f != 0);
            Console.WriteLine($"Numarul convertit in baza {b} este: ");
            Console.Write(str.ToString());            
        }
        private static void P16()
        {
            Console.WriteLine("16. Se da un vector de n numere naturale.Determinati cel mai mare divizor comun al elementelor vectorului.");
            int[] arr = ArrayInputs();
            int cmmdc = arr[0];
            int i = 1;
            while(cmmdc > 1 && i < arr.Length)
            {
                cmmdc = CMMDC(cmmdc, arr[i]);
                i++;
            }
            Console.WriteLine("CMMDC al elementelor este: " + cmmdc);
        }
        private static int CMMDC(int a, int b)
        {
            int r;
            while(b != 0)
            {
                r = a % b;
                a = b;
                b = r; 
            }
            return a;
        }
        private static void P15()
        {
            Console.WriteLine("15. Modificati un vector prin eliminarea elementelor care se repeta, fara a folosi un alt vector.");
            int[] arr = ArrayInputs();
            int max = arr.Length - 1;
            for(int i = 0; i < max; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        arr[i] = 0;
                        (arr[i], arr[max]) = (arr[max], arr[i]);              // se sparge ordinea initiala a vectorului, ramane doar un fel de sortedset.
                        while (arr[i] == 0)
                        {
                            (arr[i], arr[max]) = (arr[max], arr[i]);
                            max--;
                            
                        }
                        j = -1;
                    }
                }
            }
            Array.Resize(ref arr, max + 1);
            PrintArray(arr);
        }
        private static void P14_b()
        {
            Console.WriteLine("14. Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului).");
            int[] arr = ArrayInputs();
            int max = arr.Length - 1;
            for (int i = 0; i < max; i++)            // IN ACEST CAZ NU SE RETINE ORDINEA ELEMENTELOR DIN VECTOR
            {
                while (arr[i] == 0)
                {
                    (arr[i],arr[max]) = (arr[max], arr[i]);
                    max--;
                }
            }
            Console.WriteLine("Elementele 0 transpuse la final: ");
            PrintArray(arr);

        }
        private static void P14()
        {
            Console.WriteLine("14. Interschimbati elementele unui vector in asa fel incat la final toate valorile egale cu zero sa ajunga la sfarsit. (nu se vor folosi vectori suplimentari - operatia se va realiza inplace cu un algoritm eficient - se va face o singura parcugere a vectorului).");
            int[] arr = ArrayInputs();
            int max = arr.Length;
            for(int i = 0; i < max; i++)            // IN ACEST CAZ RAMANE ORDINEA ELEMENTELOR DIN VECTOR
            {
                while(arr[i] == 0)
                {
                    max--;
                    for(int j = i; j < max; j++)
                    {
                        (arr[j], arr[j+1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
            Console.WriteLine("Elementele 0 transpuse la final: ");
            PrintArray(arr);

        }
        private static void P13()
        {
            Console.WriteLine("13. Sortare prin insertie.Implementati algoritmul de sortare < Insertion Sort >.");
            int[] arr = ArrayInputs();
            InsertionSort(arr);
            PrintArray(arr);
        }
        public static void InsertionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && arr[j] < arr[j - 1])
                {
                    (arr[j], arr[j - 1]) = (arr[j-1], arr[j]);
                    j--;
                }
            }
        }
        private static void P12()
        {
            Console.WriteLine("12. Sortare selectie.Implementati algoritmul de sortare < Selection Sort >.");
            int[] arr = ArrayInputs();
            SelectionSort(arr);
            PrintArray(arr);
        }
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
            }
        }
        private static void P11()
        {
            Console.WriteLine("11. Se da un numar natural n.Se cere sa se afiseze toate numerele prime mai mici sau egale cu n(ciurul lui Eratostene).");
            Console.Write("Dati 'n': ");
            CiurulLuiPrimelor(int.Parse(Console.ReadLine()));
        }
        static void CiurulLuiPrimelor(int n)
        {
            int[] primes = new int[n + 1];
            for (int i = 2; i < primes.Length; i++)
            {
                if (primes[i] == 0)
                {
                    for (int j = 2 * i; j < primes.Length; j += i)
                    {
                        primes[j] = 1;
                    }
                }
            }
            Console.WriteLine("Numerele prime: ");
            for (int i = 2; i < primes.Length; i++)
            {

                if (primes[i] == 0)
                    Console.Write(i + " ");
            }
        }
        private static void P10()
        {
            Console.WriteLine("10. Cautare binara.Se da un vector cu n elemente sortat in ordine crescatoare.Se cere sa se determine pozitia unui element dat k.Daca elementul nu se gaseste in vector rezultatul va fi - 1.");
            int[] arr = ArrayInputs();
            Array.Sort(arr);
            PrintArray(arr);
            Console.Write("Dati elementul 'k': ");
            int k = int.Parse(Console.ReadLine());
            int kpoz = -1;
            Console.Write("K se afla pe pozitia : ");
            int stg, dr, mij;
            stg = 0;
            dr = arr.Length - 1;
            while (stg <= dr)
            {
                mij = (stg + dr) / 2;
                if (arr[mij] < k)
                    stg = mij + 1;
                else if (arr[mij] > k)
                    dr = mij - 1;
                else
                {
                    Console.Write(mij);
                    return;
                }
            }
            Console.Write(kpoz);
        }
        private static void P9()
        {
            Console.WriteLine("9. Rotire k.Se da un vector cu n elemente.Rotiti elementele vectorului cu k pozitii spre stanga.");
            int[] arr = ArrayInputs();
            Console.Write("Dati 'k': ");
            int k = int.Parse(Console.ReadLine());
            k = k % arr.Length; // evident daca k = lungime atunci rezulta acelasi vector
            Rotate(arr, k);
            Console.WriteLine($"Vector rotit la stanga de {k} ori: ");
            PrintArray(arr);
        }
        public static void Rotate(int[] arr, int k)
        {
            for (int j = 1; j <= k; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }
            }
        }
        private static void P8()
        {
            Console.WriteLine("8. Rotire.Se da un vector cu n elemente.Rotiti elementele vectorului cu o pozitie spre stanga.Prin rotire spre stanga primul element devine ultimul, al doilea devine primul etc.");
            int[] arr = ArrayInputs();
            for(int i = 0; i < arr.Length - 1; i++)
            {
                (arr[i], arr[i+1]) = (arr[i+1], arr[i]);
            }
            Console.WriteLine("Vector rotit la stanga o pozitie: ");
            PrintArray(arr);
        }
        private static void P7()
        {
            Console.WriteLine("7. Reverse. Se da un vector nu n elemente.Se cere sa se inverseze ordinea elementelor din vector.Prin inversare se intelege ca primul element devine ultimul, al doilea devine penultimul etc.");
            int[] arr = ArrayInputs();
            if(arr.Length % 2 == 0)
            {
                int i = 0;
                int j = arr.Length - 1;
                do
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;j--;
                } while (i + 1 != j);
            }
            else
            {
                int i = 0;
                int j = arr.Length - 1;
                do
                {
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    i++;j--;
                } while (i + 2 != j);
            }
            Console.WriteLine("Vector inversat: ");
            PrintArray(arr);
        }
        private static void P6()
        {
            Console.WriteLine("6. Se da un vector cu n elemente si o pozitie din vector k.Se cere sa se stearga din vector elementul de pe pozitia k.Prin stergerea unui element, toate elementele din dreapta lui se muta cu o pozitie spre stanga.");
            int[] arr = ArrayInputs();
            Console.Write("Dati pozitia 'K': ");
            int k = int.Parse(Console.ReadLine());
            int[] newarr = new int[arr.Length - 1];
            int i = 0;
            while (i < newarr.Length)
            {
                while (i < k)
                {
                    newarr[i] = arr[i];
                    i++;
                    continue;
                }
                newarr[i] = arr[i + 1];
                i++;
            }
            Console.WriteLine("Element sters, noul vector este: ");
            PrintArray(newarr);
        }
        private static void P5()
        {
            Console.WriteLine("5. Se da un vector cu n elemente, o valoare e si o pozitie din vector k.Se cere sa se insereze valoarea e in vector pe pozitia k.Primul element al vectorului se considera pe pozitia zero.");
            int[] arr = ArrayInputs(1);
            Console.Write("Dati valoarea 'e': ");
            int e = int.Parse(Console.ReadLine());
            Console.Write("Dati pozitia 'k': ");
            int k = int.Parse(Console.ReadLine());
            for(int i = arr.Length - 2; i >= k; i--)
            {
                (arr[i + 1], arr[i]) = (arr[i], arr[i + 1]);
            }
            arr[k] = e;
            Console.WriteLine("Inserat cu succes, noul vector este:");
            PrintArray(arr);
        }

        private static void PrintArray(int[] arr)
        {
            foreach(int i in arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        private static void P4()
        {
            Console.WriteLine("4. Deteminati printr-o singura parcurgere, cea mai mica si cea mai mare valoare dintr-un vector si de cate ori apar acestea. ");
            int[] arr = ArrayInputs();
            int minval = arr[0];
            int maxval = arr[0];
            int maxcount = 1;
            int mincount = 1;
            for(int i = 1; i < arr.Length; i++)
            {
                if (arr[i] <= minval)
                {
                    if (arr[i] == minval)
                    {
                        mincount++;
                    }
                    else
                    {
                        mincount = 1;
                        minval = arr[i];
                    }
                }
                else
                {
                    if (arr[i] > maxval)
                    {
                        maxcount = 1;
                        maxval = arr[i];
                    }
                    else
                    {
                        if (arr[i] == maxval)
                        {
                            maxcount++;
                        }                       
                    }
                }
            }
            if(minval == maxval)
            {
                maxcount = mincount;
            }
            Console.WriteLine($"Cea mai mica valoare este {minval} si apare de {mincount} ori, iar cea mai mare valoare este {maxval} si apare de {maxcount} ori.");
        }
        private static void P3()
        {
            Console.WriteLine("3. Sa se determine pozitiile dintr-un vector pe care apar cel mai mic si cel mai mare element al vectorului. Pentru extra-credit realizati programul efectuand 3n/2 comparatii (in cel mai rau caz).");
            int[] arr = ArrayInputs();
            int min, max, maxval, minval;
            int i;
            if(arr.Length % 2 == 0)
            {
                if (arr[0] < arr[1])
                {
                    min = 0;
                    max = 1;
                    minval = arr[0];
                    maxval = arr[1];
                }
                else
                {
                    min = 1;
                    max = 0;
                    minval = arr[1];
                    maxval = arr[0];
                }
                i = 2;
                
            }
            else
            {
                min = 0;
                max = 0;
                minval = arr[0];
                maxval = arr[1];
                i = 1;
            }
            
            while(i < arr.Length - 1)
            {
                if (arr[i] > arr[i + 1])
                {
                    if (arr[i] > maxval)
                    {
                        max = i;
                        maxval = arr[i];
                    }
                    if (arr[i + 1] < minval)
                    {
                        min = i + 1;
                        minval = arr[i + 1];
                    }
                }
                else
                {
                    if (arr[i + 1] > maxval)
                    {
                        max = i + 1;
                        maxval = arr[i + 1];
                    }
                    if (arr[i] < minval)
                    {
                        min = i;
                        minval = arr[i];
                    }
                }
                i++;
                i++;
            }
            Console.WriteLine($"Valoarea minima ({minval}) se afla pe pozitia {min} iar valoarea maxima ({maxval}) pe pozitia {max}.");
        }
        private static void P2()
        {
            Console.WriteLine("2. Se da un vector cu n elemente si o valoare k. Se cere sa se determine prima pozitie din vector pe care apare k. Daca k nu apare in vector rezultatul va fi -1. ");
            Console.Write("Dati 'k' pe care vreti sa il gasiti: ");
            int k = int.Parse(Console.ReadLine());
            int[] arr = ArrayInputs();
            Console.Write($"{k} se gaseste pentru prima data pe pozitia: ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == k)
                {
                    Console.Write(i + ".");
                    return;
                }
            }
            Console.Write("-1.");
        }
        private static void P1()
        {
            Console.WriteLine("1. Calculati suma elementelor unui vector de n numere citite de la tastatura. Rezultatul se va afisa pe ecran.");
            int[] arr = ArrayInputs();
            int sum = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"Suma elementelor vectorului dat este: {sum}.");
        }
        
        
        private static void Start()
        {
            Console.Clear();
        }
        private static int[] ArrayInputs()
        {
            Console.WriteLine("Introduceti elementele vectorului cu ' ' , ',' sau ';' intre elemente!");
            char[] sep = new char[] { ' ', ',', ';' };
            string[] STarray = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int[] INTarray = new int[STarray.Length];
            int i = 0;
            foreach(string s in STarray)
            {
                INTarray[i] = int.Parse(s);
                i++;
            }
            return INTarray;
        }
        private static int[] ArrayInputs(int n)
        {
            Console.WriteLine("Introduceti elementele vectorului cu ' ' , ',' sau ';' intre elemente!");
            char[] sep = new char[] { ' ', ',', ';' };
            string[] STarray = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
            int[] INTarray = new int[STarray.Length + n];
            int i = 0;
            foreach (string s in STarray)
            {
                INTarray[i] = int.Parse(s);
                i++;
            }
            //PrintArray(INTarray);
            return INTarray;
        }
        private static int[] ArrayInputs(string st)
        {
            char[] sep = new char[] { ' ', ',', ';' };
            switch (st) 
            {
                case "Binary":
                    Console.WriteLine("Introduceti elementele vectorului cu ' ' , ',' sau ';' intre elemente! 0 pentru margea alba, 1 pentru neagra.");
                    
                    string[] STarray = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    int[] INTarray = new int[STarray.Length];
                    int i = 0;
                    foreach (string s in STarray)
                    {
                        INTarray[i] = int.Parse(s);
                        if (INTarray[i] != 0 && INTarray[i] != 1)
                        {
                            Console.WriteLine("Input incorect, sireag setat cu o margea alba");
                            return new int[] { 0 };
                        }
                        i++;
                    }
                    //PrintArray(INTarray);
                    return INTarray;
                case "VectorBinar":
                    Console.WriteLine("Introduceti elementele vectorului cu ' ' , ',' sau ';' intre elemente!");
                    string[] strings = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
                    List<int> ints = new List<int>();
                    for(int j = 0; j < strings.Length; j++)
                    {
                        ints.Add(int.Parse(strings[j]));
                    }
                    int[] ints1 = new int[ints.Max() + 1];
                    foreach(int nr in ints)
                    {
                        ints1[nr] = 1;
                    }
                    return ints1;                   
            }
            return new int[] { 0 }; // nu se intampla
        }
    }
}
