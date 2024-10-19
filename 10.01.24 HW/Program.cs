using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Collections;

//Task 1:
public class EnglishUkrainianDictionary
{
    private Dictionary<string, List<string>> dictionary;

    public EnglishUkrainianDictionary()
    {
        dictionary = new Dictionary<string, List<string>>();
    }

    public void AddWord(string englishWord, List<string> ukrainianTranslations)
    {
        dictionary[englishWord] = ukrainianTranslations;
    }

    public void RemoveWord(string englishWord)
    {
        dictionary.Remove(englishWord);
    }

    public void RemoveTranslation(string englishWord, string ukrainianTranslation)
    {
        if (dictionary.ContainsKey(englishWord))
        {
            dictionary[englishWord].Remove(ukrainianTranslation);
            if (dictionary[englishWord].Count == 0)
            {
                dictionary.Remove(englishWord);
            }
        }
    }

    public void ChangeWord(string oldEnglishWord, string newEnglishWord)
    {
        if (dictionary.ContainsKey(oldEnglishWord))
        {
            var translations = dictionary[oldEnglishWord];
            dictionary.Remove(oldEnglishWord);
            dictionary[newEnglishWord] = translations;
        }
    }

    public void ChangeTranslation(string englishWord, string oldTranslation, string newTranslation)
    {
        if (dictionary.ContainsKey(englishWord))
        {
            var translations = dictionary[englishWord];
            int index = translations.IndexOf(oldTranslation);
            if (index != -1)
            {
                translations[index] = newTranslation;
            }
        }
    }

    public List<string> FindTranslations(string englishWord)
    {
        if (dictionary.ContainsKey(englishWord))
        {
            return dictionary[englishWord];
        }
        return null;
    }

    public void Display()
    {
        foreach (var entry in dictionary)
        {
            Console.WriteLine($"{entry.Key} : {string.Join(", ", entry.Value)}");
        }
    }
}


//Task 2
public class MathUtilities
{
    public static T MaxOfThree<T>(T a, T b, T c) where T : IComparable<T>
    {
        T max = a;
        if (b.CompareTo(max) > 0)
        {
            max = b;
        }
        if (c.CompareTo(max) > 0)
        {
            max = c;
        }
        return max;
    }
}


//Task 3
public class Fish
{
    public string Name { get; set; }
    public string Species { get; set; }

    public Fish(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public override string ToString()
    {
        return $"{Name} ({Species})";
    }
}

public class Crustacea
{
    public string Name { get; set; }
    public string Species { get; set; }

    public Crustacea(string name, string species)
    {
        Name = name;
        Species = species;
    }

    public override string ToString()
    {
        return $"{Name} ({Species})";
    }
}

public class Aquarium : IEnumerable
{
    private List<object> creatures;

    public Aquarium()
    {
        creatures = new List<object>();
    }

    public void AddCreature(object creature)
    {
        creatures.Add(creature);
    }

    public IEnumerator GetEnumerator()
    {
        return creatures.GetEnumerator();
    }
}


public class Program
{
    static void Main(string[] args)
    {
        //Task 1
        var dict = new EnglishUkrainianDictionary();
        dict.AddWord("apple", new List<string> { "яблуко" });
        dict.AddWord("table", new List<string> { "стіл", "таблиця" });
        dict.Display();
        dict.ChangeWord("table", "desk");
        dict.Display();
        dict.RemoveTranslation("desk", "таблиця");
        dict.Display();
        var translations = dict.FindTranslations("apple");
        if (translations != null)
        {
            Console.WriteLine($"Translations for 'apple': {string.Join(", ", translations)}");
        }


        //Task 2
        Console.WriteLine($"Max of (3, 5, 4): {MathUtilities.MaxOfThree(3, 5, 4)}");
        Console.WriteLine($"Max of (2.7, 1.8, 3.4): {MathUtilities.MaxOfThree(2.7, 1.8, 3.4)}");
        Console.WriteLine($"Max of ('apple', 'orange', 'banana'): {MathUtilities.MaxOfThree("apple", "orange", "banana")}");


        //Task 3
        var aquarium = new Aquarium();
        aquarium.AddCreature(new Fish("Salmon", "Clownfish"));
        aquarium.AddCreature(new Crustacea("Crab", "Crayfish"));

        foreach (var creature in aquarium)
        {
            Console.WriteLine(creature);
        }
    }
}

