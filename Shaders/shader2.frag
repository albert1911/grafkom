#version 330

out vec4 outputColor;

// variabel yg nerima dari prev-step -> .vert
in vec4 vertexColor;

uniform vec4 ourColor;

void main(){
	// ganti warna segitiganya

	// warna-warni
	// outputColor = vertexColor;

	// uniform
	outputColor = ourColor;
	
	// satu warna
	// outputColor = vec4(0.7, 1.0, 1.0, 1.0);
}