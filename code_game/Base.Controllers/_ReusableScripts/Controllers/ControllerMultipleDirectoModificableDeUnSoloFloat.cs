using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.Controllers
{
	// Token: 0x0200000C RID: 12
	public abstract class ControllerMultipleDirectoModificableDeUnSoloFloat : AplicableBehaviour, IControladorDirecto, IComponentStartable
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000076 RID: 118
		protected abstract ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor valorActualSeModificaComo { get; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000077 RID: 119
		protected abstract int cantidadDeTipos { get; }

		// Token: 0x06000078 RID: 120
		public abstract string KeyDeIndex(int index);

		// Token: 0x06000079 RID: 121
		public abstract int IndexDeKey(string key);

		// Token: 0x0600007A RID: 122
		protected abstract float ValorPorDefectoDeIndex(int index);

		// Token: 0x0600007B RID: 123
		protected abstract void ActualizarValor(int index, ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor);

		// Token: 0x0600007C RID: 124
		protected abstract void SetValues(Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> diccResultados, List<ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> resultados);

		// Token: 0x0600007D RID: 125
		protected abstract void SetDefaultValues();

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600007E RID: 126 RVA: 0x000031F0 File Offset: 0x000013F0
		// (remove) Token: 0x0600007F RID: 127 RVA: 0x00003228 File Offset: 0x00001428
		public event Action<ControllerMultipleDirectoModificableDeUnSoloFloat> updating;

		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000080 RID: 128 RVA: 0x00003260 File Offset: 0x00001460
		// (remove) Token: 0x06000081 RID: 129 RVA: 0x00003298 File Offset: 0x00001498
		public event Action<ControllerMultipleDirectoModificableDeUnSoloFloat> updated;

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000032CD File Offset: 0x000014CD
		public IReadOnlyDictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> diccResultados
		{
			get
			{
				return this.m_diccResultados;
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000032D5 File Offset: 0x000014D5
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			base.SetManualStart();
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000032E3 File Offset: 0x000014E3
		protected override void OnDisableUnityEvent(bool quitting)
		{
			base.OnDisableUnityEvent(quitting);
			this.FixValues();
		}

		// Token: 0x06000085 RID: 133 RVA: 0x000032F4 File Offset: 0x000014F4
		protected void DoStart()
		{
			this.m_diccValoresPorDefecto = new Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Valor>(this.cantidadDeTipos);
			this.m_diccOrdenesPromedio = new Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID>(this.cantidadDeTipos);
			this.m_diccOrdenesMaximoAbsoluto = new Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID>(this.cantidadDeTipos);
			this.m_diccResultados = new Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado>(this.cantidadDeTipos);
			this.m_keys = new List<string>(this.cantidadDeTipos);
			this.m_valoresPorDefecto = new List<ControllerMultipleDirectoModificableDeUnSoloFloat.Valor>(this.cantidadDeTipos);
			this.m_resultados = new List<ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado>(this.cantidadDeTipos);
			this.m_ordenesPromedio = new List<ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID>(this.cantidadDeTipos);
			this.m_ordenesValorMaximoAbsoluto = new List<ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID>(this.cantidadDeTipos);
			for (int i = 0; i < this.cantidadDeTipos; i++)
			{
				string text = this.KeyDeIndex(i);
				ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor = new ControllerMultipleDirectoModificableDeUnSoloFloat.Valor(text, this.ValorPorDefectoDeIndex(i));
				ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = new ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID(text);
				ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = new ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID(text);
				ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado resultado = new ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado(text);
				this.m_diccValoresPorDefecto.Add(i, valor);
				this.m_diccOrdenesPromedio.Add(i, ordenesDeID2);
				this.m_diccOrdenesMaximoAbsoluto.Add(i, ordenesDeID);
				this.m_diccResultados.Add(i, resultado);
				this.m_valoresPorDefecto.Add(valor);
				this.m_ordenesPromedio.Add(ordenesDeID2);
				this.m_ordenesValorMaximoAbsoluto.Add(ordenesDeID);
				this.m_resultados.Add(resultado);
				this.m_keys.Add(text);
			}
			base.ManualStart();
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00003458 File Offset: 0x00001658
		public ControllerMultipleDirectoModificableDeUnSoloFloat.Valor ObtenerValorActual(string id)
		{
			int num = this.IndexDeKey(id);
			if (num < 0)
			{
				return null;
			}
			return this.ObtenerValorActual(num);
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000347C File Offset: 0x0000167C
		public ControllerMultipleDirectoModificableDeUnSoloFloat.Valor ObtenerValorActual(int index)
		{
			if (!this.m_keys.ContieneIndex(index))
			{
				return null;
			}
			ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor;
			if (this.m_diccValoresPorDefecto.TryGetValue(index, out valor))
			{
				return valor;
			}
			return null;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000034AC File Offset: 0x000016AC
		public ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ObtenerOrdenesDeID(string id, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden tipo)
		{
			int num = this.IndexDeKey(id);
			if (num < 0)
			{
				return null;
			}
			return this.ObtenerOrdenesDeID(num, tipo);
		}

		// Token: 0x06000089 RID: 137 RVA: 0x000034D0 File Offset: 0x000016D0
		public ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ObtenerOrdenesDeID(int index, ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden tipo)
		{
			ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2;
			try
			{
				Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID> dictionary;
				if (tipo != ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerMaximoAbsoluto)
				{
					if (tipo != ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeOrden.obtenerPromedio)
					{
						throw new ArgumentOutOfRangeException(tipo.ToString());
					}
					dictionary = this.m_diccOrdenesPromedio;
				}
				else
				{
					dictionary = this.m_diccOrdenesMaximoAbsoluto;
				}
				ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID;
				if (dictionary.TryGetValue(index, out ordenesDeID))
				{
					ordenesDeID2 = ordenesDeID;
				}
				else
				{
					ordenesDeID2 = null;
				}
			}
			catch (Exception)
			{
				throw;
			}
			return ordenesDeID2;
		}

		// Token: 0x0600008A RID: 138
		protected abstract void Updating();

		// Token: 0x0600008B RID: 139
		protected abstract void Updated();

		// Token: 0x0600008C RID: 140 RVA: 0x00003534 File Offset: 0x00001734
		protected void DoUpdate()
		{
			for (int i = 0; i < this.m_keys.Count; i++)
			{
				ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor = this.m_diccValoresPorDefecto[i];
				this.ActualizarValor(i, valor);
			}
			this.Updating();
			Action<ControllerMultipleDirectoModificableDeUnSoloFloat> action = this.updating;
			if (action != null)
			{
				action(this);
			}
			try
			{
				for (int j = 0; j < this.m_keys.Count; j++)
				{
					ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID = this.m_diccOrdenesMaximoAbsoluto[j];
					ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID ordenesDeID2 = this.m_diccOrdenesPromedio[j];
					ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado resultado = this.m_diccResultados[j];
					ControllerMultipleDirectoModificableDeUnSoloFloat.Valor valor2 = this.m_diccValoresPorDefecto[j];
					float? num;
					float? num2;
					switch (this.valorActualSeModificaComo)
					{
					case ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.maximoAbsoluto:
						num = new float?(ordenesDeID.modificable.MaximoValorAbsolutoIncluyendo(valor2.valor));
						num2 = ordenesDeID2.modificable.TryObtenerPromedioNormalizadofloat();
						break;
					case ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.promedio:
						num2 = new float?(ordenesDeID2.modificable.PromediarNormalizadoConValor(valor2.valor));
						num = ordenesDeID.modificable.TryObtenerMaximoFloatAbsoluto();
						break;
					case ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.bajaPrioridad:
						num2 = ordenesDeID2.modificable.TryObtenerPromedioNormalizadofloat();
						num = ordenesDeID.modificable.TryObtenerMaximoFloatAbsoluto();
						break;
					default:
						throw new ArgumentOutOfRangeException(this.valorActualSeModificaComo.ToString());
					}
					if (this.valorActualSeModificaComo != ControllerMultipleDirectoModificableDeUnSoloFloat.TipoDeValor.bajaPrioridad && num2 == null && num == null)
					{
						throw new NotSupportedException("Esto no es posible");
					}
					float num3;
					if (num2 == null && num == null)
					{
						num3 = Mathf.Lerp(resultado.valor, valor2.valor, this.bajaProridadVelocidad + Time.deltaTime * 2f);
					}
					else if (num == null)
					{
						num3 = num2.Value;
					}
					else if (num2 == null)
					{
						num3 = num.Value;
					}
					else if (num2.Value >= Mathf.Abs(num.Value))
					{
						num3 = num2.Value;
					}
					else
					{
						num3 = num.Value + num2.Value;
					}
					float num4 = valor2.weight * this.weight;
					if (Application.isEditor)
					{
						if (float.IsNaN(num4) || float.IsInfinity(num4))
						{
							Debug.LogError("weight value de controllador fue invalido " + num4.ToString(), this);
							Debug.Break();
						}
						if (float.IsNaN(num3) || float.IsInfinity(num3))
						{
							Debug.LogError("val value de controllador fue invalido " + num3.ToString(), this);
							Debug.Break();
						}
						if (float.IsNaN(valor2.defaultValor) || float.IsInfinity(valor2.defaultValor))
						{
							Debug.LogError("defaultValor value de controllador fue invalido " + valor2.defaultValor.ToString(), this);
							Debug.Break();
						}
					}
					resultado.valor = Mathf.Lerp(valor2.defaultValor, num3, num4);
				}
				this.SetValues(this.m_diccResultados, this.m_resultados);
			}
			finally
			{
				Action<ControllerMultipleDirectoModificableDeUnSoloFloat> action2 = this.updated;
				if (action2 != null)
				{
					action2(this);
				}
				this.Updated();
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00003850 File Offset: 0x00001A50
		protected void FixValues()
		{
			this.SetDefaultValues();
		}

		// Token: 0x0400001A RID: 26
		[Range(0f, 1f)]
		public float weight = 1f;

		// Token: 0x0400001B RID: 27
		[Range(0f, 1f)]
		public float bajaProridadVelocidad = 0.333f;

		// Token: 0x0400001C RID: 28
		protected Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Valor> m_diccValoresPorDefecto;

		// Token: 0x0400001D RID: 29
		protected Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID> m_diccOrdenesMaximoAbsoluto;

		// Token: 0x0400001E RID: 30
		protected Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID> m_diccOrdenesPromedio;

		// Token: 0x0400001F RID: 31
		protected Dictionary<int, ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> m_diccResultados;

		// Token: 0x04000020 RID: 32
		[SerializeField]
		protected List<ControllerMultipleDirectoModificableDeUnSoloFloat.Valor> m_valoresPorDefecto;

		// Token: 0x04000021 RID: 33
		[SerializeField]
		protected List<ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID> m_ordenesValorMaximoAbsoluto;

		// Token: 0x04000022 RID: 34
		[SerializeField]
		protected List<ControllerMultipleDirectoModificableDeUnSoloFloat.OrdenesDeID> m_ordenesPromedio;

		// Token: 0x04000023 RID: 35
		[SerializeField]
		protected List<ControllerMultipleDirectoModificableDeUnSoloFloat.Resultado> m_resultados;

		// Token: 0x04000024 RID: 36
		[ReadOnlyUI]
		[SerializeField]
		private List<string> m_keys;

		// Token: 0x02000025 RID: 37
		[Serializable]
		public class OrdenesDeID
		{
			// Token: 0x06000152 RID: 338 RVA: 0x00005701 File Offset: 0x00003901
			public OrdenesDeID(string id)
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					throw new InvalidOperationException();
				}
				this.m_id = id;
				this.modificable = new ModificableDeFloat(0f);
			}

			// Token: 0x0400009D RID: 157
			[SerializeField]
			private string m_id;

			// Token: 0x0400009E RID: 158
			public ModificableDeFloat modificable;
		}

		// Token: 0x02000026 RID: 38
		[Serializable]
		public class Valor : ControllerMultipleDirectoModificableDeUnSoloFloat.ValorBase
		{
			// Token: 0x06000153 RID: 339 RVA: 0x0000572E File Offset: 0x0000392E
			public Valor(string id, float defValor)
				: base(id)
			{
				this.m_defaultValor = defValor;
			}

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x06000154 RID: 340 RVA: 0x00005749 File Offset: 0x00003949
			public float defaultValor
			{
				get
				{
					return this.m_defaultValor;
				}
			}

			// Token: 0x0400009F RID: 159
			[Range(0f, 1f)]
			public float weight = 1f;

			// Token: 0x040000A0 RID: 160
			[ReadOnlyUI]
			[SerializeField]
			private float m_defaultValor;
		}

		// Token: 0x02000027 RID: 39
		[Serializable]
		public sealed class Resultado : ControllerMultipleDirectoModificableDeUnSoloFloat.ValorBase
		{
			// Token: 0x06000155 RID: 341 RVA: 0x00005751 File Offset: 0x00003951
			public Resultado(string id)
				: base(id)
			{
			}
		}

		// Token: 0x02000028 RID: 40
		[Serializable]
		public abstract class ValorBase
		{
			// Token: 0x06000156 RID: 342 RVA: 0x0000575A File Offset: 0x0000395A
			protected ValorBase(string id)
			{
				if (string.IsNullOrWhiteSpace(id))
				{
					throw new InvalidOperationException();
				}
				this.m_id = id;
			}

			// Token: 0x1700003F RID: 63
			// (get) Token: 0x06000157 RID: 343 RVA: 0x00005777 File Offset: 0x00003977
			public string id
			{
				get
				{
					return this.m_id;
				}
			}

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x06000158 RID: 344 RVA: 0x0000577F File Offset: 0x0000397F
			// (set) Token: 0x06000159 RID: 345 RVA: 0x0000578E File Offset: 0x0000398E
			public float valor
			{
				get
				{
					return this.m_valor + this.m_Override;
				}
				set
				{
					this.m_valor = value;
				}
			}

			// Token: 0x040000A1 RID: 161
			[ReadOnlyUI]
			[SerializeField]
			private string m_id;

			// Token: 0x040000A2 RID: 162
			[SerializeField]
			private float m_valor;

			// Token: 0x040000A3 RID: 163
			[SerializeField]
			private float m_Override;
		}

		// Token: 0x02000029 RID: 41
		public enum TipoDeValor
		{
			// Token: 0x040000A5 RID: 165
			maximoAbsoluto,
			// Token: 0x040000A6 RID: 166
			promedio,
			// Token: 0x040000A7 RID: 167
			bajaPrioridad
		}

		// Token: 0x0200002A RID: 42
		public enum TipoDeOrden
		{
			// Token: 0x040000A9 RID: 169
			obtenerMaximoAbsoluto,
			// Token: 0x040000AA RID: 170
			obtenerPromedio
		}
	}
}
