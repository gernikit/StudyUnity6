using UnityEngine;
using UnityEngine.UIElements;

public class UIBotView : MonoBehaviour
{
    private const string EnterButtonName = "EnterButton";
    private const string QueryText = "QueryText";
    

    [SerializeField] private UIDocument document;
    
    private Button enterButton_;
    private TextField queryText_;

    void OnEnable( )
    {
        enterButton_ = document.rootVisualElement.Q<Button>( EnterButtonName );
        queryText_ = document.rootVisualElement.Q<TextField>( QueryText );
        enterButton_.RegisterCallback<ClickEvent>( ClickMessage );
    }

    void ClickMessage( ClickEvent clickEvent )
    {
        Debug.Log( queryText_.value );
    }
}
