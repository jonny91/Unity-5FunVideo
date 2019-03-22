# 悟饭Video

---

## 文件夹

Android ：Unity-Android 中间层项目

Unity ：测试项目



## Android使用

### plugins文件

| 5FunVideo.aar       | Unity-Android中间层           |
| ------------------- | ----------------------------- |
| AndroidManifest.xml | AndroidManifest文件           |
| gson-2.8.2.jar      | Unity-Android交互传值json解析 |
| mainTemplate        | >= 2017.4 直接打包使用        |
| wufanvideoadlib.aar | 悟饭Video SDK包               |



1. 拷贝5FunVideo.arr、gson-2.8.2.jar、wufanvideoadlib.aar到Unity项目工程 Plugins/Android 文件夹中

2. 参考平台文档配置 AndroidManifest

3. 由于sdk包中包含Android 64位部分，Unity 2017.4之前不支持64位。如果使用的是2017.4之前的版本执行以下操作:

   1. Build的时候 Export Project 

   2. 在导出的Android Studio中的gradle配置 只生成armeabi-v7a

      ```csharp
      android
      {
      		splits {
      
      		// Configures multiple APKs based on ABI.
      		abi {
      
      			// Enables building multiple APKs per ABI.
      			enable true
      
      			// By default all ABIs are included, so use reset() and include to specify that we only
      			// want APKs for x86, armeabi-v7a, and mips.
      
      			// Resets the list of ABIs that Gradle should create APKs for to none.
      			reset()
      
      			// Specifies a list of ABIs that Gradle should create APKs for.
      			include "armeabi-v7a"
      		}
      	}
      }
      ```

4. 如果使用的是2017.4及以上版本 可以不执行以上操作。拷贝mainTemplate.gradle到Plugins/Android下，使用Custom Gradle Template。正常出包即可。

   

   P.S. 使用Unity自定义Gradle打包 确保使用的Unity版本支持生成64位Android ，同时使用的Gradle版本 >= 3.0 

   

   ## 5FunVideo AAR

   Unity Android 中间层: cn.jonny.android.plugin.MainActivity

   如果需要接入其他SDK 自行合并修改.



## IVideo接口

根据不同的平台实现不同处理方式

```csharp
#if UNITY_ANDROID
        _videoPlugin = new WFAdVideoAndroidPlugin();
#elif UNITY_IOS
        _videoPlugin = new WFAdVideoIOSPlugin();
#endif
```

1. IVideo.Init()

2. IVideo.LoadVideoAd(string[] args)

   | args[0] | adPosition   |
   | ------- | ------------ |
   | args[1] | positionName |

3. IVideo.ShowVideoAd(string[] args)

   | args[0] | oUid       |
   | ------- | ---------- |
   | args[1] | adName     |
   | args[2] | adPosition |





具体参数信息参阅平台文档

