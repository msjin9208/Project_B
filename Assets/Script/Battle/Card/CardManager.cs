using System.Collections.Generic;
using UnityEngine;
using System;
using CommonEnum;
using System.Data;

/// <summary>
/// Singleton
/// </summary>
public partial class CardManager
{
    static private CardManager _instance;
    static public CardManager Instance
    {
        get
        {
            if( null == _instance )
            {
                _instance = new CardManager( );
                _instance.Initialize( );
            }

            return _instance;
        }
    }

    private void Initialize( )
    {
        _cardData = new Dictionary<int , CardStat>( );

        AddCardData( "AttackCardData" );
    }
}

/// <summary>
/// Data
/// </summary>
public partial class CardManager
{
    private readonly string             _dataPath = "Cards/Data/";
    private Dictionary<int , CardStat>  _cardData;

    private void AddCardData( string res )
    {
        CardData data       = Resources.Load<CardData>( _dataPath + res );
        CardStat[] stats    = data.CardStats;

        for( int i = 0; i < stats.Length; i++ )
        {
            CardStat stat = stats[i];
            if( _cardData.ContainsKey( stat.Index ) )
            {
                Debug.Log( $"Has Been Stat {stat.Index}" );
                continue;
            }

            _cardData.Add( stat.Index , stat );
        }
    }

    public CardStat GetData( int idx )
    {
        if( _cardData.TryGetValue( idx, out var stat ) )
        {
            return stat;
        }
        else
        {
            return default;
        }
    }
    
    public T GetCard<T>( int idx ) where T : BaseCard
    {
        CardStat stat = GetData( idx );

        Type cardType   = GetCardType( stat.CardType );
        T card          = Activator.CreateInstance( cardType ) as T;

        if( null != card )
        {
            card.SetCard(stat);
        }

        return card;
    }

    private Type GetCardType( CardType type )
    {
        Type temp = null;
        switch( type )
        {
            case CardType.Attack:   temp = typeof( AttackCard ); break;
            case CardType.Defense:  temp = typeof( BaseCard ); break;
            case CardType.Buff:     temp = typeof( BaseCard ); break;
            case CardType.Debuff:   temp = typeof( BaseCard ); break;
            default:
                {
                    Debug.Log( $" Type is not Available {type}" );
                    temp = typeof( BaseCard );
                }
                break;
        }

        return temp;
    }
}