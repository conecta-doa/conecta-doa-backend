using Conecta.Doa.Application.Presentation.Domain.Core;
using Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

namespace Conecta.Doa.Application.Presentation.Domain.Entities;

public class Donator : Entity
{
    public string FullName { get; private set; }
    public CPF Document { get; private set; }
    public string Email { get; private set; }
    public List<Donation> Donations { get; private set; }

    public Donator(string fullName, CPF document, string email, List<Donation> donations)
    {
        FullName = fullName;
        Document = document;
        Email = email;
        Donations = donations;

        Validate();
    }

    public bool HasDonations() => Donations.Count != 0;

    public void AddDonations(Donation? donation)
    {
        if (donation == null)
            return;

        Donations.Add(donation);
    }

    //TODO Adicionar mais comportamentos

    public void Validate()
    {
        Validations.ValidateIfNull(FullName, "O campo Nome Completo não pode estar fazio");
        Validations.ValidateIfNull(Email, "O campo Email não pode estar fazio");
    }
}
