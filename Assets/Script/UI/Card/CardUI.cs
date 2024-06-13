using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [SerializeField]Image           _cardBg;
    [SerializeField]TextMeshProUGUI _cardTitle;
    [SerializeField]TextMeshProUGUI _cardSubject;
    [SerializeField]Button          _playBtn;
    [SerializeField]GameObject      _cardBackImg;

    private int     _cardIdx;

    public UnityAction<int> SelectCB;

    public void Initialize(  )
    {
        _cardIdx = 0;

        ViewBack(true);
    }

    public void ViewCard( CardStat card )
    {
        SetCard( card );
        ViewBack(false);

        _playBtn.OnClickAsObservable().TakeUntilDisable(this).Subscribe(l => 
        {
            if( null != SelectCB )
            {
                SelectCB.Invoke(_cardIdx);
            }
        });
    }

    public void ViewBack( bool view )
    {
        _cardBackImg.SetActive( view );
    }

    private void SetCard( CardStat card )
    {
        _cardIdx = card.Index;

        UIUtility.SetText(_cardTitle, card.CardName);
        UIUtility.SetText(_cardSubject, card.CardSubject);
        UIUtility.SetImage(_cardBg, card.BgRes);
    }
}
