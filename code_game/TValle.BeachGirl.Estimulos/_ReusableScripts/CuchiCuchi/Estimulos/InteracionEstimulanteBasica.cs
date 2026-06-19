using System;
using System.Collections.Generic;
using Assets.TValle.BeachGirl.Estimulos.Runtime;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Estimulos
{
	// Token: 0x0200000B RID: 11
	public abstract class InteracionEstimulanteBasica : IInteracionEstimulanteBasica, IClearable, IEsConvinable, IEsConvinable<InteracionEstimulanteBasica>, IInteracionEstimulanteBasicaPertenecibleDeCharacter, IInteracionEstimulanteInversible, IInteracionEstimulanteReutilizable, IPoolableItem
	{
		// Token: 0x06000082 RID: 130 RVA: 0x000036CD File Offset: 0x000018CD
		protected void CheckCalculoDePrioridades()
		{
			this.m_DataPrioridadesPartes.CheckCalculoDePrioridades(this.m_DataRef.estimuladoPrioridades, this.m_Data.tipoDeEstimulo, this.m_DataPartes.partesDelCuerpoHumanoEstimuladas);
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000083 RID: 131 RVA: 0x000036FB File Offset: 0x000018FB
		public float prioridadGeneral
		{
			get
			{
				this.CheckCalculoDePrioridades();
				return this.m_DataPrioridadesPartes.prioridadGeneral;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000084 RID: 132 RVA: 0x0000370E File Offset: 0x0000190E
		public float prioridadFixed
		{
			get
			{
				this.CheckCalculoDePrioridades();
				return this.m_DataPrioridadesPartes.prioridadFixed;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00003721 File Offset: 0x00001921
		public float prioridadErogena
		{
			get
			{
				this.CheckCalculoDePrioridades();
				return this.m_DataPrioridadesPartes.prioridadErogena;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000086 RID: 134 RVA: 0x00003734 File Offset: 0x00001934
		public float prioridadSensible
		{
			get
			{
				this.CheckCalculoDePrioridades();
				return this.m_DataPrioridadesPartes.prioridadSensible;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00003747 File Offset: 0x00001947
		public float prioridadPrivada
		{
			get
			{
				this.CheckCalculoDePrioridades();
				return this.m_DataPrioridadesPartes.prioridadPrivada;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000088 RID: 136 RVA: 0x0000375A File Offset: 0x0000195A
		public ParteDelCuerpoHumano principalFixed
		{
			get
			{
				this.CheckCalculoDePrioridades();
				if (this.m_DataPrioridadesPartes.overridingPrincipal)
				{
					return this.m_DataPrioridadesPartes.principalOverrided;
				}
				return this.m_DataPrioridadesPartes.principalFixed;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00003786 File Offset: 0x00001986
		public ParteDelCuerpoHumano principalErogena
		{
			get
			{
				this.CheckCalculoDePrioridades();
				if (this.m_DataPrioridadesPartes.overridingPrincipal)
				{
					return this.m_DataPrioridadesPartes.principalOverrided;
				}
				return this.m_DataPrioridadesPartes.principalErogena;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000037B2 File Offset: 0x000019B2
		public ParteDelCuerpoHumano principalSensible
		{
			get
			{
				this.CheckCalculoDePrioridades();
				if (this.m_DataPrioridadesPartes.overridingPrincipal)
				{
					return this.m_DataPrioridadesPartes.principalOverrided;
				}
				return this.m_DataPrioridadesPartes.principalSensible;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600008B RID: 139 RVA: 0x000037DE File Offset: 0x000019DE
		public ParteDelCuerpoHumano principalPrivada
		{
			get
			{
				this.CheckCalculoDePrioridades();
				if (this.m_DataPrioridadesPartes.overridingPrincipal)
				{
					return this.m_DataPrioridadesPartes.principalOverrided;
				}
				return this.m_DataPrioridadesPartes.principalPrivada;
			}
		}

		// Token: 0x0600008C RID: 140 RVA: 0x0000380C File Offset: 0x00001A0C
		public ParteDelCuerpoHumano PartePrincipalEstimulada(PrioridadDeParteDelCuerpoHumanoContexto contexto)
		{
			switch (contexto)
			{
			case PrioridadDeParteDelCuerpoHumanoContexto.@fixed:
				return this.principalFixed;
			case PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor:
				return this.principalErogena;
			case PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor:
				return this.principalSensible;
			case PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor:
				return this.principalPrivada;
			default:
				throw new ArgumentOutOfRangeException(contexto.ToString());
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600008D RID: 141 RVA: 0x0000385F File Offset: 0x00001A5F
		public double prioridad
		{
			get
			{
				return (double)(this.prioridadGeneral * 0.1f * (float)this.m_Data.tipoDeEstimulo.Prioridad());
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003880 File Offset: 0x00001A80
		public int CantidadDePartes
		{
			get
			{
				return this.m_DataPartes.partesDelCuerpoHumanoEstimuladas.Count;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00003892 File Offset: 0x00001A92
		public MonoBehaviour estimulado
		{
			get
			{
				return this.m_DataRef.estimulado;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000389F File Offset: 0x00001A9F
		public Component estimulante
		{
			get
			{
				return this.m_DataRef.estimulante;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000091 RID: 145 RVA: 0x000038AC File Offset: 0x00001AAC
		public Transform transformEstimulante
		{
			get
			{
				return this.m_DataRef.transformEstimulante;
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000038B9 File Offset: 0x00001AB9
		public Transform transformEstimulanteSegundario
		{
			get
			{
				return this.m_DataRef.transformEstimulanteSegundario;
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000093 RID: 147 RVA: 0x000038C6 File Offset: 0x00001AC6
		public IParteDelCuerpoHumanoPrioridades estimuladoPrioridades
		{
			get
			{
				return this.m_DataRef.estimuladoPrioridades;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000038D3 File Offset: 0x00001AD3
		public Transform transformEstimulado
		{
			get
			{
				return this.m_DataRef.transformEstimulado;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000095 RID: 149 RVA: 0x000038E0 File Offset: 0x00001AE0
		public Transform transformEstimuladoSegundario
		{
			get
			{
				return this.m_DataRef.transformEstimuladoSegundario;
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000038ED File Offset: 0x00001AED
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000038FA File Offset: 0x00001AFA
		public DireccionDeEstimulo tipo
		{
			get
			{
				return this.m_Data.tipo;
			}
			set
			{
				this.m_Data.tipo = value;
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00003908 File Offset: 0x00001B08
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00003915 File Offset: 0x00001B15
		public Side side
		{
			get
			{
				return this.m_Data.side;
			}
			set
			{
				this.m_Data.side = value;
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00003923 File Offset: 0x00001B23
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00003930 File Offset: 0x00001B30
		public bool esUnaVez
		{
			get
			{
				return this.m_Data.esUnaVez;
			}
			set
			{
				this.m_Data.esUnaVez = value;
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600009C RID: 156 RVA: 0x0000393E File Offset: 0x00001B3E
		// (set) Token: 0x0600009D RID: 157 RVA: 0x0000394B File Offset: 0x00001B4B
		public TipoDeEstimulo tipoDeEstimulo
		{
			get
			{
				return this.m_Data.tipoDeEstimulo;
			}
			set
			{
				this.m_Data.tipoDeEstimulo = value;
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00003959 File Offset: 0x00001B59
		public void OverridePartePrincipalEstimulada(ParteDelCuerpoHumano overriding)
		{
			this.AddParteEstimulada(overriding);
			this.m_DataPrioridadesPartes.overridingPrincipal = true;
			this.m_DataPrioridadesPartes.principalOverrided = overriding;
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000397B File Offset: 0x00001B7B
		public bool normalDefinida
		{
			get
			{
				return this.m_Data.normalDefinida;
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00003988 File Offset: 0x00001B88
		public Vector3 normalGlobalDelEstimulo
		{
			get
			{
				return this.m_Data.normalGlobalDelEstimulo.ObtenerVectorGlobal();
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000399A File Offset: 0x00001B9A
		public bool posicionDefinida
		{
			get
			{
				return this.m_Data.posicionDefinida;
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x000039A7 File Offset: 0x00001BA7
		public Vector3 posicionGlobalDelEstimulo
		{
			get
			{
				return this.m_Data.posicionGlobalDelEstimulo.ObtenerVectorGlobal();
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x000039B9 File Offset: 0x00001BB9
		public Guid estimuloID
		{
			get
			{
				return this.m_Data.estimuloID;
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x000039C6 File Offset: 0x00001BC6
		public Guid estimuloOriginalID
		{
			get
			{
				return this.m_Data.estimuloOriginalID;
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x000039D3 File Offset: 0x00001BD3
		public Guid estimuloInvertidoID
		{
			get
			{
				return this.m_Data.estimuloInvertidoID;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000039E0 File Offset: 0x00001BE0
		public void DefinirReferencias(MonoBehaviour Estimulado, IParteDelCuerpoHumanoPrioridades EstimuladoPrioridades, Component Estimulante, Transform TransformEstimulante, Transform TransformEstimulanteSegundario)
		{
			if (EstimuladoPrioridades == null)
			{
				throw new ArgumentNullException("EstimuladoPrioridades", "EstimuladoPrioridades null reference.");
			}
			this.m_DataRef.estimulado = Estimulado;
			this.m_DataRef.estimuladoPrioridades = EstimuladoPrioridades;
			this.m_DataRef.estimulante = Estimulante;
			this.m_DataRef.transformEstimulante = TransformEstimulante;
			this.m_DataRef.transformEstimulanteSegundario = TransformEstimulanteSegundario;
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00003A40 File Offset: 0x00001C40
		public void DefinirTransformsYVectores(Transform TransformEstimulado, Vector3? NormalGlobalDelEstimulo, Vector3? PosicionGlobalDelEstimulo, Transform TransformEstimuladoSegundario = null)
		{
			if (TransformEstimulado == null)
			{
				throw new ArgumentNullException("TransformEstimulado", "TransformEstimulado null reference.");
			}
			if (TransformEstimuladoSegundario)
			{
				this.m_DataRef.transformEstimuladoSegundario = TransformEstimuladoSegundario;
			}
			this.m_DataRef.transformEstimulado = TransformEstimulado;
			if (NormalGlobalDelEstimulo == null)
			{
				throw new NotSupportedException("Normal no puede ser null");
			}
			if (PosicionGlobalDelEstimulo == null)
			{
				throw new NotSupportedException("Posicion no puede ser null");
			}
			if (NormalGlobalDelEstimulo.Value == Vector3.zero)
			{
				Debug.LogError("Normal del estimulo era zero", TransformEstimulado);
				NormalGlobalDelEstimulo = new Vector3?(-TransformEstimulado.forward);
			}
			this.m_Data.normalGlobalDelEstimulo.Poblar(Vector.TipoDeVector.normal, NormalGlobalDelEstimulo.Value, TransformEstimulado);
			this.m_Data.normalDefinida = true;
			this.m_Data.posicionGlobalDelEstimulo.Poblar(Vector.TipoDeVector.punto, PosicionGlobalDelEstimulo.Value, TransformEstimulado);
			this.m_Data.posicionDefinida = true;
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00003B2A File Offset: 0x00001D2A
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00003B31 File Offset: 0x00001D31
		[Obsolete("Reemplazado por parteprincipal con contexto", true)]
		public ParteDelCuerpoHumano partePrincipalEstimulada
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00003B38 File Offset: 0x00001D38
		public IReadOnlyList<ParteDelCuerpoHumano> partesDelCuerpoHumanoEstimuladas
		{
			get
			{
				return this.m_DataPartes.partesDelCuerpoHumanoEstimuladas;
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00003B45 File Offset: 0x00001D45
		public IReadOnlyCollection<int> partesDelCuerpoHumanoEstimuladasSet
		{
			get
			{
				return this.m_DataPartes.partesDelCuerpoHumanoEstimuladasSet;
			}
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00003B52 File Offset: 0x00001D52
		public ParteDelCuerpoHumano ObtenerParteEn(int index)
		{
			return this.m_DataPartes.partesDelCuerpoHumanoEstimuladas[index];
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000AD RID: 173 RVA: 0x00003B65 File Offset: 0x00001D65
		[Obsolete("", true)]
		protected Action<ParteDelCuerpoHumano> partAdder
		{
			get
			{
				if (this.m_partAdder == null)
				{
					this.m_partAdder = new Action<ParteDelCuerpoHumano>(this.add);
				}
				return this.m_partAdder;
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00003B87 File Offset: 0x00001D87
		[Obsolete("", true)]
		private void add(ParteDelCuerpoHumano parte)
		{
			if (this.m_DataPartes.partesDelCuerpoHumanoEstimuladasSet.Add((int)parte))
			{
				this.m_DataPartes.partesDelCuerpoHumanoEstimuladas.Add(parte);
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00003BAD File Offset: 0x00001DAD
		[Obsolete("", true)]
		protected void CargarPartesEstimuladas()
		{
			this.CargarPartesEstimuladas(this.partAdder);
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00003BBB File Offset: 0x00001DBB
		[Obsolete("", true)]
		protected virtual void CargarPartesEstimuladas(Action<ParteDelCuerpoHumano> adder)
		{
			Debug.Log("ninguna parte humana sera cargada a " + base.GetType().Name);
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00003BD7 File Offset: 0x00001DD7
		public bool AddParteEstimulada(ParteDelCuerpoHumano parte)
		{
			if (this.m_DataPartes.partesDelCuerpoHumanoEstimuladasSet.Add((int)parte))
			{
				this.m_DataPartes.partesDelCuerpoHumanoEstimuladas.Add(parte);
				this.m_DataPrioridadesPartes.partesCambiaron = true;
				return true;
			}
			return false;
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x00003C0C File Offset: 0x00001E0C
		public void AddPartesEstimuladas(IReadOnlyList<ParteDelCuerpoHumano> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				this.AddParteEstimulada(partes[i]);
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x00003C38 File Offset: 0x00001E38
		public bool ContineAlgunaDeEstasPartes(IReadOnlyList<ParteDelCuerpoHumano> partes)
		{
			for (int i = 0; i < partes.Count; i++)
			{
				ParteDelCuerpoHumano parteDelCuerpoHumano = partes[i];
				if (this.m_DataPartes.partesDelCuerpoHumanoEstimuladasSet.Contains((int)parteDelCuerpoHumano))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x00003C74 File Offset: 0x00001E74
		public bool ContineParte(ParteDelCuerpoHumano parte)
		{
			return this.m_DataPartes.partesDelCuerpoHumanoEstimuladasSet.Contains((int)parte);
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00003C87 File Offset: 0x00001E87
		protected virtual bool allowDownCopy
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00003C8C File Offset: 0x00001E8C
		public virtual void CopiarA(object resultado, bool convinarPartesEstimuladas)
		{
			InteracionEstimulanteBasica interacionEstimulanteBasica = resultado as InteracionEstimulanteBasica;
			if (interacionEstimulanteBasica == null)
			{
				return;
			}
			if (!this.m_Data.normalGlobalDelEstimulo.isValid)
			{
				Debug.LogWarning("Normal de estimulo NO definida", this.m_DataRef.estimulado);
			}
			if (!this.m_Data.posicionGlobalDelEstimulo.isValid)
			{
				Debug.LogWarning("Posicion de estimulo NO definida", this.m_DataRef.estimulado);
			}
			if (this.m_DataRef.estimuladoPrioridades == null)
			{
				Debug.LogError("Copiando estimulo incompleto", this.m_DataRef.estimulado);
			}
			interacionEstimulanteBasica.m_Data = this.m_Data;
			interacionEstimulanteBasica.m_DataRef = this.m_DataRef;
			this.CheckCalculoDePrioridades();
			interacionEstimulanteBasica.m_DataPrioridadesPartes = this.m_DataPrioridadesPartes;
			if (!convinarPartesEstimuladas)
			{
				interacionEstimulanteBasica.m_DataPartes.Clear();
			}
			interacionEstimulanteBasica.AddPartesEstimuladas(this.m_DataPartes.partesDelCuerpoHumanoEstimuladas);
			if (!convinarPartesEstimuladas)
			{
				interacionEstimulanteBasica.m_DataPrioridadesPartes.partesCambiaron = false;
			}
			if (this.m_Data.tipoDeEstimulo == TipoDeEstimulo.None)
			{
				string[] array = new string[8];
				array[0] = "Copiando Estimulo de tipo: ";
				array[1] = base.GetType().Name;
				array[2] = ", de estimulado: ";
				int num = 3;
				MonoBehaviour estimulado = this.estimulado;
				array[num] = ((estimulado != null) ? estimulado.name : null);
				array[4] = ", de estimulante: ";
				int num2 = 5;
				Component estimulante = this.estimulante;
				array[num2] = ((estimulante != null) ? estimulante.name : null);
				array[6] = ". tiene tipo de estimulo: ";
				array[7] = TipoDeEstimulo.None.ToString();
				Debug.LogError(string.Concat(array), this.estimulado ? this.estimulado : this.estimulante);
				if (this.m_Data.Equals(default(InteracionEstimulanteBasica.Data)))
				{
					Debug.LogError("ademas este estimulo esta Limpio, es decir no se esta copiando nada");
				}
			}
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00003E3C File Offset: 0x0000203C
		public virtual void Clear()
		{
			if (!this.m_CLEAR_IGNORAPARTE)
			{
				this.ClearPartesEstimuladas();
			}
			this.m_DataRef.estimuladoPrioridades = null;
			this.m_DataRef.estimulado = null;
			this.m_DataRef.estimulante = null;
			this.m_DataRef.transformEstimulado = null;
			this.m_DataRef.transformEstimuladoSegundario = null;
			this.m_DataRef.transformEstimulante = null;
			this.m_DataRef.transformEstimulanteSegundario = null;
			this.m_DataRef = default(InteracionEstimulanteBasica.DataReferences);
			this.m_Data = default(InteracionEstimulanteBasica.Data);
			this.m_DataPrioridadesPartes = default(InteracionEstimulanteBasica.DataPrioridadesPartes);
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x00003ECF File Offset: 0x000020CF
		public void ClearPartesEstimuladas()
		{
			this.m_Data.side = Side.none;
			this.m_DataPartes.Clear();
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x00003EE8 File Offset: 0x000020E8
		public void ClearIgnorandoPartesEstimuladas()
		{
			this.m_CLEAR_IGNORAPARTE = true;
			try
			{
				this.Clear();
			}
			finally
			{
				this.m_CLEAR_IGNORAPARTE = false;
			}
		}

		// Token: 0x060000BA RID: 186 RVA: 0x00003F1C File Offset: 0x0000211C
		public bool Convinable(object other)
		{
			InteracionEstimulanteBasica interacionEstimulanteBasica = other as InteracionEstimulanteBasica;
			return this.Convinable(interacionEstimulanteBasica);
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00003F37 File Offset: 0x00002137
		public bool Convinable(InteracionEstimulanteBasica other)
		{
			return other != null && (other.m_Data.tipo == this.m_Data.tipo && other.m_Data.tipoDeEstimulo == this.m_Data.tipoDeEstimulo) && this.ConvinableCon(other);
		}

		// Token: 0x060000BC RID: 188
		protected abstract bool ConvinableCon(InteracionEstimulanteBasica other);

		// Token: 0x060000BD RID: 189 RVA: 0x00003F77 File Offset: 0x00002177
		public void EstimuloSoloUsaPrioridadesFixed()
		{
			this.m_DataPrioridadesPartes.siempreFixed = true;
			this.m_DataRef.estimuladoPrioridades = ParteDelCuerpoHumanoPrioridadesOnlyFixed.instanceFemenina;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00003F95 File Offset: 0x00002195
		public Component GetRealEstimulante
		{
			get
			{
				if (!this.m_Data.esCopiaInvertida)
				{
					return this.estimulante;
				}
				return this.estimulado;
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00003FB1 File Offset: 0x000021B1
		public bool tieneCopiaInvertida
		{
			get
			{
				return this.m_Data.tieneCopiaInvertida;
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00003FBE File Offset: 0x000021BE
		public bool esCopiaInvertida
		{
			get
			{
				return this.m_Data.esCopiaInvertida;
			}
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00003FCB File Offset: 0x000021CB
		void IInteracionEstimulanteReutilizable.GenerateNewID()
		{
			this.m_Data.estimuloID = Guid.NewGuid();
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00003FDD File Offset: 0x000021DD
		void IInteracionEstimulanteInversible.ClearInvertedCopy()
		{
			this.m_Data.tieneCopiaInvertida = false;
			this.m_Data.estimuloInvertidoID = Guid.Empty;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00003FFB File Offset: 0x000021FB
		void IInteracionEstimulanteInversible.ClearOriginalCopy()
		{
			this.m_Data.esCopiaInvertida = false;
			this.m_Data.estimuloOriginalID = Guid.Empty;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000401C File Offset: 0x0000221C
		void IInteracionEstimulanteInversible.SwitchReferencias()
		{
			MonoBehaviour estimulado = this.m_DataRef.estimulado;
			IParteDelCuerpoHumanoPrioridades estimuladoPrioridades = this.m_DataRef.estimuladoPrioridades;
			Component estimulante = this.m_DataRef.estimulante;
			Transform transformEstimulante = this.m_DataRef.transformEstimulante;
			Transform transformEstimulado = this.m_DataRef.transformEstimulado;
			Vector3? vector = new Vector3?(this.m_Data.normalGlobalDelEstimulo.originalVector);
			Vector3? vector2 = new Vector3?(this.m_Data.posicionGlobalDelEstimulo.originalVector);
			this.DefinirReferencias((MonoBehaviour)estimulante, estimuladoPrioridades, estimulado, transformEstimulado, null);
			this.DefinirTransformsYVectores(transformEstimulante, vector, vector2, null);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000040B4 File Offset: 0x000022B4
		void IInteracionEstimulanteInversible.SetAsInvertedCopy(IInteracionEstimulanteBasica Original)
		{
			InteracionEstimulanteBasica interacionEstimulanteBasica = (InteracionEstimulanteBasica)Original;
			this.m_Data.esCopiaInvertida = true;
			interacionEstimulanteBasica.m_Data.tieneCopiaInvertida = true;
			this.m_Data.estimuloOriginalID = interacionEstimulanteBasica.estimuloID;
			interacionEstimulanteBasica.m_Data.estimuloInvertidoID = this.estimuloID;
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004102 File Offset: 0x00002302
		Guid IPoolableItem.poolOwner
		{
			get
			{
				return this.m_ownerPoolID;
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000410A File Offset: 0x0000230A
		void IPoolableItem.SetOwner(ref Guid id)
		{
			this.m_ownerPoolID = id;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00004118 File Offset: 0x00002318
		bool IPoolableItem.Compare(ref Guid id)
		{
			return this.m_ownerPoolID == id;
		}

		// Token: 0x0400000A RID: 10
		[SerializeField]
		private InteracionEstimulanteBasica.Data m_Data;

		// Token: 0x0400000B RID: 11
		[SerializeField]
		private InteracionEstimulanteBasica.DataReferences m_DataRef;

		// Token: 0x0400000C RID: 12
		[SerializeField]
		private InteracionEstimulanteBasica.DataPartes m_DataPartes = new InteracionEstimulanteBasica.DataPartes();

		// Token: 0x0400000D RID: 13
		[SerializeField]
		private InteracionEstimulanteBasica.DataPrioridadesPartes m_DataPrioridadesPartes;

		// Token: 0x0400000E RID: 14
		[Obsolete("", true)]
		private Action<ParteDelCuerpoHumano> m_partAdder;

		// Token: 0x0400000F RID: 15
		private bool m_CLEAR_IGNORAPARTE;

		// Token: 0x04000010 RID: 16
		[NonSerialized]
		private Guid m_ownerPoolID;

		// Token: 0x0200002A RID: 42
		[Serializable]
		private struct DataPrioridadesPartes
		{
			// Token: 0x1700005E RID: 94
			// (get) Token: 0x060000FF RID: 255 RVA: 0x0000437F File Offset: 0x0000257F
			public float prioridadGeneral
			{
				get
				{
					if (this.partesCambiaron)
					{
						throw new InvalidOperationException();
					}
					return (this.prioridadFixed + this.prioridadErogena + this.prioridadSensible + this.prioridadPrivada) / 4f;
				}
			}

			// Token: 0x06000100 RID: 256 RVA: 0x000043B0 File Offset: 0x000025B0
			public void CheckCalculoDePrioridades(IParteDelCuerpoHumanoPrioridades estimuladoPrioridades, TipoDeEstimulo tipo, IReadOnlyList<ParteDelCuerpoHumano> partesEstimuladas)
			{
				if (!this.partesCambiaron)
				{
					return;
				}
				if (this.siempreFixed)
				{
					switch (tipo)
					{
					case TipoDeEstimulo.tactil:
					case TipoDeEstimulo.desvestidura:
					case TipoDeEstimulo.ejecucionDePose:
					case TipoDeEstimulo.manipulandoBone:
						this.principalPrivada = (this.principalSensible = (this.principalErogena = (this.principalFixed = partesEstimuladas.ObtenerLaDeMayorPrioridadTactilFixed(Sexo.femenino))));
						this.prioridadPrivada = (this.prioridadSensible = (this.prioridadErogena = (this.prioridadFixed = (float)this.principalFixed.PrioridadTactilFixed(Sexo.femenino))));
						goto IL_017B;
					case TipoDeEstimulo.visual:
					case TipoDeEstimulo.peticionDesvestidura:
					case TipoDeEstimulo.peticionEjecucionDePose:
					case TipoDeEstimulo.guiandoBone:
						this.principalPrivada = (this.principalSensible = (this.principalErogena = (this.principalFixed = partesEstimuladas.ObtenerLaDeMayorPrioridadVisualFixed(Sexo.femenino))));
						this.prioridadPrivada = (this.prioridadSensible = (this.prioridadErogena = (this.prioridadFixed = (float)this.principalFixed.PrioridadVisualFixed(Sexo.femenino))));
						goto IL_017B;
					case TipoDeEstimulo.coital:
						this.principalPrivada = (this.principalSensible = (this.principalErogena = (this.principalFixed = partesEstimuladas.ObtenerLaDeMayorPrioridadCoitalFixed(Sexo.femenino))));
						this.prioridadPrivada = (this.prioridadSensible = (this.prioridadErogena = (this.prioridadFixed = (float)this.principalFixed.PrioridadCoitalFixed(Sexo.femenino))));
						goto IL_017B;
					}
					throw new ArgumentOutOfRangeException(tipo.ToString());
					IL_017B:
					this.partesCambiaron = false;
					return;
				}
				switch (tipo)
				{
				case TipoDeEstimulo.tactil:
					this.principalFixed = estimuladoPrioridades.ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, partesEstimuladas);
					this.principalErogena = estimuladoPrioridades.ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, partesEstimuladas);
					this.principalSensible = estimuladoPrioridades.ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, partesEstimuladas);
					this.principalPrivada = estimuladoPrioridades.ObtenerLaDeMayorPrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, partesEstimuladas);
					this.prioridadFixed = estimuladoPrioridades.PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, this.principalFixed);
					this.prioridadErogena = estimuladoPrioridades.PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, this.principalErogena);
					this.prioridadSensible = estimuladoPrioridades.PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, this.principalSensible);
					this.prioridadPrivada = estimuladoPrioridades.PrioridadTactil(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, this.principalPrivada);
					goto IL_0377;
				case TipoDeEstimulo.visual:
				case TipoDeEstimulo.desvestidura:
				case TipoDeEstimulo.peticionDesvestidura:
				case TipoDeEstimulo.ejecucionDePose:
				case TipoDeEstimulo.peticionEjecucionDePose:
				case TipoDeEstimulo.guiandoBone:
				case TipoDeEstimulo.manipulandoBone:
					this.principalFixed = estimuladoPrioridades.ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, partesEstimuladas);
					this.principalErogena = estimuladoPrioridades.ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, partesEstimuladas);
					this.principalSensible = estimuladoPrioridades.ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, partesEstimuladas);
					this.principalPrivada = estimuladoPrioridades.ObtenerLaDeMayorPrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, partesEstimuladas);
					this.prioridadFixed = estimuladoPrioridades.PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, this.principalFixed);
					this.prioridadErogena = estimuladoPrioridades.PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, this.principalErogena);
					this.prioridadSensible = estimuladoPrioridades.PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, this.principalSensible);
					this.prioridadPrivada = estimuladoPrioridades.PrioridadVisual(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, this.principalPrivada);
					goto IL_0377;
				case TipoDeEstimulo.coital:
					this.principalFixed = estimuladoPrioridades.ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, partesEstimuladas);
					this.principalErogena = estimuladoPrioridades.ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, partesEstimuladas);
					this.principalSensible = estimuladoPrioridades.ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, partesEstimuladas);
					this.principalPrivada = estimuladoPrioridades.ObtenerLaDeMayorPrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, partesEstimuladas);
					this.prioridadFixed = estimuladoPrioridades.PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.@fixed, this.principalFixed);
					this.prioridadErogena = estimuladoPrioridades.PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.erogenoMayor, this.principalErogena);
					this.prioridadSensible = estimuladoPrioridades.PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.sensibleMayor, this.principalSensible);
					this.prioridadPrivada = estimuladoPrioridades.PrioridadCoital(PrioridadDeParteDelCuerpoHumanoContexto.privadoMayor, this.principalPrivada);
					goto IL_0377;
				}
				throw new ArgumentOutOfRangeException(tipo.ToString());
				IL_0377:
				this.partesCambiaron = false;
			}

			// Token: 0x0400009F RID: 159
			public bool siempreFixed;

			// Token: 0x040000A0 RID: 160
			public bool partesCambiaron;

			// Token: 0x040000A1 RID: 161
			public bool overridingPrincipal;

			// Token: 0x040000A2 RID: 162
			public float prioridadFixed;

			// Token: 0x040000A3 RID: 163
			public float prioridadErogena;

			// Token: 0x040000A4 RID: 164
			public float prioridadSensible;

			// Token: 0x040000A5 RID: 165
			public float prioridadPrivada;

			// Token: 0x040000A6 RID: 166
			public ParteDelCuerpoHumano principalFixed;

			// Token: 0x040000A7 RID: 167
			public ParteDelCuerpoHumano principalErogena;

			// Token: 0x040000A8 RID: 168
			public ParteDelCuerpoHumano principalSensible;

			// Token: 0x040000A9 RID: 169
			public ParteDelCuerpoHumano principalPrivada;

			// Token: 0x040000AA RID: 170
			public ParteDelCuerpoHumano principalOverrided;
		}

		// Token: 0x0200002B RID: 43
		[Serializable]
		private class DataPartes : IClearable
		{
			// Token: 0x06000101 RID: 257 RVA: 0x0000473B File Offset: 0x0000293B
			public void Clear()
			{
				this.partesDelCuerpoHumanoEstimuladas.Clear();
				this.partesDelCuerpoHumanoEstimuladasSet.Clear();
			}

			// Token: 0x040000AB RID: 171
			[SerializeField]
			public List<ParteDelCuerpoHumano> partesDelCuerpoHumanoEstimuladas = new List<ParteDelCuerpoHumano>();

			// Token: 0x040000AC RID: 172
			public HashSet<int> partesDelCuerpoHumanoEstimuladasSet = new HashSet<int>();
		}

		// Token: 0x0200002C RID: 44
		[Serializable]
		private struct Data
		{
			// Token: 0x040000AD RID: 173
			public Guid estimuloID;

			// Token: 0x040000AE RID: 174
			public Guid estimuloOriginalID;

			// Token: 0x040000AF RID: 175
			public Guid estimuloInvertidoID;

			// Token: 0x040000B0 RID: 176
			public bool normalDefinida;

			// Token: 0x040000B1 RID: 177
			public Vector normalGlobalDelEstimulo;

			// Token: 0x040000B2 RID: 178
			public bool posicionDefinida;

			// Token: 0x040000B3 RID: 179
			public Vector posicionGlobalDelEstimulo;

			// Token: 0x040000B4 RID: 180
			public DireccionDeEstimulo tipo;

			// Token: 0x040000B5 RID: 181
			public Side side;

			// Token: 0x040000B6 RID: 182
			public TipoDeEstimulo tipoDeEstimulo;

			// Token: 0x040000B7 RID: 183
			public bool esUnaVez;

			// Token: 0x040000B8 RID: 184
			public bool tieneCopiaInvertida;

			// Token: 0x040000B9 RID: 185
			public bool esCopiaInvertida;
		}

		// Token: 0x0200002D RID: 45
		[Serializable]
		private struct DataReferences
		{
			// Token: 0x040000BA RID: 186
			public MonoBehaviour estimulado;

			// Token: 0x040000BB RID: 187
			public Component estimulante;

			// Token: 0x040000BC RID: 188
			public Transform transformEstimulado;

			// Token: 0x040000BD RID: 189
			public Transform transformEstimuladoSegundario;

			// Token: 0x040000BE RID: 190
			public Transform transformEstimulante;

			// Token: 0x040000BF RID: 191
			public Transform transformEstimulanteSegundario;

			// Token: 0x040000C0 RID: 192
			public IParteDelCuerpoHumanoPrioridades estimuladoPrioridades;
		}
	}
}
