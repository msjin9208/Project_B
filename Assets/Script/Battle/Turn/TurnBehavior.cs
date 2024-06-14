using CommonEnum;
using Cysharp.Threading.Tasks;
using ICard;
using ICharacter;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public partial class TurnBehavior : BaseTurn
{
    public TurnBehavior(TurnCore core) : base(core) { }
    public override async void Enter( )
    {
        base.Enter( );

        Debug.Log( "Enter Behavior" );

        await DoAnimation( );

        _core.NextState();
    }

    public override void Excute( )
    {
        base.Excute( );
    }

    public override void Exit( )
    {
        base.Exit( );

        Debug.Log( "Exit Behavior" );
    }
}

public partial class TurnBehavior
{
    private async UniTask DoAnimation( )
    {
        BaseCharacter caster    = _core.Caster;
        IBehavior behavior      = caster as IBehavior;

        BaseCard card           = _core.Card;

        if( null != behavior )
        {
            await behavior.DoBehavior(card.Animation);
        }

        DoEffect( );
    }

    private void DoEffect( )
    {
        BaseCard card           = _core.Card;
        BaseCharacter caster    = _core.Caster;
        BaseCharacter target    = _core.Target;

        switch(card.CardType)
        {
            case CardType.Attack:
                {
                    IAttack attack = card as IAttack;
                    attack?.Attack( caster, target );
                }
                break;
            case CardType.Defense:
                {

                }
                break;
            case CardType.Buff:
                {

                }
                break;
            case CardType.Debuff:
                {

                }
                break;
        }
    }
}