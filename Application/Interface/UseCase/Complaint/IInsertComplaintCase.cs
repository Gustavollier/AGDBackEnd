using Application.ResultPattern;

namespace Application.Interface.UseCase.Complaint;
public interface IInsertComplaintCase
{
    Task<Result> ExecuteAsync(Models.Complaint complaint);
}
