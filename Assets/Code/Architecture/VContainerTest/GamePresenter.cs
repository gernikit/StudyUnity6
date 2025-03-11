using UI;
using VContainer.Unity;

namespace Architecture
{
	public class GamePresenter: IStartable
	{
		readonly HelloWorldService helloWorldService_;
		readonly HelloScreen helloScreen_;  

		public GamePresenter(HelloWorldService helloWorldService, HelloScreen helloScreen )
		{
			helloWorldService_ = helloWorldService;
			helloScreen_ = helloScreen;
		}

		public void Tick( )
		{
			helloWorldService_.Hello();
		}

		public void Start( )
		{
			helloScreen_.helloButton.clicked += () => helloWorldService_.Hello();
		}
	}
}