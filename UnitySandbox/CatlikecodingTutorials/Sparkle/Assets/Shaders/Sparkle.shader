Shader "Custom/Sparkle"
{
    Properties
    {
        
		_Tint ("Tint", Color) = (0.5,0.5,0.5,0.5,1)
		_ShadowColor ("Shadow Color", Color) = (0,0,0,0,1)
		
		_NoiseTex ("Noise Texture", 2D) = "white" {}
		_NoiseSize ("Noise Size", Float) = 2
		_ShiningSpeed ("Shining Speed", Float) = 0.1
		_SparkleColor ("Sparkle Color", Color) = (1,1,1,1)
		_SparklePower ("Sparkle Power", Float) = 10
		
		_Specular ("Specular", Rangle(0,1)) = 0.5
		_Glossiness ("Glossiness", Rangle(0,1)) = 0.5
		
		_RimColor ("Rim Color", Color) = (0.17,0.36,0.81,0.0)
		_RimPower ("Rim Power", Range(0.6,0.36)) = 8.0
		_RimIntensity ("Rim Intensity", Range(0.0,100.0)) = 1.0
		
		_specsparkleRate ("Specular sparkle Rate", Float) = 6
		_rimsparkleRate ("Rim sparkle Rate", Float) = 10
		_diffsparkleRate ("Diffuse sparkle Rate", Float) = 1
		
		_ParallaxMap ("Parallax Map", 2D) = "white" {}
		_HeightFactor ("Height Scale", Range(-1, 1)) = 0.05
    }
    SubShader
    {
        Tags {
			"RenderType"="Opaque" 
			}
        LOD 100

        CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		
		#include "AutoLight.cginc"
		#include "Lighting.cginc"
		#pragma multi_compile_fwdbase
		#pragma multi_compile_fwdadd_fullshadows
		#pragma multi_compile_fog
		
		//#pragma glsl
		
		sampler2D _NoiseTex, _ParallaxMap;
		float4 _NoiseTex_ST, _ParallaxMap_ST;
		float4 _Tint, _ShadowColor, _RimColor, _SparkleColor;
		float _Specular, _Gloss, _NoiseSize, _ShiningSpeed;
		float _RimPower, _RimIntensity, _specsparkleRate, _rimsparkleRate, 
		
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
