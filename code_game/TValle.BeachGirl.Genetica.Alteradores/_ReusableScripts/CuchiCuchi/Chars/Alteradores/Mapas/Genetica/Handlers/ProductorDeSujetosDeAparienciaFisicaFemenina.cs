using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Base.Genetica.Runtime;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Clases;
using Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Clases;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers
{
	// Token: 0x02000076 RID: 118
	public sealed class ProductorDeSujetosDeAparienciaFisicaFemenina : CustomMonobehaviour, ISujetoProductor<ISujetoIdentificable>
	{
		// Token: 0x06000599 RID: 1433 RVA: 0x000147D8 File Offset: 0x000129D8
		public static ISujetoIdentificable DeepInstantiate(ISujetoIdentificable original)
		{
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = original as SujetoIdentificableAlteradoresAparienciaFemeninos;
			if (sujetoIdentificableAlteradoresAparienciaFemeninos == null)
			{
				throw new ArgumentNullException("sujetoOriginal", "sujetoOriginal null reference.");
			}
			MapaDeAlteracionesAparienciaFemeninaBase mapaDeAlteracionesAparienciaFemeninaBase = Object.Instantiate<MapaDeAlteracionesAparienciaFemeninaBase>(sujetoIdentificableAlteradoresAparienciaFemeninos.@base);
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos2 = Object.Instantiate<SujetoIdentificableAlteradoresAparienciaFemeninos>(sujetoIdentificableAlteradoresAparienciaFemeninos);
			mapaDeAlteracionesAparienciaFemeninaBase.name = sujetoIdentificableAlteradoresAparienciaFemeninos.@base.name;
			sujetoIdentificableAlteradoresAparienciaFemeninos2.name = sujetoIdentificableAlteradoresAparienciaFemeninos.name;
			sujetoIdentificableAlteradoresAparienciaFemeninos2.@base = mapaDeAlteracionesAparienciaFemeninaBase;
			return sujetoIdentificableAlteradoresAparienciaFemeninos2;
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x0001483C File Offset: 0x00012A3C
		public static ISujetoIdentificable ProducirSujeto(MapaDeAlteracionesAparienciaFemeninaBase @default, int nivelDeDefault, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandom)
		{
			if (@default == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
			sujetoIdentificableAlteradoresAparienciaFemeninos.@base = @default;
			ISujetoIdentificable sujetoIdentificable;
			try
			{
				sujetoIdentificable = ProductorDeSujetosDeAparienciaFisicaFemenina.ProducirSujeto(sujetoIdentificableAlteradoresAparienciaFemeninos, nivelDeDefault, dummy, tipoDeRandom);
			}
			finally
			{
				sujetoIdentificableAlteradoresAparienciaFemeninos.@base = null;
				Object.Destroy(sujetoIdentificableAlteradoresAparienciaFemeninos);
			}
			return sujetoIdentificable;
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x0001489C File Offset: 0x00012A9C
		public static ISujetoIdentificable ProducirSujeto(ISujeto defaultSujeto, int nivelDeDefault, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandom)
		{
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = defaultSujeto as SujetoIdentificableAlteradoresAparienciaFemeninos;
			if (sujetoIdentificableAlteradoresAparienciaFemeninos == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			MapaDeAlteracionesAparienciaFemeninaBase @base = sujetoIdentificableAlteradoresAparienciaFemeninos.@base;
			MapaDeAlteracionesAparienciaFemeninaIndependiente mapaDeAlteracionesAparienciaFemeninaIndependiente = ScriptableObject.CreateInstance<MapaDeAlteracionesAparienciaFemeninaIndependiente>();
			mapaDeAlteracionesAparienciaFemeninaIndependiente.ReemplazarAlteradorModificadores(@base.ObtenerClonesDeAlteradorModificadores());
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos2 = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresAparienciaFemeninos>();
			sujetoIdentificableAlteradoresAparienciaFemeninos2.@base = mapaDeAlteracionesAparienciaFemeninaIndependiente;
			sujetoIdentificableAlteradoresAparienciaFemeninos2.sujetoID = Guid.NewGuid();
			mapaDeAlteracionesAparienciaFemeninaIndependiente.name = (sujetoIdentificableAlteradoresAparienciaFemeninos2.name = sujetoIdentificableAlteradoresAparienciaFemeninos2.sujetoID.ToString());
			if (!dummy)
			{
				Stopwatch stopwatch = null;
				if (ProductorDeSujetosDeAparienciaFisicaFemenina.printProduccion)
				{
					stopwatch = new Stopwatch();
					stopwatch.Start();
				}
				try
				{
					sujetoIdentificableAlteradoresAparienciaFemeninos2.@base.PrepareAlteradoresDicc();
					sujetoIdentificableAlteradoresAparienciaFemeninos2.Randomizar(sujetoIdentificableAlteradoresAparienciaFemeninos, nivelDeDefault, tipoDeRandom);
					if (nivelDeDefault <= 0)
					{
						Randomizado.ModificarRandomizadoDeAparienciaV2(sujetoIdentificableAlteradoresAparienciaFemeninos2.@base.preparedAlteradoresDicc, @base);
					}
					sujetoIdentificableAlteradoresAparienciaFemeninos2.FixSymetria(1f);
				}
				finally
				{
					if (ProductorDeSujetosDeAparienciaFisicaFemenina.printProduccion)
					{
						stopwatch.Stop();
						MonoBehaviour.print(mapaDeAlteracionesAparienciaFemeninaIndependiente.name + ": " + stopwatch.Elapsed.TotalMilliseconds.ToString());
					}
				}
			}
			return sujetoIdentificableAlteradoresAparienciaFemeninos2;
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x000149C4 File Offset: 0x00012BC4
		public static void DestriurSujeto(Object posibleSujeto)
		{
			if (posibleSujeto == null)
			{
				return;
			}
			if (TValleEditorTools.IsPersistent(posibleSujeto))
			{
				return;
			}
			ISujetoIdentificable sujetoIdentificable = posibleSujeto as ISujetoIdentificable;
			if (sujetoIdentificable == null)
			{
				return;
			}
			sujetoIdentificable.Destruir();
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x000149F5 File Offset: 0x00012BF5
		public void Init()
		{
			if (!base.isAwaken)
			{
				base.ManualAwake();
			}
			if (this.@default == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			this.m_DefaultOverrider = base.GetComponent<ISujetoProductorDefaultOverrider>();
		}

		// Token: 0x0600059E RID: 1438 RVA: 0x00014A2F File Offset: 0x00012C2F
		void ISujetoProductor<ISujetoIdentificable>.DestriurSujeto(Object posibleSujeto)
		{
			ProductorDeSujetosDeAparienciaFisicaFemenina.DestriurSujeto(posibleSujeto);
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x00014A38 File Offset: 0x00012C38
		public ISujetoIdentificable ProducirSujeto(bool dummy)
		{
			IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable> component = base.GetComponent<IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>>();
			if (this.m_DefaultOverrider == null || component == null || dummy)
			{
				ISujetoNivel sujetoNivel = this.@default as ISujetoNivel;
				int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
				return this.ProducirSujeto((valueOrDefault <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, dummy);
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = this.m_DefaultOverrider.GetDefault<SujetoIdentificableAlteradoresAparienciaFemeninos>(component.ID);
			int valueOrDefault2 = ((sujetoIdentificableAlteradoresAparienciaFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresAparienciaFemeninos).nivel) : null).GetValueOrDefault();
			return this.ProducirSujeto((valueOrDefault2 <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, dummy);
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x00014AE0 File Offset: 0x00012CE0
		public ISujetoIdentificable ProducirSujeto(TipoDeRandomizadoParaSujeto tipoDeRandomizado, bool dummy)
		{
			IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable> component = base.GetComponent<IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>>();
			if (this.m_DefaultOverrider == null || component == null || dummy)
			{
				Debug.Log("usando @default mapa en lugar de overrider", this);
				ISujetoNivel sujetoNivel = this.@default as ISujetoNivel;
				int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
				return ProductorDeSujetosDeAparienciaFisicaFemenina.ProducirSujeto(this.@default, valueOrDefault, dummy, tipoDeRandomizado);
			}
			SujetoIdentificableAlteradoresAparienciaFemeninos sujetoIdentificableAlteradoresAparienciaFemeninos = this.m_DefaultOverrider.GetDefault<SujetoIdentificableAlteradoresAparienciaFemeninos>(component.ID);
			int valueOrDefault2 = ((sujetoIdentificableAlteradoresAparienciaFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresAparienciaFemeninos).nivel) : null).GetValueOrDefault();
			return ProductorDeSujetosDeAparienciaFisicaFemenina.ProducirSujeto(sujetoIdentificableAlteradoresAparienciaFemeninos, valueOrDefault2, dummy, tipoDeRandomizado);
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00014B8A File Offset: 0x00012D8A
		ISujetoIdentificable ISujetoProductor<ISujetoIdentificable>.DeepInstantiate(ISujetoIdentificable original)
		{
			return ProductorDeSujetosDeAparienciaFisicaFemenina.DeepInstantiate(original);
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x060005A2 RID: 1442 RVA: 0x00014B92 File Offset: 0x00012D92
		[Obsolete("", true)]
		private List<ModificadoresDeAlterador> modificadoresDefault
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x060005A3 RID: 1443 RVA: 0x00014B99 File Offset: 0x00012D99
		[Obsolete("", true)]
		public void ProducirGenes(Dictionary<object, GeneItem> resultado)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000257 RID: 599
		public static bool printProduccion = true;

		// Token: 0x04000258 RID: 600
		public MapaDeAlteracionesAparienciaFemeninaBase @default;

		// Token: 0x04000259 RID: 601
		private ISujetoProductorDefaultOverrider m_DefaultOverrider;

		// Token: 0x0400025A RID: 602
		[NonSerialized]
		private List<ModificadoresDeAlterador> m_modificadoresDefault;
	}
}
