using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime;
using Assets.Base.BeachGirl.Mapas.Materiales.Runtime.Globales;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Adresables.Runtime.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Skins;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering.HighDefinition;

namespace Assets._ReusableScripts.CuchiCuchi.Ropa
{
	// Token: 0x02000128 RID: 296
	public class PiezasDeRopaLoader : AplicableCustomMonobehaviour
	{
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060006DA RID: 1754 RVA: 0x00020085 File Offset: 0x0001E285
		public Character character
		{
			get
			{
				if (this.m_character == null)
				{
					this.m_character = base.GetComponentInParent<Character>();
				}
				return this.m_character;
			}
		}

		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060006DB RID: 1755 RVA: 0x000200A7 File Offset: 0x0001E2A7
		[Obsolete("Se unificaron los mapas", true)]
		public RopaTipoDeSingleton ropaTipoDeSingleton
		{
			get
			{
				return this.map;
			}
		}

		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060006DC RID: 1756 RVA: 0x000200AF File Offset: 0x0001E2AF
		public IReadOnlyList<PiezaDeRopaBase> piezasPuestas
		{
			get
			{
				return this.m_piezasPuestas;
			}
		}

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060006DD RID: 1757 RVA: 0x000200B7 File Offset: 0x0001E2B7
		public IReadOnlyDictionary<string, PiezaDeRopaBase> piezasPuestasPorId
		{
			get
			{
				return this.m_piezasPuestasPorId;
			}
		}

		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060006DE RID: 1758 RVA: 0x000200BF File Offset: 0x0001E2BF
		public RopaCubre cubriendoFlags
		{
			get
			{
				return this.m_cubriendoFlags;
			}
		}

		// Token: 0x14000029 RID: 41
		// (add) Token: 0x060006DF RID: 1759 RVA: 0x000200C8 File Offset: 0x0001E2C8
		// (remove) Token: 0x060006E0 RID: 1760 RVA: 0x00020100 File Offset: 0x0001E300
		public event PiezasDeRopaLoader.OnChangedHandler changed;

		// Token: 0x060006E1 RID: 1761 RVA: 0x00020135 File Offset: 0x0001E335
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			if (Singleton<LoadingPanel>.IsInScene)
			{
				this.m_hideLoadingPanel = Singleton<LoadingPanel>.instance.hidingModificable.ObtenerModificadorNotNull(this);
			}
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x0002015A File Offset: 0x0001E35A
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			if (this.m_hideLoadingPanel != null)
			{
				this.m_hideLoadingPanel.valor.valor = true;
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x0002017C File Offset: 0x0001E37C
		protected override void OnDestroyUnityEvent(bool quitting)
		{
			base.OnDestroyUnityEvent(quitting);
			ModificadorDeBool hideLoadingPanel = this.m_hideLoadingPanel;
			if (hideLoadingPanel != null)
			{
				hideLoadingPanel.TryRemoverDeOwner(true);
			}
			this.m_hideLoadingPanel = null;
			this.RemoverTodo();
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x000201A8 File Offset: 0x0001E3A8
		public void RemoverTodo()
		{
			try
			{
				PiezasDeRopaLoader.m_TempPiezasPuestas.AddRange(this.m_piezasPuestas);
				for (int i = 0; i < PiezasDeRopaLoader.m_TempPiezasPuestas.Count; i++)
				{
					PiezaDeRopaBase piezaDeRopaBase = PiezasDeRopaLoader.m_TempPiezasPuestas[i];
					if (piezaDeRopaBase != null)
					{
						PiezaDeRopaBase piezaDeRopaBase2;
						this.RemovePieza(piezaDeRopaBase.dataDeRopa.stringId, true, out piezaDeRopaBase2);
					}
				}
			}
			finally
			{
				PiezasDeRopaLoader.m_TempPiezasPuestas.Clear();
			}
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00020224 File Offset: 0x0001E424
		public void ToggleTodo(bool ocultar)
		{
			try
			{
				PiezasDeRopaLoader.m_TempPiezasPuestas.AddRange(this.m_piezasPuestas);
				for (int i = 0; i < PiezasDeRopaLoader.m_TempPiezasPuestas.Count; i++)
				{
					PiezaDeRopaBase piezaDeRopaBase = PiezasDeRopaLoader.m_TempPiezasPuestas[i];
					if (piezaDeRopaBase != null && piezaDeRopaBase.enabled == ocultar)
					{
						PiezaDeRopaBase piezaDeRopaBase2;
						this.OcultarPieza(piezaDeRopaBase.dataDeRopa.stringId, ocultar, out piezaDeRopaBase2);
					}
				}
			}
			finally
			{
				PiezasDeRopaLoader.m_TempPiezasPuestas.Clear();
			}
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x000202A8 File Offset: 0x0001E4A8
		public bool Usando(string PiezaID, bool ignorarOcultas)
		{
			PiezaDeRopaBase piezaDeRopaBase;
			return this.m_piezasPuestasPorId.TryGetValue(PiezaID, out piezaDeRopaBase) && (piezaDeRopaBase.enabled || !ignorarOcultas);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x000202D8 File Offset: 0x0001E4D8
		public void UpdateCubrindoPartes()
		{
			this.m_cubriendoFlags = RopaCubre.None;
			for (int i = 0; i < this.m_piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasPuestas[i];
				if (piezaDeRopaBase.isActiveAndEnabled)
				{
					this.m_cubriendoFlags |= piezaDeRopaBase.cubreFlags;
				}
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x0002032C File Offset: 0x0001E52C
		public PiezaDeRopaBase ObtenerPieza(string id)
		{
			PiezaDeRopaBase piezaDeRopaBase;
			if (this.m_piezasPuestasPorId.TryGetValue(id, out piezaDeRopaBase))
			{
				return piezaDeRopaBase;
			}
			return null;
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x0002034C File Offset: 0x0001E54C
		public void ObtenerPiezasIDs(ICollection<string> resultado, bool ignorarOcultas)
		{
			for (int i = 0; i < this.m_piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasPuestas[i];
				if (piezaDeRopaBase.enabled || !ignorarOcultas)
				{
					resultado.Add(piezaDeRopaBase.dataDeRopa.stringId);
				}
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00020398 File Offset: 0x0001E598
		public int CantidadPiezas(RopaPosicion posicion, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			int num = 0;
			for (int i = 0; i < this.m_piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasPuestas[i];
				if (piezaDeRopaBase.dataDeRopa.posicion == posicion && (piezaDeRopaBase.enabled || !ignorarOcultas))
				{
					num++;
					if (IDsResultado != null)
					{
						IDsResultado.Add(piezaDeRopaBase.dataDeRopa.stringId);
					}
				}
			}
			return num;
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x000203FC File Offset: 0x0001E5FC
		public int CantidadPiezas(RopaLayer layer, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			int num = 0;
			for (int i = 0; i < this.m_piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasPuestas[i];
				if (piezaDeRopaBase.dataDeRopa.layer == layer && (piezaDeRopaBase.enabled || !ignorarOcultas))
				{
					num++;
					if (IDsResultado != null)
					{
						IDsResultado.Add(piezaDeRopaBase.dataDeRopa.stringId);
					}
				}
			}
			return num;
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00020460 File Offset: 0x0001E660
		public int CantidadPiezasCubriendo(RopaCubre flags, bool ignorarOcultas, IList<string> IDsResultado = null)
		{
			int num2;
			try
			{
				PiezasDeRopaLoader.m_TEMP_SYNC_ONLY.AddRange(this.m_piezasPuestas);
				PiezasDeRopaLoader.m_TEMP_SYNC_ONLY.Sort(delegate(PiezaDeRopaBase x, PiezaDeRopaBase y)
				{
					int layer = (int)y.dataDeRopa.layer;
					return layer.CompareTo((int)x.dataDeRopa.layer);
				});
				int num = 0;
				for (int i = 0; i < PiezasDeRopaLoader.m_TEMP_SYNC_ONLY.Count; i++)
				{
					PiezaDeRopaBase piezaDeRopaBase = PiezasDeRopaLoader.m_TEMP_SYNC_ONLY[i];
					if (((int)piezaDeRopaBase.cubreFlags).IsAnyFlagSet((int)flags) && (piezaDeRopaBase.enabled || !ignorarOcultas))
					{
						num++;
						if (IDsResultado != null)
						{
							IDsResultado.Add(piezaDeRopaBase.dataDeRopa.stringId);
						}
					}
				}
				num2 = num;
			}
			finally
			{
				PiezasDeRopaLoader.m_TEMP_SYNC_ONLY.Clear();
			}
			return num2;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00020520 File Offset: 0x0001E720
		public RopaCubre CurrentCubriendoFlagsIgnorandoOMenorPrioridad(string ignorandoPiezaID, bool ignorarOcultas)
		{
			RopaCubre ropaCubre = RopaCubre.None;
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			for (int i = 0; i < this.piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.piezasPuestas[i];
				if (!(ignorandoPiezaID == piezaDeRopaBase.dataDeRopa.stringId) && (piezaDeRopaBase.enabled || !ignorarOcultas))
				{
					ropaCubre |= piezaDeRopaBase.dataDeRopa.cubreFlag;
				}
			}
			MapaDeRopa.RopaData ropaData = instance.ObtenerData(ignorandoPiezaID);
			if (ropaData.cubreFlag == RopaCubre.None)
			{
				return RopaCubre.None;
			}
			RopaCubre ropaCubre2 = ropaData.cubreFlag & ~ropaCubre;
			if (ropaCubre2 == RopaCubre.None)
			{
				ropaCubre2 = ropaData.cubreFlag.ObtenerLaDeMenorPrioridad(this.m_character.sexo);
			}
			return ropaCubre2;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x000205C8 File Offset: 0x0001E7C8
		public RopaCubre PiezaCubreFlags(string piezaID, bool ignorarOcultas)
		{
			RopaParaAvatarUnificado instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			PiezaDeRopaBase piezaDeRopaBase;
			if (!this.piezasPuestasPorId.TryGetValue(piezaID, out piezaDeRopaBase) || (!piezaDeRopaBase.enabled && ignorarOcultas))
			{
				return RopaCubre.None;
			}
			return instance.ObtenerData(piezaID).cubreFlag;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00020608 File Offset: 0x0001E808
		public static void Comparar(RopaCubre last, RopaCubre nuevas, ICollection<RopaCubre> coveredResult, ICollection<RopaCubre> exposedResult)
		{
			foreach (object obj in typeof(RopaCubre).GetEnumValoresObject())
			{
				RopaCubre ropaCubre = (RopaCubre)obj;
				if (ropaCubre != RopaCubre.None)
				{
					bool flag = ((int)last).HasFlag((int)ropaCubre);
					bool flag2 = ((int)nuevas).HasFlag((int)ropaCubre);
					if (flag && !flag2 && exposedResult != null && !exposedResult.Contains(ropaCubre))
					{
						exposedResult.Add(ropaCubre);
					}
					if (flag2 && !flag && coveredResult != null && !coveredResult.Contains(ropaCubre))
					{
						coveredResult.Add(ropaCubre);
					}
				}
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x000206AC File Offset: 0x0001E8AC
		[Obsolete("", true)]
		public IRopaParaAvatar ObtenerMapa()
		{
			return GeneradorDeConjuntosDeRopaAleatoriosFemeninos.ObtenerMapa();
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000206B3 File Offset: 0x0001E8B3
		private void Subscribe(PiezaDeRopaBase pieza)
		{
			pieza.onEnabled += this.Pieza_onEnabled;
			pieza.onDisabled += this.Pieza_onDisabled;
			pieza.onDestroyed += this.Pieza_onDestroyed;
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000206EB File Offset: 0x0001E8EB
		private void UnSubscribe(PiezaDeRopaBase pieza)
		{
			pieza.onEnabled -= this.Pieza_onEnabled;
			pieza.onDisabled -= this.Pieza_onDisabled;
			pieza.onDestroyed -= this.Pieza_onDestroyed;
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00020724 File Offset: 0x0001E924
		private void Pieza_onDestroyed(object obj)
		{
			if (base.applicationQuit)
			{
				return;
			}
			PiezaDeRopaBase piezaDeRopaBase = obj as PiezaDeRopaBase;
			PiezaDeRopaBase piezaDeRopaBase2;
			this.RemovePieza(piezaDeRopaBase.dataDeRopa.stringId, true, out piezaDeRopaBase2);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00020756 File Offset: 0x0001E956
		private void Pieza_onDisabled(object obj)
		{
			this.OnPiezasChanged();
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00020756 File Offset: 0x0001E956
		private void Pieza_onEnabled(object obj)
		{
			this.OnPiezasChanged();
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00020760 File Offset: 0x0001E960
		private void OnPiezasChanged()
		{
			RopaCubre cubriendoFlags = this.m_cubriendoFlags;
			this.UpdateCubrindoPartes();
			PiezasDeRopaLoader.OnChangedHandler onChangedHandler = this.changed;
			if (onChangedHandler == null)
			{
				return;
			}
			onChangedHandler(cubriendoFlags, this.m_cubriendoFlags, this);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00020794 File Offset: 0x0001E994
		public bool OcultarPiezasCubriendo(RopaCubre flags, bool ocultar)
		{
			bool flag = false;
			for (int i = 0; i < this.m_piezasPuestas.Count; i++)
			{
				PiezaDeRopaBase piezaDeRopaBase = this.m_piezasPuestas[i];
				PiezaDeRopaBase piezaDeRopaBase2;
				if (((int)piezaDeRopaBase.cubreFlags).IsAnyFlagSet((int)flags) && this.OcultarPieza(piezaDeRopaBase.dataDeRopa.stringId, ocultar, out piezaDeRopaBase2))
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x000207F0 File Offset: 0x0001E9F0
		public bool OcultarPieza(string piezaId, bool ocultar, out PiezaDeRopaBase paraCambiarEstado)
		{
			paraCambiarEstado = null;
			if (string.IsNullOrWhiteSpace(piezaId))
			{
				return false;
			}
			bool flag = this.m_piezasPuestasPorId.TryGetValue(piezaId, out paraCambiarEstado);
			if (flag)
			{
				flag = paraCambiarEstado.enabled == ocultar;
				if (!flag)
				{
					Debug.Log("pieza: " + piezaId + " no se puede ocultar/mostrar, por que ya tiene el estado deseado.");
				}
			}
			if (flag)
			{
				this.UnSubscribe(paraCambiarEstado);
				paraCambiarEstado.enabled = !ocultar;
				if (ocultar)
				{
					this.OnPiezasChanged();
				}
				else
				{
					this.OnPiezasChanged();
				}
				this.Subscribe(paraCambiarEstado);
			}
			return flag;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00020870 File Offset: 0x0001EA70
		public bool RemovePieza(string piezaId, bool destroy, out PiezaDeRopaBase removida)
		{
			removida = null;
			bool flag;
			try
			{
				Animator bodyAnimator = this.character.bodyAnimator;
				if (!this.m_piezasPuestasPorId.TryGetValue(piezaId, out removida))
				{
					flag = true;
				}
				else
				{
					this.m_piezasPuestasPorId.Remove(piezaId);
					this.m_piezasPuestas.RemoveAll((PiezaDeRopaBase p) => p.dataDeRopa.stringId == piezaId);
					this.UnSubscribe(removida);
					this.OnPiezasChanged();
					if (destroy && removida != null)
					{
						if (Application.isPlaying)
						{
							Object.Destroy(removida.gameObject, 0.01f);
						}
						else
						{
							Object.Destroy(removida.gameObject);
						}
					}
					if (bodyAnimator == null)
					{
						flag = false;
					}
					else
					{
						ArmatureSkins componentInParent = bodyAnimator.GetComponentInParent<ArmatureSkins>();
						if (componentInParent != null)
						{
							componentInParent.RemoveSkin(removida, false, false, true);
						}
						IRopaParaAvatar ropaParaAvatar = (AsyncSingleton<RopaParaAvatarUnificado>.IsInScene ? AsyncSingleton<RopaParaAvatarUnificado>.instance : null);
						if (ropaParaAvatar == null)
						{
							flag = false;
						}
						else
						{
							MapaDeRopa.RopaData ropaData = ropaParaAvatar.ObtenerData(piezaId);
							if (ropaData == null)
							{
								Debug.LogWarning(string.Concat(new string[] { "removiendo ropa de id ", piezaId, " a ", bodyAnimator.name, ", fallo, pieza no esta en singleton de IDs" }));
								flag = false;
							}
							else
							{
								Transform transform = bodyAnimator.transform.FindDeepChild(ropaData.skinName, true);
								if (transform == null)
								{
									Debug.LogError(string.Concat(new string[] { "removiendo ropa de id ", piezaId, " a ", bodyAnimator.name, ", fallo, No se encontro Pieza con nombre: ", ropaData.skinName }));
									flag = false;
								}
								else
								{
									if (!destroy)
									{
										transform.parent = null;
									}
									else if (Application.isPlaying)
									{
										Object.Destroy(transform.gameObject, 0.01f);
									}
									else
									{
										Object.Destroy(transform.gameObject);
									}
									flag = true;
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				try
				{
					List<SlotDeMaterialDeRopa> list = null;
					if (this.m_piezasPuestasDeConjuntoMaterialesPorId.TryGetValue(piezaId, out list))
					{
						this.m_piezasPuestasDeConjuntoMaterialesPorId.Remove(piezaId);
					}
					this.ReleaseGameObjects(removida);
					this.ReleaseMaterials(removida, list);
				}
				catch (Exception)
				{
					throw;
				}
			}
			return flag;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00020AF0 File Offset: 0x0001ECF0
		private void ReleaseGameObjects(PiezaDeRopaBase owner)
		{
			if (owner != null && owner.instantiatedAssets != null && owner.instantiatedAssets.Count > 0)
			{
				for (int i = 0; i < owner.instantiatedAssets.Count; i++)
				{
					try
					{
						if (!Singleton<AdresablesInstanciador>.IsInScene || !Application.isPlaying || !Singleton<AdresablesInstanciador>.instance.ReleaseInstance<Object>(owner.instantiatedAssets[i]))
						{
							if (Application.isPlaying)
							{
								Object.Destroy(owner.instantiatedAssets[i]);
							}
							else
							{
								Object.Destroy(owner.instantiatedAssets[i]);
							}
						}
					}
					catch (Exception)
					{
						throw;
					}
				}
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00020BA0 File Offset: 0x0001EDA0
		private void ReleaseMaterials(PiezaDeRopaBase owner, List<SlotDeMaterialDeRopa> materialesDePieza)
		{
			if (owner != null && materialesDePieza != null)
			{
				for (int i = 0; i < materialesDePieza.Count; i++)
				{
					this.ReleaseMaterial(owner, materialesDePieza[i]);
				}
			}
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00020BD8 File Offset: 0x0001EDD8
		private void ReleaseMaterial(PiezaDeRopaBase owner, SlotDeMaterialDeRopa materialDePieza)
		{
			if (owner != null && materialDePieza != null)
			{
				Material[] sharedMaterials = owner.skinnedMeshRenderer.sharedMaterials;
				if (sharedMaterials.ContieneIndexReadOnly(materialDePieza.materialSlot))
				{
					Material material = sharedMaterials[materialDePieza.materialSlot];
					if (material != null)
					{
						try
						{
							if ((!Singleton<AdresablesInstanciador>.IsInScene || !Singleton<AdresablesInstanciador>.instance.ReleaseInstance<Material>(material)) && !TValleEditorTools.IsPersistent(material))
							{
								TValleEditorTools.Destroy(material);
							}
						}
						catch (Exception ex)
						{
							Debug.LogException(ex, this);
						}
					}
				}
			}
			if (((materialDePieza != null) ? materialDePieza.customDiffusionProfileSettings : null) != null)
			{
				try
				{
					if ((!Singleton<AdresablesInstanciador>.IsInScene || !Singleton<AdresablesInstanciador>.instance.ReleaseInstance<DiffusionProfileSettings>(materialDePieza.customDiffusionProfileSettings)) && !TValleEditorTools.IsPersistent(materialDePieza.customDiffusionProfileSettings))
					{
						TValleEditorTools.Destroy(materialDePieza.customDiffusionProfileSettings);
						materialDePieza.customDiffusionProfileSettings = null;
					}
				}
				catch (Exception ex2)
				{
					Debug.LogException(ex2, this);
				}
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x00020CBC File Offset: 0x0001EEBC
		public static void ChangeMainColor(Material material, Color color, MaterialParaRopaData data, SlotDeMaterialDeRopa config)
		{
			Color color2 = material.GetColor(PiezasDeRopaLoader._BaseColorID);
			Color color3 = color2;
			if (data.puedeTenerCustomColor)
			{
				color3 = color;
				material.SetColor(PiezasDeRopaLoader._BaseColorID, color3);
			}
			if (!data.esTransparente)
			{
				color3.a = color2.a;
				material.SetColor(PiezasDeRopaLoader._BaseColorID, color3);
			}
			config.color = color;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x00020D18 File Offset: 0x0001EF18
		public static void SetTessellationCongig(MapaDeRopa.RopaData dataRopa, PiezaDeRopaBase pieza)
		{
			if (dataRopa.skinConfig.usarTessellation)
			{
				MaterialFieldsDeTessellationIDs materialFieldsDeTessellationIDs = new MaterialFieldsDeTessellationIDs();
				MaterialFieldsDeTessellationIDs materialFieldsDeTessellationIDs2 = materialFieldsDeTessellationIDs;
				MapaDeMaterialFields mapaDeMaterialFields = Singleton<MaterialesFieldsNombres>.instance.Obtener();
				materialFieldsDeTessellationIDs2.Load((mapaDeMaterialFields != null) ? mapaDeMaterialFields.tessellation : null);
				ConfiguracionGeneralDeGraficos.TesselationConfig skinsTesselationConfig = Singleton<ConfiguracionGeneralDeGraficos>.instance.graficas.skinsTesselationConfig;
				foreach (Material material in pieza.skinnedMeshRenderer.sharedMaterials)
				{
					if (Singleton<ConfiguracionGeneralDeGraficos>.instance.graficas.usarTesselation)
					{
						TessellationDeMaterial.Set(material, materialFieldsDeTessellationIDs, skinsTesselationConfig.amount, skinsTesselationConfig.phongSmoothing, skinsTesselationConfig.minCameraDistance, skinsTesselationConfig.maxCameraDistance);
					}
					else
					{
						TessellationDeMaterial.TurnOff(material, materialFieldsDeTessellationIDs);
					}
				}
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x00020DC1 File Offset: 0x0001EFC1
		public IEnumerator UpdateMaterialRutine(string pendaID, string newMaterialID, int materialSlot, Color color, Action<bool> output)
		{
			PiezaDeRopaBase pieza;
			if (string.IsNullOrWhiteSpace(pendaID) || !this.m_piezasPuestasPorId.TryGetValue(pendaID, out pieza))
			{
				Debug.LogError("no esta usando pieza: " + pendaID, this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			if (pieza == null)
			{
				Debug.LogError("pieza: " + pendaID + " ya fue destruida", this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			if (string.IsNullOrWhiteSpace(newMaterialID) || !pieza.materialesData.ContieneIndexReadOnly(materialSlot))
			{
				Debug.LogError("material: " + newMaterialID + " no se puede actualizar.", this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			MaterialParaRopaData dataMaterial = AsyncSingleton<MaterialesParaRopa>.instance.ObtenerData(newMaterialID);
			if (dataMaterial == null)
			{
				Debug.LogWarning("material id: " + newMaterialID + ". no tiene data.", this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			MapaDeRopa.RopaData dataRopa = AsyncSingleton<RopaParaAvatarUnificado>.instance.ObtenerData(pendaID);
			if (dataRopa == null)
			{
				Debug.LogWarning("ropa id: " + pendaID + ". no tiene data.", this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			SlotDeMaterialDeRopa current = pieza.materialesData[materialSlot];
			SlotDeMaterialDeRopa newOne = current.Clone();
			newOne.añadirUnaCopia = true;
			newOne.SetMaterialID(newMaterialID);
			Material copia = null;
			yield return Singleton<AdresablesInstanciador>.instance.Instanciate<Material>(dataMaterial.address, false, delegate(Material ins)
			{
				copia = ins;
			}, null, null);
			AssetReference diffusionProfile = dataMaterial.diffusionProfile;
			if (!string.IsNullOrWhiteSpace((diffusionProfile != null) ? diffusionProfile.AssetGUID : null))
			{
				PiezasDeRopaLoader.<>c__DisplayClass54_1 CS$<>8__locals2 = new PiezasDeRopaLoader.<>c__DisplayClass54_1();
				CS$<>8__locals2.diffusionProfileSettings = null;
				yield return Singleton<AdresablesInstanciador>.instance.Instanciate<DiffusionProfileSettings>(dataMaterial.diffusionProfile, false, delegate(DiffusionProfileSettings ins)
				{
					CS$<>8__locals2.diffusionProfileSettings = ins;
				}, null, null);
				newOne.customDiffusionProfileSettings = CS$<>8__locals2.diffusionProfileSettings;
				CS$<>8__locals2 = null;
			}
			if (copia == null)
			{
				Debug.LogWarning("fallo la instanciacion del material: " + newMaterialID, this);
				if (output != null)
				{
					output(false);
				}
				yield break;
			}
			this.ReleaseMaterial(pieza, current);
			List<SlotDeMaterialDeRopa> list;
			if (!this.m_piezasPuestasDeConjuntoMaterialesPorId.TryGetValue(pendaID, out list))
			{
				list = new List<SlotDeMaterialDeRopa>();
				this.m_piezasPuestasDeConjuntoMaterialesPorId.Add(pendaID, list);
			}
			list.RemoveAll((SlotDeMaterialDeRopa s) => s.materialIDString == current.materialIDString);
			list.Add(newOne);
			PiezasDeRopaLoader.ChangeMainColor(copia, color, dataMaterial, newOne);
			pieza.ChangeMaterial(materialSlot, newOne, copia);
			PiezasDeRopaLoader.SetTessellationCongig(dataRopa, pieza);
			if (output != null)
			{
				output(true);
			}
			yield break;
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x00020DF5 File Offset: 0x0001EFF5
		private IEnumerator LoaderMaterialesRutine(IReadOnlyList<SlotDeMaterialDeRopa> pares, Renderer render, Action<List<SlotDeMaterialDeRopa>> output)
		{
			if (pares == null)
			{
				Debug.LogError("pares es null", render);
				output(null);
				yield break;
			}
			if (pares.Count == 0)
			{
				output(null);
				yield break;
			}
			Material[] shared = render.sharedMaterials;
			List<SlotDeMaterialDeRopa> added = new List<SlotDeMaterialDeRopa>(pares.Count);
			List<MaterialParaRopaData> validos_TEMP = new List<MaterialParaRopaData>();
			List<int> indexvalidos_TEMP = new List<int>();
			HashSet<int> hashSet = new HashSet<int>();
			for (int j = 0; j < pares.Count; j++)
			{
				SlotDeMaterialDeRopa slotDeMaterialDeRopa = pares[j];
				if (slotDeMaterialDeRopa == null)
				{
					Debug.LogWarning("MaterialDataIDSlotPar es nullo", this);
				}
				else if (slotDeMaterialDeRopa.materialSlot < 0)
				{
					Debug.LogWarning("MaterialDataIDSlotPar: material slot no es valido", this);
				}
				else if (hashSet.Contains(slotDeMaterialDeRopa.materialSlot))
				{
					Debug.LogWarning("MaterialDataIDSlotPar: material repetido", this);
				}
				else if (slotDeMaterialDeRopa.materialSlot >= shared.Length)
				{
					Debug.LogWarning("MaterialDataIDSlotPar: largo de arrays de materiales no es el mismo", this);
				}
				else
				{
					MaterialParaRopaData materialParaRopaData = AsyncSingleton<MaterialesParaRopa>.instance.ObtenerData(slotDeMaterialDeRopa.materialIDString);
					if (materialParaRopaData == null)
					{
						Debug.LogWarning("MaterialDataIDSlotPar: material id: " + slotDeMaterialDeRopa.materialIDString + ". no tiene data.", this);
					}
					else
					{
						indexvalidos_TEMP.Add(j);
						hashSet.Add(slotDeMaterialDeRopa.materialSlot);
						validos_TEMP.Add(materialParaRopaData);
						added.Add(slotDeMaterialDeRopa);
					}
				}
			}
			int num2;
			for (int i = 0; i < indexvalidos_TEMP.Count; i = num2 + 1)
			{
				int num = indexvalidos_TEMP[i];
				MaterialParaRopaData data = validos_TEMP[i];
				SlotDeMaterialDeRopa par = pares[num];
				if (!par.añadirUnaCopia)
				{
					throw new NotSupportedException("Todos los materiales deben ser instancias");
				}
				PiezasDeRopaLoader.<>c__DisplayClass55_0 CS$<>8__locals1 = new PiezasDeRopaLoader.<>c__DisplayClass55_0();
				CS$<>8__locals1.copia = null;
				yield return Singleton<AdresablesInstanciador>.instance.Instanciate<Material>(data.address, false, delegate(Material ins)
				{
					CS$<>8__locals1.copia = ins;
				}, null, null);
				AssetReference diffusionProfile = data.diffusionProfile;
				if (!string.IsNullOrWhiteSpace((diffusionProfile != null) ? diffusionProfile.AssetGUID : null))
				{
					PiezasDeRopaLoader.<>c__DisplayClass55_1 CS$<>8__locals2 = new PiezasDeRopaLoader.<>c__DisplayClass55_1();
					CS$<>8__locals2.diffusionProfileSettings = null;
					yield return Singleton<AdresablesInstanciador>.instance.Instanciate<DiffusionProfileSettings>(data.diffusionProfile, false, delegate(DiffusionProfileSettings ins)
					{
						CS$<>8__locals2.diffusionProfileSettings = ins;
					}, null, null);
					par.customDiffusionProfileSettings = CS$<>8__locals2.diffusionProfileSettings;
					CS$<>8__locals2 = null;
				}
				shared[par.materialSlot] = CS$<>8__locals1.copia;
				Color color = CS$<>8__locals1.copia.GetColor(PiezasDeRopaLoader._BaseColorID);
				Color color2 = color;
				if (data.puedeTenerCustomColor)
				{
					color2 = par.color;
					CS$<>8__locals1.copia.SetColor(PiezasDeRopaLoader._BaseColorID, color2);
				}
				if (!data.esTransparente)
				{
					color2.a = color.a;
					CS$<>8__locals1.copia.SetColor(PiezasDeRopaLoader._BaseColorID, color2);
				}
				CS$<>8__locals1 = null;
				data = null;
				par = null;
				num2 = i;
			}
			render.sharedMaterials = shared;
			for (int k = 0; k < validos_TEMP.Count; k++)
			{
				MaterialParaRopaData materialParaRopaData2 = validos_TEMP[k];
				if (materialParaRopaData2 != null)
				{
					materialParaRopaData2.OnUsed();
				}
			}
			output(added);
			yield break;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00020E19 File Offset: 0x0001F019
		private IEnumerator InstanciatorSingleRutine(MapaDeRopa.RopaData data, Animator anim, Action<GameObject, GameObject> output)
		{
			GameObject instancia = null;
			switch (data.comoInstanciar)
			{
			case MapaDeRopa.RopaData.InstanceOptions.todoElPrefab:
			{
				if (data.inGamePrefab != null)
				{
					instancia = Object.Instantiate<GameObject>(data.inGamePrefab, anim.transform, false);
					if (string.IsNullOrEmpty(data.skinName))
					{
						data.SetSkinName(data.inGamePrefab);
					}
				}
				else
				{
					yield return Singleton<AdresablesInstanciador>.instance.Instanciate<GameObject>(data.prefabAddress, true, delegate(GameObject r)
					{
						instancia = r;
					}, anim.transform, new bool?(false));
					if (string.IsNullOrEmpty(data.skinName))
					{
						data.SetSkinName(instancia);
					}
				}
				instancia.name = data.skinName;
				Transform instanciaArmature = null;
				Vector3 vector = default(Vector3);
				Quaternion quaternion = Quaternion.identity;
				if (!string.IsNullOrEmpty(data.armatureAddress.AssetGUID))
				{
					PiezasDeRopaLoader.<>c__DisplayClass56_1 CS$<>8__locals2 = new PiezasDeRopaLoader.<>c__DisplayClass56_1();
					yield return Singleton<AdresablesInstanciador>.instance.Instanciate<GameObject>(data.armatureAddress, false, delegate(GameObject r)
					{
						instanciaArmature = r.transform;
					}, instancia.transform, new bool?(false));
					CS$<>8__locals2.asset = null;
					yield return Singleton<AdresablesInstanciador>.instance.LoadParAsset<GameObject>(data.prefabAddress, delegate(GameObject a)
					{
						CS$<>8__locals2.asset = a;
					}, null);
					CS$<>8__locals2.armatureAsset = null;
					yield return Singleton<AdresablesInstanciador>.instance.LoadParAsset<GameObject>(data.armatureAddress, delegate(GameObject a)
					{
						CS$<>8__locals2.armatureAsset = a;
					}, null);
					vector = CS$<>8__locals2.asset.transform.InverseTransformPoint(CS$<>8__locals2.armatureAsset.transform.position);
					quaternion = Quaternion.Inverse(CS$<>8__locals2.asset.transform.rotation) * CS$<>8__locals2.armatureAsset.transform.rotation;
					instanciaArmature.name = CS$<>8__locals2.armatureAsset.name;
					Singleton<AdresablesInstanciador>.instance.CheckRelease(data.prefabAddress);
					Singleton<AdresablesInstanciador>.instance.CheckRelease(data.armatureAddress);
					Skin.MountToSkeleton(instancia, instanciaArmature);
					CS$<>8__locals2 = null;
				}
				instancia.transform.localPosition = Vector3.zero;
				instancia.transform.localRotation = Quaternion.identity;
				instancia.transform.localScale = Vector3.one;
				if (instanciaArmature != null)
				{
					instanciaArmature.position = instancia.transform.TransformPoint(vector);
					instanciaArmature.rotation = instancia.transform.rotation * quaternion;
					instanciaArmature.localScale = Vector3.one;
				}
				GameObject instancia2 = instancia;
				Transform instanciaArmature2 = instanciaArmature;
				output(instancia2, (instanciaArmature2 != null) ? instanciaArmature2.gameObject : null);
				yield break;
			}
			case MapaDeRopa.RopaData.InstanceOptions.soloSkinnedMeshRenderer:
				throw new NotSupportedException();
			case MapaDeRopa.RopaData.InstanceOptions.soloSkinnedMeshRendererGameObject:
				throw new NotSupportedException();
			default:
				Debug.LogError(data.comoInstanciar.ToString() + " no es soportado", this);
				output(null, null);
				yield break;
			}
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00020E3D File Offset: 0x0001F03D
		public IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(Pieza piezaPrefab, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase
		{
			return this.AddPiezaAsync<T_PiezaDeRopaAbstract>(piezaPrefab.ropaIDString, piezaPrefab.materiales, output, showLoadingScreen);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00020E53 File Offset: 0x0001F053
		public IEnumerator AddPiezaAsync<T_PiezaDeRopaAbstract>(string ropaId, IReadOnlyList<SlotDeMaterialDeRopa> materiales, Action<T_PiezaDeRopaAbstract> output, bool showLoadingScreen) where T_PiezaDeRopaAbstract : PiezaDeRopaBase
		{
			while (!base.isStared)
			{
				yield return null;
			}
			if (string.IsNullOrWhiteSpace(ropaId))
			{
				Debug.LogError("no se puede añadir pieza de ropa con id zero", this);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			Animator anim = this.character.bodyAnimator;
			if (anim == null)
			{
				Debug.LogError("anim null reference.", this);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			ArmatureSkins armature = anim.GetComponentInParent<ArmatureSkins>();
			if (armature == null)
			{
				Debug.LogError("armature null reference.", this);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			while (!AsyncSingleton<RopaParaAvatarUnificado>.instanceInitiated)
			{
				Debug.LogWarning("Waiting for RopaParaAvatarUnificado to init", this);
				yield return null;
			}
			IRopaParaAvatar instance = AsyncSingleton<RopaParaAvatarUnificado>.instance;
			if (instance == null)
			{
				Debug.LogError("instance de RopaParaAvatar singleton es null reference.", this);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			MapaDeRopa.RopaData data = instance.ObtenerData(ropaId);
			if (data == null)
			{
				Debug.LogError(string.Concat(new string[] { "añadiendo ropa de id ", ropaId, " a ", anim.name, ", fallo. Pieza no esta en singleton de IDs" }), ((output != null) ? output.Target : null) as Object);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			if (showLoadingScreen)
			{
				this.m_hideLoadingPanel.valor.valor = false;
			}
			GameObject ropaInstanciada = null;
			GameObject armatureGOInstanciada = null;
			yield return this.InstanciatorSingleRutine(data, anim, delegate(GameObject r, GameObject a)
			{
				ropaInstanciada = r;
				armatureGOInstanciada = a;
			});
			SkinnedMeshRenderer componentInChildren = ropaInstanciada.GetComponentInChildren<SkinnedMeshRenderer>();
			ICharacterSkinMeshConfig characterSkinMeshConfig = null;
			characterSkinMeshConfig = anim.transform.GetComponentEnRoot(false);
			if (characterSkinMeshConfig == null)
			{
				characterSkinMeshConfig = default(PiezasDeRopaLoader.DEF_CharacterMeshConfig);
			}
			List<ICustomClothingItemScript> customScripts = new List<ICustomClothingItemScript>();
			foreach (MapaDeRopa.RopaData.CustomScript customScript in data.customScripts)
			{
				try
				{
					Type type = Type.GetType(customScript.assemblyQualifiedName);
					if (type == null)
					{
						Singleton<ModalWindow>.instance.AcumularErrores("Could not load custom modding script of type " + customScript.assemblyQualifiedName, null);
						Debug.LogError("No se pudo cargar script de tipo: " + customScript.assemblyQualifiedName);
					}
					else if (!typeof(ICustomClothingItemScript).IsAssignableFrom(type))
					{
						Debug.LogError("Type : " + type.Name + " no implementa " + typeof(ICustomClothingItemScript).Name);
					}
					else
					{
						Component component = ropaInstanciada.AddComponent(type);
						customScripts.Add(component as ICustomClothingItemScript);
					}
				}
				catch (Exception ex)
				{
					Debug.LogException(ex, this);
				}
			}
			ArmatureSkins armatureSkins = armature;
			SerializableType tipo = data.tipo;
			Type type2 = ((((tipo != null) ? tipo.type : null) == null) ? typeof(PiezaDeRopa) : data.tipo.type);
			SkinnedMeshRenderer skinnedMeshRenderer = componentInChildren;
			SkinConfig skinConfig = data.skinConfig;
			bool flag = false;
			bool flag2 = false;
			ICharacterSkinMeshConfig characterSkinMeshConfig2 = characterSkinMeshConfig;
			Action<T_PiezaDeRopaAbstract> action = delegate(T_PiezaDeRopaAbstract sk)
			{
				PiezaDeRopaBase piezaDeRopaBase2 = sk;
				MapaDeRopa.RopaData data2 = data;
				GameObject armatureGOInstanciada2 = armatureGOInstanciada;
				piezaDeRopaBase2.InitPiezaDeRopa(data2, (armatureGOInstanciada2 != null) ? armatureGOInstanciada2.transform : null, new GameObject[] { ropaInstanciada, armatureGOInstanciada }, materiales, customScripts);
			};
			object data3 = data;
			GameObject armatureGOInstanciada3 = armatureGOInstanciada;
			T_PiezaDeRopaAbstract nuevaPieza = armatureSkins.AddSkin<T_PiezaDeRopaAbstract>(type2, skinnedMeshRenderer, skinConfig, flag, flag2, characterSkinMeshConfig2, action, data3, (armatureGOInstanciada3 != null) ? armatureGOInstanciada3.transform : null);
			if (nuevaPieza == null)
			{
				this.m_hideLoadingPanel.valor.valor = true;
				Debug.LogError(string.Concat(new string[] { "añadiendo ropa de id ", ropaId, " a ", anim.name, ", fallo" }), this);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
				yield break;
			}
			if (materiales != null && materiales.Count > 0)
			{
				PiezasDeRopaLoader.<>c__DisplayClass59_1<T_PiezaDeRopaAbstract> CS$<>8__locals2 = new PiezasDeRopaLoader.<>c__DisplayClass59_1<T_PiezaDeRopaAbstract>();
				CS$<>8__locals2.matAdded = null;
				yield return this.LoaderMaterialesRutine(materiales, nuevaPieza.skinnedMeshRenderer, delegate(List<SlotDeMaterialDeRopa> r)
				{
					CS$<>8__locals2.matAdded = r;
				});
				int count = CS$<>8__locals2.matAdded.Count;
				int count2 = materiales.Count;
				if (count != count2)
				{
					Debug.LogError(string.Concat(new string[] { "añadiendo materiales a ", anim.name, " con ropa de id a ", ropaId, " fallo en todos o algunos" }), this);
				}
				List<SlotDeMaterialDeRopa> list;
				if (!this.m_piezasPuestasDeConjuntoMaterialesPorId.TryGetValue(ropaId, out list))
				{
					list = new List<SlotDeMaterialDeRopa>();
					this.m_piezasPuestasDeConjuntoMaterialesPorId.Add(ropaId, list);
				}
				if (CS$<>8__locals2.matAdded != null)
				{
					list.AddRange(CS$<>8__locals2.matAdded);
				}
				PiezasDeRopaLoader.SetTessellationCongig(data, nuevaPieza);
				CS$<>8__locals2 = null;
			}
			try
			{
				customScripts.ForEach(delegate(ICustomClothingItemScript cS)
				{
					cS.OnMaterialsAdded();
				});
			}
			catch (Exception ex2)
			{
				Debug.LogException(ex2, this);
			}
			this.m_piezasPuestas.Add(nuevaPieza);
			this.m_piezasPuestasPorId.Add(ropaId, nuevaPieza);
			this.Subscribe(nuevaPieza);
			this.OnPiezasChanged();
			this.m_hideLoadingPanel.valor.valor = true;
			if (base.isDestroyed)
			{
				PiezaDeRopaBase piezaDeRopaBase;
				this.RemovePieza(ropaId, true, out piezaDeRopaBase);
				if (output != null)
				{
					output(default(T_PiezaDeRopaAbstract));
				}
			}
			else
			{
				if (output != null)
				{
					output(nuevaPieza);
				}
				data.OnUsed();
			}
			yield break;
		}

		// Token: 0x04000570 RID: 1392
		public static readonly int _BaseColorID = Shader.PropertyToID("_BaseColor");

		// Token: 0x04000572 RID: 1394
		[Obsolete("Se unificaron los mapas", true)]
		private RopaTipoDeSingleton map;

		// Token: 0x04000573 RID: 1395
		[SerializeField]
		private RopaCubre m_cubriendoFlags;

		// Token: 0x04000574 RID: 1396
		private Character m_character;

		// Token: 0x04000575 RID: 1397
		[ReadOnlyUI]
		[SerializeField]
		private List<PiezaDeRopaBase> m_piezasPuestas;

		// Token: 0x04000576 RID: 1398
		private Dictionary<string, PiezaDeRopaBase> m_piezasPuestasPorId = new Dictionary<string, PiezaDeRopaBase>();

		// Token: 0x04000577 RID: 1399
		private Dictionary<string, List<SlotDeMaterialDeRopa>> m_piezasPuestasDeConjuntoMaterialesPorId = new Dictionary<string, List<SlotDeMaterialDeRopa>>();

		// Token: 0x04000578 RID: 1400
		[SerializeReference]
		private ModificadorDeBool m_hideLoadingPanel;

		// Token: 0x04000579 RID: 1401
		private static List<PiezaDeRopaBase> m_TempPiezasPuestas = new List<PiezaDeRopaBase>();

		// Token: 0x0400057A RID: 1402
		private static List<PiezaDeRopaBase> m_TEMP_SYNC_ONLY = new List<PiezaDeRopaBase>();

		// Token: 0x02000129 RID: 297
		// (Invoke) Token: 0x06000707 RID: 1799
		public delegate void OnChangedHandler(RopaCubre last, RopaCubre @new, PiezasDeRopaLoader sender);

		// Token: 0x0200012A RID: 298
		private struct DEF_CharacterMeshConfig : ICharacterSkinMeshConfig
		{
			// Token: 0x17000178 RID: 376
			// (get) Token: 0x0600070A RID: 1802 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.arreglaNormalesMagnitud
			{
				get
				{
					return false;
				}
			}

			// Token: 0x17000179 RID: 377
			// (get) Token: 0x0600070B RID: 1803 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.copiaShapeKeys
			{
				get
				{
					return false;
				}
			}

			// Token: 0x1700017A RID: 378
			// (get) Token: 0x0600070C RID: 1804 RVA: 0x00004252 File Offset: 0x00002452
			bool ICharacterSkinMeshConfig.recalculaNormales
			{
				get
				{
					return false;
				}
			}
		}
	}
}
