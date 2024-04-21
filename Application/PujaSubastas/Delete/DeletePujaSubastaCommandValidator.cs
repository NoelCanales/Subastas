namespace Application.PujaSubastas.Delete;

public class DeletePujaSubastaCommandValidator : AbstractValidator<DeletePujaSubastaCommand>
{
    public DeletePujaSubastaCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}