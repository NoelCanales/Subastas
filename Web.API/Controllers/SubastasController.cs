using Application.Subastas.Create;
using Application.Subastas.Update;
using Application.Subastas.GetById;
using Application.Subastas.Delete;
using Application.Subastas.GetAll;
using MediatR;

namespace Web.API.Controllers;

[Route("subastas")]
public class Subastas : ApiController
{
    private readonly ISender _mediator;

    public Subastas(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var subastasResult = await _mediator.Send(new GetAllSubastasQuery());

        return subastasResult.Match(
            subastas => Ok(subastas),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var subastaResult = await _mediator.Send(new GetSubastaByIdQuery(id));

        return subastaResult.Match(
            subasta => Ok(subasta),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSubastaCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            subastaId => Ok(subastaId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSubastaCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("subasta.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            subastaId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeleteSubastaCommand(id));

        return deleteResult.Match(
            subastaId => NoContent(),
            errors => Problem(errors)
        );
    }
}