package org.example.model;

import java.time.LocalDateTime;

public class TodoItem {
    private String title;
    private LocalDateTime remindTime;
    private boolean isCompleted;

    public TodoItem(String title, LocalDateTime remindTime) {
        this.title = title;
        this.remindTime = remindTime;
        this.isCompleted = false;
    }

    public String getTitle() {
        return title;
    }

    public LocalDateTime getRemindTime() {
        return remindTime;
    }

    public boolean isCompleted() {
        return isCompleted;
    }

    public void setCompleted(boolean completed) {
        isCompleted = completed;
    }

    @Override
    public String toString() {
        return "待办事项: " + title + "\n提醒时间: " + remindTime + "\n完成状态: " + (isCompleted ? "已完成" : "未完成");
    }
}