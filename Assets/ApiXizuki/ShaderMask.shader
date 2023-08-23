Shader "Custom/ShaderMask"
{
    SubShader
    {
        Tags { "Queue" = "Transparent+1" }
        LOD 200
		
		Pass{
			Blend Zero One
			}
	}
}