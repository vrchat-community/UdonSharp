
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Tests
{
    [AddComponentMenu("Udon Sharp/Tests/BracesInStringInterpolation")]
    public class BracesInStringInterpolation : UdonSharpBehaviour
    {
        [System.NonSerialized]
        public IntegrationTestSuite tester;

        public void ExecuteTests()
        {
            Method();
        }

        public void Method()
        {
            tester.TestAssertion("String interpolation braces escape 1", $"}}, {{}}, {{" == "}, {}, {");

            tester.TestAssertion("String interpolation braces escape 2", $"{{{1}}}, {{{{{2}}}}}, {{{{{{{3}}}}}}}" == "{1}, {{2}}, {{{3}}}");
        }
    }
}
