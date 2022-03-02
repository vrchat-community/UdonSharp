﻿
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
            tester.TestAssertion("String interpolation 1 arg", $"arg is {1}" == "arg is 1");

            tester.TestAssertion("String interpolation 4 arg", $"args are {1}, {2}, {3}, {4}" == "args are 1, 2, 3, 4");

            tester.TestAssertion("String interpolation 1 left brace", $"One left brace \"{{\"" == "One left brace \"{\"");

            tester.TestAssertion("String interpolation 1 right brace", $"One right brace \"}}\"" == "One right brace \"}\"");

            tester.TestAssertion("String interpolation multi braces", $"{{1}}, {{{{2}}}}, {{{{{{3}}}}}}" == "{1}, {{2}}, {{{3}}}");

            tester.TestAssertion("String interpolation nests", $"{{{$"{{{$"{{{"nests"}}}"}}}"}}}" == "{{{nests}}}");

            tester.TestAssertion("String interpolation alignment clause", $"{12345,6}" == " 12345");

            tester.TestAssertion("String interpolation format clause", $"{12345:D06}" == "012345");

            tester.TestAssertion("String interpolation alignment & format clause", $"{12345,7:D06}" == " 012345");

            tester.TestAssertion("String interpolation empty", $"" == string.Empty);

            tester.TestAssertion("String interpolation null", $"{null}" == string.Empty);

            tester.TestAssertion("String interpolation pattern to watch out for 1", $"{{{{{12345:D06}}}}}" == "{{D123456}}");
            tester.TestAssertion("String interpolation pattern to watch out for 2", $"{{{{{12345,7:D06}}}}}" == "{{D123456}}");
        }
    }
}
