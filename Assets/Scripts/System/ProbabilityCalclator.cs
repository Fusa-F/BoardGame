using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProbabilityCalclator
{
    public static bool Probability(float percent)
    {
        float rate = Random.value * 100f;

        if(percent == 100f && rate == percent)
        {
            return true;
        }
        else if(rate < percent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
