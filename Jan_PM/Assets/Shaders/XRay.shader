Shader "Custom/XRayShader"
{

    SubShader
    {
        Tags { "Queue" = "Transparent+1" }        // renders after all transparent objects (queue = 3001)
        Pass { Blend Zero One}                  // this makes the object transparent

    }

}