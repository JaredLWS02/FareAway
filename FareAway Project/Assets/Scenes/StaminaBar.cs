using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;
    private float maxStamina = 1;
    private float curStamina;
    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaBar instance;

    public void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        curStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void useStamina(float amount)
    {
        if(curStamina - amount >=0 )
        {
            curStamina -= amount;
            staminaBar.value = curStamina;
            if(regen != null)
            {
                StopCoroutine(regen);
            }
            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("Not Enoungh Stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(7f);

        while(curStamina < maxStamina)
        {
            curStamina += maxStamina / 7f;
            staminaBar.value = curStamina;
            yield return regenTick;
        }
        regen = null;
    }

}
