using Conecta.Doa.Application.Presentation.Domain.Core;
using Conecta.Doa.Application.Presentation.Domain.Core.DomainObjects;

namespace Conecta.Doa.Application.Presentation.Domain.Entities;

public class Establishment : Entity
{
    public string CompanyName { get; private set; }
    public string TradingName { get; private set; }
    public CNPJ Document { get; private set; }
    public List<Donation> Donations { get; private set; }
    public string Address { get; private set; }
    public string Phone { get; private set; }
    public string CompamyEmail { get; private set; }

    public Establishment(string companyName, string tradingName, CNPJ document, List<Donation> donations, string address, string phone, string companyEmail)
    {
        CompanyName = companyName;
        TradingName = tradingName;
        Document = document;
        Donations = donations;
        Address = address;
        Phone = phone;
        CompamyEmail = companyEmail;
    }

    public bool HasDonations() => Donations.Count != 0;

    // Adicionar mais comportamentos
}
