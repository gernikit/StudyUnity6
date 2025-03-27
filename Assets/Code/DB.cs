using System;
using System.Collections.Generic;
using UnityEngine;

namespace DB
{
	[CreateAssetMenu( fileName = "DB", menuName = "DB/DB" )]
	public class DB : ScriptableObject
	{
		public ObjectWithType[] paths;
		public TextAsset textFile;
	}

	[CreateAssetMenu( fileName = "DB", menuName = "DB/Paths" )]
	public class Path : ScriptableObject
	{
		public string value = "Test/";
	}

	[Serializable]
	public class ObjectWithType
	{
		public EType type;
		public Path value;
	}

	public enum EType
	{
		Path
	}
}
