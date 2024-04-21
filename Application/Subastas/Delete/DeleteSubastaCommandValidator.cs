namespace Application.Subastas.Delete;

public class DeleteSubastaCommandValidator : AbstractValidator<DeleteSubastaCommand>
{
    public DeleteSubastaCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}