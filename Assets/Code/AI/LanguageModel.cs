using Unity.Sentis;
using UnityEngine;

public class LanguageModel
{
    private static LanguageModel instance_;
    
    public static LanguageModel Instance => instance_ ??= new LanguageModel( );

    public void Load( )
    {
        ModelAsset modelAsset = Resources.Load("AI/ONNXModels/t5-encoder-12") as ModelAsset;
        Model runtimeModel = ModelLoader.Load(modelAsset);
        
        ModelHelper.DebugModelInput( runtimeModel );
        ModelHelper.DebugModelOutputs( runtimeModel );
    }
}