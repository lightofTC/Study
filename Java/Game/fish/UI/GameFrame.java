package com.fish.UI;

import javax.swing.*;

/**
 * Java中的窗体类：JFrame
 * 自定义窗体步骤：
 * 1.一个类，继承Jframe
 * 2.构造方法初始化
 */
public class GameFrame extends JFrame {
/*

 */
    public GameFrame(){
       setTitle("捕鱼");
       setSize(800,480);
       setLocationRelativeTo(null);
       setResizable(false);
      // setDefaultCloseOperation();
    }

    public static void main(String[] args) {
        GameFrame gameFrame=new GameFrame();
        GamePanel gamePanel=new GamePanel();
        gameFrame.add(gamePanel);
        gameFrame.setVisible(true);
    }
}
