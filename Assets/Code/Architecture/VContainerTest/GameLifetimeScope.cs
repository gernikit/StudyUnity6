using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Architecture
{
	public class GameLifetimeScope : LifetimeScope
	{
		[SerializeField] private HelloScreen helloScreen;
		
		protected override void Configure(IContainerBuilder builder)
		{ 
			builder.Register<HelloWorldService>(Lifetime.Singleton);
			builder.RegisterEntryPoint<GamePresenter>();
			builder.RegisterComponent(helloScreen);
			builder.Register<A>( Lifetime.Scoped );
			builder.Register<Test>( Lifetime.Scoped );
		}
	}

	public class Test
	{
		private A a;
		
		[Inject]
		public Test( A _a )
		{
			a = _a;
			int i = 1;
		}
	}

	public class A
	{
		public string Message( )
		{
			return "message";
		}
	}
}