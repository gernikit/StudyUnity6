using UnityEngine;

public static class GameInitializer
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Initialize( )
    {
        LanguageModel.Instance.Load(  );
    }
}
