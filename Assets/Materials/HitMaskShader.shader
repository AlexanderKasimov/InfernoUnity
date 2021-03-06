﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/HitMaskShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_BlinkColor("Blink color", Color) = (1,1,1,1)
	}
		SubShader
		{
			Tags
			{
				"Queue" = "Transparent"
				"IgnoreProjector" = "True"
				"RenderType" = "Transparent"
				"PreviewType" = "Plane"
				"CanUseSpriteAtlas" = "True"
			}

			Cull Off
			Lighting Off
			ZWrite Off
			Blend One OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				//#pragma multi_compile_fog

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _BlinkColor;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					//fixed4 col = tex2D(_MainTex, i.uv);
					//fixed4 tmp = float4(tex2D(_MainTex, i.uv).r,tex2D(_MainTex, i.uv).g,tex2D(_MainTex, i.uv).b,tex2D(_MainTex, i.uv).a);
					
				/*	float1 coef = 1;
					fixed4 col = (_BlinkColor * _BlinkColor.a + float4(1,0,0,1)*float1(coef))*(_BlinkColor.a+coef);*/
					//но идеально белый не получился, мб так лучше, но лучше проверить почему
					fixed4 col = _BlinkColor * tex2D(_MainTex, i.uv).a*_BlinkColor.a + tex2D(_MainTex, i.uv)* tex2D(_MainTex, i.uv).a; //_BlinkColor * tex2D(_MainTex, i.uv).a;
					//fixed4 col = (_BlinkColor * tex2D(_MainTex, i.uv).a*_BlinkColor.a + tex2D(_MainTex, i.uv)* tex2D(_MainTex, i.uv).a) * (_BlinkColor.a+ tex2D(_MainTex, i.uv).a);
					
					//fixed4 col = _BlinkColor;

				return col;
				}
			ENDCG
		}
		}
}
