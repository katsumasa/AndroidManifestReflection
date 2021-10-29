using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using UnityEngine;



namespace UTJ.Android.Extensions
{
    public class AndroidManifestReflection
    {
        System.Type mAndroidManifestType;
        System.Type mAndroidXmlDicumentType;
        object mAndroidManifestObject;

       

        public AndroidManifestReflection(string path)
        {
            try
            {
                // public classからUnityEditor.Android.Extensionsのアセンブリを引く
                var assembly = Assembly.GetAssembly(typeof(UnityEditor.Android.ADB));

                // 基底クラスのtypeも取得しておく
                mAndroidXmlDicumentType = assembly.GetType("UnityEditor.AndroidXmlDocument");

                // AndroidManifestのSystem.Typeを取得する
                mAndroidManifestType = assembly.GetType("UnityEditor.AndroidManifest");

                //var androidManifestPath = Path.Combine(path,"src","main", "AndroidManifest.xml");

                mAndroidManifestObject = mAndroidManifestType.GetConstructor(new[] { typeof(string) }).Invoke(new object[] { path });
            } 
            catch(System.Exception e)
            {
                Debug.LogException(e);
            }            
        }


        public string packageName
        {
            get
            {
                var prop = mAndroidManifestType.GetProperty("packageName");
                return (string)prop.GetValue(mAndroidManifestObject);
            }

            set
            {
                var prop = mAndroidManifestType.GetProperty("packageName");
                prop.SetValue(mAndroidManifestObject, value);
            }
        }

        public int versionCode
        {
            get
            {
                var prop = mAndroidManifestType.GetProperty("versionCode");
                return (int)prop.GetValue(mAndroidManifestType);
            }

            set
            {
                var prop = mAndroidManifestType.GetProperty("versionCode");
                prop.SetValue(mAndroidManifestObject, value);
            }
        }

        public void SetInstallLocation(string location)
        {
            var method = mAndroidManifestType.GetMethod("SetInstallLocation");
            method.Invoke(mAndroidManifestObject, new object[] { location});
        }

        public void SetApplicationFlag(string name, bool value)
        {
            var method = mAndroidManifestType.GetMethod("SetApplicationFlag");
            method.Invoke(mAndroidManifestObject,new object[] {name,value});
        }

        public void RemoveApplicationFlag(string name)
        {
            var method = mAndroidManifestType.GetMethod("RemoveApplicationFlag");
            method.Invoke(mAndroidManifestObject, new object[] { name });
        }


        public void SetApplicationBanner(string name)
        {
            var method = mAndroidManifestType.GetMethod("SetApplicationBanner");
            method.Invoke(mAndroidManifestObject, new object[] { name });
        }

        public void AddGLESVersion(string glEsVersion)
        {
            var method = mAndroidManifestType.GetMethod("AddGLESVersion");
            method.Invoke(mAndroidManifestObject, new object[] { glEsVersion });
        }

        public bool SetOrientation(string activity, string orientation)
        {
            var method = mAndroidManifestType.GetMethod("SetOrientation");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity, orientation });
        }

        public bool SetLaunchMode(string activity, string launchMode)
        {
            var method = mAndroidManifestType.GetMethod("SetLaunchMode");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity, launchMode });
        }

        public bool SetMaxAspectRatio(string activity, string maxAspectRatio)
        {
            var method = mAndroidManifestType.GetMethod("SetMaxAspectRatio");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity, maxAspectRatio });
        }

        public bool SetConfigChanges(string activity, string configChanges)
        {
            var method = mAndroidManifestType.GetMethod("SetConfigChanges");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity, configChanges });
        }

        public bool EnableVrMode(string activity)
        {
            var method = mAndroidManifestType.GetMethod("EnableVrMode");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity });
        }

        public bool SetResizableActivity(string activity, bool value)
        {
            var method = mAndroidManifestType.GetMethod("SetResizableActivity");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity ,value });
        }

        public bool SetAndroidNativeUIHWAcceleration(string activity, bool value)
        {
            var method = mAndroidManifestType.GetMethod("SetAndroidNativeUIHWAcceleration");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity, value });
        }

        public bool RenameActivity(string src, string dst)
        {
            var method = mAndroidManifestType.GetMethod("RenameActivity");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { src, dst });
        }

        private bool SetActivityAndroidAttribute(string activity, string name, string val)
        {
            var method = mAndroidManifestType.GetMethod("SetActivityAndroidAttribute",BindingFlags.NonPublic|BindingFlags.Instance);
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { activity,name, val });
        }

        public string GetActivityWithLaunchIntent()
        {
            var method = mAndroidManifestType.GetMethod("GetActivityWithLaunchIntent");
            return (string)method.Invoke(mAndroidManifestObject, null);
        }

        public HashSet<string> GetActivitiesByMetadata(string name, string value)
        {
            var method = mAndroidManifestType.GetMethod("GetActivitiesByMetadata");
            return (HashSet<string>)method.Invoke(mAndroidManifestObject, new object[] { name, value});
        }

        public bool HasLeanbackLauncherActivity()
        {
            var method = mAndroidManifestType.GetMethod("HasLeanbackLauncherActivity");
            return (bool)method.Invoke(mAndroidManifestObject, null);
        }

        public bool AddLeanbackLauncherActivity()
        {
            var method = mAndroidManifestType.GetMethod("AddLeanbackLauncherActivity");
            return (bool)method.Invoke(mAndroidManifestObject, null);
        }

        public bool AddIntentFilterCategory(string category)
        {
            var method = mAndroidManifestType.GetMethod("AddIntentFilterCategory");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { category });
        }


        public bool AddMetaDataToLaunchActivity(string name, string value)
        {
            var method = mAndroidManifestType.GetMethod("AddMetaDataToLaunchActivity");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { name,value });
        }

        public bool AddResourceToLaunchActivity(string name, string resource)
        {
            var method = mAndroidManifestType.GetMethod("AddResourceToLaunchActivity");
            return (bool)method.Invoke(mAndroidManifestObject, new object[] { name, resource });
        }

        public XmlElement AddUsesFeature(string feature, bool required)
        {
            var method = mAndroidManifestType.GetMethod("AddUsesFeature");
            return (XmlElement)method.Invoke(mAndroidManifestObject, new object[] { feature, required });
        }

        public void AddAndroidVrHeadTrackingFeature(int version, bool required)
        {
            var method = mAndroidManifestType.GetMethod("AddAndroidVrHeadTrackingFeature");
            method.Invoke(mAndroidManifestObject, new object[] { version, required });
        }

        public void AddUsesPermission(string permission)
        {
            var methodInfos = mAndroidManifestType.GetMethods();
            foreach (var method in methodInfos)
            {
                if (method.Name == "AddUsesPermission" && method.GetParameters().Length == 1)
                {
                    method.Invoke(mAndroidManifestObject, new object[] { permission });
                    return;
                }
            }
        }

        public void AddUsesPermission(string permission, int maxSdkVersion)
        {
            var methodInfos = mAndroidManifestType.GetMethods();
            foreach (var method in methodInfos)
            {
                if (method.Name == "AddUsesPermission" && method.GetParameters().Length == 2)
                {
                    method.Invoke(mAndroidManifestObject, new object[] { permission, maxSdkVersion });
                    return;
                }
            }
        }

        public void AddSupportsGLTexture(string format)
        {
            var method = mAndroidManifestType.GetMethod("AddSupportsGLTexture");
            method.Invoke(mAndroidManifestObject, new object[] { format });
        }

        public void AddApplicationMetaDataAttribute(string name, string value)
        {
            var method = mAndroidManifestType.GetMethod("AddApplicationMetaDataAttribute");
            method.Invoke(mAndroidManifestObject, new object[] { name,value });
        }

        public void AddIconAttribute(string name)
        {
            var method = mAndroidManifestType.GetMethod("AddIconAttribute");
            method.Invoke(mAndroidManifestObject, new object[] { name });
        }

        public void AddRoundIconAttribute(string name)
        {
            var method = mAndroidManifestType.GetMethod("AddRoundIconAttribute");
            method.Invoke(mAndroidManifestObject, new object[] { name });
        }

        public void OverrideTheme(string theme)
        {
            var method = mAndroidManifestType.GetMethod("OverrideTheme");
            method.Invoke(mAndroidManifestObject, new object[] { theme });
        }

        public string GetIconAttributeValue()
        {
            var method = mAndroidManifestType.GetMethod("GetIconAttributeValue");
            return (string)method.Invoke(mAndroidManifestObject, null);
        }

        public void SetBuildId(string buildId)
        {
            var method = mAndroidManifestType.GetMethod("SetBuildId");
            method.Invoke(mAndroidManifestObject, new object[] { buildId });
        }

        public void SetNotchSupport(bool enabled)
        {
            var method = mAndroidManifestType.GetMethod("SetNotchSupport");
            method.Invoke(mAndroidManifestObject, new object[] { enabled });
        }

        public string Save()
        {
            var methodInfos = mAndroidManifestType.GetMethods();
            for(var i = 0; i < methodInfos.Length; i++)
            {
                if(methodInfos[i].Name == "Save" && methodInfos[i].GetParameters().Length == 0)
                {
                    return (string)methodInfos[i].Invoke(mAndroidManifestObject, null);
                }
            }
            return null;
        }

        public string SaveAs(string path)
        {
            var method = mAndroidManifestType.GetMethod("SaveAs");
            return (string)method.Invoke(mAndroidManifestObject, new object[] { path});
        }

        public bool SetDebuggableActivity(string activity,bool value)
        {
            return SetActivityAndroidAttribute(activity, "debuggable", value ? "true" : "false");
        }
    }
}