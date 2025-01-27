﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//어플리케이션 정보를 처리하기 위한 클래스
public class CBrowserLegacy : BrowserBehaviour
{
	public void Process()
	{
		switch( play.Scene )
		{
			case SCENE.PLAY:
//				app.Game._Action();
				break;
		}
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 왼쪽 버튼을 눌렀을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONLBUTTONDOWN( Vector3 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONLBUTTONDOWN( (point), (touchIndex) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 롤오버 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONLBUTTONUP( Vector3 point )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONLBUTTONUP(point) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 오른쪽 버튼을 눌렀을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONRBUTTONDOWN( Vector3 point )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONRBUTTONDOWN(point) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 오른쪽 버튼을 눌렀을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONRBUTTONUP( Vector3 point )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONRBUTTONUP(point) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 멀티 터치를 처리하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public bool ONMULTI_TOUCH_DOWN( Vector3 point, tagFocus touch )
    {
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (touch)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONMULTI_TOUCH_DOWN( (point), (touch) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return false;
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 멀티 드래그를 처리하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
    public bool ONMULTI_TOUCH_DRAG( Vector3 point, tagFocus touch )
    {
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (touch)==(null) ) return false;

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONMULTI_TOUCH_DRAG( (point), (touch) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

	    //---------------------------------------------------------------------------------------------------------------------------
	    // -
	    //---------------------------------------------------------------------------------------------------------------------------
		return false;
    }

	//-------------------------------------------------------------------------------------------------------------------------------
	// 롤오버 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONROLLOVER( Vector3 point )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONROLLOVER(point) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 드래그 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void ONDRAG( Vector3 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		tagFocus	push		= app.Engine.GetTouch(touchIndex);
		Vector3		prepoint	= new Vector3();
		if( (push)!=(null) )
		{
			(prepoint)	= (push.point);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		while( true )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( app.Panel.ONDRAG( (point), (touchIndex) ) ) break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( ONDRAG_( (point), (touchIndex) ) ) break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			break;
		}

		/*
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (push)!=(null) )
		{
			(push.length)	+= Vector3.Distance( (prepoint), (point) );
			(push.point)	= (point);
		}
		*/

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 드래그 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONDRAG_( Vector2 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
//				if( app.Game.ONDRAG( (point), (touchIndex) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 왼쪽 버튼을 드래그 했을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONDRAG_CONTEXT( Vector3 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		tagFocus	push		= app.Engine.GetTouch(touchIndex);
		Vector3		prepoint	= new Vector3();
		if( (push)!=(null) )
		{
			(prepoint)	= (push.point);
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		while( true )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
//			if( app.Panel.ONDRAG_CONTEXT( (point), (touchIndex) ) ) break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( ONDRAG_CONTEXT_( (point), (touchIndex) ) ) break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			break;
		}

		/*
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		if( (push)!=(null) )
		{
			(push.length)	+= Vector3.Distance( (prepoint), (point) );
			(push.point)	= (point);
		}
		*/

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 오른쪽 버튼 드래그 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONDRAG_CONTEXT_( Vector3 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONDRAG_CONTEXT( (point), (touchIndex) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 마우스 휠 버튼을 드래그 했을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public bool ONDRAG_WHEEL( Vector3 point, TOUCH_INDEX touchIndex )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
				if( app.Game.ONDRAG_WHEEL( (point), (touchIndex) ) ) return true;
				break;

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	public void ONWHEEL( float fWheel )
	{
		switch( play.Scene )
		{
			case SCENE.PLAY:
				if( app.Game.ONWHEEL(fWheel) ) return;
				break;
		}
	}

	//취소 입력에 반응하기 위한 함수
	public override bool ONCANCEL( CANCEL Cancel )
	{
		if( base.ONCANCEL(Cancel) ) return true;
		if( app.Panel.ONCANCEL(Cancel) ) return true;

		return false;
	}

	//엔터 입력에 반응하기 위한 함수
	public override bool ONRETURN()
	{
		if( base.ONRETURN() ) return true;
		if( app.Panel.ONRETURN() ) return true;

		switch( play.Scene )
		{
			//플레이 (PLAY)
			case SCENE.PLAY:
				if( app.Game.ONRETURN() ) return true;
				break;
		}

		return false;
	}

	//삭제 입력에 반응하기 위한 함수
	public bool ONDELETE()
	{
		switch( play.Scene )
		{
			//플레이 (PLAY)
			case SCENE.PLAY:
				if( app.Game.ONDELETE() ) return true;
				break;
		}

		return false;
	}

	//일시정지 입력에 반응하기 위한 함수
	public bool ONPAUSE()
	{
		switch( play.Scene )
		{
			//플레이 (PLAY)
			case SCENE.PLAY:
				break;
		}

		return false;
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 키 입력에 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Key()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		switch( play.Scene )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// 플레이 (PLAY)
			//-----------------------------------------------------------------------------------------------------------------------
			case (SCENE.PLAY):
//				app.Game.Key();
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
	// 모든 인터페이스를 비활성화 하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void AllInterfaceRelease()
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		List<objPanel> Panels = new List<objPanel>();

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		foreach( objPanel panel in app.Panel.GetList() )
		{
			Panels.Add( panel );
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		foreach( objPanel panel in Panels )
		{
			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
			if( panel.ReciveComponent()==(app.ViewWorldMap) ) continue;
			if( panel.ReciveComponent()==(app.ViewTop) ) continue;
			if( panel.ReciveComponent()==(app.ViewBottom) ) continue;
			if( panel.ReciveComponent()==(app.ViewDashboardBusiness) ) continue;

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
			if( panel.ReciveComponent()!=(null) )
			{
				panel.ReciveComponent().OFF();
			}

			//-----------------------------------------------------------------------------------------------------------------------
		    // -
	        //-----------------------------------------------------------------------------------------------------------------------
		}

        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 유저 입력을 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void SetUserInput( bool option )
	{
        //---------------------------------------------------------------------------------------------------------------------------
        // -
        //---------------------------------------------------------------------------------------------------------------------------
		(play.allowUserInput)	= (option);

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