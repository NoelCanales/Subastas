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
            .MaximumLength(10) // Longitud máxima del DUI en El Salvador
            .Matches(@"^\d{8}-\d{1}$") // Patron para validar el formato del DUI
            .WithName("DUI");

        RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(250)
            .EmailAddress() // Validar que el campo sea una dirección de correo electrónico válida
            .WithName("Email");

        RuleFor(r => r.Telefono)
            .NotEmpty()
            .MaximumLength(9) // Longitud máxima de un número de teléfono 
            .Matches(@"^\d{8}$") // Patron para validar el número de teléfono (8 dígitos)
            .WithName("Telefono");
    }
}
