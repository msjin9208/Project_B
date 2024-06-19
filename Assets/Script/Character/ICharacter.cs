using CommonEnum;
using Cysharp.Threading.Tasks;

namespace ICharacter
{
    public interface IStat
    {
        public void SetStat( CharacterStat stat );
    }

    public interface IDamage
    {
        public int OnDamage( int dmg );
        public bool CheckDeath( );
    }

    public interface IBehavior
    {
        public UniTask DoBehavior( AnimationType type );
    }

    public interface IBuff
    {
        public void Buff( );
        public void Debuff( );
    }
}