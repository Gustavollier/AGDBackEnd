namespace Infrastructure.Data.Querys;
public static class PartnerQuerys
{
    public const string InsertPartner = @"INSERT INTO AGD.PARTNER(nome, email) VALUES(@nome, @email)";
    public const string DeletePartner = @"DELETE FROM AGD.PARTNER WHERE email = @email";
    public const string GetPartnerByEmail = @"SELECT * FROM AGD.PARTNER WHERE email = @email";
}
