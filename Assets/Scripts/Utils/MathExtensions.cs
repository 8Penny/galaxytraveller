using UnityEngine;

namespace Utils
{
    public static class MathExtensions
    {
        public static Vector3[] GeneratePointsOnSphere(int pointsCount, float pointMultiplier)
        {
            var points = new Vector3[pointsCount];

            var inc = Mathf.PI * (3 - Mathf.Sqrt(5));
            var off = 2 / (float) pointsCount;

            for (var pointId = 0; pointId < pointsCount; pointId++)
            {
                var y = pointId * off - 1 + (off / 2);
                var r = Mathf.Sqrt(1 - y * y);
                var phi = pointId * inc;

                var point = new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r);
                points[pointId] = point * pointMultiplier;
            }

            var rnd = new System.Random();
            rnd.Shuffle(points, pointsCount);
            return points;
        }
    }
}