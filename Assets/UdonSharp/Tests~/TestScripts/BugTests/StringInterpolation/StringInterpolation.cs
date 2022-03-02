
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Tests
{
    [AddComponentMenu("Udon Sharp/Tests/StringInterpolation")]
    public class StringInterpolation : UdonSharpBehaviour
    {
        [System.NonSerialized]
        public IntegrationTestSuite tester;

        public void ExecuteTests()
        {
            Method();
        }

        public void Method()
        {
            tester.TestAssertion("String interpolation test left", $"{{" == "{");
            tester.TestAssertion("String interpolation test right", $"}}" == "}");
            tester.TestAssertion("String interpolation test 1", $"{{}}{{{{}}}}{{{{{{}}}}}}" == "{}{{}}{{{}}}");
            tester.TestAssertion("String interpolation test 2", $"{"{{}}"}" == "{{}}");
            tester.TestAssertion("String interpolation test 3", $"{$"{{}}"}" == "{}");
        }
    }
}
