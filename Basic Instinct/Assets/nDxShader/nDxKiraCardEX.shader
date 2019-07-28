// Shader created with Shader Forge v1.38 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:False,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:False,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:2,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:2865,x:35600,y:32043,varname:node_2865,prsc:2|emission-2651-OUT;n:type:ShaderForge.SFN_UVTile,id:1243,x:32504,y:32523,varname:node_1243,prsc:2|UVIN-9774-UVOUT,WDT-3278-OUT,HGT-3278-OUT,TILE-2093-OUT;n:type:ShaderForge.SFN_TexCoord,id:1946,x:31779,y:32353,varname:node_1946,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Slider,id:3278,x:32083,y:32602,ptovrint:False,ptlb:Kira Tile,ptin:_KiraTile,varname:_KiraTile_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5555556,max:1;n:type:ShaderForge.SFN_Vector1,id:2093,x:32115,y:32804,varname:node_2093,prsc:2,v1:1;n:type:ShaderForge.SFN_Tex2d,id:2407,x:32962,y:32953,ptovrint:False,ptlb:Sub Kira Tex,ptin:_SubKiraTex,varname:_SubNormal_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:7df63a4247a77c549a2f511374372e64,ntxv:3,isnm:True|UVIN-6548-UVOUT;n:type:ShaderForge.SFN_Rotator,id:9774,x:32068,y:32385,varname:node_9774,prsc:2|UVIN-1946-UVOUT,ANG-932-OUT;n:type:ShaderForge.SFN_Slider,id:2550,x:31483,y:32530,ptovrint:False,ptlb:Kira Angle,ptin:_KiraAngle,varname:_KiraAngle_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_NormalBlend,id:3827,x:33534,y:32747,varname:node_3827,prsc:2|BSE-3254-OUT,DTL-7587-OUT;n:type:ShaderForge.SFN_TexCoord,id:96,x:32383,y:32702,varname:node_96,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_UVTile,id:6548,x:32764,y:32953,varname:node_6548,prsc:2|UVIN-9331-UVOUT,WDT-4835-OUT,HGT-4835-OUT,TILE-2093-OUT;n:type:ShaderForge.SFN_Slider,id:4835,x:32570,y:33121,ptovrint:False,ptlb:Sub Kira Tile,ptin:_SubKiraTile,varname:_SubKiraTile_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:8076,x:33422,y:32032,varname:node_3136,prsc:2,tex:0b3677ea3bd08c4408b9ea5a4bdf433e,ntxv:0,isnm:False|UVIN-2449-OUT,TEX-4785-TEX;n:type:ShaderForge.SFN_Transform,id:1276,x:33029,y:32032,varname:node_1276,prsc:2,tffrom:0,tfto:3|IN-7952-OUT;n:type:ShaderForge.SFN_NormalVector,id:1467,x:31711,y:32105,prsc:2,pt:False;n:type:ShaderForge.SFN_ComponentMask,id:2449,x:33207,y:32032,varname:node_2449,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-1276-XYZ;n:type:ShaderForge.SFN_Dot,id:2120,x:31912,y:32032,varname:node_2120,prsc:2,dt:0|A-6482-OUT,B-1467-OUT;n:type:ShaderForge.SFN_Vector3,id:6968,x:31081,y:32418,varname:node_6968,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Lerp,id:3254,x:33329,y:32584,varname:node_3254,prsc:2|A-5014-OUT,B-1429-OUT,T-7089-OUT;n:type:ShaderForge.SFN_Slider,id:7089,x:32849,y:32712,ptovrint:False,ptlb:Kira Power,ptin:_KiraPower,varname:node_4590,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Multiply,id:1814,x:32362,y:32032,varname:node_1814,prsc:2|A-1037-OUT,B-7737-OUT;n:type:ShaderForge.SFN_Slider,id:7737,x:32133,y:32215,ptovrint:False,ptlb:Holo Shift,ptin:_HoloShift,varname:node_8354,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:2,max:2;n:type:ShaderForge.SFN_AmbientLight,id:6067,x:30839,y:32890,varname:node_6067,prsc:2;n:type:ShaderForge.SFN_Tex2d,id:749,x:32744,y:32519,varname:node_9884,prsc:2,tex:876e4176d30bee54db2ca97158d72e55,ntxv:3,isnm:True|UVIN-1243-UVOUT,TEX-8816-TEX;n:type:ShaderForge.SFN_Blend,id:1429,x:32971,y:32519,varname:node_1429,prsc:2,blmd:5,clmp:True|SRC-749-RGB,DST-749-RGB;n:type:ShaderForge.SFN_Blend,id:7686,x:33672,y:32032,varname:node_7686,prsc:2,blmd:10,clmp:True|SRC-8076-RGB,DST-7141-OUT;n:type:ShaderForge.SFN_Slider,id:7141,x:33448,y:32267,ptovrint:False,ptlb:Holo Brightness,ptin:_HoloBrightness,varname:node_2159,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Color,id:2657,x:33930,y:32250,ptovrint:False,ptlb:Kira Color,ptin:_KiraColor,varname:node_3475,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_ComponentMask,id:5401,x:33909,y:32032,varname:node_5401,prsc:2,cc1:0,cc2:1,cc3:2,cc4:-1|IN-7686-OUT;n:type:ShaderForge.SFN_Set,id:9643,x:33737,y:32747,varname:KiraNormal,prsc:2|IN-3827-OUT;n:type:ShaderForge.SFN_Get,id:8213,x:32801,y:32228,varname:node_8213,prsc:2|IN-9643-OUT;n:type:ShaderForge.SFN_Multiply,id:9770,x:34224,y:32139,varname:node_9770,prsc:2|A-5401-OUT,B-2657-RGB;n:type:ShaderForge.SFN_Tex2d,id:4446,x:32590,y:32032,varname:node_4446,prsc:2,tex:0b3677ea3bd08c4408b9ea5a4bdf433e,ntxv:0,isnm:False|UVIN-1814-OUT,TEX-4785-TEX;n:type:ShaderForge.SFN_NormalBlend,id:9398,x:32822,y:32032,varname:node_9398,prsc:2|BSE-4446-RGB,DTL-8213-OUT;n:type:ShaderForge.SFN_Set,id:6029,x:34718,y:31974,varname:KiraAlbedo,prsc:2|IN-9770-OUT;n:type:ShaderForge.SFN_Append,id:1037,x:32147,y:32032,varname:node_1037,prsc:2|A-2120-OUT,B-2120-OUT;n:type:ShaderForge.SFN_Tex2d,id:8865,x:32448,y:31569,varname:node_8865,prsc:2,tex:876e4176d30bee54db2ca97158d72e55,ntxv:3,isnm:True|UVIN-1243-UVOUT,TEX-8816-TEX;n:type:ShaderForge.SFN_NormalBlend,id:7952,x:33029,y:31807,varname:node_7952,prsc:2|BSE-9398-OUT,DTL-4708-OUT;n:type:ShaderForge.SFN_Slider,id:5152,x:32362,y:31861,ptovrint:False,ptlb:Card Distortion,ptin:_CardDistortion,varname:node_5152,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Lerp,id:4708,x:32732,y:31726,varname:node_4708,prsc:2|A-512-OUT,B-8865-RGB,T-5152-OUT;n:type:ShaderForge.SFN_Lerp,id:7587,x:33347,y:32948,varname:node_7587,prsc:2|A-5014-OUT,B-2407-RGB,T-7958-OUT;n:type:ShaderForge.SFN_Slider,id:7958,x:32849,y:32838,ptovrint:False,ptlb:Sub Kira Power,ptin:_SubKiraPower,varname:node_7958,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Set,id:144,x:31345,y:32445,varname:PlaneNormal,prsc:2|IN-6968-OUT;n:type:ShaderForge.SFN_Get,id:5014,x:33123,y:32773,varname:node_5014,prsc:2|IN-144-OUT;n:type:ShaderForge.SFN_Get,id:512,x:32472,y:31707,varname:node_512,prsc:2|IN-144-OUT;n:type:ShaderForge.SFN_Pi,id:429,x:31709,y:32608,varname:node_429,prsc:2;n:type:ShaderForge.SFN_Multiply,id:932,x:31890,y:32498,varname:node_932,prsc:2|A-2550-OUT,B-429-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:4785,x:33026,y:32297,ptovrint:False,ptlb:Holo Tex,ptin:_HoloTex,varname:node_4785,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:0b3677ea3bd08c4408b9ea5a4bdf433e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2dAsset,id:8816,x:31085,y:32055,ptovrint:False,ptlb:Kira Tex,ptin:_KiraTex,varname:node_8816,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:876e4176d30bee54db2ca97158d72e55,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Color,id:9371,x:34178,y:32689,ptovrint:False,ptlb:SkyBox Color,ptin:_SkyBoxColor,varname:node_9371,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_TexCoord,id:3683,x:34020,y:32822,varname:node_3683,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_ComponentMask,id:8007,x:34376,y:32965,varname:node_8007,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-1452-UVOUT;n:type:ShaderForge.SFN_Rotator,id:1452,x:34222,y:32888,varname:node_1452,prsc:2|UVIN-3683-UVOUT,ANG-5872-OUT;n:type:ShaderForge.SFN_Slider,id:7507,x:33683,y:32966,ptovrint:False,ptlb:Grad Angle,ptin:_GradAngle,varname:node_7507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_Pi,id:7806,x:33796,y:33105,varname:node_7806,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5872,x:34042,y:33014,varname:node_5872,prsc:2|A-7507-OUT,B-7806-OUT;n:type:ShaderForge.SFN_Lerp,id:1743,x:34624,y:33003,varname:node_1743,prsc:2|A-9371-RGB,B-8034-RGB,T-8007-OUT;n:type:ShaderForge.SFN_Color,id:8034,x:34265,y:33168,ptovrint:False,ptlb:Grad Color,ptin:_GradColor,varname:node_8034,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_SwitchProperty,id:7484,x:34624,y:32810,ptovrint:False,ptlb:Gradation,ptin:_Gradation,varname:node_7484,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-9371-RGB,B-1743-OUT;n:type:ShaderForge.SFN_Set,id:6048,x:34635,y:32489,varname:Gradation,prsc:2|IN-7484-OUT;n:type:ShaderForge.SFN_Get,id:9897,x:32807,y:34240,varname:node_9897,prsc:2|IN-6048-OUT;n:type:ShaderForge.SFN_Set,id:7592,x:34029,y:34107,varname:OmoteMasterE,prsc:2|IN-1488-OUT;n:type:ShaderForge.SFN_Rotator,id:9331,x:32570,y:32912,varname:node_9331,prsc:2|UVIN-96-UVOUT,ANG-6211-OUT;n:type:ShaderForge.SFN_Pi,id:6759,x:32123,y:33038,varname:node_6759,prsc:2;n:type:ShaderForge.SFN_Multiply,id:6211,x:32353,y:32957,varname:node_6211,prsc:2|A-6341-OUT,B-6759-OUT;n:type:ShaderForge.SFN_Slider,id:6341,x:31958,y:32953,ptovrint:False,ptlb:Sub Kira Angle,ptin:_SubKiraAngle,varname:node_6341,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:2;n:type:ShaderForge.SFN_NormalVector,id:4032,x:32437,y:34497,prsc:2,pt:False;n:type:ShaderForge.SFN_Dot,id:8616,x:32646,y:34389,varname:node_8616,prsc:2,dt:0|A-7451-OUT,B-4032-OUT;n:type:ShaderForge.SFN_Smoothstep,id:8553,x:32828,y:34314,varname:node_8553,prsc:2|A-5499-OUT,B-7045-OUT,V-8616-OUT;n:type:ShaderForge.SFN_Vector1,id:5499,x:32598,y:34126,varname:node_5499,prsc:2,v1:0;n:type:ShaderForge.SFN_Vector1,id:7045,x:32598,y:34270,varname:node_7045,prsc:2,v1:1;n:type:ShaderForge.SFN_Lerp,id:3026,x:33025,y:34221,varname:node_3026,prsc:2|A-5499-OUT,B-9897-OUT,T-8553-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4003,x:31288,y:32904,ptovrint:False,ptlb:Ambient Color,ptin:_AmbientColor,varname:node_4003,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-3041-OUT,B-3656-OUT;n:type:ShaderForge.SFN_Vector1,id:3041,x:31069,y:32833,varname:node_3041,prsc:2,v1:1;n:type:ShaderForge.SFN_Set,id:3858,x:31479,y:32904,varname:AmbientColor,prsc:2|IN-4003-OUT;n:type:ShaderForge.SFN_Multiply,id:9415,x:33249,y:34223,varname:node_9415,prsc:2|A-9368-OUT,B-3026-OUT;n:type:ShaderForge.SFN_Get,id:9368,x:32988,y:34136,varname:node_9368,prsc:2|IN-3858-OUT;n:type:ShaderForge.SFN_Add,id:3656,x:31016,y:33055,varname:node_3656,prsc:2|A-6067-RGB,B-8965-OUT;n:type:ShaderForge.SFN_Vector1,id:8965,x:30808,y:33117,varname:node_8965,prsc:2,v1:0.5;n:type:ShaderForge.SFN_ViewVector,id:7451,x:32293,y:34347,varname:node_7451,prsc:2;n:type:ShaderForge.SFN_Get,id:9836,x:34837,y:32278,varname:node_9836,prsc:2|IN-7592-OUT;n:type:ShaderForge.SFN_Multiply,id:1488,x:33516,y:34069,varname:node_1488,prsc:2|A-2632-OUT,B-9415-OUT;n:type:ShaderForge.SFN_Get,id:2632,x:33261,y:34052,varname:node_2632,prsc:2|IN-6029-OUT;n:type:ShaderForge.SFN_Tex2d,id:5811,x:34871,y:32377,ptovrint:False,ptlb:node_5811,ptin:_node_5811,varname:node_5811,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b93073745d02aaa4eae52f933cb01384,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Lerp,id:3567,x:35099,y:32225,varname:node_3567,prsc:2|A-3197-RGB,B-9836-OUT,T-5811-RGB;n:type:ShaderForge.SFN_Color,id:3197,x:34876,y:32112,ptovrint:False,ptlb:node_3197,ptin:_node_3197,varname:node_3197,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_ViewVector,id:6482,x:31834,y:31818,varname:node_6482,prsc:2;n:type:ShaderForge.SFN_Multiply,id:2651,x:35348,y:32392,varname:node_2651,prsc:2|A-3567-OUT,B-2488-OUT;n:type:ShaderForge.SFN_Get,id:2488,x:35089,y:32412,varname:node_2488,prsc:2|IN-3858-OUT;proporder:8816-2657-7089-3278-2550-2407-7958-4835-6341-4785-7737-7141-5152-9371-7484-8034-7507-4003-5811-3197;pass:END;sub:END;*/

Shader "nDxShasder/nDxKiraCardEX" {
    Properties {
        _KiraTex ("Kira Tex", 2D) = "bump" {}
        [HDR]_KiraColor ("Kira Color", Color) = (1,1,1,1)
        _KiraPower ("Kira Power", Range(0, 1)) = 0
        _KiraTile ("Kira Tile", Range(0, 1)) = 0.5555556
        _KiraAngle ("Kira Angle", Range(0, 2)) = 0
        _SubKiraTex ("Sub Kira Tex", 2D) = "bump" {}
        _SubKiraPower ("Sub Kira Power", Range(0, 1)) = 1
        _SubKiraTile ("Sub Kira Tile", Range(0, 1)) = 1
        _SubKiraAngle ("Sub Kira Angle", Range(0, 2)) = 0
        _HoloTex ("Holo Tex", 2D) = "white" {}
        _HoloShift ("Holo Shift", Range(0, 2)) = 2
        _HoloBrightness ("Holo Brightness", Range(0, 1)) = 0.5
        _CardDistortion ("Card Distortion", Range(0, 1)) = 1
        _SkyBoxColor ("SkyBox Color", Color) = (0.5,0.5,0.5,1)
        [MaterialToggle] _Gradation ("Gradation", Float ) = 0.5
        _GradColor ("Grad Color", Color) = (0.5,0.5,0.5,1)
        _GradAngle ("Grad Angle", Range(0, 2)) = 0
        [MaterialToggle] _AmbientColor ("Ambient Color", Float ) = 1
        _node_5811 ("node_5811", 2D) = "white" {}
        _node_3197 ("node_3197", Color) = (1,0,0,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Cull Off
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            uniform float _KiraTile;
            uniform sampler2D _SubKiraTex; uniform float4 _SubKiraTex_ST;
            uniform float _KiraAngle;
            uniform float _SubKiraTile;
            uniform float _KiraPower;
            uniform float _HoloShift;
            uniform float _HoloBrightness;
            uniform float4 _KiraColor;
            uniform float _CardDistortion;
            uniform float _SubKiraPower;
            uniform sampler2D _HoloTex; uniform float4 _HoloTex_ST;
            uniform sampler2D _KiraTex; uniform float4 _KiraTex_ST;
            uniform float4 _SkyBoxColor;
            uniform float _GradAngle;
            uniform float4 _GradColor;
            uniform fixed _Gradation;
            uniform float _SubKiraAngle;
            uniform fixed _AmbientColor;
            uniform sampler2D _node_5811; uniform float4 _node_5811_ST;
            uniform float4 _node_3197;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float node_2120 = dot(viewDirection,i.normalDir);
                float2 node_1814 = (float2(node_2120,node_2120)*_HoloShift);
                float4 node_4446 = tex2D(_HoloTex,TRANSFORM_TEX(node_1814, _HoloTex));
                float3 PlaneNormal = float3(0,0,1);
                float3 node_5014 = PlaneNormal;
                float node_2093 = 1.0;
                float2 node_1243_tc_rcp = float2(1.0,1.0)/float2( _KiraTile, _KiraTile );
                float node_1243_ty = floor(node_2093 * node_1243_tc_rcp.x);
                float node_1243_tx = node_2093 - _KiraTile * node_1243_ty;
                float node_9774_ang = (_KiraAngle*3.141592654);
                float node_9774_spd = 1.0;
                float node_9774_cos = cos(node_9774_spd*node_9774_ang);
                float node_9774_sin = sin(node_9774_spd*node_9774_ang);
                float2 node_9774_piv = float2(0.5,0.5);
                float2 node_9774 = (mul(i.uv0-node_9774_piv,float2x2( node_9774_cos, -node_9774_sin, node_9774_sin, node_9774_cos))+node_9774_piv);
                float2 node_1243 = (node_9774 + float2(node_1243_tx, node_1243_ty)) * node_1243_tc_rcp;
                float3 node_9884 = UnpackNormal(tex2D(_KiraTex,TRANSFORM_TEX(node_1243, _KiraTex)));
                float2 node_6548_tc_rcp = float2(1.0,1.0)/float2( _SubKiraTile, _SubKiraTile );
                float node_6548_ty = floor(node_2093 * node_6548_tc_rcp.x);
                float node_6548_tx = node_2093 - _SubKiraTile * node_6548_ty;
                float node_9331_ang = (_SubKiraAngle*3.141592654);
                float node_9331_spd = 1.0;
                float node_9331_cos = cos(node_9331_spd*node_9331_ang);
                float node_9331_sin = sin(node_9331_spd*node_9331_ang);
                float2 node_9331_piv = float2(0.5,0.5);
                float2 node_9331 = (mul(i.uv0-node_9331_piv,float2x2( node_9331_cos, -node_9331_sin, node_9331_sin, node_9331_cos))+node_9331_piv);
                float2 node_6548 = (node_9331 + float2(node_6548_tx, node_6548_ty)) * node_6548_tc_rcp;
                float3 _SubKiraTex_var = UnpackNormal(tex2D(_SubKiraTex,TRANSFORM_TEX(node_6548, _SubKiraTex)));
                float3 node_3827_nrm_base = lerp(node_5014,saturate(max(node_9884.rgb,node_9884.rgb)),_KiraPower) + float3(0,0,1);
                float3 node_3827_nrm_detail = lerp(node_5014,_SubKiraTex_var.rgb,_SubKiraPower) * float3(-1,-1,1);
                float3 node_3827_nrm_combined = node_3827_nrm_base*dot(node_3827_nrm_base, node_3827_nrm_detail)/node_3827_nrm_base.z - node_3827_nrm_detail;
                float3 node_3827 = node_3827_nrm_combined;
                float3 KiraNormal = node_3827;
                float3 node_9398_nrm_base = node_4446.rgb + float3(0,0,1);
                float3 node_9398_nrm_detail = KiraNormal * float3(-1,-1,1);
                float3 node_9398_nrm_combined = node_9398_nrm_base*dot(node_9398_nrm_base, node_9398_nrm_detail)/node_9398_nrm_base.z - node_9398_nrm_detail;
                float3 node_9398 = node_9398_nrm_combined;
                float3 node_8865 = UnpackNormal(tex2D(_KiraTex,TRANSFORM_TEX(node_1243, _KiraTex)));
                float3 node_7952_nrm_base = node_9398 + float3(0,0,1);
                float3 node_7952_nrm_detail = lerp(PlaneNormal,node_8865.rgb,_CardDistortion) * float3(-1,-1,1);
                float3 node_7952_nrm_combined = node_7952_nrm_base*dot(node_7952_nrm_base, node_7952_nrm_detail)/node_7952_nrm_base.z - node_7952_nrm_detail;
                float3 node_7952 = node_7952_nrm_combined;
                float2 node_2449 = mul( UNITY_MATRIX_V, float4(node_7952,0) ).xyz.rgb.rg;
                float4 node_3136 = tex2D(_HoloTex,TRANSFORM_TEX(node_2449, _HoloTex));
                float3 KiraAlbedo = (saturate(( _HoloBrightness > 0.5 ? (1.0-(1.0-2.0*(_HoloBrightness-0.5))*(1.0-node_3136.rgb)) : (2.0*_HoloBrightness*node_3136.rgb) )).rgb*_KiraColor.rgb);
                float3 AmbientColor = lerp( 1.0, (UNITY_LIGHTMODEL_AMBIENT.rgb+0.5), _AmbientColor );
                float node_5499 = 0.0;
                float node_1452_ang = (_GradAngle*3.141592654);
                float node_1452_spd = 1.0;
                float node_1452_cos = cos(node_1452_spd*node_1452_ang);
                float node_1452_sin = sin(node_1452_spd*node_1452_ang);
                float2 node_1452_piv = float2(0.5,0.5);
                float2 node_1452 = (mul(i.uv0-node_1452_piv,float2x2( node_1452_cos, -node_1452_sin, node_1452_sin, node_1452_cos))+node_1452_piv);
                float3 Gradation = lerp( _SkyBoxColor.rgb, lerp(_SkyBoxColor.rgb,_GradColor.rgb,node_1452.r), _Gradation );
                float3 node_9415 = (AmbientColor*lerp(float3(node_5499,node_5499,node_5499),Gradation,smoothstep( node_5499, 1.0, dot(viewDirection,i.normalDir) )));
                float3 OmoteMasterE = (KiraAlbedo*node_9415);
                float3 node_9836 = OmoteMasterE;
                float4 _node_5811_var = tex2D(_node_5811,TRANSFORM_TEX(i.uv0, _node_5811));
                float3 emissive = (lerp(_node_3197.rgb,node_9836,_node_5811_var.rgb)*AmbientColor);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal xboxone ps4 
            #pragma target 3.0
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
