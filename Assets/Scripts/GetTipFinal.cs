using UnityEngine;
using TMPro;
public class GetTipFinal : MonoBehaviour
{
    public TextMeshProUGUI FinalTip;
    void Start()
    {
        FinalTip.text = PatienceSystem.totaltip.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
