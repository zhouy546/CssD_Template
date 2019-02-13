// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Glitch"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_GlitchAlpha("GlitchAlpha", Float) = 0.03
		_TechNoise("TechNoise", 2D) = "white" {}
		_fui("fui", 2D) = "white" {}
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		Blend SrcAlpha OneMinusSrcAlpha , SrcAlpha OneMinusSrcAlpha
		
		ColorMask RG
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _fui;
		uniform sampler2D _TechNoise;
		uniform float _GlitchAlpha;
		uniform sampler2D _TextureSample0;
		uniform float _Cutoff = 0.5;

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float4 color70 = IsGammaSpace() ? float4(1,1,1,0.2980392) : float4(1,1,1,0.2980392);
			float2 temp_output_22_0_g81 = i.uv_texcoord;
			float2 temp_output_15_0_g83 = i.uv_texcoord;
			float4 _Vector0 = float4(2,3,0,0);
			float2 appendResult1_g81 = (float2(0.0 , _Vector0.x));
			float2 temp_output_14_0_g83 = appendResult1_g81;
			float temp_output_16_0_g83 = _Time.y;
			float2 appendResult13_g83 = (float2(( (temp_output_15_0_g83).x + ( (temp_output_14_0_g83).x * temp_output_16_0_g83 ) ) , (1.0 + (( (temp_output_15_0_g83).y + ( (temp_output_14_0_g83).y * temp_output_16_0_g83 ) ) - 0.0) * (0.0 - 1.0) / (1.0 - 0.0))));
			float2 temp_output_2_0_g85 = appendResult13_g83;
			float2 temp_output_15_0_g84 = i.uv_texcoord;
			float2 appendResult2_g81 = (float2(_Vector0.y , 0.0));
			float2 temp_output_14_0_g84 = appendResult2_g81;
			float temp_output_16_0_g84 = _Time.y;
			float2 appendResult13_g84 = (float2(( (temp_output_15_0_g84).x + ( (temp_output_14_0_g84).x * temp_output_16_0_g84 ) ) , (1.0 + (( (temp_output_15_0_g84).y + ( (temp_output_14_0_g84).y * temp_output_16_0_g84 ) ) - 0.0) * (0.0 - 1.0) / (1.0 - 0.0))));
			float2 temp_output_2_0_g82 = appendResult13_g84;
			float2 temp_output_15_0_g44 = i.uv_texcoord;
			float2 temp_output_14_0_g44 = float2( 3,1 );
			float temp_output_16_0_g44 = _Time.y;
			float2 appendResult13_g44 = (float2(( (temp_output_15_0_g44).x + ( (temp_output_14_0_g44).x * temp_output_16_0_g44 ) ) , (1.0 + (( (temp_output_15_0_g44).y + ( (temp_output_14_0_g44).y * temp_output_16_0_g44 ) ) - 0.0) * (0.0 - 1.0) / (1.0 - 0.0))));
			float clampResult53 = clamp( ( 1.0 - tex2D( _TechNoise, appendResult13_g44 ).r ) , sin( ( _Time.y * 10.0 ) ) , 1.0 );
			float temp_output_17_0_g81 = ( ( ceil( sin( sin( (1.0 + ((temp_output_2_0_g85).y - 0.0) * (0.0 - 1.0) / (1.0 - 0.0)) ) ) ) + ceil( sin( sin( (temp_output_2_0_g82).x ) ) ) ) * clampResult53 );
			float2 appendResult26_g81 = (float2(( (temp_output_22_0_g81).x + temp_output_17_0_g81 ) , (temp_output_22_0_g81).y));
			float2 lerpResult27_g81 = lerp( temp_output_22_0_g81 , appendResult26_g81 , _GlitchAlpha);
			float4 tex2DNode49 = tex2D( _fui, lerpResult27_g81 );
			float2 temp_output_22_0_g76 = i.uv_texcoord;
			float2 temp_output_15_0_g78 = i.uv_texcoord;
			float2 appendResult1_g76 = (float2(0.0 , _Vector0.x));
			float2 temp_output_14_0_g78 = appendResult1_g76;
			float temp_output_16_0_g78 = _Time.y;
			float2 appendResult13_g78 = (float2(( (temp_output_15_0_g78).x + ( (temp_output_14_0_g78).x * temp_output_16_0_g78 ) ) , (1.0 + (( (temp_output_15_0_g78).y + ( (temp_output_14_0_g78).y * temp_output_16_0_g78 ) ) - 0.0) * (0.0 - 1.0) / (1.0 - 0.0))));
			float2 temp_output_2_0_g80 = appendResult13_g78;
			float2 temp_output_15_0_g79 = i.uv_texcoord;
			float2 appendResult2_g76 = (float2(_Vector0.y , 0.0));
			float2 temp_output_14_0_g79 = appendResult2_g76;
			float temp_output_16_0_g79 = _Time.y;
			float2 appendResult13_g79 = (float2(( (temp_output_15_0_g79).x + ( (temp_output_14_0_g79).x * temp_output_16_0_g79 ) ) , (1.0 + (( (temp_output_15_0_g79).y + ( (temp_output_14_0_g79).y * temp_output_16_0_g79 ) ) - 0.0) * (0.0 - 1.0) / (1.0 - 0.0))));
			float2 temp_output_2_0_g77 = appendResult13_g79;
			float temp_output_17_0_g76 = ( ( ceil( sin( sin( (1.0 + ((temp_output_2_0_g80).y - 0.0) * (0.0 - 1.0) / (1.0 - 0.0)) ) ) ) + ceil( sin( sin( (temp_output_2_0_g77).x ) ) ) ) * 0.0 );
			float2 appendResult26_g76 = (float2(( (temp_output_22_0_g76).x + temp_output_17_0_g76 ) , (temp_output_22_0_g76).y));
			float2 lerpResult27_g76 = lerp( temp_output_22_0_g76 , appendResult26_g76 , 0.01);
			float clampResult81 = clamp( ( tex2DNode49.r - tex2D( _TextureSample0, lerpResult27_g76 ).r ) , 0.0 , 1.0 );
			float lerpResult82 = lerp( 1.0 , 0.0 , temp_output_17_0_g76);
			float4 color83 = IsGammaSpace() ? float4(0,0.95,1,1) : float4(0,0.8900055,1,1);
			float4 color84 = IsGammaSpace() ? float4(1,0,0.23,1) : float4(1,0,0.04323364,1);
			float2 temp_output_2_0_g55 = i.uv_texcoord;
			float4 lerpResult85 = lerp( color83 , color84 , ceil( ( (temp_output_2_0_g55).x - 0.5 ) ));
			float4 lerpResult114 = lerp( ( ( color70 * color70.a ) * tex2DNode49.r ) , ( ( clampResult81 * ( lerpResult82 * lerpResult85 ) ) * float4( 1,1,1,1 ) ) , clampResult81);
			o.Emission = lerpResult114.rgb;
			o.Alpha = 1;
			clip( ( tex2DNode49.r + clampResult81 ) - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16200
2127;65;1666;876;-2271.618;1212.904;1.397053;True;False
Node;AmplifyShaderEditor.Vector2Node;51;-684.1945,-877.8378;Float;False;Constant;_Vector0;Vector 0;5;0;Create;True;0;0;False;0;3,1;0,0;0;3;FLOAT2;0;FLOAT;1;FLOAT;2
Node;AmplifyShaderEditor.SimpleTimeNode;54;-459.6094,-655.4724;Float;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;104;-364.9212,-946.08;Float;False;RGFunction;-1;;44;9bc00082e5a830b42988f48799cf019b;0;3;14;FLOAT2;0,0;False;16;FLOAT;0;False;15;FLOAT2;0,0;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SamplerNode;48;-36.02359,-981.1476;Float;True;Property;_TechNoise;TechNoise;3;0;Create;True;0;0;False;0;481ae2d55f5b6c245bf3a9d2ed277c9c;481ae2d55f5b6c245bf3a9d2ed277c9c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;55;-217.6096,-660.4724;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;10;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;52;329.8055,-945.8378;Float;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SinOpNode;56;-19.60971,-627.4724;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;76;496.4253,-535.8723;Float;False;Constant;_Alpha;Alpha;5;0;Create;True;0;0;False;0;0.01;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;53;625.8055,-929.8378;Float;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;107;1170.277,23.34929;Float;False;LinerGrandient;-1;;55;8ec29412999a7c04e8b093c74175d805;0;1;2;FLOAT2;0,0;False;2;FLOAT;0;FLOAT;5
Node;AmplifyShaderEditor.FunctionNode;112;966.4253,-631.8723;Float;False;MF_Glitch;0;;76;51cf33e4865fd8745949f84e090aafe9;0;3;28;FLOAT;0;False;22;FLOAT2;0,0;False;18;FLOAT;0;False;2;FLOAT;0;FLOAT2;30
Node;AmplifyShaderEditor.FunctionNode;113;947.8055,-956.8378;Float;False;MF_Glitch;0;;81;51cf33e4865fd8745949f84e090aafe9;0;3;28;FLOAT;0;False;22;FLOAT2;0,0;False;18;FLOAT;0;False;2;FLOAT;0;FLOAT2;30
Node;AmplifyShaderEditor.SimpleSubtractOpNode;87;1664.676,26.54917;Float;False;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;79;1392.425,-650.8723;Float;True;Property;_TextureSample0;Texture Sample 0;5;0;Create;True;0;0;False;0;None;9af9b36949436ed4aaf70fbcc4c5e720;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;49;1316.992,-962.0835;Float;True;Property;_fui;fui;4;0;Create;True;0;0;False;0;None;9af9b36949436ed4aaf70fbcc4c5e720;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CeilOpNode;88;1845.475,60.14917;Float;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;84;1819.876,-167.0507;Float;False;Constant;_GlitchColor2;GlitchColor2;5;0;Create;True;0;0;False;0;1,0,0.23,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;83;1815.076,-394.2508;Float;False;Constant;_GlitchColor1;GlitchColor1;5;0;Create;True;0;0;False;0;0,0.95,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;85;2251.875,-207.0507;Float;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.LerpOp;82;1515.876,-418.2508;Float;False;3;0;FLOAT;1;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleSubtractOpNode;80;1789.425,-724.8723;Float;True;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ClampOpNode;81;2065.425,-718.8723;Float;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;70;1386.425,-1178.872;Float;False;Constant;_EnessuveColor;EnessuveColor;3;0;Create;True;0;0;False;0;1,1,1,0.2980392;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;89;2522.277,-415.0508;Float;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;71;1658.425,-1127.872;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;95;2806.477,-588.8506;Float;True;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;69;2641.624,-952.2723;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;3103.074,-547.8505;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;1,1,1,1;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleAddOpNode;98;3535.007,-826.8425;Float;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;114;3533.553,-973.6391;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;116;4011.168,-1007.291;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;Glitch;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;False;Transparent;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;False;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;2;5;False;-1;10;False;-1;2;5;False;-1;10;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;104;14;51;0
WireConnection;48;1;104;0
WireConnection;55;0;54;0
WireConnection;52;0;48;1
WireConnection;56;0;55;0
WireConnection;53;0;52;0
WireConnection;53;1;56;0
WireConnection;112;28;76;0
WireConnection;113;18;53;0
WireConnection;87;0;107;5
WireConnection;79;1;112;30
WireConnection;49;1;113;30
WireConnection;88;0;87;0
WireConnection;85;0;83;0
WireConnection;85;1;84;0
WireConnection;85;2;88;0
WireConnection;82;2;112;0
WireConnection;80;0;49;1
WireConnection;80;1;79;1
WireConnection;81;0;80;0
WireConnection;89;0;82;0
WireConnection;89;1;85;0
WireConnection;71;0;70;0
WireConnection;71;1;70;4
WireConnection;95;0;81;0
WireConnection;95;1;89;0
WireConnection;69;0;71;0
WireConnection;69;1;49;1
WireConnection;97;0;95;0
WireConnection;98;0;49;1
WireConnection;98;1;81;0
WireConnection;114;0;69;0
WireConnection;114;1;97;0
WireConnection;114;2;81;0
WireConnection;116;2;114;0
WireConnection;116;10;98;0
ASEEND*/
//CHKSM=43A32187EAA17B80178B69F660EC85F8B1A1A523