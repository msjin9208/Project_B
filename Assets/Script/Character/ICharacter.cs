namespace ICharacter
{
    public interface IStat
    {
        public void SetStat( );
    }

    public interface IAttack
    {
        public void Attack( );
        public void Defense( );
    }

    public interface IBuff
    {
        public void Buff( );
        public void Debuff( );
    }
}