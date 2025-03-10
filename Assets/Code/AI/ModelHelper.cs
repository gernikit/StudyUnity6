using System.Collections.Generic;
using Unity.Sentis;
using UnityEngine;

namespace AI
{
	public static class ModelHelper
	{
		public static void DebugModelInput( Model _model )
		{
			List<Model.Input> inputs = _model.inputs;
			Debug.Log( "Model input:" );

			// Loop through each input
			foreach (var input in inputs)
			{
				// Log the name of the input, for example Input3
				Debug.Log(input.name);

				// Log the tensor shape of the input, for example (1, 1, 28, 28)
				Debug.Log(input.shape);
			}
		}

		public static void DebugModelOutputs( Model _model )
		{
			List<Model.Output> outputs = _model.outputs;
			Debug.Log( "Model outputs:" );

			// Loop through each output
			foreach (var output in outputs)
			{
				// Log the name of the output
				Debug.Log(output.name);
			}
		}
	}
}