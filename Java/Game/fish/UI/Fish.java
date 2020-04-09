package com.fish.UI;

import java.awt.image.BufferedImage;
import java.util.Random;

public class Fish {
    BufferedImage image;
    //鱼的横坐标、纵坐标，鱼的宽度、高度
    int [] location=new int[4];

    public  Fish(){
        image=ImageUtil.getImg("../Img/fish02_01.png");
        Random random=new Random();

        location[0]=random.nextInt(800);
        location[1]=random.nextInt(450);
        location[2]=image.getWidth();
        location[3]=image.getHeight();

    }
}
