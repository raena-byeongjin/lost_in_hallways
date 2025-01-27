﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 국가 정보를 처리하기 위한 구조체
//-----------------------------------------------------------------------------------------------------------------------------------
[System.Serializable]
public class tagNationStatic : tagAppsItem
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	public object	currency	= (null);	//tagCurrencyStatic

	//-------------------------------------------------------------------------------------------------------------------------------
	// 통화 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagCurrencyStatic Currency()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (currency as tagCurrencyStatic);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
}

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------