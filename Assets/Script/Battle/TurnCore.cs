using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;
using System;
using UniRx;
using UnityEngine.Events;

/// <summary>
/// Base
/// </summary>
public partial class TurnCore
{
    public TurnCore() 
    {
        InitData( );
    }

    private void InitData( )
    {
        _turnCnt    = 0;
        _remainTurn = 10;
        _curState   = TurnState.None;
        _turnStates = new Dictionary<TurnState, BaseTurn>();

        _turnStates.Add( TurnState.Stand    , new TurnStand( this ) );
        _turnStates.Add( TurnState.Start    , new TurnStart( this ) );
        _turnStates.Add( TurnState.Behavior , new TurnBehavior( this ) );
        _turnStates.Add( TurnState.End      , new TurnEnd( this ) );

        ResetData();
    }
}

/// <summary>
/// Turn Data
/// </summary>
public partial class TurnCore
{
    private Dictionary<TurnState, BaseTurn> _turnStates;
    
    private TurnState                       _curState;
    private IDisposable                     _turnExcute;

    private BaseCharacter                   _turnCharacter;
    private BaseCharacter                   _targetCharacter;
    private BaseCard                        _selectCard;
    private int                             _turnCnt;
    private int                             _remainTurn;

    public TurnState        State => _curState;
    public BaseCharacter    Caster => _turnCharacter;
    public BaseCharacter    Target => _targetCharacter;
    public BaseCard         Card => _selectCard;

    public void ResetData( )
    {
        _turnCharacter      = null;
        _targetCharacter    = null;
        _selectCard         = null;
    }
}

/// <summary>
/// Controll Turn
/// </summary>
public partial class TurnCore
{
    public UnityAction<TurnState> BeforeChangeState;

    public void SetTurnCharacter( BaseCharacter character )
    {
        _turnCharacter = character;
    }

    public void PlayTurn( BaseCard card, BaseCharacter target )
    {
        _selectCard         = card;
        _targetCharacter    = target;

        MoveTo(TurnState.Start);
    }

    public void NextState( )
    {
        TurnState next = _curState + 1;
        if ( next == TurnState.MAX)
        {
            next = TurnState.Stand;
        }

        MoveTo( next );
    }

    private void MoveTo( TurnState state )
    {
        if( _turnStates.TryGetValue( _curState, out var current ) )
        {
            TurnExcute( null );
            current.Exit( );
        }

        _curState = state;

        if (null != BeforeChangeState)
            BeforeChangeState.Invoke(_curState);

        if ( _turnStates.TryGetValue( _curState , out var next ) )
        {
            next.Enter( );
            TurnExcute( next );
        }
    }

    private void TurnExcute( BaseTurn turn )
    {
        if( null == turn )
        {
            if( null != _turnExcute )
            {
                _turnExcute.Dispose( );
            }
        }
        else
        {
            _turnExcute = Observable.EveryUpdate( ).Subscribe( l => turn.Excute( ) );
        }
    }
}