namespace ePortfolioContainers.UnitTests.Core.Domain;

public class ContactTests
{
    private Contact CreateValidContact() => new Contact("http://validlink.com", EContact.instagran, Guid.NewGuid(), "Valid description");

    [Fact]
    public void SetLink_LinkExceedsMaxLength_ThrowsArgumentException()
    {
        // Given: Criamos um contato base válido
        var contact = CreateValidContact();

        // When: Tentamos inserir um link que ultrapassa 200 caracteres
        var longLink = new string('a', 201);
        Action act = () => contact.SetLink(longLink);

        // Then: Esperamos uma ArgumentException
        var exception = Assert.Throws<ArgumentException>(act);
        Assert.Equal("Link cannot exceed 200 characters.", exception.Message);
    }

    [Fact]
    public void SetLink_ValidLink_SetsLinkSuccessfully()
    {
        // Given: Criamos um contato válido
        var contact = CreateValidContact();

        // When: Definimos um link válido
        contact.SetLink("http://newvalidlink.com");

        // Then: Verificamos se o link foi definido corretamente
        Assert.Equal("http://newvalidlink.com", contact.Link);
    }
}

