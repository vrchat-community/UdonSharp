
using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Tests
{
    [AddComponentMenu("Udon Sharp/Tests/GenericsTest")]
    public class GenericsTest : UdonSharpBehaviour
    {
        [System.NonSerialized]
        public IntegrationTestSuite tester;

        public void ExecuteTests()
        {
            float[] floatArray = { 1f, 2f };
            floatArray = floatArray.AddElement(3f);

            tester.TestAssertion("Generic variant 1", floatArray.Length == 3 && 
                                                      floatArray[0] == 1f && floatArray[1] == 2f && floatArray[2] == 3f);
            
            int[] intArray = { 1, 2 };
            intArray = intArray.AddElement(3);
            
            tester.TestAssertion("Generic variant 2", intArray.Length == 3 && 
                                                      intArray[0] == 1 && intArray[1] == 2 && intArray[2] == 3);

            UnityEngine.Object[] objects = { gameObject, transform };
            objects = objects.AddElement(this);
            
            tester.TestAssertion("Generic variant 3", objects.Length == 3 && 
                                                      objects[0] == gameObject && objects[1] == transform && objects[2] == this);

            CallUdonGenericMethod();
        }

        void CallUdonGenericMethod()
        {
            //float[] floatArray;
            int[] intArray;
            UnityEngine.Object[] unityEngineObjectArray;

            //floatArray = new float[] { 1f, 2f };
            //while (floatArray[0] == 1f)
            //    VRC.SDKBase.Utilities.ShuffleArray(floatArray);
            //tester.TestAssertion("Call Udon generic method 1", floatArray[0] == 2f);

            intArray = new int[] { 1, 2 };
            while (intArray[0] == 1)
                VRC.SDKBase.Utilities.ShuffleArray(intArray);
            tester.TestAssertion("Call Udon generic method 2", intArray[0] == 2);

            unityEngineObjectArray = new UnityEngine.Object[] { gameObject, transform };
            while (unityEngineObjectArray[0].Equals(gameObject))
                VRC.SDKBase.Utilities.ShuffleArray(unityEngineObjectArray);
            tester.TestAssertion("Call Udon generic method 3", unityEngineObjectArray[0].Equals(transform));
        }
    }

    internal static class GenericMethodClass
    {
        public static T[] AddElement<T>(this T[] array, T item)
        {
            T[] newArray = new T[array.Length + 1];
            Array.Copy(array, newArray, array.Length);
            newArray[array.Length] = item;
            array = newArray;
            return array;
        }
    }
}
