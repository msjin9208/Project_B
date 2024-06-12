using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class BattleScene : BaseScene
{
    BattleSceneUI _sceneUI = null;

    public override void Init( )
    {
        base.Init( );
    }

    public override void Enter( )
    {
        OnLoadUI( );
        InitBaltte( );

        _core.BattleStart( );
    }

    public override void Exit( )
    {
        base.Exit( );
    }

    public override void OnLoadUI( )
    {
        if( _sceneUI == null )
            _sceneUI = MainUI.GetUI<BattleSceneUI>( MainUI.UIType.Battle );
    }
}

/// <summary>
/// Controll BattleCore
/// </summary>
public partial class BattleScene
{
    BattleCore _core;

    private void InitBaltte( )
    {
        _core = new BattleCore( );
    }
}
