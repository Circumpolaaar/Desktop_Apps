package org.example.expansion;

import com.vladsch.flexmark.html.HtmlRenderer;
import com.vladsch.flexmark.parser.Parser;
import com.vladsch.flexmark.util.ast.Document;
import com.vladsch.flexmark.util.data.MutableDataSet;
import com.vladsch.flexmark.ext.tables.TablesExtension;
import com.vladsch.flexmark.ext.gfm.strikethrough.StrikethroughExtension;
import com.vladsch.flexmark.ext.gfm.tasklist.TaskListExtension;
import com.vladsch.flexmark.ext.autolink.AutolinkExtension;

import java.util.Arrays;

public class MarkdownParser {
    private static final MutableDataSet options = new MutableDataSet();
    private static final Parser parser;
    private static final HtmlRenderer renderer;

    static {
        // 启用表格、代码块高亮等扩展
        options.set(Parser.EXTENSIONS, Arrays.asList(
                TablesExtension.create(),

                AutolinkExtension.create(),
                StrikethroughExtension.create(),
                TaskListExtension.create()
        ));

        parser = Parser.builder(options).build();
        renderer = HtmlRenderer.builder(options).build();
    }

    public static String parseMarkdown(String markdown) {
        Document document = parser.parse(markdown);
        return renderer.render(document);
    }
}