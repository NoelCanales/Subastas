using Application.PujaSubastas.Create;
using Application.PujaSubastas.Update;
using Application.PujaSubastas.GetById;
using Application.PujaSubastas.Delete;
using Application.PujaSubastas.GetAll;
using MediatR;

namespace Web.API.Controllers;

[Route("pujasubastas")]
public class PujaSubastas : ApiController
{
    private readonly ISender _mediator;

    public PujaSubastas(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var pujasubastasResult = await _mediator.Send(new GetAllPujaSubastasQuery());

        return pujasubastasResult.Match(
            pujasubastas => Ok(pujasubastas),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var pujasubastaResult = await _mediator.Send(new GetPujaSubastaByIdQuery(id));

        return pujasubastaResult.Match(
            pujasubasta => Ok(pujasubasta),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePujaSubastaCommand command)
    {
        var createResult = await _mediator.Send(command);

        return createResult.Match(
            pujasubastaId => Ok(pujasubastaId),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePujaSubastaCommand command)
    {
        if (command.Id != id)
        {
            List<Error> errors = new()
            {
                Error.Validation("pujasubasta.UpdateInvalid", "The request Id does not match with the url Id.")
            };
            return Problem(errors);
        }

        var updateResult = await _mediator.Send(command);

        return updateResult.Match(
            pujasubastaId => NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteResult = await _mediator.Send(new DeletePujaSubastaCommand(id));

        return deleteResult.Match(
            pujasubastaId => NoContent(),
            errors => Problem(errors)
        );
    }
}