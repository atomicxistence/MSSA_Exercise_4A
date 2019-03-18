namespace SpaceTrucker.ViewModel
{
	public interface IUserInput
	{
		ActionType AwaitUserKeyResponse(InputRequestType requestType);
		string AwaitUserTypeResponse(int maxStringLength);
	}
}