using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000F3 RID: 243
	public static class Zipiry
	{
		// Token: 0x060006C6 RID: 1734 RVA: 0x00018AEC File Offset: 0x00016CEC
		public static byte[] Zip(string str)
		{
			byte[] array;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						using (GZipStream gzipStream = new GZipStream(memoryStream2, CompressionMode.Compress))
						{
							memoryStream.CopyTo(gzipStream);
						}
						array = memoryStream2.ToArray();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error ahead: Zip data");
				Debug.LogException(ex);
				array = null;
			}
			return array;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x00018B90 File Offset: 0x00016D90
		public static string Unzip(byte[] bytes)
		{
			string text;
			try
			{
				using (MemoryStream memoryStream = new MemoryStream(bytes))
				{
					using (MemoryStream memoryStream2 = new MemoryStream())
					{
						using (GZipStream gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
						{
							gzipStream.CopyTo(memoryStream2);
						}
						text = Encoding.UTF8.GetString(memoryStream2.ToArray());
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error ahead: Unzip data");
				Debug.LogException(ex);
				text = null;
			}
			return text;
		}
	}
}
