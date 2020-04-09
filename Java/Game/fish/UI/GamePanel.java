package com.fish.UI;

import javax.swing.*;
import java.awt.*;
import java.awt.image.BufferedImage;
import java.util.ArrayList;
import java.util.List;

/**
 * 步骤：
 * 1.继承JPanel类
 * 2.构造方法，确定面板特点
 */
public class GamePanel extends JPanel {
    //背景
    BufferedImage bg = ImageUtil.getImg("../Img/bg.jpg");
   //一条鱼
    Fish fish=new Fish();
    //很多鱼
    List<Fish> fishes=new ArrayList<Fish>();
    int fishNum=20;

    public GamePanel() {
        for (int i=0;i<fishNum;i++){
            fishes.add(new Fish());
        }
    }

    public void paint(Graphics g) {
        g.drawImage(bg, 0, 0, null);

        g.setColor(Color.yellow);
        g.setFont(new Font("楷体",Font.BOLD,20));
        g.drawString("分数：",600,30);
        g.drawString("渔网数：",300,30);
        g.drawString("火力：",50,30);

        for(int i=0;i<fishNum;i++) {
            Fish fish=fishes.get(i);
            g.drawImage(fish.image, fish.location[0], fish.location[1], fish.location[2], fish.location[3], null);
        }
    }
}
