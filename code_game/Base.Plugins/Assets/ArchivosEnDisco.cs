using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
	// Token: 0x020000F1 RID: 241
	public static class ArchivosEnDisco
	{
		// Token: 0x06000699 RID: 1689 RVA: 0x00017DF5 File Offset: 0x00015FF5
		public static IEnumerator AsyncLoader(ArchivosEnDisco.AsyncLoaderOnErrorHandler onError, ArchivosEnDisco.AsyncLoaderOnCompletedHandler onComplete, object context, params IEnumerator[] loaders)
		{
			int num;
			for (int i = 0; i < loaders.Length; i = num + 1)
			{
				IEnumerator enumerator = loaders[i];
				Exception e = null;
				for (;;)
				{
					object obj;
					try
					{
						if (!enumerator.MoveNext())
						{
							break;
						}
						obj = enumerator.Current;
					}
					catch (Exception ex)
					{
						if (onError != null)
						{
							onError(context, i, ex);
						}
						e = ex;
						break;
					}
					yield return obj;
				}
				if (onComplete != null)
				{
					onComplete(context, i, e);
				}
				enumerator = null;
				e = null;
				num = i;
			}
			yield break;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00017E19 File Offset: 0x00016019
		public static string[] GetDllsExitentesPaths(GameFolders.Tipo tipo)
		{
			return (from f in ArchivosEnDisco.ExistentesDeepPorFechaModificacion(tipo, new string[] { ".dll" })
				select f.FullName).ToArray<string>();
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00017E58 File Offset: 0x00016058
		public static string[] GetCatalogosExitentesPaths(GameFolders.Tipo tipo)
		{
			return (from f in ArchivosEnDisco.ExistentesDeepPorFechaModificacion(tipo, new string[] { ".json" })
				select f.FullName).ToArray<string>();
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00017E98 File Offset: 0x00016098
		private static bool TryReadJson(FileInfo JsonFile, ref StringBuilder result)
		{
			bool flag;
			try
			{
				string text = File.ReadAllText(JsonFile.FullName);
				result = new StringBuilder(text);
				flag = true;
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x00017ED8 File Offset: 0x000160D8
		public static T GetOrSaveJsonZipped<T>(T data, GameFolders.Tipo tipo, string archivoNombre, string extencion)
		{
			bool flag;
			return ArchivosEnDisco.GetOrSaveJsonZipped<T>(data, tipo, archivoNombre, extencion, out flag);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00017EF0 File Offset: 0x000160F0
		public static T GetOrSaveJsonZipped<T>(T data, GameFolders.Tipo tipo, string archivoNombre, string extencion, out bool existia)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(GameFolders.Tipo.config, archivoNombre, extencion);
			bool flag = (existia = ArchivosEnDisco.Existe(text));
			if (flag)
			{
				string text2 = null;
				byte[] array = ArchivosEnDisco.LeerDesdeDisco(text);
				if (array != null)
				{
					text2 = Zipiry.Unzip(array);
				}
				if (text2 != null)
				{
					object obj = data;
					JsonUtility.FromJsonOverwrite(text2, obj);
					return (T)((object)obj);
				}
				flag = false;
			}
			if (!flag)
			{
				byte[] array2 = Zipiry.Zip(JsonUtility.ToJson(data));
				if (array2 != null)
				{
					ArchivosEnDisco.GuardarADisco(text, array2);
				}
				return data;
			}
			throw new ArgumentOutOfRangeException();
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00017F73 File Offset: 0x00016173
		public static string ObtenerFilePathDEBUG(string relativePath)
		{
			return Application.dataPath + relativePath.Replace("Assets", "");
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00017F8F File Offset: 0x0001618F
		public static string ObtenerFilePathDEBUG(string relativePath, string archivoNombre, string extencion)
		{
			return Path.Combine(Application.dataPath, relativePath.Replace("Assets", ""), archivoNombre + extencion);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00017FB4 File Offset: 0x000161B4
		public static string ObtenerFilePath(GameFolders.Tipo tipo, string archivoNombre, string extencion)
		{
			if (archivoNombre.Contains('/') || archivoNombre.Contains('\\'))
			{
				throw new NotSupportedException();
			}
			if (!extencion.StartsWith("."))
			{
				throw new NotSupportedException();
			}
			return Path.Combine(GameFolders.Obtener(tipo), archivoNombre + extencion);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x00018000 File Offset: 0x00016200
		public static string ObtenerFolderPath(GameFolders.Tipo tipo)
		{
			return GameFolders.Obtener(tipo);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x00018008 File Offset: 0x00016208
		public static bool Existe(string FilePath)
		{
			return File.Exists(FilePath);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x00018010 File Offset: 0x00016210
		public static bool Existe(GameFolders.Tipo tipo, string archivoNombre, string extencion)
		{
			return File.Exists(ArchivosEnDisco.ObtenerFilePath(tipo, archivoNombre, extencion));
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x00018020 File Offset: 0x00016220
		public static bool ExisteAny(GameFolders.Tipo tipo, string extencion)
		{
			return !string.IsNullOrEmpty(Directory.GetFiles(ArchivosEnDisco.ObtenerFolderPath(tipo)).FirstOrDefault((string p) => p.EndsWith(extencion)));
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00018060 File Offset: 0x00016260
		public static void CopyPaste(GameFolders.Tipo tipoSorce, string archivoNombreSorce, string extencionSorce, GameFolders.Tipo tipoDestino, string archivoNombreDestino, string extencionDestino)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(tipoSorce, archivoNombreSorce, extencionSorce);
			string text2 = ArchivosEnDisco.ObtenerFilePath(tipoDestino, archivoNombreDestino, extencionDestino);
			File.Copy(text, text2, true);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00018088 File Offset: 0x00016288
		public static string MasReciente(GameFolders.Tipo tipo, string extencion)
		{
			FileInfo fileInfo = (from p in new DirectoryInfo(ArchivosEnDisco.ObtenerFolderPath(tipo)).GetFiles()
				orderby p.LastWriteTime descending
				where p.FullName.EndsWith(extencion)
				select p).FirstOrDefault<FileInfo>();
			if (fileInfo == null)
			{
				return null;
			}
			return fileInfo.FullName;
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x000180F8 File Offset: 0x000162F8
		public static FileInfo[] ExistentesDeepPorFechaModificacion(GameFolders.Tipo tipo, params string[] extencions)
		{
			return (from f in new DirectoryInfo(ArchivosEnDisco.ObtenerFolderPath(tipo)).GetFiles("*.*", SearchOption.AllDirectories)
				where extencions.Contains(f.Extension)
				select f).ToArray<FileInfo>();
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00018140 File Offset: 0x00016340
		public static string[] ExistentesPorFechaModificacion(string extencion, out List<string> moved, params GameFolders.Tipo[] tipos)
		{
			Dictionary<string, GameFolders.Tipo> dictionary = new Dictionary<string, GameFolders.Tipo>();
			Func<FileInfo, bool> <>9__1;
			Func<FileInfo, string> <>9__2;
			foreach (GameFolders.Tipo tipo in tipos)
			{
				IEnumerable<FileInfo> enumerable = from p in new DirectoryInfo(ArchivosEnDisco.ObtenerFolderPath(tipo)).GetFiles()
					orderby p.LastWriteTime descending
					select p;
				Func<FileInfo, bool> func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = (FileInfo p) => p.FullName.EndsWith(extencion));
				}
				IEnumerable<FileInfo> enumerable2 = enumerable.Where(func);
				Func<FileInfo, string> func2;
				if ((func2 = <>9__2) == null)
				{
					func2 = (<>9__2 = (FileInfo p) => Path.GetFileName(p.FullName).Replace(extencion, ""));
				}
				foreach (string text in enumerable2.Select(func2))
				{
					if (!string.IsNullOrWhiteSpace(text) && !dictionary.ContainsKey(text))
					{
						dictionary.Add(text, tipo);
					}
				}
			}
			GameFolders.Tipo tipo2 = tipos[0];
			List<string> list = new List<string>();
			moved = new List<string>();
			foreach (KeyValuePair<string, GameFolders.Tipo> keyValuePair in dictionary)
			{
				if (keyValuePair.Value == tipo2)
				{
					list.Add(keyValuePair.Key);
				}
				else if (!ArchivosEnDisco.Existe(tipo2, keyValuePair.Key, extencion))
				{
					try
					{
						ArchivosEnDisco.CopyPaste(keyValuePair.Value, keyValuePair.Key, extencion, tipo2, keyValuePair.Key, extencion);
						list.Add(keyValuePair.Key);
						moved.Add(keyValuePair.Key);
					}
					catch (Exception ex)
					{
						Debug.LogError(string.Concat(new string[]
						{
							"No se pudo transferir archivo existente : ",
							keyValuePair.Key,
							extencion,
							" hacia carpeta: ",
							tipo2.ToString(),
							" desde carpeta: ",
							keyValuePair.Value.ToString()
						}));
						Debug.LogException(ex);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000183C8 File Offset: 0x000165C8
		public static void DoBackUp(GameFolders.Tipo tipo, string archivoNombre, string extencion)
		{
			string text = ArchivosEnDisco.ObtenerFilePath(tipo, archivoNombre, extencion);
			if (File.Exists(text))
			{
				File.Copy(text, ArchivosEnDisco.ObtenerFilePath(tipo, archivoNombre + ".BackUp", extencion), true);
			}
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00018400 File Offset: 0x00016600
		public static void GuardarADisco(string FilePath, byte[] byteArray)
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream(byteArray))
				{
					using (FileStream fileStream = new FileStream(FilePath, FileMode.Create))
					{
						memoryStream.CopyTo(fileStream);
						fileStream.Flush();
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error ahead: Saving To Disk: " + FilePath);
				Debug.LogException(ex);
			}
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00018484 File Offset: 0x00016684
		public static byte[] LeerDesdeDisco(string FilePath)
		{
			byte[] array2;
			try
			{
				byte[] array = null;
				using (Stream stream = File.OpenRead(FilePath))
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						stream.CopyTo(memoryStream);
						array = memoryStream.ToArray();
					}
				}
				array2 = array;
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Error ahead: Reading from Disk: " + FilePath);
				Debug.LogException(ex);
				array2 = null;
			}
			return array2;
		}

		// Token: 0x020001C9 RID: 457
		// (Invoke) Token: 0x06000C59 RID: 3161
		public delegate void AsyncLoaderOnErrorHandler(object context, int index, Exception e);

		// Token: 0x020001CA RID: 458
		// (Invoke) Token: 0x06000C5D RID: 3165
		public delegate void AsyncLoaderOnCompletedHandler(object context, int index, Exception e);
	}
}
