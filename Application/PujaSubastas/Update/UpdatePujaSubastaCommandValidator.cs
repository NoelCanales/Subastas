namespace Application.PujaSubastas.Update;

public class UpdatePujaSubastaCommandValidator : AbstractValidator<UpdatePujaSubastaCommand>
{
    public UpdatePujaSubastaCommandValidator()
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
            .WithMessage("La Fecha de Inicio.");
    }

    // Método auxiliar para validar el formato de fecha
    


}
