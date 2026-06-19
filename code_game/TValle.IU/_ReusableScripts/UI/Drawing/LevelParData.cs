using System;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using UnityEngine;

namespace Assets._ReusableScripts.UI.Drawing
{
	// Token: 0x0200006E RID: 110
	[Serializable]
	public class LevelParData : IMultipleValorElemento<int, float, string[]>, IMultipleValorElemento<int, float>, IMultipleValorElemento<int>, IMultipleValorElemento<int, float, string[], Color[]>
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0000783C File Offset: 0x00005A3C
		public LevelParData()
		{
		}

		// Token: 0x06000330 RID: 816 RVA: 0x00007861 File Offset: 0x00005A61
		public LevelParData(int MaxLevel, float Level)
		{
			this.maxLevel = MaxLevel;
			this.level = Level;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x00007894 File Offset: 0x00005A94
		public LevelParData(int MaxLevel, float Level, string[] InfoPerLevel)
		{
			this.maxLevel = MaxLevel;
			this.level = Level;
			this.infoPerLevel = InfoPerLevel;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000078CE File Offset: 0x00005ACE
		public LevelParData(int MaxLevel, float Level, Color[] ColorPerLevel)
		{
			this.maxLevel = MaxLevel;
			this.level = Level;
			this.colorPerLevel = ColorPerLevel;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x00007908 File Offset: 0x00005B08
		public LevelParData(int MaxLevel, float Level, string[] InfoPerLevel, Color[] ColorPerLevel)
		{
			this.maxLevel = MaxLevel;
			this.level = Level;
			this.infoPerLevel = InfoPerLevel;
			this.colorPerLevel = ColorPerLevel;
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000334 RID: 820 RVA: 0x00007955 File Offset: 0x00005B55
		int IMultipleValorElemento<int>.item1
		{
			get
			{
				return this.maxLevel;
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0000795D File Offset: 0x00005B5D
		float IMultipleValorElemento<int, float>.item2
		{
			get
			{
				return this.level;
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000336 RID: 822 RVA: 0x00007965 File Offset: 0x00005B65
		string[] IMultipleValorElemento<int, float, string[]>.item3
		{
			get
			{
				return this.infoPerLevel;
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0000796D File Offset: 0x00005B6D
		Color[] IMultipleValorElemento<int, float, string[], Color[]>.item4
		{
			get
			{
				return this.colorPerLevel;
			}
		}

		// Token: 0x0400013C RID: 316
		public int maxLevel = 1;

		// Token: 0x0400013D RID: 317
		public float level;

		// Token: 0x0400013E RID: 318
		public string[] infoPerLevel = Array.Empty<string>();

		// Token: 0x0400013F RID: 319
		public Color[] colorPerLevel = Array.Empty<Color>();
	}
}
