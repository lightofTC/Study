package com.example.puzzlegame1;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Matrix;
import android.graphics.drawable.BitmapDrawable;
import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.view.animation.Animation;
import android.view.animation.TranslateAnimation;
import android.widget.Button;
import android.widget.GridLayout;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import static java.lang.System.exit;

public class MainActivity extends AppCompatActivity {

    private int arr=3;
    private ImageView[][] iv_game_arr=new ImageView[arr][arr];
    private GridLayout main_game;
    private ImageView iv_null_ImageView;
    int score=0;
    String score_text;
    private TextView mScoreView;
    private Button start_again_button;
    private Button change_picture_button;
    private boolean isGameStart=false;
    private boolean isAnimationRun=false;

    int picture_id=0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        //Bitmap mDuck = BitmapFactory.decodeResource(getResources(), R.drawable.duck);

        mScoreView=(TextView)findViewById(R.id.score_text_view);
        Bitmap mDuck = ((BitmapDrawable)getResources().getDrawable(R.drawable.duck)).getBitmap();
        Bitmap mKitty = ((BitmapDrawable)getResources().getDrawable(R.drawable.kitty)).getBitmap();
        Pictures [] mPicture=new Pictures[]{
                new Pictures(mDuck,0),
                new Pictures(mKitty,1)
        };

        start_again_button=(Button)findViewById(R.id.start_again_button);
        start_again_button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                randomMove();
                score=0;
                updataScore();
            }
        });


        Bitmap bigBm = (Bitmap) mPicture[picture_id].getBitmap();
        int tuWandH =bigBm.getWidth()/arr;
        int ivWandH=getWindowManager().getDefaultDisplay().getWidth()/4;
        for (int i = 0; i <iv_game_arr.length ; i++) {
            for (int j = 0; j < iv_game_arr[0].length ; j++){
                Bitmap bm = Bitmap.createBitmap(bigBm, j * tuWandH,
                        i * tuWandH, tuWandH, tuWandH);
                change_picture_button=(Button)findViewById(R.id.change_picture_button);
                change_picture_button.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {

                    }
                });
                iv_game_arr[i][j] = new ImageView(this);
                iv_game_arr[i][j].setImageBitmap(bm);
                iv_game_arr[i][j].setLayoutParams(new ConstraintLayout.LayoutParams(ivWandH,ivWandH));
                iv_game_arr[i][j].setPadding(2, 2, 2, 2);
                iv_game_arr[i][j].setTag(new GameData(i,j,bm));
                iv_game_arr[i][j].setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        boolean flag = isHasNullImageView((ImageView) v );
                        if (flag){
                            changeDataByImageView((ImageView) v );
                        }
                    }
                });
            }
        }

        main_game=(GridLayout) findViewById(R.id.main_game);
        for(int i=0;i<iv_game_arr.length;i++){
            for(int j=0;j<iv_game_arr[0].length;j++){
                main_game.addView(iv_game_arr[i][j]);
            }
        }
        setNullImageView(iv_game_arr[arr-1][arr-1]);
        randomMove();
        updataScore();
        isGameStart=true;
    }

    public void randomMove(){
        for(int i=0;i<150;i++){
            int type=(int)(Math.random()*4)+1;
            changeByDir(type);
            }
        }

    public void changeDataByImageView(final ImageView mImageView){
        changeDataByImageView(mImageView,false);
    }
    public void changeDataByImageView(final ImageView mImageView, final boolean isAnimation){

        if(isAnimationRun)
            return;
        if(isAnimation){
            GameData mGameData = (GameData) mImageView.getTag();
            iv_null_ImageView.setImageBitmap(mGameData.bm);
            GameData mNullGameData = (GameData) iv_null_ImageView.getTag();
            mNullGameData.bm = mGameData.bm;
            mNullGameData.p_x = mGameData.p_x;
            mNullGameData.p_y = mGameData.p_y;
            setNullImageView(mImageView);
            if(isGameStart){
                isGameOver();
            }
            return;
        }
        TranslateAnimation translateAnimation=null;
        if(mImageView.getX()<iv_null_ImageView.getX()){
            translateAnimation=new TranslateAnimation(
                    0.1f,mImageView.getWidth(),0.1f,0.1f);
        }else if(mImageView.getX()>iv_null_ImageView.getX()){
            translateAnimation=new TranslateAnimation(
                    0.1f,-mImageView.getWidth(),0.1f,0.1f);
        }else if(mImageView.getY()<iv_null_ImageView.getY()){
            translateAnimation=new TranslateAnimation(
                    0.1f,0.1f,0.1f,mImageView.getWidth());
        }else if(mImageView.getY()>iv_null_ImageView.getY()){
            translateAnimation=new TranslateAnimation(
                    0.1f,0.1f,0.1f,-mImageView.getWidth());
        }
        translateAnimation.setDuration(30);
        translateAnimation.setFillAfter(true);
        translateAnimation.setAnimationListener(new Animation.AnimationListener() {
            @Override
            public void onAnimationStart(Animation animation) {
                isAnimationRun=true;
            }
            @Override
            public void onAnimationEnd(Animation animation) {
                score++;
                updataScore();
                isAnimationRun=false;
                mImageView.clearAnimation();
                GameData mGameData = (GameData) mImageView.getTag();
                iv_null_ImageView.setImageBitmap(mGameData.bm);
                GameData mNullGameData = (GameData) iv_null_ImageView.getTag();
                mNullGameData.bm = mGameData.bm;
                mNullGameData.p_x = mGameData.p_x;
                mNullGameData.p_y = mGameData.p_y;
                setNullImageView(mImageView);
                if(isGameStart){
                    isGameOver();
                }
            }
            @Override
            public void onAnimationRepeat(Animation animation) {

            }
        });
        mImageView.startAnimation(translateAnimation);
    }

    public void setNullImageView(ImageView mImageView){
            mImageView.setImageBitmap(null);
            iv_null_ImageView=mImageView;
    }

    public boolean isHasNullImageView(ImageView mImageView){
        GameData mNullGameData = (GameData) iv_null_ImageView.getTag();
        GameData mGameData = (GameData) mImageView.getTag();
        if(mNullGameData.y==mGameData.y && (mNullGameData.x-1)==mGameData.x){
             return  true;
        }else if(mNullGameData.y==mGameData.y && (mNullGameData.x+1)==mGameData.x){
            return  true;
        }else if((mNullGameData.y-1)==mGameData.y && mNullGameData.x==mGameData.x){
            return  true;
        }else if((mNullGameData.y+1)==mGameData.y && mNullGameData.x==mGameData.x){
            return  true;
        }
        return false;
    }

    public void changeByDir(int type){
        GameData mNullGameData = (GameData) iv_null_ImageView.getTag();
        int new_x = mNullGameData.x;
        int new_y = mNullGameData.y;
        if (type == 1){
            new_x++;
        }else if (type == 2){
            new_x--;
        }else if (type == 3){
            new_y++;
        }else if (type == 4){
            new_y--;
        }

        if (new_x >=0 && new_x < iv_game_arr.length&&new_y >= 0&&new_y < iv_game_arr[0].length){
                changeDataByImageView(iv_game_arr[new_x][new_y],true);
        }else{ }
    }

    public void updataScore(){
        score_text = String.format("%d",score);
        mScoreView.setText(score_text);
    }

    public void isGameOver(){
        boolean isGameOver=true;
        for(int i=0;i<iv_game_arr.length;i++){
            for(int j=0;j<iv_game_arr[0].length;j++){
                if(iv_game_arr[i][j]==iv_null_ImageView){
                    continue;
                }
                GameData mGameData=(GameData)iv_game_arr[i][j].getTag();
                if(!mGameData.isTrue()){
                    isGameOver=false;
                    break;
                }
            }
        }
        if(isGameOver)
            Toast.makeText(MainActivity.this,"游戏结束",
                    Toast.LENGTH_SHORT).show();
    }

    /*public void changePicture(){
       picture_id=(picture_id+1)% mPicture.length;
       int id=mPicture[picture_id].getMpictureId();

    }*/


}


