using System.Collections.Generic;

public class Wave
{
    public Dictionary<string, int> Setup = new Dictionary<string, int>();

    public Wave()
    {

    }

    public Wave(string typeName, int amount)
    {
        Setup.Add(typeName, amount);
    }

    public void AddEnemiesInWave(string typeName, int amount)
    {
        Setup.Add(typeName, amount);
    }
}
