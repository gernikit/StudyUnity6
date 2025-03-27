using UI;
using VContainer.Unity;

namespace Architecture
{
	public class GamePresenter: IStartable, ITickable
	{
		private readonly HelloWorldService helloWorldService_;
		private readonly Test test_;

		public GamePresenter(HelloWorldService helloWorldService, Test test )
		{
			helloWorldService_ = helloWorldService;
			test_ = test;
		}

		public void Tick( )
		{
			//helloWorldService_.Hello();
		}

		public void Start( )
		{
			test_.Message(  );
		}
	}
}