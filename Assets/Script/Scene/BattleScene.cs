using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class BattleScene : BaseScene
{
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

        _core.PlayCardSuffle    = PlaySuffleCards;
        _core.PlayViewForState  = PlayViewForState;
        _core.PlayDamage        = PlayDamange;
    }

    private void SelectCard( int idx )
    {
        _core.PlayTurn( idx );
    }
}

/// <summary>
/// Controll UI
/// </summary>
public partial class BattleScene
{
    BattleSceneUI _sceneUI = null;

    public override void OnLoadUI( )
    {
        if( _sceneUI == null )
            _sceneUI = MainUI.GetUI<BattleSceneUI>( MainUI.UIType.Battle );

        _sceneUI.SelectCardCb = SelectCard;
    }

    private async void PlayViewForState( CommonEnum.TurnState state )
    {
        await _sceneUI.ViewForState(state);
    }

    private void PlaySuffleCards( CardStat[] cards )
    {
        _sceneUI.PlayViewCards(cards);
    }

    private void PlayDamange( Vector2 startPos, int dmg, bool opposite )
    {
        _sceneUI.ViewDamage(startPos, dmg, opposite);
    }
}