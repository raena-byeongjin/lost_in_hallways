#if UNITY_EDITOR

using UnityEngine;
using System.Collections;
using UnityEditor;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class AssetBundleBuilder
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// ����� ������
	//-------------------------------------------------------------------------------------------------------------------------------
    static void BuildAllAssetBundles( string buildName, BuildTarget buildTarget=(BuildTarget.NoTarget) )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (buildName)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
        // Create the array of bundle build details.
	    //---------------------------------------------------------------------------------------------------------------------------
		AssetBundleBuild[]	buildMap	= new AssetBundleBuild[1];
		(buildMap[0].assetBundleName)	= (buildName)+".unity3d";

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        string[]	sceneAssets			= new string[1];
        (sceneAssets[0])				= "Assets/Scenes/"+(buildName)+".unity";

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        (buildMap[0].assetNames)		= (sceneAssets);

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (buildTarget)==(BuildTarget.NoTarget) )
		{
			(buildTarget)	= (EditorUserBuildSettings.activeBuildTarget);
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		Debug.Log( "Build Scene : "+(buildName)+", Build Target : "+(buildTarget) );
		if( (buildTarget)!=(BuildTarget.NoTarget) )
		{
			BuildPipeline.BuildAssetBundles( "Assets/BuildScene", (buildMap), (BuildAssetBundleOptions.CollectDependencies|BuildAssetBundleOptions.CompleteAssets), (buildTarget) );		
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// ����� ������
	//-------------------------------------------------------------------------------------------------------------------------------
    [MenuItem("Assets/Build Scene")]
    static void BuildAllAssetBundles()
    {
	    //---------------------------------------------------------------------------------------------------------------------------
        // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (Selection.activeObject)!=(null) )
		{
			BuildAllAssetBundles( Selection.activeObject.name );
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    static void ExportResource( BuildTarget buildTarget )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		string path  = EditorUtility.SaveFilePanel( "Save Resource", "d:/Work/", RandPass(), "unity3d" );

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (path.Length)!=(0) )
        {
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Debug.Log( "Build Object : "+(Selection.activeObject)+", Build Target : "+(buildTarget) );

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            Object[]	selection	= Selection.GetFiltered( typeof(Object), (SelectionMode.DeepAssets) );

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            BuildPipeline.BuildAssetBundle( (Selection.activeObject), (selection), (path), (BuildAssetBundleOptions.CollectDependencies|BuildAssetBundleOptions.CompleteAssets), (buildTarget) );

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            (Selection.objects)     = (selection);

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
        }

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    [MenuItem("Assets/Build AssetBundle From Selection")]
    static void ExportResourceAndroid()
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        ExportResource( EditorUserBuildSettings.activeBuildTarget );

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    public static string RandPass( int Length=(20) )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        int         i;

        string      pass    = "";

        string      ch      = "";

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        for( i=0; i<(Length); i++ )
        {
	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            int     r   = Random.Range( (0), (16) );

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            if( (r)<(10) )
            {
                (ch)    = (r.ToString());
            }
            else
            {
                (r)     = 'a'+(r-10);
                (ch)    = System.Convert.ToChar(r).ToString();
            }

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
            (pass)          += (ch);

	        //-----------------------------------------------------------------------------------------------------------------------
	        // -
	        //-----------------------------------------------------------------------------------------------------------------------
        }

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        return (pass);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

#endif

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------