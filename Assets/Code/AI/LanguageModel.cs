using Unity.Sentis;
using UnityEngine;

public class LanguageModel
{
    private static LanguageModel instance_;
    
    public static LanguageModel Instance => instance_ ??= new LanguageModel( );

    private Model runtimeModel_;
    private Worker worker_;

    public void Load( )
    {
        ModelAsset modelAsset = Resources.Load("AI/ONNXModels/t5-encoder-12") as ModelAsset;
        runtimeModel_ = ModelLoader.Load(modelAsset);
        worker_ = new Worker( runtimeModel_, BackendType.CPU );
        Test(  );
    }

    public void Test( )
    {

    }
}