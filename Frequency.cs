using System;

public enum Frequency
{
    Weekly,
    Monthly,
    Yearly
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Article
{
    public Person Author { get; set; }
    public string Title { get; set; }
    public double Rating { get; set; }

    public Article(Person author, string title, double rating)
    {
        Author = author;
        Title = title;
        Rating = rating;
    }

    public Article()
    {
        Author = new Person();
        Title = string.Empty;
        Rating = 0.0;
    }

    public string ToFullString()
    {
        return $"Author: {Author.Name}\nTitle: {Title}\nRating: {Rating}";
    }
}

public class Magazine
{
    private string name;
    private Frequency frequency;
    private DateTime releaseDate;
    private int circulation;
    private Article[] articles;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Frequency Frequency
    {
        get { return frequency; }
        set { frequency = value; }
    }

    public DateTime ReleaseDate
    {
        get { return releaseDate; }
        set { releaseDate = value; }
    }

    public int Circulation
    {
        get { return circulation; }
        set { circulation = value; }
    }

    public Article[] Articles
    {
        get { return articles; }
    }

    public double AverageRating
    {
        get
        {
            if (articles.Length == 0)
                return 0.0;

            double totalRating = 0.0;
            foreach (Article article in articles)
            {
                totalRating += article.Rating;
            }
            return totalRating / articles.Length;
        }
    }

    public Magazine(string name, Frequency frequency, DateTime releaseDate, int circulation)
    {
        Name = name;
        Frequency = frequency;
        ReleaseDate = releaseDate;
        Circulation = circulation;
        articles = new Article[0];
    }

    public Magazine()
    {
        Name = string.Empty;
        Frequency = Frequency.Monthly;
        ReleaseDate = DateTime.Now;
        Circulation = 0;
        articles = new Article[0];
    }

    public void AddArticles(params Article[] newArticles)
    {
        int currentLength = articles.Length;
        int newLength = currentLength + newArticles.Length;
        Array.Resize(ref articles, newLength);

        for (int i = currentLength, j = 0; i < newLength; i++, j++)
        {
            articles[i] = newArticles[j];
        }
    }

    public string ToFullString()
    {
        string articleList = "";
        foreach (Article article in articles)
        {
            articleList += article.ToFullString() + "\n\n";
        }

        return $"Magazine Name: {Name}\nFrequency: {Frequency}\nRelease Date: {ReleaseDate}\nCirculation: {Circulation}\n\nArticles:\n{articleList}";
    }

    public string ToShortString()
    {
        return $"Magazine Name: {Name}\nFrequency: {Frequency}\nRelease Date: {ReleaseDate}\nCirculation: {Circulation}\nAverage Rating: {AverageRating}";
    }
}

public class Program
{
    public static void Main()
    {
        Magazine magazine = new Magazine();
        Console.WriteLine(magazine.ToShortString());

 
        magazine.Name = "yellow press";
        magazine.Frequency = Frequency.Monthly;
        magazine.ReleaseDate = new DateTime(2023, 5, 1);
        magazine.Circulation = 10000;


        Console.WriteLine(magazine.ToShortString()); //ToString в тз не было.

        Person author = new Person { Name = "Ivnov Ivan", Age = 30 };
        Article article1 = new Article(author, "Who killed amogus", 4.5);
        Article article2 = new Article(author, "olga buzova and dom 2", 4.8);

        magazine.AddArticles(article1, article2);


        Console.WriteLine(magazine.ToFullString());

    }
}
