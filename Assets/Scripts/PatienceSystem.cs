using UnityEngine;
using TMPro;

public class PatienceSystem : MonoBehaviour
{
    public float patienceTimer = 40f;
    public float tip;
    public float totaltip;
    public bool orderCompleated;
    public TextMeshProUGUI text;

    void Start()
    {
        tip = 30f;
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
        text.text = ("Paciencia: \n"+patienceTimer.ToString("N0"));
        patienceTimer -= Time.deltaTime;
        if(patienceTimer<= 20)
        {
            tip = 20;
        }
        if(patienceTimer<=10)
        {
            tip = 10;
        }
        if(patienceTimer<=0)
        {
            tip = 0;
        }
    }
    public void CompleteOrder()
    {
        patienceTimer = 40f;
        totaltip += tip;
        tip = 30f;
        orderCompleated = false;
    }

}
