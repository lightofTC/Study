#include <iostream>

#define GLEW_STATIC
#include<GL/glew.h>
#include<GLFW/glfw3.h>
#include "HelloWindow.h"
using namespace std;

int main(){
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR,3);
    glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 3);
    glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);
   
    //Open GLFW Window
    GLFWwindow* window = glfwCreateWindow
    (800, 600, "LearnOpenGL", NULL, NULL);
    if (window == NULL) {
        cout << "Fail to create GLFW window" << endl;
        glfwTerminate();
        return -1;
    }
    glfwMakeContextCurrent(window);

    //Init GLEW
    glewExperimental = true;
    if (glewInit() != GLEW_OK) {
        cout << "Init GLEW fail!" << endl;
        glfwTerminate();
        return -1;
    }

    glViewport(0, 0, 800, 600);
    
    //Resize the window
    glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

    while (!glfwWindowShouldClose(window)) {
        //Key input
        processInput(window);
        
        glClearColor(1.0f, 1.0f, 0, 0);
        glClear(GL_COLOR_BUFFER_BIT);

        glfwSwapBuffers(window);
        glfwPollEvents();

        
    }
    glfwTerminate();
    return 0;
}
