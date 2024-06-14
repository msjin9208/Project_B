using CommonEnum;
using UnityEngine;

[System.Serializable]
public struct CardStat
{
    public int              Index;
    public int              Power;
    public int              Defense;
    public int              TickTurn;
    public int              TickValue;
    public string           CardName;
    public string           CardSubject;
    public CardType         CardType;
    public OnTarget         TargetType;
    public AnimationType    Animation;
    public string           BgRes;
}

[CreateAssetMenu( fileName = "Card Data" , menuName = "Card/Card Data" , order = int.MaxValue )]
public class CardData : ScriptableObject
{
    [SerializeField]
    CardStat[]          _cardStats;

    public CardStat[] CardStats => _cardStats;
}
