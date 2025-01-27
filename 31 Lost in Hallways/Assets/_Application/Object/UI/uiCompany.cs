﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//-----------------------------------------------------------------------------------------------------------------------------------
// 기업 정보를 처리하기 위한 클래스
//-----------------------------------------------------------------------------------------------------------------------------------
public class uiCompany : MonoBehaviour
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
		public object			company			= (null);
		public object			business		= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public Transform		transform		= (null);
		public GameObject		gameObject		= (null);
		public objControl		control			= (null);
		public Image			back			= (null);
		public RawImage			image			= (null);
		public Text				text			= (null);
		public uiIcon			nation			= (null);
		public uiCity			city			= (null);
		public uiGraph			graph			= (null);
		public uiStock			stock			= (null);
		public Text				label			= (null);
		public objControl		excute			= (null);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		public bool				allowLabel		= (true);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	};
	public tagData		data		= new tagData();

	//-------------------------------------------------------------------------------------------------------------------------------
	// -
	//-------------------------------------------------------------------------------------------------------------------------------
	void Awake()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.transform)		= (transform);
		(data.gameObject)		= (gameObject);
		if( Control()==(null) )	(data.control)	= (GetComponent(typeof(objControl)) as objControl);
		if( Back()==(null) )	(data.back)		= (GetComponent(typeof(Image)) as Image);
		if( Image()==(null) )	(data.image)	= (GetComponentInChildren(typeof(RawImage)) as RawImage);
		if( Text()==(null) )	(data.text)		= (GetComponentInChildren(typeof(Text)) as Text);
		if( Graph()==(null) )	(data.graph)	= (GetComponentInChildren(typeof(uiGraph)) as uiGraph);
		if( Stock()==(null) )	(data.stock)	= (GetComponentInChildren(typeof(uiStock)) as uiStock);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 정보를 설정하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Set( tagCompany company )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		(data.company)	= (company);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Set( company.name );

		//---------------------------------------------------------------------------------------------------------------------------
		// 기업 이미지
		//---------------------------------------------------------------------------------------------------------------------------
		if( Image()!=(null) )
		{
			if( (company.picture)!=(null) && company.picture.IsLoad() )
			{
				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				(Image().texture)	= company.picture.GetTexture();
				(Image().color)		= Func.Color( (Color.white), (Image().color.a) );

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				if( Label()!=(null) )
				{
					Func.Destroy( Label() );
					(data.label) = (null);
				}

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
			}
			else
			{
				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				//(Image().texture)	= (Resources.Load(PATH.DEFAULT_IMAGE) as Texture2D);
				(Image().texture)	= (null);
				(Image().color)		= Func.Color( (company.color), (Image().color.a) );

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
				if( data.allowLabel )
				{
					if( (data.label)!=(null) )
					{
						Label( company );
					}
					else
					{
						CreateLabel( (Image().rectTransform), (company) );
					}
				}

				//-------------------------------------------------------------------------------------------------------------------
				// -
				//-------------------------------------------------------------------------------------------------------------------
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// 국가
		//---------------------------------------------------------------------------------------------------------------------------
		if( Nation()!=(null) && Apps.Is(company.nation) )
		{
			Nation().Set(company.nation);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이름을 입력하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public void Set( string text )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (text)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( Text()!=(null) )
		{
			(Text().text)	= (text);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 트랜스폼을 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Transform Transform()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.transform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 게임 오브젝트를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public GameObject _GameObject()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.gameObject);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 컨트롤 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objControl Control()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.control);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 배경 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Image Back()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.back);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이미지 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public RawImage Image()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.image);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 이름 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Text Text()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.text);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 기업 정보를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagCompany Get()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.company as tagCompany);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 국가 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public uiIcon Nation()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.nation);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 사업체 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public tagBusiness Business()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.business)!=(null) )
		{
			if( data.business.GetType()==typeof(tagBusiness) )
			{
				return (data.business as tagBusiness);
			}
			else
			if( data.business.GetType()==typeof(string) )
			{
				return CApp.This.Business.Find( data.business as string );
			}
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (null);
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 그래프 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public uiGraph Graph()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.graph);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 주식 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public uiStock Stock()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.stock);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 라벨을 생성하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void CreateLabel( RectTransform parent, tagCompany company )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (parent)==(null) ) return;
		if( (company)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		GameObject		gameObject		= new GameObject();
		RectTransform	transform		= (gameObject.AddComponent(typeof(RectTransform)) as RectTransform);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		transform.SetParent( parent );
		(transform.localPosition)		= new Vector3();
		(transform.localEulerAngles)	= new Vector3();
		(transform.localScale)			= new Vector3( (1), (1), (1) );
		(transform.anchorMin)			= new Vector2( (0), (0) );
		(transform.anchorMax)			= new Vector2( (1), (1) );
		(transform.offsetMin)			= new Vector2( (0), (0) );
		(transform.offsetMax)			= new Vector2( (0), (0) );

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		Text text = (gameObject.AddComponent(typeof(Text)) as Text);
		if( (text)!=(null) )
		{
			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(text.font)	= (Resources.Load(PATH.FONT_DEFAULT) as Font);
			(text.text)	= (company.name);
			(text.supportRichText)			= (false);
			(text.raycastTarget)			= (false);
			(text.resizeTextForBestFit)		= (true);
			(text.resizeTextMinSize)		= (8);
			(text.resizeTextMaxSize)		= (32);
			(text.alignment)				= (TextAnchor.MiddleCenter);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(text.color) = Func.Color( (text.color), (Image().color.a) );

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
			(data.label)	= (text);

			//-----------------------------------------------------------------------------------------------------------------------
			// -
			//-----------------------------------------------------------------------------------------------------------------------
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		gameObject.AddComponent(typeof(Outline));

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 라벨을 생성하기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	void Label( tagCompany company )
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (company)==(null) ) return;

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		if( (data.label.text)!=(company.name) )
		{
			(data.label.text)	= (company.name);
		}

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 실행 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public objControl Excute()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.excute);

		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
	}

	//-------------------------------------------------------------------------------------------------------------------------------
	// 라벨 객체를 얻기 위한 함수
	//-------------------------------------------------------------------------------------------------------------------------------
	public Text Label()
	{
		//---------------------------------------------------------------------------------------------------------------------------
		// -
		//---------------------------------------------------------------------------------------------------------------------------
		return (data.label);

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