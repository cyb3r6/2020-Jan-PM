Shader "SpecialFX/GlitchHologramShader"
{

    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _TintColor("Tint Color", Color) = (1,1,1,1)
        _Transparency("Transparency", Range(0.0, 0.5)) = 0.5   // things get weird if albedo is set too high.
        _Amplitude("Amplitude", Range(0.0, 1.0)) = 1
        _Frequency("Frequency", Float) = 1
        _Amount("Amount", Float) = 1
        _CutoutThreshold("Cutout threshold", Float) = 1
        _Distance("Distance", Float) = 1

    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 100

        ZWrite off      // don't render depth buffer
        Blend SrcAlpha OneMinusSrcAlpha // blending the pixels together using the alpha channel



        Pass
        {
            CGPROGRAM
            #pragma vertex vert     // we'll have a vertex function called 'vert'
            #pragma fragment frag   // we'll have a fragment function called 'frag'
            

            #include "UnityCG.cginc"    // has a bunch of stuff to help with rendering

            // this will pass information about verticies of a 3D model into a 'packed array' that has 4 floating point numbers (x,y,z,w)
            struct appdata
            {
                float4 vertex : POSITION;   // verticies of the model are in local space, floating4 (x,y,z,w)
                float2 uv : TEXCOORD0;      // pass the UV's for the models as a float2, binding to TEXCOORD0
            };

            // going to be what we return from the vert function
            // vert 2 frag, this struct passes out the vert fuction into the frag
            struct v2f
            {
                float2 uv : TEXCOORD0;      // pass the UV's for the models as a float2, binding to TEXCOORD0
                float4 vertex : SV_POSITION;// screen space position
            };



            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _TintColor;
            float _Transparency;
            float _Amplitude;
            float _Frequency;
            float _Amount;
            float _CutoutThreshold;
            float _Distance;

            v2f vert (appdata v)
            {
                v2f o;                                      // creating a new v3f struction called 'o'

                v.vertex.x += sin(_Time.y * _Frequency * v.vertex.y * _Amplitude) * _Distance * _Amount;

                o.vertex = UnityObjectToClipPos(v.vertex);  // bunch of matrix operations
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);       // 

                return o;
            }


            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv) + _TintColor;
                col.a = _Transparency;

                // discard any piuxels that have less than a certain amount of red. clip, if(colr.r < _CutOutThreshold) then discard
                clip(col.r = _CutoutThreshold);
                return col;
            }
            ENDCG
        }
    }
}
