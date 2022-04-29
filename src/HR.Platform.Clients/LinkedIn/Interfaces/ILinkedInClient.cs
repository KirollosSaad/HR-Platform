using HR.Platform.Clients.LinkedIn.Models;

namespace HR.Platform.Clients.LinkedIn.Interfaces
{
	public interface ILinkedInClient
	{
		Task PostJobAsync(CreateJobRequest jobRequest, CancellationToken cancellationToken = default);
	}
}
