using UnityEngine;

public class PatienceSystem : MonoBehaviour
{
    public float patienceTimer = 40f;
    public float tip;
    public float totaltip;
    bool orderCompleated;
    void Start()
    {
        tip = 30f;
    }

   
    void Update()
    {
        Patience();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            orderCompleated = true;
        }
        if(orderCompleated)
        {
            CompleteOrder();
        }
    }
    public void Patience()
    {
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
            LostOrder();
        }
    }
    public void CompleteOrder()
    {
        patienceTimer = 40f;
        totaltip += tip;
        tip = 30f;
        orderCompleated = false;
    }
    public void LostOrder()
    {
        Debug.Log("You Lost an order");
        totaltip -= 15f;
        orderCompleated = true;
        
    }
}
