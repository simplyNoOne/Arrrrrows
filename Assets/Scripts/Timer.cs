using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Image Fill;

   
    public float duration;

    private float timeLeft;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = duration;
        StartCoroutine(UpdateTimer());
    }


    private IEnumerator UpdateTimer()
    {
        while(timeLeft > 0.03f)
        {
            Fill.fillAmount = Mathf.InverseLerp(0, duration, timeLeft);
            timeLeft -= 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        TimeOut();
    } 

    private void TimeOut()
    {
        Menu.ToMenu();
    }
}
