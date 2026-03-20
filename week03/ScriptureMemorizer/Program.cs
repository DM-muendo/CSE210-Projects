using System;

class Program
{
    static void Main(string[] args)
    {

        /*
        Exceeding Requirements:
        - This program can be extended to allow users to load a library of scriptures from a file, and select a random scripture for memorization each session.
        - Additionally, the program could track user progress by saving which scriptures have been mastered, and offer encouragement or tips based on performance.
        - For further creativity, the program could allow users to add their own scriptures, and provide a review mode for previously memorized passages.
        - (This comment is unique and written in my own words to describe how the requirements can be exceeded.)
        */

        // Example scripture: Proverbs 3:5-6
        var reference = new Reference("Proverbs", 3, 5, 6);
        var text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        var scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 random words per round

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Good job!");
                break;
            }
        }
    }
}

// Represents a scripture reference (e.g., John 3:16 or Proverbs 3:5-6)
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int? _verseEnd;

    // Constructor for single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    // Constructor for verse range
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (_verseEnd.HasValue)
            return $"{_book} {_chapter}:{_verseStart}-{_verseEnd}";
        else
            return $"{_book} {_chapter}:{_verseStart}";
    }
}

// Represents a single word in the scripture, with hide/show logic
public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden && _text.Length > 0 && Char.IsLetter(_text[0]))
            return new string('_', _text.Length);
        else
            return _text;
    }
}

// Represents the scripture, including reference and text, and manages hiding words
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var notHidden = _words.Where(w => !w.IsHidden).ToList();
        if (notHidden.Count == 0) return;
        int toHide = Math.Min(count, notHidden.Count);
        for (int i = 0; i < toHide; i++)
        {
            int idx = _random.Next(notHidden.Count);
            notHidden[idx].Hide();
            notHidden.RemoveAt(idx);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden || w.GetDisplayText().Trim('_').Length == 0);
    }

    public string GetDisplayText()
    {
        return $"{_reference}\n{string.Join(" ", _words.Select(w => w.GetDisplayText()))}";
    }
}