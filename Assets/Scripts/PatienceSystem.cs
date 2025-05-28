using UnityEngine;
using TMPro;
using Unity.Android.Gradle;

public class PatienceSystem : MonoBehaviour
{
    public float patienceTimer;
    public float tip;
    public static float totaltip;
    public bool orderCompleated;
    public TextMeshProUGUI text;
    public TextMeshProUGUI tipText;
    int minutes;
    int seconds;

    public ClientController clientController;

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
        //("Paciencia: \n"+patienceTimer.ToString("N0"));
        patienceTimer -= Time.deltaTime;
        minutes = Mathf.FloorToInt(patienceTimer / 60);
        seconds = Mathf.FloorToInt(patienceTimer % 60);

        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (patienceTimer<= 30)
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

            clientController.CompleteOrder();
        }
    }
    public void CompleteOrder()
    {
        patienceTimer = 120f;
        totaltip += tip;
        tip = 30f;
        orderCompleated = false;
    }

}
