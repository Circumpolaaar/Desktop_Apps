package org.example.ui;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.File;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.time.format.DateTimeFormatter;
import java.time.format.DateTimeParseException;
import java.util.List;

import javax.swing.JOptionPane;
import javax.swing.tree.DefaultMutableTreeNode;

import org.example.manager.MemoManager;
import org.example.model.Memo;
import org.example.model.TodoItem;
import org.example.util.MemoErrorHandler;
public class MemoListener {
    private MemoUI memoUI;
    private MemoManager memoManager;
    private MemoActions memoActions; // 添加MemoActions实例

    // 修改构造函数以接受MemoUI、MemoManager和MemoActions作为参数
    public MemoListener(MemoUI memoUI, MemoManager memoManager, MemoActions memoActions) {
        this.memoUI = memoUI;
        this.memoManager = memoManager;
        this.memoActions = memoActions; // 初始化MemoActions
    }

    public void initListeners() {

        memoUI.openItem.addActionListener(e -> showOpenDialog());
        memoUI.saveItem.addActionListener(e -> memoManager.save());
        memoUI.saveAsItem.addActionListener(e -> memoManager.saveAs());
        memoUI.newMemoItem.addActionListener(e -> createNewMemo()); // 新建备忘录事件处理
        memoUI.exitItem.addActionListener(e -> {
            int result = JOptionPane.showConfirmDialog(null, "确定要退出吗？",
                    "退出确认", JOptionPane.YES_NO_OPTION);
            if (result == JOptionPane.YES_OPTION) {
                System.exit(0);
            }
        });
        memoUI.copyItem.addActionListener(e -> {
            try {
                memoActions.copy(memoUI.getRichTextEditor().getTextPane());
            } catch (Exception ex) {
                MemoErrorHandler.handleError("复制操作失败。", ex);
            }
        });
        memoUI.cutItem.addActionListener(e -> {
            try {
                memoActions.cut(memoUI.getRichTextEditor().getTextPane());
            } catch (Exception ex) {
                MemoErrorHandler.handleError("剪切操作失败。", ex);
            }
        });
        memoUI.pasteItem.addActionListener(e -> {
            try {
                memoActions.paste(memoUI.getRichTextEditor().getTextPane());
            } catch (Exception ex) {
                MemoErrorHandler.handleError("粘贴操作失败。", ex);
            }
        });
        memoUI.aboutItem.addActionListener(e -> memoManager.about());
        memoUI.undoItem.addActionListener(e -> memoManager.undo());
        memoUI.redoItem.addActionListener(e -> memoManager.redo());

        // MemoListener.java 中添加或更新树节点选择事件
        memoUI.getCategoryTree().addTreeSelectionListener(e -> {
            DefaultMutableTreeNode selectedNode = (DefaultMutableTreeNode) memoUI.getCategoryTree().getLastSelectedPathComponent();
            try {
                if (selectedNode != null && !selectedNode.isRoot()) {
                    Object userObject = selectedNode.getUserObject();
                    if (userObject instanceof Memo) {
                        // 如果选中的是备忘录节点
                        Memo selectedMemo = (Memo) userObject;
                        StringBuilder details = new StringBuilder();
                        details.append("标题: ").append(selectedMemo.getTitle()).append("\n");
                        details.append("内容: ").append(selectedMemo.getContent()).append("\n");
                        details.append("分类: ").append(selectedMemo.getCategory()).append("\n");
                        details.append("创建时间: ").append(selectedMemo.getCreatedAt()).append("\n");
                        memoUI.getRichTextEditor().getTextPane().setText(details.toString());
                    } else if (userObject instanceof String) {
                        // 如果选中的是分类节点
                        String category = (String) userObject;
                        List<Memo> memosInCategory = memoManager.memoFolderMap.get(category);
                        if (memosInCategory != null) {
                            StringBuilder sb = new StringBuilder();
                            for (Memo memo : memosInCategory) {
                                sb.append("标题: ").append(memo.getTitle()).append("\n");
                                sb.append("内容: ").append(memo.getContent()).append("\n");
                                sb.append("分类: ").append(memo.getCategory()).append("\n");
                                sb.append("创建时间: ").append(memo.getCreatedAt()).append("\n\n");
                            }
                            memoUI.getRichTextEditor().getTextPane().setText(sb.toString());
                        } else {

                            memoUI.getRichTextEditor().getTextPane().setText("此分类下没有备忘录。");
                        }
                    }
                }
            } catch (Exception ex) {
                MemoErrorHandler.handleError("选择备忘录分类时发生错误。", ex);
            }
        });

        //添加文件夹树节点选择事件
        memoUI.getCategoryTree().addTreeSelectionListener(e -> {
            DefaultMutableTreeNode node = (DefaultMutableTreeNode) 
                memoUI.getCategoryTree().getLastSelectedPathComponent();
            if (node != null) {
                Object userObject = node.getUserObject();
                if (userObject instanceof File) {
                    File file = (File) userObject;
                    if (file.isFile()) {
                        memoManager.openFile(file);
                    }
                } else if (userObject instanceof Memo) {
                    // 原有的备忘录处理逻辑
                    Memo selectedMemo = (Memo) userObject;
                    memoUI.getRichTextEditor().getTextPane().setText(selectedMemo.getContent());
                }
            }
        });
        memoUI.getNewTodoItem().addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                createNewTodoItem();
            }
        });
    }
    private void createNewTodoItem() {
        String title = JOptionPane.showInputDialog(memoUI, "请输入待办事项标题:");
        if (title == null || title.isEmpty()) {
            return;
        }

        String dateTimeStr = JOptionPane.showInputDialog(memoUI, "请输入提醒时间 (yyyy-MM-dd HH:mm):");
        if (dateTimeStr == null || dateTimeStr.isEmpty()) {
            return;
        }

        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm");
        try {
            LocalDateTime remindTime = LocalDateTime.parse(dateTimeStr, formatter);
            TodoItem newItem = new TodoItem(title, remindTime);
            memoManager.addTodoItem(newItem);
            memoUI.updateTodoList();
        } catch (DateTimeParseException ex) {
            JOptionPane.showMessageDialog(memoUI, "时间格式不正确，请输入正确的格式 (yyyy-MM-dd HH:mm)。", "错误", JOptionPane.ERROR_MESSAGE);
        }
    }
    private void createNewMemo() {
        try {
            // 清空文本区域以创建新的备忘录
            memoUI.getRichTextEditor().getTextPane().setText("");

            // 创建一个新的备忘录对象并添加到备忘录管理器中
            Memo newMemo = new Memo("新建备忘录", "", "未分类"); // 假设默认标题和分类
            memoManager.addMemo(newMemo.getTitle(), newMemo.getContent(), newMemo.getCategory());

            // 更新UI，比如备忘录列表或树状结构
            memoUI.refreshCategoryTree();

            // 设置焦点到文本编辑器
            memoUI.getRichTextEditor().getTextPane().requestFocusInWindow();

        } catch (Exception ex) {
            MemoErrorHandler.handleError("创建新备忘录失败。", ex);
        }
    }
    private void showOpenDialog() {
        String[] options = {"打开文件", "打开文件夹"};
        int choice = JOptionPane.showOptionDialog(null,
            "请选择打开类型",
            "打开",
            JOptionPane.DEFAULT_OPTION,
            JOptionPane.QUESTION_MESSAGE,
            null,
            options,
            options[0]);

        if (choice == 0) {
            // 打开文件
            memoManager.open();
        } else if (choice == 1) {
            // 打开文件夹
            File directory = memoManager.openDirectory();
            if (directory != null) {
                memoUI.buildFileTree(directory);
            }
        }
    }
}