using Application.Usuarios.Create;
using Application.Usuarios.Update;
using Application.Usuarios.GetById;
using Application.Usuarios.Delete;
using Application.Usuarios.GetAll;
using MediatR;

namespace Web.API.Controllers;

[Route("usuarios")]
public class Usuarios : ApiController
{
    private readonly ISender _mediator;

    public Usuarios(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usuariosResult = await _mediator.Send(new GetAllUsuariosQuery());

        return usuariosResult.Match(
            usuarios => Ok(usuarios),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuarioResult = await _mediator.Send(new GetUsuarioByIdQuery(id));

        return usuarioResult.Match(
            usuario => Ok(usuario),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUsuarioCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            usuarioId => Ok(usuarioId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUsuarioCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("usuario.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
             usuarioId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteUsuarioCommand(id));

        return deleteResult.Match(
            usuarioId => NoContent(),
            errors => Problem(errors)
        );
    }
}