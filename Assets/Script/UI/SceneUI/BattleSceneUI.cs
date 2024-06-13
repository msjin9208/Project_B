using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public partial class BattleSceneUI : BaseSceneUI
{
    public override void Init( )
    {
        base.Init( );

        InitCards();
    }
    public override void Enter( )
    {
        base.Enter( );
    }
    public override void Exit( )
    {
        base.Exit( );
    }
    public override void DataReset( )
    {
        base.DataReset( );
    }
    public override void SetActive( bool active )
    {
        base.SetActive( active );
    }
}

/// <summary>
/// Cards
/// </summary>
public partial class BattleSceneUI
{
    [SerializeField] CardUI[]   _cardsUI;

    public UnityAction<int>     SelectCardCb;

    private void InitCards( )
    {
        for(int i = 0; i <  _cardsUI.Length; i++)
        {
            CardUI ui = _cardsUI[i];

            ui.Initialize( );
        }
    }

    public void PlayViewCards( CardStat[] cards )
    {
        for (int i = 0; i < cards.Length; i++) 
        {
            CardUI ui   = _cardsUI[i];
            ui.SelectCB = SelectCardCb;

            ui.ViewCard(cards[i]);
        }
    }
}
