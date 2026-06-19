using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.IU.Runtime.Interacciones.THS.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x0200005B RID: 91
	public abstract class OpcionesDeTHSDonaDeCanIDisponibles : GenericOpcionesDeTHSDonaDeKeys<int>
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060002AA RID: 682
		public abstract int TipoID { get; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060002AB RID: 683 RVA: 0x0000DC40 File Offset: 0x0000BE40
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x0000DC48 File Offset: 0x0000BE48
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000DC7C File Offset: 0x0000BE7C
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			foreach (KeyValuePair<int, string> keyValuePair in OpcionesDeTHSDonaDeCanIDisponibles.opciones)
			{
				resultado.Add(keyValuePair.Key);
			}
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		protected override string KeyDeIndex(int index)
		{
			return OpcionesDeTHSDonaDeCanIDisponibles.opciones[index];
		}

		// Token: 0x060002AF RID: 687 RVA: 0x0000DCE5 File Offset: 0x0000BEE5
		protected override int KeyDeItemKey(string key, int index)
		{
			return index;
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x0000DCE8 File Offset: 0x0000BEE8
		protected override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = OpcionesDeTHSDonaDeCanIDisponibles.opciones[key];
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x0000DD2C File Offset: 0x0000BF2C
		// Note: this type is marked as 'beforefieldinit'.
		static OpcionesDeTHSDonaDeCanIDisponibles()
		{
			Dictionary<int, ParteDelCuerpoHumano[]> dictionary = new Dictionary<int, ParteDelCuerpoHumano[]>();
			dictionary.Add(0, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.mejillas,
				ParteDelCuerpoHumano.cabeza,
				ParteDelCuerpoHumano.cienes,
				ParteDelCuerpoHumano.mandibula,
				ParteDelCuerpoHumano.frente,
				ParteDelCuerpoHumano.nariz,
				ParteDelCuerpoHumano.cejas,
				ParteDelCuerpoHumano.orejas
			});
			dictionary.Add(1, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.bocaInterno,
				ParteDelCuerpoHumano.labios,
				ParteDelCuerpoHumano.lengua
			});
			dictionary.Add(2, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.hombros });
			dictionary.Add(3, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.brazos,
				ParteDelCuerpoHumano.anteBrazos
			});
			dictionary.Add(4, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.manos });
			dictionary.Add(5, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.espalda });
			dictionary.Add(6, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.cintura,
				ParteDelCuerpoHumano.vientre,
				ParteDelCuerpoHumano.abdomen,
				ParteDelCuerpoHumano.hombligo
			});
			dictionary.Add(7, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.cuello });
			dictionary.Add(8, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.caderas });
			dictionary.Add(9, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.piernas });
			dictionary.Add(10, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.canillas,
				ParteDelCuerpoHumano.rodillas
			});
			dictionary.Add(11, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.pies });
			Dictionary<int, ParteDelCuerpoHumano[]> dictionary2 = dictionary;
			int num = 12;
			ParteDelCuerpoHumano[] array = new ParteDelCuerpoHumano[3];
			array[0] = ParteDelCuerpoHumano.senos;
			array[1] = ParteDelCuerpoHumano.pezones;
			dictionary2.Add(num, array);
			dictionary.Add(13, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.nalgas,
				ParteDelCuerpoHumano.coxis
			});
			dictionary.Add(14, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.ano,
				ParteDelCuerpoHumano.perineo
			});
			dictionary.Add(15, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.vag,
				ParteDelCuerpoHumano.vientreBajo,
				ParteDelCuerpoHumano.clitoris,
				ParteDelCuerpoHumano.labiosVaginales
			});
			OpcionesDeTHSDonaDeCanIDisponibles.allSelected = dictionary;
		}

		// Token: 0x0400011B RID: 283
		public static readonly Dictionary<int, string> opcionesOLD = new Dictionary<int, string>
		{
			{ 0, "Head" },
			{ 1, "Face" },
			{ 2, "Mouth" },
			{ 3, "Shoulders" },
			{ 4, "Armpits" },
			{ 5, "Arms" },
			{ 6, "Forearms" },
			{ 7, "Hands" },
			{ 8, "Back" },
			{ 9, "Waist" },
			{ 10, "Neck" },
			{ 11, "Hips" },
			{ 12, "Belly" },
			{ 13, "Thighs" },
			{ 14, "Knees" },
			{ 15, "Calves" },
			{ 16, "Feet" },
			{ 17, "Tits" },
			{ 18, "Ass" },
			{ 19, "Asshole" },
			{ 20, "Pussy" }
		};

		// Token: 0x0400011C RID: 284
		public static readonly Dictionary<int, string> opciones = new Dictionary<int, string>
		{
			{ 0, "Face" },
			{ 1, "Mouth" },
			{ 2, "Shoulders" },
			{ 3, "Arms" },
			{ 4, "Hands" },
			{ 5, "Back" },
			{ 6, "Waist" },
			{ 7, "Neck" },
			{ 8, "Hips" },
			{ 9, "Thighs" },
			{ 10, "Calves" },
			{ 11, "Feet" },
			{ 12, "Tits" },
			{ 13, "Ass" },
			{ 14, "Asshole" },
			{ 15, "Pussy" }
		};

		// Token: 0x0400011D RID: 285
		public static readonly Dictionary<int, ParteDelCuerpoHumano> mainSelected = new Dictionary<int, ParteDelCuerpoHumano>
		{
			{
				0,
				ParteDelCuerpoHumano.mejillas
			},
			{
				1,
				ParteDelCuerpoHumano.bocaInterno
			},
			{
				2,
				ParteDelCuerpoHumano.hombros
			},
			{
				3,
				ParteDelCuerpoHumano.brazos
			},
			{
				4,
				ParteDelCuerpoHumano.manos
			},
			{
				5,
				ParteDelCuerpoHumano.espalda
			},
			{
				6,
				ParteDelCuerpoHumano.cintura
			},
			{
				7,
				ParteDelCuerpoHumano.cuello
			},
			{
				8,
				ParteDelCuerpoHumano.caderas
			},
			{
				9,
				ParteDelCuerpoHumano.piernas
			},
			{
				10,
				ParteDelCuerpoHumano.canillas
			},
			{
				11,
				ParteDelCuerpoHumano.pies
			},
			{
				12,
				ParteDelCuerpoHumano.senos
			},
			{
				13,
				ParteDelCuerpoHumano.nalgas
			},
			{
				14,
				ParteDelCuerpoHumano.ano
			},
			{
				15,
				ParteDelCuerpoHumano.vag
			}
		};

		// Token: 0x0400011E RID: 286
		public static readonly Dictionary<ParteDelCuerpoHumano, int> mainSelectedInvert = OpcionesDeTHSDonaDeCanIDisponibles.mainSelected.ToDictionary((KeyValuePair<int, ParteDelCuerpoHumano> p) => p.Value, (KeyValuePair<int, ParteDelCuerpoHumano> p) => p.Key);

		// Token: 0x0400011F RID: 287
		public static readonly Dictionary<int, ParteDelCuerpoHumano[]> allSelected;

		// Token: 0x04000120 RID: 288
		private Personalidad m_personalidad;
	}
}
