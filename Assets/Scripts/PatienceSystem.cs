using UnityEngine;
using TMPro;

public class PatienceSystem : MonoBehaviour
{
    public float patienceTimer = 40f;
    public float tip;
    public static float totaltip;
    public bool orderCompleated;
    public TextMeshProUGUI text;
    public TextMeshProUGUI tipText;

    void Start()
    {
        tip = 30f;
        totaltip = 0f;
    }

   
    void Update()
    {
        Patience();
        if(orderCompleated)
        {
            CompleteOrder();
        }
    }
    public void Patience()
    {
        tipText.text = ("Tip: " + totaltip);    
        text.text = ("Paciencia: \n"+patienceTimer.ToString("N0"));
        patienceTimer -= Time.deltaTime;
        if(patienceTimer<= 30)
        {
            tip = 20;
        }
        if(patienceTimer<=20)
        {
            tip = 10;
        }
        if(patienceTimer<=0)
        {
            tip = 0;
            patienceTimer = 0;
        }
    }
    public void CompleteOrder()
    {
        patienceTimer = 90f;
        totaltip += tip;
        tip = 30f;
        orderCompleated = false;
    }

}
