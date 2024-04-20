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

       // RuleFor(r => r.UpdatedAt)
           // .NotEmpty()
            //.MaximumLength(250)
            //.WithName("UpdatedAt");

    }
}