Shader "Snoopy/AlphaRimBase"
{
	Properties
	{
		_MainTex("Particle Texture", 2D) = "white" {}
		_Color("Color", Color) = (1,1,1,1)
		_RimColor("Rim Color", Color) = (0.5,0.5,0.5,0.5)
		_RimPower("Rim Power", Range(0.0,5.0)) = 2.5
	}
		SubShader
		{
			Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }

			Pass
			{
				ZWrite On
				ColorMask 0
			}

			CGPROGRAM
			#pragma surface surf Lambert alpha

			struct Input
			{
				float3 viewDir;
				float2 uv_MainTex;
			};

			sampler2D _MainTex;
			float4 _Color;
			float4 _RimColor;
			float _RimPower;

			void surf(Input IN, inout SurfaceOutput o)
			{
				float4 col = tex2D(_MainTex, IN.uv_MainTex);
				o.Albedo = col.rgb * _Color.rgb;
				//边缘高光
				half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));
				o.Emission = _RimColor.rgb * pow(rim, 6 - _RimPower);
				o.Alpha = _Color.a;
			}
			ENDCG
		}
			Fallback "VertexLit"
}
————————————————
版权声明：本文为CSDN博主「SnoopyNa2Co3」的原创文章，遵循CC 4.0 BY - SA版权协议，转载请附上原文出处链接及本声明。
原文链接：https ://blog.csdn.net/SnoopyNa2Co3/java/article/details/85288593