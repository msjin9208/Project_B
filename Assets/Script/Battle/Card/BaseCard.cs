using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseCard : MonoBehaviour, ICard
{
    [SerializeField]Image           _cardBg;
    [SerializeField]TextMeshProUGUI _cardTitle;
    [SerializeField]TextMeshProUGUI _cardSubject;

    public void SetCard( CardStat stat )
    {

    }
}
