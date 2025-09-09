using Conecta.Doa.Application.Presentation.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace Conecta.Doa.Application.Presentation.Tests.Domain.Entities
{
    public class DonatorTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            var fullName = "Joao Silva";
            var cpf = new CPF("12345678999");
            var email = "joao@email.com";
            var donations = new List<Donation>();
            
            // Act
            var donator = new Donator(fullName, cpf, email, donations);
            
            // Assert
            Assert.Equal(fullName, donator.FullName);
            Assert.Equal(cpf, donator.Document);
            Assert.Equal(email, donator.Email);
            Assert.Empty(donator.Donations);
            Assert.False(donator.HasDonations());
        }

        [Fact]
        public void AddDonation_ShouldAddDonation_WhenDonationIsNotNull()
        {
            // Arrange
            var donator = new Donator("Maria", new CPF("98765432100"), "maria@email.com", new List<Donation>());
            var donation = new Donation(); // Ajuste conforme o construtor real da classe Donation
            
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
    }
}
