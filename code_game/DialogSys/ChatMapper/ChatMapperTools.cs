using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

namespace PixelCrushers.DialogueSystem.ChatMapper
{
	// Token: 0x02000057 RID: 87
	public static class ChatMapperTools
	{
		// Token: 0x0600027A RID: 634 RVA: 0x0000D576 File Offset: 0x0000B776
		public static ChatMapperProject Load(TextAsset xmlFile)
		{
			return new XmlSerializer(typeof(ChatMapperProject)).Deserialize(new StringReader(xmlFile.text)) as ChatMapperProject;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0000D59C File Offset: 0x0000B79C
		public static ChatMapperProject Load(string filename)
		{
			return new XmlSerializer(typeof(ChatMapperProject)).Deserialize(new StreamReader(filename)) as ChatMapperProject;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0000D5C0 File Offset: 0x0000B7C0
		public static void Save(ChatMapperProject chatMapperProject, string filename)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ChatMapperProject));
			StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.Unicode);
			xmlSerializer.Serialize(streamWriter, chatMapperProject);
			streamWriter.Close();
		}
	}
}
