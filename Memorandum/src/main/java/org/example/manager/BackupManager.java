// BackupManager.java
package org.example.manager;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;
import org.example.model.Memo;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class BackupManager {
    private static final String BACKUP_FILE = "memos_backup.json";

    // 备份备忘录数据
    public void backupMemos(List<Memo> memos) {
        try (FileWriter writer = new FileWriter(BACKUP_FILE)) {
            writer.write(new Gson().toJson(memos));
            System.out.println("备忘录数据备份成功！");
        } catch (IOException e) {
            System.err.println("备份数据时发生错误: " + e.getMessage());
        }
    }

    // 从备份文件恢复数据
    public List<Memo> restoreMemos() {
        try (Scanner scanner = new Scanner(new File(BACKUP_FILE))) {
            String content = scanner.useDelimiter("\\A").next();
            return new Gson().fromJson(content, new TypeToken<List<Memo>>() {}.getType());
        } catch (IOException e) {
            System.err.println("恢复数据时发生错误: " + e.getMessage());
            return new ArrayList<>();
        }
    }
}