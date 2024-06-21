﻿using UnityEngine;

namespace Client.Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vectorData) => new Vector3(vectorData.X, vectorData.Y, vectorData.Z);
    }
}