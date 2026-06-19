using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles.UI;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.Archivos;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using Assets._ReusableScripts.UI.Modales.Globales;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x0200001E RID: 30
	public class SimplifiedAutoRatings : Singleton<SimplifiedAutoRatings>
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000128 RID: 296 RVA: 0x00006C78 File Offset: 0x00004E78
		public AutoRatingProfile autoRatingProfile
		{
			get
			{
				if (this.m_grupo == null || !this.m_grupo.IsValid())
				{
					return null;
				}
				return this.m_grupo;
			}
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006C98 File Offset: 0x00004E98
		protected override void Awaking()
		{
			base.Awaking();
			if (GlobalSingletonV2<MemoriaJson>.instance.isLoadedFromDisk)
			{
				Debug.LogError("deberia reinicicarse la memoria antes de cargar denuevo autoratings");
			}
			GlobalSingletonV2<MemoriaJson>.instance.loadedFromDisk += this.OnLoadedFromDisk;
			GlobalSingletonV2<MemoriaJson>.instance.onResetMemory += this.OnResetMem;
			this.m_PanelEditorDeAutoRatingProfiles = base.GetComponentInChildren<PanelEditorDeAutoRatingProfiles>();
			if (this.m_PanelEditorDeAutoRatingProfiles == null)
			{
				throw new ArgumentNullException("m_PanelEditorDeAutoRatingProfiles", "m_PanelEditorDeAutoRatingProfiles null reference.");
			}
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006D17 File Offset: 0x00004F17
		protected override void OnDestroyed(bool wasInitiated)
		{
			base.OnDestroyed(wasInitiated);
			if (SingletonV2<MemoriaJson>.IsInScene)
			{
				GlobalSingletonV2<MemoriaJson>.instance.onResetMemory -= this.OnResetMem;
				GlobalSingletonV2<MemoriaJson>.instance.loadedFromDisk -= this.OnLoadedFromDisk;
			}
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006D54 File Offset: 0x00004F54
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

		// Token: 0x0600012C RID: 300 RVA: 0x00006DE5 File Offset: 0x00004FE5
		private void OnResetMem(MemoriaJson obj)
		{
			this.ReadDataFromMemory();
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006DED File Offset: 0x00004FED
		private void OnLoadedFromDisk(MemoriaJson obj)
		{
			this.ReadDataFromMemory();
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006DF5 File Offset: 0x00004FF5
		public PanelEditorDeAutoRatingProfiles OpenEditor(string profileName = null)
		{
			this.m_PanelEditorDeAutoRatingProfiles.CrearYDibujar(null);
			if (!string.IsNullOrWhiteSpace(profileName))
			{
				this.m_PanelEditorDeAutoRatingProfiles.LoadProfile(profileName);
			}
			return this.m_PanelEditorDeAutoRatingProfiles;
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00006E20 File Offset: 0x00005020
		public void ReadDataFromMemory()
		{
			AutoRatingProfile grupo = this.m_grupo;
			if (grupo != null)
			{
				grupo.Reset();
			}
			try
			{
				IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profile/", true);
				string text = jsonMemoryNode.FindData("Interpretation", null);
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text2 = jsonMemoryNode.FindData("Archive", null);
					Texture2D texture2D = this.LoadProfilePictureFromMemory(jsonMemoryNode);
					AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(text);
					this.ChangeProfile(autoRatingWraper.modo, text2, ref autoRatingWraper.simple, ref autoRatingWraper.completa, texture2D, false);
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				Singleton<ModalWindow>.instance.AcumularErrores(ex.Message, null);
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00006ED0 File Offset: 0x000050D0
		private Texture2D LoadProfilePictureFromMemory(IJsonMemoryNode profilesMem)
		{
			Texture2D texture2D = profilesMem.FindDataImage("Pic");
			if (texture2D == null)
			{
				string text = "Could not find current profile image in memory";
				Debug.LogError(text, this);
				Singleton<ModalWindow>.instance.AcumularErrores(text, null);
				texture2D = new Texture2D(2, 2);
			}
			return texture2D;
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00006F14 File Offset: 0x00005114
		public Texture2D LoadProfilePictureFromMemory()
		{
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profile/", true);
			return this.LoadProfilePictureFromMemory(jsonMemoryNode);
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00006F3C File Offset: 0x0000513C
		public void ChangeProfile(int mode, string nombre, ref InterpretacionSimple simple, ref InterpretacionCompletaDeFemale complete, Texture2D imagen, bool saveToMemory)
		{
			AutoRatingProfile grupo = this.m_grupo;
			if (grupo != null)
			{
				grupo.Reset();
			}
			if (this.m_grupo == null)
			{
				this.m_grupo = new AutoRatingProfile();
			}
			this.m_grupo.mode = mode;
			this.m_grupo.nombre = nombre;
			this.m_grupo.simple = simple;
			this.m_grupo.completa = complete;
			this.m_grupo.picture = imagen;
			if (!this.m_grupo.IsValid())
			{
				throw new InvalidOperationException("profile data no es valida");
			}
			if (saveToMemory)
			{
				IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profile/", true);
				jsonMemoryNode.AddData("Archive", nombre, true);
				string text = JsonUtility.ToJson(new AutoRatingWraper
				{
					modo = mode,
					simple = simple,
					completa = complete
				});
				jsonMemoryNode.AddData("Interpretation", text, true);
				jsonMemoryNode.AddData("Pic", imagen, true);
			}
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00007033 File Offset: 0x00005233
		public void RemoveProfile(bool saveToMemory)
		{
			AutoRatingProfile grupo = this.m_grupo;
			if (grupo != null)
			{
				grupo.Reset();
			}
			if (saveToMemory)
			{
				GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("root/AutoRatings/Profile/", true).ClearData();
			}
		}

		// Token: 0x06000134 RID: 308 RVA: 0x0000705E File Offset: 0x0000525E
		public bool AutoRatingSeAplica()
		{
			return this.autoRatingProfile != null;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000706C File Offset: 0x0000526C
		public AutoRatingProfile Score(ref InterpretacionCompletaDeFemale interpretacion, IDictionary<string, float> aparienciaResult, IDictionary<string, float> personalidadResult)
		{
			if (!this.AutoRatingSeAplica())
			{
				throw new InvalidOperationException("No se puede aplicar auto rating");
			}
			AutoRatingProfile autoRatingProfile = this.autoRatingProfile;
			int mode = autoRatingProfile.mode;
			if (mode != 0)
			{
				if (mode != 1)
				{
					throw new ArgumentOutOfRangeException(autoRatingProfile.mode.ToString());
				}
			}
			else
			{
				autoRatingProfile.simple.ConvertirA(ref autoRatingProfile.completa);
			}
			AutoRatingHelper.Score(ref autoRatingProfile.completa, ref interpretacion, aparienciaResult, personalidadResult);
			return autoRatingProfile;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x000070D6 File Offset: 0x000052D6
		public override SingletonEditorBotones Boton1()
		{
			return new SingletonEditorBotones
			{
				text = "Load Newer",
				editorTimeVisible = false
			};
		}

		// Token: 0x06000137 RID: 311 RVA: 0x000070F0 File Offset: 0x000052F0
		public override void Aplicar1()
		{
			base.Aplicar1();
			List<string> list;
			string text = ArchivosEnDisco.ExistentesPorFechaModificacion(".png", out list, new GameFolders.Tipo[] { GameFolders.Tipo.autoRatingPortraitsV2 }).First<string>();
			Texture2D texture2D;
			byte[] array;
			SaveLoadProfilePortraits.Cargar(text, out texture2D, out array);
			AutoRatingWraper autoRatingWraper = JsonUtility.FromJson<AutoRatingWraper>(Encoding.UTF8.GetString(array));
			this.ChangeProfile(autoRatingWraper.modo, text, ref autoRatingWraper.simple, ref autoRatingWraper.completa, texture2D, true);
		}

		// Token: 0x040000B7 RID: 183
		public const string autoRatingsSaveName = "AutoRatings";

		// Token: 0x040000B8 RID: 184
		public const string profileSaveName = "Profile";

		// Token: 0x040000B9 RID: 185
		public const string archivoName = "Archive";

		// Token: 0x040000BA RID: 186
		public const string interpretacion = "Interpretation";

		// Token: 0x040000BB RID: 187
		public const string picture = "Pic";

		// Token: 0x040000BC RID: 188
		public const string profilesRuta = "root/AutoRatings/Profile/";

		// Token: 0x040000BD RID: 189
		private PanelEditorDeAutoRatingProfiles m_PanelEditorDeAutoRatingProfiles;

		// Token: 0x040000BE RID: 190
		[SerializeReference]
		private AutoRatingProfile m_grupo;
	}
}
