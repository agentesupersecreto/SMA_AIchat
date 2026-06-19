using System;
using System.Collections.Generic;
using System.Globalization;
using Assets.TValle.BeachGirl.Genetica.Alteradores.Runtime.Interpretadores;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Chars.Memorias;
using Assets._ReusableScripts.CuchiCuchi.Estimulos;
using Assets._ReusableScripts.Memorias.JsonMemorias.Clases;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Characters.Memorias
{
	// Token: 0x02000007 RID: 7
	[Obsolete("reemplazado por memoria de interacciones", true)]
	[MemoriaRelatedBehaviour]
	public class MemoriaDePlaylableCharacterNoVolatil : MemoriaDeCharacterBase
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002D50 File Offset: 0x00000F50
		public override bool permanente
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002D53 File Offset: 0x00000F53
		public MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales interpretacionesGenerales
		{
			get
			{
				return this.m_InterpretacionesGenerales;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002D5B File Offset: 0x00000F5B
		public MemoriaDePlaylableCharacterNoVolatil.HashSetDeEmocionesMaximasGenerales emocionesMaxGenerales
		{
			get
			{
				return this.m_emocionesMaxGenerales;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002D63 File Offset: 0x00000F63
		public MemoriaDePlaylableCharacterNoVolatil.HashSetDeEstimulosGenerales estimulosSingulares
		{
			get
			{
				return this.m_estimulosSingulares;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002D6B File Offset: 0x00000F6B
		public override string selfMemKeyName
		{
			get
			{
				return "Estimulos";
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002D74 File Offset: 0x00000F74
		protected override void OnLoadMemory(JsonMemoryNode m_memoria)
		{
			this.m_estimulosSingulares.Clear();
			this.m_SingularesParaEstimulos.Clear();
			this.m_SingularesParaEstimulos.Add(Guid.Empty);
			JsonMemoryNode jsonMemoryNode = m_memoria.FindChildNotNull("EstimulosSingulares");
			foreach (KeyValuePair<string, string> keyValuePair in jsonMemoryNode.data)
			{
				MemoriaDePlaylableCharacterNoVolatil.EstimuloKey estimuloKey;
				MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
				if (!jsonMemoryNode.TryFindDataObject(keyValuePair.Key, out estimuloKey, out dataGeneral, null, null))
				{
					Debug.LogError("No se pudo  deserializar data de diccionario de estimulos", this);
				}
				else
				{
					this.m_estimulosSingulares.Add(estimuloKey, dataGeneral);
				}
			}
			this.m_emocionesMaxGenerales.Clear();
			JsonMemoryNode jsonMemoryNode2 = m_memoria.FindChildNotNull("EmocionesMax");
			foreach (KeyValuePair<string, string> keyValuePair2 in jsonMemoryNode2.data)
			{
				ReaccionHumana reaccionHumana;
				MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral2;
				if (!Enum.TryParse<ReaccionHumana>(keyValuePair2.Key, out reaccionHumana))
				{
					Debug.LogError("No se pudo  deserializar key de diccionario de emociones max", this);
				}
				else if (!jsonMemoryNode2.TryFindDataObject(keyValuePair2.Key, out dataGeneral2, null))
				{
					Debug.LogError("No se pudo  deserializar data de diccionario de emociones max", this);
				}
				else
				{
					this.m_emocionesMaxGenerales.Add((int)reaccionHumana, dataGeneral2);
				}
			}
			this.m_InterpretacionesGenerales.Clear();
			this.m_SingularesParaInterpretaciones.Clear();
			this.m_SingularesParaInterpretaciones.Add(Guid.Empty);
			JsonMemoryNode jsonMemoryNode3 = m_memoria.FindChildNotNull("interpretaciones");
			foreach (KeyValuePair<string, string> keyValuePair3 in jsonMemoryNode3.data)
			{
				MemoriaDePlaylableCharacterNoVolatil.StringIntKey stringIntKey;
				MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral3;
				if (!jsonMemoryNode3.TryFindDataObject(keyValuePair3.Key, out stringIntKey, out dataGeneral3, null, null))
				{
					Debug.LogError("No se pudo  deserializar data de diccionario de interpretaciones", this);
				}
				else
				{
					this.m_InterpretacionesGenerales.Add(stringIntKey, dataGeneral3);
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002F60 File Offset: 0x00001160
		protected override void OnSavingMemory(JsonMemoryNode m_memoria)
		{
			JsonMemoryNode jsonMemoryNode = m_memoria.FindChildNotNull("EstimulosSingulares");
			jsonMemoryNode.ResetMemoria();
			foreach (KeyValuePair<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDePlaylableCharacterNoVolatil.DataGeneral> keyValuePair in this.m_estimulosSingulares)
			{
				MemoriaDePlaylableCharacterNoVolatil.EstimuloKey estimuloKey = keyValuePair.Key;
				jsonMemoryNode.AddDataObject(estimuloKey, keyValuePair.Value, true);
			}
			JsonMemoryNode jsonMemoryNode2 = m_memoria.FindChildNotNull("EmocionesMax");
			jsonMemoryNode2.ResetMemoria();
			foreach (KeyValuePair<int, MemoriaDePlaylableCharacterNoVolatil.DataGeneral> keyValuePair2 in this.m_emocionesMaxGenerales)
			{
				jsonMemoryNode2.AddDataObject(keyValuePair2.Key.ToString(CultureInfo.InvariantCulture), keyValuePair2.Value, true);
			}
			JsonMemoryNode jsonMemoryNode3 = m_memoria.FindChildNotNull("interpretaciones");
			jsonMemoryNode3.ResetMemoria();
			foreach (KeyValuePair<ValueTuple<string, int>, MemoriaDePlaylableCharacterNoVolatil.DataGeneral> keyValuePair3 in this.m_InterpretacionesGenerales)
			{
				MemoriaDePlaylableCharacterNoVolatil.StringIntKey stringIntKey = keyValuePair3.Key;
				jsonMemoryNode3.AddDataObject(stringIntKey, keyValuePair3.Value, true);
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000030C0 File Offset: 0x000012C0
		public void RegistrarEstimulo(Character afectada, ParteQuePuedeEstimular estimulante, InteracionEstimulanteBasica estimulo)
		{
			DireccionDeEstimulo tipo = estimulo.tipo;
			DireccionDeEstimulo direccionDeEstimulo;
			if (tipo != DireccionDeEstimulo.recibida)
			{
				if (tipo != DireccionDeEstimulo.dada)
				{
					throw new ArgumentOutOfRangeException(estimulo.tipo.ToString());
				}
				direccionDeEstimulo = DireccionDeEstimulo.recibida;
			}
			else
			{
				direccionDeEstimulo = DireccionDeEstimulo.dada;
			}
			for (int i = 0; i < estimulo.partesDelCuerpoHumanoEstimuladas.Count; i++)
			{
				this.RegistrarEstimulo(afectada, estimulante, estimulo.partesDelCuerpoHumanoEstimuladas[i], direccionDeEstimulo, estimulo.tipoDeEstimulo);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00003130 File Offset: 0x00001330
		public void RegistrarEstimulo(Character afectada, ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo)
		{
			this.RegistrarEstimuloSingular(afectada, estimulante, estimulada, direccion, tipoDeEstimulo);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00003140 File Offset: 0x00001340
		public void RegistrarEstimuloSingular(Character afectada, ParteQuePuedeEstimular estimulante, ParteDelCuerpoHumano estimulada, DireccionDeEstimulo direccion, TipoDeEstimulo tipoDeEstimulo)
		{
			if (this.m_SingularesParaEstimulos.Contains(afectada.ID_Unico))
			{
				return;
			}
			ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> valueTuple = new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(tipoDeEstimulo, direccion, estimulada, estimulante);
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (!this.m_estimulosSingulares.TryGetValue(valueTuple, out dataGeneral))
			{
				dataGeneral = new MemoriaDePlaylableCharacterNoVolatil.DataGeneral();
				this.m_estimulosSingulares.Add(valueTuple, dataGeneral);
			}
			dataGeneral.cantidad++;
		}

		// Token: 0x0600002F RID: 47 RVA: 0x000031A0 File Offset: 0x000013A0
		public void RegistrarEmocionMax(Emocion emocion)
		{
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (!this.m_emocionesMaxGenerales.TryGetValue((int)emocion.reaccion, out dataGeneral))
			{
				dataGeneral = new MemoriaDePlaylableCharacterNoVolatil.DataGeneral();
				this.m_emocionesMaxGenerales.Add((int)emocion.reaccion, dataGeneral);
			}
			dataGeneral.cantidad++;
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000031E8 File Offset: 0x000013E8
		public void RegistrarInterpretacion(Character afectada, ref InterpretacionCompletaDeFemale interpretacion)
		{
			if (this.m_SingularesParaInterpretaciones.Contains(afectada.ID_Unico))
			{
				return;
			}
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeRaza(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeRaza.african, new string[] { "interpretacionDeRaza", "african" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeRaza(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeRaza.asian, new string[] { "interpretacionDeRaza", "asian" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeRaza(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeRaza.elf, new string[] { "interpretacionDeRaza", "elf" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeRaza(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeRaza.hispanic, new string[] { "interpretacionDeRaza", "hispanic" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeRaza(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeRaza.nordic, new string[] { "interpretacionDeRaza", "nordic" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeSizes(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeSenos.size, new string[] { "interpretacionDeSenos", "size" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeSizes(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeAss.size, new string[] { "interpretacionDeAss", "size" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeAltura(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeBodySuperficial.altura, new string[] { "interpretacionDeBodySuperficial", "altura" });
			MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacionDeCapacidad(this.m_InterpretacionesGenerales, interpretacion.interpretacionDeBodySuperficial.bodyfat, new string[] { "interpretacionDeBodySuperficial", "bodyfat" });
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00003398 File Offset: 0x00001598
		private static void RegistrarInterpretacionDeCapacidad(MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales dicc, Interpretacion.Capacidad currentValue, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			if (currentValue == Interpretacion.Capacidad.veryLow)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -2);
			}
			if (currentValue == Interpretacion.Capacidad.low)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -1);
			}
			if (currentValue == Interpretacion.Capacidad.medium)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 0);
			}
			if (currentValue == Interpretacion.Capacidad.high)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 1);
			}
			if (currentValue == Interpretacion.Capacidad.veryHigh)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 2);
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000033EC File Offset: 0x000015EC
		private static void RegistrarInterpretacionDeAltura(MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales dicc, Interpretacion.Height currentValue, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			if (currentValue == Interpretacion.Height.veryShort)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -2);
			}
			if (currentValue == Interpretacion.Height.@short)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -1);
			}
			if (currentValue == Interpretacion.Height.normal)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 0);
			}
			if (currentValue == Interpretacion.Height.tall)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 1);
			}
			if (currentValue == Interpretacion.Height.veryTall)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 2);
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003440 File Offset: 0x00001640
		private static void RegistrarInterpretacionDeSizes(MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales dicc, Interpretacion.Size currentValue, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			if (currentValue == Interpretacion.Size.verySmall)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -2);
			}
			if (currentValue == Interpretacion.Size.small)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, -1);
			}
			if (currentValue == Interpretacion.Size.normal)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 0);
			}
			if (currentValue == Interpretacion.Size.large)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 1);
			}
			if (currentValue == Interpretacion.Size.veryLarge)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 2);
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00003494 File Offset: 0x00001694
		private static void RegistrarInterpretacionDeRaza(MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales dicc, Interpretacion.CantidadNoContable currentValue, params string[] ruta)
		{
			string text = string.Join('.', ruta);
			if (currentValue == Interpretacion.CantidadNoContable.some)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, text, 0);
			}
			if (currentValue == Interpretacion.CantidadNoContable.aLot)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, string.Join('.', ruta), 1);
			}
			if (currentValue == Interpretacion.CantidadNoContable.tooMuch)
			{
				MemoriaDePlaylableCharacterNoVolatil.RegistrarInterpretacion(dicc, string.Join('.', ruta), 2);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000034DC File Offset: 0x000016DC
		private static void RegistrarInterpretacion(MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales dicc, string field, int value)
		{
			ValueTuple<string, int> valueTuple = new ValueTuple<string, int>(field, value);
			MemoriaDePlaylableCharacterNoVolatil.DataGeneral dataGeneral;
			if (!dicc.TryGetValue(valueTuple, out dataGeneral))
			{
				dataGeneral = new MemoriaDePlaylableCharacterNoVolatil.DataGeneral();
				dicc.Add(valueTuple, dataGeneral);
			}
			dataGeneral.cantidad++;
		}

		// Token: 0x0400000B RID: 11
		private const string estimulosSingularesMemKey = "EstimulosSingulares";

		// Token: 0x0400000C RID: 12
		private const string emocionesMaxMemKey = "EmocionesMax";

		// Token: 0x0400000D RID: 13
		private const string interpretacionesMemKey = "interpretaciones";

		// Token: 0x0400000E RID: 14
		private const string estimulosDataKey = "Estimulos";

		// Token: 0x0400000F RID: 15
		private HashSet<Guid> m_SingularesParaEstimulos = new HashSet<Guid>();

		// Token: 0x04000010 RID: 16
		private HashSet<Guid> m_SingularesParaInterpretaciones = new HashSet<Guid>();

		// Token: 0x04000011 RID: 17
		private MemoriaDePlaylableCharacterNoVolatil.HashSetDeEstimulosGenerales m_estimulosSingulares = new MemoriaDePlaylableCharacterNoVolatil.HashSetDeEstimulosGenerales();

		// Token: 0x04000012 RID: 18
		private MemoriaDePlaylableCharacterNoVolatil.HashSetDeEmocionesMaximasGenerales m_emocionesMaxGenerales = new MemoriaDePlaylableCharacterNoVolatil.HashSetDeEmocionesMaximasGenerales();

		// Token: 0x04000013 RID: 19
		private MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales m_InterpretacionesGenerales = new MemoriaDePlaylableCharacterNoVolatil.HashSetDeInterpretacionesGenerales();

		// Token: 0x02000019 RID: 25
		public class HashSetDeEstimulosGeneralesParaCharacter : Dictionary<Guid, MemoriaDePlaylableCharacterNoVolatil.HashSetDeEstimulosGenerales>
		{
		}

		// Token: 0x0200001A RID: 26
		public class HashSetDeEstimulosGenerales : Dictionary<ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>, MemoriaDePlaylableCharacterNoVolatil.DataGeneral>
		{
		}

		// Token: 0x0200001B RID: 27
		public class HashSetDeEmocionesMaximasGenerales : Dictionary<int, MemoriaDePlaylableCharacterNoVolatil.DataGeneral>
		{
		}

		// Token: 0x0200001C RID: 28
		public class HashSetDeInterpretacionesGenerales : Dictionary<ValueTuple<string, int>, MemoriaDePlaylableCharacterNoVolatil.DataGeneral>
		{
		}

		// Token: 0x0200001D RID: 29
		[Serializable]
		public class DataGeneral
		{
			// Token: 0x06000107 RID: 263 RVA: 0x00006780 File Offset: 0x00004980
			public void SumarAEste(MemoriaDePlaylableCharacterNoVolatil.DataGeneral other)
			{
				this.cantidad += other.cantidad;
			}

			// Token: 0x04000061 RID: 97
			public int cantidad;
		}

		// Token: 0x0200001E RID: 30
		[Serializable]
		public class StringIntKey
		{
			// Token: 0x06000109 RID: 265 RVA: 0x0000679D File Offset: 0x0000499D
			public StringIntKey(string Name, int Value)
			{
				this.name = Name;
				this.value = Value;
			}

			// Token: 0x0600010A RID: 266 RVA: 0x000067B3 File Offset: 0x000049B3
			public static implicit operator MemoriaDePlaylableCharacterNoVolatil.StringIntKey(ValueTuple<string, int> tuple)
			{
				return new MemoriaDePlaylableCharacterNoVolatil.StringIntKey(tuple.Item1, tuple.Item2);
			}

			// Token: 0x0600010B RID: 267 RVA: 0x000067C6 File Offset: 0x000049C6
			public static implicit operator ValueTuple<string, int>(MemoriaDePlaylableCharacterNoVolatil.StringIntKey key)
			{
				return new ValueTuple<string, int>(key.name, key.value);
			}

			// Token: 0x04000062 RID: 98
			public string name;

			// Token: 0x04000063 RID: 99
			public int value;
		}

		// Token: 0x0200001F RID: 31
		[Serializable]
		public class EstimuloKey
		{
			// Token: 0x0600010C RID: 268 RVA: 0x000067D9 File Offset: 0x000049D9
			public EstimuloKey(TipoDeEstimulo tipo, DireccionDeEstimulo direccion, ParteDelCuerpoHumano estimulada, ParteQuePuedeEstimular estimulante)
			{
				this.tipo = (int)tipo;
				this.direccion = (int)direccion;
				this.estimulada = (int)estimulada;
				this.estimulante = (int)estimulante;
			}

			// Token: 0x0600010D RID: 269 RVA: 0x000067FE File Offset: 0x000049FE
			public static implicit operator MemoriaDePlaylableCharacterNoVolatil.EstimuloKey(ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular> tuple)
			{
				return new MemoriaDePlaylableCharacterNoVolatil.EstimuloKey(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
			}

			// Token: 0x0600010E RID: 270 RVA: 0x0000681D File Offset: 0x00004A1D
			public static implicit operator ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>(MemoriaDePlaylableCharacterNoVolatil.EstimuloKey key)
			{
				return new ValueTuple<TipoDeEstimulo, DireccionDeEstimulo, ParteDelCuerpoHumano, ParteQuePuedeEstimular>((TipoDeEstimulo)key.tipo, (DireccionDeEstimulo)key.direccion, (ParteDelCuerpoHumano)key.estimulada, (ParteQuePuedeEstimular)key.estimulante);
			}

			// Token: 0x04000064 RID: 100
			public int tipo;

			// Token: 0x04000065 RID: 101
			public int direccion;

			// Token: 0x04000066 RID: 102
			public int estimulada;

			// Token: 0x04000067 RID: 103
			public int estimulante;
		}

		// Token: 0x02000020 RID: 32
		public class HashSetDeEstimulosEspecificos : Dictionary<string, MemoriaDePlaylableCharacterNoVolatil.HashSetDeEstimulosGenerales>
		{
		}

		// Token: 0x02000021 RID: 33
		[Serializable]
		public class DataEspecifica : MemoriaDePlaylableCharacterNoVolatil.DataGeneral
		{
			// Token: 0x04000068 RID: 104
			public string victimaID;
		}
	}
}
