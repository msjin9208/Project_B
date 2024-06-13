using Cysharp.Threading.Tasks;

namespace ICharacter
{
    public interface IStat
    {
        public void SetStat( CharacterStat stat );
    }

    public interface IDamage
    {
        public void OnDamage( int dmg );
        public bool CheckDeath( );
    }

    public interface IBehavior
    {
        public UniTask DoBehavior( );
        public void DoAnimation( string anim );
    }

    public interface IBuff
    {
        public void Buff( );
        public void Debuff( );
    }
}