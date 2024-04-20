namespace Application.Usuarios.Create;

public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
{
    public CreateUsuarioCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Apellido)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Apellido");

               RuleFor(r => r.Dui)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Dui");
            
              RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Email"); 

             RuleFor(r => r.Telefono)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Telefono"); 

            RuleFor(r => r.CreatedAt)
            .NotEmpty()
            .WithName("CreatedAT");





       
    }
}