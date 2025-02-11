namespace HotChocolate.Fusion.Composition.Analyzers.Helpers;

public static class CodeWriterExtensions
{
    public static void WriteGeneratedAttribute(this CodeWriter writer)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }
        
#if DEBUG
        writer.WriteIndentedLine(
            "[global::System.CodeDom.Compiler.GeneratedCode(" + 
            "\"HotChocolate\", \"11.0.0\")]");
#else
        var version = typeof(CodeWriter).Assembly.GetName().Version!.ToString();
        writer.WriteIndentedLine(
            "[global::System.CodeDom.Compiler.GeneratedCode(" +
            $"\"HotChocolate\", \"{version}\")]");
#endif
    }

    public static void WriteFileHeader(this CodeWriter writer)
    {
        if (writer is null)
        {
            throw new ArgumentNullException(nameof(writer));
        }

        writer.WriteIndentedLine("// <auto-generated/>");
        writer.WriteLine();
        writer.WriteIndentedLine("#nullable enable");
    }

    public static CodeWriter WriteComment(this CodeWriter writer, string comment)
    {
        writer.Write("// ");
        writer.WriteLine(comment);
        return writer;
    }
}