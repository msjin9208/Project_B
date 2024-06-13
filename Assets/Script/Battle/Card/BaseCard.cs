using CommonEnum;
using UnityEngine;

public abstract class BaseCard : ICard.IStat
{
    public int          Index { private set; get; }
    public int          Power { private set; get; }
    public int          Defense { private set; get; }
    public int          TickTurn { private set; get; }
    public int          TickValue { private set; get; }
    public CardType     CardType { private set; get; }
    public OnTarget     TargetType { private set; get; }
    public string       Animation { private set; get; }

    public void SetCard( CardStat stat )
    {
        Index       = stat.Index;
        Power       = stat.Power;
        Defense     = stat.Defense;
        TickTurn    = stat.TickTurn;
        TickValue   = stat.TickValue;
        CardType    = stat.CardType;
        TargetType  = stat.TargetType;
        Animation   = stat.Animation;
    }
}