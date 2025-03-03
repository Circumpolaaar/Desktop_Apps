package org.example.manager;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.JTextPane;
import javax.swing.undo.UndoManager;

import org.example.model.Memo;
import org.example.model.TodoItem;
import org.example.ui.MemoUI;
import org.example.util.MemoErrorHandler;
public class MemoManager {
    public Map<String, List<Memo>> memoFolderMap = null;
    private File file;
    private JTextPane textPane; // 使用 JTextPane
    private UndoManager undoManager = new UndoManager();
    private List<TodoItem> todoList = new ArrayList<>();
    private MemoUI memoUI; // 添加对MemoUI的引用

    public MemoManager(MemoUI memoUI) {
        this.memoUI = memoUI;
    }
    public void addTodoItem(TodoItem todoItem) {
        todoList.add(todoItem);
        if (memoUI != null) {
            memoUI.updateTodoList(); // 通知UI更新待办事项列表
        }
    }

    public List<TodoItem> getTodoItems() {
        return todoList;
    }
    public MemoManager() {
        memoFolderMap = new HashMap<>();
    }

    public void setTextArea(JTextPane textPane) {
        this.textPane = textPane;
        textPane.getDocument().addUndoableEditListener(e -> undoManager.addEdit(e.getEdit()));
    }

    public void addFolder(String folderName) {
        // 这里可以添加代码来处理新建文件夹的逻辑
        JOptionPane.showMessageDialog(null, "新建文件夹: " + folderName);
    }

    public void openFolder(String folderPath) {
        // 这里可以添加代码来处理打开文件夹的逻辑
        JOptionPane.showMessageDialog(null, "打开文件夹: " + folderPath);
    }

    // 添加备忘录
    public void addMemo(String title, String content, String category) {
        Memo memo = new Memo(title, content, category);
        memoFolderMap.putIfAbsent(category, new ArrayList<>());
        memoFolderMap.get(category).add(memo);
    }

    // 获取所有备忘录
    public List<Memo> getAllMemos() {
        List<Memo> allMemos = new ArrayList<>();
        for (List<Memo> memoList : memoFolderMap.values()) {
            allMemos.addAll(memoList);
        }
        return allMemos;
    }

    // 根据标题获取备忘录
    public Memo getMemoByTitle(String title) {
        for (List<Memo> memoList : memoFolderMap.values()) {
            for (Memo memo : memoList) {
                if (memo.getTitle().equals(title)) {
                    return memo;
                }
            }
        }
        return null;
    }

    // 更新备忘录
    public void updateMemo(String title, String newTitle, String content, String newCategory) {
        Memo memo = getMemoByTitle(title);
        if (memo != null) {
            deleteMemo(title);
            addMemo(newTitle, content, newCategory);
        }
    }

    // 删除备忘录
    public void deleteMemo(String title) {
        for (List<Memo> memoList : memoFolderMap.values()) {
            Memo memo = getMemoByTitle(title);
            if (memo != null) {
                memoList.remove(memo);
                break;
            }
        }
    }

    // 搜索备忘录
    public List<Memo> searchMemos(String keyword) {
        List<Memo> result = new ArrayList<>();
        for (List<Memo> memoList : memoFolderMap.values()) {
            for (Memo memo : memoList) {
                if (memo.getTitle().contains(keyword) || memo.getContent().contains(keyword)) {
                    result.add(memo);
                }
            }
        }
        return result;
    }

    // 获取所有备忘录及其分类
    public Map<String, List<Memo>> getAllMemosByCategories() {
        return memoFolderMap;
    }

    // 文件操作
    public void open(){
        if (textPane == null){
            MemoErrorHandler.handleError("文本区域未初始化！");
            return;
        }
        JFileChooser fileChooser = new JFileChooser();
        int result = fileChooser.showOpenDialog(null);
        if (result == JFileChooser.APPROVE_OPTION) {
            file = fileChooser.getSelectedFile();
            try (BufferedReader reader = new BufferedReader(new FileReader(file))) {
                String line;
                StringBuilder textBuilder = new StringBuilder();
                while ((line = reader.readLine()) != null) {
                    textBuilder.append(line).append("\n");
                }
                textPane.setText(textBuilder.toString());
            } catch (IOException e) {
                MemoErrorHandler.handleError("打开文件时发生错误。", e);
            }
        }
    }
    //打开文件夹
    public File openDirectory() {
        JFileChooser fileChooser = new JFileChooser();
        fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        int result = fileChooser.showOpenDialog(null);
        if (result == JFileChooser.APPROVE_OPTION) {
            return fileChooser.getSelectedFile();
        }
        return null;
    }
    //用于打开文件夹后点击文件的文件打开
    public void openFile(File fileToOpen) {
        if (textPane == null) {
            MemoErrorHandler.handleError("文本区域未初始化！");
            return;
        }
        try (BufferedReader reader = new BufferedReader(new FileReader(fileToOpen))) {
            String line;
            StringBuilder textBuilder = new StringBuilder();
            while ((line = reader.readLine()) != null) {
                textBuilder.append(line).append("\n");
            }
            textPane.setText(textBuilder.toString());
            file = fileToOpen;
        } catch (IOException e) {
            MemoErrorHandler.handleError("打开文件时发生错误。", e);
        }
    }
    
    public void save() {
        if (textPane == null) {
            MemoErrorHandler.handleError("文本区域未初始化！");
            return;
        }
        if (file == null) {
            saveAs();
        } else {
            try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))) {
                writer.write(textPane.getText());
            } catch (IOException e) {
                MemoErrorHandler.handleError("保存文件时发生错误。", e);
            }
        }
    }

    public void saveAs() {
        if (textPane == null) {
            MemoErrorHandler.handleError("文本区域未初始化！");
            return;
        }
        JFileChooser fileChooser = new JFileChooser();
        int result = fileChooser.showSaveDialog(null);
        if (result == JFileChooser.APPROVE_OPTION) {
            file = fileChooser.getSelectedFile();
            try (BufferedWriter writer = new BufferedWriter(new FileWriter(file))) {
                writer.write(textPane.getText());
            } catch (IOException e) {
                MemoErrorHandler.handleError("另存为文件时发生错误。", e);
            }
        }
    }

    public void about() {
        JOptionPane.showMessageDialog(null, "备忘录系统\n版本 1.0\n© 2024 Moonshot AI\n开发者：李嘉诚，梁宇，马祺言");
    }

    public void undo() {
        if (undoManager.canUndo()) {
            undoManager.undo();
        }
    }
    public void redo() {
        if (undoManager.canRedo()) {
            undoManager.redo();
        }
    }

}