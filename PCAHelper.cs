using System;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace projection
{
    public static class PCAHelper
    {
        public static Matrix<double> ComputeCovarianceMatrix(Vector3[] points)
        {
            int n = points.Length;

           
            var data = Matrix<double>.Build.Dense(n, 3);
            var mean = Vector3.Zero;

            foreach (var pt in points) mean += pt;
            mean /= n;

            for (int i = 0; i < n; i++)
            {
                data[i, 0] = points[i].X - mean.X;
                data[i, 1] = points[i].Y - mean.Y;
                data[i, 2] = points[i].Z - mean.Z;
            }

            // Covariance matrix = (X^T * X) / (n - 1)
            var cov = data.TransposeThisAndMultiply(data) / (n - 1);
            return cov;
        }

        public static Matrix<double> GetEigenvectors(Matrix<double> covMatrix)
        {
            var evd = covMatrix.Evd();
            return evd.EigenVectors;
        }

        public static Vector3[] TransformPoints(Vector3[] points, Matrix<double> eigenvectors)
        {
            var transformed = new Vector3[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                var v = Vector<double>.Build.DenseOfArray(new double[]
                {
                    points[i].X,
                    points[i].Y,
                    points[i].Z
                });

                var result = eigenvectors.TransposeThisAndMultiply(v);

                transformed[i] = new Vector3(
                    (float)result[0],
                    (float)result[1],
                    (float)result[2]
                );
            }

            return transformed;
        }
    }
}
