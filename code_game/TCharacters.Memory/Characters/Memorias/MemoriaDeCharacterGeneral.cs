using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias
{
	// Token: 0x02000003 RID: 3
	[MemoriaRelatedBehaviour]
	public abstract class MemoriaDeCharacterGeneral : MemoriaDeCharacterBase
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x000020C0 File Offset: 0x000002C0
		public sealed override string selfMemKeyName
		{
			get
			{
				return MemoriaDeCharacterGeneral.selfMemKeyNameOfMemoriaDeCharacterGeneral;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020C7 File Offset: 0x000002C7
		protected override void OnLoadMemory(JsonMemoryNode fromMemory)
		{
			this.CleanMemory();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020CF File Offset: 0x000002CF
		protected override void OnSavingMemory(JsonMemoryNode toMemory)
		{
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020D4 File Offset: 0x000002D4
		protected virtual void CleanMemory()
		{
			if (!this.permanente)
			{
				return;
			}
			IJsonMemoryNodeReadOnly jsonMemoryNodeReadOnly = (IJsonMemoryNodeReadOnly)base.memoriaReadOnly.FindChildReadOnly("Conocidos");
			if (jsonMemoryNodeReadOnly != null)
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNodeReadOnly.data)
				{
					if (!MemoriaDeCharacterBase.PersonajeExisteAndLog(base.memoriaReadOnly.memory, jsonMemoryNodeReadOnly.nodeID, keyValuePair.Key))
					{
						list.Add(keyValuePair.Key);
					}
				}
				foreach (string text in list)
				{
					jsonMemoryNodeReadOnly.RemoverData(text);
				}
			}
			IMemoryNodeReadOnly<string, string> memoryNodeReadOnly = base.memoriaReadOnly.FindChildReadOnly("Saludado");
			if (memoryNodeReadOnly != null)
			{
				List<string> list2 = new List<string>();
				foreach (IMemoryNodeReadOnly<string, string> memoryNodeReadOnly2 in memoryNodeReadOnly.childrenReadOnly)
				{
					IJsonMemoryNodeReadOnly jsonMemoryNodeReadOnly2 = (IJsonMemoryNodeReadOnly)memoryNodeReadOnly2;
					foreach (KeyValuePair<string, string> keyValuePair2 in jsonMemoryNodeReadOnly2.data)
					{
						if (!MemoriaDeCharacterBase.PersonajeExisteAndLog(base.memoriaReadOnly.memory, memoryNodeReadOnly.nodeID + "/" + jsonMemoryNodeReadOnly2.nodeID, keyValuePair2.Key))
						{
							list2.Add(keyValuePair2.Key);
						}
					}
					foreach (string text2 in list2)
					{
						jsonMemoryNodeReadOnly2.RemoverData(text2);
					}
					list2.Clear();
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000022DC File Offset: 0x000004DC
		public bool ConoceACurrentMainCharacter()
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return false;
			}
			IMemoryNodeReadOnly<string, string> memoryNodeReadOnly = base.memoriaReadOnly.FindChildReadOnly("Conocidos");
			return memoryNodeReadOnly != null && memoryNodeReadOnly.FindData(current.ID_Unico.ToString()) != null;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002330 File Offset: 0x00000530
		public void RegistrarCurrentMainCharacterComoConocido()
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			MemoriaDeCharacterBase.RegistrarDeep(this, "Conocidos", current.ID_Unico.ToString(), string.Empty);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002371 File Offset: 0x00000571
		public bool InitialOutfitWasLoaded()
		{
			return base.memoriaReadOnly.FindDataBool("iniOutLoaded", false);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002384 File Offset: 0x00000584
		public void RegistrarInitialOutfitWasLoaded()
		{
			base.memoriaReadOnly.AddData("iniOutLoaded", true, true);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002398 File Offset: 0x00000598
		public bool SaludoACurrentMainCharacter(DateTime date)
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return false;
			}
			IMemoryNodeReadOnly<string, string> memoryNodeReadOnly = base.memoriaReadOnly.FindChildReadOnly("Saludado");
			if (memoryNodeReadOnly == null)
			{
				return false;
			}
			IMemoryNodeReadOnly<string, string> memoryNodeReadOnly2 = memoryNodeReadOnly.FindChildReadOnly(date.ToString("yyyy M dd HH"));
			return memoryNodeReadOnly2 != null && memoryNodeReadOnly2.FindData(current.ID_Unico.ToString()) != null;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002404 File Offset: 0x00000604
		public void RegistrarCurrentMainCharacterComoSaludado(DateTime date)
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			MemoriaDeCharacterBase.RegistrarDeep(this, "Saludado/" + date.ToString("yyyy M dd HH"), current.ID_Unico.ToString(), string.Empty);
		}

		// Token: 0x04000001 RID: 1
		public static string selfMemKeyNameOfMemoriaDeCharacterGeneral;
	}
}
