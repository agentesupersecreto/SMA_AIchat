using System;
using System.Collections.Generic;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using Assets._ReusableScripts.NPCs;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs
{
	// Token: 0x02000071 RID: 113
	[CreateAssetMenu(fileName = "SujetoIdentificableNpcAlteradoresFemeninos", menuName = "Objetos/Genetica/Sujeto Identificable Npc Alteradores Femeninos")]
	public class SujetoIdentificableNpcAlteradoresFemeninos : AplicableScriptable, ISujetoIdentificableNpc, ISujetoNpc, INpc, INpcIdentificable, ISujetoNivel, ISujetoCalificable
	{
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00012604 File Offset: 0x00010804
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x00012664 File Offset: 0x00010864
		int ISujetoNivel.nivel
		{
			get
			{
				SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = this.aparienciaFisicaMapa;
				int valueOrDefault = ((sujetoIdentificableAlteradoresAparienciaFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresAparienciaFemeninos).nivel) : null).GetValueOrDefault();
				SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = this.personalidadMapa;
				return Mathf.Max(valueOrDefault, ((sujetoIdentificableAlteradoresPersonalidadFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresPersonalidadFemeninos).nivel) : null).GetValueOrDefault());
			}
			set
			{
				ISujetoNivel sujetoNivel = this.aparienciaFisicaMapa;
				if (sujetoNivel != null)
				{
					sujetoNivel.nivel = value;
				}
				ISujetoNivel sujetoNivel2 = this.personalidadMapa;
				if (sujetoNivel2 != null)
				{
					sujetoNivel2.nivel = value;
				}
			}
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00012693 File Offset: 0x00010893
		[Obsolete]
		void ISujetoNivel.SubirNivel()
		{
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = this.aparienciaFisicaMapa;
			if (sujetoIdentificableAlteradoresAparienciaFemeninos != null)
			{
				((ISujetoNivel)sujetoIdentificableAlteradoresAparienciaFemeninos).SubirNivel();
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = this.personalidadMapa;
			if (sujetoIdentificableAlteradoresPersonalidadFemeninos == null)
			{
				return;
			}
			((ISujetoNivel)sujetoIdentificableAlteradoresPersonalidadFemeninos).SubirNivel();
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x000126B6 File Offset: 0x000108B6
		// (set) Token: 0x0600052E RID: 1326 RVA: 0x000126C9 File Offset: 0x000108C9
		public bool rated
		{
			get
			{
				return this.m_extraData.FindDataBool("Rated", false);
			}
			set
			{
				this.m_extraData.AddData("Rated", value, true);
			}
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x000126DD File Offset: 0x000108DD
		// (set) Token: 0x06000530 RID: 1328 RVA: 0x000126F0 File Offset: 0x000108F0
		public bool interviewed
		{
			get
			{
				return this.m_extraData.FindDataBool("Interviewed", false);
			}
			set
			{
				this.m_extraData.AddData("Interviewed", value, true);
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000531 RID: 1329 RVA: 0x00012704 File Offset: 0x00010904
		// (set) Token: 0x06000532 RID: 1330 RVA: 0x00012717 File Offset: 0x00010917
		[Obsolete("", true)]
		public bool calificado
		{
			get
			{
				return this.m_extraData.FindDataBool("CALIFICADO", false);
			}
			set
			{
				this.m_extraData.AddData("CALIFICADO", value, true);
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000533 RID: 1331 RVA: 0x0001272C File Offset: 0x0001092C
		// (set) Token: 0x06000534 RID: 1332 RVA: 0x00012784 File Offset: 0x00010984
		public Guid NpcID
		{
			get
			{
				if (this.m_NpcID == null)
				{
					try
					{
						this.m_NpcID = new Guid?(new Guid(this.m_ID));
					}
					catch (Exception ex)
					{
						Debug.LogException(ex, this);
						throw ex;
					}
				}
				return this.m_NpcID.Value;
			}
			set
			{
				this.m_NpcID = new Guid?(value);
				this.m_ID = this.m_NpcID.ToString();
			}
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x000127A9 File Offset: 0x000109A9
		public void SetStringID(string value)
		{
			this.m_ID = value;
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x000127B2 File Offset: 0x000109B2
		public ISujetoIdentificable aparienciaFisica
		{
			get
			{
				return this.aparienciaFisicaMapa;
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x000127BA File Offset: 0x000109BA
		public ISujetoIdentificable personalidad
		{
			get
			{
				return this.personalidadMapa;
			}
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x000127C2 File Offset: 0x000109C2
		public void Destruir()
		{
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = this.aparienciaFisicaMapa;
			if (sujetoIdentificableAlteradoresAparienciaFemeninos != null)
			{
				sujetoIdentificableAlteradoresAparienciaFemeninos.Destruir();
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = this.personalidadMapa;
			if (sujetoIdentificableAlteradoresPersonalidadFemeninos != null)
			{
				sujetoIdentificableAlteradoresPersonalidadFemeninos.Destruir();
			}
			if (TValleEditorTools.IsPersistent(this))
			{
				return;
			}
			Object.Destroy(this);
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x000127F5 File Offset: 0x000109F5
		public ISerializedDataContainer dataContainer
		{
			get
			{
				return this.m_extraData;
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00012800 File Offset: 0x00010A00
		[Obsolete("usar ISerializedDataContainer property", true)]
		public string FindData(string id)
		{
			string text;
			if (this.m_extraData.TryGetValue(id, out text))
			{
				return text;
			}
			return null;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x00012820 File Offset: 0x00010A20
		[Obsolete("usar ISerializedDataContainer property", true)]
		public void AddData(string id, string data)
		{
			if (this.m_extraData.ContainsKey(id))
			{
				this.m_extraData[id] = data;
				return;
			}
			this.m_extraData.Add(id, data);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0001284B File Offset: 0x00010A4B
		public IReadOnlyDictionary<string, string> GetAllData()
		{
			return this.m_extraData;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x00012871 File Offset: 0x00010A71
		string ISujetoCalificable.get_name()
		{
			return base.name;
		}

		// Token: 0x04000243 RID: 579
		[SerializeField]
		private string m_ID = "default";

		// Token: 0x04000244 RID: 580
		[SerializeField]
		private StringKeyStringValueDictionary m_extraData = new StringKeyStringValueDictionary();

		// Token: 0x04000245 RID: 581
		private Guid? m_NpcID;

		// Token: 0x04000246 RID: 582
		public SujetoIdentificableAlteradoresAparienciaFemeninos aparienciaFisicaMapa;

		// Token: 0x04000247 RID: 583
		public SujetoIdentificableAlteradoresPersonalidadFemeninos personalidadMapa;
	}
}
