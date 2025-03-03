package org.example.model;

import org.example.manager.MemoManager;

import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeModel;
import javax.swing.tree.MutableTreeNode;
import java.util.List;
import java.util.Map;

public class MemoTreeModel extends DefaultTreeModel {
    public MemoTreeModel(MemoManager memoManager) {
        super(buildTree(memoManager));
    }

    private static MutableTreeNode buildTree(MemoManager memoManager) {
        Map<String, List<Memo>> categories = memoManager.getAllMemosByCategories();
        DefaultMutableTreeNode root = new DefaultMutableTreeNode("备忘录");

        for (Map.Entry<String, List<Memo>> entry : categories.entrySet()) {
            DefaultMutableTreeNode categoryNode = new DefaultMutableTreeNode(entry.getKey());
            for (Memo memo : entry.getValue()) {
                categoryNode.add(new DefaultMutableTreeNode(memo)); // 确保这里传入的是 Memo 对象
            }
            root.add(categoryNode);
        }

        return root;
    }
}