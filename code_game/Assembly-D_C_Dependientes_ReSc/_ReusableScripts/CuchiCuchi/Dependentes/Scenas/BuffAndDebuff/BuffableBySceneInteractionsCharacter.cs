using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Tools.Runtime.Characters.BuffAndDebuff;
using Assets.TValle.Tools.Runtime.Characters.Scenes;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.AI.Emociones.Handlers;
using Assets._ReusableScripts.CuchiCuchi.Controllers;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.BuffAndDebuff;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff.Clases;
using Assets._ReusableScripts.CuchiCuchi.Skins.Semen;
using Assets._ReusableScripts.CuchiCuchi._CharactersBasics;
using InterfaceFields;
using UnityEngine;

namespace Assets._ReusableScripts.CuchiCuchi.Dependentes.Scenas.BuffAndDebuff
{
	// Token: 0x0200007F RID: 127
	public class BuffableBySceneInteractionsCharacter : CustomMonobehaviour, IBuffableBySceneInteractionsCharacter
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x00012E0C File Offset: 0x0001100C
		protected override void AwakeUnityEvent()
		{
			base.AwakeUnityEvent();
			this.m_character = this.GetComponentEnRoot(false);
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_BuffDeCharacter = this.GetComponentEnRoot(false);
			if (this.m_BuffDeCharacter == null)
			{
				throw new ArgumentNullException("m_BuffDeCharacter", "m_BuffDeCharacter null reference.");
			}
			base.SetYieldStart();
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00012E7B File Offset: 0x0001107B
		protected override IEnumerator YieldStartUnityEvent()
		{
			this.m_AplicadorParaHoles = new BuffableBySceneInteractionsCharacter.AplicadorParaHoles();
			this.m_AplicadorParaEmos = new BuffableBySceneInteractionsCharacter.AplicadorParaEmos();
			this.m_AplicadorParaFemaleAI = new BuffableBySceneInteractionsCharacter.AplicadorParaFemaleAI();
			this.m_AplicadorParaKarma = new BuffableBySceneInteractionsCharacter.AplicadorParaKarma();
			this.m_AplicadorParaOxigeno = new BuffableBySceneInteractionsCharacter.AplicadorParaOxigeno();
			this.m_AplicadorParaEyaculaciones = new BuffableBySceneInteractionsCharacter.AplicadorParaEyaculaciones();
			yield return this.m_AplicadorParaHoles.Init(this);
			yield return this.m_AplicadorParaEmos.Init(this);
			yield return this.m_AplicadorParaFemaleAI.Init(this);
			yield return this.m_AplicadorParaKarma.Init(this);
			yield return this.m_AplicadorParaOxigeno.Init(this);
			yield return this.m_AplicadorParaEyaculaciones.Init(this);
			yield break;
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x00012E8C File Offset: 0x0001108C
		public void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
		{
			if (!base.isStared)
			{
				throw new InvalidOperationException();
			}
			for (int i = 0; i < this.m_aplicadores.Count; i++)
			{
				BuffableBySceneInteractionsCharacter.Aplicador aplicador = this.m_aplicadores[i];
				if (aplicador.isValid)
				{
					aplicador.Apply(buffAndDebuff);
				}
			}
		}

		// Token: 0x040002DD RID: 733
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaHoles m_AplicadorParaHoles;

		// Token: 0x040002DE RID: 734
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaEmos m_AplicadorParaEmos;

		// Token: 0x040002DF RID: 735
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaFemaleAI m_AplicadorParaFemaleAI;

		// Token: 0x040002E0 RID: 736
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaKarma m_AplicadorParaKarma;

		// Token: 0x040002E1 RID: 737
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaOxigeno m_AplicadorParaOxigeno;

		// Token: 0x040002E2 RID: 738
		[SerializeField]
		private BuffableBySceneInteractionsCharacter.AplicadorParaEyaculaciones m_AplicadorParaEyaculaciones;

		// Token: 0x040002E3 RID: 739
		private Character m_character;

		// Token: 0x040002E4 RID: 740
		private BuffDeCharacter m_BuffDeCharacter;

		// Token: 0x040002E5 RID: 741
		[SerializeReference]
		private List<BuffableBySceneInteractionsCharacter.Aplicador> m_aplicadores = new List<BuffableBySceneInteractionsCharacter.Aplicador>();

		// Token: 0x02000080 RID: 128
		[Serializable]
		public class AplicadorParaHoles : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x17000070 RID: 112
			// (get) Token: 0x060002B7 RID: 695 RVA: 0x00012EEC File Offset: 0x000110EC
			public override bool isValid
			{
				get
				{
					return this.m_boca != null && this.m_vag != null && this.m_anus != null;
				}
			}

			// Token: 0x060002B8 RID: 696 RVA: 0x00012F18 File Offset: 0x00011118
			protected override IEnumerator OnInit()
			{
				this.m_boca = this.m_owner.m_character.GetComponentInChildren<BocaSexController>();
				this.m_vag = this.m_owner.m_character.GetComponentInChildren<VagController>();
				this.m_anus = this.m_owner.m_character.GetComponentInChildren<AnusController>();
				yield break;
			}

			// Token: 0x060002B9 RID: 697 RVA: 0x00012F27 File Offset: 0x00011127
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnHoleWearingMotion>(buffAndDebuff.BuffOnHoleWearingMotion, "Tvalle.Buff.HoleWearingMotion");
				base.GenericApply<BuffOnHoleWearingBottom>(buffAndDebuff.BuffOnHoleWearingBottom, "Tvalle.Buff.HoleWearingBottom");
				base.GenericApply<BuffOnHoleWearingWalls>(buffAndDebuff.BuffOnHoleWearingWalls, "Tvalle.Buff.HoleWearingWalls");
			}

			// Token: 0x040002E6 RID: 742
			[SerializeField]
			[ReadOnlyUI]
			private BocaSexController m_boca;

			// Token: 0x040002E7 RID: 743
			[SerializeField]
			[ReadOnlyUI]
			private VagController m_vag;

			// Token: 0x040002E8 RID: 744
			[SerializeField]
			[ReadOnlyUI]
			private AnusController m_anus;
		}

		// Token: 0x02000082 RID: 130
		[Serializable]
		public class AplicadorParaFemaleAI : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x17000073 RID: 115
			// (get) Token: 0x060002C1 RID: 705 RVA: 0x00012FE6 File Offset: 0x000111E6
			public override bool isValid
			{
				get
				{
					return this.m_Per != null && this.m_deseos != null && this.m_ConsentNecesario != null && this.m_EmocionesFemeninasBase != null;
				}
			}

			// Token: 0x060002C2 RID: 706 RVA: 0x00013020 File Offset: 0x00011220
			protected override IEnumerator OnInit()
			{
				this.m_Per = this.m_owner.m_character.GetComponentInChildren<Personalidad>();
				this.m_deseos = this.m_owner.m_character.GetComponentInChildren<Deseos>();
				this.m_ConsentNecesario = this.m_owner.m_character.GetComponentInChildren<ConsentNecesario>();
				this.m_EmocionesFemeninasBase = this.m_owner.m_character.GetComponentInChildren<EmocionesFemeninasBase>();
				yield break;
			}

			// Token: 0x060002C3 RID: 707 RVA: 0x00013030 File Offset: 0x00011230
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnPersonalityTrait>(buffAndDebuff.BuffOnPersonalityTrait, "Tvalle.Buff.PersonalityTrait");
				base.GenericApply<BuffOnDesires>(buffAndDebuff.BuffOnDesires, "Tvalle.Buff.Desires");
				base.GenericApply<BuffOnFavorabilityReqOfInteraction>(buffAndDebuff.BuffOnFavorabilityReqOfInteraction, "Tvalle.Buff.FavorabilityReq");
				base.GenericApply<BuffOnInteraction>(buffAndDebuff.BuffOnInteraction, "Tvalle.Buff.Interaction");
			}

			// Token: 0x040002EC RID: 748
			[SerializeField]
			[ReadOnlyUI]
			private Personalidad m_Per;

			// Token: 0x040002ED RID: 749
			[SerializeField]
			[ReadOnlyUI]
			private Deseos m_deseos;

			// Token: 0x040002EE RID: 750
			[SerializeField]
			[ReadOnlyUI]
			private ConsentNecesario m_ConsentNecesario;

			// Token: 0x040002EF RID: 751
			[SerializeField]
			[ReadOnlyUI]
			private EmocionesFemeninasBase m_EmocionesFemeninasBase;
		}

		// Token: 0x02000084 RID: 132
		[Serializable]
		public class AplicadorParaKarma : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x17000076 RID: 118
			// (get) Token: 0x060002CB RID: 715 RVA: 0x00013118 File Offset: 0x00011318
			public override bool isValid
			{
				get
				{
					return this.karma != null;
				}
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x060002CC RID: 716 RVA: 0x00013123 File Offset: 0x00011323
			private ICharacterKarma karma
			{
				get
				{
					return this.m_karma as ICharacterKarma;
				}
			}

			// Token: 0x060002CD RID: 717 RVA: 0x00013130 File Offset: 0x00011330
			protected override IEnumerator OnInit()
			{
				this.m_karma = this.m_owner.m_character.GetComponentInChildren<ICharacterKarma>() as Object;
				yield break;
			}

			// Token: 0x060002CE RID: 718 RVA: 0x0001313F File Offset: 0x0001133F
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnKarma>(buffAndDebuff.BuffOnKarma, "Tvalle.Buff.Karma");
			}

			// Token: 0x040002F3 RID: 755
			[ConstraintType(typeof(ICharacterKarma), true)]
			[SerializeField]
			private Object m_karma;
		}

		// Token: 0x02000086 RID: 134
		[Serializable]
		public class AplicadorParaEmos : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x1700007A RID: 122
			// (get) Token: 0x060002D6 RID: 726 RVA: 0x000131AF File Offset: 0x000113AF
			public override bool isValid
			{
				get
				{
					return this.m_Emos != null;
				}
			}

			// Token: 0x060002D7 RID: 727 RVA: 0x000131BD File Offset: 0x000113BD
			protected override IEnumerator OnInit()
			{
				this.m_Emos = this.m_owner.m_character.GetComponentInChildren<EmocionesHumanasBase>();
				yield break;
			}

			// Token: 0x060002D8 RID: 728 RVA: 0x000131CC File Offset: 0x000113CC
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnEmotion>(buffAndDebuff.BuffOnEmotion, "Tvalle.Buff.Emotion");
				base.GenericApply<BuffOnEmotionTowardCharacter>(buffAndDebuff.BuffOnEmotionTowardCharacter, "Tvalle.Buff.EmotionTowardCharacter");
				base.GenericApply<BuffOnEmotionAura>(buffAndDebuff.BuffOnEmotionAura, "Tvalle.Buff.EmotionAura");
			}

			// Token: 0x040002F7 RID: 759
			[SerializeField]
			[ReadOnlyUI]
			private EmocionesHumanasBase m_Emos;
		}

		// Token: 0x02000088 RID: 136
		[Serializable]
		public class AplicadorParaOxigeno : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x1700007D RID: 125
			// (get) Token: 0x060002E0 RID: 736 RVA: 0x00013256 File Offset: 0x00011456
			public override bool isValid
			{
				get
				{
					return this.respirador != null;
				}
			}

			// Token: 0x1700007E RID: 126
			// (get) Token: 0x060002E1 RID: 737 RVA: 0x00013261 File Offset: 0x00011461
			private ICharacterRespirador respirador
			{
				get
				{
					return this.m_respirador as ICharacterRespirador;
				}
			}

			// Token: 0x060002E2 RID: 738 RVA: 0x0001326E File Offset: 0x0001146E
			protected override IEnumerator OnInit()
			{
				this.m_respirador = this.m_owner.m_character.GetComponentInChildren<ICharacterRespirador>() as Object;
				yield break;
			}

			// Token: 0x060002E3 RID: 739 RVA: 0x0001327D File Offset: 0x0001147D
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnOxygenDemand>(buffAndDebuff.BuffOnOxygenDemand, "Tvalle.Buff.OxygenDemand");
			}

			// Token: 0x040002FB RID: 763
			[ConstraintType(typeof(ICharacterRespirador), true)]
			[SerializeField]
			private Object m_respirador;
		}

		// Token: 0x0200008A RID: 138
		[Serializable]
		public class AplicadorParaEyaculaciones : BuffableBySceneInteractionsCharacter.Aplicador
		{
			// Token: 0x17000081 RID: 129
			// (get) Token: 0x060002EB RID: 747 RVA: 0x000132EB File Offset: 0x000114EB
			public override bool isValid
			{
				get
				{
					return this.m_semen != null;
				}
			}

			// Token: 0x060002EC RID: 748 RVA: 0x000132F9 File Offset: 0x000114F9
			protected override IEnumerator OnInit()
			{
				this.m_semen = this.m_owner.m_character.GetComponentInChildren<SemenParaPene>();
				yield break;
			}

			// Token: 0x060002ED RID: 749 RVA: 0x00013308 File Offset: 0x00011508
			public override void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff)
			{
				base.GenericApply<BuffOnEyaculationTimes>(buffAndDebuff.BuffOnEyaculationTimes, "Tvalle.Buff.EyaculationTimes");
				base.GenericApply<BuffOnEyaculationAmount>(buffAndDebuff.BuffOnEyaculationAmount, "Tvalle.Buff.EyaculationAmount");
			}

			// Token: 0x040002FF RID: 767
			[ReadOnlyUI]
			[SerializeField]
			private SemenParaPene m_semen;
		}

		// Token: 0x0200008C RID: 140
		[Serializable]
		public abstract class Aplicador
		{
			// Token: 0x060002F5 RID: 757 RVA: 0x00013382 File Offset: 0x00011582
			public IEnumerator Init(BuffableBySceneInteractionsCharacter owner)
			{
				this.m_owner = owner;
				yield return this.OnInit();
				this.m_owner.m_aplicadores.Add(this);
				yield break;
			}

			// Token: 0x17000084 RID: 132
			// (get) Token: 0x060002F6 RID: 758
			public abstract bool isValid { get; }

			// Token: 0x060002F7 RID: 759
			protected abstract IEnumerator OnInit();

			// Token: 0x060002F8 RID: 760
			public abstract void Apply(SceneCharacterFromToBuffAndDebuff buffAndDebuff);

			// Token: 0x060002F9 RID: 761 RVA: 0x00013398 File Offset: 0x00011598
			protected void GenericApply<TKey, TBuff>(Dictionary<TKey, TBuff> dicc, string buffID) where TKey : struct, ITuple where TBuff : IIdentifiableBuff<TKey>, IValidableBuff, IEndableOnDateBuff, IContextValidableBuff
			{
				if (dicc == null)
				{
					return;
				}
				foreach (KeyValuePair<TKey, TBuff> keyValuePair in dicc)
				{
					TBuff value = keyValuePair.Value;
					TKey key = keyValuePair.Key;
					string text = key.ToString();
					this.GenericApply<TBuff>(value, text, buffID);
				}
				this.m_owner.m_BuffDeCharacter.eventos.Sort();
			}

			// Token: 0x060002FA RID: 762 RVA: 0x00013420 File Offset: 0x00011620
			protected void GenericApply<TBuff>(Dictionary<ITuple, TBuff> dicc, string buffID) where TBuff : IIdentifiableBuff, IValidableBuff, IEndableOnDateBuff, IContextValidableBuff
			{
				if (dicc == null)
				{
					return;
				}
				foreach (KeyValuePair<ITuple, TBuff> keyValuePair in dicc)
				{
					TBuff value = keyValuePair.Value;
					string text = keyValuePair.Key.ToString();
					this.GenericApply<TBuff>(value, text, buffID);
				}
				this.m_owner.m_BuffDeCharacter.eventos.Sort();
			}

			// Token: 0x060002FB RID: 763 RVA: 0x000134A0 File Offset: 0x000116A0
			protected void GenericApply<TBuff>(TBuff buffValue, string buffStringKey, string buffID) where TBuff : IIdentifiableBuff, IValidableBuff, IEndableOnDateBuff, IContextValidableBuff
			{
				if (!buffValue.isValid || !buffValue.isContextValid)
				{
					Debug.LogError("buff value by interaction scene con id :" + buffStringKey + " no es valido");
					return;
				}
				BuffMap map = Singleton<BuffManager>.instance.GetMap(buffID);
				if (map == null)
				{
					throw new ArgumentNullException("map", "map null reference.");
				}
				Efecto efecto = Singleton<EfectosManager>.instance.GetEfecto(map.efectoId);
				IByInteraccionEnScenaArg byInteraccionEnScenaArg;
				if (!Singleton<ArgumentosDeEfectosManager>.instance.TryInstantiateArg<IByInteraccionEnScenaArg>(efecto.argumentoID, out byInteraccionEnScenaArg))
				{
					Debug.LogError("arg id :" + efecto.argumentoID + " no fue encontrado o es de tipo incorrecto");
					return;
				}
				if (!byInteraccionEnScenaArg.TrySetyInteraccionEnScenaBuffValue(buffValue))
				{
					Debug.LogError("buff value by interaction scene con id :" + buffStringKey + " no se puedo ligar a argumento con id: " + efecto.argumentoID);
					return;
				}
				byInteraccionEnScenaArg.flagUpdateNonLocalizedTextV2 = true;
				BuffMap.Duracion duracion;
				if (!buffValue.infinite)
				{
					DateTime now = Singleton<TiempoDeJuego>.instance.now;
					TimeSpan timeSpan = buffValue.endTime - now;
					duracion = new BuffMap.Duracion();
					duracion.days = timeSpan.Days;
					duracion.hours = timeSpan.Hours;
					duracion.minutes = timeSpan.Minutes;
					duracion.seconds = timeSpan.Seconds;
				}
				else
				{
					duracion = new BuffMap.Duracion();
					duracion.infinite = true;
				}
				BySceceInteractionsBuff eventoBuff = map.GetEventoBuff<BySceceInteractionsBuff>(Singleton<TiempoDeJuego>.instance.now, buffStringKey, (ArgumentoDeEfecto)byInteraccionEnScenaArg, duracion);
				if (eventoBuff == null)
				{
					throw new ArgumentNullException("buff", "buff null reference.");
				}
				this.m_owner.m_BuffDeCharacter.eventos.AddOrStackUp(eventoBuff, false, false);
			}

			// Token: 0x04000303 RID: 771
			protected BuffableBySceneInteractionsCharacter m_owner;
		}
	}
}
