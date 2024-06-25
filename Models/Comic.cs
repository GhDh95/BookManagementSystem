using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration.Attributes;

namespace BookManagementSystem;

public class Comic
{
    [Name("comic_name")]
    public string ComicName { get; set; }

    [Name("active_years")]
    public string ActiveYears { get; set; }

    [Name("issue_title")]
    public string IssueTitle { get; set; }

    [Name("publish_date")]
    public string PublishDate { get; set; }

    [Name("issue_description")]
    public string IssueDescription { get; set; }

    [Name("penciler")]
    public string Penciler { get; set; }

    [Name("writer")]
    public string Writer { get; set; }

    [Name("cover_artist")]
    public string CoverArtist { get; set; }

    [Name("Imprint")]
    public string Imprint { get; set; }

    [Name("Format")]
    public string Format { get; set; }

    [Name("Rating")]
    public string Rating { get; set; }

    [Name("Price")]
    public string Price { get; set; }

}