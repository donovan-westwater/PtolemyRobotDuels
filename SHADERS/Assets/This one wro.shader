Shader "Custom/This one wro" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0e
		_RimColor("Rim color", Color) = (1,1,1,1)
		_RimPower("Rim color", Color) = (1, 1, 1, 1)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float4 color : Color;
			float3 viewDir;

		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		//fixed4 _RimColor;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) {
			In.color = _Color;
			o.Albedo = textD(_MainTex, IN.uv_MainTex).rgb * IN.color;
			half rim = 1.0 - saturate(dot(normalize(In.viewDir), o.Normal));
			o.Emission = _RimColor.rgb *pow(rim, _RimPower);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
