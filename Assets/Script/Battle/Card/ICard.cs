
public struct CardInfo
{
    public int      Index;
    public string   CardName;
    public string   CardSubject;
    public string   CardBgRes;
}

namespace ICard
{
    public interface IStat
    {
        public void SetCard( CardStat stat );
    }

    public interface IAttack
    {
        public int Attack( BaseCharacter caster, BaseCharacter target );
    }

    public interface IDefense
    {

    }

    public interface IBuff
    {

    }

    public interface IDebuff
    {

    }
}
