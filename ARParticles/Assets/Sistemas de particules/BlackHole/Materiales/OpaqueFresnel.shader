// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3848,x:33023,y:32719,varname:node_3848,prsc:2|emission-7653-OUT;n:type:ShaderForge.SFN_VertexColor,id:6089,x:31999,y:32797,varname:node_6089,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:7135,x:31879,y:32904,varname:node_7135,prsc:2|EXP-3016-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3016,x:31752,y:32904,ptovrint:False,ptlb:FresnelValue,ptin:_FresnelValue,varname:node_3016,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Power,id:9323,x:32035,y:33021,varname:node_9323,prsc:2|VAL-7135-OUT,EXP-8582-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8582,x:31752,y:33061,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:node_8582,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Add,id:7653,x:32661,y:32751,varname:node_7653,prsc:2|A-3077-RGB,B-1612-OUT;n:type:ShaderForge.SFN_Multiply,id:3220,x:32228,y:32907,varname:node_3220,prsc:2|A-6089-RGB,B-9323-OUT;n:type:ShaderForge.SFN_Color,id:3077,x:31999,y:32642,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_3077,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_Multiply,id:1612,x:32438,y:32935,varname:node_1612,prsc:2|A-3220-OUT,B-8302-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8302,x:32293,y:33089,ptovrint:False,ptlb:FresnelIntensity,ptin:_FresnelIntensity,varname:node_8302,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.5;proporder:3016-8582-3077-8302;pass:END;sub:END;*/

Shader "Custom/NewSurfaceShader" {
    Properties {
        _FresnelValue ("FresnelValue", Float ) = 1
        _FresnelPower ("FresnelPower", Float ) = 1
        _Color ("Color", Color) = (0,0,0,1)
        _FresnelIntensity ("FresnelIntensity", Float ) = 1.5
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        LOD 200
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float _FresnelValue;
            uniform float _FresnelPower;
            uniform float4 _Color;
            uniform float _FresnelIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(2)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float3 emissive = (_Color.rgb+((i.vertexColor.rgb*pow(pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelValue),_FresnelPower))*_FresnelIntensity));
                float3 finalColor = emissive;
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
