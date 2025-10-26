namespace Infrastructure.Data.Querys;

public static class ComplaintQuerys
{
    public const string InsertComplaintWithPartner = @"INSERT INTO AGD.Complaint (category, description, emailPartner) VALUES (@category, @description, @emailPartner)";
    public const string InsertComplaint = @"INSERT INTO AGD.Complaint (category, description) VALUES (@category, @description)";
}
