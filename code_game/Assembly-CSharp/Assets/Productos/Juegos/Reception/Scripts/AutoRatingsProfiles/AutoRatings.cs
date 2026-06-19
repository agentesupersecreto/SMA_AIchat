using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.UI;
using Assets.Productos.Juegos.Reception.Scripts.Genetica.Eventos;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.UI.Modales;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x020000C6 RID: 198
	[Obsolete("use simplified version", true)]
	public class AutoRatings : Singleton<AutoRatings>
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x00017D14 File Offset: 0x00015F14
		protected override void Awaking()
		{
			base.Awaking();
			this.m_grupoA = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 0
			};
			this.m_grupoB = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 1
			};
			this.m_grupoC = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 2
			};
			this.m_grupoD = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 3
			};
			this.m_grupoE = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 4
			};
			this.m_grupoF = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 5
			};
			this.m_grupoG = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 6
			};
			this.m_grupoH = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 7
			};
			this.m_grupoI = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 8
			};
			this.m_grupoJ = new AutoRatings.GrupoProfilePar
			{
				grupoIndex = 9
			};
			if (GlobalSingletonV2<MemoriaJson>.instance.isLoadedFromDisk)
			{
				Debug.LogError("deberia reinicicarse la memoria antes de cargar denuevo autoratings");
			}
			GlobalSingletonV2<MemoriaJson>.instance.loadedFromDisk += this.OnLoadedFromDisk;
			GlobalSingletonV2<MemoriaJson>.instance.onResetMemory += this.OnResetMem;
			this.m_PanelProfilesDeGrupos = base.GetComponentInChildren<PanelProfilesDeGrupos>();
			if (this.m_PanelProfilesDeGrupos == null)
			{
				throw new ArgumentNullException("m_PanelProfilesDeGrupos", "m_PanelProfilesDeGrupos null reference.");
			}
			this.m_PanelEditorDeAutoRatingProfiles = base.GetComponentInChildren<PanelEditorDeAutoRatingProfiles>();
			if (this.m_PanelEditorDeAutoRatingProfiles == null)
			{
				throw new ArgumentNullException("m_PanelEditorDeAutoRatingProfiles", "m_PanelEditorDeAutoRatingProfiles null reference.");
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00017E72 File Offset: 0x00016072
		private void Start()
		{
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x00017E74 File Offset: 0x00016074
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (SingletonV2<MemoriaJson>.IsInScene)
			{
				GlobalSingletonV2<MemoriaJson>.instance.onResetMemory -= this.OnResetMem;
				GlobalSingletonV2<MemoriaJson>.instance.loadedFromDisk -= this.OnLoadedFromDisk;
			}
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00017EB0 File Offset: 0x000160B0
		protected override void OnDestroyingThisDuplicated()
		{
			base.OnDestroyingThisDuplicated();
			if (SingletonV2<MemoriaJson>.IsInScene)
			{
				GlobalSingletonV2<MemoriaJson>.instance.onResetMemory -= this.OnResetMem;
				GlobalSingletonV2<MemoriaJson>.instance.loadedFromDisk -= this.OnLoadedFromDisk;
			}
			for (int i = 0; i < base.transform.childCount; i++)
			{
				if (base.transform.GetChild(i) != null)
				{
					Object.Destroy(base.transform.GetChild(i).gameObject);
				}
			}
			Object.Destroy(base.gameObject);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00017F41 File Offset: 0x00016141
		private void OnResetMem(MemoriaJson obj)
		{
			this.ReadDataFromMemory();
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x00017F49 File Offset: 0x00016149
		private void OnLoadedFromDisk(MemoriaJson obj)
		{
			this.ReadDataFromMemory();
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00017F51 File Offset: 0x00016151
		[Obsolete("ahora es un singleton", true)]
		public AutoRatingProfilePreview GetPreviwer()
		{
			this.m_instanceDePreviwer.gameObject.SetActive(true);
			return this.m_instanceDePreviwer;
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00017F6A File Offset: 0x0001616A
		public PanelEditorDeAutoRatingProfiles OpenEditor(string profileName = null)
		{
			this.m_PanelEditorDeAutoRatingProfiles.CrearYDibujar(null);
			if (!string.IsNullOrWhiteSpace(profileName))
			{
				this.m_PanelEditorDeAutoRatingProfiles.LoadProfile(profileName);
			}
			return this.m_PanelEditorDeAutoRatingProfiles;
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00017F92 File Offset: 0x00016192
		public PanelProfilesDeGrupos OpenEditorDeGrupos()
		{
			this.m_PanelProfilesDeGrupos.CrearYDibujar(null);
			return this.m_PanelProfilesDeGrupos;
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x00017FA8 File Offset: 0x000161A8
		public void ReadDataFromMemory()
		{
			for (int i = 0; i < 10; i++)
			{
				this.GetGrupo(i).Reset();
			}
			IMemoryNode<string, string> memoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profiles/", true);
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> keyValuePair in memoryNode.data)
			{
				int num;
				if (!string.IsNullOrWhiteSpace(keyValuePair.Key) && !string.IsNullOrWhiteSpace(keyValuePair.Value) && AutoRatings.numberNamesInv.TryGetValue(keyValuePair.Key, out num))
				{
					this.GetGrupo(num);
					if (!SaveLoadProfilePortraits.Existe(keyValuePair.Value))
					{
						list.Add(keyValuePair.Value);
					}
					else
					{
						Texture2D texture2D;
						byte[] array;
						SaveLoadProfilePortraits.Cargar(keyValuePair.Value, out texture2D, out array);
						if (!(texture2D == null) && array != null && array.Length != 0)
						{
							string @string = Encoding.UTF8.GetString(array);
							try
							{
								AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(@string);
								this.ChangeProfile(num, autoRatingWraper.modo, keyValuePair.Value, ref autoRatingWraper.simple, ref autoRatingWraper.completa, false);
							}
							catch (Exception ex)
							{
								Debug.LogException(ex, this);
								Singleton<ModalWindow>.instance.AcumularErrores(ex.Message, null);
							}
							finally
							{
								Object.Destroy(texture2D);
							}
						}
					}
				}
			}
			if (list.Count > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 0; j < list.Count; j++)
				{
					stringBuilder.Append(list[j]);
					if (!j.IsLastIndex(list.Count))
					{
						stringBuilder.Append(',');
						stringBuilder.Append(' ');
					}
				}
				string text = "Missing Auto-Rating profiles:\u00a0" + stringBuilder.ToString() + ".";
				if (Singleton<ModalWindow>.IsInScene)
				{
					ErrorDialog modal = Singleton<ModalWindow>.instance.MostrarErrorDialog();
					modal.pregunta.text = text;
					modal.aceptar.onClick.AddListener(delegate
					{
						Singleton<ModalWindow>.instance.Clear(modal);
					});
				}
				Debug.LogError(text, this);
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00018218 File Offset: 0x00016418
		public void ChangeProfile(int grupoIndex, int mode, string nombre, ref InterpretacionSimple simple, ref InterpretacionCompletaDeFemale complete, bool saveToMemory)
		{
			AutoRatings.GrupoProfilePar grupo = this.GetGrupo(grupoIndex);
			grupo.grupoIndex = grupoIndex;
			if (grupo.profile == null)
			{
				grupo.profile = new AutoRatingProfile();
			}
			grupo.profile.mode = mode;
			grupo.profile.nombre = nombre;
			grupo.profile.simple = simple;
			grupo.profile.completa = complete;
			if (saveToMemory)
			{
				GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profiles/", true).AddData(AutoRatings.numberNames[grupoIndex], nombre, true);
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000182AC File Offset: 0x000164AC
		public void RemoveProfile(int grupoIndex, bool saveToMemory)
		{
			AutoRatings.GrupoProfilePar grupo = this.GetGrupo(grupoIndex);
			grupo.grupoIndex = grupoIndex;
			if (grupo.profile == null)
			{
				grupo.profile = new AutoRatingProfile();
			}
			grupo.profile.mode = -1;
			grupo.profile.nombre = string.Empty;
			grupo.profile.simple = default(InterpretacionSimple);
			grupo.profile.completa = default(InterpretacionCompletaDeFemale);
			if (saveToMemory)
			{
				GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profiles/", true).AddData(AutoRatings.numberNames[grupoIndex], string.Empty, true);
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x00018342 File Offset: 0x00016542
		public bool GrupoEsDesblokeado(int grupoIndex)
		{
			if (!Singleton<PiscinasDeEventosDeEntrevista>.IsInScene)
			{
				return true;
			}
			if (grupoIndex < 0)
			{
				Debug.LogError("Index de grupo fue invalido", this);
				return false;
			}
			return grupoIndex < Singleton<PiscinasDeEventosDeEntrevista>.instance.GetNivelTotalClamped();
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x0001836C File Offset: 0x0001656C
		public AutoRatings.GrupoProfilePar GetGrupo(int index)
		{
			switch (index)
			{
			case 0:
				return this.m_grupoA;
			case 1:
				return this.m_grupoB;
			case 2:
				return this.m_grupoC;
			case 3:
				return this.m_grupoD;
			case 4:
				return this.m_grupoE;
			case 5:
				return this.m_grupoF;
			case 6:
				return this.m_grupoG;
			case 7:
				return this.m_grupoH;
			case 8:
				return this.m_grupoI;
			case 9:
				return this.m_grupoJ;
			default:
				throw new ArgumentOutOfRangeException(index.ToString());
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x000183FB File Offset: 0x000165FB
		public bool AutoRatingSeAplicaAGrupo(int profileIndex)
		{
			return this.GetGrupo(profileIndex).IsValid();
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x0001840C File Offset: 0x0001660C
		public bool AutoRatingFaltantePorConfig(int lvl)
		{
			lvl = Mathf.Clamp(lvl, 1, 10);
			for (int i = 0; i < lvl; i++)
			{
				if (!this.GetGrupo(i).IsValid())
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x00018444 File Offset: 0x00016644
		public AutoRatingProfile Score(int profileIndex, ref InterpretacionCompletaDeFemale interpretacion, IDictionary<string, float> aparienciaResult, IDictionary<string, float> personalidadResult)
		{
			if (!this.AutoRatingSeAplicaAGrupo(profileIndex))
			{
				throw new InvalidOperationException("No se puede aplicar auto rating a grupo index: " + profileIndex.ToString());
			}
			AutoRatings.GrupoProfilePar grupo = this.GetGrupo(profileIndex);
			int mode = grupo.profile.mode;
			if (mode != 0)
			{
				if (mode != 1)
				{
					throw new ArgumentOutOfRangeException(grupo.profile.mode.ToString());
				}
			}
			else
			{
				grupo.profile.simple.ConvertirA(ref grupo.profile.completa);
			}
			AutoRatingHelper.Score(ref grupo.profile.completa, ref interpretacion, aparienciaResult, personalidadResult);
			return grupo.profile;
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000184DB File Offset: 0x000166DB
		public override void Aplicar1()
		{
			base.Aplicar1();
			this.OpenEditor(null);
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000184EB File Offset: 0x000166EB
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				editorTimeVisible = false,
				text = "Opne Editor"
			};
		}

		// Token: 0x04000228 RID: 552
		public const string autoRatingsSaveName = "AutoRatings";

		// Token: 0x04000229 RID: 553
		public const string profilesSaveName = "Profiles";

		// Token: 0x0400022A RID: 554
		public const string profilesRuta = "root/AutoRatings/Profiles/";

		// Token: 0x0400022B RID: 555
		private static readonly Dictionary<int, string> numberNames = new Dictionary<int, string>
		{
			{ 0, "Zero" },
			{ 1, "One" },
			{ 2, "Two" },
			{ 3, "Three" },
			{ 4, "Four" },
			{ 5, "Five" },
			{ 6, "Six" },
			{ 7, "Seven" },
			{ 8, "Eight" },
			{ 9, "Nine" },
			{ 10, "Ten" }
		};

		// Token: 0x0400022C RID: 556
		private static readonly Dictionary<string, int> numberNamesInv = AutoRatings.numberNames.ToDictionary((KeyValuePair<int, string> x) => x.Value, (KeyValuePair<int, string> x) => x.Key);

		// Token: 0x0400022D RID: 557
		[Obsolete("", true)]
		public AutoRatingProfilePreview profilePreviwer;

		// Token: 0x0400022E RID: 558
		[Obsolete("", true)]
		[ReadOnlyUI]
		[SerializeField]
		private AutoRatingProfilePreview m_instanceDePreviwer;

		// Token: 0x0400022F RID: 559
		private PanelEditorDeAutoRatingProfiles m_PanelEditorDeAutoRatingProfiles;

		// Token: 0x04000230 RID: 560
		private PanelProfilesDeGrupos m_PanelProfilesDeGrupos;

		// Token: 0x04000231 RID: 561
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoA;

		// Token: 0x04000232 RID: 562
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoB;

		// Token: 0x04000233 RID: 563
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoC;

		// Token: 0x04000234 RID: 564
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoD;

		// Token: 0x04000235 RID: 565
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoE;

		// Token: 0x04000236 RID: 566
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoF;

		// Token: 0x04000237 RID: 567
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoG;

		// Token: 0x04000238 RID: 568
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoH;

		// Token: 0x04000239 RID: 569
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoI;

		// Token: 0x0400023A RID: 570
		[SerializeField]
		private AutoRatings.GrupoProfilePar m_grupoJ;

		// Token: 0x0200012C RID: 300
		[Serializable]
		public class GrupoProfilePar
		{
			// Token: 0x0600065A RID: 1626 RVA: 0x0001CDF7 File Offset: 0x0001AFF7
			public bool IsValid()
			{
				return this.grupoIndex > -1 && this.profile != null && this.profile.IsValid();
			}

			// Token: 0x0600065B RID: 1627 RVA: 0x0001CE17 File Offset: 0x0001B017
			public void Reset()
			{
				AutoRatingProfile autoRatingProfile = this.profile;
				if (autoRatingProfile == null)
				{
					return;
				}
				autoRatingProfile.Reset();
			}

			// Token: 0x040003D7 RID: 983
			public int grupoIndex = -1;

			// Token: 0x040003D8 RID: 984
			public AutoRatingProfile profile;
		}
	}
}
