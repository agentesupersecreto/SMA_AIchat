using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NodeEditorFramework.Utilities
{
	// Token: 0x0200009E RID: 158
	public static class ResourceManager
	{
		// Token: 0x060004BE RID: 1214 RVA: 0x00015322 File Offset: 0x00013522
		public static void SetDefaultResourcePath(string defaultResourcePath)
		{
			ResourceManager._ResourcePath = defaultResourcePath;
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x0001532C File Offset: 0x0001352C
		public static string PreparePath(string path)
		{
			path = path.Replace(Application.dataPath, "Assets");
			if (Application.isPlaying)
			{
				if (path.Contains("Resources"))
				{
					path = path.Substring(path.LastIndexOf("Resources") + 10);
				}
				path = path.Substring(0, path.LastIndexOf('.'));
				return path;
			}
			if (!path.StartsWith("Assets/"))
			{
				path = ResourceManager._ResourcePath + path;
			}
			return path;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000153A3 File Offset: 0x000135A3
		public static T[] LoadResources<T>(string path) where T : Object
		{
			path = ResourceManager.PreparePath(path);
			if (Application.isPlaying)
			{
				return Resources.LoadAll<T>(path);
			}
			return null;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000153BC File Offset: 0x000135BC
		public static T LoadResource<T>(string path) where T : Object
		{
			path = ResourceManager.PreparePath(path);
			if (Application.isPlaying)
			{
				return Resources.Load<T>(path);
			}
			return default(T);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000153E8 File Offset: 0x000135E8
		public static Texture2D LoadTexture(string texPath)
		{
			if (string.IsNullOrEmpty(texPath))
			{
				return null;
			}
			int num = ResourceManager.loadedTextures.FindIndex((ResourceManager.MemoryTexture memTex) => memTex.path == texPath);
			if (num != -1)
			{
				if (!(ResourceManager.loadedTextures[num].texture == null))
				{
					return ResourceManager.loadedTextures[num].texture;
				}
				ResourceManager.loadedTextures.RemoveAt(num);
			}
			Texture2D texture2D = ResourceManager.LoadResource<Texture2D>(texPath);
			ResourceManager.AddTextureToMemory(texPath, texture2D, Array.Empty<string>());
			return texture2D;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00015480 File Offset: 0x00013680
		public static Texture2D GetTintedTexture(string texPath, Color col)
		{
			string text = "Tint:" + col.ToString();
			Texture2D texture2D = ResourceManager.GetTexture(texPath, new string[] { text });
			if (texture2D == null)
			{
				texture2D = ResourceManager.LoadTexture(texPath);
				ResourceManager.AddTextureToMemory(texPath, texture2D, Array.Empty<string>());
				texture2D = RTEditorGUI.Tint(texture2D, col);
				ResourceManager.AddTextureToMemory(texPath, texture2D, new string[] { text });
			}
			return texture2D;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000154EC File Offset: 0x000136EC
		public static void AddTextureToMemory(string texturePath, Texture2D texture, params string[] modifications)
		{
			if (texture == null)
			{
				return;
			}
			ResourceManager.loadedTextures.Add(new ResourceManager.MemoryTexture(texturePath, texture, modifications));
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x0001550C File Offset: 0x0001370C
		public static ResourceManager.MemoryTexture FindInMemory(Texture2D tex)
		{
			int num = ResourceManager.loadedTextures.FindIndex((ResourceManager.MemoryTexture memTex) => memTex.texture == tex);
			if (num == -1)
			{
				return null;
			}
			return ResourceManager.loadedTextures[num];
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x00015550 File Offset: 0x00013750
		public static bool HasInMemory(string texturePath, params string[] modifications)
		{
			int num = ResourceManager.loadedTextures.FindIndex((ResourceManager.MemoryTexture memTex) => memTex.path == texturePath);
			return num != -1 && ResourceManager.EqualModifications(ResourceManager.loadedTextures[num].modifications, modifications);
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x000155A0 File Offset: 0x000137A0
		public static ResourceManager.MemoryTexture GetMemoryTexture(string texturePath, params string[] modifications)
		{
			List<ResourceManager.MemoryTexture> list = ResourceManager.loadedTextures.FindAll((ResourceManager.MemoryTexture memTex) => memTex.path == texturePath);
			if (list == null || list.Count == 0)
			{
				return null;
			}
			foreach (ResourceManager.MemoryTexture memoryTexture in list)
			{
				if (ResourceManager.EqualModifications(memoryTexture.modifications, modifications))
				{
					return memoryTexture;
				}
			}
			return null;
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00015630 File Offset: 0x00013830
		public static Texture2D GetTexture(string texturePath, params string[] modifications)
		{
			ResourceManager.MemoryTexture memoryTexture = ResourceManager.GetMemoryTexture(texturePath, modifications);
			if (memoryTexture != null)
			{
				return memoryTexture.texture;
			}
			return null;
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x00015650 File Offset: 0x00013850
		private static bool EqualModifications(string[] modsA, string[] modsB)
		{
			return modsA.Length == modsB.Length && Array.TrueForAll<string>(modsA, (string mod) => modsB.Count((string oMod) => mod == oMod) == modsA.Count((string oMod) => mod == oMod));
		}

		// Token: 0x04000146 RID: 326
		private static string _ResourcePath = "";

		// Token: 0x04000147 RID: 327
		private static List<ResourceManager.MemoryTexture> loadedTextures = new List<ResourceManager.MemoryTexture>();

		// Token: 0x020001C0 RID: 448
		public class MemoryTexture
		{
			// Token: 0x06000C42 RID: 3138 RVA: 0x000269C6 File Offset: 0x00024BC6
			public MemoryTexture(string texPath, Texture2D tex, params string[] mods)
			{
				this.path = texPath;
				this.texture = tex;
				this.modifications = mods;
			}

			// Token: 0x0400042C RID: 1068
			public string path;

			// Token: 0x0400042D RID: 1069
			public Texture2D texture;

			// Token: 0x0400042E RID: 1070
			public string[] modifications;
		}
	}
}
