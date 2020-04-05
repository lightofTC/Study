package com.snake;

import com.snake.img.Music;

import javax.swing.*;
import javax.swing.Timer;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;


public class SnakePanel extends JPanel implements KeyListener, ActionListener {

    ImageIcon up = new ImageIcon("./src/com/snake/img/up.gif");
    ImageIcon down = new ImageIcon("./src/com/snake/img/down.gif");
    ImageIcon right = new ImageIcon("./src/com/snake/img/right.gif");
    ImageIcon left = new ImageIcon("./src/com/snake/img/left.gif");
    ImageIcon food = new ImageIcon("./src/com/snake/img/food.png");
    ImageIcon body = new ImageIcon("./src/com/snake/img/body.png");

    //蛇的数据结构设计
    int[] snakex = new int[750];
    int[] snakey = new int[750];
    int len = 3;
    String direction = "R";

    int[] foodPos = new int[2];
    Random random = new Random();

    //游戏是否开始
    boolean isStarted = false;

    boolean isFailed = false;

    //计时器
    Timer timer = new Timer(150, this);

    public SnakePanel() {
        this.setFocusable(true);
        initSnake();//放置静态蛇
        initFood();
        this.addKeyListener(this);//键盘监听接口
        timer.start();
    }

    //初始化蛇
    public void initSnake() {
        isFailed = false;
        isStarted = false;
        len = 3;
        direction = "R";
        snakex[0] = 64;
        snakey[0] = 64;
        snakex[1] = 48;
        snakey[1] = 64;
        snakex[2] = 32;
        snakey[2] = 64;
    }

    //随机食物
    public void initFood() {
        foodPos[0] = random.nextInt(30) * 16 + 16;
        foodPos[1] = random.nextInt(30) * 16 + 16;
    }

    public void paint(Graphics g) {

        //设置背景颜色,位置
        this.setBackground(Color.BLACK);
        g.fillRect(16, 16, 480, 480);

        //画蛇身
        if (direction.equals("R")) {
            right.paintIcon(this, g, snakex[0], snakey[0]);
        } else if (direction.equals("L")) {
            left.paintIcon(this, g, snakex[0], snakey[0]);
        } else if (direction.equals("U")) {
            up.paintIcon(this, g, snakex[0], snakey[0]);
        } else if (direction.equals("D")) {
            down.paintIcon(this, g, snakex[0], snakey[0]);
        }

        //画蛇身
        for (int i = 1; i < len; i++) {
            body.paintIcon(this, g, snakex[i], snakey[i]);
        }

        //画食物
        food.paintIcon(this, g, foodPos[0], foodPos[1]);

        //画提示语
        if (!isStarted) {
            g.setColor(Color.white);
            g.setFont(new Font("arial", Font.BOLD, 15));
            g.drawString("Press Space to Start/Pause", 150, 240);
        }
        if (isFailed) {
            g.setColor(Color.white);
            g.setFont(new Font("arial", Font.BOLD, 15));
            g.drawString("Game Over! Press Space to Resart", 150, 240);
        }

        //分数
        g.setColor(Color.yellow );
        g.setFont(new Font("arial", Font.PLAIN, 15));
        g.drawString("Score:"+(len-3), 16, 32);
    }

    @Override
    public void keyTyped(KeyEvent e) {
    }

    @Override
    public void keyPressed(KeyEvent e) {
        int keyCode = e.getKeyCode();
        if ((keyCode == KeyEvent.VK_D || keyCode == KeyEvent.VK_RIGHT) && !direction.equals("L")) {
            direction = "R";
        } else if ((keyCode == KeyEvent.VK_S || keyCode == KeyEvent.VK_DOWN) && !direction.equals("U")) {
            direction = "D";
        } else if ((keyCode == KeyEvent.VK_A || keyCode == KeyEvent.VK_LEFT) && !direction.equals("R")) {
            direction = "L";
        } else if ((keyCode == KeyEvent.VK_W || keyCode == KeyEvent.VK_UP) && !direction.equals("D")) {
            direction = "U";
        } else if (keyCode == KeyEvent.VK_SPACE) {
            if (isFailed) {
                initSnake();
                initFood();
            } else{
                isStarted = !isStarted;
            }

        }
    }

    @Override
    public void keyReleased(KeyEvent e) {

    }

    /*
     * 1.重新定时钟
     * 2.蛇的移动(先移动身体，后移动头)
     * 3.重画界面
     * */
    @Override
    public void actionPerformed(ActionEvent e) {
        timer.start();
        if (isStarted && !isFailed) {
            //移动身体
            for (int i = len; i > 0; i--) {
                snakex[i] = snakex[i - 1];
                snakey[i] = snakey[i - 1];
            }
            if (direction.equals("R") && !direction.equals("L")) {
                snakex[0] += 16;
                if (snakex[0] > 480) {
                    snakex[0] = 16;
                }
            } else if (direction.equals("L")) {
                snakex[0] -= 16;
                if (snakex[0] < 16) {
                    snakex[0] = 480;
                }
            } else if (direction.equals("U")) {
                snakey[0] -= 16;
                if (snakey[0] < 16) {
                    snakey[0] = 480;
                }
            } else if (direction.equals("D")) {
                snakey[0] += 16;
                if (snakey[0] > 480) {
                    snakey[0] = 16;
                }
            }
        }

        //吃食物
        if (snakex[0] == foodPos[0] & snakey[0] == foodPos[1]) {
            len++;
            initFood();
        }

        for (int i = 1; i < len; i++) {
            if (snakex[0] == snakex[i] & snakey[0] == snakey[i]) {
                isFailed = true;
            }
        }
        repaint();
    }
}
