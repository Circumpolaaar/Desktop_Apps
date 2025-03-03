package org.example.expansion;
import java.awt.event.ComponentAdapter;
import java.awt.event.ComponentEvent;
import javax.swing.*;
import javax.swing.border.EmptyBorder;
import javax.swing.text.*;
import java.awt.*;

public class RichTextEditor extends JFrame {

    private JTextPane textPane;
    
    private JScrollPane scrollPane;
    private JSpinner fontSizeSpinner; 
    private Style defaultStyle; // 用于存储默认样式

    public RichTextEditor() {
        setTitle("富文本编辑器");
        setSize(800, 600);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        Color TextColor = new Color(0xff,0xfb,0xf0);

        // 创建工具栏
        JToolBar toolBar = new JToolBar();
        toolBar.setFloatable(false);
        toolBar.setLayout(new GridBagLayout());
        GridBagConstraints gbc = new GridBagConstraints();

        Color ToolColor = new Color(0x2b,0x31,0x3f);
        Color spinnerBackground = new Color(0x2b, 0x31, 0x3f);
        Color spinnerForeground = new Color(0xff, 0xfb, 0xf0);
        toolBar.setBackground(ToolColor);
        

        // 字体选择
        String[] fonts = {"宋体", "微软雅黑", "Times New Roman", "Arial"};
        JComboBox<String> fontCombo = new JComboBox<>(fonts);
      
        fontCombo.addActionListener(e -> changeFontFamily((String) fontCombo.getSelectedItem()));
        toolBar.add(fontCombo);

        fontCombo.setBackground(TextColor);
        fontCombo.setForeground(ToolColor);
        UIManager.put("ComboBox.selectionBackground",new Color(0x2b,0x31,0x3f) );
        UIManager.put("ComboBox.selectionForeground", new Color(0xff,0xfb,0xf0));
        //分不开按钮和框
        //  customizeComboBox(fontCombo, spinnerBackground, spinnerForeground, Color.WHITE, spinnerBackground);
        gbc.fill = GridBagConstraints.HORIZONTAL;
        gbc.weightx = 2;
        gbc.gridx = 0;
        toolBar.add(fontCombo, gbc);

        // 字体大小
        fontSizeSpinner = new JSpinner(new SpinnerNumberModel(12, 1, 72, 1));
        fontSizeSpinner.setBackground(new Color(0x2b, 0x31, 0x3f));
        fontSizeSpinner.setForeground(new Color(0xff, 0xfb, 0xf0));

        JComponent editor = fontSizeSpinner.getEditor();
        if (editor instanceof JSpinner.DefaultEditor) {
            JFormattedTextField textField = ((JSpinner.DefaultEditor) editor).getTextField();
            textField.setBackground(fontSizeSpinner.getBackground());
            textField.setForeground(fontSizeSpinner.getForeground());
        }

        Component[] components = fontSizeSpinner.getComponents();
        for (Component component : components) {
            if (component instanceof JButton) {
                JButton button = (JButton) component;
                button.setBackground(fontSizeSpinner.getBackground());
                button.setForeground(fontSizeSpinner.getForeground());
            }
        }

        // 添加 ChangeListener
        fontSizeSpinner.addChangeListener(e -> changeFontSize());

        gbc.weightx = 2;
        gbc.gridx = 1;
        toolBar.add(fontSizeSpinner, gbc);
        
        // 字体颜色
        JButton colorButton = new JButton("字体颜色");
        colorButton.addActionListener(e -> changeFontColor());
        toolBar.add(colorButton);
        colorButton.setBackground(ToolColor);
        colorButton.setForeground(TextColor);
        gbc.weightx = 1; 
        gbc.gridx = 2;
        toolBar.add(colorButton, gbc);

        // 背景颜色
        JButton bgColorButton = new JButton("背景颜色");
        bgColorButton.addActionListener(e -> changeBackgroundColor());
        toolBar.add(bgColorButton);
        bgColorButton.setBackground(ToolColor);
        bgColorButton.setForeground(TextColor);
        gbc.weightx = 1; 
        gbc.gridx = 3;
        toolBar.add(bgColorButton, gbc);

        // 加粗
        JButton boldButton = new JButton("加粗");
        boldButton.addActionListener(e -> toggleBold());
        toolBar.add(boldButton);
        boldButton.setBackground(ToolColor);
        boldButton.setForeground(TextColor);
        gbc.weightx = 1; 
        gbc.gridx = 4;
        toolBar.add(boldButton, gbc);  

        // 斜体
        JButton italicButton = new JButton("斜体");
        italicButton.addActionListener(e -> toggleItalic());
        toolBar.add(italicButton);
        italicButton.setBackground(ToolColor);
        italicButton.setForeground(TextColor);
        gbc.weightx = 1;
        gbc.gridx = 5;
        toolBar.add(italicButton, gbc);

        // 下划线
        JButton underlineButton = new JButton("下划线");
        underlineButton.addActionListener(e -> toggleUnderline());
        toolBar.add(underlineButton);
        underlineButton.setBackground(ToolColor);
        underlineButton.setForeground(TextColor);
        gbc.weightx = 1;
        gbc.gridx = 6;
        toolBar.add(underlineButton, gbc);

        // 创建文本区域
        textPane = new JTextPane();
        JScrollPane scrollPane = new JScrollPane(textPane);
        scrollPane.setHorizontalScrollBarPolicy(JScrollPane.HORIZONTAL_SCROLLBAR_AS_NEEDED);
        scrollPane.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_AS_NEEDED);
        
        
        textPane.setBackground(TextColor);
        
        // 设置默认样式
        StyledDocument doc = textPane.getStyledDocument();
        defaultStyle = textPane.addStyle("Default Style", null);
        applyDefaultStyle(defaultStyle);

        // 设置布局
        JPanel panel = new JPanel(new BorderLayout());
        panel.setBorder(new EmptyBorder(10, 10, 10, 10));
        panel.add(toolBar, BorderLayout.NORTH);
        panel.add(scrollPane, BorderLayout.CENTER);

        this.addComponentListener(new ComponentAdapter() {
            @Override
            public void componentResized(ComponentEvent e) {
                adjustTextPaneSize();
            }
        });
        setContentPane(panel);
        
    }

    private void changeFontFamily(String fontFamily) {
        StyledDocument doc = textPane.getStyledDocument();
        int start = textPane.getSelectionStart();
        int end = textPane.getSelectionEnd();
    
        if (start == end) { // 没有选中文本
            return;
        }
    
        AttributeSet attrs = doc.getCharacterElement(start).getAttributes();
    
        Style style = doc.addStyle("tempStyle", null);
        StyleConstants.setFontFamily(style, fontFamily);
        style.setResolveParent(attrs);
    
        doc.setCharacterAttributes(start, end - start, style, false);
        doc.removeStyle("tempStyle");
    }
    
    private void changeFontColor() {
        Color color = JColorChooser.showDialog(this, "选择字体颜色", Color.BLACK);
        if (color != null) {
            StyledDocument doc = textPane.getStyledDocument();
            int start = textPane.getSelectionStart();
            int end = textPane.getSelectionEnd();
    
            if (start == end) {
                return;
            }
    
            // 创建一个基于默认样式的新样式
            Style style = doc.addStyle(null, defaultStyle);
            StyleConstants.setForeground(style, color);
            
            // 应用新样式到选中的文本
            doc.setCharacterAttributes(start, end - start, style, false);
        }
    }
    private void changeFontSize() {
        if (fontSizeSpinner == null) {
            throw new IllegalStateException("fontSizeSpinner is not initialized");
        }

        int newSize = (Integer) fontSizeSpinner.getValue();
        StyledDocument doc = textPane.getStyledDocument();
        int start = textPane.getSelectionStart();
        int end = textPane.getSelectionEnd();

        if (start == end) {
            return;
        }

        Style style = doc.addStyle(null, defaultStyle);
        StyleConstants.setFontSize(style, newSize);
        doc.setCharacterAttributes(start, end - start, style, false);
    }
    private void adjustTextPaneSize() {
        JViewport viewport = scrollPane.getViewport();
        if (viewport != null) {
            Dimension extentSize = viewport.getExtentSize();
            textPane.setMaximumSize(new Dimension(extentSize.width, extentSize.height));
            textPane.revalidate();
        }
    }
    private void changeBackgroundColor() {
        Color color = JColorChooser.showDialog(this, "选择背景颜色", Color.WHITE);
        if (color != null) {
            StyledDocument doc = textPane.getStyledDocument();
            int start = textPane.getSelectionStart();
            int end = textPane.getSelectionEnd();
    
            // 如果没有文本被选中，则不执行任何操作
            if (start == end) {
                return;
            }
    
            // 创建一个基于默认样式的新样式
            Style style = doc.addStyle(null, defaultStyle);
            StyleConstants.setBackground(style, color);
    
            // 应用新样式到选中的文本
            doc.setCharacterAttributes(start, end - start, style, false);
        }
    }
    


private void toggleBold() {
    StyledDocument doc = textPane.getStyledDocument();
    int start = textPane.getSelectionStart();
    int end = textPane.getSelectionEnd();

    if (start == end) {
        return;
    }

    // 创建一个基于默认样式的新样式
    Style style = doc.addStyle(null, defaultStyle);
    StyleConstants.setBold(style, !StyleConstants.isBold(style));
    
    // 应用新样式到选中的文本
    doc.setCharacterAttributes(start, end - start, style, false);
}


private void toggleItalic() {
    StyledDocument doc = textPane.getStyledDocument();
    int start = textPane.getSelectionStart();
    int end = textPane.getSelectionEnd();

    if (start == end) {
        return;
    }

    // 创建一个基于默认样式的新样式
    Style style = doc.addStyle(null, defaultStyle);
    StyleConstants.setItalic(style, !StyleConstants.isItalic(style));
    
    // 应用新样式到选中的文本
    doc.setCharacterAttributes(start, end - start, style, false);
}
private void toggleUnderline() {
    StyledDocument doc = textPane.getStyledDocument();
    int start = textPane.getSelectionStart();
    int end = textPane.getSelectionEnd();

    if (start == end) {
        return;
    }

    // 创建一个基于默认样式的新样式
    Style style = doc.addStyle(null, defaultStyle);
    StyleConstants.setUnderline(style, !StyleConstants.isUnderline(style));
    
    // 应用新样式到选中的文本
    doc.setCharacterAttributes(start, end - start, style, false);
}

    private void applyDefaultStyle(Style style) {
        StyledDocument doc = textPane.getStyledDocument();
        doc.setCharacterAttributes(0, doc.getLength(), style, true);
    }

    public JTextPane getTextPane() {
        return textPane;
    }

    
    public void customizeComboBox(JComboBox<String> comboBox, Color textBackground, Color textForeground, Color buttonBackground, Color buttonForeground) {
        // 设置文本框（编辑器）的颜色
        Component editorComponent = comboBox.getEditor().getEditorComponent();
        if (editorComponent instanceof JTextField) {
            JTextField textField = (JTextField) editorComponent;
            textField.setBackground(textBackground);
            textField.setForeground(textForeground);
        }
    
        // 设置下拉按钮的颜色
        // 获取下拉按钮
        Component component = comboBox.getComponent(0); // 下拉按钮通常位于索引 0
        if (component instanceof JButton) {
            JButton button = (JButton) component;
            button.setBackground(buttonBackground);
            button.setForeground(buttonForeground);
        }
    
        // 设置 JComboBox 的整体颜色
        comboBox.setBackground(textBackground);
        comboBox.setForeground(textForeground);
    
        // 设置选中项的颜色
        UIManager.put("ComboBox.selectionBackground", textBackground);
        UIManager.put("ComboBox.selectionForeground", textForeground);
    }
    

}


