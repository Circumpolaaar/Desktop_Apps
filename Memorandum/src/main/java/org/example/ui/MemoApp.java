package org.example.ui;

import org.example.manager.MemoManager;
import org.example.ui.MemoActions; // 导入MemoActions类
import org.example.util.ReminderService;

public class MemoApp {
    public static void main(String[] args) {
        MemoManager memoManager = new MemoManager(); // 先创建MemoManager实例
        MemoUI memoUI = new MemoUI(memoManager); // 将memoManager传递给MemoUI

        memoUI.setVisible(true);
        memoManager.setTextArea(memoUI.getRichTextEditor().getTextPane());

        MemoActions memoActions = new MemoActions();
        MemoListener memoListener = new MemoListener(memoUI, memoManager, memoActions); // 修改此处
        memoListener.initListeners();
        memoUI.setVisible(true);
        new ReminderService(memoManager, memoUI);
    }
}