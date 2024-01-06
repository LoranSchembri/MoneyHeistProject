using UnityEngine;

public class StealingMechanism : MonoBehaviour
    {
    private bool isStealing = false;
    private float timeSinceTouched = 0.0f;
    private float stealingProgress = 0.0f;
    private float delayBeforeStealing = 3.0f; // Time before stealing starts
    private float timeToReachFullStealing = 15.0f; // Time to reach 100% stealing

    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            isStealing = true;
            // Only reset timeSinceTouched, not stealingProgress
            timeSinceTouched = 0.0f;
            }
        }

    private void OnTriggerExit(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            isStealing = false;
            }
        }

    public float GetStealingProgress()
        {
        return stealingProgress;
        }

    private void Update()
        {
        if (isStealing)
            {
            timeSinceTouched += Time.deltaTime;

            if (timeSinceTouched >= delayBeforeStealing && stealingProgress < 100.0f)
                {
                float stealingRatePerSecond = 100.0f / timeToReachFullStealing;
                stealingProgress += stealingRatePerSecond * Time.deltaTime;
                stealingProgress = Mathf.Min(stealingProgress, 100.0f);
                }
            }
        }
    }