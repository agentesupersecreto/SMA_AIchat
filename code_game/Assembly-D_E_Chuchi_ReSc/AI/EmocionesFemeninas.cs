using System;
using System.Collections.Generic;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Mapas;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.AI
{
	// Token: 0x0200034A RID: 842
	public sealed class EmocionesFemeninas : EmocionesFemeninasBase
	{
		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x06001213 RID: 4627 RVA: 0x0004E553 File Offset: 0x0004C753
		public sealed override int updateEvent1Index
		{
			get
			{
				return 70;
			}
		}

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x06001214 RID: 4628 RVA: 0x0004E557 File Offset: 0x0004C757
		public override Alegria alegria
		{
			get
			{
				return this.m_alegria;
			}
		}

		// Token: 0x1700046A RID: 1130
		// (get) Token: 0x06001215 RID: 4629 RVA: 0x0004E55F File Offset: 0x0004C75F
		public override PlacerBase placer
		{
			get
			{
				return this.m_placer;
			}
		}

		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06001216 RID: 4630 RVA: 0x0004E567 File Offset: 0x0004C767
		public override Dolor dolor
		{
			get
			{
				return this.m_dolor;
			}
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06001217 RID: 4631 RVA: 0x0004E56F File Offset: 0x0004C76F
		public override Decepcion decepcion
		{
			get
			{
				return this.m_Decepcion;
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06001218 RID: 4632 RVA: 0x0004E577 File Offset: 0x0004C777
		public override Arousal arousal
		{
			get
			{
				return this.m_arousal;
			}
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06001219 RID: 4633 RVA: 0x0004E57F File Offset: 0x0004C77F
		public override Boredom boredom
		{
			get
			{
				return this.m_boredom;
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x0600121A RID: 4634 RVA: 0x0004E587 File Offset: 0x0004C787
		public override ConsentToHero consentToHero
		{
			get
			{
				return this.m_concentToHero;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x0600121B RID: 4635 RVA: 0x0004E58F File Offset: 0x0004C78F
		public override Rage rage
		{
			get
			{
				return this.m_rage;
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x0600121C RID: 4636 RVA: 0x0004E597 File Offset: 0x0004C797
		public override Alivio alivio
		{
			get
			{
				return this.m_Alivio;
			}
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x0600121D RID: 4637 RVA: 0x0004E59F File Offset: 0x0004C79F
		public override DesHielo desHielo
		{
			get
			{
				return this.m_desHielo;
			}
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x0600121E RID: 4638 RVA: 0x0004E5A7 File Offset: 0x0004C7A7
		public override Fear fear
		{
			get
			{
				return this.m_fear;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x0600121F RID: 4639 RVA: 0x0004E5AF File Offset: 0x0004C7AF
		public EmocionesHumanasBase.Config config
		{
			get
			{
				return this.m_Config;
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06001220 RID: 4640 RVA: 0x0004E5B7 File Offset: 0x0004C7B7
		public IReadOnlyList<Emocion> emociones
		{
			get
			{
				return this.m_emociones;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06001221 RID: 4641 RVA: 0x0004E5BF File Offset: 0x0004C7BF
		public Sexo sexo
		{
			get
			{
				return this.m_sexo;
			}
		}

		// Token: 0x14000056 RID: 86
		// (add) Token: 0x06001222 RID: 4642 RVA: 0x0004E5C8 File Offset: 0x0004C7C8
		// (remove) Token: 0x06001223 RID: 4643 RVA: 0x0004E600 File Offset: 0x0004C800
		public event Action<EmocionesFemeninas> updatingEmociones;

		// Token: 0x14000057 RID: 87
		// (add) Token: 0x06001224 RID: 4644 RVA: 0x0004E638 File Offset: 0x0004C838
		// (remove) Token: 0x06001225 RID: 4645 RVA: 0x0004E670 File Offset: 0x0004C870
		public event Action<EmocionesFemeninas> updateEmociones1;

		// Token: 0x14000058 RID: 88
		// (add) Token: 0x06001226 RID: 4646 RVA: 0x0004E6A8 File Offset: 0x0004C8A8
		// (remove) Token: 0x06001227 RID: 4647 RVA: 0x0004E6E0 File Offset: 0x0004C8E0
		public event Action<EmocionesFemeninas> updateEmociones2;

		// Token: 0x14000059 RID: 89
		// (add) Token: 0x06001228 RID: 4648 RVA: 0x0004E718 File Offset: 0x0004C918
		// (remove) Token: 0x06001229 RID: 4649 RVA: 0x0004E750 File Offset: 0x0004C950
		public event Action<EmocionesFemeninas> updatedEmociones;

		// Token: 0x0600122A RID: 4650 RVA: 0x0004E788 File Offset: 0x0004C988
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_sexo = base.owner.sexo;
			foreach (Emocion emocion in this.m_emociones)
			{
				this.m_emocionesSet.Add(emocion);
				if (!this.m_emocionDeReaccion.ContainsKey((int)emocion.reaccion))
				{
					this.m_emocionDeReaccion.Add((int)emocion.reaccion, emocion);
				}
			}
		}

		// Token: 0x0600122B RID: 4651 RVA: 0x0004E820 File Offset: 0x0004CA20
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			foreach (Emocion emocion in this.m_emociones)
			{
				emocion.Init(this);
			}
		}

		// Token: 0x0600122C RID: 4652 RVA: 0x0004E878 File Offset: 0x0004CA78
		public override Emocion ObtenerEmocion(ReaccionHumana reaccion)
		{
			Emocion emocion;
			if (this.m_emocionDeReaccion.TryGetValue((int)reaccion, out emocion))
			{
				return emocion;
			}
			return null;
		}

		// Token: 0x0600122D RID: 4653 RVA: 0x0004E898 File Offset: 0x0004CA98
		protected override void EditorAdded()
		{
			base.EditorAdded();
			this.AñadirEmociones();
		}

		// Token: 0x0600122E RID: 4654 RVA: 0x0004E8A8 File Offset: 0x0004CAA8
		public void AñadirEmociones()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this.m_emociones.Clear();
			this.AñadorEmocionDeTipo<ConsentToHero>(ref this.m_concentToHero);
			this.AñadorEmocionDeTipo<Arousal>(ref this.m_arousal);
			this.AñadorEmocionDeTipo<Placer>(ref this.m_placer);
			this.AñadorEmocionDeTipo<Dolor>(ref this.m_dolor);
			this.AñadorEmocionDeTipo<Decepcion>(ref this.m_Decepcion);
			this.AñadorEmocionDeTipo<Boredom>(ref this.m_boredom);
			this.AñadorEmocionDeTipo<Rage>(ref this.m_rage);
			this.AñadorEmocionDeTipo<Alivio>(ref this.m_Alivio);
			this.AñadorEmocionDeTipo<Alegria>(ref this.m_alegria);
			this.AñadorEmocionDeTipo<DesHielo>(ref this.m_desHielo);
			this.AñadorEmocionDeTipo<Fear>(ref this.m_fear);
		}

		// Token: 0x0600122F RID: 4655 RVA: 0x0004E94C File Offset: 0x0004CB4C
		public sealed override void OnUpdateEvent1()
		{
			bool reportToProfiler = base.reportToProfiler;
			Action<EmocionesFemeninas> action = this.updatingEmociones;
			if (action != null)
			{
				action(this);
			}
			for (int i = 0; i < this.m_emociones.Count; i++)
			{
				Emocion emocion = this.m_emociones[i];
				if (emocion.isActiveAndEnabled)
				{
					emocion.UpdateEmotion(this.GetLimitDeEmocion(emocion));
				}
			}
			Action<EmocionesFemeninas> action2 = this.updateEmociones1;
			if (action2 != null)
			{
				action2(this);
			}
			base.CalleEvent_UpdateEmociones2Base();
			Action<EmocionesFemeninas> action3 = this.updateEmociones2;
			if (action3 != null)
			{
				action3(this);
			}
			bool reportToProfiler2 = base.reportToProfiler;
			bool reportToProfiler3 = base.reportToProfiler;
			Action<EmocionesFemeninas> action4 = this.updatedEmociones;
			if (action4 != null)
			{
				action4(this);
			}
			bool reportToProfiler4 = base.reportToProfiler;
		}

		// Token: 0x06001230 RID: 4656 RVA: 0x0004E9FC File Offset: 0x0004CBFC
		private EmocionesHumanasBase.Config.Limite GetLimitDeEmocion(Emocion emo)
		{
			ReaccionHumana reaccion = emo.reaccion;
			if (reaccion <= ReaccionHumana.miedo)
			{
				if (reaccion <= ReaccionHumana.placer)
				{
					switch (reaccion)
					{
					case ReaccionHumana.None:
					case ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro:
					case ReaccionHumana.concentToHero | ReaccionHumana.dolor:
					case ReaccionHumana.asombro | ReaccionHumana.dolor:
					case ReaccionHumana.concentToHero | ReaccionHumana.asombro | ReaccionHumana.dolor:
						break;
					case ReaccionHumana.concentToHero:
						return this.m_Config.limitesDeEmociones.concentToHero;
					case ReaccionHumana.dolor:
						return this.m_Config.limitesDeEmociones.dolor;
					case ReaccionHumana.rabia:
						return this.m_Config.limitesDeEmociones.rage;
					default:
						if (reaccion != ReaccionHumana.asco)
						{
							if (reaccion == ReaccionHumana.placer)
							{
								return this.m_Config.limitesDeEmociones.placer;
							}
						}
						break;
					}
				}
				else
				{
					if (reaccion == ReaccionHumana.arousal)
					{
						return this.m_Config.limitesDeEmociones.arousal;
					}
					if (reaccion != ReaccionHumana.tristeza)
					{
						if (reaccion == ReaccionHumana.miedo)
						{
							return this.m_Config.limitesDeEmociones.miedo;
						}
					}
				}
			}
			else if (reaccion <= ReaccionHumana.decepcion)
			{
				if (reaccion == ReaccionHumana.alegria)
				{
					return this.m_Config.limitesDeEmociones.alegria;
				}
				if (reaccion != ReaccionHumana.felicidad)
				{
					if (reaccion == ReaccionHumana.decepcion)
					{
						return this.m_Config.limitesDeEmociones.decepcion;
					}
				}
			}
			else
			{
				if (reaccion == ReaccionHumana.alivio)
				{
					return this.m_Config.limitesDeEmociones.alivio;
				}
				if (reaccion == ReaccionHumana.aburrimiento)
				{
					return this.m_Config.limitesDeEmociones.aburrimiento;
				}
				if (reaccion == ReaccionHumana.desHielo)
				{
					return this.m_Config.limitesDeEmociones.desHielo;
				}
			}
			throw new ArgumentOutOfRangeException(emo.reaccion.ToString());
		}

		// Token: 0x06001231 RID: 4657 RVA: 0x0004EBA1 File Offset: 0x0004CDA1
		private void AñadorEmocionDeTipo<T>(ref T result) where T : Emocion
		{
			result = this.AñadorEmocionDeTipo<T>(typeof(T).Name);
		}

		// Token: 0x06001232 RID: 4658 RVA: 0x0004EBBE File Offset: 0x0004CDBE
		private T AñadorEmocionDeTipo<T>() where T : Emocion
		{
			return this.AñadorEmocionDeTipo<T>(typeof(T).Name);
		}

		// Token: 0x06001233 RID: 4659 RVA: 0x0004EBD8 File Offset: 0x0004CDD8
		private T AñadorEmocionDeTipo<T>(string name) where T : Emocion
		{
			T componentInChildren = base.transform.GetComponentInChildren<T>(true);
			if (componentInChildren != null)
			{
				this.m_emociones.Add(componentInChildren);
				return componentInChildren;
			}
			T t = base.transform.CreateChild(name).gameObject.AddComponent<T>();
			this.m_emociones.Add(t);
			return t;
		}

		// Token: 0x06001234 RID: 4660 RVA: 0x0004EC3C File Offset: 0x0004CE3C
		public void BorrarEmociones()
		{
			if (Application.isPlaying)
			{
				return;
			}
			this.m_emociones.Clear();
			foreach (Transform transform in base.GetComponentsInChildren<Transform>(true))
			{
				if (!(transform == base.transform))
				{
					Object.DestroyImmediate(transform.gameObject);
				}
			}
			this.m_emociones.Clear();
		}

		// Token: 0x04000F36 RID: 3894
		[SerializeField]
		[ReadOnlyUI]
		private Alegria m_alegria;

		// Token: 0x04000F37 RID: 3895
		[SerializeField]
		[ReadOnlyUI]
		private Placer m_placer;

		// Token: 0x04000F38 RID: 3896
		[SerializeField]
		[ReadOnlyUI]
		private Dolor m_dolor;

		// Token: 0x04000F39 RID: 3897
		[SerializeField]
		[ReadOnlyUI]
		private Decepcion m_Decepcion;

		// Token: 0x04000F3A RID: 3898
		[SerializeField]
		[ReadOnlyUI]
		private Arousal m_arousal;

		// Token: 0x04000F3B RID: 3899
		[SerializeField]
		[ReadOnlyUI]
		private Boredom m_boredom;

		// Token: 0x04000F3C RID: 3900
		[SerializeField]
		[ReadOnlyUI]
		private ConsentToHero m_concentToHero;

		// Token: 0x04000F3D RID: 3901
		[SerializeField]
		[ReadOnlyUI]
		private Rage m_rage;

		// Token: 0x04000F3E RID: 3902
		[SerializeField]
		[ReadOnlyUI]
		private Alivio m_Alivio;

		// Token: 0x04000F3F RID: 3903
		[SerializeField]
		[ReadOnlyUI]
		private DesHielo m_desHielo;

		// Token: 0x04000F40 RID: 3904
		[SerializeField]
		[ReadOnlyUI]
		private Fear m_fear;

		// Token: 0x04000F41 RID: 3905
		[SerializeField]
		[ReadOnlyUI]
		private Sexo m_sexo;

		// Token: 0x04000F42 RID: 3906
		[SerializeField]
		private EmocionesHumanasBase.Config m_Config = new EmocionesHumanasBase.Config();

		// Token: 0x04000F47 RID: 3911
		[SerializeField]
		[ReadOnlyUI]
		private List<Emocion> m_emociones = new List<Emocion>();

		// Token: 0x04000F48 RID: 3912
		private HashSet<Emocion> m_emocionesSet = new HashSet<Emocion>();

		// Token: 0x04000F49 RID: 3913
		private Dictionary<int, Emocion> m_emocionDeReaccion = new Dictionary<int, Emocion>();

		// Token: 0x04000F4A RID: 3914
		public MapaDeEmociones mapas;
	}
}
