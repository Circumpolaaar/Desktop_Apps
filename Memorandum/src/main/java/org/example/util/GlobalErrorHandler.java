package org.example.util;

import javax.swing.JOptionPane;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

public class GlobalErrorHandler implements Thread.UncaughtExceptionHandler {

    private static final String LOG_DIR = "src/main/logs"; // 相对项目根目录的路径
    private static final String LOG_FILE = "global_error_log.txt";

    static {
        // 确保日志目录存在
        File logDir = new File(LOG_DIR);
        if (!logDir.exists()) {
            logDir.mkdirs();
        }
    }

    @Override
    public void uncaughtException(Thread t, Throwable e) {
        writeLog(t, e);
        showDialog(t, e);
    }

    /**
     * 将未捕获的异常信息写入日志文件。
     *
     * @param t 线程
     * @param e 未捕获的异常
     */
    private void writeLog(Thread t, Throwable e) {
        try (BufferedWriter writer = new BufferedWriter(new FileWriter(LOG_DIR + "/" + LOG_FILE, true))) {
            writer.write("Thread: " + t.getName());
            writer.newLine();
            writer.write("Error: " + e.getMessage());
            writer.newLine();
            e.printStackTrace();
            writer.newLine();
        } catch (IOException ex) {
            System.err.println("Error writing to log file: " + ex.getMessage());
        }
    }

    /**
     * 显示错误对话框。
     *
     * @param t 线程
     * @param e 未捕获的异常
     */
    private void showDialog(Thread t, Throwable e) {
        String message = "线程 \"" + t.getName() + "\" 发生严重错误: " + e.getMessage() + "\n\n"
                + "错误已记录到日志文件，请联系2254121680@qq.com。";
        JOptionPane.showMessageDialog(null, message, "全局错误", JOptionPane.ERROR_MESSAGE);
    }
}