﻿using Microsoft.SqlServer.Server;
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
                    //case "17":
                    //    Start();
                    //    P17();
                    //    Finish();
                    //    break;
                    //case "18":
                    //    Start();
                    //    P18();
                    //    Finish();
                    //    break;
                    //case "19":
                    //    Start();
                    //    P19();
                    //    Finish();
                    //    break;
                    //case "20":
                    //    Start();
                    //    P20();
                    //    Finish();
                    //    break;
                    //case "21":
                    //    Start();
                    //    P21();
                    //    Finish();
                    //    break;
                    //case "22":
                    //    Start();
                    //    P22();
                    //    Finish();
                    //    break;
                    //case "23":
                    //    Start();
                    //    P3();
                    //    Finish();
                    //    break;
                    //case "24":
                    //    Start();
                    //    P4();
                    //    Finish();
                    //    break;
                    //case "25":
                    //    Start();
                    //    P5();
                    //    Finish();
                    //    break;
                    //case "26":
                    //    Start();
                    //    P6();
                    //    Finish();
                    //    break;
                    //case "27":
                    //    Start();
                    //    P7();
                    //    Finish();
                    //    break;
                    //case "28":
                    //    Start();
                    //    P8();
                    //    Finish();
                    //    break;
                    //case "29":
                    //    Start();
                    //    P9();
                    //    Finish();
                    //    break;
                    //case "30":
                    //    Start();
                    //    P10();
                    //    Finish();
                    //    break;
                    //case "31":
                    //    Start();
                    //    P11();
                    //    Finish();
                    //    break;
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
            Console.WriteLine("24. Aceleasi cerinte ca si la problema anterioara dar de data asta elementele din v1 respectiv v2  sunt in ordine strict crescatoare.");
            Console.WriteLine("25. Aceleasi cerinte ca si la problema anterioara dar de data asta elementele sunt stocate ca vectori cu valori binare(v[i] este 1 daca i face parte din multime si este 0 in caz contrar).");
            Console.WriteLine("26. (Interclasare) Se dau doi vector sortati crescator v1 si v2.Construiti un al treilea vector ordonat crescator format din toate elementele din  v1 si v2.Sunt permise elemente duplicate.");
            Console.WriteLine("27. Se dau doua numere naturale foarte mari(cifrele unui numar foarte mare sunt stocate intr - un vector - fiecare cifra pe cate o pozitie).Se cere sa se determine suma, diferenta si produsul a doua astfel de numere.");
            Console.WriteLine("28. Se da un vector si un index in vectorul respectiv.Se cere sa se determine valoarea din vector care va fi pe pozitia index dupa ce vectorul este sortat.");
            Console.WriteLine("29. Quicksort.Sortati un vector folosind metoda QuickSort.");
            Console.WriteLine("30. MergeSort.Sortati un vector folosind metoda MergeSort.");
            Console.WriteLine("31. Sortare bicriteriala.Se dau doi vectori de numere intregi E si W, unde E[i] este un numar iar W[i] este un numar care reprezinta ponderea lui E[i].Sortati vectorii astfel incat elementele lui E sa fie in in ordine crescatoare iar pentru doua valori egale din E, cea cu pondere mai mare va fi prima.");
            Console.WriteLine("32. (Element majoritate).Intr - un vector cu n elemente, un element m este element majoritate daca mai mult de n / 2 din valorile vectorului sunt egale cu m(prin urmare, daca un vector are element majoritate acesta este unui singur).Sa se determine elementul majoritate al unui vector(daca nu exista atunci se va afisa < nu exista >). (incercati sa gasiti o solutie liniara).");

            Console.Write("Introduceti un numar de la 1 la 32 sau 'exit' pentru a iesi din aplicatie: ");
        }
        private static void Finish()
        {
            Console.WriteLine();
            Console.WriteLine("Pentru a reveni la meniul de selectie apasati orice buton.");
            Console.ReadKey();
        }
        private static void P16()
        {
            Console.WriteLine("16. Se da un vector de n numere naturale.Determinati cel mai mare divizor comun al elementelor vectorului.");
            int[] arr = ArrayInputs();
            int cmmdc = arr[0];
            int i = 1;
            while(cmmdc > -9 && i < arr.Length)
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
            throw new NotImplementedException();
        }
        private static void P12()
        {
            Console.WriteLine("12. Sortare selectie.Implementati algoritmul de sortare < Selection Sort >.");
            throw new NotImplementedException();
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
            for(int j = 1; j <= k; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]);
                }                
            }
            Console.WriteLine($"Vector rotit la stanga de {k} ori: ");
            PrintArray(arr);
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
    }
}