#if XR_MANAGEMENT_3_2_0_OR_NEWER
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEngine.XR.MagicLeap;

using UnityEditor;
using UnityEditor.XR.Management;
using UnityEditor.XR.Management.Metadata;

namespace UnityEditor.XR.MagicLeap
{
    class XRPackage : IXRPackage
    {
        private class MagicLeapPackageMetadata : IXRPackageMetadata
        {
            public string packageName => "Magic Leap Plugin";
            public string packageId => "com.unity.xr.magicleap";
            public string settingsType => "UnityEngine.XR.MagicLeap.MagicLeapSettings";
            public List<IXRLoaderMetadata> loaderMetadata => s_LoaderMetadata;
            private static List<IXRLoaderMetadata> s_LoaderMetadata = new List<IXRLoaderMetadata>() { new MagicLeapLoaderMetadata(), new MagicLeapRemoteLoaderMetadata() };
        }

        private class MagicLeapLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "Magic Leap";
            public string loaderType => "UnityEngine.XR.MagicLeap.MagicLeapLoader";
            public List<BuildTargetGroup> supportedBuildTargets => s_SupportedBuildTargets;
            private static List<BuildTargetGroup> s_SupportedBuildTargets = new List<BuildTargetGroup>() { BuildTargetGroup.Lumin };
        }

        // This loader is the same as the one targetting Lumin except for it's named for the ZI.
        // Since MagicLeap Package includes it's own loader there will be no conflicting assets
        // in user projects.
        private class MagicLeapRemoteLoaderMetadata : IXRLoaderMetadata
        {
            public string loaderName => "Magic Leap Zero Iteration";
            public string loaderType => "UnityEngine.XR.MagicLeap.MagicLeapLoader";
            public List<BuildTargetGroup> supportedBuildTargets => s_SupportedBuildTargets;
            private static List<BuildTargetGroup> s_SupportedBuildTargets = new List<BuildTargetGroup>() { BuildTargetGroup.Standalone };
        }

        private static IXRPackageMetadata s_Metadata => new MagicLeapPackageMetadata();
        public IXRPackageMetadata metadata => s_Metadata;

        public bool PopulateNewSettingsInstance(ScriptableObject obj) => true;
    }
}
#endif