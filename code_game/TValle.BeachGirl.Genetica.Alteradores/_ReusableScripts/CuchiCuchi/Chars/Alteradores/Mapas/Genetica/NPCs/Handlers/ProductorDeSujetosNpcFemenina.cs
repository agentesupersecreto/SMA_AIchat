using System;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using RandomNameGeneratorLibrary;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.NPCs.Handlers
{
	// Token: 0x02000075 RID: 117
	[RequireComponent(typeof(IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>))]
	public class ProductorDeSujetosNpcFemenina : CustomMonobehaviour, ISujetoNpcProductor<ISujetoIdentificableNpc>
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x00014280 File Offset: 0x00012480
		public static ISujetoIdentificableNpc DeepInstantiate(ISujetoIdentificableNpc original)
		{
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = original as SujetoIdentificableNpcAlteradoresFemeninos;
			if (sujetoIdentificableNpcAlteradoresFemeninos == null)
			{
				throw new ArgumentNullException("sujetoOriginal", "sujetoOriginal null reference.");
			}
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos2 = Object.Instantiate<SujetoIdentificableNpcAlteradoresFemeninos>(sujetoIdentificableNpcAlteradoresFemeninos);
			sujetoIdentificableNpcAlteradoresFemeninos2.name = sujetoIdentificableNpcAlteradoresFemeninos.name;
			sujetoIdentificableNpcAlteradoresFemeninos2.aparienciaFisicaMapa = (SujetoIdentificableAlteradoresAparienciaFemeninos)ProductorDeSujetosDeAparienciaFisicaFemenina.DeepInstantiate(sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisicaMapa);
			sujetoIdentificableNpcAlteradoresFemeninos2.personalidadMapa = (SujetoIdentificableAlteradoresPersonalidadFemeninos)ProductorDeSujetosDePersonalidadFemenina.DeepInstantiate(sujetoIdentificableNpcAlteradoresFemeninos.personalidadMapa);
			return sujetoIdentificableNpcAlteradoresFemeninos2;
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x000142EC File Offset: 0x000124EC
		public static ISujetoIdentificableNpc ProducirSujetoNpc(Random m_randomGen, int sourceAparienciaNivel, int sourcePersonalidadNivel, ISujeto aparienciaSource, ISujeto personalidadSource, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandomApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomPersonalidad)
		{
			ISujetoIdentificableNpc sujetoIdentificableNpc = ProductorDeSujetosNpcFemenina.ProducirSujetoNpc(m_randomGen, sourceAparienciaNivel, sourcePersonalidadNivel);
			ProductorDeSujetosNpcFemenina.ProducirSubMapasDeSujetoNpc(sujetoIdentificableNpc as SujetoIdentificableNpcAlteradoresFemeninos, sourceAparienciaNivel, sourcePersonalidadNivel, aparienciaSource, personalidadSource, dummy, tipoDeRandomApariencia, tipoDeRandomPersonalidad);
			return sujetoIdentificableNpc;
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00014317 File Offset: 0x00012517
		public static void SetName(SujetoIdentificableNpcAlteradoresFemeninos npc, string nombre, string apellido)
		{
			npc.dataContainer.AddData("Nombre", nombre, true);
			npc.dataContainer.AddData("Apellido", apellido, true);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00014340 File Offset: 0x00012540
		public static void SetRandomName(SujetoIdentificableNpcAlteradoresFemeninos npc, Random m_randomGen)
		{
			PersonNameGenerator personNameGenerator = new PersonNameGenerator(m_randomGen);
			string text = personNameGenerator.GenerateRandomFemaleFirstName();
			string text2 = personNameGenerator.GenerateRandomLastName();
			npc.dataContainer.AddData("Nombre", text, true);
			npc.dataContainer.AddData("Apellido", text2, true);
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00014384 File Offset: 0x00012584
		public static void SetID(SujetoIdentificableNpcAlteradoresFemeninos npc, Guid ID)
		{
			npc.NpcID = ID;
			npc.name = ID.ToString();
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x000143A0 File Offset: 0x000125A0
		public static void SetRandomID(SujetoIdentificableNpcAlteradoresFemeninos npc)
		{
			npc.NpcID = Guid.NewGuid();
			npc.name = npc.NpcID.ToString();
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000143D4 File Offset: 0x000125D4
		private static ISujetoIdentificableNpc ProducirSujetoNpc(Random m_randomGen, int sourceAparienciaNivel, int sourcePersonalidadNivel)
		{
			if (m_randomGen == null)
			{
				throw new ArgumentNullException("m_randomGen", "m_randomGen null reference.");
			}
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableNpcAlteradoresFemeninos>();
			ProductorDeSujetosNpcFemenina.SetRandomID(sujetoIdentificableNpcAlteradoresFemeninos);
			ProductorDeSujetosNpcFemenina.SetRandomName(sujetoIdentificableNpcAlteradoresFemeninos, m_randomGen);
			sujetoIdentificableNpcAlteradoresFemeninos.dataContainer.AddData("SourceNivel", (float)(sourceAparienciaNivel + sourcePersonalidadNivel) / 2f, true);
			return sujetoIdentificableNpcAlteradoresFemeninos;
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00014421 File Offset: 0x00012621
		private static void ProducirSubMapasDeSujetoNpc(SujetoIdentificableNpcAlteradoresFemeninos produciendo, int sourceAparienciaNivel, int sourcePersonalidadNivel, ISujeto aparienciaDefault, ISujeto personalidadDefault, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandomApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomPersonalidad)
		{
			if (aparienciaDefault != null)
			{
				produciendo.aparienciaFisicaMapa = ProductorDeSujetosDeAparienciaFisicaFemenina.ProducirSujeto(aparienciaDefault, sourceAparienciaNivel, dummy, tipoDeRandomApariencia) as SujetoIdentificableAlteradoresAparienciaFemeninos;
			}
			if (personalidadDefault != null)
			{
				produciendo.personalidadMapa = ProductorDeSujetosDePersonalidadFemenina.ProducirSujeto(personalidadDefault, sourcePersonalidadNivel, dummy, tipoDeRandomPersonalidad) as SujetoIdentificableAlteradoresPersonalidadFemeninos;
			}
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00014458 File Offset: 0x00012658
		public static void DestriurSujetoNpc(Object posibleSujeto)
		{
			if (posibleSujeto == null)
			{
				return;
			}
			if (TValleEditorTools.IsPersistent(posibleSujeto))
			{
				return;
			}
			ISujetoIdentificableNpc sujetoIdentificableNpc = posibleSujeto as ISujetoIdentificableNpc;
			if (sujetoIdentificableNpc == null)
			{
				return;
			}
			sujetoIdentificableNpc.Destruir();
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x0001448C File Offset: 0x0001268C
		public static ISujetoIdentificableNpc ProducirSujetoNpcConOverride(SujetoIdentificableNpcAlteradoresFemeninos @default, ISujetoNpcProductorDefaultOverrider m_DefaultOverrider, Random m_randomGen, string piscinaID, bool dummy, Object context)
		{
			if (m_DefaultOverrider == null || dummy)
			{
				ISujetoNivel sujetoNivel = @default.aparienciaFisica as ISujetoNivel;
				int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
				ISujetoNivel sujetoNivel2 = @default.personalidad as ISujetoNivel;
				int valueOrDefault2 = ((sujetoNivel2 != null) ? new int?(sujetoNivel2.nivel) : null).GetValueOrDefault();
				return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride((valueOrDefault <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, (valueOrDefault2 <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, @default, m_DefaultOverrider, m_randomGen, piscinaID, dummy, context);
			}
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = m_DefaultOverrider.GetDefault<SujetoIdentificableNpcAlteradoresFemeninos>(piscinaID);
			ISujetoNivel sujetoNivel3 = sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisica as ISujetoNivel;
			int valueOrDefault3 = ((sujetoNivel3 != null) ? new int?(sujetoNivel3.nivel) : null).GetValueOrDefault();
			ISujetoNivel sujetoNivel4 = sujetoIdentificableNpcAlteradoresFemeninos.personalidad as ISujetoNivel;
			int valueOrDefault4 = ((sujetoNivel4 != null) ? new int?(sujetoNivel4.nivel) : null).GetValueOrDefault();
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride((valueOrDefault3 <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, (valueOrDefault4 <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, @default, m_DefaultOverrider, m_randomGen, piscinaID, dummy, context);
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00014598 File Offset: 0x00012798
		public static ISujetoIdentificableNpc ProducirSujetoNpcConOverride(TipoDeRandomizadoParaSujeto tipoDeRandomizadoApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomizadoPersonalidad, SujetoIdentificableNpcAlteradoresFemeninos @default, ISujetoNpcProductorDefaultOverrider m_DefaultOverrider, Random m_randomGen, string piscinaID, bool dummy, Object context)
		{
			if (m_DefaultOverrider == null || dummy)
			{
				return ProductorDeSujetosNpcFemenina.ProducirSujetoNpc(tipoDeRandomizadoApariencia, tipoDeRandomizadoPersonalidad, @default, m_randomGen, dummy, context);
			}
			SujetoIdentificableNpcAlteradoresFemeninos sujetoIdentificableNpcAlteradoresFemeninos = m_DefaultOverrider.GetDefault<SujetoIdentificableNpcAlteradoresFemeninos>(piscinaID);
			ISujetoNivel sujetoNivel = sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisica as ISujetoNivel;
			int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
			ISujetoNivel sujetoNivel2 = sujetoIdentificableNpcAlteradoresFemeninos.personalidad as ISujetoNivel;
			int valueOrDefault2 = ((sujetoNivel2 != null) ? new int?(sujetoNivel2.nivel) : null).GetValueOrDefault();
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpc(m_randomGen, valueOrDefault, valueOrDefault2, sujetoIdentificableNpcAlteradoresFemeninos.aparienciaFisica, sujetoIdentificableNpcAlteradoresFemeninos.personalidad, dummy, tipoDeRandomizadoApariencia, tipoDeRandomizadoPersonalidad);
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0001463C File Offset: 0x0001283C
		public static ISujetoIdentificableNpc ProducirSujetoNpc(TipoDeRandomizadoParaSujeto tipoDeRandomizadoApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomizadoPersonalidad, SujetoIdentificableNpcAlteradoresFemeninos @default, Random m_randomGen, bool dummy, Object context)
		{
			ISujetoNivel sujetoNivel = @default.aparienciaFisica as ISujetoNivel;
			int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
			ISujetoNivel sujetoNivel2 = @default.personalidad as ISujetoNivel;
			int valueOrDefault2 = ((sujetoNivel2 != null) ? new int?(sujetoNivel2.nivel) : null).GetValueOrDefault();
			Debug.Log("usando @default mapa de npc en lugar de overrider", context);
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpc(m_randomGen, valueOrDefault, valueOrDefault2, @default.aparienciaFisica, @default.personalidad, dummy, tipoDeRandomizadoApariencia, tipoDeRandomizadoPersonalidad);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x000146C7 File Offset: 0x000128C7
		void ISujetoNpcProductor<ISujetoIdentificableNpc>.DestriurSujetoNpc(Object posibleSujeto)
		{
			ProductorDeSujetosNpcFemenina.DestriurSujetoNpc(posibleSujeto);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x000146CF File Offset: 0x000128CF
		public ISujetoIdentificableNpc ProducirSujetoNpc(bool dummy)
		{
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride(this.@default, this.m_DefaultOverrider, this.m_randomGen, this.m_piscina.ID, dummy, this);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x000146F5 File Offset: 0x000128F5
		public ISujetoIdentificableNpc ProducirSujetoNpc(TipoDeRandomizadoParaSujeto tipoDeRandomizadoApariencia, TipoDeRandomizadoParaSujeto tipoDeRandomizadoPersonalidad, bool dummy)
		{
			return ProductorDeSujetosNpcFemenina.ProducirSujetoNpcConOverride(tipoDeRandomizadoApariencia, tipoDeRandomizadoPersonalidad, this.@default, this.m_DefaultOverrider, this.m_randomGen, this.m_piscina.ID, dummy, this);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x0001471D File Offset: 0x0001291D
		ISujetoIdentificableNpc ISujetoNpcProductor<ISujetoIdentificableNpc>.DeepInstantiate(ISujetoIdentificableNpc original)
		{
			return ProductorDeSujetosNpcFemenina.DeepInstantiate(original);
		}

		// Token: 0x06000597 RID: 1431 RVA: 0x00014728 File Offset: 0x00012928
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			this.m_piscina = base.GetComponent<IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>>();
			if (this.m_piscina == null)
			{
				throw new ArgumentNullException("m_piscina", "m_piscina null reference.");
			}
			this.m_randomGen = new Random(Guid.NewGuid().GetHashCode());
			if (this.@default == null)
			{
				throw new ArgumentNullException("someObject", "someObject null reference.");
			}
			if (this.@default == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			this.m_DefaultOverrider = base.GetComponent<ISujetoNpcProductorDefaultOverrider>();
		}

		// Token: 0x04000253 RID: 595
		public SujetoIdentificableNpcAlteradoresFemeninos @default;

		// Token: 0x04000254 RID: 596
		private ISujetoNpcProductorDefaultOverrider m_DefaultOverrider;

		// Token: 0x04000255 RID: 597
		private Random m_randomGen;

		// Token: 0x04000256 RID: 598
		private IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable> m_piscina;
	}
}
