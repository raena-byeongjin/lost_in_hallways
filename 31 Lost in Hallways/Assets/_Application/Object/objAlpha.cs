﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// -
//-----------------------------------------------------------------------------------------------------------------------------------
public class objAlpha : MonoBehaviour
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	[System.Serializable]
	public class tagData
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public tagAi				ai				= new tagAi();
		public ACTION				StartAction		= (ACTION.NOTHING);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public objMove				move			= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public bool					Destroy			= (false);
		public bool					Blend			= (true);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public List<tagGraphic>		Graphics		= new List<tagGraphic>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public bool					inmove			= (false);
		public float				fAlpha			= (0f);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	private CApp		app			= (null);
	private CPlay		play		= (null);

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Awake()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(this.app)		= (CApp.This);
		(this.play)		= (CPlay.This);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.move)==(null) )	(data.move)		= (GetComponent(typeof(objMove)) as objMove);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Component[]		comArray	= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(comArray)		= GetComponentsInChildren(typeof(Graphic));
		foreach( Graphic graphic in comArray )
		{
			GetList().Add( new tagGraphic(graphic) );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(comArray)		= GetComponentsInChildren(typeof(Shadow));
		foreach( Shadow shadow in comArray )
		{
			GetList().Add( new tagGraphic(shadow) );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		switch( data.StartAction )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 페이드-인
			//-----------------------------------------------------------------------------------------------------------------------
			case (ACTION.IN):
				FadeIn();
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// 페이드-아웃
			//-----------------------------------------------------------------------------------------------------------------------
			case (ACTION.OUT):
				(Ai().fMove)	= (1f);
				FadeOut();
				break;

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
	void Update()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		switch( GetAction() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 페이드-인
			//-----------------------------------------------------------------------------------------------------------------------
			case (ACTION.IN):
				ActionFadeIn();
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// 페이드-아웃
			//-----------------------------------------------------------------------------------------------------------------------
			case (ACTION.OUT):
				ActionFadeOut();
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 페이드-인
	//-------------------------------------------------------------------------------------------------------------------------------
	void ActionFadeIn()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.fAlpha)	= Mathf.Min( (1f), GetAlpha(Time.deltaTime) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( data.Blend )
		{
			Blend( data.fAlpha );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.fAlpha)>=(1) )
		{
			End();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 페이드-아웃
	//-------------------------------------------------------------------------------------------------------------------------------
	void ActionFadeOut()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.fAlpha)	= Mathf.Max( (0f), GetAlpha(-Time.deltaTime) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( data.Blend )
		{
			Blend( data.fAlpha );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.fAlpha)<=(0) )
		{
			End();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 페이드-인을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void FadeIn()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.inmove)	= (false);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		SetAction( ACTION.IN );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( !(enabled) )
		{
			(enabled)	= (true);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 페이드-아웃을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void FadeOut()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.inmove)	= (false);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		SetAction( ACTION.OUT );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( !(enabled) )
		{
			(enabled)	= (true);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 투명 값을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	float GetAlpha( float value )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Move()!=(null) && ( Move().IsAction() || (data.inmove) ) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(data.inmove)	= (true);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (value)<(0) )
			{
				return (1f)-Move().GetLerpValue();
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return Move().GetLerpValue();
		}
		else
		{
			(Ai().fMove)	+= (value);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (Ai().fMove);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 투명 값을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void Blend( float Alpha )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( tagGraphic graphic in GetList() )
		{
			graphic.Alpha( Alpha );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 투명 값을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void End()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		(data.inmove)	= (false);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( data.Destroy )
		{
			GameObject.Destroy( gameObject );
		}
		else
		{
			if( Move()==(null) || !Move().IsAction() )
			{
				SetAction( ACTION.NOTHING );
				(enabled)	= (false);
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 움직임을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void SetAction( ACTION Action )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		SetAction( Ai(), (Action) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 움직임을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void SetAction( tagAi ai, ACTION Action )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (ai)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ai.SetAction( Action );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// AI 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagAi Ai()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.ai);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 움직임을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public ACTION GetAction()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return GetAction( Ai() );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 움직임을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	ACTION GetAction( tagAi ai )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (ai)==(null) ) return (ACTION.NOTHING);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (ACTION)(ai.Action);
	}

    //-------------------------------------------------------------------------------------------------------------------------------
    // 이동 객체를 얻기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	objMove Move()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.move);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

    //-------------------------------------------------------------------------------------------------------------------------------
    // 알파 값을 얻기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	public float Get()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.fAlpha);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<tagGraphic> GetList()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (data.Graphics);

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