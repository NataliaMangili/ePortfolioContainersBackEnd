namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public sealed class ImageGen : Faker<Image>
{
    public ImageGen()
    {
        RuleFor(x => x.Id, f => Guid.NewGuid());
        RuleFor(f => f.Name, f => f.Lorem.Word());
        RuleFor(f =>f.Url, f => f.Image.PicsumUrl());
    }
}