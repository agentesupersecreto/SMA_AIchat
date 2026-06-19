using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.TValle.Tools.Runtime.Moddding
{
	// Token: 0x02000032 RID: 50
	public abstract class ModdingMap : ScriptableObject
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0000326E File Offset: 0x0000146E
		public string displayId
		{
			get
			{
				return this.m_displayId;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00003276 File Offset: 0x00001476
		public string id
		{
			get
			{
				return this.m_id;
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00003280 File Offset: 0x00001480
		public string GetIngameName(Language language)
		{
			bool flag;
			return this.GetIngameName(language, out flag);
		}

		// Token: 0x06000117 RID: 279 RVA: 0x00003298 File Offset: 0x00001498
		public string GetIngameName(Language language, out bool isPlural)
		{
			if (this.m_inGameNamesInitiated == null)
			{
				this.m_inGameNamesInitiated = new Dictionary<int, InGameName>();
				for (int i = 0; i < this.inGameNames.Count; i++)
				{
					InGameName inGameName = this.inGameNames[i];
					if (!this.m_inGameNamesInitiated.TryAdd((int)inGameName.language, inGameName))
					{
						Debug.LogError("There is more than one name for Language " + inGameName.language.ToString(), this);
					}
				}
			}
			InGameName inGameName2;
			if (this.m_inGameNamesInitiated.TryGetValue((int)language, out inGameName2) || this.m_inGameNamesInitiated.TryGetValue(1, out inGameName2))
			{
				isPlural = inGameName2.isPlural;
				return inGameName2.name;
			}
			isPlural = false;
			return this.fullName;
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00003348 File Offset: 0x00001548
		protected virtual void OnValidate()
		{
			this.TryInitID();
			if ((this.inGameNames == null || this.inGameNames.Count == 0) && !string.IsNullOrWhiteSpace(this.fullName) && this.fullName.Trim().Any(new Func<char, bool>(char.IsWhiteSpace)))
			{
				if (this.inGameNames == null)
				{
					this.inGameNames = new List<InGameName>();
				}
				if (this.inGameNames.Count == 0)
				{
					this.inGameNames.Add(new InGameName
					{
						language = Language.en,
						name = this.fullName.Trim().Split(' ', StringSplitOptions.None).FirstOrDefault<string>()
					});
				}
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x000033F4 File Offset: 0x000015F4
		public bool TryInitID()
		{
			return this.TryGenerateID(out this.m_id, out this.m_displayId);
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00003408 File Offset: 0x00001608
		protected virtual bool TryGenerateID(out string ID, out string displayID)
		{
			displayID = string.Empty;
			ID = string.Empty;
			if (string.IsNullOrWhiteSpace(this.organization))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(this.category))
			{
				return false;
			}
			if (string.IsNullOrWhiteSpace(this.fullName))
			{
				return false;
			}
			displayID = string.Concat(new string[] { this.organization, ".", this.category, ".", this.fullName });
			ID = ModdingMap.RemoveSpecialCharacters(displayID).Trim().ToLower();
			return true;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0000349C File Offset: 0x0000169C
		private static string RemoveSpecialCharacters(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000053 RID: 83
		[Space]
		[Header("--- Basic Info -----------------------------------------------------------------------")]
		[Space]
		[JustToReadUI]
		[SerializeField]
		private string m_displayId;

		// Token: 0x04000054 RID: 84
		[JustToReadUI]
		[SerializeField]
		private string m_id;

		// Token: 0x04000055 RID: 85
		[Tooltip("the name of your company, or just your artistic name.")]
		public string organization;

		// Token: 0x04000056 RID: 86
		[Tooltip("It's clothes, or makeup, or shapes...")]
		public string category;

		// Token: 0x04000057 RID: 87
		[Tooltip("full name with details")]
		public string fullName;

		// Token: 0x04000058 RID: 88
		[Tooltip("How this item will be called in the game by the player, UI, or NPCs.")]
		public List<InGameName> inGameNames;

		// Token: 0x04000059 RID: 89
		public string version;

		// Token: 0x0400005A RID: 90
		[Tooltip("When this mod is used in the game, notifications will be displayed with the name of the author and the link.")]
		[FormerlySerializedAs("displayAutorsOnUsed")]
		public bool displayAuthorsOnUsed;

		// Token: 0x0400005B RID: 91
		[FormerlySerializedAs("autors")]
		public List<Autor> authors = new List<Autor>();

		// Token: 0x0400005C RID: 92
		private Dictionary<int, InGameName> m_inGameNamesInitiated;
	}
}
