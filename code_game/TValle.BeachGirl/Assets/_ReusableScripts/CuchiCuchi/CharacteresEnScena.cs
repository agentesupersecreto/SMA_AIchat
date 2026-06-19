using System;
using System.Collections.Generic;
using System.Linq;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x020000C9 RID: 201
	public abstract class CharacteresEnScena<TSystema> : Singleton<TSystema> where TSystema : CharacteresEnScena<TSystema>
	{
		// Token: 0x170002AE RID: 686
		// (get) Token: 0x06000706 RID: 1798 RVA: 0x000147BE File Offset: 0x000129BE
		public IReadOnlyList<ICharacterUnico> characteres
		{
			get
			{
				return this.m_ICharacteresUnicos;
			}
		}

		// Token: 0x14000036 RID: 54
		// (add) Token: 0x06000707 RID: 1799 RVA: 0x000147C8 File Offset: 0x000129C8
		// (remove) Token: 0x06000708 RID: 1800 RVA: 0x00014800 File Offset: 0x00012A00
		public event Action<TSystema> changed;

		// Token: 0x06000709 RID: 1801 RVA: 0x00014838 File Offset: 0x00012A38
		public void Registrar(ICharacterUnico character)
		{
			if (this.m_characteresPorID.ContainsKey(character.ID_Unico))
			{
				Debug.LogError("Character con id: " + character.ID_Unico.ToString() + " ya esta registrado");
				return;
			}
			this.m_characteresPorID.Add(character.ID_Unico, character);
			this.m_ICharacteresUnicos.Add(character);
			if (Application.isEditor)
			{
				this.m_ICharacterUnicoObjectsEditor.Add(character as Component);
			}
			Action<TSystema> action = this.changed;
			if (action == null)
			{
				return;
			}
			action((TSystema)((object)this));
		}

		// Token: 0x0600070A RID: 1802 RVA: 0x000148D0 File Offset: 0x00012AD0
		public void Unregistrar(ICharacterUnico character)
		{
			if (this.m_characteresPorID.Remove(character.ID_Unico))
			{
				this.m_ICharacteresUnicos.Remove(character);
				this.m_characterSingleComponentsCache.Remove(character);
				if (Application.isEditor)
				{
					this.m_ICharacterUnicoObjectsEditor.Remove(character as Component);
				}
				Action<TSystema> action = this.changed;
				if (action == null)
				{
					return;
				}
				action((TSystema)((object)this));
			}
		}

		// Token: 0x0600070B RID: 1803 RVA: 0x0001493C File Offset: 0x00012B3C
		public void FindSingleCachedComponents<T>(IList<T> result, bool includeInactive) where T : class
		{
			for (int i = 0; i < this.m_ICharacteresUnicos.Count; i++)
			{
				T t = CharacteresEnScena<TSystema>.FindCachedComponent<T>(this.m_ICharacteresUnicos[i], this.m_characterSingleComponentsCache, includeInactive);
				if (t != null)
				{
					result.Add(t);
				}
			}
		}

		// Token: 0x0600070C RID: 1804 RVA: 0x00014988 File Offset: 0x00012B88
		public T FindSingleCachedComponent<T>(Guid id, bool includeInactive) where T : class
		{
			ICharacterUnico characterUnico;
			if (!this.m_characteresPorID.TryGetValue(id, out characterUnico))
			{
				return default(T);
			}
			return CharacteresEnScena<TSystema>.FindCachedComponent<T>(characterUnico, this.m_characterSingleComponentsCache, includeInactive);
		}

		// Token: 0x0600070D RID: 1805 RVA: 0x000149BC File Offset: 0x00012BBC
		private static T FindCachedComponent<T>(ICharacter target, Dictionary<ICharacter, Dictionary<Type, WeakReference>> mainDicc, bool includeInactive) where T : class
		{
			Dictionary<Type, WeakReference> dictionary;
			if (!mainDicc.TryGetValue(target, out dictionary))
			{
				dictionary = new Dictionary<Type, WeakReference>();
				mainDicc.Add(target, dictionary);
			}
			return CharacteresEnScena<TSystema>.FindCachedComponent<T>(target, dictionary, includeInactive);
		}

		// Token: 0x0600070E RID: 1806 RVA: 0x000149EC File Offset: 0x00012BEC
		private static T FindCachedComponent<T>(ICharacter target, Dictionary<Type, WeakReference> dicc, bool includeInactive) where T : class
		{
			WeakReference weakReference;
			if (!dicc.TryGetValue(typeof(T), out weakReference))
			{
				T t = ((target != null) ? target.GetComponentInChildren<T>(includeInactive) : default(T));
				if (t != null)
				{
					weakReference = new WeakReference(t);
					dicc.Add(typeof(T), weakReference);
				}
			}
			return ((weakReference != null) ? weakReference.Target : null) as T;
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x00014A60 File Offset: 0x00012C60
		public ICharacterUnico Obtener(Guid id)
		{
			ICharacterUnico characterUnico;
			if (this.m_characteresPorID.TryGetValue(id, out characterUnico))
			{
				return characterUnico;
			}
			return null;
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x00014A80 File Offset: 0x00012C80
		public T_Char Obtener<T_Char>(string id) where T_Char : class, ICharacterUnico
		{
			Guid guid = Guid.Parse(id);
			return this.Obtener<T_Char>(guid);
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x00014A9C File Offset: 0x00012C9C
		public T_Char Obtener<T_Char>(Guid id) where T_Char : class, ICharacterUnico
		{
			ICharacterUnico characterUnico;
			if (this.m_characteresPorID.TryGetValue(id, out characterUnico))
			{
				T_Char t_Char;
				if ((t_Char = characterUnico as T_Char) == null)
				{
					t_Char = characterUnico.GetComponentEnRoot<T_Char>();
				}
				return t_Char;
			}
			return default(T_Char);
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x00014AE0 File Offset: 0x00012CE0
		public void Obtener<T_Char>(ICollection<T_Char> resultado, T_Char ignorar = default(T_Char)) where T_Char : class, ICharacterUnico
		{
			for (int i = 0; i < this.m_ICharacteresUnicos.Count; i++)
			{
				ICharacterUnico characterUnico = this.m_ICharacteresUnicos[i];
				if (characterUnico != null && characterUnico != ignorar)
				{
					T_Char t_Char;
					if ((t_Char = characterUnico as T_Char) == null)
					{
						t_Char = characterUnico.GetComponentEnRoot<T_Char>();
					}
					T_Char t_Char2 = t_Char;
					if (t_Char2 != null)
					{
						resultado.Add(t_Char2);
					}
				}
			}
		}

		// Token: 0x06000713 RID: 1811 RVA: 0x00014B48 File Offset: 0x00012D48
		public void UpdateMasterCharacters()
		{
			foreach (KeyValuePair<ICharacter, List<ICharacter>> keyValuePair in this.m_slavesDeMaster)
			{
				this.m_poolDeSlaveList.ReturnItem(keyValuePair.Value);
			}
			this.m_slavesDeMaster.Clear();
			this.m_masterDeSlave.Clear();
			for (int i = 0; i < this.m_ICharacteresUnicos.Count; i++)
			{
				ICharacter character = this.m_ICharacteresUnicos[i];
				if (character != null)
				{
					this.m_masterDeSlave.Add(new ValueTuple<ICharacter, ICharacter>(character, character.GetMasterRoot()));
				}
			}
			for (int j = 0; j < this.m_masterDeSlave.Count; j++)
			{
				ValueTuple<ICharacter, ICharacter> valueTuple = this.m_masterDeSlave[j];
				if (valueTuple.Item2 != null)
				{
					List<ICharacter> item;
					if (!this.m_slavesDeMaster.TryGetValue(valueTuple.Item2, out item))
					{
						item = this.m_poolDeSlaveList.GetItem();
						this.m_slavesDeMaster.Add(valueTuple.Item2, item);
					}
					item.Add(valueTuple.Item1);
				}
			}
			this.m_lastUpdateMasterID = ForcedUpdateId.current;
		}

		// Token: 0x06000714 RID: 1812 RVA: 0x00014C7C File Offset: 0x00012E7C
		public IReadOnlyList<ICharacter> GetSlavesDe(ICharacter master)
		{
			if (!this.m_lastUpdateMasterID.IsCurrent())
			{
				this.UpdateMasterCharacters();
			}
			List<ICharacter> list;
			if (this.m_slavesDeMaster.TryGetValue(master, out list))
			{
				return list;
			}
			return null;
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x00014CB0 File Offset: 0x00012EB0
		public T_Tipo GetSlaveDe<T_Tipo>(ICharacter master) where T_Tipo : class
		{
			if (!this.m_lastUpdateMasterID.IsCurrent())
			{
				this.UpdateMasterCharacters();
			}
			List<ICharacter> list;
			if (this.m_slavesDeMaster.TryGetValue(master, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					T_Tipo t_Tipo = list[i] as T_Tipo;
					if (t_Tipo != null)
					{
						return t_Tipo;
					}
				}
			}
			return default(T_Tipo);
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x00014D18 File Offset: 0x00012F18
		public void GetSlavesDe<T_Tipo>(ICharacter master, IList<T_Tipo> result, ISet<T_Tipo> resultSet = null) where T_Tipo : class
		{
			if (!this.m_lastUpdateMasterID.IsCurrent())
			{
				this.UpdateMasterCharacters();
			}
			List<ICharacter> list;
			if (this.m_slavesDeMaster.TryGetValue(master, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					T_Tipo t_Tipo = list[i] as T_Tipo;
					if (t_Tipo != null && (resultSet == null || resultSet.Add(t_Tipo)))
					{
						result.Add(t_Tipo);
					}
				}
			}
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x00014D88 File Offset: 0x00012F88
		public void GetSlavesDeIgnoring<T_Tipo>(ICharacter master, IList<T_Tipo> result, IReadOnlyCollection<T_Tipo> ignore) where T_Tipo : class
		{
			if (!this.m_lastUpdateMasterID.IsCurrent())
			{
				this.UpdateMasterCharacters();
			}
			List<ICharacter> list;
			if (this.m_slavesDeMaster.TryGetValue(master, out list))
			{
				for (int i = 0; i < list.Count; i++)
				{
					T_Tipo t_Tipo = list[i] as T_Tipo;
					if (t_Tipo != null && !ignore.Contains(t_Tipo))
					{
						result.Add(t_Tipo);
					}
				}
			}
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x00014DF3 File Offset: 0x00012FF3
		public override SingletonEditorBotones Boton2()
		{
			return new SingletonEditorBotones
			{
				text = "Prin Registrados",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x00014E0C File Offset: 0x0001300C
		public override void Aplicar2()
		{
			base.Aplicar2();
			foreach (KeyValuePair<Guid, ICharacterUnico> keyValuePair in this.m_characteresPorID)
			{
				MonoBehaviour.print(keyValuePair.Value.nombreCompleto);
			}
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x00014E70 File Offset: 0x00013070
		protected override void InitData(bool esEditorTime)
		{
		}

		// Token: 0x040003F8 RID: 1016
		private Dictionary<Guid, ICharacterUnico> m_characteresPorID = new Dictionary<Guid, ICharacterUnico>();

		// Token: 0x040003F9 RID: 1017
		private List<ICharacterUnico> m_ICharacteresUnicos = new List<ICharacterUnico>();

		// Token: 0x040003FA RID: 1018
		[SerializeField]
		private List<Component> m_ICharacterUnicoObjectsEditor = new List<Component>();

		// Token: 0x040003FC RID: 1020
		private Dictionary<ICharacter, List<ICharacter>> m_slavesDeMaster = new Dictionary<ICharacter, List<ICharacter>>();

		// Token: 0x040003FD RID: 1021
		private List<ValueTuple<ICharacter, ICharacter>> m_masterDeSlave = new List<ValueTuple<ICharacter, ICharacter>>();

		// Token: 0x040003FE RID: 1022
		private SimplePoolDeCollection<List<ICharacter>, ICharacter> m_poolDeSlaveList = new SimplePoolDeCollection<List<ICharacter>, ICharacter>();

		// Token: 0x040003FF RID: 1023
		private ForcedUpdateId m_lastUpdateMasterID;

		// Token: 0x04000400 RID: 1024
		private Dictionary<ICharacter, Dictionary<Type, WeakReference>> m_characterSingleComponentsCache = new Dictionary<ICharacter, Dictionary<Type, WeakReference>>();
	}
}
