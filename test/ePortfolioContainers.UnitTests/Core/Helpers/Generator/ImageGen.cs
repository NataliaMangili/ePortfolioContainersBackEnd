namespace ePortfolioContainers.UnitTests.Core.Helpers.Generator;

public sealed class ImageGen : Faker<Image>
{
    public ImageGen()
    {
        RuleFor(f => f.Name, f => f.Lorem.Word());
        RuleFor(f =>f.Path, f => f.System.DirectoryPath());
    }
}