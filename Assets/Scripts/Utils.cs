
using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public static class Utils
{
    private static System.Random s_random = new System.Random();

    public static float GetRandomFloatInRange(float min, float max)
    {
        float range = max - min;

        return (float)s_random.NextDouble() * range + min;
    }

    public static float GetRandomFloat()
    {
        float offset = 0.5f;
        float normalizer = 2f;

        return (float)(s_random.NextDouble() - offset)*normalizer;
    }

    public static Vector3 GetRandomVectorFlatY()
    {
        return new Vector3(GetRandomFloat(),0, GetRandomFloat());
    }
}
