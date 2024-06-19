using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CommonEnum;
using static UnityEngine.GraphicsBuffer;

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
    [SerializeField] GameObject _cardDimmed;

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

/// <summary>
/// State
/// </summary>
public partial class BattleSceneUI
{
    public async UniTask ViewForState( TurnState state )
    {
        switch(state)
        {
            case TurnState.Behavior:
                {
                    _cardDimmed.SetActive(true);
                }
                break;
            default:
                {
                    _cardDimmed.SetActive(false);
                }
                break;
        }
    }
}

/// <summary>
/// Damage
/// </summary>
public partial class BattleSceneUI
{
    [SerializeField] RectTransform _dmgParent;

    public void ViewDamage( Vector2 startPos, int dmg , bool opposite )
    {
        DamageUI load       = Resources.Load<DamageUI>("UIs/DamageUI");
        DamageUI ui         = GameObject.Instantiate(load, _dmgParent);

        if (null == ui)
            return;

        Vector2 position        = Camera.main.WorldToScreenPoint(startPos);
        ui.transform.position   = new Vector2( position.x, position.y + 200 );

        ui.PlayDamage(dmg, opposite);
    }
}
