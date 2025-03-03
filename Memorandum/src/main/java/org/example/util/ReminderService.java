package org.example.util;

import org.example.model.TodoItem;
import org.example.manager.MemoManager;
import org.example.ui.MemoUI;
import javax.swing.*;
import java.time.LocalDateTime;
import java.util.List;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

public class ReminderService {
    private ScheduledExecutorService scheduler;
    private MemoManager memoManager;
    private MemoUI memoUI;

    public ReminderService(MemoManager memoManager, MemoUI memoUI) {
        this.memoManager = memoManager;
        this.memoUI = memoUI;
        startScheduler();
    }

    private void startScheduler() {
        scheduler = Executors.newSingleThreadScheduledExecutor();
        scheduler.scheduleAtFixedRate(this::checkReminders, 0, 1, TimeUnit.MINUTES); // 每分钟检查一次
    }

    private void checkReminders() {
        LocalDateTime now = LocalDateTime.now();
        List<TodoItem> todoItems = memoManager.getTodoItems();
        for (TodoItem item : todoItems) {
            if (item.getRemindTime().isBefore(now) && !item.isCompleted()) {
                try {
                    // 弹出提醒对话框
                    SwingUtilities.invokeLater(() -> {
                        JOptionPane.showMessageDialog(null, "提醒：" + item.getTitle());
                        item.setCompleted(true);
                        memoUI.updateTodoList();
                    });
                } catch (Exception e) {
                    // 记录异常信息
                    e.printStackTrace();
                }
            }
        }
    }
}