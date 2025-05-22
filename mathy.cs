using System;
using System.Numerics;
using System.Drawing;

namespace projection
{
    public static class mathy
    {
        public static Vector3 RotateX(Vector3 v, float angle)
        {
            float rad = angle * (float)Math.PI / 180;
            Matrix4x4 rot = Matrix4x4.CreateRotationX(rad);
            return Vector3.Transform(v, rot);
        }

        public static Vector3 RotateY(Vector3 v, float angle)
        {
            float rad = angle * (float)Math.PI / 180;
            Matrix4x4 rot = Matrix4x4.CreateRotationY(rad);
            return Vector3.Transform(v, rot);
        }

        public static Vector3 RotateZ(Vector3 v, float angle)
        {
            float rad = angle * (float)Math.PI / 180;
            Matrix4x4 rot = Matrix4x4.CreateRotationZ(rad);
            return Vector3.Transform(v, rot);
        }

        public static PointF PerspectiveProject(Vector3 v, float fov = 200, float distance = 5)
        {
            float factor = fov / (distance + v.Z);
            float x = v.X * factor;
            float y = v.Y * factor;
            return new PointF(x, y);
        }
    }
}