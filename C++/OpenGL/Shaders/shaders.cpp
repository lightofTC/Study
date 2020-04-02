#include <iostream>

#define GLEW_STATIC
#include<GL/glew.h>
#include<GLFW/glfw3.h>
#include "../HelloWindow/HelloWindow.h"
using namespace std;

//Vertex data,3D
//float vertices[] = {
//    -0.2f,-0.5f,0.4f,
//    0.3f,-0.5f,0.0f,
//    0.0f,0.8f,0.0f,
//};

float vertices[] = {
    -0.8f,0.8f,0.0f,
    0.0f,0.0f,0.0f,
    -0.4f,-0.2f,0.0f,
    0.9f,0.1f,0.0f,
    0.0f,0.4f,0.0f,
    0.4f,-0.2f,0.0f,
    -0.9f,0.4f,0.0f,
    0.3f,0.3f,0.0f,
    -0.1f,-0.7f,0.0f
};

unsigned int indices[] = {
    0,1,5,2,6,4,6,9,5
};

//Store shaders in const C strings
const char* vertexShaderSource =
"#version 330 core                       \n                     "
"layout(location = 2) in vec3 aPos;      \n                     "
"out vec4 vertexColor;                   \n                     "        
"void main() {\n                                                "
"        gl_Position = vec4(aPos.x, aPos.y, aPos.z, 1.0);   \n  "
"        vertexColor = vec4 (1.0, 0, 0 ,1.0); }             \n  ";


const char* fragmentShaderSource =
"#version 330 core                                 \n   "
"out vec4 FragColor;                               \n   "
"in vec4 vertexColor;                              \n   "  
"uniform vec4 ourColor;                            \n   "
"void main() {                                     \n   "
"        FragColor = ourColor;}                 \n   "
"                                                       ";
int main() {
    glfwInit();
    glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 3);
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

    //glPolygonMode(GL_FRONT_AND_BACK, GL_LINE); //仅保留边

    glEnable(GL_CULL_FACE);//开启面剔除功能
    glCullFace(GL_FRONT);//剔除背面，opengl逆时针画

    unsigned int VAO;//一个元素的数组
    glGenVertexArrays(1, &VAO);//可返回多个，这里指定返回一个值
    glBindVertexArray(VAO);

    unsigned int VBO;//Vertex buffer object
    glGenBuffers(1, &VBO);
    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, sizeof(vertices), vertices, GL_STATIC_DRAW);

    unsigned int EBO;
    glGenBuffers(1, &EBO);
    glBindBuffer(GL_ELEMENT_ARRAY_BUFFER, EBO);
    glBufferData(GL_ELEMENT_ARRAY_BUFFER, sizeof(indices), indices, GL_STATIC_DRAW);

    unsigned int vertexShader;
    vertexShader = glCreateShader(GL_VERTEX_SHADER);
    glShaderSource(vertexShader, 1, &vertexShaderSource, NULL);
    glCompileShader(vertexShader);

    unsigned int fragmentShader;
    fragmentShader = glCreateShader(GL_FRAGMENT_SHADER);
    glShaderSource(fragmentShader, 1, &fragmentShaderSource, NULL);
    glCompileShader(fragmentShader);

    //Combine shaders
    unsigned int shaderProgram;
    shaderProgram = glCreateProgram();
    glAttachShader(shaderProgram, vertexShader);
    glAttachShader(shaderProgram, fragmentShader);
    glLinkProgram(shaderProgram);

    //Use shaders
    glVertexAttribPointer(2, 3, GL_FLOAT, GL_FALSE, 3 * sizeof(float), (void*)0);
    glEnableVertexAttribArray(2);

    //Resize the window
    glfwSetFramebufferSizeCallback(window, framebuffer_size_callback);

    while (!glfwWindowShouldClose(window)) {
        //Key input
        processInput(window);

        glClearColor(1.0f, 1.0f, 0, 0);
        glClear(GL_COLOR_BUFFER_BIT);

        glBindVertexArray(VAO);
        glBindBuffer(GL_ARRAY_BUFFER, EBO);
        glDrawElements(GL_TRIANGLES, 9, GL_UNSIGNED_INT, 0);

        float timeValue = glfwGetTime();
        float greenValue = (sin(timeValue) / 2.0f) + 0.5f;
        int vertexColorLocation = glGetUniformLocation(shaderProgram, "ourColor");
        glUseProgram(shaderProgram);
        glUniform4f(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);
        //glDrawArrays(GL_TRIANGLES, 0, 9);
        //glDrawElements(GL_TRIANGLES, 2, GL_UNSIGNED_INT, 0);

        glfwSwapBuffers(window);
        glfwPollEvents();


    }
    glfwTerminate();
    return 0;
}