using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonEnum;
using UnityEngine.Events;

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

        InitializeCard( );
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

    public UnityAction<CardStat[]> TurnEndCb;
    
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
        SwichTurn( );

        if( null != TurnEndCb )
        {
            CardStat[] cards = GetCardsWithSuffle( _curTurnCamp );
            TurnEndCb.Invoke( cards );
        }
            
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
        AddCharacterData( Camp.Enemy , 10 , _enemyTrans );
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

/// <summary>
/// Controll Card
/// </summary>
public partial class BattleCore
{
    private List<BaseCard> _cardList;

    private void InitializeCard( )
    {
        _cardList = new List<BaseCard>();

        AddCardData( 1 );
        AddCardData( 2 );
    }

    private void AddCardData( int idx )
    {
        BaseCard card = CardManager.Instance.GetCard( idx );
        if( 0 == card.Index )
        {
            Debug.Log( $"Card Data is not Avavailabe {idx}" );
            return;
        }
        else
        {
            _cardList.Add( card );
        }
    }

    public int[] GetHasCards( Camp camp )
    {
        return default;
    }
       
    public CardStat[] GetCardsWithSuffle( Camp camp )
    {
        CardStat[] cardStats = new CardStat[3];

        CardManager mgr = CardManager.Instance;

        cardStats[0] = mgr.GetData( _cardList[0].Index );
        cardStats[1] = mgr.GetData( _cardList[1].Index );
        cardStats[0] = mgr.GetData( _cardList[0].Index );

        return cardStats;
    }

    private void ShuffleCard( )
    {

    }
}
