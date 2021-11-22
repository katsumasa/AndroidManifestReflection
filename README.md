# AndroidManifestReflection

![GitHub release (latest SemVer)](https://img.shields.io/github/v/release/katsumasa/AndroidManifestReflection)

Package To edit AndroidManifest.xml in UnityEditor.

## 概要

`UnityEditor.Android.Extensions.dll`に含まれる、非公開Class `AndroidManifest`をReflection経由で利用する為のパッケージです。
UnityEditor上で、AndroidManifest.xmlを編集する事ができます。
また、自分で使う為に必要なAPIを多少追加しています。

## 動作環境

Unity2019.4以上

## インストール

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

| パラメーター | 説明 |
|:--:|:---:|
| path | AndroidManifest.xmlファイルへのパス |

#### 説明

新規にAndroidManifestReflectionを作成します。
引数として、変更を加えるAndroidManifest.xmlへのパスを指定します。

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

| パラメーター | 説明 |
|:--:|:---:|
| activity | アクティビティ |
| value | アトリビュートの値 |

#### 説明

指定されたアクティビティへアトリビュート`debuggable`を設定します。

```:cs
androidManifest.SetDebuggableActivity("com.unity3d.player.UnityPlayerActivity", true);
```

### AddApplicationMetaDataAttribute

public void AddApplicationMetaDataAttribute(string name, string value)

#### 説明

| パラメーター | 説明 |
|:--:|:---:|
| name | 任意のデータの項目を表す名前　|
| value | データーの値 |

#### 説明

親コンポーネントに追加で提供できる任意のデータの項目と値を設定します。

```:cs
androidManifest.AddApplicationMetaDataAttribute("com.android.graphics.developerdriver.enable", "true");
```

### Save

public void Save()

##### 説明

変更を加えた内容をAndroidManifest.xmlへ書き戻します。

## その他

フィードバックやコメントをお待ちしております。

## _木村 勝将：katsumasa@unity3d.com_
