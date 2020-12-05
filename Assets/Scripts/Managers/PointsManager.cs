using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Utils;

namespace Managers
{
    public class PointsManager
    {
        public static int freePointsLen => _freePoints.Count;
        private static Stack<Vector3> _freePoints = new Stack<Vector3>();
        private BusyZone[] _busyZones;

        public PointsManager(uint pointsCount, BusyZone[] busyZones)
        {
            _busyZones = busyZones;
            CreateFreePoints(pointsCount);
        }

        public Vector3[] GetRawFreePositions(uint numberOfPoints)
        {
            if (numberOfPoints > freePointsLen)
            {
                return null;
            }

            var points = new Vector3[(int) numberOfPoints];
            var index = 0;
            while (index < numberOfPoints)
            {
                points[index] = _freePoints.Pop();
                ++index;
            }

            return points;
        }

        public Vector3[] GetFreePoints()
        {
            var restCount = freePointsLen;
            var points = new Vector3[restCount];
            var index = 0;
            while (index < restCount)
            {
                points[index] = _freePoints.Pop();
                ++index;
            }

            return points;
        }

        private void CreateFreePoints(uint pointsCount)
        {
            var points = new Vector3[pointsCount];

            var inc = Mathf.PI * (3 - Mathf.Sqrt(5));
            var off = 2 / (float) pointsCount;
            var lastAddedIndex = 0;

            for (var pointId = 0; pointId < pointsCount; pointId++)
            {
                var y = pointId * off - 1 + (off / 2);
                var r = Mathf.Sqrt(1 - y * y);
                var phi = pointId * inc;

                var point = new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r);

                if (IsPointInFreeZone(point))
                {
                    points[lastAddedIndex] = point;
                    lastAddedIndex += 1;
                }
            }
            
            var result = points.Take(lastAddedIndex).ToArray();

            var rnd = new System.Random();
            rnd.Shuffle(result, lastAddedIndex);
            _freePoints = ConvertArrayToStack(result);
        }

        private static Stack<Vector3> ConvertArrayToStack(Vector3[] array)
        {
            var stack = new Stack<Vector3>();
            var arrLength = array.Length;

            var index = 0;
            while (index < arrLength)
            {
                stack.Push(array[index]);
                ++index;
            }

            return stack;
        }

        private bool IsPointInFreeZone(Vector3 point)
        {
            if (_busyZones == null)
            {
                return true;
            }

            foreach (var zone in _busyZones)
            {
                var distance = Vector3.Distance(point, zone.position);
                if (distance < zone.radius)
                {
                    return false;
                }
            }

            return true;
        }
    }
}