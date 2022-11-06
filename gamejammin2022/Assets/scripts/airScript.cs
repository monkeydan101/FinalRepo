using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class airScript : MonoBehaviour
{
    public Slider slider;

    public void SetAirlevel(float airLevel)
    {
        slider.value = airLevel;
    }



}
