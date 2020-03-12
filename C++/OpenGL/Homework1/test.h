#pragma once
#include<Windows.h>
#include<gl/freeglut.h>

void RenderScene(void) {
	glClear(GL_COLOR_BUFFER_BIT);
	glFlush();
}

void SetupRC(void) {
	glClearColor(0.0f, 0.5f, 0.4f,0.3f);
}
