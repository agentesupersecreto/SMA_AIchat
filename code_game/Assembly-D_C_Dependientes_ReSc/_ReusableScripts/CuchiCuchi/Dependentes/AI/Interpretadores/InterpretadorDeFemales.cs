using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Genetica;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Globales;
using Assets._ReusableScripts.CuchiCuchi.Chars.Materiales.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Helpers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores.Mapas;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Hair;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores
{
	// Token: 0x0200038E RID: 910
	public class InterpretadorDeFemales : HelperDeInterpretadorBase, IFemaleCharInfo, IFemaleCharInfoPromediable
	{
		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060016A1 RID: 5793 RVA: 0x0006BE00 File Offset: 0x0006A000
		public string nombre
		{
			get
			{
				return this.m_nombre;
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060016A2 RID: 5794 RVA: 0x0006BE08 File Offset: 0x0006A008
		public string apellido
		{
			get
			{
				return this.m_apellido;
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060016A3 RID: 5795 RVA: 0x0006BE10 File Offset: 0x0006A010
		public int age
		{
			get
			{
				return this.m_age;
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060016A4 RID: 5796 RVA: 0x0006BE18 File Offset: 0x0006A018
		public int height
		{
			get
			{
				return this.m_height;
			}
		}

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060016A5 RID: 5797 RVA: 0x0006BE20 File Offset: 0x0006A020
		public int chest
		{
			get
			{
				return this.m_chest;
			}
		}

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x060016A6 RID: 5798 RVA: 0x0006BE28 File Offset: 0x0006A028
		public string cup
		{
			get
			{
				return this.m_cup;
			}
		}

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x060016A7 RID: 5799 RVA: 0x0006BE30 File Offset: 0x0006A030
		public int waist
		{
			get
			{
				return this.m_waist;
			}
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060016A8 RID: 5800 RVA: 0x0006BE38 File Offset: 0x0006A038
		public int hips
		{
			get
			{
				return this.m_hips;
			}
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060016A9 RID: 5801 RVA: 0x0006BE40 File Offset: 0x0006A040
		public float oralExperienceWeight
		{
			get
			{
				return this.m_oralExperienceWeight;
			}
		}

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060016AA RID: 5802 RVA: 0x0006BE48 File Offset: 0x0006A048
		public float vaginalExperienceWeight
		{
			get
			{
				return this.m_vaginalExperienceWeight;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x060016AB RID: 5803 RVA: 0x0006BE50 File Offset: 0x0006A050
		public float analExperienceWeight
		{
			get
			{
				return this.m_analExperienceWeight;
			}
		}

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x060016AC RID: 5804 RVA: 0x0006BE58 File Offset: 0x0006A058
		public float breastScaleMod
		{
			get
			{
				return this.m_breastScaleMod;
			}
		}

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060016AD RID: 5805 RVA: 0x0006BE60 File Offset: 0x0006A060
		public float glutesScaleMod
		{
			get
			{
				return this.m_glutesScaleMod;
			}
		}

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x060016AE RID: 5806 RVA: 0x0006BE68 File Offset: 0x0006A068
		public float consentlookAtPrivatesOri
		{
			get
			{
				return this.m_consentlookAtPrivatesOri;
			}
		}

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x060016AF RID: 5807 RVA: 0x0006BE70 File Offset: 0x0006A070
		public float consentGrabBreastOri
		{
			get
			{
				return this.m_consentGrabBreastOri;
			}
		}

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x060016B0 RID: 5808 RVA: 0x0006BE78 File Offset: 0x0006A078
		public float consentGrabAssOri
		{
			get
			{
				return this.m_consentGrabAssOri;
			}
		}

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x060016B1 RID: 5809 RVA: 0x0006BE80 File Offset: 0x0006A080
		public float consentTouchClitOri
		{
			get
			{
				return this.m_consentTouchClitOri;
			}
		}

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x060016B2 RID: 5810 RVA: 0x0006BE88 File Offset: 0x0006A088
		public float consentOralSexOri
		{
			get
			{
				return this.m_consentOralSexOri;
			}
		}

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x060016B3 RID: 5811 RVA: 0x0006BE90 File Offset: 0x0006A090
		public float consentVagSexOri
		{
			get
			{
				return this.m_consentVagSexOri;
			}
		}

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x060016B4 RID: 5812 RVA: 0x0006BE98 File Offset: 0x0006A098
		public float consentAnalSexOri
		{
			get
			{
				return this.m_consentAnalSexOri;
			}
		}

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x060016B5 RID: 5813 RVA: 0x0006BEA0 File Offset: 0x0006A0A0
		public float consentlookAtPrivates
		{
			get
			{
				return this.m_consentlookAtPrivates;
			}
		}

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x060016B6 RID: 5814 RVA: 0x0006BEA8 File Offset: 0x0006A0A8
		public float consentGrabBreast
		{
			get
			{
				return this.m_consentGrabBreast;
			}
		}

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x060016B7 RID: 5815 RVA: 0x0006BEB0 File Offset: 0x0006A0B0
		public float consentGrabAss
		{
			get
			{
				return this.m_consentGrabAss;
			}
		}

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x060016B8 RID: 5816 RVA: 0x0006BEB8 File Offset: 0x0006A0B8
		public float consentTouchClit
		{
			get
			{
				return this.m_consentTouchClit;
			}
		}

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x060016B9 RID: 5817 RVA: 0x0006BEC0 File Offset: 0x0006A0C0
		public float consentOralSex
		{
			get
			{
				return this.m_consentOralSex;
			}
		}

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x060016BA RID: 5818 RVA: 0x0006BEC8 File Offset: 0x0006A0C8
		public float consentVagSex
		{
			get
			{
				return this.m_consentVagSex;
			}
		}

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x060016BB RID: 5819 RVA: 0x0006BED0 File Offset: 0x0006A0D0
		public float consentAnalSex
		{
			get
			{
				return this.m_consentAnalSex;
			}
		}

		// Token: 0x060016BC RID: 5820 RVA: 0x0006BED8 File Offset: 0x0006A0D8
		public void ActualizarInfo()
		{
			this.m_nombre = base.character.nombre;
			this.m_apellido = base.character.apellido;
			InterpretadorDeFemales.AparienciaDataWrap aparienciaDataWrap = new InterpretadorDeFemales.AparienciaDataWrap();
			InterpretadorDeFemales.PersonalidadDataWrap personalidadDataWrap = new InterpretadorDeFemales.PersonalidadDataWrap();
			base.alteradoresDeAparienciaFemenina.GetClonesValoresDeAlteradorModificadores(aparienciaDataWrap.alteradoresData);
			this.LoadData(ref aparienciaDataWrap, ref personalidadDataWrap);
			Dictionary<string, ModificadoresDeAlterador> alteradoresData = aparienciaDataWrap.alteradoresData;
			float valueOrDefault = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Old].modificadores.GetValueOrDefault(0);
			float valueOrDefault2 = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_FACE_Young].modificadores.GetValueOrDefault(0);
			float num = valueOrDefault - valueOrDefault2;
			float num2 = Mathf.InverseLerp(-1f, 1f, num).InInOutOutPow(3f, 2f, 0.5f);
			float valueOrDefault3 = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Morpher_BODY_fat].modificadores.GetValueOrDefault(0);
			float num3 = (this.m_breastScaleMod = (alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_L].modificadores.GetValueOrDefault(0) + alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Seno_R].modificadores.GetValueOrDefault(0)) / 2f);
			float valueOrDefault4 = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine02].modificadores.GetValueOrDefault(0);
			float valueOrDefault5 = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Spine01].modificadores.GetValueOrDefault(0);
			ModificadoresDeAlterador modificadoresDeAlterador = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_R];
			ModificadoresDeAlterador modificadoresDeAlterador2 = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_Nalga_L];
			float num4 = (modificadoresDeAlterador.modificadores.GetValueOrDefault(0) + modificadoresDeAlterador2.modificadores.GetValueOrDefault(0)) / 2f;
			float num5 = (modificadoresDeAlterador.modificadores.GetValueOrDefault(1) + modificadoresDeAlterador2.modificadores.GetValueOrDefault(1)) / 2f;
			float num6 = (modificadoresDeAlterador.modificadores.GetValueOrDefault(1) + modificadoresDeAlterador2.modificadores.GetValueOrDefault(2)) / 2f;
			float num7 = (modificadoresDeAlterador.modificadores.GetValueOrDefault(3) + modificadoresDeAlterador2.modificadores.GetValueOrDefault(3)) / 2f;
			float num8 = MathfExtension.LerpConMedio(0f, num4, 1f, num5);
			float num9 = MathfExtension.LerpConMedio(0f, num4, 1f, num6);
			float num10 = MathfExtension.LerpConMedio(0f, num4, 1f, num7);
			this.m_glutesScaleMod = (num8 + num9 + num10) / 3f;
			float num11 = (alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_R].modificadores.GetValueOrDefault(0) + alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PiernaSuperior_L].modificadores.GetValueOrDefault(0)) / 2f;
			float num12 = (alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_L].modificadores.GetValueOrDefault(0) + alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Scaler_PelvisLat_R].modificadores.GetValueOrDefault(0)) / 2f;
			float num13 = (alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_L].modificadores.GetValueOrDefault(0) + alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_PelvisLat_R].modificadores.GetValueOrDefault(0)) / 2f;
			float num14 = (alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_L].modificadores.GetValueOrDefault(0) + alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Desplazador_DePivotDePiernas_R].modificadores.GetValueOrDefault(0)) / 2f;
			float num15 = MathfExtension.LerpConMedio(79f, 89f, 116f, num3) - 89f;
			float num16 = MathfExtension.LerpConMedio(86f, 89f, 90f, valueOrDefault4) - 89f;
			float num17 = MathfExtension.LerpConMedio(88f, 89f, 97f, valueOrDefault3) - 89f;
			this.m_chestf = 89f + num15 + num16 + num17;
			float num18 = 77f + num16 + num17;
			this.m_cupf = this.m_chestf - num18;
			float num19 = MathfExtension.LerpConMedio(53f, 59f, 62f, valueOrDefault5) - 59f;
			float num20 = MathfExtension.LerpConMedio(56f, 59f, 80f, valueOrDefault3) - 59f;
			this.m_waistf = 59f + num19 + num20;
			float num21 = MathfExtension.LerpConMedio(101f, 104f, 109f, num8) - 104f;
			float num22 = MathfExtension.LerpConMedio(100f, 104f, 109f, num10) - 104f;
			float num23 = MathfExtension.LerpConMedio(101f, 104f, 107f, num11) - 104f;
			float num24 = MathfExtension.LerpConMedio(102f, 104f, 106f, num12) - 104f;
			float num25 = MathfExtension.LerpConMedio(103f, 104f, 106f, num13) - 104f;
			float num26 = MathfExtension.LerpConMedio(102f, 104f, 108f, num14) - 104f;
			float num27 = MathfExtension.LerpConMedio(102f, 104f, 123f, valueOrDefault3) - 104f;
			this.m_hipsf = 104f + num21 + num22 + num23 + num24 + num25 + num26 + num27;
			this.m_chestf *= base.character.escala;
			this.m_cupf *= base.character.escala;
			this.m_waistf *= base.character.escala;
			this.m_hipsf *= base.character.escala;
			this.m_cup = this.GetCupSize(this.m_cupf);
			this.m_chest = Mathf.RoundToInt(this.m_chestf);
			this.m_waist = Mathf.RoundToInt(this.m_waistf);
			this.m_hips = Mathf.RoundToInt(this.m_hipsf);
			this.m_age = Mathf.RoundToInt(MathfExtension.LerpConMedio(19f, 24f, 33f, num2));
			this.m_height = Mathf.RoundToInt(base.character.estatura * 100f);
			this.m_oralExperienceWeight = float.NegativeInfinity;
			this.m_vaginalExperienceWeight = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Controller_VagDesgaste].modificadores.GetValueOrDefault(0);
			this.m_analExperienceWeight = alteradoresData[DiccionarioDeNombresDeAlteradoresFemeninos.Controller_AnusDesgaste].modificadores.GetValueOrDefault(0);
			if (Application.isEditor)
			{
				EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
				this.m_consentlookAtPrivates = (ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null) + ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null) + ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null)) / 3f;
				this.m_consentGrabBreast = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentGrabAss = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentTouchClit = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.clitoris, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentOralSex = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
				this.m_consentVagSex = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
				this.m_consentAnalSex = ConsentNecesario.ParaConJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
				this.m_consentlookAtPrivatesOri = (ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null) + ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null) + ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.visual, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.labiosVaginales, ParteQuePuedeEstimular.ojos, ref emptyValid, base.personalidad, null)) / 3f;
				this.m_consentGrabBreastOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.senos, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentGrabAssOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.nalgas, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentTouchClitOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.tactil, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.clitoris, ParteQuePuedeEstimular.manos, ref emptyValid, base.personalidad, null);
				this.m_consentOralSexOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.bocaInterno, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
				this.m_consentVagSexOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.vag, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
				this.m_consentAnalSexOri = ConsentNecesario.ParaSinJerarquia(base.consentNecesario, TipoDeEstimulo.coital, DireccionDeEstimulo.recibida, ParteDelCuerpoHumano.ano, ParteQuePuedeEstimular.pene, ref emptyValid, base.personalidad, null);
			}
		}

		// Token: 0x060016BD RID: 5821 RVA: 0x0006C718 File Offset: 0x0006A918
		private string GetCupSize(float bustSize)
		{
			float num = bustSize / 2.54f;
			if (num < 1f)
			{
				return "AA";
			}
			if (num < 2f)
			{
				return "A";
			}
			if (num < 3f)
			{
				return "B";
			}
			if (num < 4f)
			{
				return "C";
			}
			if (num < 5f)
			{
				return "D";
			}
			if (num < 6f)
			{
				return "E";
			}
			if (num < 7f)
			{
				return "F";
			}
			if (num < 8f)
			{
				return "G";
			}
			if (num < 9f)
			{
				return "H";
			}
			if (num < 10f)
			{
				return "I";
			}
			if (num < 11f)
			{
				return "J";
			}
			if (num < 12f)
			{
				return "K";
			}
			if (num < 13f)
			{
				return "L";
			}
			if (num < 14f)
			{
				return "M";
			}
			if (num < 15f)
			{
				return "N";
			}
			if (num < 16f)
			{
				return "O";
			}
			if (num < 17f)
			{
				return "P";
			}
			if (num < 18f)
			{
				return "Q";
			}
			if (num < 18f)
			{
				return "R";
			}
			return "too big to have cup size!";
		}

		// Token: 0x060016BE RID: 5822 RVA: 0x0006C83C File Offset: 0x0006AA3C
		private static void LoadData(HelperDeInterpretadorBase helper, InterpretadorDeFemales.AparienciaDataWrap apariencia, InterpretadorDeFemales.PersonalidadDataWrap personalidad, PersonalidadData m_PersonalidadData, DeseosData m_DeseosData, HairData m_HairData, PubicHairData m_PubicHairData, BodySkinData m_BodySkinData, HoleRangesData m_HoleRangesData, NalgasSkinRangesData m_NalgasSkinRangesData, FacialSkinData m_FacialSkinData, SenosSkinRangesData m_SenosSkinRangesData, RazaData m_RazaData, InterpretadorDeFemales.HoleEstadisticas m_HoleEstadisticas)
		{
			m_PersonalidadData.Generate(helper);
			m_DeseosData.Generate(helper);
			m_HairData.Generate(helper);
			m_PubicHairData.Generate(helper);
			m_BodySkinData.Generate(helper);
			m_HoleRangesData.Generate(helper);
			m_NalgasSkinRangesData.Generate(helper);
			m_FacialSkinData.Generate(helper);
			m_SenosSkinRangesData.Generate(helper);
			m_RazaData.Generate(helper);
		}

		// Token: 0x060016BF RID: 5823 RVA: 0x0006C898 File Offset: 0x0006AA98
		public void Interpretar()
		{
			InterpretadorDeFemales.AparienciaDataWrap aparienciaDataWrap = new InterpretadorDeFemales.AparienciaDataWrap();
			InterpretadorDeFemales.PersonalidadDataWrap personalidadDataWrap = new InterpretadorDeFemales.PersonalidadDataWrap();
			aparienciaDataWrap.estatura = base.character.estatura;
			base.alteradoresDeAparienciaFemenina.GetClonesValoresDeAlteradorModificadores(aparienciaDataWrap.alteradoresData);
			base.alteradoresDePersonalidadFemenina.GetClonesValoresDeAlteradorModificadores(personalidadDataWrap.alteradoresData);
			this.m_lastHoleEstadisticas = new InterpretadorDeFemales.HoleEstadisticas();
			this.m_lastHoleEstadisticas.Init(this);
			InterpretadorDeFemales.LoadData(this, aparienciaDataWrap, personalidadDataWrap, this.m_PersonalidadData, this.m_DeseosData, this.m_HairData, this.m_PubicHairData, this.m_BodySkinData, this.m_HoleRangesData, this.m_NalgasSkinRangesData, this.m_FacialSkinData, this.m_SenosSkinRangesData, this.m_RazaData, this.m_lastHoleEstadisticas);
			MapaSingletonDefaultInterpretacionData instance = MapaSingleton<MapaSingletonDefaultInterpretacionData>.instance;
			this.interpretacion.interpretacionDePersonalidad = InterpretadorDePersonalidad.Interpretar(personalidadDataWrap, this.m_PersonalidadData, this.m_PersonalidadData);
			this.interpretacion.interpretacionDeGustos = InterpretadorDeGustos.Interpretar(personalidadDataWrap, this.m_PersonalidadData, instance.deseosData, this.m_DeseosData);
			this.interpretacion.interpretacionDeAnus = InterpretadorDeAnus.Interpretar(aparienciaDataWrap, this.m_lastHoleEstadisticas, instance.holeRangesData, this.m_HoleRangesData);
			this.interpretacion.interpretacionDeAss = InterpretadorDeAss.Interpretar(aparienciaDataWrap, instance.nalgasSkinRangesData, this.m_NalgasSkinRangesData);
			this.interpretacion.interpretacionDeBodySkin = InterpretadorDeBodySkin.Interpretar(aparienciaDataWrap, instance.bodySkinData, this.m_BodySkinData, this.m_BodySkinData);
			this.interpretacion.interpretacionDeBodySuperficial = InterpretadorDeBodySuperficial.Interpretar(aparienciaDataWrap);
			this.interpretacion.interpretacionDeCheeks = InterpretadorDeCheeks.Interpretar(aparienciaDataWrap);
			this.interpretacion.interpretacionDeEyebrows = InterpretadorDeEyebrows.Interpretar(aparienciaDataWrap, this.m_FacialSkinData);
			this.interpretacion.interpretacionDeEyes = InterpretadorDeEyes.Interpretar(aparienciaDataWrap, this.m_FacialSkinData);
			this.interpretacion.interpretacionDeFacialSkin = InterpretadorDeFacialSkin.Interpretar(aparienciaDataWrap, instance.facialSkinData, this.m_FacialSkinData, this.m_FacialSkinData);
			this.interpretacion.interpretacionDeHair = InterpretadorDeHair.Interpretar(aparienciaDataWrap, this.m_HairData);
			this.interpretacion.interpretacionDePubicHair = InterpretadorDePubicHair.Interpretar(aparienciaDataWrap, this.m_PubicHairData);
			this.interpretacion.interpretacionDeJaw = InterpretadorDeJaw.Interpretar(aparienciaDataWrap);
			this.interpretacion.interpretacionDeMouth = InterpretadorDeMouth.Interpretar(aparienciaDataWrap, this.m_lastHoleEstadisticas, instance.holeRangesData, this.m_HoleRangesData, this.m_FacialSkinData);
			this.interpretacion.interpretacionDeNose = InterpretadorDeNose.Interpretar(aparienciaDataWrap);
			this.interpretacion.interpretacionDeRostro = InterpretadorDeRostro.Interpretar(aparienciaDataWrap);
			this.interpretacion.interpretacionDeSenos = InterpretadorDeSenos.Interpretar(aparienciaDataWrap, instance.senosSkinRangesData, this.m_SenosSkinRangesData, this.m_SenosSkinRangesData);
			this.interpretacion.interpretacionDeVag = InterpretadorDeVag.Interpretar(aparienciaDataWrap, this.m_lastHoleEstadisticas, instance.holeRangesData, this.m_HoleRangesData);
			this.interpretacion.interpretacionDeRaza = InterpretadorDeRaza.Interpretar(this.m_RazaData);
		}

		// Token: 0x060016C0 RID: 5824 RVA: 0x0006CB48 File Offset: 0x0006AD48
		public void LoadData(ref InterpretadorDeFemales.AparienciaDataWrap apa, ref InterpretadorDeFemales.PersonalidadDataWrap per)
		{
			if (apa == null)
			{
				apa = new InterpretadorDeFemales.AparienciaDataWrap();
			}
			if (per == null)
			{
				per = new InterpretadorDeFemales.PersonalidadDataWrap();
			}
			InterpretadorDeFemales.LoadData(this, apa, per, this.m_PersonalidadData, this.m_DeseosData, this.m_HairData, this.m_PubicHairData, this.m_BodySkinData, this.m_HoleRangesData, this.m_NalgasSkinRangesData, this.m_FacialSkinData, this.m_SenosSkinRangesData, this.m_RazaData, this.m_lastHoleEstadisticas);
		}

		// Token: 0x060016C1 RID: 5825 RVA: 0x0006CBB8 File Offset: 0x0006ADB8
		public void InverseInterpretar()
		{
			Dictionary<string, ModificadoresDeAlterador> dictionary = MapaSingleton<SujetoMapasFemeninosDefectoGetter>.instance.@default.aparienciaFisicaMapa.@base.ObtenerClonesDeAlteradorModificadores().ToDictionary((ModificadoresDeAlterador mod) => mod.alteradorName);
			InterpretadorDeFemales.AparienciaDataWrap aparienciaDataWrap = new InterpretadorDeFemales.AparienciaDataWrap();
			aparienciaDataWrap.alteradoresData = dictionary;
			InterpretadorDeAnus.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeAnus);
			InterpretadorDeAss.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeAss);
			Color color;
			Color color2;
			float num;
			float num2;
			InterpretadorDeBodySkin.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeBodySkin, out color, out color2, out num, out num2);
			InterpretadorDeBodySuperficial.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeBodySuperficial);
			InterpretadorDeCheeks.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeCheeks);
			Color color3;
			InterpretadorDeEyebrows.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeEyebrows, out color3);
			Color color4;
			InterpretadorDeEyes.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeEyes, out color4);
			float num3;
			float num4;
			InterpretadorDeFacialSkin.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeFacialSkin, out num3, out num4);
			bool flag;
			Color color5;
			InterpretadorDeHair.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeHair, out flag, out color5);
			Color color6;
			InterpretadorDePubicHair.InterpretarInverse(aparienciaDataWrap, new Func<float, int>(InterpretadorDeFemales.DensidadDePubesAIndexDeTexturaDePubes), this.interpretacion.interpretacionDePubicHair, out color6);
			InterpretadorDeJaw.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeJaw);
			Color color7;
			InterpretadorDeMouth.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeMouth, out color7);
			InterpretadorDeNose.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeNose);
			InterpretadorDeRostro.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeRostro);
			Color color8;
			InterpretadorDeSenos.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeSenos, out color8, 0.3f, 0.75f);
			InterpretadorDeVag.InterpretarInverse(aparienciaDataWrap, this.interpretacion.interpretacionDeVag);
			base.alteradoresDeAparienciaFemenina.UpdateValoresWithData(aparienciaDataWrap.alteradoresData.Values);
			base.controlladorDeFemalePiel.colorDeFingerNails.ForceNewValue(color, false);
			base.controlladorDeFemalePiel.colorDeToeNails.ForceNewValue(color2, false);
			base.controlladorDeFemalePiel.colorDeLabios.ForceNewValue(color7, false);
			base.controlladorDeFemalePiel.colorDePezones.ForceNewValue(color8, false);
			ConjuntosDeMaterialesDeFemalePiel instance = Singleton<ConjuntosDeMaterialesDeFemalePiel>.instance;
			int num5 = -1;
			float num6 = float.MaxValue;
			for (int i = 0; i < instance.conjuntos.Count; i++)
			{
				MapaDeConjuntosDeMaterialesDePielFemeninos.Conjunto conjunto = instance.conjuntos[i];
				float num7 = Mathf.Abs(conjunto.tanWeigth - num) + Mathf.Abs(1f - conjunto.qualityWeigth * 0.75f + conjunto.varWeigth * 0.25f - num2);
				if (num7 < num6)
				{
					num5 = i;
					num6 = num7;
				}
			}
			base.controlladorDeFemalePiel.ActualizarPiel();
			base.controlladorDeFemalePiel.ChangeDiffuseTo(num5);
			base.ControlladorDeFemaleCejasApariencia.colorDeCejas.ForceNewValue(color3, false);
			base.ControlladorDeFemaleCejasApariencia.ActualizarColorCejas();
			base.controlladorDeEyeAdvanceColores.colorDeOjoL.ForceNewValue(color4, false);
			base.controlladorDeEyeAdvanceColores.colorDeOjoR.ForceNewValue(color4, false);
			base.controlladorDeEyeAdvanceColores.ActualizarOjos();
			base.controlladorDeCabelloGpu.colorDeGpuHair.ForceNewValue(color5, false);
			base.controlladorDeCabelloGpu.ActualizarColorDeCabello();
			CollecionDeStylosDeCabello instance2 = Singleton<CollecionDeStylosDeCabello>.instance;
			if (flag)
			{
				base.controlladorDeCabelloGpu.flagCambiarStyloAIndex = instance2.stylos.IndexOf(instance2.styloLargo);
			}
			else
			{
				base.controlladorDeCabelloGpu.flagCambiarStyloAIndex = instance2.stylos.IndexOf(instance2.styloCorto);
			}
			base.controlladorDeCabelloGpu.ActualizarStylo();
			base.controlladorDeFemalePubesApariencia.colorDePubes.ForceNewValue(color6, false);
			base.controlladorDeFemalePubesApariencia.ActualizarColorPubes();
			MapaSingletonDeFemaleMakeUp instance3 = MapaSingleton<MapaSingletonDeFemaleMakeUp>.instance;
			int num8 = -1;
			float num9 = float.MaxValue;
			for (int j = 0; j < instance3.makeUps.Count; j++)
			{
				MapaSingletonDeFemaleMakeUp.MakeUpItem makeUpItem = instance3.makeUps[j];
				float num10 = Mathf.Abs(makeUpItem.cheeksWeigth - num3) + Mathf.Abs(makeUpItem.eyeShadowWeigth - num4);
				if (num10 < num9)
				{
					num8 = j;
					num9 = num10;
				}
			}
			base.controlladorDeFemaleMakeUp.ChangeTo(num8);
		}

		// Token: 0x060016C2 RID: 5826 RVA: 0x0006CFA4 File Offset: 0x0006B1A4
		public static int DensidadDePubesAIndexDeTexturaDePubes(float density)
		{
			IReadOnlyList<MapaSingletonDeFemalePubesTextures.Conjunto> conjuntos = MapaSingleton<MapaSingletonDeFemalePubesTextures>.instance.conjuntos;
			for (int i = 0; i < conjuntos.Count; i++)
			{
				MapaSingletonDeFemalePubesTextures.Conjunto conjunto = conjuntos[i];
				if (Mathf.Abs(density - conjunto.densidadSubjetiva) < 0.1f)
				{
					return i;
				}
			}
			if (density < 0.4f)
			{
				return conjuntos.IndexOf(MapaSingleton<MapaSingletonDeFemalePubesTextures>.instance.menosDenso);
			}
			if (density > 0.6f)
			{
				return conjuntos.IndexOf(MapaSingleton<MapaSingletonDeFemalePubesTextures>.instance.masDenso);
			}
			return conjuntos.IndexOf(MapaSingleton<MapaSingletonDeFemalePubesTextures>.instance.intermedioDenso);
		}

		// Token: 0x060016C3 RID: 5827 RVA: 0x0006D02D File Offset: 0x0006B22D
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			if (this.m_MapaSingletonDefaultInterpretacionData == null || this.m_MapaSingletonDefaultInterpretacion == null)
			{
				return null;
			}
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Interpretar a Mapa"
			};
		}

		// Token: 0x060016C4 RID: 5828 RVA: 0x0006D064 File Offset: 0x0006B264
		protected override void OnAplicar2()
		{
			if (this.m_MapaSingletonDefaultInterpretacionData == null || this.m_MapaSingletonDefaultInterpretacion == null)
			{
				return;
			}
			InterpretadorDeFemales.AparienciaDataWrap aparienciaDataWrap = new InterpretadorDeFemales.AparienciaDataWrap();
			InterpretadorDeFemales.PersonalidadDataWrap personalidadDataWrap = new InterpretadorDeFemales.PersonalidadDataWrap();
			aparienciaDataWrap.estatura = base.character.estatura;
			base.alteradoresDeAparienciaFemenina.GetValoresDeAlteradorModificadores(aparienciaDataWrap.alteradoresData);
			base.alteradoresDePersonalidadFemenina.GetValoresDeAlteradorModificadores(personalidadDataWrap.alteradoresData);
			this.m_lastHoleEstadisticas = new InterpretadorDeFemales.HoleEstadisticas();
			this.m_lastHoleEstadisticas.Init(this);
			InterpretadorDeFemales.LoadData(this, aparienciaDataWrap, personalidadDataWrap, this.m_MapaSingletonDefaultInterpretacionData.personalidadData, this.m_MapaSingletonDefaultInterpretacionData.deseosData, this.m_MapaSingletonDefaultInterpretacionData.hairData, this.m_MapaSingletonDefaultInterpretacionData.pubicHairData, this.m_MapaSingletonDefaultInterpretacionData.bodySkinData, this.m_MapaSingletonDefaultInterpretacionData.holeRangesData, this.m_MapaSingletonDefaultInterpretacionData.nalgasSkinRangesData, this.m_MapaSingletonDefaultInterpretacionData.facialSkinData, this.m_MapaSingletonDefaultInterpretacionData.senosSkinRangesData, this.m_MapaSingletonDefaultInterpretacionData.razaData, this.m_lastHoleEstadisticas);
			TValleEditorTools.SetDirty(this.m_MapaSingletonDefaultInterpretacionData);
			this.Interpretar();
			this.m_MapaSingletonDefaultInterpretacion.interpretacion = this.interpretacion;
			TValleEditorTools.SetDirty(this.m_MapaSingletonDefaultInterpretacion);
		}

		// Token: 0x060016C5 RID: 5829 RVA: 0x0006D18D File Offset: 0x0006B38D
		protected override CustomMonobehaviourBotonConfig Boton3()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Interpretar"
			};
		}

		// Token: 0x060016C6 RID: 5830 RVA: 0x0006D1A6 File Offset: 0x0006B3A6
		protected override void OnAplicar3()
		{
			this.Interpretar();
		}

		// Token: 0x060016C7 RID: 5831 RVA: 0x0006D1AE File Offset: 0x0006B3AE
		protected override CustomMonobehaviourBotonConfig Boton4()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Inverse Interpretar"
			};
		}

		// Token: 0x060016C8 RID: 5832 RVA: 0x0006D1C7 File Offset: 0x0006B3C7
		protected override void OnAplicar4()
		{
			this.InverseInterpretar();
		}

		// Token: 0x060016C9 RID: 5833 RVA: 0x0006D1CF File Offset: 0x0006B3CF
		protected override CustomMonobehaviourBotonConfig Boton5()
		{
			return new CustomMonobehaviourBotonConfig
			{
				editorTimeVisible = false,
				text = "Print face Interpretation c#"
			};
		}

		// Token: 0x060016CA RID: 5834 RVA: 0x0006D1E8 File Offset: 0x0006B3E8
		protected override void OnAplicar5()
		{
			StringBuilder stringBuilder = new StringBuilder();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeRostro", this.interpretacion.interpretacionDeRostro);
			stringBuilder.Clear();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeEyebrows", this.interpretacion.interpretacionDeEyebrows);
			stringBuilder.Clear();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeEyes", this.interpretacion.interpretacionDeEyes);
			stringBuilder.Clear();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeCheeks", this.interpretacion.interpretacionDeCheeks);
			stringBuilder.Clear();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeNose", this.interpretacion.interpretacionDeNose);
			stringBuilder.Clear();
			InterpretadorDeFemales.PrintInterpretacion("ReplaceMe", stringBuilder, "interpretacionDeMouth", this.interpretacion.interpretacionDeMouth);
			stringBuilder.Clear();
		}

		// Token: 0x060016CB RID: 5835 RVA: 0x0006D2E8 File Offset: 0x0006B4E8
		private static void PrintInterpretacion(string varName, StringBuilder b, string interpretacionName, object interpretacion)
		{
			foreach (PropertyInfo propertyInfo in interpretacion.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
			{
				if (propertyInfo.PropertyType.IsEnum)
				{
					b.Append(varName);
					b.Append('.');
					b.Append(interpretacionName);
					b.Append('.');
					b.Append(propertyInfo.Name);
					b.Append(' ');
					b.Append('=');
					b.Append(' ');
					b.Append(propertyInfo.PropertyType.Name);
					b.Append('.');
					b.Append(propertyInfo.GetValue(interpretacion).ToString());
					b.Append(';');
					b.Append('\n');
				}
			}
			MonoBehaviour.print(b.ToString());
		}

		// Token: 0x04001065 RID: 4197
		[ReadOnlyUI]
		[SerializeField]
		private string m_nombre;

		// Token: 0x04001066 RID: 4198
		[ReadOnlyUI]
		[SerializeField]
		private string m_apellido;

		// Token: 0x04001067 RID: 4199
		[ReadOnlyUI]
		[SerializeField]
		private int m_age;

		// Token: 0x04001068 RID: 4200
		[ReadOnlyUI]
		[SerializeField]
		private int m_height;

		// Token: 0x04001069 RID: 4201
		[ReadOnlyUI]
		[SerializeField]
		private int m_chest;

		// Token: 0x0400106A RID: 4202
		[ReadOnlyUI]
		[SerializeField]
		private string m_cup;

		// Token: 0x0400106B RID: 4203
		[ReadOnlyUI]
		[SerializeField]
		private int m_waist;

		// Token: 0x0400106C RID: 4204
		[ReadOnlyUI]
		[SerializeField]
		private int m_hips;

		// Token: 0x0400106D RID: 4205
		[ReadOnlyUI]
		[SerializeField]
		private float m_oralExperienceWeight;

		// Token: 0x0400106E RID: 4206
		[ReadOnlyUI]
		[SerializeField]
		private float m_vaginalExperienceWeight;

		// Token: 0x0400106F RID: 4207
		[ReadOnlyUI]
		[SerializeField]
		private float m_analExperienceWeight;

		// Token: 0x04001070 RID: 4208
		[ReadOnlyUI]
		[SerializeField]
		private float m_chestf;

		// Token: 0x04001071 RID: 4209
		[ReadOnlyUI]
		[SerializeField]
		private float m_cupf;

		// Token: 0x04001072 RID: 4210
		[ReadOnlyUI]
		[SerializeField]
		private float m_waistf;

		// Token: 0x04001073 RID: 4211
		[ReadOnlyUI]
		[SerializeField]
		private float m_hipsf;

		// Token: 0x04001074 RID: 4212
		[ReadOnlyUI]
		[SerializeField]
		private float m_breastScaleMod;

		// Token: 0x04001075 RID: 4213
		[ReadOnlyUI]
		[SerializeField]
		private float m_glutesScaleMod;

		// Token: 0x04001076 RID: 4214
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentlookAtPrivatesOri;

		// Token: 0x04001077 RID: 4215
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentGrabBreastOri;

		// Token: 0x04001078 RID: 4216
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentGrabAssOri;

		// Token: 0x04001079 RID: 4217
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentTouchClitOri;

		// Token: 0x0400107A RID: 4218
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentOralSexOri;

		// Token: 0x0400107B RID: 4219
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentVagSexOri;

		// Token: 0x0400107C RID: 4220
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentAnalSexOri;

		// Token: 0x0400107D RID: 4221
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentlookAtPrivates;

		// Token: 0x0400107E RID: 4222
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentGrabBreast;

		// Token: 0x0400107F RID: 4223
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentGrabAss;

		// Token: 0x04001080 RID: 4224
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentTouchClit;

		// Token: 0x04001081 RID: 4225
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentOralSex;

		// Token: 0x04001082 RID: 4226
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentVagSex;

		// Token: 0x04001083 RID: 4227
		[ReadOnlyUI]
		[SerializeField]
		private float m_consentAnalSex;

		// Token: 0x04001084 RID: 4228
		[Header("Interpretacion")]
		public InterpretacionCompletaDeFemale interpretacion;

		// Token: 0x04001085 RID: 4229
		[Header("Data")]
		[SerializeField]
		private PersonalidadData m_PersonalidadData;

		// Token: 0x04001086 RID: 4230
		[SerializeField]
		private DeseosData m_DeseosData;

		// Token: 0x04001087 RID: 4231
		[SerializeField]
		private HairData m_HairData = new HairData();

		// Token: 0x04001088 RID: 4232
		[SerializeField]
		private PubicHairData m_PubicHairData = new PubicHairData();

		// Token: 0x04001089 RID: 4233
		[SerializeField]
		private BodySkinData m_BodySkinData = new BodySkinData();

		// Token: 0x0400108A RID: 4234
		[SerializeField]
		private HoleRangesData m_HoleRangesData = new HoleRangesData();

		// Token: 0x0400108B RID: 4235
		[SerializeField]
		private NalgasSkinRangesData m_NalgasSkinRangesData = new NalgasSkinRangesData();

		// Token: 0x0400108C RID: 4236
		[SerializeField]
		private FacialSkinData m_FacialSkinData = new FacialSkinData();

		// Token: 0x0400108D RID: 4237
		[SerializeField]
		private SenosSkinRangesData m_SenosSkinRangesData = new SenosSkinRangesData();

		// Token: 0x0400108E RID: 4238
		[SerializeField]
		private RazaData m_RazaData = new RazaData();

		// Token: 0x0400108F RID: 4239
		[ReadOnlyUI]
		[SerializeField]
		private InterpretadorDeFemales.HoleEstadisticas m_lastHoleEstadisticas;

		// Token: 0x04001090 RID: 4240
		[SerializeField]
		private MapaSingletonDefaultInterpretacionData m_MapaSingletonDefaultInterpretacionData;

		// Token: 0x04001091 RID: 4241
		[SerializeField]
		private MapaSingletonDefaultInterpretacion m_MapaSingletonDefaultInterpretacion;

		// Token: 0x0200038F RID: 911
		public class AparienciaDataWrap : InterpretadorDeFemales.AlteradoresDataWrap, IInterpretadorHelperConAlteradoresDeApariencia, IBodySuperficialInterpretadorHelper
		{
			// Token: 0x060016CD RID: 5837 RVA: 0x0006D42B File Offset: 0x0006B62B
			public float GetWorldSpaceEstatura()
			{
				return this.estatura;
			}

			// Token: 0x060016CE RID: 5838 RVA: 0x0006D433 File Offset: 0x0006B633
			IReadOnlyDictionary<string, ModificadoresDeAlterador> IInterpretadorHelperConAlteradoresDeApariencia.GetPreparedAlteradoresAparienciaDicc()
			{
				return this.alteradoresData;
			}

			// Token: 0x04001092 RID: 4242
			public float estatura;
		}

		// Token: 0x02000390 RID: 912
		public class PersonalidadDataWrap : InterpretadorDeFemales.AlteradoresDataWrap, IInterpretadorHelperConAlteradoresDePersonalidad
		{
			// Token: 0x060016D0 RID: 5840 RVA: 0x0006D433 File Offset: 0x0006B633
			IReadOnlyDictionary<string, ModificadoresDeAlterador> IInterpretadorHelperConAlteradoresDePersonalidad.GetPreparedAlteradoresPersonalidadDicc()
			{
				return this.alteradoresData;
			}
		}

		// Token: 0x02000391 RID: 913
		public abstract class AlteradoresDataWrap
		{
			// Token: 0x04001093 RID: 4243
			public Dictionary<string, ModificadoresDeAlterador> alteradoresData = new Dictionary<string, ModificadoresDeAlterador>();
		}

		// Token: 0x02000392 RID: 914
		[Serializable]
		private class HoleEstadisticas : IEstadisticasDeHoleInterpretadorHelper
		{
			// Token: 0x060016D3 RID: 5843 RVA: 0x0006D458 File Offset: 0x0006B658
			private void AnalAnchuraRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeAnchura(FemalePenetracionTipo.anus, ref aceptanceMod);
				this.m_AnalAnchuraRangoDeSufrimiento = rangeValueV;
			}

			// Token: 0x060016D4 RID: 5844 RVA: 0x0006D480 File Offset: 0x0006B680
			private void AnalProfundidadRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeProfundidad(FemalePenetracionTipo.anus, ref aceptanceMod, false);
				this.m_AnalProfundidadRangoDeSufrimiento = new RangeValueV2(rangeValueV.max * 1.05f, rangeValueV.max * 1.1f);
			}

			// Token: 0x060016D5 RID: 5845 RVA: 0x0006D4C8 File Offset: 0x0006B6C8
			private void OralAnchuraRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeAnchura(FemalePenetracionTipo.facial, ref aceptanceMod);
				this.m_OralAnchuraRangoDeSufrimiento = rangeValueV;
			}

			// Token: 0x060016D6 RID: 5846 RVA: 0x0006D4F0 File Offset: 0x0006B6F0
			private void OralProfundidadRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeProfundidad(FemalePenetracionTipo.facial, ref aceptanceMod, false);
				this.m_OralProfundidadRangoDeSufrimiento = new RangeValueV2(rangeValueV.max * 1.05f, rangeValueV.max * 1.1f);
			}

			// Token: 0x060016D7 RID: 5847 RVA: 0x0006D538 File Offset: 0x0006B738
			private void VaginalAnchuraRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeAnchura(FemalePenetracionTipo.vag, ref aceptanceMod);
				this.m_VaginalAnchuraRangoDeSufrimiento = rangeValueV;
			}

			// Token: 0x060016D8 RID: 5848 RVA: 0x0006D560 File Offset: 0x0006B760
			private void VaginalProfundidadRangoDeSufrimiento(ref EmocionesFemeninasValues aceptanceMod)
			{
				RangeValueV2 rangeValueV = this.m_helper.dolorPorPenetracion.ObtenerRangoDeProfundidad(FemalePenetracionTipo.vag, ref aceptanceMod, false);
				this.m_VaginalProfundidadRangoDeSufrimiento = new RangeValueV2(rangeValueV.max * 1.05f, rangeValueV.max * 1.1f);
			}

			// Token: 0x060016D9 RID: 5849 RVA: 0x0006D5A8 File Offset: 0x0006B7A8
			public void Init(HelperDeInterpretadorBase helper)
			{
				this.m_helper = helper;
				EmocionesFemeninasValues emptyValid = EmocionesFemeninasValues.emptyValid;
				emptyValid.humanasValues.placer = 0.99f;
				this.m_offsetGetter = (float input, RangeValueV2 rango) => UmbralBasico.Calcular(input, rango, 1f, SpotBonuses.@default, 0.5f, 1f, 0f).offsetMod;
				this.m_anusScale = this.m_helper.anus.worldScaleReal;
				this.m_vagScale = this.m_helper.vag.worldScaleReal;
				this.m_facialScale = this.m_helper.boca.worldScaleReal;
				this.VaginalProfundidadRangoDeSufrimiento(ref emptyValid);
				this.VaginalAnchuraRangoDeSufrimiento(ref emptyValid);
				this.AnalProfundidadRangoDeSufrimiento(ref emptyValid);
				this.AnalAnchuraRangoDeSufrimiento(ref emptyValid);
				this.OralProfundidadRangoDeSufrimiento(ref emptyValid);
				this.OralAnchuraRangoDeSufrimiento(ref emptyValid);
			}

			// Token: 0x060016DA RID: 5850 RVA: 0x0006D66A File Offset: 0x0006B86A
			void IEstadisticasDeHoleInterpretadorHelper.VaginalProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_VaginalProfundidadRangoDeSufrimiento;
				holeScale = this.m_vagScale;
			}

			// Token: 0x060016DB RID: 5851 RVA: 0x0006D688 File Offset: 0x0006B888
			void IEstadisticasDeHoleInterpretadorHelper.AnalProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_AnalProfundidadRangoDeSufrimiento;
				holeScale = this.m_anusScale;
			}

			// Token: 0x060016DC RID: 5852 RVA: 0x0006D6A6 File Offset: 0x0006B8A6
			void IEstadisticasDeHoleInterpretadorHelper.OralProfundidadRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_OralProfundidadRangoDeSufrimiento;
				holeScale = this.m_facialScale;
			}

			// Token: 0x060016DD RID: 5853 RVA: 0x0006D6C4 File Offset: 0x0006B8C4
			void IEstadisticasDeHoleInterpretadorHelper.VaginalAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_VaginalAnchuraRangoDeSufrimiento;
				holeScale = this.m_vagScale;
			}

			// Token: 0x060016DE RID: 5854 RVA: 0x0006D6E2 File Offset: 0x0006B8E2
			void IEstadisticasDeHoleInterpretadorHelper.AnalAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_AnalAnchuraRangoDeSufrimiento;
				holeScale = this.m_anusScale;
			}

			// Token: 0x060016DF RID: 5855 RVA: 0x0006D700 File Offset: 0x0006B900
			void IEstadisticasDeHoleInterpretadorHelper.OralAnchuraRangoDeSufrimiento(out IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler offsetGetter, out RangeValueV2 rangoLocalCoitalPene, out float holeScale)
			{
				offsetGetter = this.m_offsetGetter;
				rangoLocalCoitalPene = this.m_OralAnchuraRangoDeSufrimiento;
				holeScale = this.m_facialScale;
			}

			// Token: 0x04001094 RID: 4244
			[SerializeField]
			private RangeValueV2 m_VaginalProfundidadRangoDeSufrimiento;

			// Token: 0x04001095 RID: 4245
			[SerializeField]
			private RangeValueV2 m_VaginalAnchuraRangoDeSufrimiento;

			// Token: 0x04001096 RID: 4246
			[SerializeField]
			private RangeValueV2 m_OralProfundidadRangoDeSufrimiento;

			// Token: 0x04001097 RID: 4247
			[SerializeField]
			private RangeValueV2 m_OralAnchuraRangoDeSufrimiento;

			// Token: 0x04001098 RID: 4248
			[SerializeField]
			private RangeValueV2 m_AnalProfundidadRangoDeSufrimiento;

			// Token: 0x04001099 RID: 4249
			[SerializeField]
			private RangeValueV2 m_AnalAnchuraRangoDeSufrimiento;

			// Token: 0x0400109A RID: 4250
			[SerializeField]
			private float m_anusScale;

			// Token: 0x0400109B RID: 4251
			[SerializeField]
			private float m_vagScale;

			// Token: 0x0400109C RID: 4252
			[SerializeField]
			private float m_facialScale;

			// Token: 0x0400109D RID: 4253
			private IEstadisticasDeHoleInterpretadorHelper.OffsetGetterHandler m_offsetGetter;

			// Token: 0x0400109E RID: 4254
			private HelperDeInterpretadorBase m_helper;
		}
	}
}
