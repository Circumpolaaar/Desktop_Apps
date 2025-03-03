// AdvancedSearchManager.java
package org.example.manager;

import org.example.model.Memo;
import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

public class AdvancedSearchManager {
    private List<String> searchHistory = new ArrayList<>();

    // 按日期、分类、标签进行搜索
    public List<Memo> searchMemos(List<Memo> memos, LocalDateTime startDate, LocalDateTime endDate, String category, String tag) {
        List<Memo> results = new ArrayList<>();
        for (Memo memo : memos) {
            if ((startDate == null || !memo.getCreatedAt().isBefore(startDate)) &&
                    (endDate == null || !memo.getCreatedAt().isAfter(endDate)) &&
                    (category == null || memo.getCategory().equals(category)) &&
                    (tag == null || memo.getContent().contains(tag))) {
                results.add(memo);
            }
        }
        return results;
    }

    // 添加搜索历史
    public void addSearchHistory(String query) {
        searchHistory.add(query);
    }

    // 获取搜索历史
    public List<String> getSearchHistory() {
        return searchHistory;
    }
}