using VContainer.Unity;

namespace Architecture
{
	public class GamePresenter: ITickable
	{
		readonly HelloWorldService helloWorldService_;

		public GamePresenter(HelloWorldService helloWorldService)
		{
			helloWorldService_ = helloWorldService;
		}

		public void Tick( )
		{
			helloWorldService_.Hello();
		}
	}
}