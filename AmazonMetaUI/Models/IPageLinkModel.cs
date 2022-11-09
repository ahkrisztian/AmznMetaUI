namespace AmazonMetaUI.Models
{
    public interface IPageLinkModel
    {
        string LinkFirst { get; set; }
        string LinkForth { get; set; }
        string LinkSecond { get; set; }
        string LinkThird { get; set; }
        int PageNumber { get; set; }
    }
}