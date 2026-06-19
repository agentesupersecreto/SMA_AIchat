using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi
{
	// Token: 0x02000009 RID: 9
	[Serializable]
	public class PersonalidadDinamica : PersonalidadDinamicaValores
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002EFE File Offset: 0x000010FE
		public float Pragmatismo
		{
			get
			{
				return this.GetModNegativo(this.m_abstraccion, PersonalidadRasgoCompleto.pragmatismo);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00002F0D File Offset: 0x0000110D
		public float Imaginacion
		{
			get
			{
				return this.GetModPositivo(this.m_abstraccion, PersonalidadRasgoCompleto.Imaginacion);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x00002F1C File Offset: 0x0000111C
		public float Seguro
		{
			get
			{
				return this.GetModNegativo(this.m_preocupacion, PersonalidadRasgoCompleto.seguro);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000028 RID: 40 RVA: 0x00002F2B File Offset: 0x0000112B
		public float Preocupacion
		{
			get
			{
				return this.GetModPositivo(this.m_preocupacion, PersonalidadRasgoCompleto.Preocupacion);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00002F3A File Offset: 0x0000113A
		public float Sumiso
		{
			get
			{
				return this.GetModNegativo(this.m_dominancia, PersonalidadRasgoCompleto.sumiso);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600002A RID: 42 RVA: 0x00002F49 File Offset: 0x00001149
		public float Dominante
		{
			get
			{
				return this.GetModPositivo(this.m_dominancia, PersonalidadRasgoCompleto.Dominante);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002F58 File Offset: 0x00001158
		public float Inestable
		{
			get
			{
				return this.GetModNegativo(this.m_estabilidadEmocional, PersonalidadRasgoCompleto.inestable);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002F67 File Offset: 0x00001167
		public float Calmado
		{
			get
			{
				return this.GetModPositivo(this.m_estabilidadEmocional, PersonalidadRasgoCompleto.Calmado);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00002F76 File Offset: 0x00001176
		public float Contenido
		{
			get
			{
				return this.GetModNegativo(this.m_vivacidad, PersonalidadRasgoCompleto.contenido);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002F86 File Offset: 0x00001186
		public float Espontaneo
		{
			get
			{
				return this.GetModPositivo(this.m_vivacidad, PersonalidadRasgoCompleto.Espontaneo);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00002F96 File Offset: 0x00001196
		public float ApegadoALoFamiliar
		{
			get
			{
				return this.GetModNegativo(this.m_aperturaAlCambio, PersonalidadRasgoCompleto.apegadoALoFamiliar);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002FA6 File Offset: 0x000011A6
		public float Flexible
		{
			get
			{
				return this.GetModPositivo(this.m_aperturaAlCambio, PersonalidadRasgoCompleto.Flexible);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00002FB6 File Offset: 0x000011B6
		public float Indisciplinado
		{
			get
			{
				return this.GetModNegativo(this.m_perfectionismo, PersonalidadRasgoCompleto.indisciplinado);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002FC6 File Offset: 0x000011C6
		public float Controlado
		{
			get
			{
				return this.GetModPositivo(this.m_perfectionismo, PersonalidadRasgoCompleto.Controlado);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002FD6 File Offset: 0x000011D6
		public float Abierto
		{
			get
			{
				return this.GetModNegativo(this.m_privacidad, PersonalidadRasgoCompleto.abierto);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002FE6 File Offset: 0x000011E6
		public float Discreto
		{
			get
			{
				return this.GetModPositivo(this.m_privacidad, PersonalidadRasgoCompleto.Discreto);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00002FF6 File Offset: 0x000011F6
		public float Concreto
		{
			get
			{
				return this.GetModNegativo(this.m_razonamiento, PersonalidadRasgoCompleto.concreto);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00003006 File Offset: 0x00001206
		public float Abstracto
		{
			get
			{
				return this.GetModPositivo(this.m_razonamiento, PersonalidadRasgoCompleto.Abstracto);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00003016 File Offset: 0x00001216
		public float NoConforme
		{
			get
			{
				return this.GetModNegativo(this.m_concienciaNormativa, PersonalidadRasgoCompleto.noConforme);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00003026 File Offset: 0x00001226
		public float ConformeALasNormas
		{
			get
			{
				return this.GetModPositivo(this.m_concienciaNormativa, PersonalidadRasgoCompleto.ConformeALasNormas);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00003036 File Offset: 0x00001236
		public float Dependencia
		{
			get
			{
				return this.GetModNegativo(this.m_confianzaEnUnoMismo, PersonalidadRasgoCompleto.dependencia);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600003A RID: 58 RVA: 0x00003046 File Offset: 0x00001246
		public float Autosuficiencia
		{
			get
			{
				return this.GetModPositivo(this.m_confianzaEnUnoMismo, PersonalidadRasgoCompleto.Autosuficiencia);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00003056 File Offset: 0x00001256
		public float Dureza
		{
			get
			{
				return this.GetModNegativo(this.m_sensibilidad, PersonalidadRasgoCompleto.dureza);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00003066 File Offset: 0x00001266
		public float Calidez
		{
			get
			{
				return this.GetModPositivo(this.m_sensibilidad, PersonalidadRasgoCompleto.Calidez);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00003076 File Offset: 0x00001276
		public float Timido
		{
			get
			{
				return this.GetModNegativo(this.m_atrevimientoSocial, PersonalidadRasgoCompleto.timido);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600003E RID: 62 RVA: 0x00003086 File Offset: 0x00001286
		public float Desinhibido
		{
			get
			{
				return this.GetModPositivo(this.m_atrevimientoSocial, PersonalidadRasgoCompleto.Desinhibido);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00003096 File Offset: 0x00001296
		public float Relajado
		{
			get
			{
				return this.GetModNegativo(this.m_tension, PersonalidadRasgoCompleto.relajado);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000040 RID: 64 RVA: 0x000030A6 File Offset: 0x000012A6
		public float Impaciente
		{
			get
			{
				return this.GetModPositivo(this.m_tension, PersonalidadRasgoCompleto.Impaciente);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000041 RID: 65 RVA: 0x000030B6 File Offset: 0x000012B6
		public float Confiado
		{
			get
			{
				return this.GetModNegativo(this.m_vigilancia, PersonalidadRasgoCompleto.confiado);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000042 RID: 66 RVA: 0x000030C6 File Offset: 0x000012C6
		public float Desconfiado
		{
			get
			{
				return this.GetModPositivo(this.m_vigilancia, PersonalidadRasgoCompleto.Desconfiado);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000043 RID: 67 RVA: 0x000030D6 File Offset: 0x000012D6
		public float Reservado
		{
			get
			{
				return this.GetModNegativo(this.m_calidez, PersonalidadRasgoCompleto.reservado);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000044 RID: 68 RVA: 0x000030E6 File Offset: 0x000012E6
		public float Extrovertido
		{
			get
			{
				return this.GetModPositivo(this.m_calidez, PersonalidadRasgoCompleto.Extrovertido);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000030F6 File Offset: 0x000012F6
		public float Sensible
		{
			get
			{
				return this.GetModNegativo(this.m_resilianza, PersonalidadRasgoCompleto.sensible);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003106 File Offset: 0x00001306
		public float Resistente
		{
			get
			{
				return this.GetModPositivo(this.m_resilianza, PersonalidadRasgoCompleto.Resistente);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00003116 File Offset: 0x00001316
		public int Count
		{
			get
			{
				if (PersonalidadDinamica.count == null)
				{
					PersonalidadDinamica.count = new int?(typeof(PersonalidadRasgo).GetEnumCount() - 1);
				}
				return PersonalidadDinamica.count.Value;
			}
		}

		// Token: 0x17000029 RID: 41
		public PersonalidadDinamica.Par this[int i]
		{
			get
			{
				PersonalidadDinamica.Par par;
				try
				{
					this.CheckParesInit();
					par = this.m_pares[i];
				}
				catch (Exception)
				{
					throw;
				}
				return par;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003180 File Offset: 0x00001380
		private void CheckModificablesInit()
		{
			if (this.m_Modificables != null)
			{
				return;
			}
			this.m_Modificables = new DiccionaryEnum<PersonalidadRasgoCompleto, Modificable>((PersonalidadRasgoCompleto x) => (int)x);
			this.m_ModificablesDEBUG = new List<Modificable>();
			foreach (object obj in typeof(PersonalidadRasgoCompleto).GetEnumValoresLimpiosObject())
			{
				PersonalidadRasgoCompleto personalidadRasgoCompleto = (PersonalidadRasgoCompleto)obj;
				Modificable modificable = new Modificable(personalidadRasgoCompleto);
				this.m_Modificables.Add(personalidadRasgoCompleto, modificable);
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003230 File Offset: 0x00001430
		private void CheckParesInit()
		{
			if (this.m_pares != null)
			{
				return;
			}
			this.m_pares = new List<PersonalidadDinamica.Par>(this.Count)
			{
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.abstraccion),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.preocupacion),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.dominancia),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.estabilidadEmocional),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.vivacidad),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.aperturaAlCambio),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.perfectionismo),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.privacidad),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.razonamiento),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.concienciaNormativa),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.confianzaEnUnoMismo),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.sensibilidad),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.atrevimientoSocial),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.tension),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.vigilancia),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.calidez),
				new PersonalidadDinamica.Par(this, PersonalidadRasgo.resilianza)
			}.ToArray();
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003366 File Offset: 0x00001566
		private void Set(ref float reff, float value)
		{
			reff = Mathf.Clamp(value, 0f, 100f);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000337A File Offset: 0x0000157A
		private float Get(float value)
		{
			return Mathf.Clamp(value, 0f, 100f);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000338C File Offset: 0x0000158C
		private float GetModPositivo(float value)
		{
			if (value <= 50f)
			{
				return 0f;
			}
			return Mathf.InverseLerp(50f, 100f, value);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000033AC File Offset: 0x000015AC
		private float GetModNegativo(float value)
		{
			if (value >= 50f)
			{
				return 0f;
			}
			return Mathf.InverseLerp(50f, 0f, value);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000033CC File Offset: 0x000015CC
		private float GetPorcentagePositivo(float value)
		{
			if (value <= 50f)
			{
				return 0f;
			}
			return this.GetModPositivo(value) * 100f;
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000033E9 File Offset: 0x000015E9
		private float GetPorcentageNegativo(float value)
		{
			if (value >= 50f)
			{
				return 0f;
			}
			return this.GetModNegativo(value) * 100f;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003406 File Offset: 0x00001606
		public float GetInvert(PersonalidadRasgo rasgo)
		{
			return 100f - this.Get(rasgo);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003418 File Offset: 0x00001618
		public float Get(PersonalidadRasgo rasgo)
		{
			if (rasgo <= PersonalidadRasgo.razonamiento)
			{
				if (rasgo <= PersonalidadRasgo.vivacidad)
				{
					switch (rasgo)
					{
					case PersonalidadRasgo.abstraccion:
						return this.Get(this.m_abstraccion);
					case PersonalidadRasgo.preocupacion:
						return this.Get(this.m_preocupacion);
					case PersonalidadRasgo.abstraccion | PersonalidadRasgo.preocupacion:
						break;
					case PersonalidadRasgo.dominancia:
						return this.Get(this.m_dominancia);
					default:
						if (rasgo == PersonalidadRasgo.estabilidadEmocional)
						{
							return this.Get(this.m_estabilidadEmocional);
						}
						if (rasgo == PersonalidadRasgo.vivacidad)
						{
							return this.Get(this.m_vivacidad);
						}
						break;
					}
				}
				else if (rasgo <= PersonalidadRasgo.perfectionismo)
				{
					if (rasgo == PersonalidadRasgo.aperturaAlCambio)
					{
						return this.Get(this.m_aperturaAlCambio);
					}
					if (rasgo == PersonalidadRasgo.perfectionismo)
					{
						return this.Get(this.m_perfectionismo);
					}
				}
				else
				{
					if (rasgo == PersonalidadRasgo.privacidad)
					{
						return this.Get(this.m_privacidad);
					}
					if (rasgo == PersonalidadRasgo.razonamiento)
					{
						return this.Get(this.m_razonamiento);
					}
				}
			}
			else if (rasgo <= PersonalidadRasgo.atrevimientoSocial)
			{
				if (rasgo <= PersonalidadRasgo.confianzaEnUnoMismo)
				{
					if (rasgo == PersonalidadRasgo.concienciaNormativa)
					{
						return this.Get(this.m_concienciaNormativa);
					}
					if (rasgo == PersonalidadRasgo.confianzaEnUnoMismo)
					{
						return this.Get(this.m_confianzaEnUnoMismo);
					}
				}
				else
				{
					if (rasgo == PersonalidadRasgo.sensibilidad)
					{
						return this.Get(this.m_sensibilidad);
					}
					if (rasgo == PersonalidadRasgo.atrevimientoSocial)
					{
						return this.Get(this.m_atrevimientoSocial);
					}
				}
			}
			else if (rasgo <= PersonalidadRasgo.vigilancia)
			{
				if (rasgo == PersonalidadRasgo.tension)
				{
					return this.Get(this.m_tension);
				}
				if (rasgo == PersonalidadRasgo.vigilancia)
				{
					return this.Get(this.m_vigilancia);
				}
			}
			else
			{
				if (rasgo == PersonalidadRasgo.calidez)
				{
					return this.Get(this.m_calidez);
				}
				if (rasgo == PersonalidadRasgo.resilianza)
				{
					return this.Get(this.m_resilianza);
				}
			}
			throw new ArgumentOutOfRangeException(rasgo.ToString());
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00003608 File Offset: 0x00001808
		public void Set(PersonalidadRasgo rasgo, float valor)
		{
			valor = Mathf.Clamp(valor, 0f, 100f);
			if (rasgo <= PersonalidadRasgo.razonamiento)
			{
				if (rasgo <= PersonalidadRasgo.vivacidad)
				{
					switch (rasgo)
					{
					case PersonalidadRasgo.abstraccion:
						this.m_abstraccion = valor;
						return;
					case PersonalidadRasgo.preocupacion:
						this.m_preocupacion = valor;
						return;
					case PersonalidadRasgo.abstraccion | PersonalidadRasgo.preocupacion:
						break;
					case PersonalidadRasgo.dominancia:
						this.m_dominancia = valor;
						return;
					default:
						if (rasgo == PersonalidadRasgo.estabilidadEmocional)
						{
							this.m_estabilidadEmocional = valor;
							return;
						}
						if (rasgo == PersonalidadRasgo.vivacidad)
						{
							this.m_vivacidad = valor;
							return;
						}
						break;
					}
				}
				else if (rasgo <= PersonalidadRasgo.perfectionismo)
				{
					if (rasgo == PersonalidadRasgo.aperturaAlCambio)
					{
						this.m_aperturaAlCambio = valor;
						return;
					}
					if (rasgo == PersonalidadRasgo.perfectionismo)
					{
						this.m_perfectionismo = valor;
						return;
					}
				}
				else
				{
					if (rasgo == PersonalidadRasgo.privacidad)
					{
						this.m_privacidad = valor;
						return;
					}
					if (rasgo == PersonalidadRasgo.razonamiento)
					{
						this.m_razonamiento = valor;
						return;
					}
				}
			}
			else if (rasgo <= PersonalidadRasgo.atrevimientoSocial)
			{
				if (rasgo <= PersonalidadRasgo.confianzaEnUnoMismo)
				{
					if (rasgo == PersonalidadRasgo.concienciaNormativa)
					{
						this.m_concienciaNormativa = valor;
						return;
					}
					if (rasgo == PersonalidadRasgo.confianzaEnUnoMismo)
					{
						this.m_confianzaEnUnoMismo = valor;
						return;
					}
				}
				else
				{
					if (rasgo == PersonalidadRasgo.sensibilidad)
					{
						this.m_sensibilidad = valor;
						return;
					}
					if (rasgo == PersonalidadRasgo.atrevimientoSocial)
					{
						this.m_atrevimientoSocial = valor;
						return;
					}
				}
			}
			else if (rasgo <= PersonalidadRasgo.vigilancia)
			{
				if (rasgo == PersonalidadRasgo.tension)
				{
					this.m_tension = valor;
					return;
				}
				if (rasgo == PersonalidadRasgo.vigilancia)
				{
					this.m_vigilancia = valor;
					return;
				}
			}
			else
			{
				if (rasgo == PersonalidadRasgo.calidez)
				{
					this.m_calidez = valor;
					return;
				}
				if (rasgo == PersonalidadRasgo.resilianza)
				{
					this.m_resilianza = valor;
					return;
				}
			}
			throw new ArgumentOutOfRangeException(rasgo.ToString());
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000037B3 File Offset: 0x000019B3
		public Modificable GetMod(PersonalidadRasgoCompleto rasgo)
		{
			this.CheckModificablesInit();
			return this.m_Modificables[rasgo];
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000037C8 File Offset: 0x000019C8
		private float GetModPositivo(float value, PersonalidadRasgoCompleto rasgo)
		{
			Modificable mod = this.GetMod(rasgo);
			float num = this.GetPorcentagePositivo(value);
			num = mod.Sumar(num);
			return mod.Multiplicar(num / 100f);
		}

		// Token: 0x06000056 RID: 86 RVA: 0x000037F8 File Offset: 0x000019F8
		private float GetModNegativo(float value, PersonalidadRasgoCompleto rasgo)
		{
			Modificable mod = this.GetMod(rasgo);
			float num = this.GetPorcentageNegativo(value);
			num = mod.Sumar(num);
			return mod.Multiplicar(num / 100f);
		}

		// Token: 0x04000017 RID: 23
		[NonSerialized]
		private static int? count;

		// Token: 0x04000018 RID: 24
		[NonSerialized]
		private PersonalidadDinamica.Par[] m_pares;

		// Token: 0x04000019 RID: 25
		[NonSerialized]
		private DiccionaryEnum<PersonalidadRasgoCompleto, Modificable> m_Modificables;

		// Token: 0x0400001A RID: 26
		[SerializeField]
		private List<Modificable> m_ModificablesDEBUG;

		// Token: 0x0200000A RID: 10
		[Serializable]
		public class Par
		{
			// Token: 0x06000058 RID: 88 RVA: 0x00003830 File Offset: 0x00001A30
			public Par(PersonalidadDinamica personalidad, PersonalidadRasgo rasgo)
			{
				this.m_rasgo = rasgo;
				this.m_personalidad = personalidad;
			}

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000059 RID: 89 RVA: 0x00003846 File Offset: 0x00001A46
			public PersonalidadRasgo rasgo
			{
				get
				{
					return this.m_rasgo;
				}
			}

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x0600005A RID: 90 RVA: 0x0000384E File Offset: 0x00001A4E
			public float puntage
			{
				get
				{
					return this.m_personalidad.Get(this.m_rasgo);
				}
			}

			// Token: 0x0400001B RID: 27
			[SerializeField]
			[ReadOnlyUI]
			private PersonalidadRasgo m_rasgo;

			// Token: 0x0400001C RID: 28
			private PersonalidadDinamica m_personalidad;
		}
	}
}
