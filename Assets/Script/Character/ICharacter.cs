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
        public void OnDamage( int dmg );
        public bool CheckDeath( );
    }

    public interface IBehavior
    {
        public void DoBehavior( AnimationType type );
    }

    public interface IBuff
    {
        public void Buff( );
        public void Debuff( );
    }
}