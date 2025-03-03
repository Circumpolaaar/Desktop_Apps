package org.example.util;

import javax.swing.JOptionPane;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class MemoErrorHandler {

    private static final String LOG_DIR = "src/main/logs"; // 相对项目根目录的路径
    private static final String LOG_FILE = "memo_error_log.txt";

    static {
        // 确保日志目录存在
        File logDir = new File(LOG_DIR);
        if (!logDir.exists()) {
            logDir.mkdirs();
        }
    }

    /**
     * 记录错误信息到日志，并显示错误对话框。
     *
     * @param message 错误信息
     * @param e       异常对象，可以为 null
     */
    public static void handleError(String message, Exception e) {
        writeLog(message, e);
        showDialog(message + (e != null ? "\n" + e.getMessage() : ""));
    }

    /**
     * 仅记录和显示错误信息，不传入异常对象。
     *
     * @param message 错误信息
     */
    public static void handleError(String message) {
        handleError(message, null);
    }

    /**
     * 将错误信息写入日志文件。
     *
     * @param message 错误信息
     * @param e       异常对象，可以为 null
     */
    private static void writeLog(String message, Exception e) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(LOG_DIR + "/" + LOG_FILE, true))) {
            writer.write(message);
            if (e != null) {
                writer.write("\n" + e.getMessage());
                e.printStackTrace();
            }
            writer.newLine();
        } catch (IOException ex) {
            System.err.println("Error writing to log file: " + ex.getMessage());
        }
    }

    /**
     * 显示错误对话框。
     *
     * @param message 错误信息
     */
    private static void showDialog(String message) {
        JOptionPane.showMessageDialog(null, message, "备忘录错误", JOptionPane.ERROR_MESSAGE);
    }
}
