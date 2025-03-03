package org.example.model;

import java.time.LocalDateTime;

public class Memo {
    private String title;
    private String content;
    private LocalDateTime createdAt;
    private String category;

    // 修改构造函数，添加分类参数
    public Memo(String title, String content, String category) {
        this.title = title;
        this.content = content;
        this.category = category; // 正确初始化分类
        this.createdAt = LocalDateTime.now();
    }

    public String getTitle() {
        return title;
    }

    public String getContent() {
        return content;
    }

    public LocalDateTime getCreatedAt() {
        return createdAt;
    }

    public String getCategory() {
        return category; // 添加获取分类的方法
    }

    @Override
    public String toString() {
        return "标题: " + title + "\n内容: " + content + "\n分类: " + category + "\n创建时间: " + createdAt;
    }
}


