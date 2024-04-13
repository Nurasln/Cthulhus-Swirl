using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class LightController : MonoBehaviour
{
    [SerializeField] Light2D light2D;
    [SerializeField] float LightSize;
    bool isLightOn = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!isLightOn)
            {
                light2D.intensity = LightSize;
                isLightOn = true;
            }
        }

        else
        {
            light2D.intensity = 0;
        }
    }
}
