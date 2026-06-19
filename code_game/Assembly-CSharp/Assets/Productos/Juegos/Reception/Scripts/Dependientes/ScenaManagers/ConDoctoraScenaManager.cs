using System;
using System.Collections.Generic;
using Assets.SingletonesAndSystemasGlobales.AbstractLayer.Globales;
using Assets._ReusableScripts.CuchiCuchi;
using Assets._ReusableScripts.CuchiCuchi.AI;
using Assets._ReusableScripts.CuchiCuchi.Characters.Alteradores.Mapas.Abstracts;
using Assets._ReusableScripts.CuchiCuchi.Dependentes.ScenaManagers;
using Assets._ReusableScripts.CuchiCuchi.Ropa;
using Assets._ReusableScripts.UI;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Productos.Juegos.Reception.Scripts.Dependientes.ScenaManagers
{
	// Token: 0x020000B9 RID: 185
	public abstract class ConDoctoraScenaManager : ScenaCharacteresManager
	{
		// Token: 0x06000423 RID: 1059 RVA: 0x00014C18 File Offset: 0x00012E18
		protected override void Onload(LoadSceneMode loadSceneMode)
		{
			if (this.Doctora == null)
			{
				throw new ArgumentNullException("Doctora", "Doctora null reference.");
			}
			this.LoadFemale();
			if (this.gameOverOnMaxActive)
			{
				foreach (ReaccionHumana reaccionHumana in this.gameOverOnMax)
				{
					base.GameOverOnMax(this.Doctora, reaccionHumana);
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00014CA0 File Offset: 0x00012EA0
		protected override void OnUnload()
		{
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00014CA2 File Offset: 0x00012EA2
		protected override void OnGameOverPorMax(Emocion emo)
		{
			GameOverPanel instance = Singleton<GameOverPanel>.instance;
			if (instance == null)
			{
				return;
			}
			instance.ChangeState(true);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00014CB4 File Offset: 0x00012EB4
		private void Doc_stared(object obj)
		{
			this.emocionesValoresConfig.Load((FemaleChar)obj);
			if (this.addEstetoscopio && !string.IsNullOrWhiteSpace(this.estetoscopioID))
			{
				base.LoadFemaleRopa<EstetoscopioPiel>(this.Doctora, this.estetoscopioID);
			}
			this.OnDocStared((FemaleChar)obj);
		}

		// Token: 0x06000427 RID: 1063
		protected abstract void OnDocStared(FemaleChar doc);

		// Token: 0x06000428 RID: 1064 RVA: 0x00014D08 File Offset: 0x00012F08
		private void LoadFemale()
		{
			base.BindMainCharacter("Doctora", "Doctora TODO name", this.Doctora);
			base.LoadAparienciaFisica(this.Doctora, this.aparienciaFisica);
			this.AddConversaciones();
			foreach (GameObject gameObject in this.interaccionesDynamicasDeFemalePrefabs)
			{
				base.InstantiateInteraccionDynamica(gameObject, this.Doctora, 1.5f);
			}
			base.AddStaredListiner(this.Doctora, new CustomMonobehaviourEventHandler(this.Doc_stared));
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00014DAC File Offset: 0x00012FAC
		private void AddConversaciones()
		{
			Animator bodyAnimator = this.Doctora.bodyAnimator;
			Transform boneTransform = this.Doctora.bodyAnimator.GetBoneTransform(HumanBodyBones.Head);
			foreach (ConversationTrigger conversationTrigger in this.conversaciones)
			{
				base.InstantiateConversationTrigger(conversationTrigger, boneTransform.position, this.Doctora.bodyAnimator.transform.rotation, this.Doctora.transform.FindChildNotNull("Conversaciones"), boneTransform.lossyScale, bodyAnimator.transform);
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00014E5C File Offset: 0x0001305C
		protected sealed override CustomMonobehaviourBotonConfig Boton2()
		{
			return new CustomMonobehaviourBotonConfig
			{
				text = "Re Add Conversaciones",
				editorTimeVisible = false
			};
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00014E75 File Offset: 0x00013075
		protected sealed override void OnAplicar2()
		{
			base.OnAplicar2();
			this.AddConversaciones();
		}

		// Token: 0x040001CE RID: 462
		[Tooltip("Opcional")]
		public string doctoraNombre;

		// Token: 0x040001CF RID: 463
		[Tooltip("Opcional")]
		public string jugadorNombre;

		// Token: 0x040001D0 RID: 464
		[Space]
		public ScenaCharacteresManager.EmocionesConfig emocionesValoresConfig = new ScenaCharacteresManager.EmocionesConfig();

		// Token: 0x040001D1 RID: 465
		public MapaDeAlteracionesAparienciaFemeninaBase aparienciaFisica;

		// Token: 0x040001D2 RID: 466
		[Header("Scena References")]
		public FemaleChar Doctora;

		// Token: 0x040001D3 RID: 467
		public bool addEstetoscopio;

		// Token: 0x040001D4 RID: 468
		[Tooltip("Zero o menor a zero para no usar estetoscopio")]
		public string estetoscopioID;

		// Token: 0x040001D5 RID: 469
		[CoolArrayItem]
		public List<ConversationTrigger> conversaciones = new List<ConversationTrigger>();

		// Token: 0x040001D6 RID: 470
		[CoolArrayItem]
		public List<GameObject> interaccionesDynamicasDeFemalePrefabs = new List<GameObject>();

		// Token: 0x040001D7 RID: 471
		public bool gameOverOnMaxActive;

		// Token: 0x040001D8 RID: 472
		public List<ReaccionHumana> gameOverOnMax = new List<ReaccionHumana>();
	}
}
