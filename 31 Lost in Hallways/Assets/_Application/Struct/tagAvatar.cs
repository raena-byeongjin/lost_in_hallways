﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 아바타 정보를 처리하기 위한 구조체
//-----------------------------------------------------------------------------------------------------------------------------------
[System.Serializable]
public class tagAvatar
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagAvatarStatic	body		= (null);
	public tagAvatarStatic	face		= (null);
	public tagAvatarStatic	hair		= (null);
	public tagAvatarStatic	kit			= (null);
	public tagAvatarStatic	backcolor	= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool Is()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Apps.Is(body) )
		{
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------