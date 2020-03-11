package com.example.puzzlegame1;

import android.graphics.Bitmap;

class GameData{
    public int x=0,y=0,p_x=0,p_y=0;
    public Bitmap bm;

    public GameData(int x,int y,Bitmap bm) {
        super();
        this.x=x;
        this.y=y;
        this.bm=bm;
        this.p_x=x;
        this.p_y=y;
    }

    public boolean isTrue() {
        if (x == p_x && y == p_y){
            return true;
        }
        return false;
    }
}