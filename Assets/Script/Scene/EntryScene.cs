using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScene : MonoBehaviour
{
    private void Start( )
    {
        Initialize( );

        AppScene.Move( AppScene.SceneType.Battle );
    }

    private void Initialize( )
    {
        InitScene( );
        InitMainUI( );
    }
  
    private void InitScene( )
    {
        AppScene.Initialize( );
    }

    private void InitMainUI( )
    {
        GameObject go = new GameObject("[MainUI]", typeof( MainUI ));
        DontDestroyOnLoad( go );

        MainUI.Initialize( );
    }
}
