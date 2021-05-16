using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public float batterylevel = 100f;
    public Text batteryText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (GetComponent<Light>().enabled)
                GetComponent<Light>().enabled = false;
            else
                GetComponent<Light>().enabled = true;
        }

        if (GetComponent<Light>().enabled)
        {
            Debug.LogFormat("light on - battery level: {0}", batterylevel);
            batterylevel -= Time.deltaTime;
            if (batterylevel < 0)
                batterylevel = 0;
        }
        else
        {
            Debug.LogFormat("light off - battery level: {0}", batterylevel);
            batterylevel += Time.deltaTime;
            if (batterylevel > 100)
                batterylevel = 100;
        }
        GetComponent<Light>().intensity = batterylevel / 100f * 50f;
        
        batteryText.text = $"Battery level: {batterylevel}";
    }
}
