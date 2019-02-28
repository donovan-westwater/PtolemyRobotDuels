Shader "Custom/Learning" {
	Properties {
		_MainTex("Texture", 2D) = "white"{}
		_Freq("Frequency",Rang(1.0, 256.0)) = 50
			_Scale("Scale" Range(0,1)) = 0.1
			_Speed("Speed", Range(0,10)) = 1
	}
	SubShader {
		Tag{"Queue"= "Transparent"}
			Pass{
				CGPROGRAM
				#pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"
				Blend SrcAplpha OneMinusSrcAlpha
				struct appdata{
					float4 vertex : POSTION;
					float2 uv : TEXCOORD0;
				}

				struct v2f
				{
					float4 vertex: SV_POSTION;
				}
				sampler2D _MainTex;
				float _Freq;
				float _Scale;
				float _Speed;
				v2f vert(appdata v){
					v2f 0;
					o.vertex = UnityObjectToClipPos(v.vertex);
					return o;
				}
				float4 frag(v2f i) : SV_Target
				{
					//return float4(1.uv.r, 1, 1, 1);
					float4 color = text2D(_MainTex, i.uv * sin((_Time*_Speed + i.uv.y*_Freq))*_Color;
					return color;
				}
				ENDCG
			}
}
