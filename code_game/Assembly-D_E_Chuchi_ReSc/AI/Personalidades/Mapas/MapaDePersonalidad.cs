using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI.Personalidades.Mapas
{
	// Token: 0x020003D8 RID: 984
	[CreateAssetMenu(fileName = "MapaDePersonalidad", menuName = "Objetos/AI/MapaDePersonalidad")]
	public sealed class MapaDePersonalidad : AplicableScriptable, ICloneable
	{
		// Token: 0x06001566 RID: 5478 RVA: 0x0005ABA1 File Offset: 0x00058DA1
		public object Clone()
		{
			return this.Clonar(true, false, false);
		}

		// Token: 0x06001567 RID: 5479 RVA: 0x0005ABAC File Offset: 0x00058DAC
		protected override CustomMonobehaviourBotonConfig Boton1()
		{
			return new CustomMonobehaviourBotonConfig
			{
				playTimeVisible = false,
				text = "FixTraits"
			};
		}

		// Token: 0x06001568 RID: 5480 RVA: 0x0005ABC5 File Offset: 0x00058DC5
		public float CurrentMaxConsentPorInteraciones()
		{
			return this.modificableDeConsentPorSessiones.ModificarValor(this.consentPorSessiones.maxConsentPorSessionesV2);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x0005ABE0 File Offset: 0x00058DE0
		private void LoadListaDeTrait()
		{
			IReadOnlyList<int> enumValoresInt = typeof(TraitHumano).GetEnumValoresInt();
			for (int i = this.traits.Count - 1; i >= 0; i--)
			{
				Personalidad.Trait trait = this.traits[i];
				if (trait == null)
				{
					this.traits.RemoveAt(i);
				}
				else
				{
					int trait2 = (int)trait.trait;
					if (!enumValoresInt.Contains(trait2))
					{
						this.traits.RemoveAt(i);
					}
				}
			}
			this.traits.Distinct(new MapaDePersonalidad.ItemEqualityComparer());
			for (int j = 0; j < enumValoresInt.Count; j++)
			{
				int tEnum = enumValoresInt[j];
				if (this.traits.FirstOrDefault((Personalidad.Trait t) => t.trait == (TraitHumano)tEnum) == null)
				{
					this.traits.Add(new Personalidad.Trait
					{
						trait = (TraitHumano)tEnum,
						score = HumanTraitScore.normal
					});
				}
			}
		}

		// Token: 0x04001137 RID: 4407
		public PersonalidadDinamica rasgos = new PersonalidadDinamica();

		// Token: 0x04001138 RID: 4408
		public List<Personalidad.Trait> traits = new List<Personalidad.Trait>();

		// Token: 0x04001139 RID: 4409
		public Vector2 facialDirection;

		// Token: 0x0400113A RID: 4410
		public Vector2 bocalDirection;

		// Token: 0x0400113B RID: 4411
		public MapaDePersonalidad.GustosFloat maxConsentPorGustos = new MapaDePersonalidad.GustosFloat
		{
			musculos = 20f,
			slender = 20f,
			madurez = 10f,
			bodyFat = 10f,
			juventud = 15f,
			altura = 20f,
			lujos = 60f,
			paquete = 10f
		};

		// Token: 0x0400113C RID: 4412
		public MapaDePersonalidad.ConsentPorSessiones consentPorSessiones = new MapaDePersonalidad.ConsentPorSessiones();

		// Token: 0x0400113D RID: 4413
		public ModificableDeFloat modificableDeConsentPorSessiones = new ModificableDeFloat(1f);

		// Token: 0x020003D9 RID: 985
		[Serializable]
		public class ConsentPorSessiones
		{
			// Token: 0x17000522 RID: 1314
			// (get) Token: 0x0600156B RID: 5483 RVA: 0x0005AD73 File Offset: 0x00058F73
			// (set) Token: 0x0600156C RID: 5484 RVA: 0x0005AD81 File Offset: 0x00058F81
			public float maxConsentPorSessionesV2
			{
				get
				{
					return this.maxConsentPorSessiones / 2.64f;
				}
				set
				{
					this.maxConsentPorSessiones = value * 2.64f;
				}
			}

			// Token: 0x0400113E RID: 4414
			public const string maxConsentPorSessionesName = "maxConsentPorSessiones";

			// Token: 0x0400113F RID: 4415
			[Range(0f, 100f)]
			[SerializeField]
			protected float maxConsentPorSessiones = 66f;

			// Token: 0x04001140 RID: 4416
			public float visualMod = 0.333f;

			// Token: 0x04001141 RID: 4417
			public float tactilMod = 1f;

			// Token: 0x04001142 RID: 4418
			public float coitalMod = 1.5f;
		}

		// Token: 0x020003DA RID: 986
		[Serializable]
		public class GustosFloat : MapaDePersonalidad.GustosValores<float>
		{
			// Token: 0x17000523 RID: 1315
			// (get) Token: 0x0600156E RID: 5486 RVA: 0x0005ADC4 File Offset: 0x00058FC4
			// (set) Token: 0x0600156F RID: 5487 RVA: 0x0005ADD2 File Offset: 0x00058FD2
			public float musculosV2
			{
				get
				{
					return this.musculos / 1f;
				}
				set
				{
					this.musculos = value * 1f;
				}
			}

			// Token: 0x17000524 RID: 1316
			// (get) Token: 0x06001570 RID: 5488 RVA: 0x0005ADE1 File Offset: 0x00058FE1
			// (set) Token: 0x06001571 RID: 5489 RVA: 0x0005ADEF File Offset: 0x00058FEF
			public float slenderV2
			{
				get
				{
					return this.slender / 2f;
				}
				set
				{
					this.slender = value * 2f;
				}
			}

			// Token: 0x17000525 RID: 1317
			// (get) Token: 0x06001572 RID: 5490 RVA: 0x0005ADFE File Offset: 0x00058FFE
			// (set) Token: 0x06001573 RID: 5491 RVA: 0x0005AE0C File Offset: 0x0005900C
			public float madurezV2
			{
				get
				{
					return this.madurez / 2f;
				}
				set
				{
					this.madurez = value * 2f;
				}
			}

			// Token: 0x17000526 RID: 1318
			// (get) Token: 0x06001574 RID: 5492 RVA: 0x0005AE1B File Offset: 0x0005901B
			// (set) Token: 0x06001575 RID: 5493 RVA: 0x0005AE29 File Offset: 0x00059029
			public float bodyFatV2
			{
				get
				{
					return this.bodyFat / 2f;
				}
				set
				{
					this.bodyFat = value * 2f;
				}
			}

			// Token: 0x17000527 RID: 1319
			// (get) Token: 0x06001576 RID: 5494 RVA: 0x0005AE38 File Offset: 0x00059038
			// (set) Token: 0x06001577 RID: 5495 RVA: 0x0005AE46 File Offset: 0x00059046
			public float juventudV2
			{
				get
				{
					return this.juventud / 2f;
				}
				set
				{
					this.juventud = value * 2f;
				}
			}

			// Token: 0x17000528 RID: 1320
			// (get) Token: 0x06001578 RID: 5496 RVA: 0x0005AE55 File Offset: 0x00059055
			// (set) Token: 0x06001579 RID: 5497 RVA: 0x0005AE63 File Offset: 0x00059063
			public float alturaV2
			{
				get
				{
					return this.altura / 1f;
				}
				set
				{
					this.altura = value * 1f;
				}
			}

			// Token: 0x17000529 RID: 1321
			// (get) Token: 0x0600157A RID: 5498 RVA: 0x0005AE72 File Offset: 0x00059072
			// (set) Token: 0x0600157B RID: 5499 RVA: 0x0005AE80 File Offset: 0x00059080
			public float lujosV2
			{
				get
				{
					return this.lujos / 2f;
				}
				set
				{
					this.lujos = value * 2f;
				}
			}

			// Token: 0x1700052A RID: 1322
			// (get) Token: 0x0600157C RID: 5500 RVA: 0x0005AE8F File Offset: 0x0005908F
			// (set) Token: 0x0600157D RID: 5501 RVA: 0x0005AE9D File Offset: 0x0005909D
			public float paqueteV2
			{
				get
				{
					return this.paquete / 1f;
				}
				set
				{
					this.paquete = value * 1f;
				}
			}

			// Token: 0x0600157E RID: 5502 RVA: 0x0005AEAC File Offset: 0x000590AC
			public float AggregateAllV2()
			{
				return this.musculosV2 + this.slenderV2 + this.madurezV2 + this.bodyFatV2 + this.juventudV2 + this.alturaV2 + this.lujosV2 + this.paqueteV2;
			}

			// Token: 0x0600157F RID: 5503 RVA: 0x0005AEE5 File Offset: 0x000590E5
			public override float AggregateAll()
			{
				return this.musculos + this.slender + this.madurez + this.bodyFat + this.juventud + this.altura + this.lujos + this.paquete;
			}
		}

		// Token: 0x020003DB RID: 987
		public abstract class GustosValores<T>
		{
			// Token: 0x06001581 RID: 5505
			public abstract T AggregateAll();

			// Token: 0x04001143 RID: 4419
			public T musculos;

			// Token: 0x04001144 RID: 4420
			public T slender;

			// Token: 0x04001145 RID: 4421
			public T madurez;

			// Token: 0x04001146 RID: 4422
			public T bodyFat;

			// Token: 0x04001147 RID: 4423
			public T juventud;

			// Token: 0x04001148 RID: 4424
			public T altura;

			// Token: 0x04001149 RID: 4425
			public T lujos;

			// Token: 0x0400114A RID: 4426
			public T paquete;
		}

		// Token: 0x020003DC RID: 988
		private class ItemEqualityComparer : IEqualityComparer<Personalidad.Trait>
		{
			// Token: 0x06001583 RID: 5507 RVA: 0x00052036 File Offset: 0x00050236
			public bool Equals(Personalidad.Trait x, Personalidad.Trait y)
			{
				return x.trait == y.trait;
			}

			// Token: 0x06001584 RID: 5508 RVA: 0x00052046 File Offset: 0x00050246
			public int GetHashCode(Personalidad.Trait obj)
			{
				return obj.trait.GetHashCode();
			}
		}
	}
}
