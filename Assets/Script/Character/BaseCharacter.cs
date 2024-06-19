using CommonEnum;
using Cysharp.Threading.Tasks;
using UnityEngine;

public partial class BaseCharacter : MonoBehaviour , ICharacter.IStat
{
    public string           Name { get; protected set; }
    public int              Hp { get; protected set; }
    public int              MaxHp { get; protected set; }
    public int              Power { get; protected set; }
    public int              Defense { get; protected set; }
    public bool             Death { get; protected set; }
    public CharacterType    Type { get; protected set; }


    public virtual void SetStat( CharacterStat stat )
    {
        Name    = stat.Name;
        Hp      = stat.Hp;
        MaxHp   = stat.Hp;
        Power   = stat.Power;
        Defense = stat.Defense;
        Type    = stat.CharacterType;

        InitAnimator( );
    }
}

/// <summary>
/// Animation
/// </summary>
public partial class BaseCharacter
{
    protected Animator _animator;

    private void InitAnimator( )
    {
        if(false == TryGetComponent<Animator>( out _animator ))
        {
            Debug.Log( "Animator is not Available" );
        }
    }

    protected void DoAnimation( AnimationType type )
    {
        _animator.Play(type.ToString());
    }

    protected async UniTask DoAnimationWithWaiting( AnimationType type )
    {
        DoAnimation(type);

        await UniTask.DelayFrame(1);

        float time = _animator.GetCurrentAnimatorStateInfo(0).length;
        
        await UniTask.Delay(System.TimeSpan.FromSeconds(time));

        DoAnimation(AnimationType.Idle);
    }
}