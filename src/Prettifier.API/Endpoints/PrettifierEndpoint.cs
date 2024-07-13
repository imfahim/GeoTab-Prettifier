using FastEndpoints;

namespace Prettifier.API.Endpoints;


public class PrettifierRequest
{
	public double Number { get; set; }
}

public class PrettifierResponse
{
	public string Result { get; set; }
}

public class PrettifierEndpoint : Endpoint<PrettifierRequest, PrettifierResponse>
{
	private readonly Service.Prettifier _prettifier;

	public PrettifierEndpoint(Service.Prettifier prettifier)
	{
		_prettifier = prettifier;
	}

	public override void Configure()
	{
		Verbs(Http.GET);
		Routes("/api/prettify");
		AllowAnonymous();
	}

	public override async Task HandleAsync(PrettifierRequest req, CancellationToken ct)
	{
		var result = _prettifier.Prettify(req.Number);
		await SendAsync(new PrettifierResponse { Result = result }, cancellation: ct);
	}
}

