namespace Infrastructure.Data.Querys;
public static class PartnerQuerys
{
    public const string InsertPartner = @"INSERT INTO PARTNER(nome, email) VALUES(@nome, @email)";
}
