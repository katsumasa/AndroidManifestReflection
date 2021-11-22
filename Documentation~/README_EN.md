# AndroidManifestReflection

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/katsumasa/AndroidManifestReflection)

Package To edit AndroidManifest.xml in UnityEditor.

## Summary

A package for using private Class`AndroidManifest`included in `UnityEditor.Android.Extensions.dll`via Relfection
You're able to edit AndroidManifest.xml on UnityEditor.
You could also add APIs you desire.

## Operating Environment

Unity2019.4 or higher

## Install

### using git

```:console
git clone https://github.com/katsumasa/AndroidManifestReflection.git
```

### using Unity Package Manager

![image](https://user-images.githubusercontent.com/29646672/136918028-7236dbf2-2b47-4ea2-9390-61ea57b5e107.png)

1. Click the add  button in the status bar.
2. The options for adding packages appear.
3. Select Add package from git URL from the add menu. A text box and an Add button appear.
4. Enter https://github.com/katsumasa/AndroidManifestReflection.git in the text box and click Add.

[Click here for details.](https://docs.unity3d.com/2019.4/Documentation/Manual/upm-ui-giturl.html)

## API Reference

### AndroidManifestReflection

public AndroidManifestReflection(string path)

| Parameter| Explanation|
|:--:|:---:|
| path | AndroidManifest.xml's file path |

#### Description

Create a new AndroidManifestReflection.
Specify the path to AndroidManifest.xml to be modified as an argument.

```:cs
using System.IO;
using UnityEditor.Android;
using UnityEditor.Build;
using UTJ.Android.Extensions;


public class AndroidManifestPost : IPostGenerateGradleAndroidProject
 {
      void IPostGenerateGradleAndroidProject.OnPostGenerateGradleAndroidProject(string path)
      {
          var androidManifest = new AndroidManifestReflection(path);
          var androidManifest = new AndroidManifestReflection(path);
      }

 }
```

### SetDebuggableActivity

public bool SetDebuggableActivity(string activity,bool value)

| Parameter| Description |
|:--:|:---:|
| activity | activity |
| value | Attribute's value |

#### Description

Set the attribute`debuggable`to the specified activiy. 

```:cs
androidManifest.SetDebuggableActivity("com.unity3d.player.UnityPlayerActivity", true);
```

### AddApplicationMetaDataAttribute

public void AddApplicationMetaDataAttribute(string name, string value)

#### Description

| Parameter | Description |
|:--:|:---:|
| name | Name that represents an item of arbitrary data　|
| value | Data's value |

#### Description

Sets any additional data fields and values ​​that can be provided to the parent component.

```:cs
androidManifest.AddApplicationMetaDataAttribute("com.android.graphics.developerdriver.enable", "true");
```

### Save

public void Save()

##### Description

Write the changed contents back to AndroidManifest.xml.

## Other

Appreciate your comments and feedback.

Tha'll be all

## _Katsumasa Kimura：katsumasa@unity3d.com_
