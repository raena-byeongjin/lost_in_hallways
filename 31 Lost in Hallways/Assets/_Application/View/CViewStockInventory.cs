﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 주식 리스트를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class CViewStockInventory : ViewPanel
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
		public List<uiCompany>		Stocks		= new List<uiCompany>();

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
		if( base.ON(data) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			ForeBack();
			Indigator( app.Language.Get(TEXT.주식_정보를_불러오는_중입니다) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
//			LoveSignalHash.LoadStockInventory();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}
		else
		{
			ForeBack();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return base.ON();
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 인터페이스가 전면에 출력되었을 때 반응하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public override void ONFORE()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		app.ViewFinance.ON( (this), (ALIGN.RIGHT_BOTTOM) );

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
			app.ViewFinance.OFF( this );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			GetList().Clear();

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
	// 상품 정보를 등록하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Register( tagCompany company, AppsParameter col )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return;
		if( (col)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		uiCompany icon = Find(company);
		if( (icon)!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( col.GetInt("count")<=(0) )
			{
				Func.Destroy( icon._GameObject() );
				GetList().Remove( icon );
				Refresh();
			}
			else
			{
				icon.Stock().Set( company );
				update( (icon), (company), (col) );
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(icon) = (Func.Create( ScrollView().Content(), (Resources.Load(PATH.UI_STOCK_INVENTORY_ITEM) as GameObject) ).GetComponent(typeof(uiCompany)) as uiCompany);
		if( (icon)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Set( company );
		icon.Stock().Set( company );
		
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		update( (icon), (company), (col) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( app.Company.IsOwner(company) )
		{
			icon.Excute().Active();
		}
		else
		{
			icon.Excute().Inactive();
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GetList().Add( icon );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주식 정보를 업데이트하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void update( uiCompany icon, tagCompany company, AppsParameter col )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (icon)==(null) ) return;
		if( (company)==(null) ) return;
		if( (col)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		icon.Stock().Set( col.GetInt("count"), (company) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 리스트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public List<uiCompany> GetList()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.Stocks);

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
		int	i = (0);
		int nPattern = (0);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (ScrollView().Content().sizeDelta.y)<ScrollView().Height() )
		{
			(nPattern)	= (GetList().Count)%(2);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiCompany icon in GetList() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			if( (i+nPattern)%(2)==(0) )
			{
				(icon.Back().color)	= Func.Color( (32), (46), (69) );
			}
			else
			{
				(icon.Back().color)	= Func.Color( (24), (34), (52) );
			}

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(i)	++;
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주식을 매도하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void funcStockSell( object wParam=(null), object lParam=(null) )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (wParam)==(null) || wParam.GetType()!=typeof(tagCompany) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Indigator( app.Language.Get(TEXT.주식을_거래하는_중입니다) );
//		LoveSignalHash.StockSell( wParam as tagCompany );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 기업 정보를 검색하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	uiCompany Find( tagCompany company )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		foreach( uiCompany icon in GetList() )
		{
			if( icon.Get()==(company) )
			{
				return (icon);
			}
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
		if( Is() )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			GetList().Clear();

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			return base.ONCANCEL( Cancel );
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return false;
	}

	//컨트롤 입력에 반응하기 위한 함수
	public override bool ONCONTROL( objControl control, CONTROL_ACTION Action, tagFocus focus )
	{
		if( control==null ) return false;

		foreach( uiCompany icon in GetList() )
		{
			if( control==icon.Excute() && (Action)==(CONTROL_ACTION.SELECT) )
			{
				if( control!=null )
				{
					app.Confirm.ON( app.Language.Get(TEXT.준비중입니다) );
				}
				else
				if( app.Company.IsOwner(icon.Get()) )
				{
					app.Confirm.ON( Func.Script( app.Language.Get(TEXT.__주식을_매도하시겠습니까), (icon.Get().name) ), (CONFIRM.YESNO), (funcStockSell), icon.Get() );
				}
				else
				{
					app.Confirm.ON( app.Language.Get(TEXT.기업의_소유주만_주식을_거래할_수_있습니다) );
				}

				return true;
			}
			else
			if( control==icon.Control() && Action==CONTROL_ACTION.SELECT )
			{
				app.ViewCompany.ON(icon.Get());
				return true;
			}
		}

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
		base.Loader( Resources.Load("ApplicationLoader/View/ViewGenericList"), (play.uiCanvas) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Text subject = (Func.Get( Transform(), "Subject" ).GetComponentInChildren(typeof(Text)) as Text);
		if( (subject)!=(null) )
		{
			(subject.text)	= app.Language.Get(TEXT.보유_주식);
		}

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