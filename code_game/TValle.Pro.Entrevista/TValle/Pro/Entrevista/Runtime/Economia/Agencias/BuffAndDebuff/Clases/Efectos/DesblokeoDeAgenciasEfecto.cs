using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.BeachGirl.Characters.Male.Runtime.Memoria;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Eventos;
using Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.Mapas;
using Assets.TValle.Tools.Runtime.Characters.Atts.Emotions;
using Assets.TValle.Tools.Runtime.Characters.Intections;
using Assets._ReusableScripts;
using Assets._ReusableScripts.CuchiCuchi.Characters.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Globales;
using Assets._ReusableScripts.Memorias.JsonMemorias;
using UnityEngine;

namespace Assets.TValle.Pro.Entrevista.Runtime.Economia.Agencias.BuffAndDebuff.Clases.Efectos
{
	// Token: 0x020000E4 RID: 228
	[Serializable]
	public abstract class DesblokeoDeAgenciasEfecto<T> : Efecto<T, DesblokeoDeAgenciasArg> where T : DesblokeoDeAgenciasEfecto<T>
	{
		// Token: 0x0600081F RID: 2079 RVA: 0x0002F6BD File Offset: 0x0002D8BD
		public override void Apply(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0002F6C0 File Offset: 0x0002D8C0
		public override void Stay(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
			if (!this.HanSidoDesblokeadas(affected, argument, stacks, buff, caster))
			{
				return;
			}
			DesblokeoDeAgenciasArg desblokeoDeAgenciasArg = argument as DesblokeoDeAgenciasArg;
			if (desblokeoDeAgenciasArg == null)
			{
				return;
			}
			MonoBehaviour monoBehaviour = affected as MonoBehaviour;
			EmailsInbox emailsInbox = ((monoBehaviour != null) ? monoBehaviour.GetComponentEnRoot(false) : null);
			if (emailsInbox == null)
			{
				return;
			}
			IJsonMemoryNode jsonMemoryNode = GlobalSingletonV2<MemoriaJson>.instance.LeerDeep("Agencias", true);
			for (int i = 0; i < desblokeoDeAgenciasArg.agenciasID.Count; i++)
			{
				string text = desblokeoDeAgenciasArg.agenciasID[i];
				IJsonMemoryNode jsonMemoryNode2 = jsonMemoryNode.FindChildNotNull<IJsonMemoryNode>(text);
				if (!jsonMemoryNode2.FindDataBool("EsUnlocked", false))
				{
					jsonMemoryNode2.AddData("EsUnlocked", true, true);
					Agencia agencia = Singleton<OtrasAgencias>.instance.ObtenerAgencia(text);
					string msgUnloked = Singleton<OtrasAgencias>.instance.GetMsgUnloked(text);
					EmailAgencyUnlockedEvento emailAgencyUnlockedEvento = new EmailAgencyUnlockedEvento();
					emailAgencyUnlockedEvento.agencyID = text;
					emailAgencyUnlockedEvento.id = text;
					emailAgencyUnlockedEvento.nombre = agencia.nombre;
					emailAgencyUnlockedEvento.showMessageOnStart = false;
					emailAgencyUnlockedEvento.startDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual;
					emailAgencyUnlockedEvento.endDateTime = Singleton<TiempoDeJuego>.instance.tiempoActual + new TimeSpan(14, 0, 0, 0);
					emailAgencyUnlockedEvento.msg = msgUnloked;
					emailsInbox.eventos.Add(emailAgencyUnlockedEvento, false);
				}
			}
			emailsInbox.eventos.Sort();
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0002F814 File Offset: 0x0002DA14
		public override void Remove(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster)
		{
		}

		// Token: 0x06000822 RID: 2082
		protected abstract bool HanSidoDesblokeadas(object affected, ArgumentoDeEfecto argument, int stacks, object buff, object caster);

		// Token: 0x06000823 RID: 2083 RVA: 0x0002F818 File Offset: 0x0002DA18
		[Obsolete("reemplazado por memoria de interacciones", true)]
		public static int HanSidoInteractuadaCantidad(MemoriaDePlaylableCharacterNoVolatil memoria, TipoDeEstimulo tipoDeEstimulo, ParteDelCuerpoHumano parteDelCuerpo, IReadOnlyList<ParteQuePuedeEstimular> estimulantes)
		{
			int num = 0;
			for (int i = 0; i < estimulantes.Count; i++)
			{
				ParteQuePuedeEstimular parteQuePuedeEstimular = estimulantes[i];
				MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
				if (memoria.estimulosSingulares.TryGetValue(new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(tipoDeEstimulo, DireccionDeEstimulo.dada, parteDelCuerpo, parteQuePuedeEstimular), out dataGeneral))
				{
					num += ((dataGeneral != null) ? new int?(dataGeneral.cantidad) : null).GetValueOrDefault();
				}
			}
			return num;
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x0002F880 File Offset: 0x0002DA80
		public static int HanSidoInteractuadaCantidad(MemoriaDeIntereaccionesDeCharacter memoria, TipoDeEstimulo tipoDeEstimulo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano parteDelCuerpo, IReadOnlyList<ParteQuePuedeEstimular> estimulantes)
		{
			int num = 0;
			for (int i = 0; i < estimulantes.Count; i++)
			{
				ParteQuePuedeEstimular parteQuePuedeEstimular = estimulantes[i];
				int num2 = parteQuePuedeEstimular.ObtenerTipoDeEstimulo(tipoDeEstimulo, parteDelCuerpo, false, null);
				InterationReceivedType interationReceivedType = tipoDeEstimulo.GetInterationReceivedType(num2, direccion, parteDelCuerpo, parteQuePuedeEstimular);
				Interaction interaction;
				memoria.GetRegistro(MemoriaDeIntereaccionesDeCharacter.TipoDeRegistro.allTime, MemoriaDeIntereaccionesDeCharacter.DireccionDeRegistro.dado, parteQuePuedeEstimular.GetPartSimple(), parteDelCuerpo.GetPart(), interationReceivedType, Emotion.pleasure, false, out interaction);
				num += interaction.times;
			}
			return num;
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x0002F8E6 File Offset: 0x0002DAE6
		[Obsolete("reemplazado por memoria de interacciones", true)]
		public static int HanSidoInteractuadaCantidad(MemoriaDePlaylableCharacterNoVolatil memoria, TipoDeEstimulo tipoDeEstimulo1, TipoDeEstimulo tipoDeEstimulo2, ParteDelCuerpoHumano parteDelCuerpo, IReadOnlyList<ParteQuePuedeEstimular> estimulantes)
		{
			if (tipoDeEstimulo1 == tipoDeEstimulo2)
			{
				throw new InvalidOperationException();
			}
			return DesblokeoDeAgenciasEfecto<T>.HanSidoInteractuadaCantidad(memoria, tipoDeEstimulo1, parteDelCuerpo, estimulantes) + DesblokeoDeAgenciasEfecto<T>.HanSidoInteractuadaCantidad(memoria, tipoDeEstimulo2, parteDelCuerpo, estimulantes);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x0002F907 File Offset: 0x0002DB07
		public static int HanSidoInteractuadaCantidad(MemoriaDeIntereaccionesDeCharacter memoria, TipoDeEstimulo tipoDeEstimulo1, DireccionDeEstimulo direccion1, TipoDeEstimulo tipoDeEstimulo2, DireccionDeEstimulo direccion2, ParteDelCuerpoHumano parteDelCuerpo, IReadOnlyList<ParteQuePuedeEstimular> estimulantes)
		{
			if (tipoDeEstimulo1 == tipoDeEstimulo2)
			{
				throw new InvalidOperationException();
			}
			return DesblokeoDeAgenciasEfecto<T>.HanSidoInteractuadaCantidad(memoria, tipoDeEstimulo1, direccion1, parteDelCuerpo, estimulantes) + DesblokeoDeAgenciasEfecto<T>.HanSidoInteractuadaCantidad(memoria, tipoDeEstimulo2, direccion2, parteDelCuerpo, estimulantes);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x0002F930 File Offset: 0x0002DB30
		[Obsolete("reemplazado por memoria de interacciones", true)]
		public static int HanSidoEntrevistadaCantidad(MemoriaDePlaylableCharacterNoVolatil memoria, int value, params string[] ruta)
		{
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (!memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(string.Join('.', ruta), value), out dataGeneral))
			{
				return 0;
			}
			return dataGeneral.cantidad;
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x0002F964 File Offset: 0x0002DB64
		public static int HanSidoEntrevistadaCantidad(MaleCharInterpretacionesMemory memoria, int value, params string[] ruta)
		{
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral;
			if (!memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(string.Join('.', ruta), value), out dataGeneral))
			{
				return 0;
			}
			return dataGeneral.cantidad;
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x0002F998 File Offset: 0x0002DB98
		[Obsolete("reemplazado por memoria de interacciones", true)]
		public static int HanSidoEntrevistadaCantidad(MemoriaDePlaylableCharacterNoVolatil memoria, int value1, int value2, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			int num = 0;
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value1), out dataGeneral))
			{
				num += dataGeneral.cantidad;
			}
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral2;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value2), out dataGeneral2))
			{
				num += dataGeneral2.cantidad;
			}
			return num;
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x0002F9F0 File Offset: 0x0002DBF0
		[Obsolete("reemplazado por memoria de interacciones", true)]
		public static int HanSidoEntrevistadaCantidad(MemoriaDePlaylableCharacterNoVolatil memoria, int value1, int value2, int value3, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			int num = 0;
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value1), out dataGeneral))
			{
				num += dataGeneral.cantidad;
			}
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral2;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value2), out dataGeneral2))
			{
				num += dataGeneral2.cantidad;
			}
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral3;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value3), out dataGeneral3))
			{
				num += dataGeneral3.cantidad;
			}
			return num;
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x0002FA68 File Offset: 0x0002DC68
		public static int HanSidoEntrevistadaCantidad(MaleCharInterpretacionesMemory memoria, int value1, int value2, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			int num = 0;
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value1), out dataGeneral))
			{
				num += dataGeneral.cantidad;
			}
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral2;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value2), out dataGeneral2))
			{
				num += dataGeneral2.cantidad;
			}
			return num;
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x0002FAC0 File Offset: 0x0002DCC0
		public static int HanSidoEntrevistadaCantidad(MaleCharInterpretacionesMemory memoria, int value1, int value2, int value3, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			int num = 0;
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value1), out dataGeneral))
			{
				num += dataGeneral.cantidad;
			}
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral2;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value2), out dataGeneral2))
			{
				num += dataGeneral2.cantidad;
			}
			MaleCharInterpretacionesMemory.DataGeneral dataGeneral3;
			if (memoria.interpretacionesGenerales.TryGetValue(new ValueTuple<string, int>(text, value3), out dataGeneral3))
			{
				num += dataGeneral3.cantidad;
			}
			return num;
		}
	}
}
