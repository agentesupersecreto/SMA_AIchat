using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Reactores.Dialogos;
using Assets._ReusableScripts.CuchiCuchi.Dialogos.Genericos.Objetos;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem
{
	// Token: 0x02000017 RID: 23
	public class GeneradorDeDialogosGenericosDeInteracciones : Singleton<GeneradorDeDialogosGenericosDeInteracciones>
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x00005082 File Offset: 0x00003282
		public IReadOnlyDictionary<ValueTuple<TipoDePersonaje, bool>, DialogosLocalizadosDeTipoDeRespuesta> respuestaDeTipoDePersonaje
		{
			get
			{
				return this.m_respuestaDeTipoDePersonaje;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x0000508C File Offset: 0x0000328C
		protected override void DoAwake()
		{
			base.DoAwake();
			for (int i = 0; i < this.tipoDePersonajesRespuestas.Count; i++)
			{
				GeneradorDeDialogosGenericosDeInteracciones.Par par = this.tipoDePersonajesRespuestas[i];
				this.m_respuestaDeTipoDePersonaje.Add(new ValueTuple<TipoDePersonaje, bool>(par.tipoDePersonaje, par.esMultiple), par.respuestas);
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000050E4 File Offset: 0x000032E4
		public string ObtenerDialogoTipoDePersonaje(TipoDePersonaje tipoDePersonaje, bool plural)
		{
			return this.m_respuestaDeTipoDePersonaje[new ValueTuple<TipoDePersonaje, bool>(tipoDePersonaje, plural)].Obtener(null).NoMutado(Localizacion.US, 1);
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005108 File Offset: 0x00003308
		public static string ObtenerDialogoGeneric(Object contexto, DialogosLocalizadosGenericos sinCosaPropia, DialogosLocalizadosGenericos conCosaPropia, ObtenerDialogosUtil Util, Character modelo, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta, ReaccionHumana reaccionHumana, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo, bool usaParteEstimulada, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, bool ignorarRedundancia, bool ignorarContextoErrado)
		{
			DialogosLocalizadosGenericos dialogosLocalizadosGenericos = (usaParteEstimulada ? conCosaPropia : sinCosaPropia);
			return GeneradorDeDialogosGenericosDeInteracciones.ObtenerDialogo(contexto, dialogosLocalizadosGenericos, Util, modelo, reaccionHumana, direccion, tipoDeEstimulo, estimulada, estimulante, tag, ignorarRedundancia, ignorarContextoErrado, tipoDeRespuesta);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x0000513C File Offset: 0x0000333C
		public static string ObtenerDialogo(Object contexto, DialogosLocalizadosGenericos lista, ObtenerDialogosUtil Util, Character modelo, ReaccionHumana reaccionHumana, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante, string tag, bool ignorarRedundancia, bool ignorarContextoErrado, Personalidad.TipoDeRespuestaDeDialogoDeHeroina tipoDeRespuesta)
		{
			Util.ReInit(modelo, contexto);
			string text;
			if (!ObtenerDialogoHelper.ObtenerDialogo(Util, lista, tipoDeRespuesta, modelo, reaccionHumana, direccion, contexto, tipoDeEstimulo, estimulada, estimulante, tag, out text, ignorarRedundancia, ignorarContextoErrado))
			{
				Debug.LogError("No se encontro dialogo", contexto);
				return "Error";
			}
			return text;
		}

		// Token: 0x04000059 RID: 89
		public DialogosLocalizadosGenericos dialogosAccion;

		// Token: 0x0400005A RID: 90
		public DialogosLocalizadosGenericos dialogosAccion3Persona;

		// Token: 0x0400005B RID: 91
		public DialogosLocalizadosGenericos dialogosAccionPresente;

		// Token: 0x0400005C RID: 92
		public DialogosLocalizadosGenericos dialogosAccionPasado;

		// Token: 0x0400005D RID: 93
		public DialogosLocalizadosGenericos dialogosAccionConCosaPropia;

		// Token: 0x0400005E RID: 94
		public DialogosLocalizadosGenericos dialogosAccion3PersonaConCosaPropia;

		// Token: 0x0400005F RID: 95
		public DialogosLocalizadosGenericos dialogosAccionPresenteConCosaPropia;

		// Token: 0x04000060 RID: 96
		public DialogosLocalizadosGenericos dialogosAccionPasadoConCosaPropia;

		// Token: 0x04000061 RID: 97
		[Header("Los tipso de personaje a lenguaje humano")]
		public List<GeneradorDeDialogosGenericosDeInteracciones.Par> tipoDePersonajesRespuestas = new List<GeneradorDeDialogosGenericosDeInteracciones.Par>();

		// Token: 0x04000062 RID: 98
		private Dictionary<ValueTuple<TipoDePersonaje, bool>, DialogosLocalizadosDeTipoDeRespuesta> m_respuestaDeTipoDePersonaje = new Dictionary<ValueTuple<TipoDePersonaje, bool>, DialogosLocalizadosDeTipoDeRespuesta>();

		// Token: 0x02000085 RID: 133
		[Serializable]
		public class Par
		{
			// Token: 0x04000196 RID: 406
			public TipoDePersonaje tipoDePersonaje;

			// Token: 0x04000197 RID: 407
			public bool esMultiple;

			// Token: 0x04000198 RID: 408
			public DialogosLocalizadosDeTipoDeRespuesta respuestas;
		}
	}
}
