package org.example.ui;

import java.awt.*;
import java.awt.image.BufferedImage;
import javax.imageio.ImageIO;
import java.io.File;
import java.io.IOException;
import java.awt.event.ActionEvent;
import java.awt.event.KeyEvent;
import java.io.File;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.ResourceBundle;
import java.util.stream.Collectors;
import org.example.manager.MemoManager;
import org.example.model.Memo;
import org.example.expansion.MarkdownParser;

import javax.imageio.ImageIO;
import javax.swing.*;
import javax.swing.text.html.HTMLEditorKit;
import javax.swing.text.html.StyleSheet;
import javax.swing.BorderFactory;
import javax.swing.DefaultListModel;
import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JComponent;
import javax.swing.JFileChooser;
import javax.swing.JFrame;
import javax.swing.JList;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPopupMenu;
import javax.swing.JScrollPane;
import javax.swing.JSplitPane;
import javax.swing.JTree;
import javax.swing.KeyStroke;
import javax.swing.SwingUtilities;
import javax.swing.UIManager;
import javax.swing.border.Border;
import javax.swing.border.EmptyBorder;
import javax.swing.border.EtchedBorder;
import javax.swing.tree.DefaultMutableTreeNode;
import javax.swing.tree.DefaultTreeCellRenderer;
import javax.swing.tree.DefaultTreeModel;

import org.example.expansion.RichTextEditor;
import org.example.model.MemoTreeModel;
import org.example.model.TodoItem;
import org.example.util.ReminderService;

public class MemoUI extends JFrame {
    private RichTextEditor richTextEditor; // 使用RichTextEditor替换JTextArea
    private JMenuBar menuBar;
    private ReminderService reminderService;
    private JButton newTodoItemButton;
    private JList<TodoItem> todoListPanel;
    private DefaultListModel<TodoItem> todoListModel;
    private JMenu fileMenu, editMenu, aboutMenu,toolsMenu;
    public JMenuItem openItem,newTodoItem, saveItem, saveAsItem, searchItem,newMemoItem;
    private JTree categoryTree;
    private DefaultTreeModel treeModel;
    private MemoManager memoManager; // 添加对MemoManager的引用
    private JMenuItem openFolderItem;
    public JMenuItem newFolderItem,exitItem, copyItem, cutItem, pasteItem, aboutItem,languageItem;
    private JButton searchButton;
    private DefaultMutableTreeNode fileTreeRoot;//文件夹根结点，用于实现文件夹树（和备忘录分类树是两个树状系统）
    public JMenuItem undoItem, redoItem;
    private MemoUI memoUI;
    private JTextPane textPane;
    private Component textScrollPane;
    private ResourceBundle bundle;


    public MemoUI(MemoManager memoManager) {
        this.memoManager = memoManager; // 初始化MemoManager
        this.reminderService = new ReminderService(memoManager,memoUI);
        this.bundle = ResourceBundle.getBundle("Messages", Locale.getDefault());
        initializeUI();
        initializeTodoPanel();
    }

    public void openFolder() {
        JFileChooser fileChooser = new JFileChooser();
        fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        int result = fileChooser.showOpenDialog(this);
        if (result == JFileChooser.APPROVE_OPTION) {
            File selectedFolder = fileChooser.getSelectedFile();
            // 这里可以添加代码来处理打开文件夹后的逻辑，例如更新备忘录列表
            JOptionPane.showMessageDialog(this, "打开文件夹: " + selectedFolder.getAbsolutePath());
        }
    }
    public void createNewFolder() {
        JFileChooser fileChooser = new JFileChooser();
        fileChooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);
        if (fileChooser.showSaveDialog(this) == JFileChooser.APPROVE_OPTION) {
            File newFolder = fileChooser.getSelectedFile();
            if (!newFolder.exists()) {
                boolean created = newFolder.mkdir();
                if (created) {
                    JOptionPane.showMessageDialog(this, "新建文件夹: " + newFolder.getAbsolutePath());
                    // 更新备忘录分类树
                    refreshCategoryTree();
                } else {
                    JOptionPane.showMessageDialog(this, "创建文件夹失败", "错误", JOptionPane.ERROR_MESSAGE);
                }
            }
        }
    }

    private void initializeUI() {
        setTitle("Memory your life");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLocationRelativeTo(null);
        categoryTree = new JTree(new MemoTreeModel(memoManager));
        richTextEditor = new RichTextEditor();
        // 创建文本区域并设置为HTML模式
        textPane = new JTextPane();
        textPane.setContentType("text/html");
        textPane.setEditable(false);

        // 设置HTML样式表
        HTMLEditorKit kit = new HTMLEditorKit();
        textPane.setEditorKit(kit);
        StyleSheet styleSheet = kit.getStyleSheet();
        styleSheet.addRule("body { font-family: Arial, sans-serif; }");
        styleSheet.addRule("h1, h2, h3, h4, h5, h6 { color: #333; }");
        styleSheet.addRule("a { color: #0077cc; }");
        styleSheet.addRule("table, th, td { border: 1px solid black; border-collapse: collapse; }");
        styleSheet.addRule("th, td { padding: 8px; text-align: left; }");
        styleSheet.addRule("code { background-color: #f0f0f0; padding: 2px; }");
        styleSheet.addRule("pre { background-color: #f0f0f0; padding: 10px; }");

        JScrollPane textScrollPane = new JScrollPane(textPane);
        // 创建备忘录分类树
        treeModel = new DefaultTreeModel(buildTreeModel());
        categoryTree = new JTree(treeModel);
        JScrollPane treeScrollPane = new JScrollPane(categoryTree);
        treeScrollPane.setPreferredSize(new Dimension(160, 600));

        // 设置布局
        JSplitPane splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, treeScrollPane, textScrollPane);
        add(splitPane, BorderLayout.CENTER);
        // 初始化富文本编辑器
        richTextEditor = new RichTextEditor();
        JScrollPane scrollPane = new JScrollPane(richTextEditor.getContentPane());

        File file = new File("textPanel.jpg");
        File file2;
        if (file.exists()) {
            System.out.println("File path: " + file.getAbsolutePath());

            file2 = new File(file.getAbsolutePath());

            try {
                // 使用 ImageIO 读取 WebP 图像
                BufferedImage image = ImageIO.read(file);
                if (image == null) {
                    System.out.println("Failed to read the image, possibly due to format not being supported.");

                }else {
                    System.out.println(image.getSource());

                    // 创建 ImageIcon 实例并设置图像
                    ImageIcon imageIcon = new ImageIcon(image);
                    // 创建 JLabel 实例并设置图像

                    JLabel label = new JLabel(imageIcon);

                    Dimension size = new Dimension(30, 30); // width 和 height 是你想要的大小
                    label.setPreferredSize(size);
                    label.setMinimumSize(size);
                    label.setMaximumSize(size);

                    JLayeredPane layeredPane =new JLayeredPane();
                    layeredPane.add(label, JLayeredPane.DRAG_LAYER);
                    textScrollPane.setViewportView(layeredPane);
                    // 将 JLabel 添加到 JPanel
                    JComponent contentComponent = new JComponent() {
                        protected void paintComponent(Graphics g) {
                            super.paintComponent(g);
                            // 在这里绘制你的底层内容
                        }
                    };
                    layeredPane.add(contentComponent, JLayeredPane.DEFAULT_LAYER);

                    textScrollPane.add(label);
                }
            } catch (IOException e) {
                System.out.println("11");
            }
        }
        File file1 = new File("treePanel.webp");
        File file3;
        if (!file1.exists()) {
            file3 = new File(file1.getAbsolutePath());

            try {
            // 使用 ImageIO 读取 WebP 图像
            BufferedImage image = ImageIO.read(file3);
            // 创建 ImageIcon 实例并设置图像
            ImageIcon imageIcon = new ImageIcon(image);
            // 创建 JLabel 实例并设置图像
            JLabel label = new JLabel(imageIcon);

            // 将 JLabel 添加到 JPanel
            treeScrollPane.add(label);
        } catch (IOException e) {
            e.printStackTrace();
        }
        }



        menuBar = new JMenuBar();
        fileMenu = new JMenu("文件");
        editMenu = new JMenu("编辑");
        aboutMenu = new JMenu("关于");

        openItem = new JMenuItem("打开", KeyEvent.VK_O);
        openItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_O, ActionEvent.CTRL_MASK));
        saveItem = new JMenuItem("保存文件", KeyEvent.VK_S);
        saveItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S, ActionEvent.CTRL_MASK));
        saveAsItem = new JMenuItem("另存为", KeyEvent.VK_S);
        saveAsItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_S, ActionEvent.CTRL_MASK | ActionEvent.SHIFT_MASK));
        newMemoItem = new JMenuItem("新建文件", KeyEvent.VK_N);
        newMemoItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_N, ActionEvent.CTRL_MASK));
        exitItem = new JMenuItem("退出", KeyEvent.VK_Q);
        exitItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_Q, ActionEvent.CTRL_MASK)); // 新建备忘录菜单项

        copyItem = new JMenuItem("复制", KeyEvent.VK_C);
        copyItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_C, ActionEvent.CTRL_MASK));
        cutItem = new JMenuItem("剪切", KeyEvent.VK_X);
        cutItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_X, ActionEvent.CTRL_MASK));
        pasteItem = new JMenuItem("粘贴", KeyEvent.VK_V);
        pasteItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_V, ActionEvent.CTRL_MASK));
        aboutItem = new JMenuItem("关于");
        undoItem = new JMenuItem("撤销");
        undoItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_Z, ActionEvent.CTRL_MASK));
        redoItem = new JMenuItem("重做");
        redoItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_Y, ActionEvent.CTRL_MASK));

        searchItem = new JMenuItem("搜索");
        searchItem.addActionListener(e -> showSearchDialog());
        newTodoItem = new JMenuItem("创建待办事项");

        JPanel searchPanel = new JPanel();
        searchPanel.add(searchItem);
        this.add(searchPanel, BorderLayout.SOUTH);

        fileMenu.add(openItem);
        fileMenu.add(saveItem);
        fileMenu.add(saveAsItem);
        fileMenu.add(newMemoItem); // 添加新建备忘录菜单项
        fileMenu.addSeparator();
        fileMenu.add(exitItem);
        fileMenu.addSeparator();

        editMenu.add(copyItem);
        editMenu.add(cutItem);
        editMenu.add(pasteItem);
        editMenu.add(undoItem); // 将撤销添加到编辑菜单
        editMenu.add(redoItem); // 将重做添加到编辑菜单
        aboutMenu.add(aboutItem);

        toolsMenu = new JMenu("工具");
        toolsMenu.add(newTodoItem);
        toolsMenu.add(searchItem);
        languageItem = new JMenuItem("语言");
        languageItem.addActionListener(e -> changeLanguage());

        toolsMenu.add(languageItem);
        menuBar.add(fileMenu);
        menuBar.add(editMenu);
        menuBar.add(aboutMenu);
        menuBar.add(toolsMenu);
        setJMenuBar(menuBar);

        //JMenuBar
        menuBar.setOpaque(true);
        menuBar.setBorder(new EmptyBorder(0, 0, 0, 0));
        menuBar.setSize(new Dimension(10,10));
        menuBar.setBackground(new Color(0x21,0x39,0x5b));
        UIManager.put("MenuBar.font", new Font("微软雅黑", Font.PLAIN, 14));
        UIManager.put("MenuBar.foreground", Color.WHITE);

        //JMenu
        fileMenu.setBorder(new EmptyBorder(0, 2, 0, 2));
        editMenu.setBorder(new EmptyBorder(0, 2, 0, 2));
        aboutMenu.setBorder(new EmptyBorder(0, 2, 0, 2));
        UIManager.put("Menu.background", new Color(0x21,0x39,0x5b));
        UIManager.put("Menu.foreground", Color.WHITE);
        UIManager.put("Menu.font", new Font("微软雅黑", Font.PLAIN, 12));
        UIManager.put("Menu.selectionBackground", new Color(0xff,0xfb,0xf0));
        UIManager.put("Menu.selectionForeground", new Color(0x43,0x5f,0x87));

        //JMenuItem
        openItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        saveItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        saveAsItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        newMemoItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        exitItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        copyItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        cutItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        pasteItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        aboutItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        undoItem.setBorder(new EmptyBorder(0, 0, 0, 0)); 
        redoItem.setBorder(new EmptyBorder(0, 0, 0, 0)); 
        searchItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        newTodoItem.setBorder(new EmptyBorder(0, 0, 0, 0));
        UIManager.put("MenuItem.background", new Color(0x21,0x39,0x5b));
        UIManager.put("MenuItem.foreground", Color.WHITE);
        UIManager.put("MenuItem.font", new Font("微软雅黑", Font.PLAIN, 12));
        UIManager.put("MenuItem.selectionBackground", new Color(0xff,0xfb,0xf0));
        UIManager.put("MenuItem.selectionForeground", new Color(0x43,0x5f,0x87));


        treeModel = new DefaultTreeModel(buildTreeModel());
        categoryTree = new JTree(treeModel);
        treeScrollPane = new JScrollPane(categoryTree);
        treeScrollPane.setPreferredSize(new Dimension(160, 600));

        Color bgColor = new Color(0x21,0x39,0x5b);
        Color textColor = Color.WHITE; // 设置文本颜色


        // 设置richTextEditor的背景颜色
        JComponent richTextComponent = (JComponent) richTextEditor.getContentPane();
        richTextComponent.setBackground(bgColor);
        richTextComponent.setOpaque(true);


        // 设置treeScrollPane的背景颜色
        treeScrollPane.getViewport().setBackground(bgColor);
        categoryTree.setBackground(bgColor);
        categoryTree.setOpaque(true);

        // 设置scrollPane的背景颜色
        // scrollPane.getViewport().setBackground(bgColor);
        scrollPane.getViewport().setOpaque(true);

        // 设置整个内容面板的背景颜色
        getContentPane().setBackground(bgColor);

        DefaultTreeCellRenderer renderer = new DefaultTreeCellRenderer() {
            private final ImageIcon folderIcon = new ImageIcon("folde.png");
            private final ImageIcon fileIcon = new ImageIcon("file.png");

            public Component getTreeCellRendererComponent(JTree tree, Object value, boolean sel, boolean expanded, boolean leaf, int row, boolean hasFocus) {
                super.getTreeCellRendererComponent(tree, value, sel, expanded, leaf, row, hasFocus);
                setBackgroundNonSelectionColor(bgColor);
                setBackgroundSelectionColor(bgColor.darker());
                setForeground(textColor); // 设置文本颜色
                setFont(new Font("微软雅黑", Font.PLAIN, 14));

                // 设置图标
                if (value instanceof DefaultMutableTreeNode) {
                    DefaultMutableTreeNode node = (DefaultMutableTreeNode) value;
                    Object userObject = node.getUserObject();
                    if (userObject instanceof File) {
                        File file = (File) userObject;
                        if (file.isDirectory()) {
                            setIcon(folderIcon);
                        } else {
                            setIcon(fileIcon);
                        }
                    }
                }
                return this;
            }
        };

        //设置边框
        Border etchedBorder = BorderFactory.createEtchedBorder(EtchedBorder.LOWERED);
        //scrollPane.setBorder(etchedBorder);
        scrollPane.setBorder(null);
        //treeScrollPane.setBorder(etchedBorder);
        treeScrollPane.setBorder(null);
        //richTextComponent.setBorder(etchedBorder);
        richTextComponent.setBorder(null);

        categoryTree.setCellRenderer(renderer);

        splitPane = new JSplitPane(JSplitPane.HORIZONTAL_SPLIT, treeScrollPane, scrollPane);
        add(splitPane, BorderLayout.CENTER);
        SwingUtilities.updateComponentTreeUI(this);
    }
    public void changeLanguage() {
        JPopupMenu languageMenu = new JPopupMenu();
        String[] languages = {"English", "简体中文", "Français", "繁體中文"};
        for (String lang : languages) {
            JMenuItem langItem = new JMenuItem(lang);
            langItem.addActionListener(e -> setLanguage(lang));
            languageMenu.add(langItem);
        }
        languageItem.setComponentPopupMenu(languageMenu);
    }

    private void setLanguage(String language) {
        Locale locale;
        switch (language) {
            case "English":
                locale = Locale.ENGLISH;
                break;
            case "简体中文":
                locale = Locale.CHINESE;
                break;
            case "Français":
                locale = Locale.FRENCH;
                break;
            case "繁體中文":
                locale = Locale.TRADITIONAL_CHINESE;
                break;
            default:
                locale = Locale.getDefault();
        }
        SwingUtilities.invokeLater(() -> {
            bundle = ResourceBundle.getBundle("Messages", locale);
            reloadLanguage(bundle);
        });
    }

    private void reloadLanguage(ResourceBundle bundle) {
        setTitle(bundle.getString("window.title"));
        fileMenu.setText(bundle.getString("menu.file"));
        editMenu.setText(bundle.getString("menu.edit"));
        aboutMenu.setText(bundle.getString("menu.about"));
        toolsMenu.setText(bundle.getString("menu.tools"));
        languageItem.setText(bundle.getString("menu.language"));
        newTodoItemButton.setText(bundle.getString("button.newTodo"));
        searchButton.setText(bundle.getString("button.search"));
    }

    public JMenuItem getNewTodoItem() {
        return newTodoItem;
    }

    private void initializeTodoPanel() {
        todoListModel = new DefaultListModel<>();
        todoListPanel = new JList<>(todoListModel);
        JScrollPane scrollPane = new JScrollPane(todoListPanel);
        scrollPane.setPreferredSize(new Dimension(160, 600));

        //JScrollPane
        scrollPane.getViewport().setBackground(new Color(0x21, 0x39, 0x5b));
        scrollPane.setOpaque(true);
       // scrollPane.setBorder(null);

        //todoListPanel
        todoListPanel.setOpaque(true);
        todoListPanel.setBackground(new Color(0x21, 0x39, 0x5b));


        this.add(scrollPane, BorderLayout.EAST);





    }


    public void updateTodoList() {
        List<TodoItem> todoItems = memoManager.getTodoItems();
        DefaultListModel<TodoItem> todoListModel = new DefaultListModel<>();
        for (TodoItem item : todoItems) {
            todoListModel.addElement(item);
        }
        JList<TodoItem> todoListPanel = new JList<>(todoListModel);
        JScrollPane scrollPane = new JScrollPane(todoListPanel);
        scrollPane.setPreferredSize(new Dimension(160, 600));
        this.add(scrollPane, BorderLayout.EAST);
    }

    private DefaultMutableTreeNode buildTreeModel() {
        DefaultMutableTreeNode root = new DefaultMutableTreeNode("备忘录");
        Map<String, List<Memo>> categories = memoManager.getAllMemosByCategories();
        for (Map.Entry<String, List<Memo>> entry : categories.entrySet()) {
            DefaultMutableTreeNode categoryNode = new DefaultMutableTreeNode(entry.getKey());
            for (Memo memo : entry.getValue()) {
                categoryNode.add(new DefaultMutableTreeNode(memo));
            }
            root.add(categoryNode);
        }
        return root;
    }
    public void displayMemo(Memo memo) {
        String markdown = memo.getContent();
        String html = MarkdownParser.parseMarkdown(markdown);
        textPane.setText(html);
    }
    public JTextPane getTextPane() {
        return textPane;
    }


    /**
     * 刷新备忘录分类树。
     */
    public void refreshCategoryTree() {
        DefaultMutableTreeNode root = buildTreeModel();
        treeModel.setRoot(root);
        categoryTree.repaint(); // 重新绘制树以显示更新
    }

    private void showSearchDialog() {
        String keyword = JOptionPane.showInputDialog(this, "请输入搜索关键词:");
        if (keyword != null && !keyword.isEmpty()) {
            List<Memo> searchResults = memoManager.searchMemos(keyword);
            String results = String.join("\n", searchResults.stream()
                    .map(memo -> "标题: " + memo.getTitle() + ", 分类: " + memo.getCategory() + ", 创建时间: " + memo.getCreatedAt())
                    .collect(Collectors.joining("\n")));
            JOptionPane.showMessageDialog(this, results, "搜索结果", JOptionPane.INFORMATION_MESSAGE);
        }
    }
    public RichTextEditor getRichTextEditor() {
        return richTextEditor;
    }

    public JTree getCategoryTree() {
        return categoryTree;
    }

    public JMenuItem getOpenFolderItem() {
        return openFolderItem;
    }

    public JMenuItem getNewFolderItem() {
        return newFolderItem;
    }
    public void buildFileTree(File directory) {
        fileTreeRoot = new DefaultMutableTreeNode(directory);
        if (directory.isDirectory()) {
            createFileNodes(directory, fileTreeRoot);
        }
        treeModel.setRoot(fileTreeRoot);
    }
    private void createFileNodes(File directory, DefaultMutableTreeNode node) {
        File[] files = directory.listFiles();
        if (files != null) {
            for (File file : files) {
                DefaultMutableTreeNode childNode = new DefaultMutableTreeNode(file);
                node.add(childNode);
                if (file.isDirectory()) {
                    createFileNodes(file, childNode);
                }
            }
        }
    }
}