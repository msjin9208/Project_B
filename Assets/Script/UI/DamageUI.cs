using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _damageTxt;

    public void PlayDamage( int dmg, bool opposite )
    {
        Color color = _damageTxt.color;
        color.a     = 1;

        _damageTxt.color = color;

        UIUtility.SetText(_damageTxt, dmg.ToString( ));

        gameObject.SetActive(true);
        StartCoroutine(PlayAnimation( opposite ));
    }

    private void DoFade( )
    {
        Color color = _damageTxt.color;

        color.a -= Time.deltaTime;

        _damageTxt.color = color;
    }

    private IEnumerator PlayAnimation( bool opposite )
    {
        float pushX = 2f;
        float pushY = 15f;

        float target = transform.position.y + 100;

        while ( true )
        {
            Vector2 position = transform.position;

            if(position.y > target)
            {
                gameObject.SetActive(false);
                yield break;
            }

            float x = 0;
            if( opposite )
                x = position.x - (pushX * 10f * Time.deltaTime);
            else
                x = position.x + (pushX * 10f * Time.deltaTime);

            float y = position.y + (pushY * 10f * Time.deltaTime);

            transform.position = new Vector3(x, y);

            DoFade();
            yield return null;
        }
    }
}
