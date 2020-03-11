package com.example.puzzlegame1;

import android.graphics.Bitmap;

public class Pictures {
    private int mPictureId;
    Bitmap mBitmap;

    public Pictures(Bitmap bitmap,int mpictureId){
        this.mPictureId=mpictureId;
        mBitmap=bitmap;
    }
    public int getMpictureId(){
        return mPictureId;
    }

    public Bitmap getBitmap() {
        return mBitmap;
    }

    public void setBitmap(Bitmap bitmap) {
        mBitmap = bitmap;
    }

    public void setMpictureId(int mpictureId) {
        mPictureId = mpictureId;
    }
}
