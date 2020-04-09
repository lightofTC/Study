package com.fish.UI;

import javax.imageio.ImageIO;
import java.awt.image.BufferedImage;
import java.io.IOException;

/**
 * 操作图片的工具类
 */
public class ImageUtil {

    public static BufferedImage getImg(String path) {
        try {
            BufferedImage image = ImageIO.read(ImageUtil.class.getResource(path));
            return image;
        } catch (IOException e) {
            e.printStackTrace();
        }
        return null;
    }
}
