Shader "AnakonShader/Outline_Beta"
{
    Properties
    {
        _OutlineColor ("Outline color", Color) = (0,0,0,1)
        _OutlineWidth ("Outlines width", Range (0.0, 2.0)) = 1.1
        _OutlineX("X", Range (-2.0, 2.0)) = 0
        _OutlineY("Y", Range (-2.0, 2.0)) = 0
        _OutlineZ("Z", Range (-2.0, 2.0)) = 0
    }

    CGINCLUDE
    #include "UnityCG.cginc"

    struct appdata
    {
        float4 vertex : POSITION;
    };

    struct v2f
    {
        float4 pos : POSITION;
        float4 screenPos: TEXCOORD1;
    };

    uniform float _OutlineWidth;
    uniform float _OutlineX;
    uniform float _OutlineY;
    uniform float _OutlineZ;
    uniform float4 _OutlineColor;
    ENDCG

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent" "IgnoreProjector" = "True"
        }

        Pass //Outline
        {
            ZWrite Off
            Cull Back
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            v2f vert(appdata v)
            {
                appdata original = v;
                v.vertex.xyzw += _OutlineWidth * normalize(v.vertex.xyzw);
                v.vertex.x -= _OutlineWidth / 4 + _OutlineX;
                v.vertex.y += _OutlineWidth / 4 + _OutlineY;
                v.vertex.z += _OutlineZ;

                v2f o;
        
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }

            half4 frag(v2f i) : COLOR
            {
          
                return _OutlineColor;
            }
            ENDCG
        }


    }
    Fallback "Diffuse"
}