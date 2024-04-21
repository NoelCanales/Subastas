namespace Application.Usuarios.Update;
public class UpdateUsuarioCommandValidator : AbstractValidator<UpdateUsuarioCommand>
{
    public UpdateUsuarioCommandValidator()
    {
        RuleFor(r => r.Nombre)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Apellido)
            .NotEmpty()
            .MaximumLength(250)
            .WithName("Apellido");

        RuleFor(r => r.Dui)
            .MaximumLength(10) // Longitud máxima del DUI en El Salvador
            .Matches(@"^\d{8}-\d{1}$") // Patron para validar el formato del DUI
            .WithName("DUI");  

        RuleFor(r => r.Email)
            .NotEmpty()
            .MaximumLength(250)
            .EmailAddress() // Validar que el campo sea una dirección de correo electrónico válida
            .WithName("Email");  

        RuleFor(r => r.Telefono)
            .MaximumLength(8) // Longitud máxima de un número de teléfono 
            .Matches(@"^\d{8}$") // Patron para validar el número de teléfono (8 dígitos)
            .WithName("Telefono");
    }
}
