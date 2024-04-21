namespace Application.Subastas.Create;

public class CreateSubastaCommandValidator : AbstractValidator<CreateSubastaCommand>
{
    public CreateSubastaCommandValidator()
    {
        RuleFor(r => r.ProductoId)
            .NotEmpty()
            .WithMessage("El campo ProductoId es obligatorio.");

        RuleFor(r => r.FechaInicio)
            .NotEmpty()
            .WithMessage("La Fecha de Inicio es obligatoria.")
            
            .WithMessage("La Fecha de Inicio debe ser una fecha válida en formato ISO 8601.");

        RuleFor(r => r.FechaFinal)
            .NotEmpty()
            .WithMessage("La Fecha Final es obligatoria.")
            
            .WithMessage("La Fecha Final debe ser una fecha válida en formato ISO 8601.")
            .GreaterThan(r => r.FechaInicio)
            .WithMessage("La Fecha Final debe ser posterior a la Fecha de Inicio.");

        RuleFor(r => r.Estado)
            .Must(BeValidEstado)
            .WithMessage("El Estado debe ser 'true' (Abierta) o 'false' (Cerrada).");
    }

    // Método auxiliar para validar el formato de fecha
    private bool BeValidDate(string date)
    {
        return DateTimeOffset.TryParse(date, out _);
    }

    // Método auxiliar para validar el estado
    private bool BeValidEstado(bool estado)
    {
        return estado == true || estado == false;
    }
}
