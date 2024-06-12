using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;
using System;
using UniRx;

/// <summary>
/// Base
/// </summary>
public partial class TurnCore
{
    public TurnCore() 
    {
        _turnStates = new Dictionary<TurnState , BaseTurn>( );

        InitData( );
    }

    private void InitData( )
    {
        _turnCnt    = 0;
        _remainTurn = 10;

        _turnStates.Add( TurnState.Stand    , new TurnStand( ) );
        _turnStates.Add( TurnState.Start    , new TurnStart( ) );
        _turnStates.Add( TurnState.Behavior , new TurnBehavior( ) );
        _turnStates.Add( TurnState.End      , new TurnEnd( ) );

        MoveTo( TurnState.Stand );
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
    private int                             _turnCnt;
    private int                             _remainTurn;
}

/// <summary>
/// Controll Turn
/// </summary>
public partial class TurnCore
{
    public void SwichTurn( BaseCharacter character )
    {
        _turnCharacter = character;
    }

    public void TurnStart( )
    {
        MoveTo( TurnState.Start );
    }

    public void NextTurn( )
    {
        ++_turnCnt;
    }

    private void MoveTo( TurnState state )
    {
        if( _turnStates.TryGetValue( _curState, out var current ) )
        {
            TurnExcute( null );
            current.Exit( );
        }

        _curState = state;

        if( _turnStates.TryGetValue( _curState , out var next ) )
        {
            next.Enter( _turnCharacter );
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