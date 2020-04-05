package com.snake;

import javax.swing.JFrame;

public class Snake {
    public static void main(String[] args) {
        JFrame frame=new JFrame("SNAKE");
        frame.setBounds(400,200,512,544);
        frame.setResizable(false);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        SnakePanel panel=new SnakePanel();
        frame.add(panel);
        frame.setVisible(true);
    }
}
