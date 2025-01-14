﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class uiGraphStick : MonoBehaviour
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------	
	public int		date	= (0);
	public float	value	= (0);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------	
	private RectTransform	m_transform		= (null);
	private Image			m_image			= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------	
	void Awake()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(m_transform)	= (transform as RectTransform);
		(m_image)		= (GetComponent(typeof(Image)) as Image);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------	
	public RectTransform Transform()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (m_transform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이미지 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------	
	public Image Image()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (m_image);

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