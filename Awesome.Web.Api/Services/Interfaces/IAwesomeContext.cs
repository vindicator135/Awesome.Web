using Awesome.Entities;

namespace Awesome.Web.Api.Services
{
	public interface IAwesomeContext
	{
		AwesomeEntities Context { get; set; }
	}
}