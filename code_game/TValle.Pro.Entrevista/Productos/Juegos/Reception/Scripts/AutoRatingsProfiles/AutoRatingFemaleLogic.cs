using System;
using System.Collections.Generic;
using Assets.Base.Genetica.Runtime.NPCs;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets.TValle.Pro.Entrevista.Runtime.Actividades;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.Ai.Interpretadores;
using UnityEngine;

namespace Assets.Productos.Juegos.Reception.Scripts.AutoRatingsProfiles
{
	// Token: 0x02000018 RID: 24
	public class AutoRatingFemaleLogic : AplicableCustomMonobehaviour, ICharacterAutoRateable
	{
		// Token: 0x06000106 RID: 262 RVA: 0x00005C5C File Offset: 0x00003E5C
		protected override void StartUnityEvent()
		{
			base.StartUnityEvent();
			this.m_character = base.GetComponentInParent<ICharacter>();
			if (this.m_character == null)
			{
				throw new ArgumentNullException("m_character", "m_character null reference.");
			}
			this.m_InterpretadorDeFemales = this.m_character.GetComponentInChildren<InterpretadorDeFemales>();
			if (this.m_InterpretadorDeFemales == null)
			{
				throw new ArgumentNullException("m_InterpretadorDeFemales", "m_InterpretadorDeFemales null reference.");
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00005CC4 File Offset: 0x00003EC4
		public object DoAutoRating(out IReadOnlyDictionary<string, float> aparienciaRatingResult, out IReadOnlyDictionary<string, float> personalidadRatingResult)
		{
			aparienciaRatingResult = null;
			personalidadRatingResult = null;
			if (!Singleton<SimplifiedAutoRatings>.instance.AutoRatingSeAplica())
			{
				return null;
			}
			this.m_aparienciaAutoRating.Clear();
			this.m_personalidadAutoRating.Clear();
			this.m_InterpretadorDeFemales.Interpretar();
			object obj = Singleton<SimplifiedAutoRatings>.instance.Score(ref this.m_InterpretadorDeFemales.interpretacion, this.m_aparienciaAutoRating, this.m_personalidadAutoRating);
			aparienciaRatingResult = this.m_aparienciaAutoRating;
			personalidadRatingResult = this.m_personalidadAutoRating;
			return obj;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00005D38 File Offset: 0x00003F38
		public void DoAutoRating()
		{
			EntrevistaParaCalificarFemaleCharacterFromPool entrevistaParaCalificarFemaleCharacterFromPool = (EntrevistaParaCalificarFemaleCharacterFromPool)Actividad.running;
			if (entrevistaParaCalificarFemaleCharacterFromPool != null)
			{
				if (!entrevistaParaCalificarFemaleCharacterFromPool.femaleCharacterCanBeRated)
				{
					return;
				}
				if (entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresApariencia.mapaDeValores != null)
				{
					entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresApariencia.Save();
				}
				if (entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresPersonalidad.mapaDeValores != null)
				{
					entrevistaParaCalificarFemaleCharacterFromPool.currentFemaleCharacterAlteradoresPersonalidad.Save();
				}
			}
			IReadOnlyDictionary<string, float> readOnlyDictionary;
			IReadOnlyDictionary<string, float> readOnlyDictionary2;
			if ((AutoRatingProfile)this.DoAutoRating(out readOnlyDictionary, out readOnlyDictionary2) != null && entrevistaParaCalificarFemaleCharacterFromPool != null)
			{
				foreach (KeyValuePair<string, float> keyValuePair in this.m_aparienciaAutoRating)
				{
					entrevistaParaCalificarFemaleCharacterFromPool.flagScoreAparienciaCurrentFemaleV2.AddOrReplase(keyValuePair.Key, keyValuePair.Value);
				}
				foreach (KeyValuePair<string, float> keyValuePair2 in this.m_personalidadAutoRating)
				{
					entrevistaParaCalificarFemaleCharacterFromPool.flagScorePersonalidadCurrentFemaleV2.AddOrReplase(keyValuePair2.Key, keyValuePair2.Value);
				}
				entrevistaParaCalificarFemaleCharacterFromPool.CalificarCurrentFemale();
			}
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00005E74 File Offset: 0x00004074
		protected override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Do Auto Rating",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600010A RID: 266 RVA: 0x00005E90 File Offset: 0x00004090
		protected override void OnAplicar2()
		{
			base.OnAplicar2();
			IReadOnlyDictionary<string, float> readOnlyDictionary;
			IReadOnlyDictionary<string, float> readOnlyDictionary2;
			this.DoAutoRating(out readOnlyDictionary, out readOnlyDictionary2);
		}

		// Token: 0x04000098 RID: 152
		private ICharacter m_character;

		// Token: 0x04000099 RID: 153
		[ReadOnlyUI]
		[SerializeField]
		private InterpretadorDeFemales m_InterpretadorDeFemales;

		// Token: 0x0400009A RID: 154
		[SerializeField]
		private StringKeyFloatValueDictionary m_aparienciaAutoRating = new StringKeyFloatValueDictionary();

		// Token: 0x0400009B RID: 155
		[SerializeField]
		private StringKeyFloatValueDictionary m_personalidadAutoRating = new StringKeyFloatValueDictionary();
	}
}
