using System;
using System.Numerics;

public static class PointCloud
{
    public static Vector3[] GenerateRandomCube(int numPoints = 500)
    {
        var rand = new Random();
        var points = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            float x = (float)(rand.NextDouble() * 2 - 1);
            float y = (float)(rand.NextDouble() * 2 - 1);
            float z = (float)(rand.NextDouble() * 2 - 1);
            points[i] = new Vector3(x, y, z);
        }

        return points;
    }
}
