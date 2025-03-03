package org.example.ui;
import javax.swing.*;
import java.awt.*;

public class CircleButton extends JButton{
    public CircleButton(String label) {
        super(label);
        // 设置按钮的默认大小
        Dimension size = new Dimension(50, 50);
        setPreferredSize(size);
        setMinimumSize(size);
        setMaximumSize(size);
        // 设置边框为空，这样按钮就没有矩形边框了
        setBorderPainted(false);
        setContentAreaFilled(false);
        setFocusPainted(false);
    }

    @Override
    protected void paintComponent(Graphics g) {
        if (getModel().isArmed()) {
            // 当按钮被按下时，可以改变颜色
            g.setColor(Color.lightGray);
        } else {
            g.setColor(getBackground());
        }
        g.fillOval(0, 0, getSize().width - 1, getSize().height - 1);
        super.paintComponent(g);
    }

    @Override
    protected void paintBorder(Graphics g) {
        g.setColor(getForeground());
        g.drawOval(0, 0, getSize().width - 1, getSize().height - 1);
    }
}
