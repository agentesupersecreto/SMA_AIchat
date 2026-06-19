using System;
using System.Collections.Generic;
using System.Linq;
using Assets.TValle.IU.Runtime.Interacciones.Donas;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.UI.Drawing.Elementos.Abstracts;
using Assets._ReusableScripts.UI.Interacciones.Donas;
using Assets._ReusableScripts.UI.Interacciones.Donas.Abstracts;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.DialogueSystem.Estimulaciones.UI
{
	// Token: 0x02000058 RID: 88
	[Obsolete("usar la version para THS")]
	public abstract class OpcionesDeDonaDeCanITodosDisponibles : GenericOpcionesDeDonaDeKeys<int, OpcionesDeDonaDeCanITodosDisponibles.CurrentToggled>, IOpcionesDeDonaAcceptProductor
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600028F RID: 655
		public abstract int TipoID { get; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000290 RID: 656 RVA: 0x0000D1DC File Offset: 0x0000B3DC
		public Personalidad personalidad
		{
			get
			{
				return this.m_personalidad;
			}
		}

		// Token: 0x06000291 RID: 657 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_personalidad = this.GetComponentEnRoot(false);
			if (this.m_personalidad == null)
			{
				throw new ArgumentNullException("m_personalidad", "m_personalidad null reference.");
			}
		}

		// Token: 0x06000292 RID: 658 RVA: 0x0000D218 File Offset: 0x0000B418
		protected override void LoadKeys(HashSetList<int> resultado)
		{
			foreach (KeyValuePair<int, string> keyValuePair in OpcionesDeDonaDeCanITodosDisponibles.opciones)
			{
				resultado.Add(keyValuePair.Key);
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0000D274 File Offset: 0x0000B474
		public override string TextDeKey(int key)
		{
			string text;
			try
			{
				text = OpcionesDeDonaDeCanITodosDisponibles.opciones[key];
			}
			catch (Exception ex)
			{
				Debug.LogException(ex, this);
				text = key.ToString();
			}
			return text;
		}

		// Token: 0x06000294 RID: 660 RVA: 0x0000D2B0 File Offset: 0x0000B4B0
		public DonaDeInteraccionBase.Item ObtenerItem(LoaderOpcionesDeDonaBase caller)
		{
			return new DonaDeInteraccionBase.Item
			{
				text = "Ask her",
				grayOut = false,
				hidden = false,
				clickedCallback = null,
				clickedCallbackCompleto = new UnityAction<IUIElementoConValor, DonaDeInteraccionBase>(this.OnAcceptarClicked),
				modelo = "Aceptar Botton",
				modeloInstanceType = typeof(bool)
			};
		}

		// Token: 0x06000295 RID: 661
		protected abstract void OnAcceptarClicked(IUIElementoConValor boton, DonaDeInteraccionBase dona);

		// Token: 0x06000297 RID: 663 RVA: 0x0000D318 File Offset: 0x0000B518
		// Note: this type is marked as 'beforefieldinit'.
		static OpcionesDeDonaDeCanITodosDisponibles()
		{
			Dictionary<int, ParteDelCuerpoHumano[]> dictionary = new Dictionary<int, ParteDelCuerpoHumano[]>();
			dictionary.Add(0, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.cabeza });
			dictionary.Add(1, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.mejillas,
				ParteDelCuerpoHumano.cienes,
				ParteDelCuerpoHumano.mandibula,
				ParteDelCuerpoHumano.frente,
				ParteDelCuerpoHumano.nariz,
				ParteDelCuerpoHumano.cejas,
				ParteDelCuerpoHumano.orejas
			});
			dictionary.Add(2, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.bocaInterno,
				ParteDelCuerpoHumano.labios,
				ParteDelCuerpoHumano.lengua
			});
			dictionary.Add(3, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.hombros });
			dictionary.Add(4, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.axilas });
			dictionary.Add(5, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.brazos });
			dictionary.Add(6, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.anteBrazos });
			dictionary.Add(7, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.manos });
			dictionary.Add(8, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.espalda });
			dictionary.Add(9, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.cintura });
			dictionary.Add(10, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.cuello });
			dictionary.Add(11, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.caderas });
			dictionary.Add(12, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.vientre,
				ParteDelCuerpoHumano.abdomen,
				ParteDelCuerpoHumano.hombligo
			});
			dictionary.Add(13, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.piernas });
			dictionary.Add(14, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.rodillas });
			dictionary.Add(15, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.canillas });
			dictionary.Add(16, new ParteDelCuerpoHumano[] { ParteDelCuerpoHumano.pies });
			Dictionary<int, ParteDelCuerpoHumano[]> dictionary2 = dictionary;
			int num = 17;
			ParteDelCuerpoHumano[] array = new ParteDelCuerpoHumano[3];
			array[0] = ParteDelCuerpoHumano.senos;
			array[1] = ParteDelCuerpoHumano.pezones;
			dictionary2.Add(num, array);
			dictionary.Add(18, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.nalgas,
				ParteDelCuerpoHumano.coxis
			});
			dictionary.Add(19, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.ano,
				ParteDelCuerpoHumano.perineo
			});
			dictionary.Add(20, new ParteDelCuerpoHumano[]
			{
				ParteDelCuerpoHumano.vag,
				ParteDelCuerpoHumano.vientreBajo,
				ParteDelCuerpoHumano.clitoris,
				ParteDelCuerpoHumano.labiosVaginales
			});
			OpcionesDeDonaDeCanITodosDisponibles.allSelected = dictionary;
		}

		// Token: 0x0400010D RID: 269
		private static readonly Dictionary<int, string> opcionesDELETE = new Dictionary<int, string>
		{
			{ 1, "Face" },
			{ 2, "Mouth" },
			{ 3, "Shoulders" },
			{ 5, "Arms" },
			{ 7, "Hands" },
			{ 8, "Back" },
			{ 9, "Waist" },
			{ 10, "Neck" },
			{ 11, "Hips" },
			{ 13, "Thighs" },
			{ 15, "Calves" },
			{ 16, "Feet" },
			{ 17, "Tits" },
			{ 18, "Ass" },
			{ 19, "Asshole" },
			{ 20, "Pussy" }
		};

		// Token: 0x0400010E RID: 270
		public static readonly Dictionary<int, string> opciones = new Dictionary<int, string>
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

		// Token: 0x0400010F RID: 271
		public static readonly Dictionary<int, ParteDelCuerpoHumano> mainSelected = new Dictionary<int, ParteDelCuerpoHumano>
		{
			{
				0,
				ParteDelCuerpoHumano.cabeza
			},
			{
				1,
				ParteDelCuerpoHumano.mejillas
			},
			{
				2,
				ParteDelCuerpoHumano.bocaInterno
			},
			{
				3,
				ParteDelCuerpoHumano.hombros
			},
			{
				4,
				ParteDelCuerpoHumano.axilas
			},
			{
				5,
				ParteDelCuerpoHumano.brazos
			},
			{
				6,
				ParteDelCuerpoHumano.anteBrazos
			},
			{
				7,
				ParteDelCuerpoHumano.manos
			},
			{
				8,
				ParteDelCuerpoHumano.espalda
			},
			{
				9,
				ParteDelCuerpoHumano.cintura
			},
			{
				10,
				ParteDelCuerpoHumano.cuello
			},
			{
				11,
				ParteDelCuerpoHumano.caderas
			},
			{
				12,
				ParteDelCuerpoHumano.vientre
			},
			{
				13,
				ParteDelCuerpoHumano.piernas
			},
			{
				14,
				ParteDelCuerpoHumano.rodillas
			},
			{
				15,
				ParteDelCuerpoHumano.canillas
			},
			{
				16,
				ParteDelCuerpoHumano.pies
			},
			{
				17,
				ParteDelCuerpoHumano.senos
			},
			{
				18,
				ParteDelCuerpoHumano.nalgas
			},
			{
				19,
				ParteDelCuerpoHumano.ano
			},
			{
				20,
				ParteDelCuerpoHumano.vag
			}
		};

		// Token: 0x04000110 RID: 272
		public static readonly Dictionary<ParteDelCuerpoHumano, int> mainSelectedInvert = OpcionesDeDonaDeCanITodosDisponibles.mainSelected.ToDictionary((KeyValuePair<int, ParteDelCuerpoHumano> p) => p.Value, (KeyValuePair<int, ParteDelCuerpoHumano> p) => p.Key);

		// Token: 0x04000111 RID: 273
		public static readonly Dictionary<int, ParteDelCuerpoHumano[]> allSelected;

		// Token: 0x04000112 RID: 274
		private Personalidad m_personalidad;

		// Token: 0x02000090 RID: 144
		[Serializable]
		public class CurrentToggled : OpcionesDeDonaCurrentClickedKey<int>
		{
			// Token: 0x040001B0 RID: 432
			public bool puede;

			// Token: 0x040001B1 RID: 433
			public bool selected;
		}
	}
}
