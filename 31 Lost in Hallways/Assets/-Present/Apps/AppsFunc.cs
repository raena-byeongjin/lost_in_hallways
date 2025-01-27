﻿using UnityEngine;
using System;
using System.Collections;
using System.IO;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class AppsFunc
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
    public static int[] EncodeBit   = new int[4];

	//-------------------------------------------------------------------------------------------------------------------------------
	// 데이타를 암호화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static byte[] encode( byte[] bytes )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        if( (bytes)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        for( int i=0; i<(bytes.Length); i++ )
        {
            (bytes[i])	= encode( (bytes[i]), (i) );
        }

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (bytes);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 데이타를 암호화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static byte encode( byte value, int index )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		return (byte)( (value) ^ (EncodeBit[0]^index) ^ (EncodeBit[1]^index) ^ (EncodeBit[2]^index) ^ (EncodeBit[3]^index) );
		return (byte)( (value) ^ EncodeBit[0] ^ EncodeBit[1] ^ EncodeBit[2] ^ EncodeBit[3] );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
    }
	
	//-------------------------------------------------------------------------------------------------------------------------------
	// 암호화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static string encode( string text )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        if( (text)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        byte[]      bytes   = System.Text.Encoding.ASCII.GetBytes( text.ToCharArray() );
 
        string      result  = "";

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        for( int i=0; i<(bytes.Length); i++ )
        {
            sbyte   n       = Convert.ToSByte( bytes[i] );            
            (result)        += DecToHex((n) ^ (EncodeBit[0]) ^ (EncodeBit[1]) ^ (EncodeBit[2]) ^ (EncodeBit[3]));
        }

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (result);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 복호화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static string decode( string text )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        if( (text)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        int             i;
 
        string          result  = "";

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        for( i=0; i<(text.Length); i+=(2) )
        {
		    //-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
            string      ch  = text.Substring( (i), Mathf.Min((2), (text.Length-i)) );

		    //-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
            int         n   = HexToDec(ch) ^ (EncodeBit[0]) ^ (EncodeBit[1]) ^ (EncodeBit[2]) ^ (EncodeBit[3]);

		    //-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
            (result)    += System.Text.Encoding.UTF8.GetString( BitConverter.GetBytes(n) ).Substring( (0), (1) );

		    //-----------------------------------------------------------------------------------------------------------------------
		    // -
		    //-----------------------------------------------------------------------------------------------------------------------
        }

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (result);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
    // 10진수를 16진수로 변환하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    static string DecToHex( int value )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        string  result  = "";

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        (result)   += ""+DecToHexByte(value/16);
        (result)   += ""+DecToHexByte(value%16);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (result);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
    // 10진수를 16진수로 변환하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    static string DecToHexByte( int value )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        switch( value )
        {
            case (1):
                return "1";
            case (2):
                return "2";
            case (3):
                return "3";
            case (4):
                return "4";
            case (5):
                return "5";
            case (6):
                return "6";
            case (7):
                return "7";
            case (8):
                return "8";
            case (9):
                return "9";
            case (10):
                return "A";
            case (11):
                return "B";
            case (12):
                return "C";
            case (13):
                return "D";
            case (14):
                return "E";
            case (15):
                return "F";
        }

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return "0";
    }

	//-------------------------------------------------------------------------------------------------------------------------------
    // 16진수를 10진수로 변환하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    static int HexToDecByte( string value )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        switch( value )
        {
            case "1":
                return (1);
            case "2":
                return (2);
            case "3":
                return (3);
            case "4":
                return (4);
            case "5":
                return (5);
            case "6":
                return (6);
            case "7":
                return (7);
            case "8":
                return (8);
            case "9":
                return (9);
            case "A":
                return (10);
            case "B":
                return (11);
            case "C":
                return (12);
            case "D":
                return (13);
            case "E":
                return (14);
            case "F":
                return (15);
        }

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (0);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
    // 16진수를 10진수로 변환하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    static int HexToDec( string code )
    {
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        if( (code)==(null) ) return (0);
        if( (code.Length)<(2) ) return (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        int         result  = (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        (result)    += HexToDecByte( code.Substring( (0), (1) ) ) * (16);
        (result)    += HexToDecByte( code.Substring( (1), (1) ) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
        return (result);
    }

    // 자열을 확인하기 위한 함수
    public static bool IsEquals( object column, string value )
    {
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
        if( (column)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------        
        if( column.ToString()==(value) )
        {
            return true;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
        return false;
    }

	//인코딩 비트를 설정하기 위한 함수
    public static void InitEncodeBit( int bit1, int bit2, int bit3, int bit4 )
    {
        EncodeBit[0] = bit1;
        EncodeBit[1] = bit2;
        EncodeBit[2] = bit3;
        EncodeBit[3] = bit4;
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 로그를 출력하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static void Log( string text )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (text)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( Apps.Data().bLog )
        {
#if UNITY_EDITOR
			Debug.Log( text );
#else
//			(GameObject.FindObjectOfType(typeof(CConfirm)) as CConfirm).ON( text );
#endif
        }

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 애셋번들 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static void GetAssetBundle( tagAssetBundle assetBundle, string text )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (assetBundle)==(null) ) return;
        if( (text)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        AppsParameter col = AppsParameter.Decode(text);
        if( (col)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        GetAssetBundle( (assetBundle), (col) );

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 애셋번들 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static void GetAssetBundle( tagAssetBundle assetBundle, AppsParameter col )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (assetBundle)==(null) ) return;
        if( (col)==(null) ) return;

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        (assetBundle.id)		= col.Get("id");
        (assetBundle.Name)		= col.Get("name");
        (assetBundle.url)		= col.Get("Url");
        (assetBundle.cache)		= col.GetInt("cache");

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( col.Is("AssetBundle") )
        {
            (assetBundle.url)	= col.Get("AssetBundle");
        }

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 문자열을 소셜 객체로 변환하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public static APPS_LINKAGE StringToLinkage( string linkage )
    {
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        if( (linkage)==(null) ) return (APPS_LINKAGE.NOTHING);

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        int         i;

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        for( i=0; i<((int)APPS_LINKAGE.END); i++ )
        {
            if( ((APPS_LINKAGE)i).ToString()==(linkage) )
            {
                return ((APPS_LINKAGE)i);
            }
        }

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
        return (APPS_LINKAGE.NOTHING);
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 편집 에디터에서 실행중인지 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public static bool IsEditor()
	{
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (Application.platform)==(RuntimePlatform.WindowsEditor) )
		{
			return true;
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//텍스쳐 정보를 불러오기 위한 함수
	public static tagTexture Parse( tagTexture texture, string json )
	{
//		if( texture==null ) return null; //(NULL)값을 허용함
		if( !Library.Is(json) ) return null;

		AppsParameter col = AppsParameter.Decode(json);
        if( col==null ) return null;

		if( texture==null )
		{
			texture = new tagTexture();
		}

		ulong cache = col.GetULong("cache");
		if( texture.cache!=cache )
		{
			texture.Update = true;
		}

		texture.oldUrl = texture.url;

		texture.url		= col.Get("Url");
		texture.cache	= cache;
		texture.width	= col.GetInt("width");
		texture.height	= col.GetInt("height");

		if( texture.Update )
		{
			if( Platform.IsEditor() )
			{
				if( Library.Is(texture.oldUrl) && Library.IsFile(CEngine.GetStreamingPath(texture.oldUrl)) )
				{
					Debug.Log( "(StreamingAsset-Delete) "+CEngine.GetStreamingPath(texture.oldUrl) );
					Library.Delete( CEngine.GetStreamingPath(texture.oldUrl) );
				}
			}

			if( Library.IsFile( CEngine.GetCachePath(texture.oldUrl) ) )
			{
#if UNITY_EDITOR
				Debug.Log( "(Cache-Delete) "+CEngine.GetCachePath(texture.oldUrl) );
#endif
				Library.Delete( CEngine.GetCachePath(texture.oldUrl) );
			}
		}

		return texture;
	}

	//애셋번들 정보를 얻기 위한 함수
    public static tagAssetBundle Parse( tagAssetBundle assetBundle, string json )
    {
//		if( assetBundle==null ) return null;	//(NULL)값을 허용함
		if( !Library.Is(json) ) return null;

		if( assetBundle==null )
		{
			assetBundle = new tagAssetBundle();
		}

		AppsParameter col = AppsParameter.Decode(json);
        if( col==null ) return assetBundle;

        return Parse( assetBundle, col );
    }

	//애셋번들 정보를 얻기 위한 함수
    public static tagAssetBundle Parse( tagAssetBundle assetBundle, AppsParameter col )
    {
        if( assetBundle==null ) return null;
        if( col==null ) return null;

		int cache = col.GetInt("cache");
		if( assetBundle.cache!=cache )
		{
			assetBundle.Update = true;
		}

		assetBundle.oldUrl = assetBundle.url;

        assetBundle.id				= col.Get("id");
        assetBundle.Name			= col.Get("name");
        assetBundle.url				= col.Get("Url");
        assetBundle.cache			= cache;
        assetBundle.UnityVersion	= col.Get("UnityVersion");

        if( col.Is("AssetBundle") )
        {
            assetBundle.url = col.Get("AssetBundle");
        }

		if( assetBundle.Update )
		{
			if( Platform.IsEditor() && Library.Is(assetBundle.oldUrl) )
			{
				Debug.Log( "(StreamingAsset-Delete) => "+CEngine.GetStreamingPath( assetBundle.oldUrl, false ) );
				Library.Delete( CEngine.GetStreamingPath( assetBundle.oldUrl, false ) );
			}

			if( Library.IsFile( CEngine.GetCachePath(assetBundle.oldUrl) ) )
			{
#if UNITY_EDITOR
				Debug.Log( "(Cache-Delete) "+CEngine.GetCachePath(assetBundle.oldUrl) );
#endif
				Library.Delete( CEngine.GetCachePath(assetBundle.oldUrl) );
			}
		}

		return assetBundle;
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 업데이트 클래스를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public static UPDATE_CLASS GetUpdateClass( string Class )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (Class)==(null) ) return (UPDATE_CLASS.Nothing);

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		for( int i=0; i<(int)(UPDATE_CLASS.End); i++ )
		{
			if( ((UPDATE_CLASS)i).ToString()==(Class) )
			{
				return (UPDATE_CLASS)(i);
			}
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (UPDATE_CLASS.Nothing);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 업데이트 타입을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public static UPDATE_TYPE GetUpdateType( string type )
	{
	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		if( (type)==(null) ) return (UPDATE_TYPE.Nothing);

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		for( int i=0; i<(int)(UPDATE_TYPE.End); i++ )
		{
			if( ((UPDATE_TYPE)i).ToString()==(type) )
			{
				return (UPDATE_TYPE)(i);
			}
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return (UPDATE_TYPE.Nothing);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------