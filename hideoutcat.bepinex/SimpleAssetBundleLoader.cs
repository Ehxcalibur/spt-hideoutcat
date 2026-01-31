using System.IO;
using UnityEngine;
using BepInEx;

namespace hideoutcat.bepinex
{
    public static class SimpleAssetBundleLoader
    {
        public static AssetBundle LoadAssetBundle(string bundleName)
        {
            // Assuming bundles are in BepInEx/plugins/tarkin/bundles/
            string bundlesPath = Path.Combine(BepInEx.Paths.PluginPath, "tarkin", "bundles");
            string fullPath = Path.Combine(bundlesPath, bundleName);

            if (!File.Exists(fullPath))
            {
                // Try adding .bundle extension if not present, though usually they have no extension or specific one
                if (File.Exists(fullPath + ".bundle"))
                    fullPath += ".bundle";
                else
                {
                    Debug.LogError($"[SimpleAssetBundleLoader] Bundle not found at: {fullPath}");
                    return null;
                }
            }

            AssetBundle bundle = AssetBundle.LoadFromFile(fullPath);
            if (bundle == null)
            {
                Debug.LogError($"[SimpleAssetBundleLoader] Failed to load bundle from: {fullPath}");
            }
            return bundle;
        }
    }
}
