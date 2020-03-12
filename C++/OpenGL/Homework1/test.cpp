#include <Windows.h>
#include<gl/glut.h>
#include "test.h"

void main(int argc,char *argv[]) {
	glutInit(&argc, argv);
	glutInitDisplayMode(GLUT_SINGLE | GLUT_RGB);
	glutCreateWindow("MyFirstWindow");
	glutDisplayFunc(RenderScene);
	SetupRC();
	glutMainLoop();
}

