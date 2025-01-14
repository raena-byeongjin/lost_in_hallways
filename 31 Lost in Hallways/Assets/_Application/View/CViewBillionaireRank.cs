﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-----------------------------------------------------------------------------------------------------------------------------------
// 억만장자 순위를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewBillionaireRank : ViewPanel
{
	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	[System.Serializable]
	public class tagData : _tagData
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public List<uiPerson>		Persons			= new List<uiPerson>();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public decimal				property_max	= (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ON()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
//		bool isChange = Get()!=(business) || !Is(true);
		bool isChange = !Is(true);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( base.ON(data) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
//			ForeBack();
//			app.Canvas.FullscreenScrollViewInit( ScrollView()._RectTransform() );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Indigator( app.Language.Get(TEXT.억만장자_순위를_불러오는_중입니다) );
//			LoveSignalHash.LoadBillionaireRank();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( isChange )
		{
			Fullscreen( new tagHistory() );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 네비게이션을 처리하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void ONNAVIGATION()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewNavigation.ON( (this), app.Language.Get(TEXT.억만장자_순위), Func.Color( (55), (55), (55) ), (Color.white) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스가 전면에 출력되었을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void ONFORE()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewBottom.Fore();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool OFF()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Is(true) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(data.property_max)	= (0);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return base.OFF();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 등록하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Register( tagPerson person )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (person)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiPerson icon = (Func.Create( ScrollView().Content(), (Resources.Load((PATH.UI)+"/ListItem/BillionaireRankListItem") as GameObject) ).GetComponent(typeof(uiPerson)) as uiPerson);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( person );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ValueBehaviour value = (icon.GetComponentInChildren(typeof(ValueBehaviour)) as ValueBehaviour);
		if( (value)!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (person.property)>(data.property_max) )
			{
				(data.property_max)	= (person.property);
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			value.ON( (float)Func.Divide( (person.property), (data.property_max) ) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(icon.Property().text)	= app.Cash.ExchangeToString(person.property);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Func.TextWidthPerfect(icon.Name());
		Func.TextWidthPerfect(icon.Property());

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GetList().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiPerson> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Persons);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 새로고침 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Refresh()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		ScrollView().Init();

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	/*
	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void OnHistory( tagHistory _history )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (_history)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		historyBusiness history = (_history as historyBusiness);
		if( (history)!=(null) )
		{
			ON( history.business );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}
	*/

	//-------------------------------------------------------------------------------------------------------------------------------
	// 취소 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCANCEL( CANCEL Cancel )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Is() )
		{
			return base.ONCANCEL( Cancel );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCONTROL( objControl control, CONTROL_ACTION Action, tagFocus focus )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(null) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 메모리를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Unloader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Loader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		base.Loader( Resources.Load("ApplicationLoader/View/ViewBillionaireRank"), (play.uiCanvas) );

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