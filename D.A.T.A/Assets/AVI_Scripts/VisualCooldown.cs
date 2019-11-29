using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualCooldown : MonoBehaviour
{
    Image vCooldown;

    float maxValue;
    float currentValue;
    float percent;

    // Start is called before the first frame update
    void Start()
    {
        vCooldown = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue > 0)
        {
            percent = currentValue / maxValue;
            Debug.Log(percent);
            vCooldown.fillAmount = Mathf.Lerp(0, 1, percent);
            currentValue = currentValue - Time.deltaTime;
        }
        else
        {
            vCooldown.fillAmount = 0;
        }
    }

    public void StartCoolDown(float a_cooldown)
    {
        maxValue = a_cooldown;
        currentValue = a_cooldown;
    }
}
