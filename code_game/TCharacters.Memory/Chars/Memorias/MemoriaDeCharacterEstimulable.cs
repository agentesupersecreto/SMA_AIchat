using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.ReactoresDeEstimulos;
using Assets._ReusableScripts.CuchiCuchi.AI.UmbralesV2;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Memorias;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Chars.Memorias
{
	// Token: 0x0200000D RID: 13
	[MemoriaRelatedBehaviour]
	[Obsolete("", true)]
	public abstract class MemoriaDeCharacterEstimulable : MemoriaDeCharacterBase, IReactorRegistrador
	{
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600009B RID: 155 RVA: 0x00004424 File Offset: 0x00002624
		// (remove) Token: 0x0600009C RID: 156 RVA: 0x0000445C File Offset: 0x0000265C
		public event IReactorReaccionandoHandler reaccionando;

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00004491 File Offset: 0x00002691
		public sealed override string selfMemKeyName
		{
			get
			{
				return "Estimulos";
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00004498 File Offset: 0x00002698
		protected override void AwakeUnityEvent()
		{
			throw new NotSupportedException();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000044A0 File Offset: 0x000026A0
		protected override void OnEnableUnityEvent()
		{
			base.OnEnableUnityEvent();
			this.m_currentSession = Singleton<TiempoDeJuego>.instance.tiempoActual.Ticks;
			this.m_emos.updatedEmociones += this.M_emos_updatedEmociones;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000044E2 File Offset: 0x000026E2
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.m_emos.updatedEmociones -= this.M_emos_updatedEmociones;
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00004504 File Offset: 0x00002704
		public void Registrar(IReadOnlyList<ICalculoDeEstimulo> resultadosEnFrame)
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			for (int i = 0; i < resultadosEnFrame.Count; i++)
			{
				ICalculoDeEstimulo calculoDeEstimulo = resultadosEnFrame[i];
				if (calculoDeEstimulo.tipo == TipoDeCalculoDeEstimulo.frame)
				{
					this.RegistrarEstimulo(calculoDeEstimulo as ICalculoDeInteracionEstimulante);
				}
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x00004548 File Offset: 0x00002748
		private void RegistrarEstimulo(ICalculoDeInteracionEstimulante estimulo)
		{
			ICharacterUnico character = estimulo.GetCharacter();
			if (character == null)
			{
				if (Application.isEditor || Debug.isDebugBuild)
				{
					Debug.LogWarning("No se pudo registrar estimulo por q estimulante productor es null o no es character");
				}
				return;
			}
			ICalculoDeEstimuloCompleto calculoDeEstimuloCompleto = estimulo as ICalculoDeEstimuloCompleto;
			if (calculoDeEstimuloCompleto == null)
			{
				return;
			}
			this.registrarMaxValuePorEstimuloConPartes(character, calculoDeEstimuloCompleto);
			this.registrarEstimuloConPartes(character, calculoDeEstimuloCompleto);
			this.registrarEstimuloDeParteEstimulante(character, calculoDeEstimuloCompleto);
			this.registrarEstimuloEnParte(character, calculoDeEstimuloCompleto);
			this.registrarEstimulo(character, calculoDeEstimuloCompleto);
			this.registrarEstimuloEspecificoEnParte(character, calculoDeEstimuloCompleto);
			this.registrarEstimuloEspecifico(character, calculoDeEstimuloCompleto);
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x000045BC File Offset: 0x000027BC
		private void registrarMaxValuePorEstimuloConPartes(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			if (!estimulo.emocion.currentFrameIsValueAtMax)
			{
				return;
			}
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes dataDeMaxValuePorEstimulosConPartes = this.ObtenerMaxValuePorEstimulosConPartesPorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = this.ObtenerValorConPartes(estimulo);
			MemoriaDeCharacterEstimulable.MaxValueData maxValueData;
			if (dataDeMaxValuePorEstimulosConPartes.TryGetValue(valueTuple, out maxValueData))
			{
				maxValueData.times += 1f;
				if (maxValueData.lastSession != this.m_currentSession)
				{
					maxValueData.sessions++;
					maxValueData.lastSession = this.m_currentSession;
				}
				dataDeMaxValuePorEstimulosConPartes[valueTuple] = maxValueData;
				return;
			}
			maxValueData.times = 1f;
			maxValueData.sessions = 1;
			maxValueData.lastSession = this.m_currentSession;
			dataDeMaxValuePorEstimulosConPartes.Add(valueTuple, maxValueData);
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00004664 File Offset: 0x00002864
		private void registrarEstimuloConPartes(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes dataDeEstimulosConPartes = this.ObtenerEstimulosConPartesPorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = this.ObtenerValorConPartes(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosConPartes.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosConPartes[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosConPartes.Add(valueTuple, data);
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000472C File Offset: 0x0000292C
		private void registrarEstimuloDeParteEstimulante(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes dataDeEstimulosDePartes = this.ObtenerEstimulosDePartePorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple = this.ObtenerValorDeParte(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosDePartes.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosDePartes[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosDePartes.Add(valueTuple, data);
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000047F4 File Offset: 0x000029F4
		private void registrarEstimuloEnParte(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes dataDeEstimulosEnPartes = this.ObtenerEstimulosEnPartePorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = this.ObtenerValorEnParte(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosEnPartes.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosEnPartes[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosEnPartes.Add(valueTuple, data);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000048BC File Offset: 0x00002ABC
		private void registrarEstimulo(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos dataDeEstimulosBasicos = this.ObtenerEstimulosBasicosPorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> valueTuple = this.ObtenerValorBasico(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosBasicos.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosBasicos[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosBasicos.Add(valueTuple, data);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00004984 File Offset: 0x00002B84
		private void registrarEstimuloEspecificoEnParte(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes dataDeEstimulosEspecificosEnPartes = this.ObtenerEstimulosEspecificosEnPartePorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = this.ObtenerValorEspecificoDeParte(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosEspecificosEnPartes.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosEspecificosEnPartes[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosEspecificosEnPartes.Add(valueTuple, data);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00004A4C File Offset: 0x00002C4C
		private void registrarEstimuloEspecifico(ICharacterUnico estimulante, ICalculoDeEstimuloCompleto estimulo)
		{
			Guid id_Unico = estimulante.ID_Unico;
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos dataDeEstimulosEspecificos = this.ObtenerEstimulosEspecificosPorCharacter(id_Unico);
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> valueTuple = this.ObtenerValorEspecifico(estimulo);
			MemoriaDeCharacterEstimulable.Data data;
			if (dataDeEstimulosEspecificos.TryGetValue(valueTuple, out data))
			{
				UmbralBasico.Estado estado;
				ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado);
				data.damage += estado.estimulacionGeneradaEnFrame;
				data.duration += Time.deltaTime;
				if (data.lastSession != this.m_currentSession)
				{
					data.sessions++;
					data.lastSession = this.m_currentSession;
				}
				dataDeEstimulosEspecificos[valueTuple] = data;
				return;
			}
			UmbralBasico.Estado estado2;
			ReactorSegundario.GetEstadoConMasEstimuloEnFrame(estimulo, out estado2);
			data.damage = estado2.estimulacionGeneradaEnFrame;
			data.duration = Time.deltaTime;
			data.sessions = 1;
			data.lastSession = this.m_currentSession;
			dataDeEstimulosEspecificos.Add(valueTuple, data);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x00004B14 File Offset: 0x00002D14
		public bool ConoceACurrentMainCharacter()
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return false;
			}
			IMemoryNodeReadOnly<string, string> memoryNodeReadOnly = base.memoriaReadOnly.FindChildReadOnly("Conocidos");
			return memoryNodeReadOnly != null && memoryNodeReadOnly.FindData(current.ID_Unico.ToString()) != null;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00004B68 File Offset: 0x00002D68
		public void RegistrarCurrentMainCharacterComoConocido()
		{
			Character current = MainChar.current;
			if (current == null)
			{
				return;
			}
			MemoriaDeCharacterBase.RegistrarDeep(this, "Conocidos", current.ID_Unico.ToString(), string.Empty);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00004BAC File Offset: 0x00002DAC
		public int CantidadDeOrgasmosPorCurrentMain()
		{
			return MemoriaDeCharacterBase.CantidadRegistrada(this, "Orgasmos", MainChar.current.ID_Unico.ToString());
		}

		// Token: 0x060000AD RID: 173 RVA: 0x00004BDC File Offset: 0x00002DDC
		public bool EstimuloEstaRegistrado(Guid characterID, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ReaccionHumana).GetEnumValoresInt();
			for (int i = 1; i < enumValoresInt.Count; i++)
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)i;
				if (this.EstimuloEstaRegistrado(characterID, reaccionHumana, tipo, direccion))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00004C1C File Offset: 0x00002E1C
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos dataDeEstimulosBasicos;
			if (!this.m_estimulosRegistradosBasicoFast.TryGetValue(characterID, out dataDeEstimulosBasicos))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>(emocion, tipo, direccion);
			return ((dataDeEstimulosBasicos != null) ? new bool?(dataDeEstimulosBasicos.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004C68 File Offset: 0x00002E68
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes dataDeEstimulosEnPartes;
			if (!this.m_estimulosRegistradosEnPartesFast.TryGetValue(characterID, out dataDeEstimulosEnPartes))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>(emocion, tipo, direccion, parteEstimulada);
			return ((dataDeEstimulosEnPartes != null) ? new bool?(dataDeEstimulosEnPartes.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00004CB8 File Offset: 0x00002EB8
		public bool EstimuloEstaRegistrado(Guid characterID, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulanteParte)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ReaccionHumana).GetEnumValoresInt();
			for (int i = 1; i < enumValoresInt.Count; i++)
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)i;
				if (this.EstimuloEstaRegistrado(characterID, reaccionHumana, tipo, direccion, estimulanteParte))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00004CFC File Offset: 0x00002EFC
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes dataDeEstimulosDePartes;
			if (!this.m_estimulosRegistradosDePartesFast.TryGetValue(characterID, out dataDeEstimulosDePartes))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>(emocion, tipo, direccion, estimulanteParte);
			return ((dataDeEstimulosDePartes != null) ? new bool?(dataDeEstimulosDePartes.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00004D4C File Offset: 0x00002F4C
		public bool MaxValuePorEstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes dataDeMaxValuePorEstimulosConPartes;
			if (!this.m_maxValuePorEstimulosRegistradosConPartesFast.TryGetValue(characterID, out dataDeMaxValuePorEstimulosConPartes))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(emocion, tipo, direccion, parteEstimulada, estimulanteParte);
			return ((dataDeMaxValuePorEstimulosConPartes != null) ? new bool?(dataDeMaxValuePorEstimulosConPartes.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00004D9C File Offset: 0x00002F9C
		public bool EstimuloEstaRegistrado(Guid characterID, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulanteParte)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ReaccionHumana).GetEnumValoresInt();
			for (int i = 1; i < enumValoresInt.Count; i++)
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)i;
				if (this.EstimuloEstaRegistrado(characterID, reaccionHumana, tipo, direccion, parteEstimulada, estimulanteParte))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00004DE0 File Offset: 0x00002FE0
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes dataDeEstimulosConPartes;
			if (!this.m_estimulosRegistradosConPartesFast.TryGetValue(characterID, out dataDeEstimulosConPartes))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(emocion, tipo, direccion, parteEstimulada, estimulanteParte);
			return ((dataDeEstimulosConPartes != null) ? new bool?(dataDeEstimulosConPartes.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00004E30 File Offset: 0x00003030
		public bool EstimuloEstaRegistrado(Guid characterID, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ReaccionHumana).GetEnumValoresInt();
			for (int i = 1; i < enumValoresInt.Count; i++)
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)i;
				if (this.EstimuloEstaRegistrado(characterID, reaccionHumana, tipo, especifico, direccion, parteEstimulada))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00004E74 File Offset: 0x00003074
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes dataDeEstimulosEspecificosEnPartes;
			if (!this.m_estimulosEspecificosRegistradosEnPartesFast.TryGetValue(characterID, out dataDeEstimulosEspecificosEnPartes))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>(emocion, tipo, especifico, direccion, parteEstimulada);
			return ((dataDeEstimulosEspecificosEnPartes != null) ? new bool?(dataDeEstimulosEspecificosEnPartes.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00004EC4 File Offset: 0x000030C4
		public bool EstimuloEstaRegistrado(Guid characterID, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion)
		{
			IReadOnlyList<int> enumValoresInt = typeof(ReaccionHumana).GetEnumValoresInt();
			for (int i = 1; i < enumValoresInt.Count; i++)
			{
				ReaccionHumana reaccionHumana = (ReaccionHumana)i;
				if (this.EstimuloEstaRegistrado(characterID, reaccionHumana, tipo, especifico, direccion))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00004F08 File Offset: 0x00003108
		public bool EstimuloEstaRegistrado(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos dataDeEstimulosEspecificos;
			if (!this.m_estimulosEspecificosRegistradosFast.TryGetValue(characterID, out dataDeEstimulosEspecificos))
			{
				return false;
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>(emocion, tipo, especifico, direccion);
			return ((dataDeEstimulosEspecificos != null) ? new bool?(dataDeEstimulosEspecificos.ContainsKey(valueTuple)) : null).GetValueOrDefault();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00004F58 File Offset: 0x00003158
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos dataDeEstimulosBasicos;
			if (!this.m_estimulosRegistradosBasicoFast.TryGetValue(characterID, out dataDeEstimulosBasicos) || dataDeEstimulosBasicos == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>(emocion, tipo, direccion);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosBasicos.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00004F98 File Offset: 0x00003198
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes dataDeEstimulosEnPartes;
			if (!this.m_estimulosRegistradosEnPartesFast.TryGetValue(characterID, out dataDeEstimulosEnPartes) || dataDeEstimulosEnPartes == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>(emocion, tipo, direccion, parteEstimulada);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosEnPartes.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00004FDC File Offset: 0x000031DC
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes dataDeEstimulosDePartes;
			if (!this.m_estimulosRegistradosDePartesFast.TryGetValue(characterID, out dataDeEstimulosDePartes) || dataDeEstimulosDePartes == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>(emocion, tipo, direccion, estimulanteParte);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosDePartes.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00005020 File Offset: 0x00003220
		public MemoriaDeCharacterEstimulable.MaxValueData MaxValuePorEstimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes dataDeMaxValuePorEstimulosConPartes;
			if (!this.m_maxValuePorEstimulosRegistradosConPartesFast.TryGetValue(characterID, out dataDeMaxValuePorEstimulosConPartes) || dataDeMaxValuePorEstimulosConPartes == null)
			{
				return default(MemoriaDeCharacterEstimulable.MaxValueData);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(emocion, tipo, direccion, parteEstimulada, estimulanteParte);
			MemoriaDeCharacterEstimulable.MaxValueData maxValueData;
			dataDeMaxValuePorEstimulosConPartes.TryGetValue(valueTuple, out maxValueData);
			return maxValueData;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005064 File Offset: 0x00003264
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada, ParteQuePuedeEstimular estimulanteParte)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes dataDeEstimulosConPartes;
			if (!this.m_estimulosRegistradosConPartesFast.TryGetValue(characterID, out dataDeEstimulosConPartes) || dataDeEstimulosConPartes == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(emocion, tipo, direccion, parteEstimulada, estimulanteParte);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosConPartes.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x000050A8 File Offset: 0x000032A8
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteEstimulada)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes dataDeEstimulosEspecificosEnPartes;
			if (!this.m_estimulosEspecificosRegistradosEnPartesFast.TryGetValue(characterID, out dataDeEstimulosEspecificosEnPartes) || dataDeEstimulosEspecificosEnPartes == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>(emocion, tipo, especifico, direccion, parteEstimulada);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosEspecificosEnPartes.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x000050EC File Offset: 0x000032EC
		public MemoriaDeCharacterEstimulable.Data Estimulo(Guid characterID, ReaccionHumana emocion, TipoDeEstimulo tipo, int especifico, DireccionDeEstimulo direccion)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos dataDeEstimulosEspecificos;
			if (!this.m_estimulosEspecificosRegistradosFast.TryGetValue(characterID, out dataDeEstimulosEspecificos) || dataDeEstimulosEspecificos == null)
			{
				return default(MemoriaDeCharacterEstimulable.Data);
			}
			ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> valueTuple = new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>(emocion, tipo, especifico, direccion);
			MemoriaDeCharacterEstimulable.Data data;
			dataDeEstimulosEspecificos.TryGetValue(valueTuple, out data);
			return data;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00005130 File Offset: 0x00003330
		protected override void OnLoadMemory(JsonMemoryNode m_memoria)
		{
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.MaxValueData>(m_memoria, "MaxValuePorEstimulosConPartes", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes>(this.ObtenerMaxValuePorEstimulosConPartesPorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosConPartes", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes>(this.ObtenerEstimulosConPartesPorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosDePartes", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes>(this.ObtenerEstimulosDePartePorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEnPartes", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes>(this.ObtenerEstimulosEnPartePorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosBasicosRegistro", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos>(this.ObtenerEstimulosBasicosPorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEspecificoDePartes", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes>(this.ObtenerEstimulosEspecificosEnPartePorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>>(MemoriaDeCharacterEstimulable.TryDeSerial));
			MemoriaDeCharacterEstimulable.LoadDic<MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos, ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEspecifico", new Func<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos>(this.ObtenerEstimulosEspecificosPorCharacter), new MemoriaDeCharacterEstimulable.TryGetKeyHandle<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>>(MemoriaDeCharacterEstimulable.TryDeSerial));
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00005234 File Offset: 0x00003434
		protected override void OnSavingMemory(JsonMemoryNode m_memoria)
		{
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes>, MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.MaxValueData>(m_memoria, "MaxValuePorEstimulosConPartes", this.m_maxValuePorEstimulosRegistradosConPartesFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes>, MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosConPartes", this.m_estimulosRegistradosConPartesFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes>, MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosDePartes", this.m_estimulosRegistradosDePartesFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes>, MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEnPartes", this.m_estimulosRegistradosEnPartesFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos>, MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos, ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosBasicosRegistro", this.m_estimulosRegistradosBasicoFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes>, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes, ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEspecificoDePartes", this.m_estimulosEspecificosRegistradosEnPartesFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>, string>(MemoriaDeCharacterEstimulable.Serial));
			MemoriaDeCharacterEstimulable.SaveDicc<Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos>, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos, ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>(m_memoria, "EstimulosEspecifico", this.m_estimulosEspecificosRegistradosFast, new Func<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>, string>(MemoriaDeCharacterEstimulable.Serial));
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000530C File Offset: 0x0000350C
		public static void SaveDicc<TDicc, TSet, TKey, TData>(JsonMemoryNode memoria, string DataKey, TDicc dicc, Func<TKey, string> keyStringGetter) where TDicc : IDictionary<Guid, TSet> where TSet : IDictionary<TKey, TData>
		{
			JsonMemoryNode jsonMemoryNode = memoria.FindChildNotNull(DataKey);
			jsonMemoryNode.ResetMemoria();
			foreach (KeyValuePair<Guid, TSet> keyValuePair in dicc)
			{
				Guid key = keyValuePair.Key;
				TSet value = keyValuePair.Value;
				JsonMemoryNode jsonMemoryNode2 = jsonMemoryNode.FindChildNotNull(key.ToString());
				jsonMemoryNode2.ResetMemoria();
				foreach (KeyValuePair<TKey, TData> keyValuePair2 in value)
				{
					TKey key2 = keyValuePair2.Key;
					TData value2 = keyValuePair2.Value;
					string text = keyStringGetter(key2);
					jsonMemoryNode2.AddDataObject(text, value2, true);
				}
			}
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x000053FC File Offset: 0x000035FC
		private static void LoadDic<TSet, TKey, TData>(JsonMemoryNode memoria, string DataKey, Func<Guid, TSet> setGetter, MemoriaDeCharacterEstimulable.TryGetKeyHandle<TKey> keyGetter) where TSet : IDictionary<TKey, TData> where TData : new()
		{
			TData tdata = new TData();
			foreach (JsonMemoryNode jsonMemoryNode in memoria.FindChildNotNull(DataKey).children)
			{
				Guid guid = Guid.Parse(jsonMemoryNode.id);
				TSet tset = setGetter(guid);
				foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNode.data)
				{
					TKey tkey;
					TData tdata2;
					if (!keyGetter(keyValuePair.Key, out tkey))
					{
						Debug.LogWarning("Deserial Failed " + keyValuePair.Key);
					}
					else if (!jsonMemoryNode.TryFindDataObject(keyValuePair.Key, out tdata2, tdata))
					{
						Debug.LogWarning("Deserial Failed " + keyValuePair.Value);
					}
					else if (tset.ContainsKey(tkey))
					{
						tset[tkey] = tdata2;
					}
					else
					{
						tset.Add(tkey, tdata2);
					}
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00005534 File Offset: 0x00003734
		private MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos ObtenerEstimulosBasicosPorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos dataDeEstimulosBasicos;
			if (!this.m_estimulosRegistradosBasicoFast.TryGetValue(id, out dataDeEstimulosBasicos))
			{
				dataDeEstimulosBasicos = new MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos();
				this.m_estimulosRegistradosBasicoFast.Add(id, dataDeEstimulosBasicos);
			}
			return dataDeEstimulosBasicos;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00005565 File Offset: 0x00003765
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> ObtenerValorBasico(ICalculoDeInteracionEstimulante estimulo)
		{
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, estimulo.estimuloBasico.tipo);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00005590 File Offset: 0x00003790
		private MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes ObtenerEstimulosDePartePorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes dataDeEstimulosDePartes;
			if (!this.m_estimulosRegistradosDePartesFast.TryGetValue(id, out dataDeEstimulosDePartes))
			{
				dataDeEstimulosDePartes = new MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes();
				this.m_estimulosRegistradosDePartesFast.Add(id, dataDeEstimulosDePartes);
			}
			return dataDeEstimulosDePartes;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x000055C1 File Offset: 0x000037C1
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> ObtenerValorDeParte(ICalculoDeInteracionEstimulanteDeParteEstimulante estimulo)
		{
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, estimulo.estimuloBasico.tipo, estimulo.estimulanteParte);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000055F0 File Offset: 0x000037F0
		private MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes ObtenerMaxValuePorEstimulosConPartesPorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes dataDeMaxValuePorEstimulosConPartes;
			if (!this.m_maxValuePorEstimulosRegistradosConPartesFast.TryGetValue(id, out dataDeMaxValuePorEstimulosConPartes))
			{
				dataDeMaxValuePorEstimulosConPartes = new MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes();
				this.m_maxValuePorEstimulosRegistradosConPartesFast.Add(id, dataDeMaxValuePorEstimulosConPartes);
			}
			return dataDeMaxValuePorEstimulosConPartes;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00005624 File Offset: 0x00003824
		private MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes ObtenerEstimulosEnPartePorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes dataDeEstimulosEnPartes;
			if (!this.m_estimulosRegistradosEnPartesFast.TryGetValue(id, out dataDeEstimulosEnPartes))
			{
				dataDeEstimulosEnPartes = new MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes();
				this.m_estimulosRegistradosEnPartesFast.Add(id, dataDeEstimulosEnPartes);
			}
			return dataDeEstimulosEnPartes;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00005655 File Offset: 0x00003855
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> ObtenerValorEnParte(ICalculoDeInteracionEstimulante estimulo)
		{
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, estimulo.estimuloBasico.tipo, estimulo.PartePrincipalEstimulada(false));
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00005684 File Offset: 0x00003884
		private MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes ObtenerEstimulosConPartesPorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes dataDeEstimulosConPartes;
			if (!this.m_estimulosRegistradosConPartesFast.TryGetValue(id, out dataDeEstimulosConPartes))
			{
				dataDeEstimulosConPartes = new MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes();
				this.m_estimulosRegistradosConPartesFast.Add(id, dataDeEstimulosConPartes);
			}
			return dataDeEstimulosConPartes;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000056B5 File Offset: 0x000038B5
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> ObtenerValorConPartes(ICalculoDeInteracionEstimulanteDeParteEstimulante estimulo)
		{
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, estimulo.estimuloBasico.tipo, estimulo.PartePrincipalEstimulada(false), estimulo.estimulanteParte);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000056EC File Offset: 0x000038EC
		private MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes ObtenerEstimulosEspecificosEnPartePorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes dataDeEstimulosEspecificosEnPartes;
			if (!this.m_estimulosEspecificosRegistradosEnPartesFast.TryGetValue(id, out dataDeEstimulosEspecificosEnPartes))
			{
				dataDeEstimulosEspecificosEnPartes = new MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes();
				this.m_estimulosEspecificosRegistradosEnPartesFast.Add(id, dataDeEstimulosEspecificosEnPartes);
			}
			return dataDeEstimulosEspecificosEnPartes;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00005720 File Offset: 0x00003920
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> ObtenerValorEspecificoDeParte(ICalculoDeInteracionEstimulanteDeParteEstimulante estimulo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = estimulo.PartePrincipalEstimulada(false);
			int num = estimulo.estimulanteParte.ObtenerTipoDeEstimulo(estimulo.estimuloBasico.tipoDeEstimulo, parteDelCuerpoHumano, estimulo.tag == "golpe", estimulo.estimuloBasico);
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, num, estimulo.estimuloBasico.tipo, parteDelCuerpoHumano);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000578C File Offset: 0x0000398C
		private MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos ObtenerEstimulosEspecificosPorCharacter(Guid id)
		{
			MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos dataDeEstimulosEspecificos;
			if (!this.m_estimulosEspecificosRegistradosFast.TryGetValue(id, out dataDeEstimulosEspecificos))
			{
				dataDeEstimulosEspecificos = new MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos();
				this.m_estimulosEspecificosRegistradosFast.Add(id, dataDeEstimulosEspecificos);
			}
			return dataDeEstimulosEspecificos;
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000057C0 File Offset: 0x000039C0
		private ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> ObtenerValorEspecifico(ICalculoDeInteracionEstimulanteDeParteEstimulante estimulo)
		{
			ParteDelCuerpoHumano parteDelCuerpoHumano = estimulo.PartePrincipalEstimulada(false);
			int num = estimulo.estimulanteParte.ObtenerTipoDeEstimulo(estimulo.estimuloBasico.tipoDeEstimulo, parteDelCuerpoHumano, estimulo.tag == "golpe", estimulo.estimuloBasico);
			return new ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>(estimulo.emocion.reaccion, estimulo.estimuloBasico.tipoDeEstimulo, num, estimulo.estimuloBasico.tipo);
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x0000582A File Offset: 0x00003A2A
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> valor)
		{
			return string.Format("EstimuloDeParte[{0},{1},{2},{3}]", (int)valor.Item1, (int)valor.Item2, (int)valor.Item3);
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00005858 File Offset: 0x00003A58
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valor)
		{
			return string.Format("EstimuloEnParteDeParte[{0},{1},{2},{3},{4}]", new object[]
			{
				(int)valor.Item1,
				(int)valor.Item2,
				(int)valor.Item3,
				(int)valor.Item4
			});
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000058AD File Offset: 0x00003AAD
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> valor)
		{
			return string.Format("EstimuloEnParte[{0},{1},{2},{3}]", (int)valor.Item1, (int)valor.Item2, (int)valor.Item3);
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000058DA File Offset: 0x00003ADA
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> valor)
		{
			return string.Format("Estimulo[{0},{1},{2}]", (int)valor.Item1, (int)valor.Item2);
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x000058FC File Offset: 0x00003AFC
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> valor)
		{
			return string.Format("EstimuloEspecificoEnParte[{0},{1},{2},{3},{4}]", new object[]
			{
				(int)valor.Item1,
				(int)valor.Item2,
				valor.Item3,
				(int)valor.Item4
			});
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00005951 File Offset: 0x00003B51
		public static string Serial(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> valor)
		{
			return string.Format("EstimuloEspecifico[{0},{1},{2},{3}]", (int)valor.Item1, (int)valor.Item2, valor.Item3);
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00005980 File Offset: 0x00003B80
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("EstimuloDeParte", string.Empty);
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>("{" + string.Format("\"data\":{0}", text) + "}");
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 4)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					DireccionDeEstimulo direccionDeEstimulo;
					ParteQuePuedeEstimular parteQuePuedeEstimular;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[2].ToString(), out direccionDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<ParteQuePuedeEstimular>(wrapper.data[3].ToString(), out parteQuePuedeEstimular))
					{
						flag = false;
					}
					else
					{
						result.Item1 = reaccionHumana;
						result.Item2 = tipoDeEstimulo;
						result.Item3 = direccionDeEstimulo;
						result.Item4 = parteQuePuedeEstimular;
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00005ABC File Offset: 0x00003CBC
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("EstimuloEnParteDeParte", string.Empty);
				string text2 = string.Format("\"data\":{0}", text);
				text2 = "{" + text2 + "}";
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>(text2);
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 5)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					DireccionDeEstimulo direccionDeEstimulo;
					ParteDelCuerpoHumano parteDelCuerpoHumano;
					ParteQuePuedeEstimular parteQuePuedeEstimular;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[2].ToString(), out direccionDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<ParteDelCuerpoHumano>(wrapper.data[3].ToString(), out parteDelCuerpoHumano))
					{
						flag = false;
					}
					else if (!Enum.TryParse<ParteQuePuedeEstimular>(wrapper.data[4].ToString(), out parteQuePuedeEstimular))
					{
						flag = false;
					}
					else
					{
						result.Item1 = reaccionHumana;
						result.Item2 = tipoDeEstimulo;
						result.Item3 = direccionDeEstimulo;
						result.Item4 = parteDelCuerpoHumano;
						result.Item5 = parteQuePuedeEstimular;
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00005C28 File Offset: 0x00003E28
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("EstimuloEnParte", string.Empty);
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>("{" + string.Format("\"data\":{0}", text) + "}");
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 4)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					DireccionDeEstimulo direccionDeEstimulo;
					ParteDelCuerpoHumano parteDelCuerpoHumano;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[2].ToString(), out direccionDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<ParteDelCuerpoHumano>(wrapper.data[3].ToString(), out parteDelCuerpoHumano))
					{
						flag = false;
					}
					else
					{
						result.Item1 = reaccionHumana;
						result.Item2 = tipoDeEstimulo;
						result.Item3 = direccionDeEstimulo;
						result.Item4 = parteDelCuerpoHumano;
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00005D64 File Offset: 0x00003F64
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("Estimulo", string.Empty);
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>("{" + string.Format("\"data\":{0}", text) + "}");
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 3)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					DireccionDeEstimulo direccionDeEstimulo;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[2].ToString(), out direccionDeEstimulo))
					{
						flag = false;
					}
					else
					{
						result.Item1 = reaccionHumana;
						result.Item2 = tipoDeEstimulo;
						result.Item3 = direccionDeEstimulo;
						flag = true;
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00005E6C File Offset: 0x0000406C
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("EstimuloEspecificoEnParte", string.Empty);
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>("{" + string.Format("\"data\":{0}", text) + "}");
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 5)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else
					{
						int num = wrapper.data[2];
						DireccionDeEstimulo direccionDeEstimulo;
						ParteDelCuerpoHumano parteDelCuerpoHumano;
						if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[3].ToString(), out direccionDeEstimulo))
						{
							flag = false;
						}
						else if (!Enum.TryParse<ParteDelCuerpoHumano>(wrapper.data[4].ToString(), out parteDelCuerpoHumano))
						{
							flag = false;
						}
						else
						{
							result.Item1 = reaccionHumana;
							result.Item2 = tipoDeEstimulo;
							result.Item3 = num;
							result.Item4 = direccionDeEstimulo;
							result.Item5 = parteDelCuerpoHumano;
							flag = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00005FC0 File Offset: 0x000041C0
		public static bool TryDeSerial(string data, out ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo> result)
		{
			bool flag;
			try
			{
				string text = data.Replace("EstimuloEspecifico", string.Empty);
				MemoriaDeCharacterEstimulable.Wrapper wrapper = JsonUtility.FromJson<MemoriaDeCharacterEstimulable.Wrapper>("{" + string.Format("\"data\":{0}", text) + "}");
				if (wrapper == null || wrapper.data.Length == 0 || wrapper.data.Length < 4)
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>);
					flag = false;
				}
				else
				{
					result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>);
					ReaccionHumana reaccionHumana;
					TipoDeEstimulo tipoDeEstimulo;
					if (!Enum.TryParse<ReaccionHumana>(wrapper.data[0].ToString(), out reaccionHumana))
					{
						flag = false;
					}
					else if (!Enum.TryParse<TipoDeEstimulo>(wrapper.data[1].ToString(), out tipoDeEstimulo))
					{
						flag = false;
					}
					else
					{
						int num = wrapper.data[2];
						DireccionDeEstimulo direccionDeEstimulo;
						if (!Enum.TryParse<DireccionDeEstimulo>(wrapper.data[3].ToString(), out direccionDeEstimulo))
						{
							flag = false;
						}
						else
						{
							result.Item1 = reaccionHumana;
							result.Item2 = tipoDeEstimulo;
							result.Item3 = num;
							result.Item4 = direccionDeEstimulo;
							flag = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.LogException(ex);
				result = default(ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>);
				flag = false;
			}
			return flag;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x000060D8 File Offset: 0x000042D8
		private void M_emos_updatedEmociones(EmocionesFemeninas obj)
		{
			if (obj.placer.currentFrameIsValueAtMax)
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(this, "Orgasmos", MainChar.current.ID_Unico.ToString());
			}
			if (obj.rage.currentFrameIsValueAtMax)
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(this, "Enfurecidas", MainChar.current.ID_Unico.ToString());
			}
			if (obj.dolor.currentFrameIsValueAtMax)
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(this, "Desmayos", MainChar.current.ID_Unico.ToString());
			}
			if (obj.decepcion.currentFrameIsValueAtMax)
			{
				MemoriaDeCharacterBase.RegistrarCantidadPlus(this, "Decepciones", MainChar.current.ID_Unico.ToString());
			}
		}

		// Token: 0x04000020 RID: 32
		private const string maxValuePorestimulosConPartesDataKey = "MaxValuePorEstimulosConPartes";

		// Token: 0x04000021 RID: 33
		private const string estimulosConPartesDataKey = "EstimulosConPartes";

		// Token: 0x04000022 RID: 34
		private const string estimulosEnPartesDataKey = "EstimulosEnPartes";

		// Token: 0x04000023 RID: 35
		private const string estimulosDePartesDataKey = "EstimulosDePartes";

		// Token: 0x04000024 RID: 36
		private const string estimulosBasicosDataKey = "EstimulosBasicosRegistro";

		// Token: 0x04000025 RID: 37
		private const string estimulosEspecificoDePartesDataKey = "EstimulosEspecificoDePartes";

		// Token: 0x04000026 RID: 38
		private const string estimulosEspecificoDataKey = "EstimulosEspecifico";

		// Token: 0x04000027 RID: 39
		private const string estimulosDataKey = "Estimulos";

		// Token: 0x04000028 RID: 40
		private const string maxPlacer = "Orgasmos";

		// Token: 0x04000029 RID: 41
		private const string maxRage = "Enfurecidas";

		// Token: 0x0400002A RID: 42
		private const string maxPain = "Desmayos";

		// Token: 0x0400002B RID: 43
		private const string maxDeception = "Decepciones";

		// Token: 0x0400002C RID: 44
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes> m_maxValuePorEstimulosRegistradosConPartesFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeMaxValuePorEstimulosConPartes>();

		// Token: 0x0400002D RID: 45
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes> m_estimulosRegistradosConPartesFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosConPartes>();

		// Token: 0x0400002E RID: 46
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes> m_estimulosRegistradosEnPartesFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEnPartes>();

		// Token: 0x0400002F RID: 47
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes> m_estimulosRegistradosDePartesFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosDePartes>();

		// Token: 0x04000030 RID: 48
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos> m_estimulosRegistradosBasicoFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosBasicos>();

		// Token: 0x04000031 RID: 49
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes> m_estimulosEspecificosRegistradosEnPartesFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificosEnPartes>();

		// Token: 0x04000032 RID: 50
		private Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos> m_estimulosEspecificosRegistradosFast = new Dictionary<Guid, MemoriaDeCharacterEstimulable.DataDeEstimulosEspecificos>();

		// Token: 0x04000034 RID: 52
		private EmocionesFemeninas m_emos;

		// Token: 0x04000035 RID: 53
		[ReadOnlyUI]
		[SerializeField]
		private long m_currentSession;

		// Token: 0x04000036 RID: 54
		private const string EstimuloDeParteKeyAdded = "EstimuloDeParte";

		// Token: 0x04000037 RID: 55
		private const string EstimuloEnParteDeParteKeyAdded = "EstimuloEnParteDeParte";

		// Token: 0x04000038 RID: 56
		private const string EstimuloEnParteKeyAdded = "EstimuloEnParte";

		// Token: 0x04000039 RID: 57
		private const string EstimuloKeyAdded = "Estimulo";

		// Token: 0x0400003A RID: 58
		private const string EstimuloEspecificoEnParteKeyAdded = "EstimuloEspecificoEnParte";

		// Token: 0x0400003B RID: 59
		private const string EstimuloEspecificoKeyAdded = "EstimuloEspecifico";

		// Token: 0x0400003C RID: 60
		private const string WrapperFormat = "\"data\":{0}";

		// Token: 0x02000023 RID: 35
		// (Invoke) Token: 0x06000118 RID: 280
		private delegate bool TryGetKeyHandle<TKey>(string data, out TKey resultKey);

		// Token: 0x02000024 RID: 36
		private class Wrapper
		{
			// Token: 0x0400006C RID: 108
			public int[] data;
		}

		// Token: 0x02000025 RID: 37
		public class DataDeMaxValuePorEstimulosConPartes : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.MaxValueData>
		{
		}

		// Token: 0x02000026 RID: 38
		public class DataDeEstimulosConPartes : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x02000027 RID: 39
		public class DataDeEstimulosEnPartes : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x02000028 RID: 40
		public class DataDeEstimulosDePartes : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo, ParteQuePuedeEstimular>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x02000029 RID: 41
		public class DataDeEstimulosBasicos : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x0200002A RID: 42
		public class DataDeEstimulosEspecificosEnPartes : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo, ParteDelCuerpoHumano>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x0200002B RID: 43
		public class DataDeEstimulosEspecificos : Dictionary<ValueTuple<ReaccionHumana, TipoDeEstimulo, int, DireccionDeEstimulo>, MemoriaDeCharacterEstimulable.Data>
		{
		}

		// Token: 0x0200002C RID: 44
		[Serializable]
		public struct MaxValueData
		{
			// Token: 0x17000019 RID: 25
			// (get) Token: 0x06000123 RID: 291 RVA: 0x0000692C File Offset: 0x00004B2C
			public bool isValid
			{
				get
				{
					return this.lastSession > 0L;
				}
			}

			// Token: 0x0400006D RID: 109
			public float times;

			// Token: 0x0400006E RID: 110
			public int sessions;

			// Token: 0x0400006F RID: 111
			public long lastSession;
		}

		// Token: 0x0200002D RID: 45
		[Serializable]
		public struct Data
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000124 RID: 292 RVA: 0x00006938 File Offset: 0x00004B38
			public bool isValid
			{
				get
				{
					return this.lastSession > 0L;
				}
			}

			// Token: 0x04000070 RID: 112
			public float duration;

			// Token: 0x04000071 RID: 113
			public float damage;

			// Token: 0x04000072 RID: 114
			public int sessions;

			// Token: 0x04000073 RID: 115
			public long lastSession;
		}
	}
}
