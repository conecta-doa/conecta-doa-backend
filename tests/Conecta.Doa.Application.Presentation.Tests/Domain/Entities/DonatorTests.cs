using Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;
using Conecta.Doa.Application.Presentation.Domain.Entities;
using Xunit;

namespace Conecta.Doa.Application.Presentation.Domain.Entities
{
    public class DonatorTests
    { 
        [Fact]
        public void AddDonation_ShouldAddDonation_WhenDonationIsNotNull()
        {
            // Arrange
            var donator = new Donator("Maria", new CPF("98765432100"), "maria@email.com", new List<Donation>());
            var donation = new Donation(DonationType.Financial, "", null, null); // Ajuste conforme o construtor real da classe Donation

            // Act
            donator.AddDonations(donation);

            // Assert
            Assert.Single(donator.Donations);
            Assert.True(donator.HasDonations());
        }

        [Fact]
        public void AddDonation_ShouldNotAdd_WhenDonationIsNull()
        {
            // Arrange
            var donator = new Donator("Pedro", new CPF("11122233344"), "pedro@email.com", new List<Donation>());
            var initialCount = donator.Donations.Count;

            // Act
            donator.AddDonations(null);

            // Assert
            Assert.Equal(initialCount, donator.Donations.Count);
        }
        
        [Fact]
        public void HasDonations_WhenDonationsExist_ReturnsTrue()
        {
            // Arrange
            var donation = Donation.Financial(50.00m, "Doação única");
            var donator = new Donator("Maria", new CPF("12345678900"), "maria@email.com", new List<Donation> { donation });

            // Act
            var result = donator.HasDonations();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void HasDonations_WhenNoDonations_ReturnsFalse()
        {
            // Arrange
            var donator = new Donator("João", new CPF("09876543211"), "joao@email.com", new List<Donation>());

            // Act
            var result = donator.HasDonations();

            // Assert
            Assert.False(result);
        }
    }
}