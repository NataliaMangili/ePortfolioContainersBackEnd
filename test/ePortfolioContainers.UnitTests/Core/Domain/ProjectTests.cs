using ePortfolio.Domain.Models.ProjectAggregate;
using ePortfolioContainers.UnitTests.Core.Helpers;

namespace ePortfolioContainers.UnitTests.Core.Domain;

public class ProjectTest
{
    [Fact]
    public void AddTag_ShouldAddTag_WhenTagIsNotAlreadyAdded()
    {
        // Arrange
        var project = GeneratorHelper.CreateProjectGen().Generate();
        var tag1 = GeneratorHelper.CreateTagGen().Generate();
        var tag2 = GeneratorHelper.CreateTagGen().Generate();

        var tagsList = new List<Tag> { tag1, tag2 };

        // Act
        project.AddTags(tagsList);

        // Assert
        Assert.Equal(2, project.ProjectTags.Count); // Verifica se as duas tags foram adicionadas
        Assert.Contains(project.ProjectTags, pt => pt.TagId == tag1.Id); // Verifica se as tags corretas foram adicionadas
        Assert.Contains(project.ProjectTags, pt => pt.TagId == tag2.Id);
    }

    [Fact]
    public void AddTags_ShouldThrowException_WhenTagIsAlreadyAdded()
    {
        // Arrange
        var project = GeneratorHelper.CreateProjectGen().Generate();
        var tag1 = GeneratorHelper.CreateTagGen().Generate();
        var tag2 = GeneratorHelper.CreateTagGen().Generate();

        var tagsList = new List<Tag> { tag1, tag2 };

        project.AddTags(new List<Tag> { tag1 }); // Adiciona Tag1 previamente

        // Act & Assert
        var exception = Assert.Throws<InvalidOperationException>(() => project.AddTags(tagsList));
        Assert.Equal($"Tag with Id {tag1.Id} is already added.", exception.Message);
    }
}
