using System;

[Serializable]
public class MinMaxPair
{
    public MinMaxPair(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public int Min;
    public int Max;
}

public static class Utils
{
    private static Random s_random = new Random();
    public static int GetRandomNumber(int min, int max)
    {
        return s_random.Next(min, max+1);
    }

    public static float GetRandomValue()
    {
        int normalizer = 2;
        float offsetter = -0.5f;
        return (float)s_random.NextDouble() * normalizer + offsetter;
    }

    public static bool IsProcessed(float ratio)
    {
        if(ratio > 1f)
        {
            throw new ArgumentException("Ratio can not be greatet than 1", nameof(ratio));
        }
        else
        {
            return s_random.NextDouble() <= ratio;
        }
    }
}
