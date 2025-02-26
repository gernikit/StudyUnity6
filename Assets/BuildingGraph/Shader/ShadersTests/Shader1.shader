Shader "Unlit/Shader1"
{
    Properties // input data
    {
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float4 _Color;
            
            struct MeshData //per-vertex mesh data
            {
                float4 vertex : POSITION; //vertex position
                float3 normals: NORMAL;
                //float4 tangent: TANGENT;
                //float4 color: COLOR; //vertex color
                float2 uv : TEXCOORD0; // uv0 coordinates
               // float2 uv1 : TEXCOORD1; // uv1 coordinates
            };

            struct Interpolators
            {
                float4 vertex : SV_POSITION; // clip space position
                float2 uv : TEXCOORD0;
            };
            
            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex); // local space to clip space
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                return _Color;
            }
            ENDCG
        }
    }
}
