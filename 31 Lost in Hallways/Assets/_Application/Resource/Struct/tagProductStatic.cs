﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 상품 정보를 처리하기 위한 구조체
//-----------------------------------------------------------------------------------------------------------------------------------
[System.Serializable]
public class tagProductStatic : tagAppsItem
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool				industry		= (false);	//반제품
	public bool				retail			= (false);	//소비재

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagSoundStatic	soundstatic		= (null);
	public string			sound			= (null);	//효과음

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------