using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airbar : MonoBehaviour
{
    public Slider airBar;
    // Start is called before the first frame update
    public void SetAir(int airLevel)
    {
        airBar.value = airLevel;
    }
}
