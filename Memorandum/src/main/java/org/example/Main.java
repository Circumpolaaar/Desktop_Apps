package org.example;

import org.example.manager.*;
import org.example.model.Memo;
import org.example.util.GlobalErrorHandler;

import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.Scanner;

public class Main {
    private static final int ADD_MEMO = 1;
    private static final int VIEW_ALL_MEMOS = 2;
    private static final int VIEW_SINGLE_MEMO = 3;
    private static final int MODIFY_MEMO = 4;
    private static final int DELETE_MEMO = 5;
    private static final int SEARCH_MEMO = 6;
    private static final int BACKUP_MEMOS = 7;
    private static final int RESTORE_MEMOS = 8;
    private static final int ADVANCED_SEARCH = 9;
    private static final int EXIT = 10;

    public static void main(String[] args) {
        Thread.setDefaultUncaughtExceptionHandler(new GlobalErrorHandler());

        MemoManager memoManager = new MemoManager();
        BackupManager backupManager = new BackupManager();
        AdvancedSearchManager searchManager = new AdvancedSearchManager();
        Scanner scanner = new Scanner(System.in);

        List<Memo> memos = Storage.loadMemos();
        memoManager.getAllMemos();

        while (true) {
            System.out.println("请选择操作: " +
                    ADD_MEMO + ". 添加 " +
                    VIEW_ALL_MEMOS + ". 查看全部 " +
                    VIEW_SINGLE_MEMO + ". 查看单个 " +
                    MODIFY_MEMO + ". 修改 " +
                    DELETE_MEMO + ". 删除 " +
                    SEARCH_MEMO + ". 搜索 " +
                    BACKUP_MEMOS + ". 备份备忘录 " +
                    RESTORE_MEMOS + ". 恢复备忘录 " +
                    ADVANCED_SEARCH + ". 高级搜索 " +
                    EXIT + ". 退出");

            int choice = getUserInput(scanner);

            switch (choice) {
                case ADD_MEMO:
                    addMemo(scanner, memoManager);
                    break;
                case VIEW_ALL_MEMOS:
                    viewAllMemos(memoManager);
                    break;
                case VIEW_SINGLE_MEMO:
                    viewSingleMemo(scanner, memoManager);
                    break;
                case MODIFY_MEMO:
                    modifyMemo(scanner, memoManager);
                    break;
                case DELETE_MEMO:
                    deleteMemo(scanner, memoManager);
                    break;
                case SEARCH_MEMO:
                    searchMemo(scanner, memoManager);
                    break;
                case BACKUP_MEMOS:
                    backupManager.backupMemos(memoManager.getAllMemos());
                    break;
                case RESTORE_MEMOS:
                    List<Memo> restoredMemos = backupManager.restoreMemos();
                    memoManager.getAllMemos();
                    System.out.println("备忘录数据恢复成功！");
                    break;
                case ADVANCED_SEARCH:
                    advancedSearch(scanner, memoManager, searchManager);
                    break;
                case EXIT:
                    Storage.saveMemos(memoManager.getAllMemos());
                    System.out.println("退出程序。");
                    scanner.close();
                    return;
                default:
                    System.out.println("无效的选择!");
            }
        }
    }


    private static int getUserInput(Scanner scanner) {
        while (true) {
            try {
                return Integer.parseInt(scanner.nextLine());
            } catch (NumberFormatException e) {
                System.out.println("请输入一个有效的数字！");
            }
        }
    }
    private static void advancedSearch(Scanner scanner, MemoManager memoManager, AdvancedSearchManager searchManager) {
        System.out.println("输入开始日期 (格式: yyyy-MM-dd HH:mm:ss):");
        LocalDateTime startDate = LocalDateTime.parse(scanner.nextLine(), DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
        System.out.println("输入结束日期 (格式: yyyy-MM-dd HH:mm:ss):");
        LocalDateTime endDate = LocalDateTime.parse(scanner.nextLine(), DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss"));
        System.out.println("输入分类:");
        String category = scanner.nextLine();
        System.out.println("输入标签:");
        String tag = scanner.nextLine();

        List<Memo> results = searchManager.searchMemos(memoManager.getAllMemos(), startDate, endDate, category, tag);
        if (results.isEmpty()) {
            System.out.println("没有找到匹配的备忘录。");
        } else {
            for (Memo memo : results) {
                System.out.println(memo);
            }
        }

        searchManager.addSearchHistory("日期: " + startDate + " - " + endDate + ", 分类: " + category + ", 标签: " + tag);
    }

    private static void addMemo(Scanner scanner, MemoManager memoManager) {
        System.out.println("输入标题:");
        String title = scanner.nextLine();
        System.out.println("输入内容:");
        String content = scanner.nextLine();
        System.out.println("输入分类:");
        String category = scanner.nextLine();

        memoManager.addMemo(title, content, category);
        System.out.println("备忘录添加成功！");
    }

    private static void viewAllMemos(MemoManager memoManager) {
        List<Memo> allMemos = memoManager.getAllMemos();
        if (allMemos.isEmpty()) {
            System.out.println("没有备忘录。");
        } else {
            for (int i = 0; i < allMemos.size(); i++) {
                System.out.println("备忘录 " + (i + 1) + ": \n" + allMemos.get(i));
            }
        }
    }

    private static void viewSingleMemo(Scanner scanner, MemoManager memoManager) {
        System.out.println("输入要查看的备忘录分类:");
        String category = scanner.nextLine();
        System.out.println("输入要查看的备忘录标题关键词:");
        String keyword = scanner.nextLine();
        List<Memo> memosInCategory = memoManager.getAllMemosByCategories().get(category);
        if (memosInCategory != null) {
            boolean found = false;
            for (Memo memo : memosInCategory) {
                if (memo.getTitle().contains(keyword)) {
                    System.out.println(memo);
                    found = true;
                    break;
                }
            }
            if (!found) {
                System.out.println("未找到包含关键词 \"" + keyword + "\" 的备忘录");
            }
        } else {
            System.out.println("未找到分类为 \"" + category + "\" 的备忘录");
        }
    }

    private static void modifyMemo(Scanner scanner, MemoManager memoManager) {
        System.out.println("输入要修改的备忘录分类:");
        String category = scanner.nextLine();
        System.out.println("输入要修改的备忘录标题关键词:");
        String keyword = scanner.nextLine();
        List<Memo> memosInCategory = memoManager.getAllMemosByCategories().get(category);
        if (memosInCategory != null) {
            boolean found = false;
            for (Memo memo : memosInCategory) {
                if (memo.getTitle().contains(keyword)) {
                    System.out.println("输入新标题:");
                    String newTitle = scanner.nextLine();
                    System.out.println("输入新内容:");
                    String newContent = scanner.nextLine();
                    System.out.println("输入新分类:");
                    String newCategory = scanner.nextLine();
                    memoManager.updateMemo(memo.getTitle(), newTitle, newContent, newCategory);
                    System.out.println("备忘录修改成功！");
                    found = true;
                    break;
                }
            }
            if (!found) {
                System.out.println("未找到包含关键词 \"" + keyword + "\" 的备忘录");
            }
        } else {
            System.out.println("未找到分类为 \"" + category + "\" 的备忘录");
        }
    }

    private static void deleteMemo(Scanner scanner, MemoManager memoManager) {
        System.out.println("输入要删除的备忘录分类:");
        String category = scanner.nextLine();
        System.out.println("输入要删除的备忘录标题关键词:");
        String keyword = scanner.nextLine();
        List<Memo> memosInCategory = memoManager.getAllMemosByCategories().get(category);
        if (memosInCategory != null) {
            boolean found = false;
            for (Memo memo : memosInCategory) {
                if (memo.getTitle().contains(keyword)) {
                    memoManager.deleteMemo(memo.getTitle());
                    System.out.println("备忘录删除成功！");
                    found = true;
                    break;
                }
            }
            if (!found) {
                System.out.println("未找到包含关键词 \"" + keyword + "\" 的备忘录");
            }
        } else {
            System.out.println("未找到分类为 \"" + category + "\" 的备忘录");
        }
    }

    private static void searchMemo(Scanner scanner, MemoManager memoManager) {
        System.out.println("输入搜索关键字:");
        String keyword = scanner.nextLine();
        List<Memo> searchResults = memoManager.searchMemos(keyword);
        if (searchResults.isEmpty()) {
            System.out.println("没有找到匹配的备忘录。");
        } else {
            for (Memo searchedMemo : searchResults) {
                System.out.println(searchedMemo);
            }
        }
    }
}



