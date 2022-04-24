#version 330 core

		//lokasi		//type data
layout(location = 0) in vec3 aPosition;
// layout(location = 1) in vec3 aColor;

// menyediakan veriabel yg bisa dikirim ke next-step -> .frag
out vec4 vertexColor;

void main(void){
	gl_Position = vec4(aPosition, 1.0);

	// tiga warna
	// vertexColor = vec4(aColor, 1.0);

	// satu warna (merah)
	vertexColor = vec4(1.0, 0.0, 0.0, 1.0);
}