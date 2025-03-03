package org.example.util;

import java.io.File;
import java.util.concurrent.Executors;
import java.util.concurrent.ScheduledExecutorService;
import java.util.concurrent.TimeUnit;

public class LogCleaner {

    private static final String LOG_DIR = "src/main/logs";
    private static final long CLEANUP_INTERVAL = 1; // 清理间隔时间，单位：天
    private static final long MAX_FILE_AGE = 7; // 日志文件最大存活时间，单位：天

    public static void main(String[] args) {
        ScheduledExecutorService scheduler = Executors.newSingleThreadScheduledExecutor();
        scheduler.scheduleAtFixedRate(LogCleaner::cleanOldLogFiles, 0, CLEANUP_INTERVAL, TimeUnit.DAYS);
    }

    private static void cleanOldLogFiles() {
        File dir = new File(LOG_DIR);
        File[] files = dir.listFiles(file -> {
            return file.lastModified() < System.currentTimeMillis() - MAX_FILE_AGE * 86400000L; // 检查文件是否超过最大存活时间
        });

        if (files != null) {
            for (File file : files) {
                if (file.delete()) {
                    System.out.println("Deleted old log file: " + file.getName());
                } else {
                    System.out.println("Failed to delete old log file: " + file.getName());
                }
            }
        }
    }
}