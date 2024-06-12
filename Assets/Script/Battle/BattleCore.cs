using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;



/// <summary>
/// Base
/// </summary>
public partial class BattleCore
{
    public BattleCore( )
    {
        _characterDic = new Dictionary<Camp , BaseCharacter>( );

        InitTurn( );
        InitWave( );

        InitCharacterPosition( );
        InitCharacter( );
    }

    public void BattleStart( )
    {
        StartWave( );
        StartTurn( );
    }
}

/// <summary>
/// Controll Wave
/// </summary>
public partial class BattleCore
{
    private int _wave;

    private void InitWave( )
    {
        _wave = 0;
    }

    public void StartWave( )
    {

    }

    public void EndWave( )
    {

    }

    private void NextWave( )
    {
        ++_wave;
    }
}

/// <summary>
/// Controll Turn
/// </summary>
public partial class BattleCore
{
    private TurnCore    _turnCore;
    private Camp        _curTurnCamp;

    public BaseCharacter GetCurCharacter => _characterDic[_curTurnCamp];
    public BaseCharacter GetCharacter( Camp camp ) => _characterDic[camp];
    
    private void InitTurn( )
    {
        _turnCore       = new TurnCore( );
        _curTurnCamp    = Camp.None;
    }

    public void StartTurn( )
    {
        SwichTurn( );

        _turnCore.TurnStart( );
    }

    public void EndTurn( )
    {

    }

    private void SwichTurn( )
    {
        switch( _curTurnCamp )
        {
            case Camp.None:
                {
                    _curTurnCamp = Camp.Ally;
                }
                break;
            case Camp.Ally:
                {
                    _curTurnCamp = Camp.Enemy;
                }
                break;
            case Camp.Enemy:
                {
                    _curTurnCamp = Camp.Ally;
                }
                break;
        }

        BaseCharacter character = GetCurCharacter;

        _turnCore.SwichTurn( character );
    }

    private void NextTurn( )
    {
        
    }
}

/// <summary>
/// Controll Character
/// </summary>
public partial class BattleCore
{
    Transform                               _allyTrans;
    Transform                               _enemyTrans;

    private Dictionary<Camp, BaseCharacter> _characterDic;

    private void InitCharacterPosition( )
    {
        _allyTrans  = GameObject.Find( "Ally" ).transform;
        _enemyTrans = GameObject.Find( "Enemy" ).transform;
    }

    private void InitCharacter( )
    {
        AddCharacterData( Camp.Ally , 1 , _allyTrans );
        AddCharacterData( Camp.Enemy , 2 , _enemyTrans );
    }

    private bool AddCharacterData( Camp camp, int idx, Transform parent )
    {
        BaseCharacter load = CharacterManager.Instance.MakeByCharacter( idx, parent );
        if( null == load )
        {
            return false;
        }
        else
        {

            _characterDic.Add( camp , load );

            return true;
        }
    }
}
