Shader "CylindricalUnwrap"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
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
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float PI = 3.14159265;
 
				float angle;
				float azim;
				float dist;

				float get_s, get_t, pos_s;

				angle = i.uv.x * 360.0 - 180.0;	

				if (angle >= -180.0 && angle < -90.0) {
					azim = angle+180.0 - 45.0;
					pos_s = 0.0;
				}

				if (angle >= -90.0 && angle < 0.0) {
					azim = angle + 45.0;
					pos_s = 0.25;
				}

				if (angle >= 0.0 && angle < 90.0) {
					azim = angle - 45.0;
					pos_s = 0.5;
				}

				if (angle >= 90.0 && angle < 180.0) {
					azim = angle - 180.0 + 45.0;
					pos_s = 0.75;
				}

				dist = sqrt(pow(tan(PI*azim/180.0),2.0) + 1.0);          
				get_s = (tan(PI*azim/180.0) + 1.0)/8.0 + pos_s;
				get_t = (i.uv.y-0.5)*dist + 0.5;

				fixed4 col;

				if (i.uv.y  < 0.5 - 0.5/sqrt(2.0) || i.uv.y > 0.5 + 0.5/sqrt(2.0)) {
					col = fixed4(0.0,0.0,0.0,0.0);
				} else {
					col = tex2D(_MainTex, float2(get_s, get_t));
				}

				return col;
			}
			ENDCG
		}
	}
}
