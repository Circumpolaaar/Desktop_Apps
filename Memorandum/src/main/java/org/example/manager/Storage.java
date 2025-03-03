package org.example.manager;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import org.example.model.Memo;
import org.example.util.MemoErrorHandler;

import java.io.*;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

public class Storage {
    private static final String FILE_NAME = "memos.json";
    private static final Gson gson = new GsonBuilder()
            .registerTypeAdapter(LocalDateTime.class, new org.example.expansion.LocalDateTimeAdapter())
            .create();

    public static void saveMemos(List<Memo> memos) {
        try (Writer writer = new FileWriter(FILE_NAME)) {
            gson.toJson(memos, writer);
        } catch (IOException e) {
            MemoErrorHandler.handleError("保存备忘录数据时发生错误。", e);
        }
    }

    public static List<Memo> loadMemos() {
        try (Reader reader = new FileReader(FILE_NAME)) {
            return gson.fromJson(reader, new TypeToken<List<Memo>>() {}.getType());
        } catch (IOException e) {
            MemoErrorHandler.handleError("加载备忘录数据时发生错误。", e);
            return new ArrayList<>(); // 返回空列表以防出错
        }
    }
}



