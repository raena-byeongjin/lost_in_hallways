﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//-----------------------------------------------------------------------------------------------------------------------------------
// 네비게이션 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewNavigation : ViewPanel
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
		public Image				back			= (null);
		public objControl			cancel			= (null);
		public uiText				subject			= (null);
		public objAlign				sbjAlign		= (null);
		public objControl			edit			= (null);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public List<ViewPanel>		Panels			= new List<ViewPanel>();

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		public float				HMargin		= (0);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}
	public tagData		data		= new tagData();

    //-------------------------------------------------------------------------------------------------------------------------------
    // 인터페이스를 활성화 하기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	public bool ON( ViewPanel panel, string text, Color textColor, Color backColor, float margin=(0) )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (panel)==(null) ) return false;
		if( (text)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		ViewPanel fore = GetFore();
		if( (fore)!=(null) )
		{
			fore.OutObjectsInactive();
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( !Is(true) && base.ON(data) )
		{
			//---------------------------------------------------------------------------------------------------------------------------
			// -
			//---------------------------------------------------------------------------------------------------------------------------
			(data.sbjAlign)	= (data.subject.GetComponent(typeof(objAlign)) as objAlign);
			if( (data.sbjAlign)!=(null) )
			{
				(data.HMargin)	= (data.sbjAlign.data.HMargin);
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}
		else
		{
			Transform().SetSiblingIndex( panel.Transform().GetSiblingIndex()+(1) );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( !GetList().Contains(panel) )
		{
			GetList().Add( panel );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (backColor)!=new Color() )
		{
			SetBackcolor( backColor );
		}
		else
		{
			SetBackcolor( Func.Color( (32), (46), (69) ) );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( true )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			Subject().Set( text );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (textColor)!=new Color() )
			{
				(data.cancel.Image().color)	= (textColor);
				(Subject().Text().color)	= (textColor);
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (data.sbjAlign)!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (margin)!=(0) )
			{
				(data.sbjAlign.data.HMargin)	= (data.HMargin) + (margin);
			}
			else
			{
				(data.sbjAlign.data.HMargin)	= (data.HMargin);
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			data.sbjAlign.Align();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		Func.Inactive( Edit()._GameObject() );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		panel.OutObjectsActive();

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

    //-------------------------------------------------------------------------------------------------------------------------------
    // 인터페이스를 활성화 하기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	public bool ON( ViewPanel panel, string text )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (panel)==(null) ) return false;
		if( (text)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return ON( (panel), (text), new Color(), new Color() );
	}

    //-------------------------------------------------------------------------------------------------------------------------------
    // 인터페이스를 활성화 하기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	public bool ON( ViewPanel panel, string text, int margin )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (panel)==(null) ) return false;
		if( (text)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return ON( (panel), (text), new Color(), new Color(), (margin) );
	}

    //-------------------------------------------------------------------------------------------------------------------------------
    // 인터페이스를 활성화 하기 위한 함수
    //-------------------------------------------------------------------------------------------------------------------------------
	public void OnEdit()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(Edit()._RectTransform().anchoredPosition)	= new Vector2( (Subject()._RectTransform().anchoredPosition.x)+(Subject().Text().preferredWidth)+(Edit()._RectTransform().sizeDelta.x)*(Edit()._RectTransform().localScale.x)-(20), (Edit()._RectTransform().anchoredPosition.y) );

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		Func.Active( Edit()._GameObject() );

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
		if( Is() && (GetList().Count)<=(0) )
		{
			return base.OFF();
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void OFF( ViewPanel panel )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (panel)==(null) ) return;
		if( (panel)==(this) ) return;	//자기 자신을 비활성화 하고자할 경우, 무한 재귀가 발생하므로, 자기 자신일 경우는 중단함

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		GetList().Remove(panel);

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (app.History.GetList().Count)>(0) )
		{
//			ViewPanel prev = GetList()[GetList().Count-1];
			tagHistory history = app.History.GetForeHistory();
			if( (history)!=(null) )
			{
				history.panel.OnHistory( history );
//				history.panel.ONNAVIGATION();
			}
		}
		else
		{
			OFF();
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스 높이를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public float Height()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( Is() )
		{
			return (_RectTransform().sizeDelta.y);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return (0);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<ViewPanel> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Panels);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스를 확인하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool Is( ViewPanel panel )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (panel)==(null) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( ViewPanel panel0 in GetList() )
		{
			if( (panel0)==(panel) )
			{
				return true;
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 제목 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public uiText Subject()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.subject);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 편집 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objControl Edit()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.edit);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 배경색을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void SetBackcolor( Color color )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.back.color)	= (color);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	ViewPanel GetFore()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (GetList().Count)>(0) )
		{
			return GetList()[GetList().Count-1];
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 취소 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCANCEL( CANCEL Cancel )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 컨트롤 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override bool ONCONTROL( objControl control, CONTROL_ACTION Action, tagFocus focus )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(null) ) return false;

		//---------------------------------------------------------------------------------------------------------------------------
		// 취소 (CANCEL)
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==(data.cancel) && (Action)==(CONTROL_ACTION.SELECT) )
		{
			app.History.Back();
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 편집 (EDIT)
		//---------------------------------------------------------------------------------------------------------------------------
		if( (control)==Edit() && (Action)==(CONTROL_ACTION.SELECT) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( app.Panel.GetFullscreen()!=(null) )
			{
				app.Panel.GetFullscreen().OnNavigationEdit();
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return true;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ONCONTROL( (control), (Action) );
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리소스를 초기화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Unloader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.back)		= (null);
		(data.cancel)	= (null);
		(data.subject)	= (null);
		(data.edit)		= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리소스를 불러오기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void Loader()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		base.Loader( Resources.Load("ApplicationLoader/View/ViewNavigation"), MainUI.Canvas() );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.back)		= (Transform().GetComponent(typeof(Image)) as Image);
		(data.cancel)	= (Func.Get( Transform(), "Cancel" ).GetComponent(typeof(objControl)) as objControl);
		(data.subject)	= (Func.Get( Transform(), "Subject" ).GetComponent(typeof(uiText)) as uiText);
		(data.edit)		= (Func.Get( Transform(), "Edit" ).GetComponent(typeof(objControl)) as objControl);

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