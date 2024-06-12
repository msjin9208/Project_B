namespace ICharacter
{
    public interface IStat
    {
        public void SetStat( CharacterManager.CharacterStat stat );
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