package org.example.ui;
import javax.swing.*;
import javax.swing.text.JTextComponent;

public class MemoActions {
    public void copy(JTextComponent textComponent) {
        textComponent.copy();
    }

    public void cut(JTextComponent textComponent) {
        textComponent.cut();
    }

    public void paste(JTextComponent textComponent) {
        textComponent.paste();
    }
}