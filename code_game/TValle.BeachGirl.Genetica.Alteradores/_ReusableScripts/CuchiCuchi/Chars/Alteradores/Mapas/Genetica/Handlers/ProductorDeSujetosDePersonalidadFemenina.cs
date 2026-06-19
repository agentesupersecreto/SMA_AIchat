using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Base.Genetica.Runtime;
using Assets.Base.Plugins.Runtime;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Randomizacion.Clases;
using Assets._ReusableScripts.Genetica;
using Assets._ReusableScripts.Genetica.NPCs;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Alteradores.Mapas.Genetica.Handlers
{
	// Token: 0x02000077 RID: 119
	public sealed class ProductorDeSujetosDePersonalidadFemenina : CustomMonobehaviour, ISujetoProductor<ISujetoIdentificable>
	{
		// Token: 0x060005A6 RID: 1446 RVA: 0x00014BB0 File Offset: 0x00012DB0
		public static ISujetoIdentificable DeepInstantiate(ISujetoIdentificable original)
		{
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = original as SujetoIdentificableAlteradoresPersonalidadFemeninos;
			if (sujetoIdentificableAlteradoresPersonalidadFemeninos == null)
			{
				throw new ArgumentNullException("sujetoOriginal", "sujetoOriginal null reference.");
			}
			MapaDeAlteracionesPersonalidadFemeninaBase mapaDeAlteracionesPersonalidadFemeninaBase = Object.Instantiate<MapaDeAlteracionesPersonalidadFemeninaBase>(sujetoIdentificableAlteradoresPersonalidadFemeninos.@base);
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos2 = Object.Instantiate<SujetoIdentificableAlteradoresPersonalidadFemeninos>(sujetoIdentificableAlteradoresPersonalidadFemeninos);
			mapaDeAlteracionesPersonalidadFemeninaBase.name = sujetoIdentificableAlteradoresPersonalidadFemeninos.@base.name;
			sujetoIdentificableAlteradoresPersonalidadFemeninos2.name = sujetoIdentificableAlteradoresPersonalidadFemeninos.name;
			sujetoIdentificableAlteradoresPersonalidadFemeninos2.@base = mapaDeAlteracionesPersonalidadFemeninaBase;
			return sujetoIdentificableAlteradoresPersonalidadFemeninos2;
		}

		// Token: 0x060005A7 RID: 1447 RVA: 0x00014C14 File Offset: 0x00012E14
		public static ISujetoIdentificable ProducirSujeto(MapaDeAlteracionesPersonalidadFemeninaBase @default, int nivelDeDefault, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandom)
		{
			if (@default == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
			sujetoIdentificableAlteradoresPersonalidadFemeninos.@base = @default;
			ISujetoIdentificable sujetoIdentificable;
			try
			{
				sujetoIdentificable = ProductorDeSujetosDePersonalidadFemenina.ProducirSujeto(sujetoIdentificableAlteradoresPersonalidadFemeninos, nivelDeDefault, dummy, tipoDeRandom);
			}
			finally
			{
				sujetoIdentificableAlteradoresPersonalidadFemeninos.@base = null;
				Object.Destroy(sujetoIdentificableAlteradoresPersonalidadFemeninos);
			}
			return sujetoIdentificable;
		}

		// Token: 0x060005A8 RID: 1448 RVA: 0x00014C74 File Offset: 0x00012E74
		public static ISujetoIdentificable ProducirSujeto(ISujeto defaultSujeto, int nivelDeDefault, bool dummy, TipoDeRandomizadoParaSujeto tipoDeRandom)
		{
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = defaultSujeto as SujetoIdentificableAlteradoresPersonalidadFemeninos;
			if (sujetoIdentificableAlteradoresPersonalidadFemeninos == null)
			{
				throw new ArgumentNullException("@default", "@default null reference.");
			}
			MapaDeAlteracionesPersonalidadFemeninaBase @base = sujetoIdentificableAlteradoresPersonalidadFemeninos.@base;
			MapaDeAlteracionesPersonalidadFemeninaIndependiente mapaDeAlteracionesPersonalidadFemeninaIndependiente = ScriptableObject.CreateInstance<MapaDeAlteracionesPersonalidadFemeninaIndependiente>();
			mapaDeAlteracionesPersonalidadFemeninaIndependiente.ReemplazarAlteradorModificadores(@base.ObtenerClonesDeAlteradorModificadores());
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos2 = ScriptableObject.CreateInstance<SujetoIdentificableAlteradoresPersonalidadFemeninos>();
			sujetoIdentificableAlteradoresPersonalidadFemeninos2.@base = mapaDeAlteracionesPersonalidadFemeninaIndependiente;
			sujetoIdentificableAlteradoresPersonalidadFemeninos2.sujetoID = Guid.NewGuid();
			mapaDeAlteracionesPersonalidadFemeninaIndependiente.name = (sujetoIdentificableAlteradoresPersonalidadFemeninos2.name = sujetoIdentificableAlteradoresPersonalidadFemeninos2.sujetoID.ToString());
			if (!dummy)
			{
				Stopwatch stopwatch = null;
				if (ProductorDeSujetosDePersonalidadFemenina.printProduccion)
				{
					stopwatch = new Stopwatch();
					stopwatch.Start();
				}
				try
				{
					sujetoIdentificableAlteradoresPersonalidadFemeninos2.@base.PrepareAlteradoresDicc();
					sujetoIdentificableAlteradoresPersonalidadFemeninos2.Randomizar(sujetoIdentificableAlteradoresPersonalidadFemeninos, nivelDeDefault, tipoDeRandom);
					if (nivelDeDefault <= 0)
					{
						Randomizado.ModificarRandomizadoDePersonalidadV2(sujetoIdentificableAlteradoresPersonalidadFemeninos2.@base.preparedAlteradoresDicc, @base);
					}
					sujetoIdentificableAlteradoresPersonalidadFemeninos2.FixSymetria(1f);
				}
				finally
				{
					if (ProductorDeSujetosDePersonalidadFemenina.printProduccion)
					{
						stopwatch.Stop();
						MonoBehaviour.print(mapaDeAlteracionesPersonalidadFemeninaIndependiente.name + ": " + stopwatch.Elapsed.TotalMilliseconds.ToString());
					}
				}
			}
			return sujetoIdentificableAlteradoresPersonalidadFemeninos2;
		}

		// Token: 0x060005A9 RID: 1449 RVA: 0x00014D9C File Offset: 0x00012F9C
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

		// Token: 0x060005AA RID: 1450 RVA: 0x00014DCD File Offset: 0x00012FCD
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

		// Token: 0x060005AB RID: 1451 RVA: 0x00014E07 File Offset: 0x00013007
		void ISujetoProductor<ISujetoIdentificable>.DestriurSujeto(Object posibleSujeto)
		{
			ProductorDeSujetosDePersonalidadFemenina.DestriurSujeto(posibleSujeto);
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x00014E10 File Offset: 0x00013010
		public ISujetoIdentificable ProducirSujeto(bool dummy)
		{
			IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable> component = base.GetComponent<IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>>();
			if (this.m_DefaultOverrider == null || component == null || dummy)
			{
				ISujetoNivel sujetoNivel = this.@default as ISujetoNivel;
				int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
				return this.ProducirSujeto((valueOrDefault <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, dummy);
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = this.m_DefaultOverrider.GetDefault<SujetoIdentificableAlteradoresPersonalidadFemeninos>(component.ID);
			int valueOrDefault2 = ((sujetoIdentificableAlteradoresPersonalidadFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresPersonalidadFemeninos).nivel) : null).GetValueOrDefault();
			return this.ProducirSujeto((valueOrDefault2 <= 0) ? TipoDeRandomizadoParaSujeto.guiada : TipoDeRandomizadoParaSujeto.nerfed, dummy);
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x00014EB8 File Offset: 0x000130B8
		public ISujetoIdentificable ProducirSujeto(TipoDeRandomizadoParaSujeto tipoDeRandomizado, bool dummy)
		{
			IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable> component = base.GetComponent<IPiscinaDeSujetosNPCs<ISujetoIdentificableNpc, ISujetoIdentificable>>();
			if (this.m_DefaultOverrider == null || component == null || dummy)
			{
				Debug.Log("usando @default mapa en lugar de overrider", this);
				ISujetoNivel sujetoNivel = this.@default as ISujetoNivel;
				int valueOrDefault = ((sujetoNivel != null) ? new int?(sujetoNivel.nivel) : null).GetValueOrDefault();
				return ProductorDeSujetosDePersonalidadFemenina.ProducirSujeto(this.@default, valueOrDefault, dummy, tipoDeRandomizado);
			}
			SujetoIdentificableAlteradoresPersonalidadFemeninos sujetoIdentificableAlteradoresPersonalidadFemeninos = this.m_DefaultOverrider.GetDefault<SujetoIdentificableAlteradoresPersonalidadFemeninos>(component.ID);
			int valueOrDefault2 = ((sujetoIdentificableAlteradoresPersonalidadFemeninos != null) ? new int?(((ISujetoNivel)sujetoIdentificableAlteradoresPersonalidadFemeninos).nivel) : null).GetValueOrDefault();
			return ProductorDeSujetosDePersonalidadFemenina.ProducirSujeto(sujetoIdentificableAlteradoresPersonalidadFemeninos, valueOrDefault2, dummy, tipoDeRandomizado);
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00014F62 File Offset: 0x00013162
		[Obsolete("", true)]
		public void ProducirGenes(Dictionary<object, GeneItem> resultado)
		{
			throw new NotSupportedException();
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00014F69 File Offset: 0x00013169
		ISujetoIdentificable ISujetoProductor<ISujetoIdentificable>.DeepInstantiate(ISujetoIdentificable original)
		{
			return ProductorDeSujetosDePersonalidadFemenina.DeepInstantiate(original);
		}

		// Token: 0x0400025B RID: 603
		public static bool printProduccion = true;

		// Token: 0x0400025C RID: 604
		public MapaDeAlteracionesPersonalidadFemeninaBase @default;

		// Token: 0x0400025D RID: 605
		private ISujetoProductorDefaultOverrider m_DefaultOverrider;
	}
}
