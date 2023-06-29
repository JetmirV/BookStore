namespace Infrastructure.Communication.Common
{
	public interface IGenericRequestBuilder
	{
		Task<TResponseModel> CreateRequest<TResponseModel>(GenericRequestModel model) where TResponseModel : class;
	}
}