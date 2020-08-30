﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UdonSharpEditor;
using UnityEngine;
using VRC.Udon;

namespace UdonSharp.Serialization
{
    /// <summary>
    /// UdonSharpBehaviour Serialization Context, confusing abbreviation isn't it?
    /// </summary>
    internal static class USBSerializationContext
    {
        public static HashSet<UdonSharpBehaviour> serializedBehaviourSet = new HashSet<UdonSharpBehaviour>();
        public static ProxySerializationPolicy currentPolicy = null;
        public static int currentDepth = 0;
    }

    public class UdonSharpBehaviourSerializer<T> : Serializer<T> where T : UdonSharpBehaviour 
    {
        public UdonSharpBehaviourSerializer(TypeSerializationMetadata typeMetadata)
            : base(typeMetadata)
        {
        }

        public override Type GetUdonStorageType()
        {
            return typeof(UdonBehaviour);
        }

        public override bool HandlesTypeSerialization(TypeSerializationMetadata typeMetadata)
        {
            return typeMetadata.cSharpType == typeof(UdonSharpBehaviour) || typeMetadata.cSharpType.IsSubclassOf(typeof(UdonSharpBehaviour));
        }

        public override void Read(ref T targetObject, IValueStorage sourceObject)
        {
            if (sourceObject.Value == null)
            {
                targetObject = null;
                return;
            }

            if (USBSerializationContext.currentPolicy == null)
                throw new NullReferenceException("Serialization policy cannot be null");
            
            if (USBSerializationContext.currentDepth >= USBSerializationContext.currentPolicy.MaxSerializationDepth)
                return;

            if (targetObject == null)
                targetObject = (T)UdonSharpEditorUtility.GetProxyBehaviour((UdonBehaviour)sourceObject.Value, ProxySerializationPolicy.NoSerialization);

            if (USBSerializationContext.serializedBehaviourSet.Contains(targetObject))
                return;

            USBSerializationContext.serializedBehaviourSet.Add(targetObject);
            USBSerializationContext.currentDepth++;

            try
            {
                UdonSharpBehaviourFormatterEmitter.GetFormatter<T>().Read(ref targetObject, sourceObject);
            }
            finally
            {
                USBSerializationContext.currentDepth--;

                if (USBSerializationContext.currentDepth <= 0)
                {
                    Debug.Assert(USBSerializationContext.currentDepth == 0, "Serialization depth cannot be negative");

                    USBSerializationContext.serializedBehaviourSet.Clear();
                }
            }
        }

        public override void Write(IValueStorage targetObject, in T sourceObject)
        {
            if (sourceObject == null)
            {
                targetObject.Value = null;
                return;
            }

            if (USBSerializationContext.currentPolicy == null)
                throw new NullReferenceException("Serialization policy cannot be null");

            if (USBSerializationContext.currentDepth >= USBSerializationContext.currentPolicy.MaxSerializationDepth)
            {
                targetObject.Value = null;
                return;
            }

            if (USBSerializationContext.serializedBehaviourSet.Contains(sourceObject))
                return;

            USBSerializationContext.serializedBehaviourSet.Add(sourceObject);
            USBSerializationContext.currentDepth++;
            
            try
            {
                UdonBehaviour backingBehaviour = UdonSharpEditorUtility.GetBackingUdonBehaviour(sourceObject);

                if (backingBehaviour)
                {
                    targetObject.Value = backingBehaviour;
                }
                else if (USBSerializationContext.currentPolicy.ChildProxyMode == ProxySerializationPolicy.ChildProxyCreateMode.Create)
                {
                    UdonBehaviour newBehaviour = UdonSharpEditorUtility.ConvertToUdonBehaviours(new UdonSharpBehaviour[] { sourceObject })[0];
                    targetObject.Value = newBehaviour;
                }
                else if (USBSerializationContext.currentPolicy.ChildProxyMode == ProxySerializationPolicy.ChildProxyCreateMode.CreateWithUndo)
                {
                    UdonBehaviour newBehaviour = UdonSharpEditorUtility.ConvertToUdonBehavioursWithUndo(new UdonSharpBehaviour[] { sourceObject })[0];
                    targetObject.Value = newBehaviour;
                }
                else
                {
                    targetObject.Value = null;
                }

                UdonSharpBehaviourFormatterEmitter.GetFormatter<T>().Write(targetObject, sourceObject);
            }
            finally
            {
                USBSerializationContext.currentDepth--;

                if (USBSerializationContext.currentDepth <= 0)
                {
                    Debug.Assert(USBSerializationContext.currentDepth == 0, "Serialization depth cannot be negative");

                    USBSerializationContext.serializedBehaviourSet.Clear();
                }
            }
        }

        protected override Serializer MakeSerializer(TypeSerializationMetadata typeMetadata)
        {
            return (Serializer)System.Activator.CreateInstance(typeof(UdonSharpBehaviourSerializer<>).MakeGenericType(typeMetadata.cSharpType), typeMetadata);
        }
    }
}
