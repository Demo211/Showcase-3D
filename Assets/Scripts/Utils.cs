using System;

public static class Utils
{
    private static Random s_random = new Random();

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
}
