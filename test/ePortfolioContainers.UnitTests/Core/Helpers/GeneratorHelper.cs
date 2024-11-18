using ePortfolioContainers.UnitTests.Core.Helpers.Generator;

namespace ePortfolioContainers.UnitTests.Core.Helpers;

public static class GeneratorHelper
{
    public static EducationGen CreateEducationGen() => new();

    public static ImageGen CreateImageGen() => new();

    public static KnowledgeGen CreateKnowledgeGen() => new();

    public static ProjectGen CreateProjectGen() => new();

    public static TagGen CreateTagGen() => new();
}
