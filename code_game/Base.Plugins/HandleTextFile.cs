using System;
using System.IO;

// Token: 0x0200000B RID: 11
public class HandleTextFile
{
	// Token: 0x06000045 RID: 69 RVA: 0x00004645 File Offset: 0x00002845
	public static void WriteTextFile(string filePath, string text)
	{
		File.WriteAllText(filePath, text);
	}
}
