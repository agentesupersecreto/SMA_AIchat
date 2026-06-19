using System;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem.ChatMapper;
using UnityEngine;

namespace PixelCrushers.DialogueSystem
{
	// Token: 0x02000016 RID: 22
	[Serializable]
	public class Actor : Asset
	{
		// Token: 0x06000132 RID: 306 RVA: 0x00005CCC File Offset: 0x00003ECC
		public Actor()
		{
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00005CE0 File Offset: 0x00003EE0
		public Actor(Actor sourceActor)
			: base(sourceActor)
		{
			this.portrait = sourceActor.portrait;
			this.alternatePortraits = new List<Texture2D>(sourceActor.alternatePortraits);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00005D14 File Offset: 0x00003F14
		public Actor(Actor chatMapperActor)
		{
			this.Assign(chatMapperActor);
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000135 RID: 309 RVA: 0x00005D30 File Offset: 0x00003F30
		// (set) Token: 0x06000136 RID: 310 RVA: 0x00005D40 File Offset: 0x00003F40
		public bool IsPlayer
		{
			get
			{
				return base.LookupBool("IsPlayer");
			}
			set
			{
				Field.SetValue(this.fields, "IsPlayer", value);
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000137 RID: 311 RVA: 0x00005D54 File Offset: 0x00003F54
		// (set) Token: 0x06000138 RID: 312 RVA: 0x00005D5C File Offset: 0x00003F5C
		public string TextureName
		{
			get
			{
				return this.LookupTextureName();
			}
			set
			{
				this.SetTextureName(value);
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x00005D68 File Offset: 0x00003F68
		public void Assign(Actor chatMapperActor)
		{
			if (chatMapperActor != null)
			{
				base.Assign(chatMapperActor.ID, chatMapperActor.Fields);
			}
		}

		// Token: 0x0600013A RID: 314 RVA: 0x00005D84 File Offset: 0x00003F84
		public Texture2D GetPortraitTexture(int i)
		{
			if (i == 1)
			{
				return this.portrait;
			}
			int num = i - 2;
			return (0 > num || num >= this.alternatePortraits.Count) ? null : this.alternatePortraits[num];
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00005DD0 File Offset: 0x00003FD0
		private string LookupTextureName()
		{
			Field field = Field.Lookup(this.fields, "Pictures");
			if (field == null || field.value == null)
			{
				return null;
			}
			string[] array = field.value.Split(new char[] { '[', ';', ']' });
			return (array.Length < 2) ? null : array[1];
		}

		// Token: 0x0600013C RID: 316 RVA: 0x00005E34 File Offset: 0x00004034
		private void SetTextureName(string value)
		{
			Field.SetValue(this.fields, "Pictures", "[" + value + "]");
		}

		// Token: 0x0400006E RID: 110
		public Texture2D portrait;

		// Token: 0x0400006F RID: 111
		public List<Texture2D> alternatePortraits = new List<Texture2D>();
	}
}
