﻿using UnityEngine;

namespace Client.Scripts.Data
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 vector) => new Vector3Data(vector.x, vector.y, vector.z);

        public static Vector3 AsUnityVector(this Vector3Data vectorData) => new Vector3(vectorData.X, vectorData.Y, vectorData.Z);

        public static string ToJson(this object obj) => JsonUtility.ToJson(obj);
        public static T ToDeserialize<T>(this string json) => JsonUtility.FromJson<T>(json);
    }
}