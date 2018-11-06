using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

public class ExportAssetBundles2
{
	[MenuItem ("Assets/Buid_AssetBundle_for_Android")]

	static void ExportResourceAndroid ()
	{
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "android.unity3d");
		if (path.Length != 0) {
			Object[] selection = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
			BuildPipeline.BuildAssetBundle (Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies, BuildTarget.Android);
			Selection.objects = selection;
		}

	}

	[MenuItem ("Assets/Buid_AssetBundle_for_IOS")]

	static void ExportResourceIOS ()
	{ 
		string path = EditorUtility.SaveFilePanel ("Save Resource", "", "New Resource", "iphone.unity3d");
		if (path.Length != 0) {
			Object[] selection = Selection.GetFiltered (typeof(Object), SelectionMode.DeepAssets);
			BuildPipeline.BuildAssetBundle (Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies, BuildTarget.iOS);
			Selection.objects = selection;
		} 
	}
}

#endif