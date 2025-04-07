namespace SteeringBehaviour
{
	public static class MovementEntityCreator
	{
		public static SimpleMovementEntity CreateSimpleMovementEntity( SimpleMovementEntityCreationParams _creationParams )
		{
			var entity = new SimpleMovementEntity( );
			entity.Init( _creationParams );
			return entity;
		}
	}
}