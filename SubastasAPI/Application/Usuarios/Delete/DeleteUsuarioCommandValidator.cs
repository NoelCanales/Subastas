namespace Application.Usuarios.Delete;

public class DeleteUsuarioCommandValidator : AbstractValidator<DeleteUsuarioCommand>
{
    public DeleteUsuarioCommandValidator()
    {
        RuleFor(r => r.Id)
            .NotEmpty();
    }
}