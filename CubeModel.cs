using System.Numerics;

public static class CubeModel
{
    public static Vector3[] Vertices = new Vector3[]
    {
        new Vector3(-1, -1, -1),
        new Vector3( 1, -1, -1),
        new Vector3( 1,  1, -1),
        new Vector3(-1,  1, -1),
        new Vector3(-1, -1,  1),
        new Vector3( 1, -1,  1),
        new Vector3( 1,  1,  1),
        new Vector3(-1,  1,  1)
    };

    public static int[][] Edges = new int[][]
    {
        new[] {0,1}, new[] {1,2}, new[] {2,3}, new[] {3,0},
        new[] {4,5}, new[] {5,6}, new[] {6,7}, new[] {7,4},
        new[] {0,4}, new[] {1,5}, new[] {2,6}, new[] {3,7}
    };
}
