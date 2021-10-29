using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;
using UTJ.Android;


public class AndroidManifestReflectionTest
{
    [Test]
    public void Test()
    {
        string path = "AndroidManifestReflectionSample.xml";       
        string[] files = Directory.GetFiles(@".", path, SearchOption.AllDirectories);
        
        if (File.Exists(files[0]))
        {
            Debug.Log("OK");
        }
        var androidManifest = new AndroidManifestReflection(files[0]);
        androidManifest.SetDebuggableActivity("com.unity3d.player.UnityPlayerActivity", true);
        androidManifest.AddApplicationMetaDataAttribute("com.android.graphics.developerdriver.enable","true");
        var dst = Path.Combine("Temp", "AndroidManifest.xml");
        androidManifest.SaveAs(dst);
    }


}
