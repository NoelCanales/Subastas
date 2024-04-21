namespace Application.PujaSubastas.Create;

public class CreatePujaSubastaCommandValidator : AbstractValidator<CreatePujaSubastaCommand>
{
    public CreatePujaSubastaCommandValidator()
    {
        RuleFor(r => r.SubastaId)
            .NotEmpty()
            .WithMessage("El campo SubastaId es obligatorio.");

        RuleFor(r => r.UsuarioId)
            .NotEmpty()
            .WithMessage("El campo SubastaId es obligatorio.");
    
        RuleFor(r => r.CantidadPuja)
            .NotEmpty()
            .WithMessage("La Cantidad puja es obligatoria.");
            
        RuleFor(r => r.Fecha)    
            .GreaterThan(r => r.Fecha)
            .WithMessage("La Fecha debe ser posterior a la Fecha de Inicio.");
    
    }

    // Método auxiliar para validar el formato de fecha
    private bool BeValidDate(string date)
    {
        return DateTimeOffset.TryParse(date, out _);
    }

}
