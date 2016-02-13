Shader "FlatShader" {


	Properties{
		_Color("Color", Color) = (0,0,0)
	}


		SubShader{
		Color[_Color]
		Pass{}
	}


}